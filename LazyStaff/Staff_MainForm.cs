using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using ExcelDLL = Microsoft.Office.Interop.Excel;
using LazyStaff.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using LazyStaff.Helpers;
using LazyStaff.Models;
using LazyStaff.Repositories;
using System.Globalization;

namespace LazyStaff
{
    public partial class Staff_MainForm : Form
    {
        private BindingList<Device> _devices = new BindingList<Device>();
        private readonly IDeviceRepository _deviceRepository = new DeviceRepository();
        public string password, personnelNumber,
            factoryNumber, deviceType, yearOfIssue, deviceLocation, verifiedTo,
            solutionNumber, sentDate, verificationDate, sphereSreumName, help_serachTB = "Введите Табульный/Заводской номер или дату продления";
        public int index, state, mcInterval, sphereSreumId, passportId;
        public bool gan_state;

        /// <summary>Текущее выбранное устройство в гриде (источник данных — коллекция).</summary>
        public Device CurrentDevice => dataGridView1.CurrentRow?.DataBoundItem as Device;

        /// <summary>Коллекция устройств — единственный источник данных для грида.</summary>
        public IList<Device> Devices => _devices;

        ListMarking listMarking = new ListMarking();
        Search Search = new Search();

        //-----------------------------------
        // Кнопка экспорта из DGV в Excel
        //-----------------------------------
        private void ExportToXml_button_Click(object sender, EventArgs e)
        {
            Thread exportToExcel = new Thread(ExportToExcel);
            exportToExcel.Start();
        }

        //-----------------------------------
        // кнопка ПЕЧАТЬ
        //-----------------------------------
        private void PrintPdf_button_Click(object sender, EventArgs e)
        {
            PDF();
        }

        //-----------------------------------
        // Инициализация
        //-----------------------------------
        public Staff_MainForm()
        {
            InitializeComponent();

            // Включаем двойную буферизацию для DataGridView
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null,
                dataGridView1,
                new object[] { true });

            progressBar1.Visible = false;
            groupBox2.Enabled = true;
            printDateTimePicker.Checked = true;

            Dictionary<string, MetrologicalControlType> metrologicalControlSet = new Dictionary<string, MetrologicalControlType>
            {
                {"Поверка", MetrologicalControlType.Verification},
                {"Калибровка", MetrologicalControlType.Calibration},
                {"В качестве эталона", MetrologicalControlType.AsReference},
                {"Входной контроль", MetrologicalControlType.InputControl},
                {"Иногородняя организация", MetrologicalControlType.OutOfTown}
            };

            cbMetrologicalControlType.DataSource = metrologicalControlSet.ToList();
            cbMetrologicalControlType.DisplayMember = "Key";
            cbMetrologicalControlType.ValueMember = "Value";

            Dictionary<string, RepairType> repairTypeSet = new Dictionary<string, RepairType>
            {
                {"Текущий", RepairType.Current},
                {"Средний", RepairType.Medium},
                {"Капитальный", RepairType.Major},
                {"На месте эксплуатации", RepairType.OnSite},
                {"Иногородняя организация", RepairType.OutOfTown}
            };

            cbRepairType.DataSource = repairTypeSet.ToList();
            cbRepairType.DisplayMember = "Key";
            cbRepairType.ValueMember = "Value";
        }

        //-----------------------------------
        // Событие изменение select состояния строки || количество выделенных приборов
        //-----------------------------------
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int visibleRowCount = dataGridView1.SelectedRows.OfType<DataGridViewRow>().Where(row => row.Visible).Count();
            CountStatusLabel_StatusPanel.Text = "Количество выделенных приборов: " + visibleRowCount.ToString();
        }

        //-----------------------------------
        // Событие окончания сортировки, обновление маркеровки
        //-----------------------------------
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            listMarking.Start(this);
        }

        //---------------------------------
        // Замена устройства
        //---------------------------------
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var device = CurrentDevice;
            if (device == null) return;

            var replaceForm = new ReplaceDevice { DeviceToReplace = device, DevicesList = _devices.Where(d => d.Id != device.Id).ToList() ?? new List<Device>() };
            replaceForm.ShowDialog();

            DataGridView_Load();
        }
        //-----------------------------------
        // Изменение устройства
        //-----------------------------------
        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var device = CurrentDevice;
            if (device == null) return;

            var changeForm = new Change_device { DeviceToEdit = device };
            changeForm.ShowDialog();

            DataGridView_Load();
        }
        //---------------------------------
        // Добавление устройства
        //---------------------------------
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_device AddDevice = new Add_device();
            AddDevice.ShowDialog();

            DataGridView_Load();
        }

        //------------------------------------
        // Выделение Row по ПКМ
        //------------------------------------
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentRow.Selected = true;
            }
        }

        //-----------------------------------
        // Удаление устройства
        //-----------------------------------
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var device = CurrentDevice;
            if (device == null) return;

            var result = MessageBox.Show(
                "Удалить устройство с табульным №" + device.Id + " из базы данных",
                "Подтверждение:",
                MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK) return;

            _deviceRepository.Delete(device.Id);
            _devices.Remove(device);
            UpdateVisibleCountLabel();
            MessageBox.Show("Устройство удалёно!");
        }

        //-----------------------------------
        // Событие при первом отображении формы, загрузка из бд
        //-----------------------------------
        private void Staff_MainForm_Shown(object sender, EventArgs e)
        {
            // Заполняем таблицу из MS SQL
            Thread dataGridUpdate = new Thread(DataGridView_Load);
            dataGridUpdate.Start();
        }

        //----------------------------------------------------------------------------
        // Загрузка данных из БД в коллекцию и привязка к гриду
        //----------------------------------------------------------------------------
        public void DataGridView_Load()
        {
            try
            {
                var list = _deviceRepository.GetAll().ToList();
                _devices = new BindingList<Device>(list);
            }
            catch (Npgsql.NpgsqlException)
            {
                var result = MessageBox.Show(
                    "Не удалось подклюиться к базе данных. Открыть настройки?",
                    "Ошибка",
                    MessageBoxButtons.OK);

                if (result == DialogResult.OK)
                    Application.Exit();
                return;
            }

            Invoke((MethodInvoker)delegate
            {
                dataGridView1.DataSource = _devices;
                ConfigureGridColumns();
            });

            listMarking.Start(this);
            SyncStatusLabel_StatusPanel.Text = "Последняя синхронизация: " + DateTime.Now.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture);
        }

        private void ConfigureGridColumns()
        {
            if (dataGridView1.Columns.Count == 0) return;
            var cols = dataGridView1.Columns;
            if (cols["PassportId"] != null) { cols["PassportId"].HeaderText = "Паспорт. №"; cols["PassportId"].MinimumWidth = 30; cols["PassportId"].DisplayIndex = 0; }
            if (cols["Id"] != null) { cols["Id"].HeaderText = "Таб. №"; cols["Id"].MinimumWidth = 30; cols["Id"].DisplayIndex = 1; }
            if (cols["SerialId"] != null) { cols["SerialId"].HeaderText = "Завод. №"; cols["SerialId"].MinimumWidth = 30; cols["SerialId"].DisplayIndex = 2; }
            if (cols["DeviceTypeName"] != null) { cols["DeviceTypeName"].HeaderText = "Тип устройства"; cols["DeviceTypeName"].MinimumWidth = 40; cols["DeviceTypeName"].DisplayIndex = 3; }
            if (cols["ReleaseYear"] != null) { cols["ReleaseYear"].HeaderText = "Год выпуска"; cols["ReleaseYear"].MinimumWidth = 40; cols["ReleaseYear"].DisplayIndex = 4; }
            if (cols["DateOfShipment"] != null) { cols["DateOfShipment"].HeaderText = "Дата отправки"; cols["DateOfShipment"].DisplayIndex = 5; }
            if (cols["DateCheck"] != null) { cols["DateCheck"].HeaderText = "Дата ГП"; cols["DateCheck"].DisplayIndex = 6; }
            if (cols["Loaction"] != null) { cols["Loaction"].HeaderText = "Расположение"; cols["Loaction"].MinimumWidth = 50; cols["Loaction"].DisplayIndex = 7; }
            if (cols["SphereSREUMId"] != null) { cols["SphereSREUMId"].HeaderText = "ГРОЕИ ID"; cols["SphereSREUMId"].MinimumWidth = 30; cols["SphereSREUMId"].DisplayIndex = 8; }
            if (cols["SphereSREUMName"] != null) { cols["SphereSREUMName"].HeaderText = "Сфера ГРОЕИ"; cols["SphereSREUMName"].MinimumWidth = 60; cols["SphereSREUMName"].DisplayIndex = 9; }
            if (cols["ValidTo"] != null) { cols["ValidTo"].HeaderText = "Продление"; cols["ValidTo"].MinimumWidth = 55; cols["ValidTo"].DisplayIndex = 10; }
            if (cols["Solution"] != null) { cols["Solution"].HeaderText = "Тех. решение"; cols["Solution"].MinimumWidth = 60; cols["Solution"].DisplayIndex = 11; }
            if (cols["MetrologicalControlInterval"] != null) { cols["MetrologicalControlInterval"].HeaderText = "М/П Инт."; cols["MetrologicalControlInterval"].MinimumWidth = 30; cols["MetrologicalControlInterval"].DisplayIndex = 12; }
            if (cols["IsGun"] != null) { cols["IsGun"].HeaderText = "ГАН"; cols["IsGun"].MinimumWidth = 60; cols["IsGun"].Visible = false; cols["IsGun"].DisplayIndex = 13; }
            if (cols["Status"] != null) { cols["Status"].HeaderText = "Состояние"; cols["Status"].MinimumWidth = 60; cols["Status"].Visible = false; cols["Status"].DisplayIndex = 14; }
            if (cols["DateOfTechnicalInspection"] != null) { cols["DateOfTechnicalInspection"].HeaderText = "Дата Тех. Осв."; cols["DateOfTechnicalInspection"].MinimumWidth = 60; cols["DateOfTechnicalInspection"].DisplayIndex = 15; }
        }

        private void UpdateVisibleCountLabel()
        {
            CountVisibleDevices_StatusLabel1.Text = "Отображено приборов: " + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible);
        }

        //--------------------------------------------------------------
        // Метод для рботы с PDF файлом
        //--------------------------------------------------------------
        private void PDF()
        {
            var device = CurrentDevice;
            if (device == null) return;

            try
            {
                var date = printDateTimePicker.Checked ? printDateTimePicker.Value.ToString(Constants.DateFormat, CultureInfo.InvariantCulture) : DateTime.Now.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
                var printDevice = new PrintDevice
                {
                    TabelNumber = device.Id.ToString(),
                    SerialNumber = device.SerialId.ToString(),
                    Type = device.DeviceTypeName.ToString(),
                    YearOfRelease = device.ReleaseYear.ToString(),
                    DateToPrint = date,
                    IsMetrologicalControlType = rbMetrologicalControlType.Checked,
                    IsRepairType = rbRepairType.Checked,
                    McSelected = (MetrologicalControlType)cbMetrologicalControlType.SelectedValue,
                    RepairSelected = (RepairType)cbRepairType.SelectedValue
                };

                PrintDeviceHelper.FillPdf(printDevice);

                device.DateOfShipment = DateTime.ParseExact(date, Constants.DateFormat, CultureInfo.InvariantCulture);
                device.Loaction = "----";
                device.Status = (int)Status.Sended;
                _deviceRepository.Update(device);
                _devices.ResetItem(_devices.IndexOf(device));
            }
            catch (IOException)
            {
                MessageBox.Show("Файл уже используется");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                PrintDeviceHelper.PrintPdfFile();
                listMarking.Start(this);
            }
        }

        //---------------------------------------
        // получаем индекс выделенной строки
        //---------------------------------------
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
        }
        //------------------------------------
        // фильтр поиска в datagridview
        //------------------------------------
        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            Search.Start(this, dataGridView1, search_textBox);
        }
        //------------------------------------
        // Удаление подсказки из textbox
        //------------------------------------
        private void search_textBox_Enter(object sender, EventArgs e)
        {
            if (search_textBox.Text == "Введите: Табельный номер, заводской номер или квартал, до которого продлён прибор (пр.: 1 кв. 2020)")
            {
                search_textBox.TextChanged -= new System.EventHandler(search_textBox_TextChanged);      // Отписываемся от события TextChanged, что бы не дёргало таблицу
                search_textBox.Text = "";                                                               // Очищаем TextBox
                search_textBox.ForeColor = Color.Black;                                                 // Возвращаем системный текст
                search_textBox.TextChanged += new System.EventHandler(search_textBox_TextChanged);      // Подписываемся обратно после завершения очистки TextBox
            }
        }
        //------------------------------------
        // Добавление подсказки из textbox
        //------------------------------------
        private void search_textBox_Leave(object sender, EventArgs e)
        {
            if (search_textBox.Text == "")
            {
                search_textBox.Text = "Введите: Табельный номер, заводской номер или квартал, до которого продлён прибор (пр.: 1 кв. 2020)";
                search_textBox.ForeColor = Color.Silver;
            }
        }

        //---------------------------------------
        // Фильтрация по ThreeView
        //---------------------------------------

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int level = e.Node.Level;
            int index = e.Node.Index;

            Classes.TreeViewFilter treeViewFilter = new Classes.TreeViewFilter();
            treeViewFilter.Filter(this, level, index);
        }

        //---------------------------------------
        // Экспорт видмых строк в .xml
        //---------------------------------------
        private void ExportToExcel()
        {
            Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = dataGridView1.Rows.Count;                                               // Назначаем прогресс бару range колличество строк
                progressBar1.Visible = true;                                                                   // делаем его видимым
            });
            //---------------------------------------------
            // Подготавливаем Excel файл под эксорт в него
            //---------------------------------------------

            try
            {
                ExcelDLL.Application excelApp = new ExcelDLL.Application();                                        // Создаем объект класса Application
                excelApp.Workbooks.Add();                                                                          // Создаем новую рабочую книгу (содержит 3 листа по умолчанию)
                ExcelDLL.Worksheet workSheet = (ExcelDLL.Worksheet)excelApp.ActiveSheet;                           // Получаем активный лист

                //---------------------------------------------
                // Заполняем заголовки колонок
                //---------------------------------------------

                workSheet.Cells[1, 1] = "Таб. №";
                workSheet.Cells[1, 2] = "Завод. №";
                workSheet.Cells[1, 3] = "Тип устройства";
                workSheet.Cells[1, 4] = "Год выпуска";
                workSheet.Cells[1, 5] = "Дата отправки";
                workSheet.Cells[1, 6] = "Дата ГП";
                workSheet.Cells[1, 7] = "Расположение";
                workSheet.Cells[1, 8] = "Продление";
                workSheet.Cells[1, 9] = "Тех. решение";
                workSheet.Cells[1, 10] = "Дата Тех. Осв.";

                int rowExcel = 2;
                int visibleCount = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Invoke((MethodInvoker)delegate { progressBar1.Increment(1); });
                    if (!dataGridView1.Rows[i].Visible) continue;
                    var d = dataGridView1.Rows[i].DataBoundItem as Device;
                    if (d == null) continue;
                    workSheet.Cells[rowExcel, 1] = d.Id;
                    workSheet.Cells[rowExcel, 2] = d.SerialId;
                    workSheet.Cells[rowExcel, 3] = d.DeviceTypeName;
                    workSheet.Cells[rowExcel, 4] = d.ReleaseYear;
                    workSheet.Cells[rowExcel, 5] = d.DateOfShipment == default ? "" : d.DateOfShipment.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
                    workSheet.Cells[rowExcel, 6] = d.DateCheck == default ? "" : d.DateCheck.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
                    workSheet.Cells[rowExcel, 7] = d.Loaction ?? "";
                    workSheet.Cells[rowExcel, 8] = d.ValidTo ?? "";
                    workSheet.Cells[rowExcel, 9] = d.Solution ?? "";
                    workSheet.Cells[rowExcel, 10] = d.DateOfTechnicalInspection ?? "";
                    rowExcel++;
                    visibleCount++;
                }
                workSheet.Range["A1:B" + (visibleCount + 1)].NumberFormat = "@";

                //--------------------------------------------
                // Настройка форматирвоания вывода
                //--------------------------------------------
                workSheet.Name = "Список приборов";

                workSheet.Cells.Font.Name = "Time New Roman";                                                       // используем нужный шрифт
                workSheet.Cells.Font.Size = 10;                                                                     // используемый нужный размер текста

                for (int i = 1; i < 11; i++)                                                                        // делаем заголовок жирным
                    (workSheet.Cells[1, i] as ExcelDLL.Range).Font.Bold = true;

                (workSheet.Cells as ExcelDLL.Range).HorizontalAlignment = ExcelDLL.XlHAlign.xlHAlignCenter;         // выравнивание вертикали по центру
                (workSheet.Cells as ExcelDLL.Range).VerticalAlignment = ExcelDLL.XlVAlign.xlVAlignCenter;           // выравнивание горизонтали по центру

                var rng = workSheet.Range["A1:J" + (visibleCount + 1)];
                rng.Borders.LineStyle = 1;                                                                          // Стиль границ
                rng.Borders.ColorIndex = 0;                                                                         // Цвет
                rng.Borders.TintAndShade = 0;
                rng.Borders.Weight = 2;                                                                             // Толщина линии

                for (int i = 1; i < 11; i++)                                                                          // устанавливаем ширину колонки по содержимому
                    workSheet.Columns[i].AutoFit();

                // Сохраняем файл
                string username = Environment.UserName;                                                             // узнаем имя пользователя
                DateTime dateTime = DateTime.Now;
                string pathToXmlFile = (@"C:\Documents and Settings\" + username + @"\Desktop\Export " +
                    dateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + "");
                workSheet.SaveAs(pathToXmlFile);                                                                    // сохраняем файл

                excelApp.Quit();
                Invoke((MethodInvoker)delegate
                {
                    progressBar1.Visible = false;
                });
                MessageBox.Show("Экспорт завершен, файл с именем Export " + dateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + ".xmlx расположен на рабочем столе");
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                Invoke((MethodInvoker)delegate
                {
                    progressBar1.Visible = false;
                });
                MessageBox.Show("Для работы требуется установленный Microsoft Office Excel\n\nКод ошибки: 0x80040154 (System.Runtime.InteropServices.COMException)");
            }
        }

        private void WorkTypesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var clickedButon = (RadioButton)sender;
            bool isMetrologicalControlTypeClicked = clickedButon.Name == rbMetrologicalControlType.Name;
            bool isRepairTypeClicked = clickedButon.Name == rbRepairType.Name;

            cbRepairType.Enabled = isRepairTypeClicked;
            cbMetrologicalControlType.Enabled = isMetrologicalControlTypeClicked;

            if (cbRepairType.Enabled == false && cbMetrologicalControlType.Enabled == false) cbMetrologicalControlType.Enabled = true;
        }
    }
}

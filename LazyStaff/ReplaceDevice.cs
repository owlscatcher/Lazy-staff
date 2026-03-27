using LazyStaff.Classes;
using LazyStaff.Helpers;
using LazyStaff.Models;
using System.Globalization;
using LazyStaff.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LazyStaff
{
    public partial class ReplaceDevice : Form
    {
        private readonly IDeviceRepository _deviceRepository = new DeviceRepository();
        public Device DeviceToReplace;
        public List<Device> DevicesList { get; set; }
        ListMarking listMarking = new ListMarking();
        Classes.Search Search = new Classes.Search();
        string date = DateTime.Now.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);

        public ReplaceDevice()
        {
            InitializeComponent();

            // Включаем двойную буферизацию для DataGridView2
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.SetProperty,
                null,
                dataGridView2,
                new object[] { true });

            Print_chechBox.Checked = true;
            manualDate_dateTimePicker.Enabled = false;

            manualDate_dateTimePicker.CustomFormat = "MMMM dd, yyyy - dddd";
            manualDate_dateTimePicker.Format = DateTimePickerFormat.Custom;

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

        private void ReplaceDevice_Load(object sender, EventArgs e)
        {
            if (DeviceToReplace == null) return;

            manualDate_dateTimePicker.Value = DateTime.Now;

            dataGridView1.DataSource = new List<Device> { DeviceToReplace };
            ConfigureDeviceGridColumns(dataGridView1);

            dataGridView2.DataSource = DevicesList;
            ConfigureDeviceGridColumns(dataGridView2);

            ListMarking listMarking = new ListMarking();
            listMarking.CommonMark(dataGridView2);
        }

        private static void ConfigureDeviceGridColumns(DataGridView grid)
        {
            if (grid.Columns.Count == 0) return;
            var cols = grid.Columns;
            if (cols["PassportId"] != null) { cols["PassportId"].HeaderText = "Паспорт. №"; cols["PassportId"].MinimumWidth = 30; cols["PassportId"].DisplayIndex = 0; }
            if (cols["Id"] != null) { cols["Id"].HeaderText = "Таб. №"; cols["Id"].MinimumWidth = 30; cols["Id"].DisplayIndex = 1; }
            if (cols["SerialId"] != null) { cols["SerialId"].HeaderText = "Завод. №"; cols["SerialId"].MinimumWidth = 30; cols["SerialId"].DisplayIndex = 2; }
            if (cols["DeviceTypeName"] != null) { cols["DeviceTypeName"].HeaderText = "Тип устройства"; cols["DeviceTypeName"].MinimumWidth = 40; cols["DeviceTypeName"].DisplayIndex = 3; }
            if (cols["ReleaseYear"] != null) { cols["ReleaseYear"].HeaderText = "Год выпуска"; cols["ReleaseYear"].MinimumWidth = 40; cols["ReleaseYear"].DisplayIndex = 4; }
            if (cols["DateOfShipment"] != null) { cols["DateOfShipment"].HeaderText = "Дата отправки"; cols["DateOfShipment"].DisplayIndex = 5; }
            if (cols["DateCheck"] != null) { cols["DateCheck"].HeaderText = "Дата ГП"; cols["DateCheck"].DisplayIndex = 6; }
            if (cols["Loaction"] != null) { cols["Loaction"].HeaderText = "Расположение"; cols["Loaction"].MinimumWidth = 50; cols["Loaction"].DisplayIndex = 7; }
            if (cols["SphereSREUMId"] != null) { cols["SphereSREUMId"].HeaderText = "ГРОЕИ ID"; cols["SphereSREUMId"].MinimumWidth = 30; cols["SphereSREUMId"].Visible = false; cols["SphereSREUMId"].DisplayIndex = 8; }
            if (cols["SphereSREUMName"] != null) { cols["SphereSREUMName"].HeaderText = "Сфера ГРОЕИ"; cols["SphereSREUMName"].MinimumWidth = 60; cols["SphereSREUMName"].Visible = false; cols["SphereSREUMName"].DisplayIndex = 9; }
            if (cols["ValidTo"] != null) { cols["ValidTo"].HeaderText = "Продление"; cols["ValidTo"].MinimumWidth = 55; cols["ValidTo"].DisplayIndex = 10; }
            if (cols["Solution"] != null) { cols["Solution"].HeaderText = "Тех. решение"; cols["Solution"].MinimumWidth = 60; cols["Solution"].DisplayIndex = 11; }
            if (cols["MetrologicalControlInterval"] != null) { cols["MetrologicalControlInterval"].HeaderText = "М/П Инт."; cols["MetrologicalControlInterval"].MinimumWidth = 30; cols["MetrologicalControlInterval"].Visible = false; cols["MetrologicalControlInterval"].DisplayIndex = 12; }
            if (cols["IsGun"] != null) { cols["IsGun"].HeaderText = "ГАН"; cols["IsGun"].MinimumWidth = 60; cols["IsGun"].Visible = false; cols["IsGun"].DisplayIndex = 13; }
            if (cols["Status"] != null) { cols["Status"].HeaderText = "Состояние"; cols["Status"].MinimumWidth = 60; cols["Status"].Visible = false; cols["Status"].DisplayIndex = 14; }
            if (cols["DateOfTechnicalInspection"] != null) { cols["DateOfTechnicalInspection"].HeaderText = "Дата Тех. Осв."; cols["DateOfTechnicalInspection"].MinimumWidth = 60; cols["DateOfTechnicalInspection"].Visible = false; cols["DateOfTechnicalInspection"].DisplayIndex = 15; }
        }

        //------------------------------------
        // фильтр поиска в datagridview
        //------------------------------------
        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            Search.Start(this, dataGridView2, search_textBox);
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

        private void Print_chechBox_CheckedChanged(object sender, EventArgs e)
        {
            typeOfWorkPanel.Enabled = Print_chechBox.Checked;
        }

        private void Replace_button_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите устройство из второй таблицы, которым требуется заменить");
                return;
            }

            var deviceReplacement = dataGridView2.CurrentRow?.DataBoundItem as Device;
            if (deviceReplacement == null) return;
            if (DeviceToReplace == null) return;
            if (deviceReplacement.Id == DeviceToReplace.Id)
            {
                MessageBox.Show("Нельзя заменить устройство на само себя. Выберите другое устройство для замены.");
                return;
            }

            bool hasLocation = !string.IsNullOrWhiteSpace(DeviceToReplace.Loaction);
            if (!hasLocation)
            {
                var result = MessageBox.Show("Не указано расположение первого прибора. \nВсё равно внести изменения?", "Подтверждение:", MessageBoxButtons.OKCancel);
                if (result != DialogResult.OK) return;
            }

            string locationToAssign = DeviceToReplace.Loaction ?? "";

            DeviceToReplace.DateOfShipment = DateTime.ParseExact(date, Constants.DateFormat, CultureInfo.InvariantCulture);
            DeviceToReplace.Loaction = "----";
            DeviceToReplace.Status = (int)Status.Sended;
            _deviceRepository.Update(DeviceToReplace);

            deviceReplacement.Loaction = locationToAssign;
            deviceReplacement.Status = (int)Status.Normal;
            _deviceRepository.Update(deviceReplacement);

            if (Print_chechBox.Checked)
            {
                try
                {
                    var printDevice = new PrintDevice
                    {
                        TabelNumber = DeviceToReplace.Id.ToString(),
                        SerialNumber = DeviceToReplace.SerialId.ToString(),
                        Type = DeviceToReplace.DeviceTypeName.ToString(),
                        YearOfRelease = DeviceToReplace.ReleaseYear.ToString(),
                        DateToPrint = date,
                        IsMetrologicalControlType = rbMetrologicalControlType.Checked,
                        IsRepairType = rbRepairType.Checked,
                        McSelected = (MetrologicalControlType)cbMetrologicalControlType.SelectedValue,
                        RepairSelected = (RepairType)cbRepairType.SelectedValue
                    };
                    PrintDeviceHelper.FillPdf(printDevice);
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Файл уже используется");
                }
                finally
                {
                    PrintDeviceHelper.PrintPdfFile();
                }
            }

            Close();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        //------------------------------------------------------
        // настройка ввода даты вручну
        //------------------------------------------------------
        private void ManualDate_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (manualDate_checkBox.Checked)
            {
                manualDate_dateTimePicker.Enabled = true;
                date = manualDate_dateTimePicker.Value.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
            }
            else
            {
                manualDate_dateTimePicker.Enabled = false;
                date = DateTime.Now.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
            }
        }
        private void ManualDate_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (manualDate_checkBox.Checked)
                date = manualDate_dateTimePicker.Value.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
            else
                date = DateTime.Now.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
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

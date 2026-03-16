using LazyStaff.Classes;
using LazyStaff.Helpers;
using LazyStaff.Models;
using System.Globalization;
using LazyStaff.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace LazyStaff
{
    public partial class ReplaceDevice : Form
    {
        private readonly IDeviceRepository _deviceRepository = new DeviceRepository();
        private Device _deviceToReplace;
        Classes.Search Search = new Classes.Search();
        string date = DateTime.Now.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
        string personnelNumberOfRowToReplace = string.Empty;

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
            var main = Owner as Staff_MainForm;
            if (main == null) return;

            _deviceToReplace = main.CurrentDevice;
            if (_deviceToReplace == null) return;

            manualDate_dateTimePicker.Value = DateTime.Now;
            personnelNumberOfRowToReplace = _deviceToReplace.Id.ToString();

            dataGridView1.DataSource = new List<Device> { _deviceToReplace };
            ConfigureDeviceGridColumns(dataGridView1);

            var otherDevices = main.Devices?.Where(d => d.Id != _deviceToReplace.Id).ToList() ?? new List<Device>();
            dataGridView2.DataSource = otherDevices;
            ConfigureDeviceGridColumns(dataGridView2);
        }

        private static void ConfigureDeviceGridColumns(DataGridView grid)
        {
            if (grid.Columns.Count == 0) return;
            var cols = grid.Columns;
            if (cols["Id"] != null) { cols["Id"].HeaderText = "Таб. №"; cols["Id"].MinimumWidth = 30; }
            if (cols["SerialId"] != null) { cols["SerialId"].HeaderText = "Завод. №"; cols["SerialId"].MinimumWidth = 30; }
            if (cols["DeviceTypeId"] != null) { cols["DeviceTypeId"].HeaderText = "Тип устройства"; cols["DeviceTypeId"].MinimumWidth = 40; }
            if (cols["ReleaseYear"] != null) { cols["ReleaseYear"].HeaderText = "Год выпуска"; cols["ReleaseYear"].MinimumWidth = 40; }
            if (cols["DateOfShipment"] != null) cols["DateOfShipment"].HeaderText = "Дата отправки";
            if (cols["DateCheck"] != null) cols["DateCheck"].HeaderText = "Дата ГП";
            if (cols["Loaction"] != null) { cols["Loaction"].HeaderText = "Расположение"; cols["Loaction"].MinimumWidth = 50; }
            if (cols["ValidTo"] != null) { cols["ValidTo"].HeaderText = "Продление"; cols["ValidTo"].MinimumWidth = 55; }
            if (cols["Solution"] != null) { cols["Solution"].HeaderText = "Тех. решение"; cols["Solution"].MinimumWidth = 60; }
            if (cols["IsGun"] != null) { cols["IsGun"].HeaderText = "ГАН"; cols["IsGun"].Visible = false; }
            if (cols["Status"] != null) { cols["Status"].HeaderText = "Состояние"; cols["Status"].Visible = false; }
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
            if (_deviceToReplace == null) return;
            if (deviceReplacement.Id == _deviceToReplace.Id)
            {
                MessageBox.Show("Нельзя заменить устройство на само себя. Выберите другое устройство для замены.");
                return;
            }

            var main = Owner as Staff_MainForm;
            if (main == null) return;

            bool hasLocation = !string.IsNullOrWhiteSpace(_deviceToReplace.Loaction);
            if (!hasLocation)
            {
                var result = MessageBox.Show("Не указано расположение первого прибора. \nВсё равно внести изменения?", "Подтверждение:", MessageBoxButtons.OKCancel);
                if (result != DialogResult.OK) return;
            }

            string locationToAssign = _deviceToReplace.Loaction ?? "";

            _deviceToReplace.DateOfShipment = DateTime.ParseExact(date, Constants.DateFormat, CultureInfo.InvariantCulture);
            _deviceToReplace.Loaction = "----";
            _deviceToReplace.Status = (int)Status.Sended;
            _deviceRepository.Update(_deviceToReplace);

            deviceReplacement.Loaction = locationToAssign;
            deviceReplacement.Status = (int)Status.Normal;
            _deviceRepository.Update(deviceReplacement);

            if (Print_chechBox.Checked)
            {
                try
                {
                    var printDevice = new PrintDevice
                    {
                        TabelNumber = _deviceToReplace.Id.ToString(),
                        SerialNumber = _deviceToReplace.SerialId.ToString(),
                        Type = _deviceToReplace.DeviceTypeId.ToString(),
                        YearOfRelease = _deviceToReplace.ReleaseYear.ToString(),
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
                    main.PrintPdfFile();
                }
            }

            main.DataGridView_Load();
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

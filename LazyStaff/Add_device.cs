using System;
using System.Globalization;
using System.Windows.Forms;
using LazyStaff.Models;
using LazyStaff.Repositories;

namespace LazyStaff
{
    public partial class Add_device : Form
    {
        private readonly IDeviceRepository _deviceRepository = new DeviceRepository();
        public int state, conservation, sent, overdue, storage;
        public bool gan_state;

        public Add_device()
        {
            InitializeComponent();
        }

        private void storage_checkBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (StateStorage_radioButton.Checked)
                deviceLocation_textBox.Text = "склад";
            else
                deviceLocation_textBox.Text = "";
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            Staff_MainForm main = this.Owner as Staff_MainForm;

            if (!decommissioned_checkBox.Checked)
            {
                if (StateOverdue_radioButton.Checked == false &&
                    StateSend_radioButton.Checked == false &&
                    StateConservation_radioButton.Checked == false &&
                    StateStorage_radioButton.Checked == false &&
                    StateNormal_radioButton.Checked == true)
                    state = (int)Status.Normal;
                if (StateOverdue_radioButton.Checked == true)
                    state = (int)Status.Overdue;
                if (StateSend_radioButton.Checked == true)
                    state = (int)Status.Sended;
                if (StateConservation_radioButton.Checked == true)
                    state = (int)Status.Canned;
                if (StateStorage_radioButton.Checked == true)
                    state = (int)Status.InStock;
            }
            else
            {
                state = (int)Status.WrittenOff;
            }

            if (gan_checkBox.Checked)
                gan_state = true;
            else
                gan_state = false;

            if(yearOfIssue_textBox.Text == "" || personnelNumber_textBox.Text == "" || factoryNumber_textBox.Text == "")
            {
                MessageBox.Show("Не все поля заполнены! \n\nОбязательно должны быть указаны Табульный и Заводской номер, \nа так же Год выпуска устройства.");
                return;
            }

            DateTime validTo;
            DateTime.TryParse(verifiedTo_textBox.Text + " " + verifiedToY_textBox.Text, CultureInfo.InvariantCulture, DateTimeStyles.None, out validTo);

            int deviceTypeId = 0;
            if (deviceType_comboBox.SelectedValue != null)
                int.TryParse(deviceType_comboBox.SelectedValue.ToString(), out deviceTypeId);
            if (deviceTypeId == 0)
                int.TryParse(deviceType_comboBox.Text, out deviceTypeId);

            var device = new Device
            {
                Id = int.Parse(personnelNumber_textBox.Text),
                SerialId = int.Parse(factoryNumber_textBox.Text),
                DeviceTypeId = deviceTypeId,
                ReleaseYear = int.Parse(yearOfIssue_textBox.Text),
                DateOfShipment = sentDate_dateTimePicker.Checked ? sentDate_dateTimePicker.Value : default,
                DateCheck = verificationDate_dateTimePicker.Checked ? verificationDate_dateTimePicker.Value : default,
                Loaction = deviceLocation_textBox.Text ?? "",
                ValidTo = validTo,
                Solution = solutionNunber_textBox.Text ?? "",
                IsGun = gan_state,
                Status = state
            };

            try
            {
                _deviceRepository.Add(device);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            main.DataGridView_Load();

            main.dataGridView1.Refresh();

            string message = "Устройство добавлено!";                                                       // Формировани текста окна
            string caption = "Успешно";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);                                            // Вывод диалогового окна
            if (result == System.Windows.Forms.DialogResult.OK)
                Close();
        }
    }
}

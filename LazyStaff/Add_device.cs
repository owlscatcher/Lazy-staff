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
        Device device = new Device();

        public Add_device()
        {
            InitializeComponent();
            personnelNumber_textBox.Text = "0";
            factoryNumber_textBox.Text = "0";
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PersonnelNumber_textBox_TextChanged(object sender, EventArgs e)
        {
            ValidateNumericFill(sender);
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
            if(yearOfIssue_textBox.Text == "" || personnelNumber_textBox.Text == "" || factoryNumber_textBox.Text == "")
            {
                MessageBox.Show("Не все поля заполнены! \n\nОбязательно должны быть указаны Табульный и Заводской номер, \nа так же Год выпуска устройства.");
                return;
            }

            if (decommissioned_checkBox.Checked == true)
                device.Status = (int)Status.WrittenOff;

            device.IsGun = gan_checkBox.Checked;

            device.ValidTo = "" + verifiedToQuarter_comboBox.Text + "" + verifiedToYear_comboBox.Text + "";

            if (device == null) return;

            device.Id = int.TryParse(personnelNumber_textBox.Text, out var id) ? id : default;
            device.SerialId = factoryNumber_textBox.Text;
            device.DeviceTypeName = deviceType_comboBox.Text;
            device.ReleaseYear = int.TryParse(yearOfIssue_textBox.Text, out var year) ? year : device.ReleaseYear;
            device.DateOfShipment = sentDate_dateTimePicker.Checked ? sentDate_dateTimePicker.Value : default;
            device.DateCheck = verificationDate_dateTimePicker.Checked ? verificationDate_dateTimePicker.Value : default;
            device.Loaction = deviceLocation_textBox.Text ?? "";
            device.Solution = solutionNunber_textBox.Text ?? "";
            device.PassportId = int.TryParse(passport_id_textBox.Text, out var personal_id) ? personal_id : device.PassportId;
            device.SphereSREUMId = int.TryParse(sphere_sreum_id_textBox.Text, out var sphereId) ? sphereId : device.SphereSREUMId;
            device.SphereSREUMName = sphere_sreum_name_textBox.Text ?? "";
            device.MetrologicalControlInterval = int.TryParse(mc_interval_comboBox.Text, out var mc_interval) ? mc_interval : device.MetrologicalControlInterval;

            try
            {
                _deviceRepository.Add(device);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            string message = "Устройство добавлено!";                                                       // Формировани текста окна
            string caption = "Успешно";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);                                            // Вывод диалогового окна
            if (result == System.Windows.Forms.DialogResult.OK)
                Close();
        }

        private void StateSend_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            device.Status = (int)Status.Sended;
        }

        private void StateOverdue_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            device.Status = (int)Status.Overdue;
        }

        private void StateConservation_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            device.Status = (int)Status.Canned;
        }

        private void StateStorage_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            device.Status = (int)Status.InStock;

            if (StateStorage_radioButton.Checked)
                deviceLocation_textBox.Text = "склад";
            else
                deviceLocation_textBox.Text = "";
        }

        private void StateNormal_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            device.Status = (int)Status.Normal;
        }

        private void ValidateNumericFill(object sender)
        {
            var input = sender as TextBox;
            bool successParse;

            try
            {
                successParse = int.TryParse(input.Text, out int _validator);

                if (!successParse)
                    throw new ArgumentOutOfRangeException(paramName: "input", actualValue: input.Text, message: "Недопустимое значение");
            }
            catch (ArgumentOutOfRangeException exc)
            {
                MessageBox.Show(exc.Message);
                input.Text = "0";
            }
        }
    }
}

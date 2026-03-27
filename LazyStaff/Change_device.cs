using LazyStaff.Helpers;
using LazyStaff.Models;
using LazyStaff.Repositories;
using System;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;

namespace LazyStaff
{
    public partial class Change_device : Form
    {
        private readonly IDeviceRepository _deviceRepository = new DeviceRepository();
        private Classes.ListMarking listMarking = new Classes.ListMarking();

        /// <summary>Устройство, которое редактируется (из коллекции главной формы).</summary>
        public Device DeviceToEdit { get; set; }

        public Change_device()
        {
            InitializeComponent();
        }

        //------------------------------------------
        // кнопка cancel
        //------------------------------------------
        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        //------------------------------------------
        // Заполнние формы данными из Staff_MainForm
        //-------------------------------------------
        private void Change_dev_Load(object sender, EventArgs e)
        {
            personnelNumber_textBox.Text = DeviceToEdit.Id.ToString();
            factoryNumber_textBox.Text = DeviceToEdit.SerialId.ToString();
            deviceType_comboBox.Text = DeviceToEdit.DeviceTypeName;
            yearOfIssue_textBox.Text = DeviceToEdit.ReleaseYear.ToString();
            deviceLocation_textBox.Text = DeviceToEdit.Loaction;
            var sentDate = DeviceToEdit.DateOfShipment == default ? null : DeviceToEdit.DateOfShipment.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);
            var verificationDate = DeviceToEdit.DateCheck == default ? null : DeviceToEdit.DateCheck.ToString(Constants.DateFormat, CultureInfo.InvariantCulture);

            // Если в БД даты NULL --> датаПикеры потухшие (парсим в инвариантной культуре)
            if (sentDate is null)
                sentDate_dateTimePicker.Checked = false;
            else if (DateTime.TryParseExact(sentDate, Constants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedSentDate))
                sentDate_dateTimePicker.Value = parsedSentDate;
            if (verificationDate is null)
                verificationDate_dateTimePicker.Checked = false;
            else if (DateTime.TryParseExact(verificationDate, Constants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var verifDate))
                verificationDate_dateTimePicker.Value = verifDate;

            // разбиваем дату верификации на квартал и год

            var verefiedToSumm = DeviceToEdit.ValidTo;

            if (verefiedToSumm != null && verefiedToSumm != "" && verefiedToSumm != " ")
            {
                try
                {
                    int l = verefiedToSumm.Length;
                    var verifiedToQuarter = verefiedToSumm.Substring(0, 6);
                    var verifiedToYear = verefiedToSumm.Substring(6, 4);

                    verifiedToQuarter_comboBox.Text = verifiedToQuarter;
                    verifiedToYear_comboBox.Text = verifiedToYear;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }

            solutionNunber_textBox.Text = DeviceToEdit.Solution;

            // значения stage: 0 - норма (установлен, поверен | маркируется в default), 1 - просрочен, 2 - отправлен, 3 - на складе, 4 - консервация
            switch(DeviceToEdit.Status)
            {
                case 0: // нормально
                    StateNormal_radioButton.Checked = true;
                    break;
                case 1: //просрочен
                    StateOverdue_radioButton.Checked = true;
                    break;
                case 2: // отправлен
                    StateSend_radioButton.Checked = true;
                    break;
                case 3: // на складе
                    StateStorage_radioButton.Checked = true;
                    break;
                case 4: // консервирован
                    StateConservation_radioButton.Checked = true;
                    break;
                case 8:
                    decommissioned_checkBox.Checked = true;
                    break;
            }
            //значения stageGan: false - не в списке ГАН, true - в списке ГАН (маркеруется в default)
            gan_checkBox.Checked = DeviceToEdit.IsGun;
            passport_id_textBox.Text = DeviceToEdit.PassportId.ToString();
            mc_interval_comboBox.SelectedIndex = mc_interval_comboBox.Items.IndexOf(DeviceToEdit.MetrologicalControlInterval.ToString());
            sphere_sreum_id_textBox.Text = DeviceToEdit.SphereSREUMId.ToString();
            sphere_sreum_name_textBox.Text = DeviceToEdit.SphereSREUMName.ToString();
        }
        //------------------------------------------------
        // Заносим изменения в БД и обновляем грид
        //------------------------------------------------
        private void save_button_Click(object sender, EventArgs e)
        {
            if (decommissioned_checkBox.Checked == true)
                DeviceToEdit.Status = (int)Status.WrittenOff;

            DeviceToEdit.IsGun = gan_checkBox.Checked;

            DeviceToEdit.ValidTo = "" + verifiedToQuarter_comboBox.Text + "" + verifiedToYear_comboBox.Text + "";

            if (DeviceToEdit == null) return;

            DeviceToEdit.Id = int.TryParse(personnelNumber_textBox.Text, out var id) ? id : DeviceToEdit.Id;
            DeviceToEdit.SerialId = factoryNumber_textBox.Text;
            DeviceToEdit.DeviceTypeName = deviceType_comboBox.Text;
            DeviceToEdit.ReleaseYear = int.TryParse(yearOfIssue_textBox.Text, out var year) ? year : DeviceToEdit.ReleaseYear;
            DeviceToEdit.DateOfShipment = sentDate_dateTimePicker.Checked ? sentDate_dateTimePicker.Value : default;
            DeviceToEdit.DateCheck = verificationDate_dateTimePicker.Checked ? verificationDate_dateTimePicker.Value : default;
            DeviceToEdit.Loaction = deviceLocation_textBox.Text ?? "";
            DeviceToEdit.Solution = solutionNunber_textBox.Text ?? "";
            DeviceToEdit.PassportId = int.TryParse(passport_id_textBox.Text, out var personal_id) ? personal_id : DeviceToEdit.PassportId;
            DeviceToEdit.SphereSREUMId = int.TryParse(sphere_sreum_id_textBox.Text, out var sphereId) ? sphereId : DeviceToEdit.SphereSREUMId;
            DeviceToEdit.SphereSREUMName = sphere_sreum_name_textBox.Text ?? "";
            DeviceToEdit.MetrologicalControlInterval = int.TryParse(mc_interval_comboBox.Text, out var mc_interval) ? mc_interval : DeviceToEdit.MetrologicalControlInterval;

            _deviceRepository.Update(DeviceToEdit);
            Close();
        }

        private void StateSend_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            DeviceToEdit.Status = (int)Status.Sended;
        }

        private void StateOverdue_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            DeviceToEdit.Status = (int)Status.Overdue;
        }

        private void StateConservation_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            DeviceToEdit.Status = (int)Status.Canned;
        }

        private void StateStorage_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            DeviceToEdit.Status = (int)Status.InStock;

            if (StateStorage_radioButton.Checked)
                deviceLocation_textBox.Text = "склад";
            else
                deviceLocation_textBox.Text = "";
        }

        private void StateNormal_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            DeviceToEdit.Status = (int)Status.Normal;
        }
    }
}

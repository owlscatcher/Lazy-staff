using LazyStaff.Helpers;
using LazyStaff.Models;
using LazyStaff.Repositories;
using System;
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

        public int state;
        public bool gan_state;
        public string verifiedToQuarter, verifiedToYear, verefiedToSumm;

        public Change_device()
        {
            InitializeComponent();
        }

        private void StateStorage_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (StateStorage_radioButton.Checked)
                deviceLocation_textBox.Text = "склад";
            else
                deviceLocation_textBox.Text = "";
        }

        //------------------------------------------
        // кнопка cancel
        //------------------------------------------
        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SentDate_dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        //------------------------------------------
        // Заполнние формы данными из Staff_MainForm
        //-------------------------------------------
        private void Change_dev_Load(object sender, EventArgs e)
        {
            personnelNumber_textBox.Enabled = false;
            factoryNumber_textBox.Enabled = false;
            deviceType_comboBox.Enabled = false;
            yearOfIssue_textBox.Enabled = false;
            
            Staff_MainForm main = this.Owner as Staff_MainForm;

            personnelNumber_textBox.Text = main.personnelNumber;
            factoryNumber_textBox.Text = main.factoryNumber;
            deviceType_comboBox.Text = main.deviceType;
            yearOfIssue_textBox.Text = main.yearOfIssue;
            deviceLocation_textBox.Text = main.deviceLocation;

            // Если в БД даты NULL --> датаПикеры потухшие (парсим в инвариантной культуре)
            if (main.sentDate is null)
                sentDate_dateTimePicker.Checked = false;
            else if (DateTime.TryParseExact(main.sentDate, Constants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var sentDate))
                sentDate_dateTimePicker.Value = sentDate;
            if (main.verificationDate is null)
                verificationDate_dateTimePicker.Checked = false;
            else if (DateTime.TryParseExact(main.verificationDate, Constants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var verifDate))
                verificationDate_dateTimePicker.Value = verifDate;

            // разбиваем дату верификации на квартал и год

            verefiedToSumm = main.verifiedTo;

            if (verefiedToSumm != null && verefiedToSumm != "" && verefiedToSumm != " ")
            {
                try
                {
                    int l = verefiedToSumm.Length;
                    verifiedToQuarter = verefiedToSumm.Substring(0, 6);
                    verifiedToYear = verefiedToSumm.Substring(6, 4);

                    verifiedToQuarter_comboBox.Text = verifiedToQuarter;
                    verifiedToYear_comboBox.Text = verifiedToYear;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }

            solutionNunber_textBox.Text = main.solutionNumber;

            // значения stage: 0 - норма (установлен, поверен | маркируется в default), 1 - просрочен, 2 - отправлен, 3 - на складе, 4 - консервация
            switch(main.state)
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
            switch (main.gan_state)
            {
                case true:
                    gan_checkBox.Checked = true;
                    gan_state = true;
                    break;
                case false:
                    gan_checkBox.Checked = false;
                    gan_state = false;
                    break;
            }
        }
        //------------------------------------------------
        // Заносим изменения в БД и обновляем грид
        //------------------------------------------------
        private void save_button_Click(object sender, EventArgs e)
        {
            Staff_MainForm main = this.Owner as Staff_MainForm;

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
            if (StateStorage_radioButton.Checked == true)
                state = (int)Status.InStock;
            if (StateConservation_radioButton.Checked == true)
                state = (int)Status.Canned;
            if (decommissioned_checkBox.Checked == true)
                state = (int)Status.WrittenOff;

            if (gan_checkBox.Checked)
                gan_state = true;
            else
                gan_state = false;

            verefiedToSumm = "" + verifiedToQuarter_comboBox.Text + "" + verifiedToYear_comboBox.Text + "";
            DateTime validTo = default;
            DateTime.TryParse(verefiedToSumm, CultureInfo.InvariantCulture, DateTimeStyles.None, out validTo);

            if (DeviceToEdit == null) return;

            DeviceToEdit.SerialId = int.TryParse(factoryNumber_textBox.Text, out var serialId) ? serialId : DeviceToEdit.SerialId;
            DeviceToEdit.DeviceTypeId = int.TryParse(deviceType_comboBox.Text, out var typeId) ? typeId : DeviceToEdit.DeviceTypeId;
            DeviceToEdit.ReleaseYear = int.TryParse(yearOfIssue_textBox.Text, out var year) ? year : DeviceToEdit.ReleaseYear;
            DeviceToEdit.DateOfShipment = sentDate_dateTimePicker.Checked ? sentDate_dateTimePicker.Value : default;
            DeviceToEdit.DateCheck = verificationDate_dateTimePicker.Checked ? verificationDate_dateTimePicker.Value : default;
            DeviceToEdit.Loaction = deviceLocation_textBox.Text ?? "";
            DeviceToEdit.ValidTo = validTo;
            DeviceToEdit.Solution = solutionNunber_textBox.Text ?? "";
            DeviceToEdit.Status = state;
            DeviceToEdit.IsGun = gan_state;

            _deviceRepository.Update(DeviceToEdit);
            main.DataGridView_Load();
            listMarking.Start(main);
            Close();
        }
    }
}

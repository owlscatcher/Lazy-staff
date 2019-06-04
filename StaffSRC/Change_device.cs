using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffSRC
{
    public partial class Change_device : Form
    {
        public int state;
        public bool gan_state;
        public string verifiedToQuarter, verifiedToYear, verefiedToSumm;
        Classes.ListMarking listMarking = new Classes.ListMarking();
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

            // Если в БД даты NULL --> датаПикеры потухшие
            if (main.sentDate is null)
                sentDate_dateTimePicker.Checked = false;
            else
                sentDate_dateTimePicker.Value = Convert.ToDateTime(main.sentDate);
            if (main.verificationDate is null)
                verificationDate_dateTimePicker.Checked = false;
            else
                verificationDate_dateTimePicker.Value = Convert.ToDateTime(main.verificationDate);

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
                state = 0;
            if (StateOverdue_radioButton.Checked == true)
                state = 1;
            if (StateSend_radioButton.Checked == true)
                state = 2;
            if (StateStorage_radioButton.Checked == true)
                state = 3;
            if (StateConservation_radioButton.Checked == true)
                state = 4;
            if (decommissioned_checkBox.Checked == true)
                state = 8;

            if (gan_checkBox.Checked)
                gan_state = true;
            else
                gan_state = false;

            verefiedToSumm = "" + verifiedToQuarter_comboBox.Text + "" + verifiedToYear_comboBox.Text + "";

            SqlConnection connection = new SqlConnection(main.connectionString);
            
            string querry = "";
            // разрешение конфликта пустых строк DateTime и ms sql 
            if (!sentDate_dateTimePicker.Checked && !verificationDate_dateTimePicker.Checked)     // если отсутствует дата в поле отрпавки и поверки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= NULL, verificationDate= NULL, deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verefiedToSumm + "', solutionNunber= '" + solutionNunber_textBox.Text + "', state= " + state + ", gan= '" + gan_state + "' WHERE personnelNumber= " + main.personnelNumber);
            else if (!sentDate_dateTimePicker.Checked)                                            // если отсутствует дата в поле отрпавки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= NULL, verificationDate= '" + verificationDate_dateTimePicker.Value.ToString("dd.MM.yyyy") + "', deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verefiedToSumm + "', solutionNunber= '" + solutionNunber_textBox.Text + "', state= " + state + ", gan= '" + gan_state + "' WHERE personnelNumber= " + main.personnelNumber);
            else if (!verificationDate_dateTimePicker.Checked)                                    // если отсутствует дата в поле Гос поверки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= '" + sentDate_dateTimePicker.Value.ToString("dd.MM.yyyy") + "', verificationDate= NULL, deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verefiedToSumm + "', solutionNunber= '" + solutionNunber_textBox.Text + "', state= " + state + ", gan= '" + gan_state + "' WHERE personnelNumber= " + main.personnelNumber);
            else if (sentDate_dateTimePicker.Checked && verificationDate_dateTimePicker.Checked)     // если дата есть в дрвух полях
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= '" + sentDate_dateTimePicker.Value.ToString("dd.MM.yyyy") + "', verificationDate= '" + verificationDate_dateTimePicker.Value.ToString("dd.MM.yyyy") + "', deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verefiedToSumm + "', solutionNunber= '" + solutionNunber_textBox.Text + "', state= " + state + ", gan= '" + gan_state + "' WHERE personnelNumber= " + main.personnelNumber);

            SqlCommand command = new SqlCommand(querry, connection);
            connection.Open();
            command.ExecuteNonQuery();

            // обновление записи в гриде
            main.dataGridView1.CurrentRow.Cells[0].Value = personnelNumber_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[1].Value = factoryNumber_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[2].Value = deviceType_comboBox.Text;
            main.dataGridView1.CurrentRow.Cells[3].Value = yearOfIssue_textBox.Text;
            if (!sentDate_dateTimePicker.Checked)
                main.dataGridView1.CurrentRow.Cells[4].Value = DBNull.Value;
            else
                main.dataGridView1.CurrentRow.Cells[4].Value = sentDate_dateTimePicker.Value.ToString("dd.MM.yyyy");
            if (!verificationDate_dateTimePicker.Checked)
                main.dataGridView1.CurrentRow.Cells[5].Value = DBNull.Value;
            else
                main.dataGridView1.CurrentRow.Cells[5].Value = verificationDate_dateTimePicker.Value.ToString("dd.MM.yyyy");
            main.dataGridView1.CurrentRow.Cells[6].Value = deviceLocation_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[7].Value = verefiedToSumm;
            main.dataGridView1.CurrentRow.Cells[8].Value = solutionNunber_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[10].Value = state;
            main.dataGridView1.CurrentRow.Cells[9].Value = gan_state;

            // Маркируем список

            listMarking.Start(main);

            Close();
        }
    }
}

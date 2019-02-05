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
            sentDate_textBox.Text = Convert.ToString(main.sentDate);
            verificationDate_textBox.Text = Convert.ToString(main.verificationDate);
            verifiedTo_textBox.Text = main.verifiedTo;
            solutionNunber_textBox.Text = main.solutionNumber;

            // значения stage: 0 - норма (установлен, поверен | маркируется в default), 1 - просрочен, 2 - отправлен, 3 - на складе, 4 - консервация
            switch(main.state)
            {
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

            if (StateOverdue_radioButton.Checked == false && StateSend_radioButton.Checked == false && StateConservation_radioButton.Checked == false && StateStorage_radioButton.Checked == false)
                state = 0;
            if (StateOverdue_radioButton.Checked == true)
                state = 1;
            if (StateSend_radioButton.Checked == true)
                state = 2;
            if (StateConservation_radioButton.Checked == true)
                state = 4;
            if (StateStorage_radioButton.Checked == true)
                state = 3;

            if (gan_checkBox.Checked)
                gan_state = true;
            else
                gan_state = false;

            SqlConnection connection = new SqlConnection(main.connectionString);
            
            string querry = "";
            // разрешение конфликта пустых строк DateTime и ms sql 
            if (sentDate_textBox.Text == "" && verificationDate_textBox.Text == "")     // если отсутствует дата в поле отрпавки и поверки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= NULL, verificationDate= NULL, deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verifiedTo_textBox.Text + "', solutionNunber= '" + solutionNunber_textBox.Text + "', state= " + state + ", gan= '" + gan_state + "' WHERE personnelNumber= " + main.personnelNumber);
            else if (sentDate_textBox.Text == "")                                            // если отсутствует дата в поле отрпавки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= NULL, verificationDate= '" + verificationDate_textBox.Text + "', deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verifiedTo_textBox.Text + "', solutionNunber= '" + solutionNunber_textBox.Text + "', state= " + state + ", gan= '" + gan_state + "' WHERE personnelNumber= " + main.personnelNumber);
            else if (verificationDate_textBox.Text == "")                                    // если отсутствует дата в поле Гос поверки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= '" + sentDate_textBox.Text + "', verificationDate= NULL, deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verifiedTo_textBox.Text + "', solutionNunber= '" + solutionNunber_textBox.Text + "', state= " + state + ", gan= '" + gan_state + "' WHERE personnelNumber= " + main.personnelNumber);
            else if (sentDate_textBox.Text != "" && verificationDate_textBox.Text != "")     // если дата есть в дрвух полях
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= '" + sentDate_textBox.Text + "', verificationDate= '" + verificationDate_textBox.Text + "', deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verifiedTo_textBox.Text + "', solutionNunber= '" + solutionNunber_textBox.Text + "', state= " + state + ", gan= '" + gan_state + "' WHERE personnelNumber= " + main.personnelNumber);

            SqlCommand command = new SqlCommand(querry, connection);
            connection.Open();
            command.ExecuteNonQuery();

            // обновление записи в гриде
            main.dataGridView1.CurrentRow.Cells[0].Value = personnelNumber_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[1].Value = factoryNumber_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[2].Value = deviceType_comboBox.Text;
            main.dataGridView1.CurrentRow.Cells[3].Value = yearOfIssue_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[4].Value = sentDate_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[5].Value = verificationDate_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[6].Value = deviceLocation_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[7].Value = verifiedTo_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[8].Value = solutionNunber_textBox.Text;
            main.dataGridView1.CurrentRow.Cells[10].Value = state;
            main.dataGridView1.CurrentRow.Cells[9].Value = gan_state;

            // Маркируем список

            main.ListMarking();

            Close();
        }
    }
}

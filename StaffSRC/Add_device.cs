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
    public partial class Add_device : Form
    {
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
            if (sentDate_textBox.Text == String.Empty && verificationDate_textBox.Text == String.Empty)     // если отсутствует дата в поле отрпавки и поверки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("INSERT INTO " + main.tableName + " (personnelNumber, factoryNumber, deviceType, yearOfIssue, sentDate, verificationDate, deviceLocation, verifiedTo, solutionNunber, state, gan) VALUES (" + personnelNumber_textBox.Text + ", '" + factoryNumber_textBox.Text + "', '" + deviceType_comboBox.Text + "', " + yearOfIssue_textBox.Text + ", NULL, NULL, '" + deviceLocation_textBox.Text + "', '" + verifiedTo_textBox.Text + " " + verifiedToY_textBox.Text + "', '" + solutionNunber_textBox.Text + "', " + state +", '" + gan_state + "')");
            else if (sentDate_textBox.Text == String.Empty)                                            // если отсутствует дата в поле отрпавки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("INSERT INTO " + main.tableName + " (personnelNumber, factoryNumber, deviceType, yearOfIssue, sentDate, verificationDate, deviceLocation, verifiedTo, solutionNunber, state, gan) VALUES (" + personnelNumber_textBox.Text + ", '" + factoryNumber_textBox.Text + "', '" + deviceType_comboBox.Text + "', " + yearOfIssue_textBox.Text + ", NULL, '" + verificationDate_textBox.Text + "', '" + deviceLocation_textBox.Text + "', '" + verifiedTo_textBox.Text + " " + verifiedToY_textBox.Text + "', '" + solutionNunber_textBox.Text + "', " + state + ", '" + gan_state + "')");
            else if (verificationDate_textBox.Text == String.Empty)                                    // если отсутствует дата в поле Гос поверки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("INSERT INTO " + main.tableName + " (personnelNumber, factoryNumber, deviceType, yearOfIssue, sentDate, verificationDate, deviceLocation, verifiedTo, solutionNunber, state, gan) VALUES (" + personnelNumber_textBox.Text + ", '" + factoryNumber_textBox.Text + "', '" + deviceType_comboBox.Text + "', " + yearOfIssue_textBox.Text + ", '" + sentDate_textBox.Text + "', NULL, '" + deviceLocation_textBox.Text + "', '" + verifiedTo_textBox.Text + " " + verifiedToY_textBox.Text + "', '" + solutionNunber_textBox.Text + "', " + state + ", '" + gan_state + "')");
            else if (sentDate_textBox.Text != String.Empty && verificationDate_textBox.Text != String.Empty)     // если дата есть в дрвух полях
                querry = ("INSERT INTO " + main.tableName + " (personnelNumber, factoryNumber, deviceType, yearOfIssue, sentDate, verificationDate, deviceLocation, verifiedTo, solutionNunber, state, gan) VALUES (" + personnelNumber_textBox.Text + ", '" + factoryNumber_textBox.Text + "', '" + deviceType_comboBox.Text + "', " + yearOfIssue_textBox.Text + ", '" + sentDate_textBox.Text + "', '" + verificationDate_textBox.Text + "', '" + deviceLocation_textBox.Text + "', '" + verifiedTo_textBox.Text + " " + verifiedToY_textBox.Text + "', '" + solutionNunber_textBox.Text + "', " + state + ", '" + gan_state + "')");

            SqlCommand command = new SqlCommand(querry, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            connection.Close();
            connection.Dispose();

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

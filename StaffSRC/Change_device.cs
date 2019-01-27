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
        public int conservation, sent, overdue, storage;
        public bool gan;
        public Change_device()
        {
            InitializeComponent();
        }

        private void storage_checkBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (storage_checkBox.Checked)
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
            gan = main.gan_station;

            if (main.conservation == 1)
            {
                conservation_checkBox.Checked = true;
                conservation = 1;
            }
            else
            {
                conservation_checkBox.Checked = false;
                conservation = 0;
            }
            if (main.sent == 1)
            {
                sent_checkBox.Checked = true;
                sent = 1;
            }
            else
            {
                sent_checkBox.Checked = false;
                sent = 0;
            }
            if (main.overdue == 1)
            {
                overdue_checkBox.Checked = true;
                overdue = 1;
            }
            else
            {
                overdue_checkBox.Checked = false;
                overdue = 0;
            }
            if(main.storage == 1)
            {
                storage_checkBox.Checked = true;
                storage = 1;
            }
            else
            {
                storage_checkBox.Checked = false;
                storage = 0;
            }
            if (main.gan_station == true)
            {
                gan_checkBox.Checked = true;
                gan = true;
            }
            else
            {
                gan_checkBox.Checked = false;
                gan = false;
            }
        }
        //------------------------------------------------
        // Заносим изменения в БД и обновляем грид
        //------------------------------------------------
        private void save_button_Click(object sender, EventArgs e)
        {
            Staff_MainForm main = this.Owner as Staff_MainForm;

            if (conservation_checkBox.Checked == true)
                conservation = 1;
            else
                conservation = 0;
            if (sent_checkBox.Checked == true)
                sent = 1;
            else
                sent = 0;
            if (overdue_checkBox.Checked == true)
                overdue = 1;
            else
                overdue = 0;
            if (storage_checkBox.Checked == true)
                storage = 1;
            else
                storage = 0;
            if (gan_checkBox.Checked)
                gan = true;
            else
                gan = false;

            SqlConnection connection = new SqlConnection(main.connectionString);
            
            string querry = "";
            // разрешение конфликта пустых строк DateTime и ms sql 
            if (sentDate_textBox.Text == "" && verificationDate_textBox.Text == "")     // если отсутствует дата в поле отрпавки и поверки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= NULL, verificationDate= NULL, deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verifiedTo_textBox.Text + "', solutionNunber= '" + solutionNunber_textBox.Text + "', conservation= " + conservation + ", sent= " + sent + ", overdue= " + overdue + ", storage= " + storage + ", gan= '" + gan + "' WHERE personnelNumber= " + main.personnelNumber);
            else if (sentDate_textBox.Text == "")                                            // если отсутствует дата в поле отрпавки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= NULL, verificationDate= '" + verificationDate_textBox.Text + "', deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verifiedTo_textBox.Text + "', solutionNunber= '" + solutionNunber_textBox.Text + "', conservation= " + conservation + ", sent= " + sent + ", overdue= " + overdue + ", storage= " + storage + ", gan= '" + gan + "' WHERE personnelNumber= " + main.personnelNumber);
            else if (verificationDate_textBox.Text == "")                                    // если отсутствует дата в поле Гос поверки, пишем в базу NULL, иначе будет выставлена дата 01.01.1900
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= '" + sentDate_textBox.Text + "', verificationDate= NULL, deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verifiedTo_textBox.Text + "', solutionNunber= '" + solutionNunber_textBox.Text + "', conservation= " + conservation + ", sent= " + sent + ", overdue= " + overdue + ", storage= " + storage + ", gan= '" + gan + "' WHERE personnelNumber= " + main.personnelNumber);
            else if (sentDate_textBox.Text != "" && verificationDate_textBox.Text != "")     // если дата есть в дрвух полях
                querry = ("UPDATE " + main.tableName + " SET factoryNumber= '" + factoryNumber_textBox.Text + "', deviceType= '" + deviceType_comboBox.Text + "', yearOfIssue= " + yearOfIssue_textBox.Text + ", sentDate= '" + sentDate_textBox.Text + "', verificationDate= '" + verificationDate_textBox.Text + "', deviceLocation= '" + deviceLocation_textBox.Text + "', verifiedTo= '" + verifiedTo_textBox.Text + "', solutionNunber= '" + solutionNunber_textBox.Text + "', conservation= " + conservation + ", sent= " + sent + ", overdue= " + overdue + ", storage= " + storage + ", gan= '" + gan + "' WHERE personnelNumber= " + main.personnelNumber);

            SqlCommand command = new SqlCommand(querry, connection);
          //  try
          //  {
                connection.Open();
                command.ExecuteNonQuery();
          //  }
          /*  catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();
            connection.Dispose(); */

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
            if (conservation_checkBox.Checked == true)
            {
                main.dataGridView1.CurrentRow.Cells[9].Value = 1;
                main.conservation = 1;
            }
            else
            {
                main.dataGridView1.CurrentRow.Cells[9].Value = 0;
                main.conservation = 0;
            }
            if (sent_checkBox.Checked == true)
            {
                main.dataGridView1.CurrentRow.Cells[10].Value = 1;
                main.sent = 1;
            }
            else
            {
                main.dataGridView1.CurrentRow.Cells[10].Value = 0;
                main.sent = 1;
            }
            if (overdue_checkBox.Checked == true)
            {
                main.dataGridView1.CurrentRow.Cells[11].Value = 1;
                main.overdue = 1;
            }
            else
            {
                main.dataGridView1.CurrentRow.Cells[11].Value = 0;
                main.overdue = 0;
            }
            if (storage_checkBox.Checked == true)
            {
                main.dataGridView1.CurrentRow.Cells[12].Value = 1;
                main.overdue = 1;
            }
            else
            {
                main.dataGridView1.CurrentRow.Cells[12].Value = 0;
                main.overdue = 0;
            }
            if (gan_checkBox.Checked == true)
            {
                main.dataGridView1.CurrentRow.Cells[13].Value = true;
                main.gan_station = true;
            }
            else
            {
                main.dataGridView1.CurrentRow.Cells[13].Value = false;
                main.gan_station = false;
            }

            // Маркируем список
            main.ListMarkingMethod();
            Close();
        }
    }
}

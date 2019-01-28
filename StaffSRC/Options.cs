using StaffSRC.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffSRC
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();

            ConnectionStr_TextBox.Text = Settings.Default["connectionString"].ToString();
            TableName_TextBox.Text = Settings.Default["tableName"].ToString();
            TableNameUIM_TextBox.Text = Settings.Default["tableNameUIM"].ToString();
            TableNameRoom_TextBox.Text = Settings.Default["tableNameRoom"].ToString();
        }

        // Сохранение настроек
        private void Save_button_Click(object sender, EventArgs e)
        {
            Staff_MainForm main = this.Owner as Staff_MainForm;

            Settings.Default["connectionString"] = (ConnectionStr_TextBox.Text).ToString();
            Settings.Default.Save();
            ConnectionStr_TextBox.Text = Settings.Default["connectionString"].ToString();
            main.connectionString = Settings.Default["connectionString"].ToString();                // Обновление переменной


            Settings.Default["tableName"] = (TableName_TextBox.Text).ToString();
            Settings.Default.Save();
            TableName_TextBox.Text = Settings.Default["tableName"].ToString();
            main.tableName = Settings.Default["tableName"].ToString();                              // Обновление переменной

            Uim_info uim_Info = new Uim_info();

            Settings.Default["tableNameUIM"] = (TableNameUIM_TextBox.Text).ToString();
            Settings.Default.Save();
            TableNameUIM_TextBox.Text = Settings.Default["tableNameUIM"].ToString();
            uim_Info.tableNameUIM = Settings.Default["tableNameUIM"].ToString();                    // Обновление переменной

            Settings.Default["tableNameRoom"] = (TableNameRoom_TextBox.Text).ToString();
            Settings.Default.Save();
            TableNameRoom_TextBox.Text = Settings.Default["tableNameRoom"].ToString();
            uim_Info.tableNameUIM = Settings.Default["tableNameRoom"].ToString();                    // Обновление переменной


            Thread dataGridUpdate = new Thread(main.DataGridView_Load);
            dataGridUpdate.Start();

            Close();
        }
    }
}

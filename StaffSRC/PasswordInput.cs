using StaffSRC.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffSRC
{
    public partial class PasswordInput : Form
    {
        string password;
        public PasswordInput()
        {
            InitializeComponent();

            password = Settings.Default["password"].ToString();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                PasswordInput passwordForm = new PasswordInput();
                Staff_MainForm mainForm = new Staff_MainForm();

                if (password == password_TextBox.Text)
                {
                    Staff_MainForm.administration = true;
                    Close();
                }
                else
                {
                    Staff_MainForm.administration = false;
                    MessageBox.Show("Неверный пароль");
                }
            }
        }

        private void PasswordInput_Load(object sender, EventArgs e)
        {
            password_TextBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
        }
    }
}

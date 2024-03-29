﻿using StaffSRC.Properties;
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
        bool admin;
        Staff_MainForm staff_MainForm = new Staff_MainForm();
        public PasswordInput()
        {
            InitializeComponent();

            // Загрузили настройки
            password = Settings.Default["password"].ToString();
            admin = Convert.ToBoolean(Settings.Default["admin"]);   
        }

        // Обработка нажатия Enter
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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
            CenterToScreen();
            password_TextBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);

            if(admin)
            {
                SavePassword_checkBox.Checked = true;
                password_TextBox.Text = password;
            }
        }

        // Сохранять / не сохранять изменения
        private void SavePassword_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SavePassword_checkBox.Checked)
            {
                admin = true;

                Settings.Default["admin"] = admin;
                Settings.Default.Save();
            }
            else
            {
                admin = false;

                Settings.Default["admin"] = admin;
                Settings.Default.Save();
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
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
}

namespace LazyStaff
{
    partial class PasswordInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.password_TextBox = new System.Windows.Forms.TextBox();
            this.SavePassword_checkBox = new System.Windows.Forms.CheckBox();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.login_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // password_TextBox
            // 
            this.password_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password_TextBox.Location = new System.Drawing.Point(4, 2);
            this.password_TextBox.Name = "password_TextBox";
            this.password_TextBox.PasswordChar = '•';
            this.password_TextBox.Size = new System.Drawing.Size(121, 20);
            this.password_TextBox.TabIndex = 0;
            // 
            // SavePassword_checkBox
            // 
            this.SavePassword_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SavePassword_checkBox.AutoSize = true;
            this.SavePassword_checkBox.Location = new System.Drawing.Point(4, 28);
            this.SavePassword_checkBox.Name = "SavePassword_checkBox";
            this.SavePassword_checkBox.Size = new System.Drawing.Size(121, 17);
            this.SavePassword_checkBox.TabIndex = 1;
            this.SavePassword_checkBox.Text = "Запомнить пароль";
            this.SavePassword_checkBox.UseVisualStyleBackColor = true;
            this.SavePassword_checkBox.CheckedChanged += new System.EventHandler(this.SavePassword_checkBox_CheckedChanged);
            // 
            // cancel_Button
            // 
            this.cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_Button.Location = new System.Drawing.Point(65, 51);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(60, 25);
            this.cancel_Button.TabIndex = 2;
            this.cancel_Button.Text = "Отмена";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // login_Button
            // 
            this.login_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.login_Button.Location = new System.Drawing.Point(4, 51);
            this.login_Button.Name = "login_Button";
            this.login_Button.Size = new System.Drawing.Size(60, 25);
            this.login_Button.TabIndex = 3;
            this.login_Button.Text = "Войти";
            this.login_Button.UseVisualStyleBackColor = true;
            this.login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // PasswordInput
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(129, 80);
            this.Controls.Add(this.login_Button);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.SavePassword_checkBox);
            this.Controls.Add(this.password_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(129, 80);
            this.MinimumSize = new System.Drawing.Size(129, 80);
            this.Name = "PasswordInput";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PasswordInput";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PasswordInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox password_TextBox;
        private System.Windows.Forms.CheckBox SavePassword_checkBox;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.Button login_Button;
    }
}
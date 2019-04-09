namespace StaffSRC
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
            this.SuspendLayout();
            // 
            // password_TextBox
            // 
            this.password_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password_TextBox.Location = new System.Drawing.Point(1, 2);
            this.password_TextBox.Name = "password_TextBox";
            this.password_TextBox.PasswordChar = '•';
            this.password_TextBox.Size = new System.Drawing.Size(155, 20);
            this.password_TextBox.TabIndex = 0;
            // 
            // SavePassword_checkBox
            // 
            this.SavePassword_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SavePassword_checkBox.AutoSize = true;
            this.SavePassword_checkBox.Location = new System.Drawing.Point(159, 4);
            this.SavePassword_checkBox.Name = "SavePassword_checkBox";
            this.SavePassword_checkBox.Size = new System.Drawing.Size(121, 17);
            this.SavePassword_checkBox.TabIndex = 1;
            this.SavePassword_checkBox.Text = "Запомнить пароль";
            this.SavePassword_checkBox.UseVisualStyleBackColor = true;
            this.SavePassword_checkBox.CheckedChanged += new System.EventHandler(this.SavePassword_checkBox_CheckedChanged);
            // 
            // PasswordInput
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(281, 23);
            this.Controls.Add(this.SavePassword_checkBox);
            this.Controls.Add(this.password_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(281, 23);
            this.MinimumSize = new System.Drawing.Size(281, 23);
            this.Name = "PasswordInput";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PasswordInput";
            this.Load += new System.EventHandler(this.PasswordInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox password_TextBox;
        private System.Windows.Forms.CheckBox SavePassword_checkBox;
    }
}
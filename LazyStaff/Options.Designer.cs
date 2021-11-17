namespace LazyStaff
{
    partial class Options
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
            this.ConnectionStr_TextBox = new System.Windows.Forms.TextBox();
            this.Save_button = new System.Windows.Forms.Button();
            this.ConnectionStr_Label = new System.Windows.Forms.Label();
            this.TableName_Label = new System.Windows.Forms.Label();
            this.TableName_TextBox = new System.Windows.Forms.TextBox();
            this.Connection_groupBox = new System.Windows.Forms.GroupBox();
            this.Administration_groupBox = new System.Windows.Forms.GroupBox();
            this.NewAdminPass_label = new System.Windows.Forms.Label();
            this.NewAdminPass_TextBox = new System.Windows.Forms.TextBox();
            this.OldAdminPass_TextBox = new System.Windows.Forms.TextBox();
            this.OldAdminPass_label = new System.Windows.Forms.Label();
            this.Connection_groupBox.SuspendLayout();
            this.Administration_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectionStr_TextBox
            // 
            this.ConnectionStr_TextBox.Location = new System.Drawing.Point(131, 24);
            this.ConnectionStr_TextBox.Multiline = true;
            this.ConnectionStr_TextBox.Name = "ConnectionStr_TextBox";
            this.ConnectionStr_TextBox.Size = new System.Drawing.Size(418, 52);
            this.ConnectionStr_TextBox.TabIndex = 0;
            // 
            // Save_button
            // 
            this.Save_button.Location = new System.Drawing.Point(414, 198);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(147, 23);
            this.Save_button.TabIndex = 1;
            this.Save_button.Text = "Сохранить";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // ConnectionStr_Label
            // 
            this.ConnectionStr_Label.AutoSize = true;
            this.ConnectionStr_Label.Location = new System.Drawing.Point(6, 27);
            this.ConnectionStr_Label.Name = "ConnectionStr_Label";
            this.ConnectionStr_Label.Size = new System.Drawing.Size(113, 13);
            this.ConnectionStr_Label.TabIndex = 2;
            this.ConnectionStr_Label.Text = "Строка подключения";
            // 
            // TableName_Label
            // 
            this.TableName_Label.AutoSize = true;
            this.TableName_Label.Location = new System.Drawing.Point(5, 99);
            this.TableName_Label.Name = "TableName_Label";
            this.TableName_Label.Size = new System.Drawing.Size(120, 13);
            this.TableName_Label.TabIndex = 3;
            this.TableName_Label.Text = "Имя таблицы прибор.:";
            // 
            // TableName_TextBox
            // 
            this.TableName_TextBox.Location = new System.Drawing.Point(131, 96);
            this.TableName_TextBox.Name = "TableName_TextBox";
            this.TableName_TextBox.Size = new System.Drawing.Size(418, 20);
            this.TableName_TextBox.TabIndex = 4;
            // 
            // Connection_groupBox
            // 
            this.Connection_groupBox.Controls.Add(this.ConnectionStr_Label);
            this.Connection_groupBox.Controls.Add(this.ConnectionStr_TextBox);
            this.Connection_groupBox.Controls.Add(this.TableName_Label);
            this.Connection_groupBox.Controls.Add(this.TableName_TextBox);
            this.Connection_groupBox.Location = new System.Drawing.Point(12, 12);
            this.Connection_groupBox.Name = "Connection_groupBox";
            this.Connection_groupBox.Size = new System.Drawing.Size(561, 124);
            this.Connection_groupBox.TabIndex = 9;
            this.Connection_groupBox.TabStop = false;
            this.Connection_groupBox.Text = "Параметры соединения:";
            // 
            // Administration_groupBox
            // 
            this.Administration_groupBox.Controls.Add(this.NewAdminPass_label);
            this.Administration_groupBox.Controls.Add(this.NewAdminPass_TextBox);
            this.Administration_groupBox.Controls.Add(this.OldAdminPass_TextBox);
            this.Administration_groupBox.Controls.Add(this.OldAdminPass_label);
            this.Administration_groupBox.Location = new System.Drawing.Point(12, 142);
            this.Administration_groupBox.Name = "Administration_groupBox";
            this.Administration_groupBox.Size = new System.Drawing.Size(561, 50);
            this.Administration_groupBox.TabIndex = 10;
            this.Administration_groupBox.TabStop = false;
            this.Administration_groupBox.Text = "Параметры администрирования:";
            // 
            // NewAdminPass_label
            // 
            this.NewAdminPass_label.AutoSize = true;
            this.NewAdminPass_label.Location = new System.Drawing.Point(286, 27);
            this.NewAdminPass_label.Name = "NewAdminPass_label";
            this.NewAdminPass_label.Size = new System.Drawing.Size(83, 13);
            this.NewAdminPass_label.TabIndex = 3;
            this.NewAdminPass_label.Text = "Новый пароль:";
            // 
            // NewAdminPass_TextBox
            // 
            this.NewAdminPass_TextBox.Location = new System.Drawing.Point(402, 24);
            this.NewAdminPass_TextBox.Name = "NewAdminPass_TextBox";
            this.NewAdminPass_TextBox.PasswordChar = '•';
            this.NewAdminPass_TextBox.Size = new System.Drawing.Size(147, 20);
            this.NewAdminPass_TextBox.TabIndex = 2;
            // 
            // OldAdminPass_TextBox
            // 
            this.OldAdminPass_TextBox.Location = new System.Drawing.Point(131, 24);
            this.OldAdminPass_TextBox.Name = "OldAdminPass_TextBox";
            this.OldAdminPass_TextBox.PasswordChar = '•';
            this.OldAdminPass_TextBox.Size = new System.Drawing.Size(147, 20);
            this.OldAdminPass_TextBox.TabIndex = 1;
            // 
            // OldAdminPass_label
            // 
            this.OldAdminPass_label.AutoSize = true;
            this.OldAdminPass_label.Location = new System.Drawing.Point(6, 27);
            this.OldAdminPass_label.Name = "OldAdminPass_label";
            this.OldAdminPass_label.Size = new System.Drawing.Size(87, 13);
            this.OldAdminPass_label.TabIndex = 0;
            this.OldAdminPass_label.Text = "Старый пароль:";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 226);
            this.Controls.Add(this.Administration_groupBox);
            this.Controls.Add(this.Connection_groupBox);
            this.Controls.Add(this.Save_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.Connection_groupBox.ResumeLayout(false);
            this.Connection_groupBox.PerformLayout();
            this.Administration_groupBox.ResumeLayout(false);
            this.Administration_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ConnectionStr_TextBox;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.Label ConnectionStr_Label;
        private System.Windows.Forms.Label TableName_Label;
        private System.Windows.Forms.TextBox TableName_TextBox;
        private System.Windows.Forms.GroupBox Connection_groupBox;
        private System.Windows.Forms.GroupBox Administration_groupBox;
        private System.Windows.Forms.TextBox NewAdminPass_TextBox;
        private System.Windows.Forms.TextBox OldAdminPass_TextBox;
        private System.Windows.Forms.Label OldAdminPass_label;
        private System.Windows.Forms.Label NewAdminPass_label;
    }
}
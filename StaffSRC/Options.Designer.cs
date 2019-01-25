namespace StaffSRC
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
            this.SuspendLayout();
            // 
            // ConnectionStr_TextBox
            // 
            this.ConnectionStr_TextBox.Location = new System.Drawing.Point(138, 12);
            this.ConnectionStr_TextBox.Multiline = true;
            this.ConnectionStr_TextBox.Name = "ConnectionStr_TextBox";
            this.ConnectionStr_TextBox.Size = new System.Drawing.Size(418, 107);
            this.ConnectionStr_TextBox.TabIndex = 0;
            // 
            // Save_button
            // 
            this.Save_button.Location = new System.Drawing.Point(426, 160);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(130, 23);
            this.Save_button.TabIndex = 1;
            this.Save_button.Text = "Сохранить";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // ConnectionStr_Label
            // 
            this.ConnectionStr_Label.AutoSize = true;
            this.ConnectionStr_Label.Location = new System.Drawing.Point(13, 15);
            this.ConnectionStr_Label.Name = "ConnectionStr_Label";
            this.ConnectionStr_Label.Size = new System.Drawing.Size(113, 13);
            this.ConnectionStr_Label.TabIndex = 2;
            this.ConnectionStr_Label.Text = "Строка подключения";
            // 
            // TableName_Label
            // 
            this.TableName_Label.AutoSize = true;
            this.TableName_Label.Location = new System.Drawing.Point(13, 137);
            this.TableName_Label.Name = "TableName_Label";
            this.TableName_Label.Size = new System.Drawing.Size(75, 13);
            this.TableName_Label.TabIndex = 3;
            this.TableName_Label.Text = "Имя таблицы";
            // 
            // TableName_TextBox
            // 
            this.TableName_TextBox.Location = new System.Drawing.Point(138, 134);
            this.TableName_TextBox.Name = "TableName_TextBox";
            this.TableName_TextBox.Size = new System.Drawing.Size(418, 20);
            this.TableName_TextBox.TabIndex = 4;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 194);
            this.Controls.Add(this.TableName_TextBox);
            this.Controls.Add(this.TableName_Label);
            this.Controls.Add(this.ConnectionStr_Label);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.ConnectionStr_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ConnectionStr_TextBox;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.Label ConnectionStr_Label;
        private System.Windows.Forms.Label TableName_Label;
        private System.Windows.Forms.TextBox TableName_TextBox;
    }
}
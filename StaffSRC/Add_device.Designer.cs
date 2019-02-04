namespace StaffSRC
{
    partial class Add_device
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
            this.save_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.solutionNunber_textBox = new System.Windows.Forms.TextBox();
            this.verifiedTo_textBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.deviceType_comboBox = new System.Windows.Forms.ComboBox();
            this.deviceLocation_textBox = new System.Windows.Forms.TextBox();
            this.verificationDate_textBox = new System.Windows.Forms.TextBox();
            this.sentDate_textBox = new System.Windows.Forms.TextBox();
            this.yearOfIssue_textBox = new System.Windows.Forms.TextBox();
            this.factoryNumber_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.personnelNumber_textBox = new System.Windows.Forms.TextBox();
            this.verifiedToY_textBox = new System.Windows.Forms.ComboBox();
            this.gan_checkBox = new System.Windows.Forms.CheckBox();
            this.StateConservation_radioButton = new System.Windows.Forms.RadioButton();
            this.StateStorage_radioButton = new System.Windows.Forms.RadioButton();
            this.StateOverdue_radioButton = new System.Windows.Forms.RadioButton();
            this.StateSend_radioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(564, 102);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(92, 23);
            this.save_button.TabIndex = 47;
            this.save_button.Text = "Добавить";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(457, 102);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(100, 23);
            this.cancel_button.TabIndex = 46;
            this.cancel_button.Text = "Отмена";
            this.cancel_button.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Тех. решение:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Продлен до:";
            // 
            // solutionNunber_textBox
            // 
            this.solutionNunber_textBox.Location = new System.Drawing.Point(351, 75);
            this.solutionNunber_textBox.Name = "solutionNunber_textBox";
            this.solutionNunber_textBox.Size = new System.Drawing.Size(206, 20);
            this.solutionNunber_textBox.TabIndex = 39;
            // 
            // verifiedTo_textBox
            // 
            this.verifiedTo_textBox.AutoCompleteCustomSource.AddRange(new string[] {
            "1 кв. 2019",
            "2 кв. 2019",
            "3 кв. 2019",
            "4 кв. 2019"});
            this.verifiedTo_textBox.FormattingEnabled = true;
            this.verifiedTo_textBox.Items.AddRange(new object[] {
            "1 кв.",
            "2 кв.",
            "3 кв. ",
            "4 кв."});
            this.verifiedTo_textBox.Location = new System.Drawing.Point(224, 75);
            this.verifiedTo_textBox.Name = "verifiedTo_textBox";
            this.verifiedTo_textBox.Size = new System.Drawing.Size(53, 21);
            this.verifiedTo_textBox.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Расположение:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(561, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Дата ГП:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Дата отпр. на ГП:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Год выпуска:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Тип прибора:";
            // 
            // deviceType_comboBox
            // 
            this.deviceType_comboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "БДАС-03П",
            "БДГБ-02П",
            "БДГБ-02П1",
            "БДГБ-02И",
            "БДМГ41",
            "БДМГ41-01",
            "БДМГ41-03",
            "БДМГ08Р-02",
            "БДМГ08Р-04",
            "БДМГ08Р-05",
            "ДКГ-АТ2503",
            "ДКГ-АТ2503А",
            "ДКС-96",
            "ДП-5В",
            "ДРГ-01Т",
            "ДРГ-05",
            "МКС-01Р",
            "МКС-АТ1117",
            "УДАБ-03П",
            "УДАС-02П",
            "УДАС-03П",
            "УИ-27",
            "УИМ2-2",
            "УИМ2-2Д"});
            this.deviceType_comboBox.FormattingEnabled = true;
            this.deviceType_comboBox.Items.AddRange(new object[] {
            "альфа-радиометр",
            "БДАС-03П",
            "БДГБ-02И",
            "БДГБ-02П",
            "БДГБ-02П1",
            "БДЗА2-02",
            "БДМГ08Р-02",
            "БДМГ08Р-04",
            "БДМГ08Р-05",
            "БДМГ41",
            "БДМГ41-01",
            "БДМГ41-03",
            "ДКГ-АТ2503",
            "ДКГ-АТ2503А",
            "ДКС-96",
            "ДП-5В",
            "ДРГ-01Т",
            "ДРГ-05",
            "МКС-01Р",
            "МКСАТ1117",
            "ПСО2-2еМ",
            "ПСО2-4",
            "УДАС-02П",
            "УДАС-03П",
            "УДБН-02Р",
            "УИ-27",
            "УИМ2-2",
            "УИМ2-2Д"});
            this.deviceType_comboBox.Location = new System.Drawing.Point(224, 25);
            this.deviceType_comboBox.Name = "deviceType_comboBox";
            this.deviceType_comboBox.Size = new System.Drawing.Size(121, 21);
            this.deviceType_comboBox.TabIndex = 32;
            // 
            // deviceLocation_textBox
            // 
            this.deviceLocation_textBox.Location = new System.Drawing.Point(12, 75);
            this.deviceLocation_textBox.Name = "deviceLocation_textBox";
            this.deviceLocation_textBox.Size = new System.Drawing.Size(206, 20);
            this.deviceLocation_textBox.TabIndex = 31;
            // 
            // verificationDate_textBox
            // 
            this.verificationDate_textBox.Location = new System.Drawing.Point(564, 25);
            this.verificationDate_textBox.Name = "verificationDate_textBox";
            this.verificationDate_textBox.Size = new System.Drawing.Size(92, 20);
            this.verificationDate_textBox.TabIndex = 30;
            // 
            // sentDate_textBox
            // 
            this.sentDate_textBox.Location = new System.Drawing.Point(457, 26);
            this.sentDate_textBox.Name = "sentDate_textBox";
            this.sentDate_textBox.Size = new System.Drawing.Size(100, 20);
            this.sentDate_textBox.TabIndex = 29;
            // 
            // yearOfIssue_textBox
            // 
            this.yearOfIssue_textBox.Location = new System.Drawing.Point(351, 26);
            this.yearOfIssue_textBox.Name = "yearOfIssue_textBox";
            this.yearOfIssue_textBox.Size = new System.Drawing.Size(100, 20);
            this.yearOfIssue_textBox.TabIndex = 28;
            // 
            // factoryNumber_textBox
            // 
            this.factoryNumber_textBox.Location = new System.Drawing.Point(118, 25);
            this.factoryNumber_textBox.Name = "factoryNumber_textBox";
            this.factoryNumber_textBox.Size = new System.Drawing.Size(100, 20);
            this.factoryNumber_textBox.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Заводской №:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Табульный №:";
            // 
            // personnelNumber_textBox
            // 
            this.personnelNumber_textBox.Location = new System.Drawing.Point(12, 25);
            this.personnelNumber_textBox.Name = "personnelNumber_textBox";
            this.personnelNumber_textBox.Size = new System.Drawing.Size(100, 20);
            this.personnelNumber_textBox.TabIndex = 24;
            // 
            // verifiedToY_textBox
            // 
            this.verifiedToY_textBox.FormattingEnabled = true;
            this.verifiedToY_textBox.Items.AddRange(new object[] {
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040"});
            this.verifiedToY_textBox.Location = new System.Drawing.Point(283, 75);
            this.verifiedToY_textBox.Name = "verifiedToY_textBox";
            this.verifiedToY_textBox.Size = new System.Drawing.Size(62, 21);
            this.verifiedToY_textBox.TabIndex = 48;
            // 
            // gan_checkBox
            // 
            this.gan_checkBox.AutoSize = true;
            this.gan_checkBox.Location = new System.Drawing.Point(12, 102);
            this.gan_checkBox.Name = "gan_checkBox";
            this.gan_checkBox.Size = new System.Drawing.Size(173, 17);
            this.gan_checkBox.TabIndex = 49;
            this.gan_checkBox.Text = "Прибор входит в списки ГАН";
            this.gan_checkBox.UseVisualStyleBackColor = true;
            // 
            // StateConservation_radioButton
            // 
            this.StateConservation_radioButton.AutoSize = true;
            this.StateConservation_radioButton.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StateConservation_radioButton.Location = new System.Drawing.Point(614, 65);
            this.StateConservation_radioButton.Name = "StateConservation_radioButton";
            this.StateConservation_radioButton.Size = new System.Drawing.Size(18, 30);
            this.StateConservation_radioButton.TabIndex = 53;
            this.StateConservation_radioButton.TabStop = true;
            this.StateConservation_radioButton.Text = "К";
            this.StateConservation_radioButton.UseVisualStyleBackColor = true;
            // 
            // StateStorage_radioButton
            // 
            this.StateStorage_radioButton.AutoSize = true;
            this.StateStorage_radioButton.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StateStorage_radioButton.Location = new System.Drawing.Point(638, 65);
            this.StateStorage_radioButton.Name = "StateStorage_radioButton";
            this.StateStorage_radioButton.Size = new System.Drawing.Size(18, 30);
            this.StateStorage_radioButton.TabIndex = 52;
            this.StateStorage_radioButton.TabStop = true;
            this.StateStorage_radioButton.Text = "С";
            this.StateStorage_radioButton.UseVisualStyleBackColor = true;
            // 
            // StateOverdue_radioButton
            // 
            this.StateOverdue_radioButton.AutoSize = true;
            this.StateOverdue_radioButton.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StateOverdue_radioButton.Location = new System.Drawing.Point(589, 65);
            this.StateOverdue_radioButton.Name = "StateOverdue_radioButton";
            this.StateOverdue_radioButton.Size = new System.Drawing.Size(19, 30);
            this.StateOverdue_radioButton.TabIndex = 51;
            this.StateOverdue_radioButton.TabStop = true;
            this.StateOverdue_radioButton.Text = "П";
            this.StateOverdue_radioButton.UseVisualStyleBackColor = true;
            // 
            // StateSend_radioButton
            // 
            this.StateSend_radioButton.AutoSize = true;
            this.StateSend_radioButton.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StateSend_radioButton.Location = new System.Drawing.Point(564, 65);
            this.StateSend_radioButton.Name = "StateSend_radioButton";
            this.StateSend_radioButton.Size = new System.Drawing.Size(19, 30);
            this.StateSend_radioButton.TabIndex = 50;
            this.StateSend_radioButton.TabStop = true;
            this.StateSend_radioButton.Text = "О";
            this.StateSend_radioButton.UseVisualStyleBackColor = true;
            // 
            // Add_device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 135);
            this.Controls.Add(this.StateConservation_radioButton);
            this.Controls.Add(this.StateStorage_radioButton);
            this.Controls.Add(this.StateOverdue_radioButton);
            this.Controls.Add(this.StateSend_radioButton);
            this.Controls.Add(this.gan_checkBox);
            this.Controls.Add(this.verifiedToY_textBox);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.solutionNunber_textBox);
            this.Controls.Add(this.verifiedTo_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deviceType_comboBox);
            this.Controls.Add(this.deviceLocation_textBox);
            this.Controls.Add(this.verificationDate_textBox);
            this.Controls.Add(this.sentDate_textBox);
            this.Controls.Add(this.yearOfIssue_textBox);
            this.Controls.Add(this.factoryNumber_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.personnelNumber_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Add_device";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить прибор:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox solutionNunber_textBox;
        private System.Windows.Forms.ComboBox verifiedTo_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox deviceType_comboBox;
        private System.Windows.Forms.TextBox deviceLocation_textBox;
        private System.Windows.Forms.TextBox verificationDate_textBox;
        private System.Windows.Forms.TextBox sentDate_textBox;
        private System.Windows.Forms.TextBox yearOfIssue_textBox;
        private System.Windows.Forms.TextBox factoryNumber_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox personnelNumber_textBox;
        private System.Windows.Forms.ComboBox verifiedToY_textBox;
        private System.Windows.Forms.CheckBox gan_checkBox;
        private System.Windows.Forms.RadioButton StateConservation_radioButton;
        private System.Windows.Forms.RadioButton StateStorage_radioButton;
        private System.Windows.Forms.RadioButton StateOverdue_radioButton;
        private System.Windows.Forms.RadioButton StateSend_radioButton;
    }
}
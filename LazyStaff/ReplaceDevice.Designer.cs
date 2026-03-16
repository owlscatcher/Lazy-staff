namespace LazyStaff
{
    partial class ReplaceDevice
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.personnelNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factoryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearOfIssue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verificationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verifiedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solutionNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gan_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.search_textBox = new System.Windows.Forms.TextBox();
            this.Replace_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.manualDate_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.typeOfWorkPanel = new System.Windows.Forms.Panel();
            this.rbRepairType = new System.Windows.Forms.RadioButton();
            this.cbMetrologicalControlType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbMetrologicalControlType = new System.Windows.Forms.RadioButton();
            this.cbRepairType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.manualDate_checkBox = new System.Windows.Forms.CheckBox();
            this.Print_chechBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.typeOfWorkPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 94);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView2.Location = new System.Drawing.Point(12, 138);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(776, 283);
            this.dataGridView2.TabIndex = 1;
            // 
            // search_textBox
            // 
            this.search_textBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.search_textBox.Location = new System.Drawing.Point(12, 112);
            this.search_textBox.Name = "search_textBox";
            this.search_textBox.Size = new System.Drawing.Size(776, 20);
            this.search_textBox.TabIndex = 2;
            this.search_textBox.Text = "Введите: Табельный номер, заводской номер или квартал, до которого продлён прибор" +
    " (пр.: 1 кв. 2020)";
            this.search_textBox.TextChanged += new System.EventHandler(this.search_textBox_TextChanged);
            this.search_textBox.Enter += new System.EventHandler(this.search_textBox_Enter);
            this.search_textBox.Leave += new System.EventHandler(this.search_textBox_Leave);
            // 
            // Replace_button
            // 
            this.Replace_button.Location = new System.Drawing.Point(657, 429);
            this.Replace_button.Name = "Replace_button";
            this.Replace_button.Size = new System.Drawing.Size(131, 23);
            this.Replace_button.TabIndex = 3;
            this.Replace_button.Text = "Заменить";
            this.Replace_button.UseVisualStyleBackColor = true;
            this.Replace_button.Click += new System.EventHandler(this.Replace_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(657, 460);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(131, 23);
            this.Cancel_button.TabIndex = 5;
            this.Cancel_button.Text = "Отмена";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.manualDate_dateTimePicker);
            this.groupBox1.Controls.Add(this.typeOfWorkPanel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.manualDate_checkBox);
            this.groupBox1.Controls.Add(this.Print_chechBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 423);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 63);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройка печати:";
            // 
            // manualDate_dateTimePicker
            // 
            this.manualDate_dateTimePicker.Location = new System.Drawing.Point(154, 40);
            this.manualDate_dateTimePicker.Name = "manualDate_dateTimePicker";
            this.manualDate_dateTimePicker.Size = new System.Drawing.Size(233, 20);
            this.manualDate_dateTimePicker.TabIndex = 8;
            this.manualDate_dateTimePicker.Value = new System.DateTime(2019, 5, 31, 7, 49, 8, 0);
            this.manualDate_dateTimePicker.ValueChanged += new System.EventHandler(this.ManualDate_dateTimePicker_ValueChanged);
            // 
            // typeOfWorkPanel
            // 
            this.typeOfWorkPanel.Controls.Add(this.rbRepairType);
            this.typeOfWorkPanel.Controls.Add(this.cbMetrologicalControlType);
            this.typeOfWorkPanel.Controls.Add(this.label2);
            this.typeOfWorkPanel.Controls.Add(this.label3);
            this.typeOfWorkPanel.Controls.Add(this.rbMetrologicalControlType);
            this.typeOfWorkPanel.Controls.Add(this.cbRepairType);
            this.typeOfWorkPanel.Location = new System.Drawing.Point(154, 13);
            this.typeOfWorkPanel.Name = "typeOfWorkPanel";
            this.typeOfWorkPanel.Size = new System.Drawing.Size(479, 29);
            this.typeOfWorkPanel.TabIndex = 20;
            // 
            // rbRepairType
            // 
            this.rbRepairType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRepairType.AutoSize = true;
            this.rbRepairType.Location = new System.Drawing.Point(240, 3);
            this.rbRepairType.Name = "rbRepairType";
            this.rbRepairType.Size = new System.Drawing.Size(14, 13);
            this.rbRepairType.TabIndex = 17;
            this.rbRepairType.UseVisualStyleBackColor = true;
            this.rbRepairType.Click += new System.EventHandler(this.WorkTypesRadioButton_CheckedChanged);
            // 
            // cbMetrologicalControlType
            // 
            this.cbMetrologicalControlType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMetrologicalControlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetrologicalControlType.FormattingEnabled = true;
            this.cbMetrologicalControlType.Location = new System.Drawing.Point(121, 0);
            this.cbMetrologicalControlType.Name = "cbMetrologicalControlType";
            this.cbMetrologicalControlType.Size = new System.Drawing.Size(113, 21);
            this.cbMetrologicalControlType.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Вид метр. работ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(260, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Вид рем. работ";
            // 
            // rbMetrologicalControlType
            // 
            this.rbMetrologicalControlType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMetrologicalControlType.AutoSize = true;
            this.rbMetrologicalControlType.Checked = true;
            this.rbMetrologicalControlType.Location = new System.Drawing.Point(6, 1);
            this.rbMetrologicalControlType.Name = "rbMetrologicalControlType";
            this.rbMetrologicalControlType.Size = new System.Drawing.Size(14, 13);
            this.rbMetrologicalControlType.TabIndex = 14;
            this.rbMetrologicalControlType.TabStop = true;
            this.rbMetrologicalControlType.UseVisualStyleBackColor = true;
            this.rbMetrologicalControlType.Click += new System.EventHandler(this.WorkTypesRadioButton_CheckedChanged);
            // 
            // cbRepairType
            // 
            this.cbRepairType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRepairType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRepairType.Enabled = false;
            this.cbRepairType.FormattingEnabled = true;
            this.cbRepairType.Location = new System.Drawing.Point(350, 0);
            this.cbRepairType.Name = "cbRepairType";
            this.cbRepairType.Size = new System.Drawing.Size(113, 21);
            this.cbRepairType.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "|";
            // 
            // manualDate_checkBox
            // 
            this.manualDate_checkBox.AutoSize = true;
            this.manualDate_checkBox.Location = new System.Drawing.Point(7, 36);
            this.manualDate_checkBox.Name = "manualDate_checkBox";
            this.manualDate_checkBox.Size = new System.Drawing.Size(141, 17);
            this.manualDate_checkBox.TabIndex = 7;
            this.manualDate_checkBox.Text = "Указать дату вручную:";
            this.manualDate_checkBox.UseVisualStyleBackColor = true;
            this.manualDate_checkBox.CheckedChanged += new System.EventHandler(this.ManualDate_checkBox_CheckedChanged);
            // 
            // Print_chechBox
            // 
            this.Print_chechBox.AutoSize = true;
            this.Print_chechBox.Location = new System.Drawing.Point(7, 13);
            this.Print_chechBox.Name = "Print_chechBox";
            this.Print_chechBox.Size = new System.Drawing.Size(132, 17);
            this.Print_chechBox.TabIndex = 8;
            this.Print_chechBox.Text = "Отправить на печать";
            this.Print_chechBox.UseVisualStyleBackColor = true;
            this.Print_chechBox.CheckedChanged += new System.EventHandler(this.Print_chechBox_CheckedChanged);
            // 
            // ReplaceDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Replace_button);
            this.Controls.Add(this.search_textBox);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReplaceDevice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Замена устройства";
            this.Load += new System.EventHandler(this.ReplaceDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.typeOfWorkPanel.ResumeLayout(false);
            this.typeOfWorkPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox search_textBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn personnelNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn factoryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearOfIssue;
        private System.Windows.Forms.DataGridViewTextBoxColumn sentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn verificationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn verifiedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn solutionNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gan_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.Button Replace_button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Print_chechBox;
        private System.Windows.Forms.CheckBox manualDate_checkBox;
        private System.Windows.Forms.DateTimePicker manualDate_dateTimePicker;
        private System.Windows.Forms.RadioButton rbRepairType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRepairType;
        private System.Windows.Forms.RadioButton rbMetrologicalControlType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMetrologicalControlType;
        private System.Windows.Forms.Panel typeOfWorkPanel;
    }
}
namespace StaffSRC
{
    partial class Staff_MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("УИМ");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("БДАС");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("БДГБ");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("БДМГ");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("УДАС");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("ДКГ");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Все приборы", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Просроченные приборы");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Консервация");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Отправленные на Гос. поверку");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Склад");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("ГАН");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Другие");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Особые списки", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Staff_MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DeleteDevice_Button = new System.Windows.Forms.Button();
            this.Setting_button = new System.Windows.Forms.Button();
            this.uimInfo_button = new System.Windows.Forms.Button();
            this.AddDevice_button = new System.Windows.Forms.Button();
            this.Marker_button = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ExportToXml_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.entranceControl_radioButton = new System.Windows.Forms.RadioButton();
            this.repairs_radioButton = new System.Windows.Forms.RadioButton();
            this.test_radioButton = new System.Windows.Forms.RadioButton();
            this.PrintPdf_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.notgan_label = new System.Windows.Forms.Label();
            this.gan_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.allDevides_label = new System.Windows.Forms.Label();
            this.storage_label = new System.Windows.Forms.Label();
            this.seporatingLine_label = new System.Windows.Forms.Label();
            this.overdue_label = new System.Windows.Forms.Label();
            this.sent_label = new System.Windows.Forms.Label();
            this.conservation_label = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.search_textBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel1.Controls.Add(this.ExportToXml_button);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.search_textBox);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1542, 846);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.DeleteDevice_Button);
            this.groupBox3.Controls.Add(this.Setting_button);
            this.groupBox3.Controls.Add(this.uimInfo_button);
            this.groupBox3.Controls.Add(this.AddDevice_button);
            this.groupBox3.Controls.Add(this.Marker_button);
            this.groupBox3.Location = new System.Drawing.Point(5, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 164);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Опции";
            // 
            // DeleteDevice_Button
            // 
            this.DeleteDevice_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteDevice_Button.Location = new System.Drawing.Point(0, 77);
            this.DeleteDevice_Button.Name = "DeleteDevice_Button";
            this.DeleteDevice_Button.Size = new System.Drawing.Size(179, 23);
            this.DeleteDevice_Button.TabIndex = 13;
            this.DeleteDevice_Button.Text = "Удалить устройство";
            this.DeleteDevice_Button.UseVisualStyleBackColor = true;
            this.DeleteDevice_Button.Click += new System.EventHandler(this.DeleteDevice_Button_Click);
            // 
            // Setting_button
            // 
            this.Setting_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Setting_button.Location = new System.Drawing.Point(0, 19);
            this.Setting_button.Name = "Setting_button";
            this.Setting_button.Size = new System.Drawing.Size(179, 23);
            this.Setting_button.TabIndex = 11;
            this.Setting_button.Text = "Настройки";
            this.Setting_button.UseVisualStyleBackColor = true;
            // 
            // uimInfo_button
            // 
            this.uimInfo_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uimInfo_button.Location = new System.Drawing.Point(0, 106);
            this.uimInfo_button.Name = "uimInfo_button";
            this.uimInfo_button.Size = new System.Drawing.Size(179, 23);
            this.uimInfo_button.TabIndex = 9;
            this.uimInfo_button.Text = "Справка по УИМ2-2";
            this.uimInfo_button.UseVisualStyleBackColor = true;
            this.uimInfo_button.Click += new System.EventHandler(this.uimInfo_button_Click);
            // 
            // AddDevice_button
            // 
            this.AddDevice_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddDevice_button.Location = new System.Drawing.Point(0, 48);
            this.AddDevice_button.Name = "AddDevice_button";
            this.AddDevice_button.Size = new System.Drawing.Size(179, 23);
            this.AddDevice_button.TabIndex = 10;
            this.AddDevice_button.Text = "Добавить устройство";
            this.AddDevice_button.UseVisualStyleBackColor = true;
            this.AddDevice_button.Click += new System.EventHandler(this.AddDevice_button_Click);
            // 
            // Marker_button
            // 
            this.Marker_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Marker_button.Location = new System.Drawing.Point(0, 135);
            this.Marker_button.Name = "Marker_button";
            this.Marker_button.Size = new System.Drawing.Size(179, 23);
            this.Marker_button.TabIndex = 2;
            this.Marker_button.Text = "Принудительная маркеровка";
            this.Marker_button.UseVisualStyleBackColor = true;
            this.Marker_button.Click += new System.EventHandler(this.ListMarking_buttons);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(5, 629);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(179, 10);
            this.progressBar1.TabIndex = 8;
            // 
            // ExportToXml_button
            // 
            this.ExportToXml_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportToXml_button.Location = new System.Drawing.Point(5, 645);
            this.ExportToXml_button.Name = "ExportToXml_button";
            this.ExportToXml_button.Size = new System.Drawing.Size(179, 23);
            this.ExportToXml_button.TabIndex = 7;
            this.ExportToXml_button.Text = "Экспортировать в Excel";
            this.ExportToXml_button.UseVisualStyleBackColor = true;
            this.ExportToXml_button.Click += new System.EventHandler(this.ExportToXml_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.entranceControl_radioButton);
            this.groupBox2.Controls.Add(this.repairs_radioButton);
            this.groupBox2.Controls.Add(this.test_radioButton);
            this.groupBox2.Controls.Add(this.PrintPdf_button);
            this.groupBox2.Location = new System.Drawing.Point(3, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 116);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройка печати";
            // 
            // entranceControl_radioButton
            // 
            this.entranceControl_radioButton.AutoSize = true;
            this.entranceControl_radioButton.Location = new System.Drawing.Point(12, 65);
            this.entranceControl_radioButton.Name = "entranceControl_radioButton";
            this.entranceControl_radioButton.Size = new System.Drawing.Size(117, 17);
            this.entranceControl_radioButton.TabIndex = 4;
            this.entranceControl_radioButton.TabStop = true;
            this.entranceControl_radioButton.Text = "Входной контроль";
            this.entranceControl_radioButton.UseVisualStyleBackColor = true;
            // 
            // repairs_radioButton
            // 
            this.repairs_radioButton.AutoSize = true;
            this.repairs_radioButton.Location = new System.Drawing.Point(12, 42);
            this.repairs_radioButton.Name = "repairs_radioButton";
            this.repairs_radioButton.Size = new System.Drawing.Size(63, 17);
            this.repairs_radioButton.TabIndex = 3;
            this.repairs_radioButton.TabStop = true;
            this.repairs_radioButton.Text = "Ремонт";
            this.repairs_radioButton.UseVisualStyleBackColor = true;
            // 
            // test_radioButton
            // 
            this.test_radioButton.AutoSize = true;
            this.test_radioButton.Location = new System.Drawing.Point(12, 19);
            this.test_radioButton.Name = "test_radioButton";
            this.test_radioButton.Size = new System.Drawing.Size(69, 17);
            this.test_radioButton.TabIndex = 2;
            this.test_radioButton.TabStop = true;
            this.test_radioButton.Text = "Поверка";
            this.test_radioButton.UseVisualStyleBackColor = true;
            // 
            // PrintPdf_button
            // 
            this.PrintPdf_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintPdf_button.Location = new System.Drawing.Point(2, 88);
            this.PrintPdf_button.Name = "PrintPdf_button";
            this.PrintPdf_button.Size = new System.Drawing.Size(179, 23);
            this.PrintPdf_button.TabIndex = 1;
            this.PrintPdf_button.Text = "Печать предъявления";
            this.PrintPdf_button.UseVisualStyleBackColor = true;
            this.PrintPdf_button.Click += new System.EventHandler(this.PrintPdf_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.notgan_label);
            this.groupBox1.Controls.Add(this.gan_label);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.allDevides_label);
            this.groupBox1.Controls.Add(this.storage_label);
            this.groupBox1.Controls.Add(this.seporatingLine_label);
            this.groupBox1.Controls.Add(this.overdue_label);
            this.groupBox1.Controls.Add(this.sent_label);
            this.groupBox1.Controls.Add(this.conservation_label);
            this.groupBox1.Location = new System.Drawing.Point(3, 674);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 169);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация:";
            // 
            // notgan_label
            // 
            this.notgan_label.AutoSize = true;
            this.notgan_label.Location = new System.Drawing.Point(9, 113);
            this.notgan_label.Name = "notgan_label";
            this.notgan_label.Size = new System.Drawing.Size(99, 13);
            this.notgan_label.TabIndex = 12;
            this.notgan_label.Text = "Приборов не ГАН:";
            // 
            // gan_label
            // 
            this.gan_label.AutoSize = true;
            this.gan_label.Location = new System.Drawing.Point(9, 100);
            this.gan_label.Name = "gan_label";
            this.gan_label.Size = new System.Drawing.Size(84, 13);
            this.gan_label.TabIndex = 11;
            this.gan_label.Text = "Приборов ГАН:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "____________________";
            // 
            // allDevides_label
            // 
            this.allDevides_label.AutoSize = true;
            this.allDevides_label.Location = new System.Drawing.Point(9, 149);
            this.allDevides_label.Name = "allDevides_label";
            this.allDevides_label.Size = new System.Drawing.Size(94, 13);
            this.allDevides_label.TabIndex = 9;
            this.allDevides_label.Text = "Всего устройств:";
            // 
            // storage_label
            // 
            this.storage_label.AutoSize = true;
            this.storage_label.Location = new System.Drawing.Point(9, 65);
            this.storage_label.Name = "storage_label";
            this.storage_label.Size = new System.Drawing.Size(63, 13);
            this.storage_label.TabIndex = 8;
            this.storage_label.Text = "На складе:";
            // 
            // seporatingLine_label
            // 
            this.seporatingLine_label.AutoSize = true;
            this.seporatingLine_label.Location = new System.Drawing.Point(6, 78);
            this.seporatingLine_label.Name = "seporatingLine_label";
            this.seporatingLine_label.Size = new System.Drawing.Size(127, 13);
            this.seporatingLine_label.TabIndex = 7;
            this.seporatingLine_label.Text = "____________________";
            // 
            // overdue_label
            // 
            this.overdue_label.AutoSize = true;
            this.overdue_label.Location = new System.Drawing.Point(9, 52);
            this.overdue_label.Name = "overdue_label";
            this.overdue_label.Size = new System.Drawing.Size(74, 13);
            this.overdue_label.TabIndex = 6;
            this.overdue_label.Text = "Просрочено: ";
            // 
            // sent_label
            // 
            this.sent_label.AutoSize = true;
            this.sent_label.Location = new System.Drawing.Point(9, 39);
            this.sent_label.Name = "sent_label";
            this.sent_label.Size = new System.Drawing.Size(71, 13);
            this.sent_label.TabIndex = 5;
            this.sent_label.Text = "Отправлено:";
            // 
            // conservation_label
            // 
            this.conservation_label.AutoSize = true;
            this.conservation_label.Location = new System.Drawing.Point(9, 26);
            this.conservation_label.Name = "conservation_label";
            this.conservation_label.Size = new System.Drawing.Size(93, 13);
            this.conservation_label.TabIndex = 4;
            this.conservation_label.Text = "На консервации:";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.SystemColors.Window;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "UIM";
            treeNode1.Text = "УИМ";
            treeNode2.Name = "BDAS";
            treeNode2.Text = "БДАС";
            treeNode3.Name = "BDGB";
            treeNode3.Text = "БДГБ";
            treeNode4.Name = "BDMG";
            treeNode4.Text = "БДМГ";
            treeNode5.Name = "UDAS";
            treeNode5.Text = "УДАС";
            treeNode6.Name = "DKG";
            treeNode6.Text = "ДКГ";
            treeNode7.Name = "All";
            treeNode7.Text = "Все приборы";
            treeNode8.Name = "PROSROCH";
            treeNode8.Text = "Просроченные приборы";
            treeNode9.Name = "KONSERV";
            treeNode9.Text = "Консервация";
            treeNode10.Name = "OTPRAVLENNIE";
            treeNode10.Text = "Отправленные на Гос. поверку";
            treeNode11.Name = "SKLAD";
            treeNode11.Text = "Склад";
            treeNode12.Name = "gan";
            treeNode12.Text = "ГАН";
            treeNode13.Name = "notgan";
            treeNode13.Text = "Другие";
            treeNode14.Name = "lists";
            treeNode14.Text = "Особые списки";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode14});
            this.treeView1.Size = new System.Drawing.Size(186, 199);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // search_textBox
            // 
            this.search_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_textBox.Location = new System.Drawing.Point(3, 3);
            this.search_textBox.Name = "search_textBox";
            this.search_textBox.Size = new System.Drawing.Size(1340, 20);
            this.search_textBox.TabIndex = 2;
            this.search_textBox.TextChanged += new System.EventHandler(this.search_textBox_TextChanged);
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1340, 817);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Staff_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1542, 846);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Staff_MainForm";
            this.Text = "Приборы УРБ зд. 106 (v1.1.2 от 11/10/2018)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Staff_MainForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button PrintPdf_button;
        private System.Windows.Forms.TextBox search_textBox;
        private System.Windows.Forms.Button Marker_button;
        private System.Windows.Forms.Label conservation_label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label overdue_label;
        private System.Windows.Forms.Label sent_label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton entranceControl_radioButton;
        private System.Windows.Forms.RadioButton repairs_radioButton;
        private System.Windows.Forms.RadioButton test_radioButton;
        private System.Windows.Forms.Label storage_label;
        private System.Windows.Forms.Label seporatingLine_label;
        private System.Windows.Forms.Button ExportToXml_button;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button uimInfo_button;
        private System.Windows.Forms.Label allDevides_label;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Setting_button;
        private System.Windows.Forms.Button AddDevice_button;
        private System.Windows.Forms.Button DeleteDevice_Button;
        private System.Windows.Forms.Label notgan_label;
        private System.Windows.Forms.Label gan_label;
        private System.Windows.Forms.Label label1;
    }
}


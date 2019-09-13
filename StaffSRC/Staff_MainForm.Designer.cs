using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Staff_MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("УИМ");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("БДАС");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("БДГБ");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("БДМГ");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("УДАБ");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("УДАС");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("ДКГ");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Все приборы", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Подготовить на отпр.");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Просроченные приборы");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Консервация");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Отправленные на Гос. поверку");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Склад");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("ГАН");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Другие");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Списанные приборы");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Особые списки", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Setting_button = new System.Windows.Forms.Button();
            this.ToggleHost = new System.Windows.Forms.Integration.ElementHost();
            this.ToggleSwitch = new StaffSRC.Toggle();
            this.Admin_Label = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ExportToXml_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.printDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.entranceControl_radioButton = new System.Windows.Forms.RadioButton();
            this.repairs_radioButton = new System.Windows.Forms.RadioButton();
            this.test_radioButton = new System.Windows.Forms.RadioButton();
            this.PrintPdf_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.seporatingLine_label2 = new System.Windows.Forms.Label();
            this.decommissioned_label = new System.Windows.Forms.Label();
            this.notgan_label = new System.Windows.Forms.Label();
            this.gan_label = new System.Windows.Forms.Label();
            this.seporatingLine_label3 = new System.Windows.Forms.Label();
            this.allDevides_label = new System.Windows.Forms.Label();
            this.storage_label = new System.Windows.Forms.Label();
            this.seporatingLine_label = new System.Windows.Forms.Label();
            this.overdue_label = new System.Windows.Forms.Label();
            this.sent_label = new System.Windows.Forms.Label();
            this.conservation_label = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.StatusPanel = new System.Windows.Forms.StatusStrip();
            this.SyncStatusLabel_StatusPanel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CountStatusLabel_StatusPanel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CountVisibleDevices_StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.search_textBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGrid_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.StatusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.dataGrid_contextMenuStrip.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.Admin_Label);
            this.splitContainer1.Panel1.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel1.Controls.Add(this.ExportToXml_button);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.StatusPanel);
            this.splitContainer1.Panel2.Controls.Add(this.search_textBox);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1370, 749);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(96, 718);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Setting_button);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ToggleHost);
            this.splitContainer2.Size = new System.Drawing.Size(71, 28);
            this.splitContainer2.SplitterDistance = 26;
            this.splitContainer2.TabIndex = 16;
            // 
            // Setting_button
            // 
            this.Setting_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Setting_button.BackColor = System.Drawing.Color.Transparent;
            this.Setting_button.FlatAppearance.BorderSize = 0;
            this.Setting_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Setting_button.Image = ((System.Drawing.Image)(resources.GetObject("Setting_button.Image")));
            this.Setting_button.Location = new System.Drawing.Point(2, 3);
            this.Setting_button.MaximumSize = new System.Drawing.Size(22, 22);
            this.Setting_button.MinimumSize = new System.Drawing.Size(22, 22);
            this.Setting_button.Name = "Setting_button";
            this.Setting_button.Size = new System.Drawing.Size(22, 22);
            this.Setting_button.TabIndex = 11;
            this.Setting_button.UseVisualStyleBackColor = false;
            this.Setting_button.Click += new System.EventHandler(this.Setting_button_Click);
            // 
            // ToggleHost
            // 
            this.ToggleHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ToggleHost.Location = new System.Drawing.Point(3, 3);
            this.ToggleHost.Name = "ToggleHost";
            this.ToggleHost.Size = new System.Drawing.Size(33, 22);
            this.ToggleHost.TabIndex = 15;
            this.ToggleHost.Text = "elementHost1";
            this.ToggleHost.Child = this.ToggleSwitch;
            // 
            // Admin_Label
            // 
            this.Admin_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Admin_Label.AutoSize = true;
            this.Admin_Label.Location = new System.Drawing.Point(9, 724);
            this.Admin_Label.Name = "Admin_Label";
            this.Admin_Label.Size = new System.Drawing.Size(86, 13);
            this.Admin_Label.TabIndex = 14;
            this.Admin_Label.Text = "Администратор";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(5, 503);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(157, 10);
            this.progressBar1.TabIndex = 8;
            // 
            // ExportToXml_button
            // 
            this.ExportToXml_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportToXml_button.Location = new System.Drawing.Point(5, 519);
            this.ExportToXml_button.Name = "ExportToXml_button";
            this.ExportToXml_button.Size = new System.Drawing.Size(157, 23);
            this.ExportToXml_button.TabIndex = 7;
            this.ExportToXml_button.Text = "Экспортировать в Excel";
            this.ExportToXml_button.UseVisualStyleBackColor = true;
            this.ExportToXml_button.Click += new System.EventHandler(this.ExportToXml_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.printDateTimePicker);
            this.groupBox2.Controls.Add(this.entranceControl_radioButton);
            this.groupBox2.Controls.Add(this.repairs_radioButton);
            this.groupBox2.Controls.Add(this.test_radioButton);
            this.groupBox2.Controls.Add(this.PrintPdf_button);
            this.groupBox2.Location = new System.Drawing.Point(3, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 142);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройка печати";
            // 
            // printDateTimePicker
            // 
            this.printDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printDateTimePicker.Location = new System.Drawing.Point(4, 88);
            this.printDateTimePicker.Name = "printDateTimePicker";
            this.printDateTimePicker.ShowCheckBox = true;
            this.printDateTimePicker.Size = new System.Drawing.Size(153, 20);
            this.printDateTimePicker.TabIndex = 5;
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
            this.PrintPdf_button.Location = new System.Drawing.Point(2, 114);
            this.PrintPdf_button.Name = "PrintPdf_button";
            this.PrintPdf_button.Size = new System.Drawing.Size(157, 23);
            this.PrintPdf_button.TabIndex = 1;
            this.PrintPdf_button.Text = "Печать предъявления";
            this.PrintPdf_button.UseVisualStyleBackColor = true;
            this.PrintPdf_button.Click += new System.EventHandler(this.PrintPdf_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.seporatingLine_label2);
            this.groupBox1.Controls.Add(this.decommissioned_label);
            this.groupBox1.Controls.Add(this.notgan_label);
            this.groupBox1.Controls.Add(this.gan_label);
            this.groupBox1.Controls.Add(this.seporatingLine_label3);
            this.groupBox1.Controls.Add(this.allDevides_label);
            this.groupBox1.Controls.Add(this.storage_label);
            this.groupBox1.Controls.Add(this.seporatingLine_label);
            this.groupBox1.Controls.Add(this.overdue_label);
            this.groupBox1.Controls.Add(this.sent_label);
            this.groupBox1.Controls.Add(this.conservation_label);
            this.groupBox1.Location = new System.Drawing.Point(5, 548);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 166);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация:";
            // 
            // seporatingLine_label2
            // 
            this.seporatingLine_label2.AutoSize = true;
            this.seporatingLine_label2.Location = new System.Drawing.Point(6, 107);
            this.seporatingLine_label2.Name = "seporatingLine_label2";
            this.seporatingLine_label2.Size = new System.Drawing.Size(127, 13);
            this.seporatingLine_label2.TabIndex = 14;
            this.seporatingLine_label2.Text = "____________________";
            // 
            // decommissioned_label
            // 
            this.decommissioned_label.AutoSize = true;
            this.decommissioned_label.Location = new System.Drawing.Point(9, 120);
            this.decommissioned_label.Name = "decommissioned_label";
            this.decommissioned_label.Size = new System.Drawing.Size(66, 13);
            this.decommissioned_label.TabIndex = 13;
            this.decommissioned_label.Text = "Списанных:";
            // 
            // notgan_label
            // 
            this.notgan_label.AutoSize = true;
            this.notgan_label.Location = new System.Drawing.Point(9, 94);
            this.notgan_label.Name = "notgan_label";
            this.notgan_label.Size = new System.Drawing.Size(99, 13);
            this.notgan_label.TabIndex = 12;
            this.notgan_label.Text = "Приборов не ГАН:";
            // 
            // gan_label
            // 
            this.gan_label.AutoSize = true;
            this.gan_label.Location = new System.Drawing.Point(9, 81);
            this.gan_label.Name = "gan_label";
            this.gan_label.Size = new System.Drawing.Size(84, 13);
            this.gan_label.TabIndex = 11;
            this.gan_label.Text = "Приборов ГАН:";
            // 
            // seporatingLine_label3
            // 
            this.seporatingLine_label3.AutoSize = true;
            this.seporatingLine_label3.Location = new System.Drawing.Point(6, 133);
            this.seporatingLine_label3.Name = "seporatingLine_label3";
            this.seporatingLine_label3.Size = new System.Drawing.Size(127, 13);
            this.seporatingLine_label3.TabIndex = 10;
            this.seporatingLine_label3.Text = "____________________";
            // 
            // allDevides_label
            // 
            this.allDevides_label.AutoSize = true;
            this.allDevides_label.Location = new System.Drawing.Point(9, 146);
            this.allDevides_label.Name = "allDevides_label";
            this.allDevides_label.Size = new System.Drawing.Size(94, 13);
            this.allDevides_label.TabIndex = 9;
            this.allDevides_label.Text = "Всего устройств:";
            // 
            // storage_label
            // 
            this.storage_label.AutoSize = true;
            this.storage_label.Location = new System.Drawing.Point(9, 55);
            this.storage_label.Name = "storage_label";
            this.storage_label.Size = new System.Drawing.Size(63, 13);
            this.storage_label.TabIndex = 8;
            this.storage_label.Text = "На складе:";
            // 
            // seporatingLine_label
            // 
            this.seporatingLine_label.AutoSize = true;
            this.seporatingLine_label.Location = new System.Drawing.Point(6, 68);
            this.seporatingLine_label.Name = "seporatingLine_label";
            this.seporatingLine_label.Size = new System.Drawing.Size(127, 13);
            this.seporatingLine_label.TabIndex = 7;
            this.seporatingLine_label.Text = "____________________";
            // 
            // overdue_label
            // 
            this.overdue_label.AutoSize = true;
            this.overdue_label.Location = new System.Drawing.Point(9, 42);
            this.overdue_label.Name = "overdue_label";
            this.overdue_label.Size = new System.Drawing.Size(74, 13);
            this.overdue_label.TabIndex = 6;
            this.overdue_label.Text = "Просрочено: ";
            // 
            // sent_label
            // 
            this.sent_label.AutoSize = true;
            this.sent_label.Location = new System.Drawing.Point(9, 29);
            this.sent_label.Name = "sent_label";
            this.sent_label.Size = new System.Drawing.Size(71, 13);
            this.sent_label.TabIndex = 5;
            this.sent_label.Text = "Отправлено:";
            // 
            // conservation_label
            // 
            this.conservation_label.AutoSize = true;
            this.conservation_label.Location = new System.Drawing.Point(9, 16);
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
            treeNode5.Name = "UDAB";
            treeNode5.Text = "УДАБ";
            treeNode6.Name = "UDAS";
            treeNode6.Text = "УДАС";
            treeNode7.Name = "DKG";
            treeNode7.Text = "ДКГ";
            treeNode8.Name = "All";
            treeNode8.Text = "Все приборы";
            treeNode9.Name = "PREPROSROCH";
            treeNode9.Text = "Подготовить на отпр.";
            treeNode10.Name = "PROSROCH";
            treeNode10.Text = "Просроченные приборы";
            treeNode11.Name = "KONSERV";
            treeNode11.Text = "Консервация";
            treeNode12.Name = "OTPRAVLENNIE";
            treeNode12.Text = "Отправленные на Гос. поверку";
            treeNode13.Name = "SKLAD";
            treeNode13.Text = "Склад";
            treeNode14.Name = "gan";
            treeNode14.Text = "ГАН";
            treeNode15.Name = "notgan";
            treeNode15.Text = "Другие";
            treeNode16.Name = "decommissioned";
            treeNode16.Text = "Списанные приборы";
            treeNode17.Name = "lists";
            treeNode17.Text = "Особые списки";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode17});
            this.treeView1.Size = new System.Drawing.Size(164, 199);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // StatusPanel
            // 
            this.StatusPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyncStatusLabel_StatusPanel,
            this.CountStatusLabel_StatusPanel,
            this.CountVisibleDevices_StatusLabel});
            this.StatusPanel.Location = new System.Drawing.Point(0, 727);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(1196, 22);
            this.StatusPanel.TabIndex = 3;
            this.StatusPanel.Text = "statusStrip1";
            // 
            // SyncStatusLabel_StatusPanel
            // 
            this.SyncStatusLabel_StatusPanel.Name = "SyncStatusLabel_StatusPanel";
            this.SyncStatusLabel_StatusPanel.Size = new System.Drawing.Size(157, 17);
            this.SyncStatusLabel_StatusPanel.Text = "Последняя синхронизация:";
            // 
            // CountStatusLabel_StatusPanel
            // 
            this.CountStatusLabel_StatusPanel.Name = "CountStatusLabel_StatusPanel";
            this.CountStatusLabel_StatusPanel.Size = new System.Drawing.Size(207, 17);
            this.CountStatusLabel_StatusPanel.Text = "Количество выделенных приборов: ";
            // 
            // CountVisibleDevices_StatusLabel
            // 
            this.CountVisibleDevices_StatusLabel.Name = "CountVisibleDevices_StatusLabel";
            this.CountVisibleDevices_StatusLabel.Size = new System.Drawing.Size(141, 17);
            this.CountVisibleDevices_StatusLabel.Text = "Отображено приборов: ";
            // 
            // search_textBox
            // 
            this.search_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_textBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.search_textBox.Location = new System.Drawing.Point(3, 3);
            this.search_textBox.Name = "search_textBox";
            this.search_textBox.Size = new System.Drawing.Size(1190, 20);
            this.search_textBox.TabIndex = 2;
            this.search_textBox.Text = "Введите: Табельный номер, заводской номер или квартал, до которого продлён прибор" +
    " (пр.: 1 кв. 2020)";
            this.search_textBox.TextChanged += new System.EventHandler(this.search_textBox_TextChanged);
            this.search_textBox.Enter += new System.EventHandler(this.search_textBox_Enter);
            this.search_textBox.Leave += new System.EventHandler(this.search_textBox_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.dataGrid_contextMenuStrip;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.Location = new System.Drawing.Point(3, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1190, 698);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            // 
            // dataGrid_contextMenuStrip
            // 
            this.dataGrid_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.separateToolStripMenuItem,
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.dataGrid_contextMenuStrip.Name = "dataGrid_contextMenuStrip";
            this.dataGrid_contextMenuStrip.Size = new System.Drawing.Size(165, 114);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.changeToolStripMenuItem.Text = "Изменить";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.replaceToolStripMenuItem.Text = "Заменить";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // separateToolStripMenuItem
            // 
            this.separateToolStripMenuItem.Enabled = false;
            this.separateToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.separateToolStripMenuItem.Name = "separateToolStripMenuItem";
            this.separateToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.separateToolStripMenuItem.Text = "__________________";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addToolStripMenuItem.Text = "Добавить";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // Staff_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Staff_MainForm";
            this.Text = "Radioactive Raccoon (v1.5.2 от 13/09/2019)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Staff_MainForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.dataGrid_contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button PrintPdf_button;
        private System.Windows.Forms.TextBox search_textBox;
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
        private System.Windows.Forms.Label allDevides_label;
        private System.Windows.Forms.Button Setting_button;
        private System.Windows.Forms.Label notgan_label;
        private System.Windows.Forms.Label gan_label;
        private System.Windows.Forms.Label seporatingLine_label3;
        private System.Windows.Forms.Label Admin_Label;
        private System.Windows.Forms.Integration.ElementHost ToggleHost;
        private Toggle ToggleSwitch;
        private System.Windows.Forms.StatusStrip StatusPanel;
        private System.Windows.Forms.ToolStripStatusLabel SyncStatusLabel_StatusPanel;
        private System.Windows.Forms.ToolStripStatusLabel CountStatusLabel_StatusPanel;
        private System.Windows.Forms.Label seporatingLine_label2;
        private System.Windows.Forms.Label decommissioned_label;
        private System.Windows.Forms.ToolStripStatusLabel CountVisibleDevices_StatusLabel;
        private System.Windows.Forms.ContextMenuStrip dataGrid_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem separateToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private DateTimePicker printDateTimePicker;
        private SplitContainer splitContainer2;

        public Toggle ToggleSwitch1 { get => ToggleSwitch; set => ToggleSwitch = value; }
        public Label Conservation_label { get => conservation_label; set => conservation_label = value; }
        public Label Sent_label { get => sent_label; set => sent_label = value; }
        public Label Overdue_label { get => overdue_label; set => overdue_label = value; }
        public Label Storage_label { get => storage_label; set => storage_label = value; }
        public Label Decommissioned_label { get => decommissioned_label; set => decommissioned_label = value; }
        public Label AllDevides_label { get => allDevides_label; set => allDevides_label = value; }
        public Label Gan_label { get => gan_label; set => gan_label = value; }
        public Label Notgan_label { get => notgan_label; set => notgan_label = value; }
        public ToolStripStatusLabel CountVisibleDevices_StatusLabel1 { get => CountVisibleDevices_StatusLabel; set => CountVisibleDevices_StatusLabel = value; }
        public TextBox Search_textBox { get => search_textBox; set => search_textBox = value; }
        public TreeView TreeView { get => treeView1; }
    }
}


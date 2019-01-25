namespace StaffSRC
{
    partial class Uim_info
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uimInfo_DataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.roomPowerSocketInfo_DataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uimInfo_DataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomPowerSocketInfo_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(380, 584);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uimInfo_DataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(372, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "УИМ2-2";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uimInfo_DataGridView
            // 
            this.uimInfo_DataGridView.AllowUserToAddRows = false;
            this.uimInfo_DataGridView.AllowUserToDeleteRows = false;
            this.uimInfo_DataGridView.AllowUserToResizeColumns = false;
            this.uimInfo_DataGridView.AllowUserToResizeRows = false;
            this.uimInfo_DataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.uimInfo_DataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.uimInfo_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uimInfo_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uimInfo_DataGridView.Location = new System.Drawing.Point(3, 3);
            this.uimInfo_DataGridView.MultiSelect = false;
            this.uimInfo_DataGridView.Name = "uimInfo_DataGridView";
            this.uimInfo_DataGridView.ReadOnly = true;
            this.uimInfo_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uimInfo_DataGridView.Size = new System.Drawing.Size(366, 552);
            this.uimInfo_DataGridView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.roomPowerSocketInfo_DataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(372, 558);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Помещения";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // roomPowerSocketInfo_DataGridView
            // 
            this.roomPowerSocketInfo_DataGridView.AllowUserToAddRows = false;
            this.roomPowerSocketInfo_DataGridView.AllowUserToDeleteRows = false;
            this.roomPowerSocketInfo_DataGridView.AllowUserToResizeColumns = false;
            this.roomPowerSocketInfo_DataGridView.AllowUserToResizeRows = false;
            this.roomPowerSocketInfo_DataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.roomPowerSocketInfo_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomPowerSocketInfo_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomPowerSocketInfo_DataGridView.Location = new System.Drawing.Point(3, 3);
            this.roomPowerSocketInfo_DataGridView.Name = "roomPowerSocketInfo_DataGridView";
            this.roomPowerSocketInfo_DataGridView.Size = new System.Drawing.Size(366, 552);
            this.roomPowerSocketInfo_DataGridView.TabIndex = 0;
            // 
            // Uim_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 584);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Uim_info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка по УИМ2-2 и помещениям";
            this.Load += new System.EventHandler(this.Uim_info_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uimInfo_DataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roomPowerSocketInfo_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView uimInfo_DataGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView roomPowerSocketInfo_DataGridView;
    }
}
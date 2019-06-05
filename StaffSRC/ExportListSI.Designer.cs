namespace StaffSRC
{
    partial class ExportListSI
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
            this.Export_button = new System.Windows.Forms.Button();
            this.From_comboBox = new System.Windows.Forms.ComboBox();
            this.To_comboBox = new System.Windows.Forms.ComboBox();
            this.From_label = new System.Windows.Forms.Label();
            this.To_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Export_button
            // 
            this.Export_button.Location = new System.Drawing.Point(15, 39);
            this.Export_button.Name = "Export_button";
            this.Export_button.Size = new System.Drawing.Size(193, 23);
            this.Export_button.TabIndex = 0;
            this.Export_button.Text = "Экспорт";
            this.Export_button.UseVisualStyleBackColor = true;
            this.Export_button.Click += new System.EventHandler(this.Export_button_Click);
            // 
            // From_comboBox
            // 
            this.From_comboBox.FormattingEnabled = true;
            this.From_comboBox.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
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
            this.From_comboBox.Location = new System.Drawing.Point(41, 12);
            this.From_comboBox.Name = "From_comboBox";
            this.From_comboBox.Size = new System.Drawing.Size(65, 21);
            this.From_comboBox.TabIndex = 1;
            this.From_comboBox.SelectedIndexChanged += new System.EventHandler(this.From_comboBox_SelectedIndexChanged);
            // 
            // To_comboBox
            // 
            this.To_comboBox.FormattingEnabled = true;
            this.To_comboBox.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
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
            this.To_comboBox.Location = new System.Drawing.Point(143, 12);
            this.To_comboBox.Name = "To_comboBox";
            this.To_comboBox.Size = new System.Drawing.Size(65, 21);
            this.To_comboBox.TabIndex = 2;
            this.To_comboBox.SelectedIndexChanged += new System.EventHandler(this.To_comboBox_SelectedIndexChanged);
            // 
            // From_label
            // 
            this.From_label.AutoSize = true;
            this.From_label.Location = new System.Drawing.Point(12, 15);
            this.From_label.Name = "From_label";
            this.From_label.Size = new System.Drawing.Size(23, 13);
            this.From_label.TabIndex = 3;
            this.From_label.Text = "От:";
            // 
            // To_label
            // 
            this.To_label.AutoSize = true;
            this.To_label.Location = new System.Drawing.Point(112, 15);
            this.To_label.Name = "To_label";
            this.To_label.Size = new System.Drawing.Size(25, 13);
            this.To_label.TabIndex = 4;
            this.To_label.Text = "До:";
            // 
            // ExportListSI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 75);
            this.Controls.Add(this.To_label);
            this.Controls.Add(this.From_label);
            this.Controls.Add(this.To_comboBox);
            this.Controls.Add(this.From_comboBox);
            this.Controls.Add(this.Export_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExportListSI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Интервал дат:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Export_button;
        private System.Windows.Forms.ComboBox From_comboBox;
        private System.Windows.Forms.ComboBox To_comboBox;
        private System.Windows.Forms.Label From_label;
        private System.Windows.Forms.Label To_label;
    }
}
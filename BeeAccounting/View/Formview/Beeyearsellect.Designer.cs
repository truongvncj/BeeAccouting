namespace BEEACCOUNT.View
{
    partial class Beeyearsellect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Beeyearsellect));
            this.bt_thuchien = new System.Windows.Forms.Button();
            this.cb_year = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_thuchien
            // 
            this.bt_thuchien.Location = new System.Drawing.Point(75, 68);
            this.bt_thuchien.Name = "bt_thuchien";
            this.bt_thuchien.Size = new System.Drawing.Size(93, 25);
            this.bt_thuchien.TabIndex = 3;
            this.bt_thuchien.Text = "Chọn";
            this.bt_thuchien.UseVisualStyleBackColor = true;
            this.bt_thuchien.Click += new System.EventHandler(this.bt_thuchien_Click);
            // 
            // cb_year
            // 
            this.cb_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_year.FormattingEnabled = true;
            this.cb_year.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023"});
            this.cb_year.Location = new System.Drawing.Point(75, 22);
            this.cb_year.Name = "cb_year";
            this.cb_year.Size = new System.Drawing.Size(93, 23);
            this.cb_year.TabIndex = 10;
            this.cb_year.SelectedValueChanged += new System.EventHandler(this.cb_year_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Năm";
            // 
            // Beeyearsellect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 105);
            this.Controls.Add(this.cb_year);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_thuchien);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Beeyearsellect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn năm";
            this.Load += new System.EventHandler(this.Beeyearsellect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_thuchien;
        private System.Windows.Forms.ComboBox cb_year;
        private System.Windows.Forms.Label label3;
    }
}
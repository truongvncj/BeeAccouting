namespace BEEACCOUNT.View
{
    partial class ChonNCChoacNV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChonNCChoacNV));
            this.bt_thuchien = new System.Windows.Forms.Button();
            this.cb_nhacungung = new System.Windows.Forms.CheckBox();
            this.cb_nhanvientamung = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bt_thuchien
            // 
            this.bt_thuchien.Location = new System.Drawing.Point(140, 172);
            this.bt_thuchien.Name = "bt_thuchien";
            this.bt_thuchien.Size = new System.Drawing.Size(84, 23);
            this.bt_thuchien.TabIndex = 3;
            this.bt_thuchien.Text = "Chọn";
            this.bt_thuchien.UseVisualStyleBackColor = true;
            this.bt_thuchien.Click += new System.EventHandler(this.bt_thuchien_Click);
            // 
            // cb_nhacungung
            // 
            this.cb_nhacungung.AutoSize = true;
            this.cb_nhacungung.Checked = true;
            this.cb_nhacungung.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_nhacungung.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_nhacungung.Location = new System.Drawing.Point(42, 43);
            this.cb_nhacungung.Name = "cb_nhacungung";
            this.cb_nhacungung.Size = new System.Drawing.Size(295, 28);
            this.cb_nhacungung.TabIndex = 4;
            this.cb_nhacungung.Text = "Thanh toán nhà cung ứng (331)";
            this.cb_nhacungung.UseVisualStyleBackColor = true;
            this.cb_nhacungung.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cb_nhanvientamung
            // 
            this.cb_nhanvientamung.AutoSize = true;
            this.cb_nhanvientamung.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_nhanvientamung.Location = new System.Drawing.Point(42, 102);
            this.cb_nhanvientamung.Name = "cb_nhanvientamung";
            this.cb_nhanvientamung.Size = new System.Drawing.Size(245, 28);
            this.cb_nhanvientamung.TabIndex = 5;
            this.cb_nhanvientamung.Text = "Thanh toán tạm ứng (141)";
            this.cb_nhanvientamung.UseVisualStyleBackColor = true;
            this.cb_nhanvientamung.CheckedChanged += new System.EventHandler(this.cb_nhanvientamung_CheckedChanged);
            // 
            // ChonNCChoacNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 229);
            this.Controls.Add(this.cb_nhanvientamung);
            this.Controls.Add(this.cb_nhacungung);
            this.Controls.Add(this.bt_thuchien);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChonNCChoacNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn loại thanh toán";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_thuchien;
        private System.Windows.Forms.CheckBox cb_nhacungung;
        private System.Windows.Forms.CheckBox cb_nhanvientamung;
    }
}
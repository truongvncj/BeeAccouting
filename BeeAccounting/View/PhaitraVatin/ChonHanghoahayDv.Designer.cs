namespace BEEACCOUNT.View
{
    partial class ChonHanghoahayDv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChonHanghoahayDv));
            this.bt_thuchien = new System.Windows.Forms.Button();
            this.cb_sphanghoanhapkho = new System.Windows.Forms.CheckBox();
            this.cb_spdichvu = new System.Windows.Forms.CheckBox();
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
            // cb_sphanghoanhapkho
            // 
            this.cb_sphanghoanhapkho.AutoSize = true;
            this.cb_sphanghoanhapkho.Checked = true;
            this.cb_sphanghoanhapkho.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_sphanghoanhapkho.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_sphanghoanhapkho.Location = new System.Drawing.Point(42, 43);
            this.cb_sphanghoanhapkho.Name = "cb_sphanghoanhapkho";
            this.cb_sphanghoanhapkho.Size = new System.Drawing.Size(196, 28);
            this.cb_sphanghoanhapkho.TabIndex = 4;
            this.cb_sphanghoanhapkho.Text = "Hàng hóa nhập kho";
            this.cb_sphanghoanhapkho.UseVisualStyleBackColor = true;
            this.cb_sphanghoanhapkho.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cb_spdichvu
            // 
            this.cb_spdichvu.AutoSize = true;
            this.cb_spdichvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_spdichvu.Location = new System.Drawing.Point(42, 102);
            this.cb_spdichvu.Name = "cb_spdichvu";
            this.cb_spdichvu.Size = new System.Drawing.Size(92, 28);
            this.cb_spdichvu.TabIndex = 5;
            this.cb_spdichvu.Text = "Dịch vụ";
            this.cb_spdichvu.UseVisualStyleBackColor = true;
            this.cb_spdichvu.CheckedChanged += new System.EventHandler(this.cb_nhanvientamung_CheckedChanged);
            // 
            // ChonHanghoahayDv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 229);
            this.Controls.Add(this.cb_spdichvu);
            this.Controls.Add(this.cb_sphanghoanhapkho);
            this.Controls.Add(this.bt_thuchien);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChonHanghoahayDv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn loại thanh toán";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_thuchien;
        private System.Windows.Forms.CheckBox cb_sphanghoanhapkho;
        private System.Windows.Forms.CheckBox cb_spdichvu;
    }
}
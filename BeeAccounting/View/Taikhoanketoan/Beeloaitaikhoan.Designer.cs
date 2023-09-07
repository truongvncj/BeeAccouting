namespace BEEACCOUNT.View
{
    partial class Beeloaitaikhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Beeloaitaikhoan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txttenloaitk = new System.Windows.Forms.TextBox();
            this.cbmaloaitk = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bttaomoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btupdate = new System.Windows.Forms.Button();
            this.btxoa = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txttenloaitk);
            this.panel1.Controls.Add(this.cbmaloaitk);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bttaomoi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btupdate);
            this.panel1.Controls.Add(this.btxoa);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 149);
            this.panel1.TabIndex = 0;
            // 
            // txttenloaitk
            // 
            this.txttenloaitk.Location = new System.Drawing.Point(171, 21);
            this.txttenloaitk.Name = "txttenloaitk";
            this.txttenloaitk.Size = new System.Drawing.Size(382, 20);
            this.txttenloaitk.TabIndex = 59;
            // 
            // cbmaloaitk
            // 
            this.cbmaloaitk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmaloaitk.FormattingEnabled = true;
            this.cbmaloaitk.Items.AddRange(new object[] {
            "TIENMAT",
            "NGANHANG",
            "KHO",
            "TAISAN",
            "NGUONVON",
            "DOANHTHU",
            "CHIPHI",
            "TINHKQKD",
            "LOINHUAN",
            "PHAITHU",
            "PHAITRA"});
            this.cbmaloaitk.Location = new System.Drawing.Point(171, 57);
            this.cbmaloaitk.Name = "cbmaloaitk";
            this.cbmaloaitk.Size = new System.Drawing.Size(214, 21);
            this.cbmaloaitk.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "Mã loại tài khoản";
            // 
            // bttaomoi
            // 
            this.bttaomoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bttaomoi.BackColor = System.Drawing.Color.Transparent;
            this.bttaomoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttaomoi.ForeColor = System.Drawing.Color.Red;
            this.bttaomoi.Location = new System.Drawing.Point(445, 116);
            this.bttaomoi.Name = "bttaomoi";
            this.bttaomoi.Size = new System.Drawing.Size(94, 27);
            this.bttaomoi.TabIndex = 53;
            this.bttaomoi.Text = "Tạo mới";
            this.bttaomoi.UseVisualStyleBackColor = false;
            this.bttaomoi.Click += new System.EventHandler(this.bttaomoi_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Tên loại tài khoản";
            // 
            // btupdate
            // 
            this.btupdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btupdate.BackColor = System.Drawing.Color.Transparent;
            this.btupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btupdate.ForeColor = System.Drawing.Color.Red;
            this.btupdate.Location = new System.Drawing.Point(301, 116);
            this.btupdate.Name = "btupdate";
            this.btupdate.Size = new System.Drawing.Size(94, 27);
            this.btupdate.TabIndex = 6;
            this.btupdate.Text = "Cập nhật";
            this.btupdate.UseVisualStyleBackColor = false;
            this.btupdate.Click += new System.EventHandler(this.btupdate_Click);
            // 
            // btxoa
            // 
            this.btxoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btxoa.BackColor = System.Drawing.Color.Transparent;
            this.btxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btxoa.ForeColor = System.Drawing.Color.Red;
            this.btxoa.Location = new System.Drawing.Point(171, 116);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(94, 27);
            this.btxoa.TabIndex = 6;
            this.btxoa.Text = "Xóa";
            this.btxoa.UseVisualStyleBackColor = false;
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
            // 
            // Beeloaitaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 155);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Beeloaitaikhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loại tài khoản kế toán";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btupdate;
        private System.Windows.Forms.Button btxoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttaomoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttenloaitk;
        private System.Windows.Forms.ComboBox cbmaloaitk;
    }
}
namespace BEEACCOUNT.View
{
    partial class ThemtktinhKQKD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemtktinhKQKD));
            this.bt_themvao = new System.Windows.Forms.Button();
            this.txtmatk = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckListcongtru = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckListNoco = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtchuoi = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_themvao
            // 
            this.bt_themvao.Location = new System.Drawing.Point(370, 287);
            this.bt_themvao.Name = "bt_themvao";
            this.bt_themvao.Size = new System.Drawing.Size(103, 23);
            this.bt_themvao.TabIndex = 7;
            this.bt_themvao.Text = "Thêm ";
            this.bt_themvao.UseVisualStyleBackColor = true;
            this.bt_themvao.Click += new System.EventHandler(this.bt_themvao_Click);
            this.bt_themvao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bt_themvao_KeyPress);
            // 
            // txtmatk
            // 
            this.txtmatk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmatk.Location = new System.Drawing.Point(159, 22);
            this.txtmatk.Name = "txtmatk";
            this.txtmatk.Size = new System.Drawing.Size(235, 24);
            this.txtmatk.TabIndex = 0;
            this.txtmatk.TextChanged += new System.EventHandler(this.tbchontkco_TextChanged);
            this.txtmatk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbchontkco_KeyPress_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 18);
            this.label13.TabIndex = 82;
            this.label13.Text = "Tài khoản kế toán";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckListcongtru);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 76);
            this.groupBox2.TabIndex = 81;
            this.groupBox2.TabStop = false;
            // 
            // ckListcongtru
            // 
            this.ckListcongtru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckListcongtru.FormattingEnabled = true;
            this.ckListcongtru.Items.AddRange(new object[] {
            "Cộng",
            "Trừ"});
            this.ckListcongtru.Location = new System.Drawing.Point(81, 19);
            this.ckListcongtru.Name = "ckListcongtru";
            this.ckListcongtru.Size = new System.Drawing.Size(106, 46);
            this.ckListcongtru.TabIndex = 85;
            this.ckListcongtru.SelectedIndexChanged += new System.EventHandler(this.ckListcongtru_SelectedIndexChanged);
            this.ckListcongtru.SelectedValueChanged += new System.EventHandler(this.ckListcongtru_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 73;
            this.label2.Text = "Phép tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(52, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 77;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckListNoco);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(278, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 96);
            this.groupBox3.TabIndex = 82;
            this.groupBox3.TabStop = false;
            // 
            // ckListNoco
            // 
            this.ckListNoco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckListNoco.FormattingEnabled = true;
            this.ckListNoco.Items.AddRange(new object[] {
            "Dư Nợ",
            "Dư Có"});
            this.ckListNoco.Location = new System.Drawing.Point(128, 24);
            this.ckListNoco.Name = "ckListNoco";
            this.ckListNoco.Size = new System.Drawing.Size(109, 46);
            this.ckListNoco.TabIndex = 85;
            this.ckListNoco.SelectedIndexChanged += new System.EventHandler(this.ckListNoco_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 73;
            this.label5.Text = "Lựa chọn số liệu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(52, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 16);
            this.label6.TabIndex = 77;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 18);
            this.label7.TabIndex = 84;
            this.label7.Text = "Chuỗi kỹ tự";
            // 
            // txtchuoi
            // 
            this.txtchuoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtchuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchuoi.Location = new System.Drawing.Point(115, 210);
            this.txtchuoi.Name = "txtchuoi";
            this.txtchuoi.ReadOnly = true;
            this.txtchuoi.Size = new System.Drawing.Size(209, 24);
            this.txtchuoi.TabIndex = 83;
            // 
            // ThemtktinhKQKD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 322);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtmatk);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtchuoi);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bt_themvao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemtktinhKQKD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tài khoản";
            this.Deactivate += new System.EventHandler(this.BeeHtoansocaidoiungphieuthu_Deactivate);
            this.Load += new System.EventHandler(this.BeeHtoansocaidoiungphieuthu_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_themvao;
        private System.Windows.Forms.TextBox txtmatk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtchuoi;
        private System.Windows.Forms.CheckedListBox ckListcongtru;
        private System.Windows.Forms.CheckedListBox ckListNoco;
    }
}
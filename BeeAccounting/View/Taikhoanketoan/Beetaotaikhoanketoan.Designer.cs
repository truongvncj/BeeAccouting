namespace BEEACCOUNT.View
{
    partial class Beetaotaikhoanketoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Beetaotaikhoanketoan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbtaikhoanketchuyencuoinam = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkbookchitiet = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btupdate = new System.Windows.Forms.Button();
            this.btxoa = new System.Windows.Forms.Button();
            this.cbtkmother = new System.Windows.Forms.ComboBox();
            this.cbloaitk = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcaptaikhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnew = new System.Windows.Forms.Button();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.txt_nametk = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbtaikhoanketchuyencuoinam);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.checkbookchitiet);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btupdate);
            this.panel1.Controls.Add(this.btxoa);
            this.panel1.Controls.Add(this.cbtkmother);
            this.panel1.Controls.Add(this.cbloaitk);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtcaptaikhoan);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnew);
            this.panel1.Controls.Add(this.txtcode);
            this.panel1.Controls.Add(this.txt_nametk);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 370);
            this.panel1.TabIndex = 0;
            // 
            // cbtaikhoanketchuyencuoinam
            // 
            this.cbtaikhoanketchuyencuoinam.DropDownWidth = 332;
            this.cbtaikhoanketchuyencuoinam.FormattingEnabled = true;
            this.cbtaikhoanketchuyencuoinam.Location = new System.Drawing.Point(189, 241);
            this.cbtaikhoanketchuyencuoinam.Name = "cbtaikhoanketchuyencuoinam";
            this.cbtaikhoanketchuyencuoinam.Size = new System.Drawing.Size(347, 21);
            this.cbtaikhoanketchuyencuoinam.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 21);
            this.label5.TabIndex = 61;
            this.label5.Text = "Tài khoản kết chuyển cuối năm";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // checkbookchitiet
            // 
            this.checkbookchitiet.AutoSize = true;
            this.checkbookchitiet.Location = new System.Drawing.Point(191, 207);
            this.checkbookchitiet.Name = "checkbookchitiet";
            this.checkbookchitiet.Size = new System.Drawing.Size(29, 17);
            this.checkbookchitiet.TabIndex = 59;
            this.checkbookchitiet.Text = " ";
            this.checkbookchitiet.UseVisualStyleBackColor = true;
            this.checkbookchitiet.CheckedChanged += new System.EventHandler(this.checkbookchitiet_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 17);
            this.label4.TabIndex = 58;
            this.label4.Text = "Đăng ký mở sổ dõi chi tiết";
            // 
            // btupdate
            // 
            this.btupdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btupdate.BackColor = System.Drawing.Color.Transparent;
            this.btupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btupdate.ForeColor = System.Drawing.Color.Red;
            this.btupdate.Location = new System.Drawing.Point(344, 333);
            this.btupdate.Name = "btupdate";
            this.btupdate.Size = new System.Drawing.Size(94, 21);
            this.btupdate.TabIndex = 6;
            this.btupdate.Text = "Cập nhật";
            this.btupdate.UseVisualStyleBackColor = false;
            this.btupdate.Click += new System.EventHandler(this.btupdate_Click);
            // 
            // btxoa
            // 
            this.btxoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btxoa.BackColor = System.Drawing.Color.Transparent;
            this.btxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btxoa.ForeColor = System.Drawing.Color.Red;
            this.btxoa.Location = new System.Drawing.Point(207, 333);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(94, 21);
            this.btxoa.TabIndex = 6;
            this.btxoa.Text = "Xóa";
            this.btxoa.UseVisualStyleBackColor = false;
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
            // 
            // cbtkmother
            // 
            this.cbtkmother.DropDownWidth = 332;
            this.cbtkmother.FormattingEnabled = true;
            this.cbtkmother.Location = new System.Drawing.Point(191, 163);
            this.cbtkmother.Name = "cbtkmother";
            this.cbtkmother.Size = new System.Drawing.Size(347, 21);
            this.cbtkmother.TabIndex = 5;
            this.cbtkmother.SelectedIndexChanged += new System.EventHandler(this.cbtkmother_SelectedIndexChanged);
            this.cbtkmother.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbtkmother_KeyPress);
            // 
            // cbloaitk
            // 
            this.cbloaitk.DropDownWidth = 332;
            this.cbloaitk.FormattingEnabled = true;
            this.cbloaitk.Location = new System.Drawing.Point(191, 92);
            this.cbloaitk.Name = "cbloaitk";
            this.cbloaitk.Size = new System.Drawing.Size(347, 21);
            this.cbloaitk.TabIndex = 3;
            this.cbloaitk.SelectedIndexChanged += new System.EventHandler(this.cbloaitk_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 17);
            this.label3.TabIndex = 56;
            this.label3.Text = "TK  con của tài khoản";
            // 
            // txtcaptaikhoan
            // 
            this.txtcaptaikhoan.Enabled = false;
            this.txtcaptaikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcaptaikhoan.Location = new System.Drawing.Point(192, 127);
            this.txtcaptaikhoan.Name = "txtcaptaikhoan";
            this.txtcaptaikhoan.Size = new System.Drawing.Size(109, 20);
            this.txtcaptaikhoan.TabIndex = 53;
            this.txtcaptaikhoan.Text = "1";
            this.txtcaptaikhoan.TextChanged += new System.EventHandler(this.txtcaptaikhoan_TextChanged);
            this.txtcaptaikhoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "Cấp tài khoản";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 52;
            this.label1.Text = "Loại tài khoản";
            // 
            // btnew
            // 
            this.btnew.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnew.BackColor = System.Drawing.Color.Transparent;
            this.btnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnew.ForeColor = System.Drawing.Color.Red;
            this.btnew.Location = new System.Drawing.Point(444, 333);
            this.btnew.Name = "btnew";
            this.btnew.Size = new System.Drawing.Size(94, 21);
            this.btnew.TabIndex = 8;
            this.btnew.Text = "Tạo mới";
            this.btnew.UseVisualStyleBackColor = false;
            this.btnew.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtcode
            // 
            this.txtcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcode.Location = new System.Drawing.Point(193, 25);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(109, 20);
            this.txtcode.TabIndex = 1;
            this.txtcode.TextChanged += new System.EventHandler(this.txtcode_TextChanged);
            this.txtcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustcode_KeyPress);
            // 
            // txt_nametk
            // 
            this.txt_nametk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nametk.Location = new System.Drawing.Point(192, 62);
            this.txt_nametk.Name = "txt_nametk";
            this.txt_nametk.Size = new System.Drawing.Size(346, 20);
            this.txt_nametk.TabIndex = 2;
            this.txt_nametk.TextChanged += new System.EventHandler(this.txt_nametk_TextChanged);
            this.txt_nametk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_represennt_KeyPress);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(14, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(171, 17);
            this.label20.TabIndex = 50;
            this.label20.Text = "Mã tài khoản";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(14, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(170, 21);
            this.label21.TabIndex = 49;
            this.label21.Text = "Tên tài khoản";
            // 
            // Beetaotaikhoanketoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 388);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Beetaotaikhoanketoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tài khoản";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.TextBox txt_nametk;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnew;
        private System.Windows.Forms.ComboBox cbtkmother;
        private System.Windows.Forms.ComboBox cbloaitk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcaptaikhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btupdate;
        private System.Windows.Forms.Button btxoa;
        private System.Windows.Forms.CheckBox checkbookchitiet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbtaikhoanketchuyencuoinam;
    }
}
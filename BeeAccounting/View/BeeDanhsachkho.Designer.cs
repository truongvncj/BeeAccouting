namespace BEEACCOUNT.View
{
    partial class BeeDanhsachkho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeeDanhsachkho));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btupdate = new System.Windows.Forms.Button();
            this.btxoa = new System.Windows.Forms.Button();
            this.btnew = new System.Windows.Forms.Button();
            this.txtmakho = new System.Windows.Forms.TextBox();
            this.txttenkho = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtghichu);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtdiachi);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btupdate);
            this.panel1.Controls.Add(this.btxoa);
            this.panel1.Controls.Add(this.btnew);
            this.panel1.Controls.Add(this.txtmakho);
            this.panel1.Controls.Add(this.txttenkho);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 210);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtghichu
            // 
            this.txtghichu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtghichu.Location = new System.Drawing.Point(171, 138);
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(368, 20);
            this.txtghichu.TabIndex = 74;
            this.txtghichu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghichu_KeyPress);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 75;
            this.label5.Text = "Ghi chú";
            // 
            // txtdiachi
            // 
            this.txtdiachi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiachi.Location = new System.Drawing.Point(170, 98);
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(368, 20);
            this.txtdiachi.TabIndex = 67;
            this.txtdiachi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdiachi_KeyPress);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 20);
            this.label11.TabIndex = 68;
            this.label11.Text = "Địa chỉ";
            // 
            // btupdate
            // 
            this.btupdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btupdate.BackColor = System.Drawing.Color.Transparent;
            this.btupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btupdate.ForeColor = System.Drawing.Color.Red;
            this.btupdate.Location = new System.Drawing.Point(336, 186);
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
            this.btxoa.Location = new System.Drawing.Point(199, 186);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(94, 21);
            this.btxoa.TabIndex = 6;
            this.btxoa.Text = "Xóa";
            this.btxoa.UseVisualStyleBackColor = false;
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
            // 
            // btnew
            // 
            this.btnew.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnew.BackColor = System.Drawing.Color.Transparent;
            this.btnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnew.ForeColor = System.Drawing.Color.Red;
            this.btnew.Location = new System.Drawing.Point(447, 186);
            this.btnew.Name = "btnew";
            this.btnew.Size = new System.Drawing.Size(94, 21);
            this.btnew.TabIndex = 8;
            this.btnew.Text = "Tạo mới";
            this.btnew.UseVisualStyleBackColor = false;
            this.btnew.Click += new System.EventHandler(this.btnew_Click);
            // 
            // txtmakho
            // 
            this.txtmakho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmakho.Location = new System.Drawing.Point(171, 25);
            this.txtmakho.Name = "txtmakho";
            this.txtmakho.Size = new System.Drawing.Size(131, 20);
            this.txtmakho.TabIndex = 1;
            this.txtmakho.TextChanged += new System.EventHandler(this.txtmakho_TextChanged);
            this.txtmakho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustcode_KeyPress);
            // 
            // txttenkho
            // 
            this.txttenkho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenkho.Location = new System.Drawing.Point(172, 61);
            this.txttenkho.Name = "txttenkho";
            this.txttenkho.Size = new System.Drawing.Size(368, 20);
            this.txttenkho.TabIndex = 2;
            this.txttenkho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttenkho_KeyPress);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(14, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(126, 16);
            this.label20.TabIndex = 50;
            this.label20.Text = "Mã kho";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(14, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 20);
            this.label21.TabIndex = 49;
            this.label21.Text = "Tên kho";
            // 
            // BeeDanhsachkho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 218);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeeDanhsachkho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kho hàng";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtmakho;
        private System.Windows.Forms.TextBox txttenkho;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnew;
        private System.Windows.Forms.Button btupdate;
        private System.Windows.Forms.Button btxoa;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.Label label5;
    }
}
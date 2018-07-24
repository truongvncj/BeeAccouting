namespace BEEACCOUNT.View
{
    partial class BeeSeachdieuvan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeeSeachdieuvan));
            this.label1 = new System.Windows.Forms.Label();
            this.txttenkhachhang = new System.Windows.Forms.TextBox();
            this.txtdiachihanghoas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsovandon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txthanghoa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên khách hàng";
            // 
            // txttenkhachhang
            // 
            this.txttenkhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenkhachhang.Location = new System.Drawing.Point(16, 24);
            this.txttenkhachhang.Name = "txttenkhachhang";
            this.txttenkhachhang.Size = new System.Drawing.Size(215, 32);
            this.txttenkhachhang.TabIndex = 1;
            this.txttenkhachhang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingtext_KeyPress);
            // 
            // txtdiachihanghoas
            // 
            this.txtdiachihanghoas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiachihanghoas.Location = new System.Drawing.Point(16, 75);
            this.txtdiachihanghoas.Name = "txtdiachihanghoas";
            this.txtdiachihanghoas.Size = new System.Drawing.Size(215, 32);
            this.txtdiachihanghoas.TabIndex = 2;
            this.txtdiachihanghoas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingcontract_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Địa chỉ khách hàng";
            // 
            // txtsovandon
            // 
            this.txtsovandon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsovandon.Location = new System.Drawing.Point(14, 126);
            this.txtsovandon.Name = "txtsovandon";
            this.txtsovandon.Size = new System.Drawing.Size(215, 32);
            this.txtsovandon.TabIndex = 3;
            this.txtsovandon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingname_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số vận đơn";
            // 
            // txthanghoa
            // 
            this.txthanghoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthanghoa.Location = new System.Drawing.Point(14, 179);
            this.txthanghoa.Name = "txthanghoa";
            this.txthanghoa.Size = new System.Drawing.Size(215, 32);
            this.txthanghoa.TabIndex = 4;
            this.txthanghoa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtvat_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tên hàng hóa";
            // 
            // BeeSeachdieuvan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 244);
            this.Controls.Add(this.txthanghoa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtsovandon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdiachihanghoas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttenkhachhang);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeeSeachdieuvan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm";
            this.Deactivate += new System.EventHandler(this.Seachcode_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttenkhachhang;
        private System.Windows.Forms.TextBox txtdiachihanghoas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsovandon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txthanghoa;
        private System.Windows.Forms.Label label4;
    }
}
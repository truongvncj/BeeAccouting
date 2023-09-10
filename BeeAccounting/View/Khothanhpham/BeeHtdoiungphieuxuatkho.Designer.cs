namespace BEEACCOUNT.View
{
    partial class BeeHtdoiungphieuxuatkho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeeHtdoiungphieuxuatkho));
            this.bt_themvao = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtdonvi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttensanpham = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbmasanpham = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_themvao
            // 
            this.bt_themvao.Location = new System.Drawing.Point(380, 225);
            this.bt_themvao.Name = "bt_themvao";
            this.bt_themvao.Size = new System.Drawing.Size(103, 22);
            this.bt_themvao.TabIndex = 7;
            this.bt_themvao.Text = "Thêm ";
            this.bt_themvao.UseVisualStyleBackColor = true;
            this.bt_themvao.TextChanged += new System.EventHandler(this.bt_themvao_TextChanged);
            this.bt_themvao.Click += new System.EventHandler(this.bt_themvao_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtdonvi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txttensanpham);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtsoluong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbmasanpham);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " --";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtdonvi
            // 
            this.txtdonvi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdonvi.Location = new System.Drawing.Point(127, 107);
            this.txtdonvi.Name = "txtdonvi";
            this.txtdonvi.ReadOnly = true;
            this.txtdonvi.Size = new System.Drawing.Size(125, 24);
            this.txtdonvi.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 48;
            this.label4.Text = "Đơn vị";
            // 
            // txttensanpham
            // 
            this.txttensanpham.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttensanpham.Location = new System.Drawing.Point(127, 66);
            this.txttensanpham.Name = "txttensanpham";
            this.txttensanpham.ReadOnly = true;
            this.txttensanpham.Size = new System.Drawing.Size(390, 24);
            this.txttensanpham.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 43;
            this.label2.Text = "Tên sản phẩm";
            // 
            // txtsoluong
            // 
            this.txtsoluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsoluong.Location = new System.Drawing.Point(127, 147);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(125, 24);
            this.txtsoluong.TabIndex = 41;
            this.txtsoluong.TextChanged += new System.EventHandler(this.txtsoluong_TextChanged);
            this.txtsoluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsoluong_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 39;
            this.label1.Text = "Mã sản phẩm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 18);
            this.label8.TabIndex = 36;
            this.label8.Text = "Số lượng";
            // 
            // cbmasanpham
            // 
            this.cbmasanpham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmasanpham.DropDownWidth = 350;
            this.cbmasanpham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmasanpham.FormattingEnabled = true;
            this.cbmasanpham.Location = new System.Drawing.Point(127, 29);
            this.cbmasanpham.Name = "cbmasanpham";
            this.cbmasanpham.Size = new System.Drawing.Size(208, 24);
            this.cbmasanpham.TabIndex = 0;
            this.cbmasanpham.SelectionChangeCommitted += new System.EventHandler(this.cbtkco_SelectionChangeCommitted);
            this.cbmasanpham.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbmasanpham_KeyPress);
            // 
            // BeeHtdoiungphieuxuatkho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 258);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bt_themvao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeeHtdoiungphieuxuatkho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hạch toán kế toán";
            this.Deactivate += new System.EventHandler(this.BeeHtoansocaidoiungphieuthu_Deactivate);
            this.Load += new System.EventHandler(this.BeeHtoansocaidoiungphieuthu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_themvao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbmasanpham;
        private System.Windows.Forms.TextBox txttensanpham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.TextBox txtdonvi;
        private System.Windows.Forms.Label label4;
    }
}
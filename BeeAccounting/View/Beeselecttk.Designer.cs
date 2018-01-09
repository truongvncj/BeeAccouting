namespace BEEACCOUNT.View
{
    partial class Beeselecttk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Beeselecttk));
            this.bt_thuchien = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pkfromdate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.pk_todate = new System.Windows.Forms.DateTimePicker();
            this.lb_machitietno = new System.Windows.Forms.Label();
            this.lbtenchitietno = new System.Windows.Forms.Label();
            this.cbtk = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_thuchien
            // 
            this.bt_thuchien.Location = new System.Drawing.Point(261, 170);
            this.bt_thuchien.Name = "bt_thuchien";
            this.bt_thuchien.Size = new System.Drawing.Size(84, 23);
            this.bt_thuchien.TabIndex = 3;
            this.bt_thuchien.Text = "Chọn";
            this.bt_thuchien.UseVisualStyleBackColor = true;
            this.bt_thuchien.Click += new System.EventHandler(this.bt_thuchien_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Từ ngày:";
            // 
            // pkfromdate
            // 
            this.pkfromdate.CustomFormat = "dd.MM.yyyy";
            this.pkfromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pkfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkfromdate.Location = new System.Drawing.Point(138, 76);
            this.pkfromdate.Name = "pkfromdate";
            this.pkfromdate.Size = new System.Drawing.Size(122, 24);
            this.pkfromdate.TabIndex = 1;
            this.pkfromdate.Value = new System.DateTime(2017, 8, 19, 6, 29, 10, 0);
            this.pkfromdate.ValueChanged += new System.EventHandler(this.pkfromdate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Đến ngày:";
            // 
            // pk_todate
            // 
            this.pk_todate.CustomFormat = "dd.MM.yyyy";
            this.pk_todate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pk_todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pk_todate.Location = new System.Drawing.Point(138, 107);
            this.pk_todate.Name = "pk_todate";
            this.pk_todate.Size = new System.Drawing.Size(122, 24);
            this.pk_todate.TabIndex = 2;
            this.pk_todate.Value = new System.DateTime(2017, 8, 19, 6, 29, 34, 0);
            // 
            // lb_machitietno
            // 
            this.lb_machitietno.AutoSize = true;
            this.lb_machitietno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_machitietno.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_machitietno.Location = new System.Drawing.Point(137, 49);
            this.lb_machitietno.Name = "lb_machitietno";
            this.lb_machitietno.Size = new System.Drawing.Size(40, 16);
            this.lb_machitietno.TabIndex = 65;
            this.lb_machitietno.Text = "Mã ct";
            // 
            // lbtenchitietno
            // 
            this.lbtenchitietno.AutoSize = true;
            this.lbtenchitietno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtenchitietno.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbtenchitietno.Location = new System.Drawing.Point(183, 49);
            this.lbtenchitietno.Name = "lbtenchitietno";
            this.lbtenchitietno.Size = new System.Drawing.Size(57, 16);
            this.lbtenchitietno.TabIndex = 64;
            this.lbtenchitietno.Text = "Chi tiết 1";
            // 
            // cbtk
            // 
            this.cbtk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtk.DropDownWidth = 350;
            this.cbtk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtk.FormattingEnabled = true;
            this.cbtk.Location = new System.Drawing.Point(138, 20);
            this.cbtk.Name = "cbtk";
            this.cbtk.Size = new System.Drawing.Size(207, 26);
            this.cbtk.TabIndex = 0;
            this.cbtk.SelectionChangeCommitted += new System.EventHandler(this.cbtk_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 62;
            this.label3.Text = "Tài khoản";
            // 
            // Beeselecttk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 205);
            this.Controls.Add(this.lb_machitietno);
            this.Controls.Add(this.lbtenchitietno);
            this.Controls.Add(this.cbtk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pk_todate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pkfromdate);
            this.Controls.Add(this.bt_thuchien);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Beeselecttk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn tài khoản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_thuchien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker pkfromdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker pk_todate;
        private System.Windows.Forms.Label lb_machitietno;
        private System.Windows.Forms.Label lbtenchitietno;
        private System.Windows.Forms.ComboBox cbtk;
        private System.Windows.Forms.Label label3;
    }
}
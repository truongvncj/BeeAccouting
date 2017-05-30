namespace BEEACCOUNT.View
{
    partial class KAcontractlisting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KAcontractlisting));
            this.panel1 = new System.Windows.Forms.Panel();
            this.filterlabel = new System.Windows.Forms.Label();
            this.cbcontracttypefil = new System.Windows.Forms.ComboBox();
            this.statusview = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.formname = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Bt_Adddata = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.filterlabel);
            this.panel1.Controls.Add(this.cbcontracttypefil);
            this.panel1.Controls.Add(this.statusview);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.formname);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Bt_Adddata);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 502);
            this.panel1.TabIndex = 0;
            // 
            // filterlabel
            // 
            this.filterlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterlabel.AutoSize = true;
            this.filterlabel.ForeColor = System.Drawing.Color.Red;
            this.filterlabel.Location = new System.Drawing.Point(736, 34);
            this.filterlabel.Name = "filterlabel";
            this.filterlabel.Size = new System.Drawing.Size(99, 13);
            this.filterlabel.TabIndex = 47;
            this.filterlabel.Text = "Filter Contract Type";
            // 
            // cbcontracttypefil
            // 
            this.cbcontracttypefil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbcontracttypefil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcontracttypefil.FormattingEnabled = true;
            this.cbcontracttypefil.Location = new System.Drawing.Point(841, 30);
            this.cbcontracttypefil.Name = "cbcontracttypefil";
            this.cbcontracttypefil.Size = new System.Drawing.Size(121, 21);
            this.cbcontracttypefil.TabIndex = 46;
            // 
            // statusview
            // 
            this.statusview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statusview.AutoSize = true;
            this.statusview.ForeColor = System.Drawing.Color.Blue;
            this.statusview.Location = new System.Drawing.Point(990, 48);
            this.statusview.Name = "statusview";
            this.statusview.Size = new System.Drawing.Size(39, 13);
            this.statusview.TabIndex = 43;
            this.statusview.Text = "Master";
            this.statusview.Click += new System.EventHandler(this.statusview_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(112, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 22);
            this.button1.TabIndex = 42;
            this.button1.Text = "Update All Contract";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formname
            // 
            this.formname.AutoSize = true;
            this.formname.ForeColor = System.Drawing.Color.Blue;
            this.formname.Location = new System.Drawing.Point(9, 48);
            this.formname.Name = "formname";
            this.formname.Size = new System.Drawing.Size(74, 13);
            this.formname.TabIndex = 41;
            this.formname.Text = "Input Contract";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(9, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 22);
            this.button2.TabIndex = 40;
            this.button2.Text = "Exports Excel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(255, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "F3:Contract Seach    F6:Create New Contract        F7: Detail List         F8: Ma" +
    "ster List   ";
            // 
            // Bt_Adddata
            // 
            this.Bt_Adddata.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Bt_Adddata.Location = new System.Drawing.Point(222, 23);
            this.Bt_Adddata.Name = "Bt_Adddata";
            this.Bt_Adddata.Size = new System.Drawing.Size(97, 22);
            this.Bt_Adddata.TabIndex = 36;
            this.Bt_Adddata.Text = "Contract View";
            this.Bt_Adddata.UseVisualStyleBackColor = true;
            this.Bt_Adddata.Click += new System.EventHandler(this.Bt_Adddata_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(395, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "CONTRACT LISTING";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1043, 428);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // KAcontractlisting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 509);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KAcontractlisting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KAcontractlisting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Bt_Adddata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label formname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label statusview;
        private System.Windows.Forms.ComboBox cbcontracttypefil;
        private System.Windows.Forms.Label filterlabel;
    }
}
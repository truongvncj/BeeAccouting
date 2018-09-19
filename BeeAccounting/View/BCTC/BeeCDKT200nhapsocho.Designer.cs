namespace BEEACCOUNT.View
{
    partial class BeeCDKT200nhapsocho
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeeCDKT200nhapsocho));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.formlabelED = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btchangecontractitem = new System.Windows.Forms.Button();
            this.txtnam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // formlabelED
            // 
            this.formlabelED.AutoSize = true;
            this.formlabelED.BackColor = System.Drawing.SystemColors.Control;
            this.formlabelED.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formlabelED.Location = new System.Drawing.Point(258, 11);
            this.formlabelED.Name = "formlabelED";
            this.formlabelED.Size = new System.Drawing.Size(362, 19);
            this.formlabelED.TabIndex = 87;
            this.formlabelED.Text = "NHẬP SỐ  ĐẦU KỲ BÁO CÁO CÂN ĐỐI KẾ TOÁN";
            this.formlabelED.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Controls.Add(this.btchangecontractitem);
            this.groupBox4.Controls.Add(this.formlabelED);
            this.groupBox4.Controls.Add(this.txtnam);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(7, -2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(880, 542);
            this.groupBox4.TabIndex = 102;
            this.groupBox4.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(868, 442);
            this.dataGridView1.TabIndex = 102;
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            // 
            // btchangecontractitem
            // 
            this.btchangecontractitem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btchangecontractitem.BackColor = System.Drawing.Color.Transparent;
            this.btchangecontractitem.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btchangecontractitem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btchangecontractitem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btchangecontractitem.ForeColor = System.Drawing.Color.Red;
            this.btchangecontractitem.Location = new System.Drawing.Point(726, 510);
            this.btchangecontractitem.Name = "btchangecontractitem";
            this.btchangecontractitem.Size = new System.Drawing.Size(78, 23);
            this.btchangecontractitem.TabIndex = 101;
            this.btchangecontractitem.Text = "Lưu";
            this.btchangecontractitem.UseVisualStyleBackColor = false;
            this.btchangecontractitem.Click += new System.EventHandler(this.btchangecontractitem_Click);
            // 
            // txtnam
            // 
            this.txtnam.BackColor = System.Drawing.SystemColors.Control;
            this.txtnam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtnam.FormattingEnabled = true;
            this.txtnam.Location = new System.Drawing.Point(362, 31);
            this.txtnam.Name = "txtnam";
            this.txtnam.Size = new System.Drawing.Size(71, 21);
            this.txtnam.TabIndex = 88;
            this.txtnam.SelectedIndexChanged += new System.EventHandler(this.txtten_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 87;
            this.label1.Text = "Năm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BeeCDKT200nhapsocho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 543);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeeCDKT200nhapsocho";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BCTC - CĐKT 200 ";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label formlabelED;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox txtnam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btchangecontractitem;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
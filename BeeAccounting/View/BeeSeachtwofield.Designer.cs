namespace BEEACCOUNT.View
{
    partial class BeeSeachtwofield
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeeSeachtwofield));
            this.lb01 = new System.Windows.Forms.Label();
            this.text01 = new System.Windows.Forms.TextBox();
            this.text02 = new System.Windows.Forms.TextBox();
            this.lb02 = new System.Windows.Forms.Label();
            this.txt03 = new System.Windows.Forms.TextBox();
            this.lb03 = new System.Windows.Forms.Label();
            this.bt_timkiem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb01
            // 
            this.lb01.AutoSize = true;
            this.lb01.Location = new System.Drawing.Point(13, 8);
            this.lb01.Name = "lb01";
            this.lb01.Size = new System.Drawing.Size(27, 13);
            this.lb01.TabIndex = 0;
            this.lb01.Text = "lb01";
            // 
            // text01
            // 
            this.text01.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text01.Location = new System.Drawing.Point(16, 24);
            this.text01.Name = "text01";
            this.text01.Size = new System.Drawing.Size(287, 32);
            this.text01.TabIndex = 1;
            this.text01.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingtext_KeyPress);
            // 
            // text02
            // 
            this.text02.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text02.Location = new System.Drawing.Point(16, 75);
            this.text02.Name = "text02";
            this.text02.Size = new System.Drawing.Size(287, 32);
            this.text02.TabIndex = 2;
            this.text02.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingcontract_KeyPress);
            // 
            // lb02
            // 
            this.lb02.AutoSize = true;
            this.lb02.Location = new System.Drawing.Point(13, 59);
            this.lb02.Name = "lb02";
            this.lb02.Size = new System.Drawing.Size(27, 13);
            this.lb02.TabIndex = 2;
            this.lb02.Text = "lb02";
            // 
            // txt03
            // 
            this.txt03.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt03.Location = new System.Drawing.Point(14, 126);
            this.txt03.Name = "txt03";
            this.txt03.Size = new System.Drawing.Size(289, 32);
            this.txt03.TabIndex = 3;
            this.txt03.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingname_KeyPress);
            // 
            // lb03
            // 
            this.lb03.AutoSize = true;
            this.lb03.Location = new System.Drawing.Point(11, 110);
            this.lb03.Name = "lb03";
            this.lb03.Size = new System.Drawing.Size(27, 13);
            this.lb03.TabIndex = 4;
            this.lb03.Text = "lb03";
            // 
            // bt_timkiem
            // 
            this.bt_timkiem.Location = new System.Drawing.Point(200, 182);
            this.bt_timkiem.Name = "bt_timkiem";
            this.bt_timkiem.Size = new System.Drawing.Size(103, 23);
            this.bt_timkiem.TabIndex = 5;
            this.bt_timkiem.Text = "Tìm kiếm";
            this.bt_timkiem.UseVisualStyleBackColor = true;
            this.bt_timkiem.Click += new System.EventHandler(this.bt_timkiem_Click);
            this.bt_timkiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bt_timkiem_KeyPress);
            // 
            // BeeSeachtwofield
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 219);
            this.Controls.Add(this.bt_timkiem);
            this.Controls.Add(this.txt03);
            this.Controls.Add(this.lb03);
            this.Controls.Add(this.text02);
            this.Controls.Add(this.lb02);
            this.Controls.Add(this.text01);
            this.Controls.Add(this.lb01);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeeSeachtwofield";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm";
            this.Deactivate += new System.EventHandler(this.Seachcode_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb01;
        private System.Windows.Forms.TextBox text01;
        private System.Windows.Forms.TextBox text02;
        private System.Windows.Forms.Label lb02;
        private System.Windows.Forms.TextBox txt03;
        private System.Windows.Forms.Label lb03;
        private System.Windows.Forms.Button bt_timkiem;
    }
}
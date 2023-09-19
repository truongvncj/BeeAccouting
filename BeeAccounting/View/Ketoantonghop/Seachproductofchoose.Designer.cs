namespace BEEACCOUNT.View
{
    partial class Seachproductofchoose
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb01
            // 
            this.lb01.AutoSize = true;
            this.lb01.Location = new System.Drawing.Point(19, 4);
            this.lb01.Name = "lb01";
            this.lb01.Size = new System.Drawing.Size(27, 13);
            this.lb01.TabIndex = 0;
            this.lb01.Text = "lb01";
            // 
            // text01
            // 
            this.text01.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text01.Location = new System.Drawing.Point(22, 20);
            this.text01.Name = "text01";
            this.text01.Size = new System.Drawing.Size(389, 32);
            this.text01.TabIndex = 1;
            this.text01.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingtext_KeyPress);
            // 
            // text02
            // 
            this.text02.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text02.Location = new System.Drawing.Point(22, 71);
            this.text02.Name = "text02";
            this.text02.Size = new System.Drawing.Size(389, 32);
            this.text02.TabIndex = 2;
            this.text02.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingcontract_KeyPress);
            // 
            // lb02
            // 
            this.lb02.AutoSize = true;
            this.lb02.Location = new System.Drawing.Point(19, 55);
            this.lb02.Name = "lb02";
            this.lb02.Size = new System.Drawing.Size(27, 13);
            this.lb02.TabIndex = 2;
            this.lb02.Text = "lb02";
            // 
            // txt03
            // 
            this.txt03.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt03.Location = new System.Drawing.Point(20, 122);
            this.txt03.Name = "txt03";
            this.txt03.Size = new System.Drawing.Size(391, 32);
            this.txt03.TabIndex = 3;
            this.txt03.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendingname_KeyPress);
            // 
            // lb03
            // 
            this.lb03.AutoSize = true;
            this.lb03.Location = new System.Drawing.Point(17, 106);
            this.lb03.Name = "lb03";
            this.lb03.Size = new System.Drawing.Size(27, 13);
            this.lb03.TabIndex = 4;
            this.lb03.Text = "lb03";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter để tìm kiếm";
            // 
            // BeeSeachtwofield
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 184);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
    }
}
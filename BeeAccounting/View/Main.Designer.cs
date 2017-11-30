namespace BEEACCOUNT.View
{
    using BEEACCOUNT;
    using System.Windows.Forms;

    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 
       
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lbusername = new System.Windows.Forms.Label();
            this.lb_user = new System.Windows.Forms.Label();
            this.panelmain = new System.Windows.Forms.Panel();
            this.dfasfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ádfasdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Controls.Add(this.lbusername);
            this.panel1.Controls.Add(this.lb_user);
            this.panel1.Controls.Add(this.panelmain);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 662);
            this.panel1.TabIndex = 20;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(1118, 7);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(212, 652);
            this.webBrowser1.TabIndex = 25;
            this.webBrowser1.Url = new System.Uri("https://sites.google.com/site/advcocacolagogle/", System.UriKind.Absolute);
            // 
            // lbusername
            // 
            this.lbusername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbusername.AutoSize = true;
            this.lbusername.ForeColor = System.Drawing.Color.Red;
            this.lbusername.Location = new System.Drawing.Point(67, 649);
            this.lbusername.Name = "lbusername";
            this.lbusername.Size = new System.Drawing.Size(35, 13);
            this.lbusername.TabIndex = 24;
            this.lbusername.Text = "label1";
            // 
            // lb_user
            // 
            this.lb_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_user.AutoSize = true;
            this.lb_user.Location = new System.Drawing.Point(3, 649);
            this.lb_user.Name = "lb_user";
            this.lb_user.Size = new System.Drawing.Size(58, 13);
            this.lb_user.TabIndex = 23;
            this.lb_user.Text = "User name";
            // 
            // panelmain
            // 
            this.panelmain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelmain.AutoScroll = true;
            this.panelmain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelmain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelmain.Location = new System.Drawing.Point(6, 27);
            this.panelmain.Name = "panelmain";
            this.panelmain.Size = new System.Drawing.Size(1106, 619);
            this.panelmain.TabIndex = 7;
            // 
            // dfasfToolStripMenuItem
            // 
            this.dfasfToolStripMenuItem.Name = "dfasfToolStripMenuItem";
            this.dfasfToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.dfasfToolStripMenuItem.Text = "Thiết lập người dùng";
            this.dfasfToolStripMenuItem.Click += new System.EventHandler(this.dfasfToolStripMenuItem_Click);
            // 
            // ádfasdfToolStripMenuItem
            // 
            this.ádfasdfToolStripMenuItem.Name = "ádfasdfToolStripMenuItem";
            this.ádfasdfToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ádfasdfToolStripMenuItem.Text = "Thiết lập hệ thống";
            this.ádfasdfToolStripMenuItem.Click += new System.EventHandler(this.ádfasdfToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 20);
            this.textBox1.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 19);
            this.button1.TabIndex = 28;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "T-Code";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 669);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BEE ACCOUNTING";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_user;
        private Label lbusername;
     //   private ToolStripMenuItem Menu;
        private ToolStripMenuItem dfasfToolStripMenuItem;
        private ToolStripMenuItem ádfasdfToolStripMenuItem;
        private WebBrowser webBrowser1;
        private Panel panelmain;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
    }
}


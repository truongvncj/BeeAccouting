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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoNhậpXuấtTồnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoGiaoHàngHàngTrênĐườngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.inputMinuteTransferPOSMTicketToMKTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfPOSMTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sôKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.sôKhoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.baoCaoNhâpXuâtTônKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.sôNhâtKyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.baoCaoKQKDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baoCaoLưuChuyênTiênTêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banCânĐôiTaiKhoanPhatSinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baoCaoTaiChinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.hêThôngTaiKhoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dfasfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ádfasdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Controls.Add(this.lbusername);
            this.panel1.Controls.Add(this.lb_user);
            this.panel1.Controls.Add(this.panelmain);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1450, 645);
            this.panel1.TabIndex = 20;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(1232, 7);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(212, 635);
            this.webBrowser1.TabIndex = 25;
            this.webBrowser1.Url = new System.Uri("https://sites.google.com/site/advcocacolagogle/", System.UriKind.Absolute);
            // 
            // lbusername
            // 
            this.lbusername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbusername.AutoSize = true;
            this.lbusername.ForeColor = System.Drawing.Color.Red;
            this.lbusername.Location = new System.Drawing.Point(67, 632);
            this.lbusername.Name = "lbusername";
            this.lbusername.Size = new System.Drawing.Size(35, 13);
            this.lbusername.TabIndex = 24;
            this.lbusername.Text = "label1";
            // 
            // lb_user
            // 
            this.lb_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_user.AutoSize = true;
            this.lb_user.Location = new System.Drawing.Point(3, 632);
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
            this.panelmain.Size = new System.Drawing.Size(1220, 602);
            this.panelmain.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fINToolStripMenuItem,
            this.systemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(6, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(158, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fINToolStripMenuItem
            // 
            this.fINToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoNhậpXuấtTồnToolStripMenuItem,
            this.báoCáoGiaoHàngHàngTrênĐườngToolStripMenuItem,
            this.toolStripSeparator11,
            this.inputMinuteTransferPOSMTicketToMKTToolStripMenuItem,
            this.listOfPOSMTicketToolStripMenuItem,
            this.sôKhoToolStripMenuItem,
            this.toolStripSeparator12,
            this.sôKhoToolStripMenuItem1,
            this.baoCaoNhâpXuâtTônKhoToolStripMenuItem,
            this.toolStripSeparator13,
            this.sôNhâtKyToolStripMenuItem,
            this.toolStripSeparator14,
            this.baoCaoKQKDToolStripMenuItem,
            this.baoCaoLưuChuyênTiênTêToolStripMenuItem,
            this.banCânĐôiTaiKhoanPhatSinhToolStripMenuItem,
            this.baoCaoTaiChinhToolStripMenuItem});
            this.fINToolStripMenuItem.Name = "fINToolStripMenuItem";
            this.fINToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.fINToolStripMenuItem.Text = "BÁO CÁO";
            this.fINToolStripMenuItem.Click += new System.EventHandler(this.fINToolStripMenuItem_Click);
            // 
            // báoCáoNhậpXuấtTồnToolStripMenuItem
            // 
            this.báoCáoNhậpXuấtTồnToolStripMenuItem.Name = "báoCáoNhậpXuấtTồnToolStripMenuItem";
            this.báoCáoNhậpXuấtTồnToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.báoCáoNhậpXuấtTồnToolStripMenuItem.Text = "Sổ cái tài khoản";
            // 
            // báoCáoGiaoHàngHàngTrênĐườngToolStripMenuItem
            // 
            this.báoCáoGiaoHàngHàngTrênĐườngToolStripMenuItem.Name = "báoCáoGiaoHàngHàngTrênĐườngToolStripMenuItem";
            this.báoCáoGiaoHàngHàngTrênĐườngToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.báoCáoGiaoHàngHàngTrênĐườngToolStripMenuItem.Text = "Sổ chi tiết tài khản";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(237, 6);
            // 
            // inputMinuteTransferPOSMTicketToMKTToolStripMenuItem
            // 
            this.inputMinuteTransferPOSMTicketToMKTToolStripMenuItem.Name = "inputMinuteTransferPOSMTicketToMKTToolStripMenuItem";
            this.inputMinuteTransferPOSMTicketToMKTToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.inputMinuteTransferPOSMTicketToMKTToolStripMenuItem.Text = "Sổ quỹ";
            // 
            // listOfPOSMTicketToolStripMenuItem
            // 
            this.listOfPOSMTicketToolStripMenuItem.Name = "listOfPOSMTicketToolStripMenuItem";
            this.listOfPOSMTicketToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.listOfPOSMTicketToolStripMenuItem.Text = "Sổ tạm ứng";
            // 
            // sôKhoToolStripMenuItem
            // 
            this.sôKhoToolStripMenuItem.Name = "sôKhoToolStripMenuItem";
            this.sôKhoToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.sôKhoToolStripMenuItem.Text = "Sổ lương";
            this.sôKhoToolStripMenuItem.Click += new System.EventHandler(this.sôKhoToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(237, 6);
            // 
            // sôKhoToolStripMenuItem1
            // 
            this.sôKhoToolStripMenuItem1.Name = "sôKhoToolStripMenuItem1";
            this.sôKhoToolStripMenuItem1.Size = new System.Drawing.Size(240, 22);
            this.sôKhoToolStripMenuItem1.Text = "Sổ kho";
            // 
            // baoCaoNhâpXuâtTônKhoToolStripMenuItem
            // 
            this.baoCaoNhâpXuâtTônKhoToolStripMenuItem.Name = "baoCaoNhâpXuâtTônKhoToolStripMenuItem";
            this.baoCaoNhâpXuâtTônKhoToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.baoCaoNhâpXuâtTônKhoToolStripMenuItem.Text = "Báo cáo nhập xuất tồn kho";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(237, 6);
            // 
            // sôNhâtKyToolStripMenuItem
            // 
            this.sôNhâtKyToolStripMenuItem.Name = "sôNhâtKyToolStripMenuItem";
            this.sôNhâtKyToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.sôNhâtKyToolStripMenuItem.Text = "Sổ nhật ký";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(237, 6);
            // 
            // baoCaoKQKDToolStripMenuItem
            // 
            this.baoCaoKQKDToolStripMenuItem.Name = "baoCaoKQKDToolStripMenuItem";
            this.baoCaoKQKDToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.baoCaoKQKDToolStripMenuItem.Text = "Báo cáo KQKD";
            // 
            // baoCaoLưuChuyênTiênTêToolStripMenuItem
            // 
            this.baoCaoLưuChuyênTiênTêToolStripMenuItem.Name = "baoCaoLưuChuyênTiênTêToolStripMenuItem";
            this.baoCaoLưuChuyênTiênTêToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.baoCaoLưuChuyênTiênTêToolStripMenuItem.Text = "Báo cáo lưu chuyển tiền tệ";
            // 
            // banCânĐôiTaiKhoanPhatSinhToolStripMenuItem
            // 
            this.banCânĐôiTaiKhoanPhatSinhToolStripMenuItem.Name = "banCânĐôiTaiKhoanPhatSinhToolStripMenuItem";
            this.banCânĐôiTaiKhoanPhatSinhToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.banCânĐôiTaiKhoanPhatSinhToolStripMenuItem.Text = "Bản cân đối tài khoản phát sinh";
            // 
            // baoCaoTaiChinhToolStripMenuItem
            // 
            this.baoCaoTaiChinhToolStripMenuItem.Name = "baoCaoTaiChinhToolStripMenuItem";
            this.baoCaoTaiChinhToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.baoCaoTaiChinhToolStripMenuItem.Text = "Báo cáo tài chính";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configMasterToolStripMenuItem,
            this.usersSetupToolStripMenuItem,
            this.toolStripSeparator1,
            this.hêThôngTaiKhoanToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.systemToolStripMenuItem.Text = "HỆ THỐNG";
            // 
            // configMasterToolStripMenuItem
            // 
            this.configMasterToolStripMenuItem.Name = "configMasterToolStripMenuItem";
            this.configMasterToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.configMasterToolStripMenuItem.Text = "Thiết lập hệ thống";
            this.configMasterToolStripMenuItem.Click += new System.EventHandler(this.configMasterToolStripMenuItem_Click);
            // 
            // usersSetupToolStripMenuItem
            // 
            this.usersSetupToolStripMenuItem.Name = "usersSetupToolStripMenuItem";
            this.usersSetupToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.usersSetupToolStripMenuItem.Text = "Thiết lập phân quyền người dùng";
            this.usersSetupToolStripMenuItem.Click += new System.EventHandler(this.usersSetupToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(248, 6);
            // 
            // hêThôngTaiKhoanToolStripMenuItem
            // 
            this.hêThôngTaiKhoanToolStripMenuItem.Name = "hêThôngTaiKhoanToolStripMenuItem";
            this.hêThôngTaiKhoanToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.hêThôngTaiKhoanToolStripMenuItem.Text = "Hệ thống tài khoản";
            this.hêThôngTaiKhoanToolStripMenuItem.Click += new System.EventHandler(this.hêThôngTaiKhoanToolStripMenuItem_Click);
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 669);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BEE ACCOUNTING";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_user;
        private Label lbusername;
        private MenuStrip menuStrip1;
     //   private ToolStripMenuItem Menu;
        private ToolStripMenuItem dfasfToolStripMenuItem;
        private ToolStripMenuItem ádfasdfToolStripMenuItem;
        private ToolStripMenuItem fINToolStripMenuItem;
        private ToolStripMenuItem báoCáoNhậpXuấtTồnToolStripMenuItem;
        private ToolStripMenuItem báoCáoGiaoHàngHàngTrênĐườngToolStripMenuItem;
        private WebBrowser webBrowser1;
        private Panel panelmain;
        private ToolStripMenuItem systemToolStripMenuItem;
        private ToolStripMenuItem configMasterToolStripMenuItem;
        private ToolStripMenuItem usersSetupToolStripMenuItem;
        private ToolStripMenuItem inputMinuteTransferPOSMTicketToMKTToolStripMenuItem;
        private ToolStripMenuItem listOfPOSMTicketToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem sôKhoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem sôKhoToolStripMenuItem1;
        private ToolStripMenuItem baoCaoNhâpXuâtTônKhoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem sôNhâtKyToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem baoCaoKQKDToolStripMenuItem;
        private ToolStripMenuItem baoCaoLưuChuyênTiênTêToolStripMenuItem;
        private ToolStripMenuItem banCânĐôiTaiKhoanPhatSinhToolStripMenuItem;
        private ToolStripMenuItem baoCaoTaiChinhToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem hêThôngTaiKhoanToolStripMenuItem;
    }
}


using BEEACCOUNT.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BEEACCOUNT.View
{
    public partial class BeeAccountsetup : Form
    {
        public BeeAccountsetup()
        {
            InitializeComponent();

             string connection_string = Utils.getConnectionstr();

             LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //var rs = from tbl_dstaikhoan in db.tbl_dstaikhoans
            //         orderby tbl_dstaikhoan.matk, tbl_dstaikhoan.matktren
            //         select tbl_dstaikhoan;
            var rs = Model.Taikhoanketoan.danhsachtaikhoan(db);
            grviewlisttk.DataSource = rs;



        
    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void KAmasterinput_Deactivate(object sender, EventArgs e)
        {

        }

   
        private void button6_Click(object sender, EventArgs e)
        {
            //Product prd = new Product();
            //DialogResult kq1 = MessageBox.Show("Xóa toàn bộ Product ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //bool kq;
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);




        }


 
  
 
 
 
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();

        

        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {

            this.pictureBox2.Image = global::BEEACCOUNT.Properties.Resources.exit_2;



        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.Image = global::BEEACCOUNT.Properties.Resources.exit;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            Model.Taikhoanketoan.themmoitaikhoan();

            var rs = Model.Taikhoanketoan.danhsachtaikhoan(dc);

                grviewlisttk.DataSource = rs;


            


        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            int idtk = 0;
            try
            {
                idtk = (int)this.grviewlisttk.Rows[this.grviewlisttk.CurrentCell.RowIndex].Cells["id"].Value;
            }
            catch (Exception)
            {

                MessageBox.Show("Bạn chọn một tài khoản bên bảng danh sách tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rs = (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                      where tbl_dstaikhoan.id == idtk
                      select tbl_dstaikhoan).FirstOrDefault();
            if (rs == null)
            {
                MessageBox.Show("Bạn chọn một tài khoản khác bên bảng danh sách tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (rs != null)
            {

                string taikhoan = rs.matk;
                View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(4, taikhoan); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa

                createacc.ShowDialog();


                var rs3 = Model.Taikhoanketoan.danhsachtaikhoan(dc);

                grviewlisttk.DataSource = rs3;



            }







        }

        private void button4_Click_2(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rs3 = Model.Taikhoanketoan.danhsachtaikhoan(dc);

            grviewlisttk.DataSource = rs3;



            this.Refresh();


        }

        private void grviewlisttk_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int idtk = 0;
            try
            {
                idtk = (int)this.grviewlisttk.Rows[this.grviewlisttk.CurrentCell.RowIndex].Cells["id"].Value;
            }
            catch (Exception)
            {

                MessageBox.Show("Bạn chọn một tài khoản bên bảng danh sách tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rs = (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                      where tbl_dstaikhoan.id == idtk
                      select tbl_dstaikhoan).FirstOrDefault();
            if (rs == null)
            {
                MessageBox.Show("Bạn chọn một tài khoản khác bên bảng danh sách tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (rs != null)
            {

                string taikhoan = rs.matk;

                ////View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(4, taikhoan); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa

                ////createacc.ShowDialog();

                Model.Taikhoanketoan.suataikhoan(taikhoan);

                var rs3 = Model.Taikhoanketoan.danhsachtaikhoan(dc);

                grviewlisttk.DataSource = rs3;

              



            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          //  Beemosochitiettaikhoan


        }

        private void grviewlisttk_Paint(object sender, PaintEventArgs e)
        {

            foreach (var c in grviewlisttk.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

        }

        private void grviewlisttk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

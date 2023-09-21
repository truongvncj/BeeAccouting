using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEEACCOUNT.Control;

namespace BEEACCOUNT.View
{


    public partial class fdanhsachphanxuongsx : Form
    {
        // public View.CreatenewContract contractnew;
        public int id { get; set; }
        public string maphanxuong { get; set; }
        public string tenphanxuong { get; set; }

     
        public string ghichu { get; set; }
        public bool chon { get; set; }


        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }


            public override string ToString()
            {
                return Text;
            }
        }


        public fdanhsachphanxuongsx(int loai, int idphanxuong) // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
        {
            InitializeComponent();

            chon = false;
            //    cbkhohang


         

            this.id = idphanxuong;

            if (loai == 4) // xóa + sua
            {
                this.btnew.Visible = false;
                //  this.txtmaNCC.Text = makhachhang;
                txtmaphanxuong.Text = idphanxuong.ToString();
                txtmaphanxuong.Enabled = false;






                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



                var item = (from p in dc.tbl_sx_dsphanxuongs
                            where p.id == idphanxuong
                            select p).FirstOrDefault();

                if (item != null)
                {
                   

                    txtmaphanxuong.Text = item.maphanxuong;
                    txttenphanxuong.Text = item.tenphanxuong;

               

                    txtghichu.Text = item.ghichu;
                  

                 
                  




                }


            }






            if (loai == 3) // tạo mới
            {
                this.btupdate.Visible = false;
                this.btxoa.Visible = false;





            }




        }

        private void txtCustcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txttenphanxuong.Focus();


            }



        }






        private void btxoa_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            var rs1 = (from p in dc.tbl_sx_dsphanxuongs
                       where p.id == this.id
                       select p).FirstOrDefault();

            if (rs1 != null)
            {

                dc.tbl_sx_dsphanxuongs.DeleteOnSubmit(rs1);
                dc.SubmitChanges();
                this.Close();


            }




        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            //




            this.maphanxuong = this.txtmaphanxuong.Text;
            this.tenphanxuong = this.txttenphanxuong.Text;


          

            


            this.ghichu = txtghichu.Text;


        



            if (maphanxuong == "")
            {
                MessageBox.Show("Bạn chưa có mã phân xưởng", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          

            if (maphanxuong != "")
            {
                chon = true;
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                //   tbl_dstaikhoan tk = new tbl_dstaikhoan();


                //    MeasureItemEventArgs.re
                var rs = (from p in db.tbl_sx_dsphanxuongs
                          where p.maphanxuong == maphanxuong
                          //  orderby tbl_dstaikhoan.matk
                          select p).FirstOrDefault();


                if (rs != null)
                {

                    rs.maphanxuong = this.maphanxuong;// = this.txtmaNCC.Text;
                    rs.tenphanxuong = this.tenphanxuong;// this.txttenNCC.Text;

              

                    rs.ghichu = this.ghichu;

                    db.SubmitChanges();
                    this.Close();
                }



            }









        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnew_Click(object sender, EventArgs e)
        {
            if (txtmaphanxuong.Text == "")
            {
                MessageBox.Show("Bạn kiểm tra mã phân xưởng", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          

       
            this.maphanxuong = this.txtmaphanxuong.Text;
            this.tenphanxuong = this.txttenphanxuong.Text;

            
            this.ghichu = txtghichu.Text;

        




            chon = true;
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            tbl_sx_dsphanxuong p = new tbl_sx_dsphanxuong();


            p.maphanxuong = this.maphanxuong;// = this.txtmaNCC.Text;
            p.tenphanxuong = this.tenphanxuong;// this.txttenNCC.Text;
          
       
            p.ghichu = this.ghichu;

            db.tbl_sx_dsphanxuongs.InsertOnSubmit(p);
            db.SubmitChanges();
            this.Close();






        }








        private void txtQuocgia_TextChanged(object sender, EventArgs e)
        {

        }








        private void txttennganhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmaphanxuong.Focus();


            }
        }

        private void txtmakho_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtghichu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmaphanxuong.Focus();


            }
        }

       
        private void txtkhoiluong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


             


            }

        }

        private void txtnhomsanpham_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txtghichu.Focus();


            }

        }

        private void txtghichu_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmaphanxuong.Focus();


            }

        }
    }


}

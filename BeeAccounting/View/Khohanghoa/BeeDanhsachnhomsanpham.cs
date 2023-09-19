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


    public partial class BeeDanhsachnhomsanpham : Form
    {
        // public View.CreatenewContract contractnew;
        public int id { get; set; }
        public string manhomsanpham { get; set; }
        public string tennhomsanpham { get; set; }
    
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


        public BeeDanhsachnhomsanpham(int loai, int idnhomsp) // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
        {
            InitializeComponent();

            chon = false;



            this.id = idnhomsp;

            if (loai == 4) // xóa + sua
            {
                this.btnew.Visible = false;
                //  this.txtmaNCC.Text = makhachhang;
                txtnhomsanpham.Text = idnhomsp.ToString();
                txtnhomsanpham.Enabled = false;


                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



                var item = (from p in dc.tbl_kho_nhomsanphams
                            where p.id == idnhomsp
                         select p).FirstOrDefault();

                if (item != null)
                {


                    txtnhomsanpham.Text = item.manhomsanpham;
                    txttennhoomsanpham.Text = item.tennhomsanpham;

                 
              


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


                txttennhoomsanpham.Focus();


            }



        }

        private void txt_vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txttennhoomsanpham.Focus();


            }

        }

    


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {





        }

        private void cbtkmother_KeyPress(object sender, KeyPressEventArgs e)
        {



            if (e.KeyChar == (char)Keys.Enter)
            {


                btnew.Focus();


            }



        }

        private void btxoa_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            var rs1 = (from p in dc.tbl_kho_nhomsanphams
                       where p.id == this.id
                       select p).FirstOrDefault();

            if (rs1 != null)
            {

                dc.tbl_kho_nhomsanphams.DeleteOnSubmit(rs1);
                dc.SubmitChanges();
                this.Close();


            }




        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            //




            this.manhomsanpham = this.txtnhomsanpham.Text;
            this.tennhomsanpham = this.txttennhoomsanpham.Text;

        //this.usertao = Utils.getusername();

            //this.ngaytao = DateTime.Today;


            if (manhomsanpham == "")
            {
                MessageBox.Show("Bạn chưa có mã nhà cung cấp", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (manhomsanpham != "")
            {
                chon = true;
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                //   tbl_dstaikhoan tk = new tbl_dstaikhoan();


                //    MeasureItemEventArgs.re
                var rs = (from p in db.tbl_kho_nhomsanphams
                          where p.manhomsanpham == manhomsanpham
                          //  orderby tbl_dstaikhoan.matk
                          select p).FirstOrDefault();


                if (rs != null)
                {

                    rs.manhomsanpham = this.manhomsanpham;// = this.txtmaNCC.Text;
                    rs.tennhomsanpham = this.tennhomsanpham;// this.txttenNCC.Text;
      

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


            this.manhomsanpham = this.txtnhomsanpham.Text;
            this.tennhomsanpham = this.txttennhoomsanpham.Text;

       
        

            if (manhomsanpham == "")
            {
                MessageBox.Show("Bạn chưa có mã nhóm sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            chon = true;
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            tbl_kho_nhomsanpham p = new tbl_kho_nhomsanpham();


            p.manhomsanpham = this.manhomsanpham;// = this.txtmaNCC.Text;
            p.tennhomsanpham = this.tennhomsanpham;// this.txttenNCC.Text;

        
      
         
            db.tbl_kho_nhomsanphams.InsertOnSubmit(p);
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


                txtnhomsanpham.Focus();


            }
        }

        private void txtmakho_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void txtghichu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtnhomsanpham.Focus();


            }
        }
    }


}

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


    public partial class fdanhsachnhamay : Form
    {
        // public View.CreatenewContract contractnew;
        public int id { get; set; }
        public string manhamay { get; set; }
        public string tennhamay { get; set; }

      
        public string diachi { get; set; }

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




        public fdanhsachnhamay(int loai, int idkho) // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
        {
            InitializeComponent();

            chon = false;

            //#region load cb pp tính giá


            //ComboboxItem cb1 = new ComboboxItem();
            //cb1.Value = "lifo";
            //cb1.Text = "Nhập trước xuất trước FIFO";
            //this.txtpptinhhangton.Items.Add(cb1);
            //ComboboxItem cb2 = new ComboboxItem();
            //cb2.Value = "dichdanh";
            //cb2.Text = "Phương pháp đích danh";
            //this.txtpptinhhangton.Items.Add(cb2);

            //ComboboxItem cb3 = new ComboboxItem();
            //cb3.Value = "bqky";
            //cb3.Text = "Bình quân gia quyền cả tháng";
            //this.txtpptinhhangton.Items.Add(cb3);

            //ComboboxItem cb4 = new ComboboxItem();
            //cb4.Value = "fifo";
            //cb4.Text = "Nhập sau xuất trước LIFO";
            //this.txtpptinhhangton.Items.Add(cb4);


            //ComboboxItem cb5 = new ComboboxItem();
            //cb5.Value = "bqlannhap";
            //cb5.Text = "Bình quân sau mỗi lần nhâp";
            //this.txtpptinhhangton.Items.Add(cb5);
            //#endregion load tk nợ



            this.id = idkho;

            if (loai == 4) // xóa + sua
            {
                this.btnew.Visible = false;
                //  this.txtmaNCC.Text = makhachhang;

                txtmanhamay.Enabled = false;


                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



                var item = (from p in dc.tbl_sx_dsnhamays
                            where p.id == idkho
                            select p).FirstOrDefault();

                if (item != null)
                {


                    txtmanhamay.Text = item.maNhamay;
                    txttennhamay.Text = item.tenNhamay;


                  

                    txtghichu.Text = item.ghichu;//  p.ghichunganhnghe  

                 


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


                txttennhamay.Focus();


            }



        }

        private void txt_vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txttennhamay.Focus();


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



            var rs1 = (from p in dc.tbl_sx_dsnhamays
                       where p.id == this.id
                       select p).FirstOrDefault();

            if (rs1 != null)
            {

                dc.tbl_sx_dsnhamays.DeleteOnSubmit(rs1);
                dc.SubmitChanges();
                this.Close();


            }




        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            //




            this.manhamay = this.txtmanhamay.Text;
            this.tennhamay = this.txttennhamay.Text;


          

            this.ghichu = this.txtghichu.Text;

         


            if (manhamay == "")
            {
                MessageBox.Show("Bạn chưa có mã kho", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (manhamay != "")
            {
                chon = true;
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                //   tbl_dstaikhoan tk = new tbl_dstaikhoan();


                //    MeasureItemEventArgs.re
                var rs = (from p in db.tbl_sx_dsnhamays
                          where p.maNhamay == manhamay
                          //  orderby tbl_dstaikhoan.matk
                          select p).FirstOrDefault();


                if (rs != null)
                {

                    rs.maNhamay = this.manhamay;// = this.txtmaNCC.Text;
                    rs.tenNhamay = this.tennhamay;// this.txttenNCC.Text;
                
                 

                    rs.ghichu = this.ghichu;// this.txtNganhnghe.Text;


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


            this.manhamay = this.txtmanhamay.Text;
            this.tennhamay = this.txttennhamay.Text;

            this.ghichu = this.txtghichu.Text;


            if (manhamay == "")
            {
                MessageBox.Show("Bạn chưa có mã nhà cung cấp", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           



            chon = true;
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            tbl_sx_dsnhamay p = new tbl_sx_dsnhamay();


            p.maNhamay = this.manhamay;// = this.txtmaNCC.Text;
            p.tenNhamay = this.tennhamay;// this.txttenNCC.Text;
        

          
            p.ghichu = this.ghichu;// this.txtNganhnghe.Text;


            db.tbl_sx_dsnhamays.InsertOnSubmit(p);
            db.SubmitChanges();
            this.Close();






        }








        private void txtQuocgia_TextChanged(object sender, EventArgs e)
        {

        }





        private void txtNguoidaidien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtghichu.Focus();


            }
        }



        private void txttennganhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmanhamay.Focus();


            }
        }

        private void txtmakho_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void txtdiachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtghichu.Focus();


            }
        }

        private void txtghichu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmanhamay.Focus();


            }
        }

      
    }


}

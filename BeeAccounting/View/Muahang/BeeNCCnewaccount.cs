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


    public partial class BeeNCCnewaccount : Form
    {
        // public View.CreatenewContract contractnew;
        public int idNCC { get; set; }
        public string maNcc { get; set; }
        public string tenNcc { get; set; }
        public string sonha { get; set; }
        public string duongpho { get; set; }
        public string huyenquan { get; set; }
        public string thanhpho { get; set; }
        public string dienthoai { get; set; }
        public string masothue { get; set; }
        public string sotaikhoannganhang { get; set; }
        public string tennganhang { get; set; }
        public string ghichunganhnghe { get; set; }
        public string nguoidaidien { get; set; }
        public string quocgia { get; set; }
        public string usertao { get; set; }

        public DateTime ngaytao { get; set; }

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


        public BeeNCCnewaccount(int loai, int idNCC) // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
        {
            InitializeComponent();

            chon = false;



            this.idNCC = idNCC;

            if (loai == 4) // xóa + sua
            {
                this.btnew.Visible = false;
                //  this.txtmaNCC.Text = makhachhang;
                txtmaNCC.Enabled = false;


                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



                var l = (from p in dc.tbl_danhsachnhacungcaps
                         where p.id == idNCC
                         select p).FirstOrDefault();

                if (l != null)
                {


                    txtmaNCC.Text = l.maNcc;
                    txttenNCC.Text = l.tenNcc;

                    txtSonha.Text = l.sonha;
                    txtDuongpho.Text = l.duongpho;// duongpho  
                    txtQuanhuyen.Text = l.huyenquan;//  .huyenquan  
                    txtThanhpho.Text = l.thanhpho;//    p.thanhpho  
                    txtDienthoai.Text = l.dienthoai;//   p.dienthoai  
                    txtMasothue.Text = l.masothue;//  p.masothue  
                    txtsotaikhoannganhang.Text = l.sotaikhoannganhang;//  p.sotaikhoannganhang  
                    txttennganhang.Text = l.tennganhang;//  p.tennganhang  
                    txtNganhnghe.Text = l.ghichunganhnghe;//  p.ghichunganhnghe  
                    txtNguoidaidien.Text = l.nguoidaidien;//  p.nguoidaidien  
                    txtQuocgia.Text = l.quocgia;//  p.quocgia  


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


                txttenNCC.Focus();


            }



        }

        private void txt_vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txttenNCC.Focus();


            }

        }

        private void txt_represennt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtSonha.Focus();


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



            var rs1 = (from p in dc.tbl_danhsachnhacungcaps
                       where p.id == this.idNCC
                       select p).FirstOrDefault();

            if (rs1 != null)
            {

                dc.tbl_danhsachnhacungcaps.DeleteOnSubmit(rs1);
                dc.SubmitChanges();
                this.Close();


            }




        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            //




            this.maNcc = this.txtmaNCC.Text;
            this.tenNcc = this.txttenNCC.Text;

            this.sonha = this.txtSonha.Text;
            this.duongpho = this.txtDuongpho.Text;
            this.huyenquan = this.txtQuanhuyen.Text;
            this.thanhpho = this.txtThanhpho.Text;
            this.dienthoai = this.txtDienthoai.Text;
            this.masothue = this.txtMasothue.Text;
            this.sotaikhoannganhang = this.txtsotaikhoannganhang.Text;
            this.tennganhang = this.txttennganhang.Text;
            this.ghichunganhnghe = this.txtNganhnghe.Text;
            this.nguoidaidien = this.txtNguoidaidien.Text;

            this.quocgia = this.txtQuocgia.Text;
            this.usertao = Utils.getusername();

            this.ngaytao = DateTime.Today;


            if (maNcc == "")
            {
                MessageBox.Show("Bạn chưa có mã nhà cung cấp", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (maNcc != "")
            {
                chon = true;
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                //   tbl_dstaikhoan tk = new tbl_dstaikhoan();


                //    MeasureItemEventArgs.re
                var rs = (from p in db.tbl_danhsachnhacungcaps
                          where p.maNcc == maNcc
                          //  orderby tbl_dstaikhoan.matk
                          select p).FirstOrDefault();


                if (rs != null)
                {

                    rs.maNcc = this.maNcc;// = this.txtmaNCC.Text;
                    rs.tenNcc = this.tenNcc;// this.txttenNCC.Text;

                    rs.sonha = this.sonha;// this.txtSonha.Text;
                    rs.duongpho = this.duongpho;// this.txtDuongpho.Text;
                    rs.huyenquan = this.huyenquan;// this.txtQuanhuyen.Text;
                    rs.thanhpho = this.thanhpho;// this.txtThanhpho.Text;
                    rs.dienthoai = this.dienthoai;// this.txtDienthoai.Text;
                    rs.masothue = this.masothue;// this.txtMasothue.Text;
                    rs.sotaikhoannganhang = this.sotaikhoannganhang;// this.txtsotaikhoannganhang.Text;
                    rs.tennganhang = this.tennganhang;// this.txttennganhang.Text;
                    rs.ghichunganhnghe = this.ghichunganhnghe;// this.txtNganhnghe.Text;
                    rs.nguoidaidien = this.nguoidaidien;// this.txtNguoidaidien.Text;

                    rs.quocgia = this.quocgia;// this.txtQuocgia.Text;
                    rs.usertao = this.usertao;// Utils.getusername();

                    rs.ngaytao = this.ngaytao;// DateTime.Today;


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


            this.maNcc = this.txtmaNCC.Text;
            this.tenNcc = this.txttenNCC.Text;

            this.sonha = this.txtSonha.Text;
            this.duongpho = this.txtDuongpho.Text;
            this.huyenquan = this.txtQuanhuyen.Text;
            this.thanhpho = this.txtThanhpho.Text;
            this.dienthoai = this.txtDienthoai.Text;
            this.masothue = this.txtMasothue.Text;
            this.sotaikhoannganhang = this.txtsotaikhoannganhang.Text;
            this.tennganhang = this.txttennganhang.Text;
            this.ghichunganhnghe = this.txtNganhnghe.Text;
            this.nguoidaidien = this.txtNguoidaidien.Text;

            this.quocgia = this.txtQuocgia.Text;
            this.usertao = Utils.getusername();

            this.ngaytao = DateTime.Today;


            if (maNcc == "")
            {
                MessageBox.Show("Bạn chưa có mã nhà cung cấp", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            chon = true;
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            tbl_danhsachnhacungcap p = new tbl_danhsachnhacungcap();


            p.maNcc = this.maNcc;// = this.txtmaNCC.Text;
            p.tenNcc = this.tenNcc;// this.txttenNCC.Text;

            p.sonha = this.sonha;// this.txtSonha.Text;
            p.duongpho = this.duongpho;// this.txtDuongpho.Text;
            p.huyenquan = this.huyenquan;// this.txtQuanhuyen.Text;
            p.thanhpho = this.thanhpho;// this.txtThanhpho.Text;
            p.dienthoai = this.dienthoai;// this.txtDienthoai.Text;
            p.masothue = this.masothue;// this.txtMasothue.Text;
            p.sotaikhoannganhang = this.sotaikhoannganhang;// this.txtsotaikhoannganhang.Text;
            p.tennganhang = this.tennganhang;// this.txttennganhang.Text;
            p.ghichunganhnghe = this.ghichunganhnghe;// this.txtNganhnghe.Text;
            p.nguoidaidien = this.nguoidaidien;// this.txtNguoidaidien.Text;

            p.quocgia = this.quocgia;// this.txtQuocgia.Text;
            p.usertao = this.usertao;// Utils.getusername();

            p.ngaytao = this.ngaytao;// DateTime.Today;

            db.tbl_danhsachnhacungcaps.InsertOnSubmit(p);
            db.SubmitChanges();
            this.Close();






        }

        private void txtSonha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtDuongpho.Focus();


            }
        }

        private void txtDuongpho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtQuanhuyen.Focus();


            }
        }

        private void txtQuanhuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtThanhpho.Focus();


            }
        }

        private void txtThanhpho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtQuocgia.Focus();


            }
        }

        private void txtQuocgia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuocgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtDienthoai.Focus();


            }
        }

        private void txtDienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtMasothue.Focus();


            }
        }

        private void txtMasothue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtNguoidaidien.Focus();


            }
        }

        private void txtNguoidaidien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtNganhnghe.Focus();


            }
        }

        private void txtNganhnghe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtsotaikhoannganhang.Focus();


            }
        }

        private void txtsotaikhoannganhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txttennganhang.Focus();


            }
        }

        private void txttennganhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmaNCC.Focus();


            }
        }
    }


}

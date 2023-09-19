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


    public partial class BeeDanhsachsanpham : Form
    {
        // public View.CreatenewContract contractnew;
        public int id { get; set; }
        public string masanpham { get; set; }
        public string tensanpham { get; set; }

        public string makho { get; set; }
        public string tenkho { get; set; }

        public string mavach { get; set; }
        public string donvi { get; set; }


        public float trongluong { get; set; }
        public float khoiluong { get; set; }
        public float daukhysoluong { get; set; }
        public float daukythanhtien { get; set; }

        public string idnhomsanpham { get; set; }
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


        public BeeDanhsachsanpham(int loai, int idsanpham) // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
        {
            InitializeComponent();

            chon = false;
            //    cbkhohang


            #region load nhóm kho

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var listkho = from p in dc.tbl_khohangs
                              //   where tk.loaitkid == 5 || tk.loaitkid == 9 || tk.loaitkid == 7  // 5.nguon von;  7 phai tra; 9. tam ung
                          select p;

            //      string drowdownshow = "";

            foreach (var item in listkho)
            {
                ComboboxItem cbkho = new ComboboxItem();
                cbkho.Value = item.makho;
                cbkho.Text = item.tenkho;
                this.cbkhohang.Items.Add(cbkho); // CombomCollection.Add(cb);

            }

            #endregion load tk kho

            #region load nhóm sản phẩm

            //      string connection_string = Utils.getConnectionstr();
            //  LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = from p in dc.tbl_kho_nhomsanphams
                          //   where tk.loaitkid == 5 || tk.loaitkid == 9 || tk.loaitkid == 7  // 5.nguon von;  7 phai tra; 9. tam ung
                      select p;

            //      string drowdownshow = "";

            foreach (var item in rs1)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.manhomsanpham;
                cb.Text = item.tennhomsanpham;
                this.txtnhomsanpham.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk nợ


            this.id = idsanpham;

            if (loai == 4) // xóa + sua
            {
                this.btnew.Visible = false;
                //  this.txtmaNCC.Text = makhachhang;
                txtmasanpham.Text = idsanpham.ToString();
                txtmasanpham.Enabled = false;






                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



                var item = (from p in dc.tbl_kho_sanphams
                            where p.id == idsanpham
                            select p).FirstOrDefault();

                if (item != null)
                {
                    txttondaukysoluong.Text = item.tondksoluong.ToString();
                    txtthanhtienton.Text = item.tondkthanhtien.ToString();

                    txtmasanpham.Text = item.masp;
                    txttensanpham.Text = item.tensp;

                    txtdonvi.Text = item.donvi;
                    txttrongluong.Text = item.trongluong.ToString();
                    txtmavach.Text = item.mavach;

                    txtghichu.Text = item.ghichu;
                    txtkhoiluong.Text = item.khoiluong.ToString();

                    foreach (var sp in txtnhomsanpham.Items)
                    {

                        if ((string)(sp as ComboboxItem).Value == item.idmanhomsp)
                        {
                            //      loaitk = (int)(cbloaitk.SelectedItem as ComboboxItem).Value;
                            //     cmbEmployeeStatus.SelectedValue = cmbEmployeeStatus.Items.FindByText("text").Value;

                            txtnhomsanpham.SelectedItem = sp;
                            //      cbtkmother.(iten);

                        }



                    }

                    foreach (var kho in cbkhohang.Items)
                    {

                        if ((string)(kho as ComboboxItem).Value == item.makho)
                        {
                            //      loaitk = (int)(cbloaitk.SelectedItem as ComboboxItem).Value;
                            //     cmbEmployeeStatus.SelectedValue = cmbEmployeeStatus.Items.FindByText("text").Value;

                            cbkhohang.SelectedItem = kho;
                            //      cbtkmother.(iten);

                        }



                    }






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


                txttensanpham.Focus();


            }



        }






        private void btxoa_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            var rs1 = (from p in dc.tbl_kho_sanphams
                       where p.id == this.id
                       select p).FirstOrDefault();

            if (rs1 != null)
            {

                dc.tbl_kho_sanphams.DeleteOnSubmit(rs1);
                dc.SubmitChanges();
                this.Close();


            }




        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            //




            this.masanpham = this.txtmasanpham.Text;
            this.tensanpham = this.txttensanpham.Text;


            this.mavach = txtmavach.Text;
            this.donvi = txtdonvi.Text;

            if (Utils.IsValidnumber(txttrongluong.Text))
            {
                this.trongluong = float.Parse(txttrongluong.Text);
            }


            if (Utils.IsValidnumber(txtkhoiluong.Text))
            {
                this.khoiluong = float.Parse(txtkhoiluong.Text);

            }

            if (txtnhomsanpham.SelectedItem  != null)
            {
                this.idnhomsanpham = (string)(txtnhomsanpham.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            }
            else
            {
                MessageBox.Show("Kiểm tra nhóm sản phẩm !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            this.ghichu = txtghichu.Text;

            if (cbkhohang.SelectedItem != null)
            {
                this.makho = (string)(cbkhohang.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            }
            else
            {
                MessageBox.Show("Kiểm tra kho hàng!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            this.tenkho = (string)(cbkhohang.SelectedItem as ComboboxItem).Text;



            if (Utils.IsValidnumber(txttondaukysoluong.Text))
            {
                this.daukhysoluong = float.Parse(txttondaukysoluong.Text);
            }
            else
            {
                MessageBox.Show("Số lượng tôn đàu kỳ phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Utils.IsValidnumber(txtthanhtienton.Text))
            {
                this.daukythanhtien = float.Parse(txtthanhtienton.Text);
            }
            else
            {
                MessageBox.Show("Thành tiền tôn đàu kỳ phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (masanpham == "")
            {
                MessageBox.Show("Bạn chưa có mã sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (masanpham != "")
            {
                chon = true;
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                //   tbl_dstaikhoan tk = new tbl_dstaikhoan();


                //    MeasureItemEventArgs.re
                var rs = (from p in db.tbl_kho_sanphams
                          where p.masp == masanpham
                          //  orderby tbl_dstaikhoan.matk
                          select p).FirstOrDefault();


                if (rs != null)
                {

                    rs.masp = this.masanpham;// = this.txtmaNCC.Text;
                    rs.tensp = this.tensanpham;// this.txttenNCC.Text;

                    rs.idmanhomsp = this.idnhomsanpham;

                    rs.mavach = this.mavach;
                    rs.donvi = this.donvi;
                    rs.makho = this.makho;
                    rs.tenkho = this.tenkho;
                    rs.tondksoluong = this.daukhysoluong;
                    rs.tondkthanhtien = this.daukythanhtien;

                    rs.khoiluong = this.khoiluong;


                    rs.trongluong = this.trongluong;


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
            if (txtmasanpham.Text == "")
            {
                MessageBox.Show("Bạn kiểm tra mã sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.mavach = txtmavach.Text;
            this.masanpham = this.txtmasanpham.Text;
            this.tensanpham = this.txttensanpham.Text;
            this.donvi = txtdonvi.Text;
            this.masanpham = txtmavach.Text;
            this.ghichu = txtghichu.Text;

            if (Utils.IsValidnumber(txttrongluong.Text))
            {
                this.trongluong = float.Parse(txttrongluong.Text);
            }
            else
            {
                MessageBox.Show("Bạn kiểm tra trọng lượng sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Utils.IsValidnumber(txtkhoiluong.Text))
            {
                this.khoiluong = float.Parse(txtkhoiluong.Text);
            }
            else
            {
                MessageBox.Show("Bạn kiểm tra khối lượng sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtnhomsanpham.SelectedIndex >= 0)
            {
                this.idnhomsanpham = (string)(txtnhomsanpham.SelectedItem as ComboboxItem).Value;

            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhóm của sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.makho = (string)(cbkhohang.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            this.tenkho = (string)(cbkhohang.SelectedItem as ComboboxItem).Text;



            if (Utils.IsValidnumber(txttondaukysoluong.Text))
            {
                this.daukhysoluong = float.Parse(txttondaukysoluong.Text);
            }
            else
            {
                MessageBox.Show("Số lượng tôn đàu kỳ phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Utils.IsValidnumber(txtthanhtienton.Text))
            {
                this.daukythanhtien = float.Parse(txtthanhtienton.Text);
            }
            else
            {
                MessageBox.Show("Thành tiền tôn đàu kỳ phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            chon = true;
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            tbl_kho_sanpham p = new tbl_kho_sanpham();


            p.masp = this.masanpham;// = this.txtmaNCC.Text;
            p.tensp = this.tensanpham;// this.txttenNCC.Text;
            p.khoiluong = this.khoiluong;
            p.trongluong = this.trongluong;
            p.idmanhomsp = this.idnhomsanpham;
            p.ghichu = this.ghichu;
            p.mavach = this.mavach;
            p.donvi = this.donvi;
            p.makho = this.makho;
            p.tenkho = this.tenkho;
            p.tondksoluong = this.daukhysoluong;
            p.tondkthanhtien = this.daukythanhtien;






            db.tbl_kho_sanphams.InsertOnSubmit(p);
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


                txtmasanpham.Focus();


            }
        }

        private void txtmakho_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtghichu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmasanpham.Focus();


            }
        }

        private void txttensanpham_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmavach.Focus();


            }

        }

        private void txtmavach_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txtdonvi.Focus();


            }

        }

        private void txtdonvi_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txttrongluong.Focus();


            }

        }

        private void txttrongluong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txtkhoiluong.Focus();


            }

        }

        private void txtkhoiluong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txtnhomsanpham.Focus();


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


                txtmasanpham.Focus();


            }

        }
    }


}

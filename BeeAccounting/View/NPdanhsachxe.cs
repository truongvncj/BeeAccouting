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


    public partial class NPdanhsachxe : Form
    {
        // public View.CreatenewContract contractnew;
        public int id { get; set; }
        public string _manhavantai { get; set; }
        public string _tenhavantai { get; set; }
        public string _biensoxe { get; set; }


        public float _taitrong { get; set; }
        public float _khoiluong { get; set; }

        public string _hotenlaixe { get; set; }
        public string _sodienthoai { get; set; }
        public string _asochungminhthu { get; set; }
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


        public NPdanhsachxe(int loainghiepvu, int id) // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
        {
            InitializeComponent();

            chon = false;
            //    cbkhohang


            #region load ma nha van tai

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var dsnhaxe = from p in dc.tbl_NP_Nhacungungvantais
                          orderby p.maNVT
                          //   where tk.loaitkid == 5 || tk.loaitkid == 9 || tk.loaitkid == 7  // 5.nguon von;  7 phai tra; 9. tam ung
                          select p;

            //      string drowdownshow = "";

            foreach (var item in dsnhaxe)
            {
                ComboboxItem cbkho = new ComboboxItem();
                cbkho.Value = item.maNVT;
                cbkho.Text = item.maNVT + " : " + item.tenNVT;
                this.cbnhavantai.Items.Add(cbkho); // CombomCollection.Add(cb);

            }

            #endregion load tk kho



            this.id = id;

            if (loainghiepvu == 4) // xóa + sua
            {
                this.btnew.Visible = false;
           
                var item = (from p in dc.tbl_NP_danhsachxes
                            where p.id == id
                            select p).FirstOrDefault();

                if (item != null)
                {
                    if (item.tenlaixe != null)
                    {
                        txttenlaixe.Text = item.tenlaixe.ToString();
                    }

                    if (item.dienthoailaixe != null)
                    {
                        txtdienthoailaixe.Text = item.dienthoailaixe.ToString();

                    }

                    if (item.cmtlaixe != null)
                    {
                        txtcmtlaixe.Text = item.cmtlaixe.ToString();
                    }

                    if (item.sotantai != null)
                    {
                        txttaitrong.Text = item.sotantai.ToString();
                    }



                    txtbienso.Text = item.bienso.ToString();
                    txtkhoiluong.Text = item.sokhoithungxe.ToString();



                    foreach (var nhavantai in cbnhavantai.Items)
                    {

                        if ((string)(nhavantai as ComboboxItem).Value == item.maNVT)
                        {
                            //      loaitk = (int)(cbloaitk.SelectedItem as ComboboxItem).Value;
                            //     cmbEmployeeStatus.SelectedValue = cmbEmployeeStatus.Items.FindByText("text").Value;

                            cbnhavantai.SelectedItem = nhavantai;
                            //      cbtkmother.(iten);

                        }



                    }






                }


            }






            if (loainghiepvu == 3) // tạo mới
            {
                this.btupdate.Visible = false;
                this.btxoa.Visible = false;





            }




        }

        private void txtCustcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //   txttensanpham.Focus();


            }



        }






        private void btxoa_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            var rs1 = (from p in dc.tbl_NP_danhsachxes
                       where p.id == this.id
                       select p).FirstOrDefault();

            if (rs1 != null)
            {

                dc.tbl_NP_danhsachxes.DeleteOnSubmit(rs1);
                dc.SubmitChanges();
                this.Close();


            }




        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            this._hotenlaixe = txttenlaixe.Text;
            this._sodienthoai = txtdienthoailaixe.Text;


            this._asochungminhthu = txtcmtlaixe.Text;
            //if (Utils.IsValidnumber(txtkhoiluong.Text))
            //{
            //    this._khoiluong = float.Parse(txtkhoiluong.Text);

            //}




            this._sodienthoai = txtdienthoailaixe.Text;

            if (cbnhavantai.SelectedItem != null)
            {
                this._manhavantai = (string)(cbnhavantai.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            }
            else
            {
                MessageBox.Show("Kiểm tra kho hàng!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            this._tenhavantai = (string)(cbnhavantai.SelectedItem as ComboboxItem).Text;



            if (Utils.IsValidnumber(txtkhoiluong.Text))
            {
                this._khoiluong = float.Parse(txtkhoiluong.Text.ToString());
            }
            else
            {
                MessageBox.Show("Số khối thùng phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Utils.IsValidnumber(txttaitrong.Text))
            {
                this._taitrong = float.Parse(txttaitrong.Text.ToString());
            }
            else
            {
                MessageBox.Show("Tải trọng phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (_manhavantai == "")
            {
                MessageBox.Show("Bạn phải chọn mã nhà vận tải ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_biensoxe == "")
            {
                MessageBox.Show("Biển số xe !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this._biensoxe = txtbienso.Text;
            }




            if (_biensoxe != "" && _biensoxe != null)
            {
                chon = true;
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                //   tbl_dstaikhoan tk = new tbl_dstaikhoan();


                //    MeasureItemEventArgs.re
                var rs = (from p in db.tbl_NP_danhsachxes
                          where p.bienso.Trim() == _biensoxe.Trim()
                          //  orderby tbl_dstaikhoan.matk
                          select p).FirstOrDefault();


                if (rs != null)
                {



                    rs.cmtlaixe = this._asochungminhthu;

                    rs.sotantai = this._taitrong;
                    rs.dienthoailaixe = this._sodienthoai;
                    rs.maNVT = this._manhavantai;
                    rs.sokhoithungxe = this._khoiluong;

                    rs.tenlaixe = this._hotenlaixe;


                    rs.bienso = this._biensoxe;


                    rs.cmtlaixe = this._asochungminhthu;

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
            if (_manhavantai == "")
            {
                MessageBox.Show("Bạn kiểm tra mã sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this._asochungminhthu = txtcmtlaixe.Text;

            //     this._taitrong = float.Parse(txttaitrong.Text.ToString());
            this._sodienthoai = txtdienthoailaixe.Text;
            // this._manhavantai = (string)(cbnhavantai.SelectedItem as ComboboxItem).Value;
            //   this._khoiluong = float.Parse(txtkhoiluong.Text.ToString()); ;

            this._hotenlaixe = txttenlaixe.Text;



            this._biensoxe = txtbienso.Text;




            this._biensoxe = txtbienso.Text;

            if (Utils.IsValidnumber(txttaitrong.Text))
            {
                this._taitrong = float.Parse(txttaitrong.Text);
            }
            else
            {
                MessageBox.Show("Bạn kiểm tra trọng lượng sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Utils.IsValidnumber(txtkhoiluong.Text))
            {
                this._khoiluong = float.Parse(txtkhoiluong.Text);
            }
            else
            {
                MessageBox.Show("Bạn kiểm tra khối lượng sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            this._manhavantai = (string)(cbnhavantai.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            this._tenhavantai = (string)(cbnhavantai.SelectedItem as ComboboxItem).Text;




            chon = true;
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            tbl_NP_danhsachxe p = new tbl_NP_danhsachxe();


            p.maNVT = this._manhavantai;// = this.txtmaNCC.Text;
            p.bienso = this._biensoxe;// this.txttenNCC.Text;
            p.sokhoithungxe = this._khoiluong;
            p.sotantai = this._taitrong;
            p.tenlaixe = this._hotenlaixe;
            p.dienthoailaixe = this._sodienthoai;

            p.cmtlaixe = this._asochungminhthu;



            db.tbl_NP_danhsachxes.InsertOnSubmit(p);
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


                //     txtmasanpham.Focus();


            }
        }

        private void txtmakho_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtghichu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //     txtmasanpham.Focus();


            }
        }

        private void txttensanpham_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                //     txtmavach.Focus();


            }

        }

        private void txtmavach_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                //   txtdonvi.Focus();


            }

        }

        private void txtdonvi_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txttaitrong.Focus();


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


                // txtnhomsanpham.Focus();


            }

        }

        private void txtnhomsanpham_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txtbienso.Focus();


            }

        }

        private void txtghichu_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                //     txtmasanpham.Focus();


            }

        }
    }


}

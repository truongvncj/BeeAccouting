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


    public partial class NPgiavantaitheotuyen : Form
    {
        // public View.CreatenewContract contractnew;
        public string makh { get; set; } // item.matuyen;
        public string tentuyen { get; set; } // item.tentuyen;
        public string matuyen { get; set; } // item.matuyen;
        public float trichdoitac { get; set; }


        public float trichcongty { get; set; }

        public float tongchiphi { get; set; } // item.tongcfuoctinh.ToString();

        public float loinhuantuyen { get; set; } // item.lntuyen.ToString();
        public float loaidon { get; set; } // item.loaidonxe.ToString();
        public float km { get; set; } // item.km.ToString();
        public float khauhao { get; set; } // item.cfkhauhao.ToString();
        public float giathue { get; set; } // item.giathue.ToString();
        public float giahoadon { get; set; } // item.giahoadon.ToString();
        public float giadauhientai { get; set; } // item.giadau.ToString();
        public string ghichu { get; set; } // item.ghichucf;
        public float dtkhac { get; set; } // item.ghepdiem.ToString();
        public float dinhmucdau { get; set; } // item.dinhmucdau.ToString();
        public float chiphilaixe { get; set; } // item.cflaixe.ToString();
        public float chiphidau { get; set; } // item.cfxang.ToString();
        public float chiphicongan { get; set; } // item.cfcongan.ToString();
        public float bocxep { get; set; } // item.bocxep.ToString();
        public float chiphicauduong { get; set; } // item.cfcauduong.ToString();

        public bool chon { get; set; }
        public int id { get; set; }



        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }


            public override string ToString()
            {
                return Text;
            }
        }


        public NPgiavantaitheotuyen(int lainghiepvu, int id) // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
        {
            InitializeComponent();

            chon = false;



            this.id = id;


            #region load ma khách hàng vận tải

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var dskhach = from p in dc.tbl_NP_khachhangvanchuyens
                          orderby p.maKH
                          //   where tk.loaitkid == 5 || tk.loaitkid == 9 || tk.loaitkid == 7  // 5.nguon von;  7 phai tra; 9. tam ung
                          select p;

            //      string drowdownshow = "";

            foreach (var item in dskhach)
            {
                ComboboxItem cbkhachhang = new ComboboxItem();
                cbkhachhang.Value = item.maKH;
                cbkhachhang.Text = item.maKH + " : " + item.tenKH;
                this.cbkhachhang.Items.Add(cbkhachhang); // CombomCollection.Add(cb);

            }

            #endregion load tk kho


            if (lainghiepvu == 4) // xóa + sua
            {
                this.btnew.Visible = false;

                var item = (from p in dc.tbl_NP_giavantaitheotuyens
                            where p.id == id
                            select p).FirstOrDefault();

                if (item != null)
                {


                    foreach (var makhachhang in cbkhachhang.Items)
                    {

                        if ((string)(makhachhang as ComboboxItem).Value == item.maKH)
                        {

                            cbkhachhang.SelectedItem = makhachhang;

                        }



                    }





                    txttrichdoitac.Text = item.trichdoitac.ToString();

                    txttrichcongty.Text = item.trichcongty.ToString();
                    txttongchiphi.Text = item.tongcfuoctinh.ToString();
                    txttentuyen.Text = item.tentuyen;
                    txtmatuyen.Text = item.matuyen;
                    txtloinhuantuyen.Text = item.lntuyen.ToString();
                    txtloaidon.Text = item.loaidonxe.ToString();
                    txtkm.Text = item.km.ToString();
                    txtkhauhao.Text = item.cfkhauhao.ToString();
                    txtgiathue.Text = item.giathue.ToString();
                    txtgiahoadon.Text = item.giahoadon.ToString();
                    txtgiadauhientai.Text = item.giadau.ToString();
                    txtghichu.Text = item.ghichucf;
                    txtphiphac.Text = item.dtkhac.ToString();
                    txtdinhmucdau.Text = item.dinhmucdau.ToString();
                    txtchiphilaixe.Text = item.cflaixe.ToString();
                    txtchiphidau.Text = item.cfxang.ToString();
                    txtchiphicongan.Text = item.cfcongan.ToString();
                    txtbocxep.Text = item.bocxep.ToString();
                    txtchiphicauduong.Text = item.cfcauduong.ToString();




                }


            }






            if (lainghiepvu == 3) // tạo mới
            {
                this.btupdate.Visible = false;
                this.btxoa.Visible = false;





            }




        }

        private void txtCustcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmatuyen.Focus();


            }



        }

        private void txt_vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmatuyen.Focus();


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



            var rs1 = (from p in dc.tbl_NP_giavantaitheotuyens
                       where p.id == this.id
                       select p).FirstOrDefault();

            if (rs1 != null)
            {

                dc.tbl_NP_giavantaitheotuyens.DeleteOnSubmit(rs1);
                dc.SubmitChanges();
                this.Close();


            }




        }

        private void btupdate_Click(object sender, EventArgs e)
        {


            #region chekc detail

            if (cbkhachhang.SelectedIndex < 0)
            {
                MessageBox.Show("Kiểm tra lại mã khác hàng !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbkhachhang.Focus();
                return;
            }
            if (txttrichdoitac.Text == "" || Utils.IsValidnumber(txttrichdoitac.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại trích đối tác !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttrichdoitac.Focus();
                return;
            }

            if (txttrichcongty.Text == "" || Utils.IsValidnumber(txttrichcongty.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại trích công ty!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttrichcongty.Focus();
                return;
            }

            if (txttongchiphi.Text == "" || Utils.IsValidnumber(txttongchiphi.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại tổng chi phí !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttongchiphi.Focus();
                return;
            }

            if (txttentuyen.Text == "" || txttentuyen.Text == null)
            {
                MessageBox.Show("Kiểm tra lại tên tuyến !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentuyen.Focus();
                return;
            }

            if (txtmatuyen.Text == "" || txtmatuyen.Text == null)
            {
                MessageBox.Show("Kiểm tra lại mã tuyến !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmatuyen.Focus();
                return;
            }

            if (txtloinhuantuyen.Text == "" || Utils.IsValidnumber(txtloinhuantuyen.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại lợi nhận tuyến !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtloinhuantuyen.Focus();
                return;
            }

            if (txtloaidon.Text == "" || Utils.IsValidnumber(txtloaidon.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại loại đơn !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtloaidon.Focus();
                return;
            }
            if (txtkm.Text == "" || Utils.IsValidnumber(txtkm.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại KM!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtkm.Focus();
                return;
            }
            if (txtkhauhao.Text == "" || Utils.IsValidnumber(txtkhauhao.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại khấu hao ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtkhauhao.Focus();
                return;
            }
            if (txtgiathue.Text == "" || Utils.IsValidnumber(txtgiathue.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại giá thuê ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgiathue.Focus();
                return;
            }
            if (txtgiahoadon.Text == "" || Utils.IsValidnumber(txtgiahoadon.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại giá hóa đơn ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgiahoadon.Focus();
                return;
            }

            if (txtgiadauhientai.Text == "" || Utils.IsValidnumber(txtgiadauhientai.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại giá dầu hiện tại ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgiadauhientai.Focus();
                return;
            }


            if (txtghichu.Text == "" || txtghichu.Text == null)
            {
                MessageBox.Show("Kiểm tra lại ghi chú ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtghichu.Focus();
                return;
            }

            if (txtphiphac.Text == "" || Utils.IsValidnumber(txtphiphac.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại tiền phí khác ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtphiphac.Focus();
                return;
            }


            if (txtdinhmucdau.Text == "" || Utils.IsValidnumber(txtdinhmucdau.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại định mức dầu ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdinhmucdau.Focus();
                return;
            }

            if (txtchiphilaixe.Text == "" || Utils.IsValidnumber(txtchiphilaixe.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại chi phí lái xe ước tính ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtchiphilaixe.Focus();
                return;
            }

            if (txtchiphidau.Text == "" || Utils.IsValidnumber(txtchiphidau.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại chi phí dầu ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtchiphidau.Focus();
                return;
            }

            if (txtchiphicongan.Text == "" || Utils.IsValidnumber(txtchiphicongan.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại chi phí công an ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtchiphicongan.Focus();
                return;
            }

            if (txtbocxep.Text == "" || Utils.IsValidnumber(txtbocxep.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại chi phí bốc xếp ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbocxep.Focus();
                return;
            }

            if (txtchiphicauduong.Text == "" || Utils.IsValidnumber(txtchiphicauduong.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại chi phí cầu đường  ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtchiphicauduong.Focus();
                return;
            }
            #endregion


            this.trichdoitac = float.Parse(txttrichdoitac.Text);

            this.trichcongty = float.Parse(txttrichcongty.Text);
            this.tongchiphi = float.Parse(txttongchiphi.Text);
            this.tentuyen = txttentuyen.Text;
            this.matuyen = txtmatuyen.Text;
            this.loinhuantuyen = float.Parse(txtloinhuantuyen.Text);
            this.loaidon = float.Parse(txtloaidon.Text);
            this.km = float.Parse(txtkm.Text);
            this.khauhao = float.Parse(txtkhauhao.Text);
            this.giathue = float.Parse(txtgiathue.Text);
            this.giahoadon = float.Parse(txtgiahoadon.Text);
            this.giadauhientai = float.Parse(txtgiadauhientai.Text);
            this.ghichu = txtghichu.Text;
            this.dtkhac = float.Parse(txtphiphac.Text); // item.ghepdiem.ToString();
            this.dinhmucdau = float.Parse(txtdinhmucdau.Text);
            this.chiphilaixe = float.Parse(txtchiphilaixe.Text);
            this.chiphidau = float.Parse(txtchiphidau.Text);
            this.chiphicongan = float.Parse(txtchiphicongan.Text);
            this.bocxep = float.Parse(txtbocxep.Text);
            this.chiphicauduong = float.Parse(txtchiphicauduong.Text);
            this.makh = (string)(cbkhachhang.SelectedItem as ComboboxItem).Value;




            if (matuyen != "")
            {
                chon = true;
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                //   tbl_dstaikhoan tk = new tbl_dstaikhoan();


                //    MeasureItemEventArgs.re
                var rs = (from p in db.tbl_NP_giavantaitheotuyens
                          where p.maKH == makh && p.matuyen == matuyen
                          //  orderby tbl_dstaikhoan.matk
                          select p).FirstOrDefault();


                if (rs != null)
                {
                 
                    rs.trichdoitac=    this.trichdoitac ;// float.Parse(txttrichdoitac.Text);

                    rs.trichcongty =    this.trichcongty ;// float.Parse(txttrichcongty.Text);
                    rs.tongcfuoctinh =      this.tongchiphi ;// float.Parse(txttongchiphi.Text);
                    rs.tentuyen = this.tentuyen ;// txttentuyen.Text;
                    rs.matuyen = this.matuyen ;// txtmatuyen.Text;
                    rs.lntuyen = this.loinhuantuyen ;// float.Parse(txtloinhuantuyen.Text);
                    rs.loaidonxe = this.loaidon ;// float.Parse(txtloaidon.Text);
                    rs.km = this.km ;// float.Parse(txtkm.Text);
                    rs.cfkhauhao = this.khauhao ;// float.Parse(txtkhauhao.Text);
                    rs.giathue = this.giathue ;// float.Parse(txtgiathue.Text);
                    rs.giahoadon = this.giahoadon ;// float.Parse(txtgiahoadon.Text);
                    rs.giadau = this.giadauhientai ;// float.Parse(txtgiadauhientai.Text);
                    rs.ghichucf = this.ghichu ;// txtghichu.Text;
                    rs.dtkhac = this.dtkhac ;// float.Parse(txtphiphac.Text); ;// item.ghepdiem.ToString();
                    rs.dinhmucdau = this.dinhmucdau ;// float.Parse(txtdinhmucdau.Text);
                    rs.cflaixe = this.chiphilaixe ;// float.Parse(txtchiphilaixe.Text);
                    rs.cfxang = this.chiphidau ;// float.Parse(txtchiphidau.Text);
                    rs.cfcongan = this.chiphicongan ;// float.Parse(txtchiphicongan.Text);
                    rs.bocxep = this.bocxep ;// float.Parse(txtbocxep.Text);
                    rs.cfcauduong = this.chiphicauduong ;// float.Parse(txtchiphicauduong.Text);
                    rs.maKH = this.makh ;// (string)(cbkhachhang.SelectedItem as ComboboxItem).Value;

                    

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



            #region chekc detail

            if (cbkhachhang.SelectedIndex < 0)
            {
                MessageBox.Show("Kiểm tra lại mã khác hàng !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbkhachhang.Focus();
                return;
            }
            if (txttrichdoitac.Text == "" || Utils.IsValidnumber(txttrichdoitac.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại trích đối tác !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttrichdoitac.Focus();
                return;
            }

            if (txttrichcongty.Text == "" || Utils.IsValidnumber(txttrichcongty.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại trích công ty!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttrichcongty.Focus();
                return;
            }

            if (txttongchiphi.Text == "" || Utils.IsValidnumber(txttongchiphi.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại tổng chi phí !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttongchiphi.Focus();
                return;
            }

            if (txttentuyen.Text == "" || txttentuyen.Text == null)
            {
                MessageBox.Show("Kiểm tra lại tên tuyến !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentuyen.Focus();
                return;
            }

            if (txtmatuyen.Text == "" || txtmatuyen.Text == null)
            {
                MessageBox.Show("Kiểm tra lại mã tuyến !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmatuyen.Focus();
                return;
            }

            if (txtloinhuantuyen.Text == "" || Utils.IsValidnumber(txtloinhuantuyen.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại lợi nhận tuyến !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtloinhuantuyen.Focus();
                return;
            }

            if (txtloaidon.Text == "" || Utils.IsValidnumber(txtloaidon.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại loại đơn !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtloaidon.Focus();
                return;
            }
            if (txtkm.Text == "" || Utils.IsValidnumber(txtkm.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại KM!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtkm.Focus();
                return;
            }
            if (txtkhauhao.Text == "" || Utils.IsValidnumber(txtkhauhao.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại khấu hao ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtkhauhao.Focus();
                return;
            }
            if (txtgiathue.Text == "" || Utils.IsValidnumber(txtgiathue.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại giá thuê ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgiathue.Focus();
                return;
            }
            if (txtgiahoadon.Text == "" || Utils.IsValidnumber(txtgiahoadon.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại giá hóa đơn ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgiahoadon.Focus();
                return;
            }

            if (txtgiadauhientai.Text == "" || Utils.IsValidnumber(txtgiadauhientai.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại giá dầu hiện tại ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgiadauhientai.Focus();
                return;
            }


            if (txtghichu.Text == "" || txtghichu.Text == null)
            {
                MessageBox.Show("Kiểm tra lại ghi chú ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtghichu.Focus();
                return;
            }

            if (txtphiphac.Text == "" || Utils.IsValidnumber(txtphiphac.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại tiền phí khác ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtphiphac.Focus();
                return;
            }


            if (txtdinhmucdau.Text == "" || Utils.IsValidnumber(txtdinhmucdau.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại định mức dầu ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdinhmucdau.Focus();
                return;
            }

            if (txtchiphilaixe.Text == "" || Utils.IsValidnumber(txtchiphilaixe.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại chi phí lái xe ước tính ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtchiphilaixe.Focus();
                return;
            }

            if (txtchiphidau.Text == "" || Utils.IsValidnumber(txtchiphidau.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại chi phí dầu ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtchiphidau.Focus();
                return;
            }

            if (txtchiphicongan.Text == "" || Utils.IsValidnumber(txtchiphicongan.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại chi phí công an ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtchiphicongan.Focus();
                return;
            }

            if (txtbocxep.Text == "" || Utils.IsValidnumber(txtbocxep.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại chi phí bốc xếp ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbocxep.Focus();
                return;
            }

            if (txtchiphicauduong.Text == "" || Utils.IsValidnumber(txtchiphicauduong.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại chi phí cầu đường  ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtchiphicauduong.Focus();
                return;
            }
            #endregion


            this.trichdoitac = float.Parse(txttrichdoitac.Text);

            this.trichcongty = float.Parse(txttrichcongty.Text);
            this.tongchiphi = float.Parse(txttongchiphi.Text);
            this.tentuyen = txttentuyen.Text;
            this.matuyen = txtmatuyen.Text;
            this.loinhuantuyen = float.Parse(txtloinhuantuyen.Text);
            this.loaidon = float.Parse(txtloaidon.Text);
            this.km = float.Parse(txtkm.Text);
            this.khauhao = float.Parse(txtkhauhao.Text);
            this.giathue = float.Parse(txtgiathue.Text);
            this.giahoadon = float.Parse(txtgiahoadon.Text);
            this.giadauhientai = float.Parse(txtgiadauhientai.Text);
            this.ghichu = txtghichu.Text;
            this.dtkhac = float.Parse(txtphiphac.Text); // item.ghepdiem.ToString();
            this.dinhmucdau = float.Parse(txtdinhmucdau.Text);
            this.chiphilaixe = float.Parse(txtchiphilaixe.Text);
            this.chiphidau = float.Parse(txtchiphidau.Text);
            this.chiphicongan = float.Parse(txtchiphicongan.Text);
            this.bocxep = float.Parse(txtbocxep.Text);
            this.chiphicauduong = float.Parse(txtchiphicauduong.Text);
            this.makh = (string)(cbkhachhang.SelectedItem as ComboboxItem).Value;



            chon = true;
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            tbl_NP_giavantaitheotuyen p = new tbl_NP_giavantaitheotuyen();

            p.trichdoitac = this.trichdoitac;

            p.trichcongty = this.trichcongty;
            p.tongcfuoctinh = this.tongchiphi;
            p.tentuyen = this.tentuyen;
            p.matuyen = this.matuyen;
            p.lntuyen = this.loinhuantuyen;
            p.loaidonxe = this.loaidon;
            p.km = this.km;
            p.cfkhauhao = this.khauhao;
            p.giathue = this.giathue;
            p.giahoadon = this.giahoadon;
            p.giadau = this.giadauhientai;
            p.ghichucf = this.ghichu;
            p.dtkhac = this.dtkhac;
            p.dinhmucdau = this.dinhmucdau;
            p.cflaixe = this.chiphilaixe;
            p.cfxang = this.chiphidau;
            p.cfcongan = this.chiphicongan;
            p.bocxep = this.bocxep;
            p.cfcauduong = this.chiphicauduong;
            p.maKH = this.makh;




            db.tbl_NP_giavantaitheotuyens.InsertOnSubmit(p);
            db.SubmitChanges();
            this.Close();






        }








        private void txtQuocgia_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtDienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txttentuyen.Focus();


            }
        }



        private void txtNguoidaidien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtkm.Focus();


            }
        }



        private void txttennganhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //    txtma.Focus();


            }
        }

        private void txtmakho_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttenkho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txttentuyen.Focus();


            }
        }

        private void txtdiachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtloaidon.Focus();


            }
        }

        private void txtghichu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //       txtma.Focus();


            }
        }

        private void txtmasothue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtkm.Focus();


            }
        }

        private void txttaikhoannganhangso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtgiahoadon.Focus();


            }
        }

        private void txtdiachitaikhoannganhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //        txtma.Focus();


            }
        }
    }


}

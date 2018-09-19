using BEEACCOUNT.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BEEACCOUNT.View
{
    public partial class BeeKhophieuxuat : Form
    {
        public int statusphieuxuat { get; set; } // mới  // 2 suawra // 3 display //
        public int phieuxuatid { get; set; }

        public string makho { get; set; }
        public string sophieuxuat { get; set; }
        public string tkno { get; set; }
        public int tknochitiet { get; set; }
        public string tkco { get; set; }
        public int tkcochitiet { get; set; }
        public double sotien { get; set; }
        //    public double pssotienco { get; set; }

        public string maphieuthuOld { get; set; }
        //    public DataGridView DataGridView1 { get; set; }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }


        public void add_detailGridviewPXkho(tbl_kho_phieuxuat_detail sanpham)
        {





            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            DataTable dataTable = (DataTable)dataGridViewTkCo.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            //  drToAdd["mahang"] = sanpham.mahang;
            drToAdd["Số_lượng_xuất"] = sanpham.soluongxuat;
            drToAdd["Đơn_giá"] = sanpham.dongia;
            drToAdd["Tên_sản_phẩm"] = sanpham.tenhang;

            drToAdd["Đơn_vị"] = sanpham.donvi;

            drToAdd["Thành_tiền"] = sanpham.thanhtien;

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();



            int i = dataTable.Rows.Count - 1;

            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridViewTkCo.Rows[i].Cells["Mã_sản_phẩm"];
          //  DataGridViewCell dgvc = (DataGridViewCell)dataGridViewTkCo.Rows[i].Cells["Mã_sản_phẩm"];

            #region tim item comboboc

            foreach (ComboboxItem item in (List<ComboboxItem>)cb.DataSource)
            {

                if (item.Value.ToString().Trim() == sanpham.mahang.ToString().Trim())
                {

                    dataGridViewTkCo.Rows[i].Cells["Mã_sản_phẩm"].Value = item.Value;

                    cb.Selected = true;
                  
                }


            }

            //      dataGridViewTkCo.Rows[i].Cells["Số_lượng_nhập"].Value = 
            dataGridViewTkCo.Rows[i].Cells["Đơn_giá"].Selected = true;
            #endregion tom item comboubox





        }

        public void blankphieutonew(string makho)
        {
            #region  list black phiếu
            datepickngayphieu.Enabled = true;
            //         txtquyenso.Enabled = true;
            txtsophieu.Enabled = true;
            txttennguoinhan.Enabled = true;
            txtlydoxuat.Enabled = true;
            //txtdiengiai.Enabled = true;
            //txtsotien.Enabled = true;
            //   txtsochungtugoc.Enabled = true;
            btluu.Visible = true;
            btluu.Enabled = true;
            //    cbtaikhoanco.Enabled = true;
            cbtkno.Enabled = true;
            cbtkco.Enabled = true;
            btsua.Enabled = false;
            txtsotiensave.Visible = false;
            txtdiachibophan.Enabled = true;
            txtdiachibophan.Text = "";
            txtsophieu.Text = "";
            txttennguoinhan.Text = "";
            txtlydoxuat.Text = "";
            //    txtdiengiai.Text = "";
            //lbid.Text = "";
            //     txtsotien.Text = "";
            //     txtsochungtugoc.Text = "";
            //     txtquyenso.Text = "";

            cbtkno.SelectedIndex = -1;
            cbtkco.SelectedIndex = -1;
            cbkhohang.SelectedIndex = -1;

            lb_machitietno.Text = "";
            lbtenchitietno.Text = "";
            //    txttaikhoanco.Text = "";
            lb_machitietco.Text = "";
            lbtenchitietco.Text = "";
         //   this.makho = null;
            txtsophieu.Focus();
            txthoadonkemtheo.Text = "";

            this.phieuxuatid = -1;

            this.statusphieuxuat = 1; // tạo mới
            #endregion
         dataGridViewTkCo = Model.Khohang.reloaddetailnewPXK(dataGridViewTkCo, makho);

        }

        public void reloadseachview(string nguoinop, string diachi, string noidung)
        {



            //   dataGridViewListphieuthu.DataSource = Model.Phieuthuchi.reloadseachview("PT", nguoinop, diachi, noidung);


        }



        void Control_KeyPress(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.F3)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "BeeSeach")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    //               View.BeeSeachtwofield sheaching = new BeeSeachtwofield(this, "Người nôp", "Địa chỉ", "Nội dung");
                    //             sheaching.Show();
                }




            }


            if (e.Control == true && e.KeyCode == Keys.N)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "BeeHtdoiungphieuxuatkho")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    View.BeeHtdoiungphieuxuatkho BeeHtdoiungphieuxuatkho = new BeeHtdoiungphieuxuatkho(this, "Địa chỉ", "", "");
                    BeeHtdoiungphieuxuatkho.Show();
                }




            }


        }

        public View.Main main1;
        public BeeKhophieuxuat(View.Main Main)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);  // để đọc từ bàn phím phím tắt

            this.sotien = 0;
            //   this.pssotienco = 0;
            this.main1 = Main;
            //lbid.Text = "";
            this.statusphieuxuat = 1; // tạo mới
            txtsotiensave.Visible = false;

            Model.Username used = new Model.Username();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            string username = Utils.getusername();


            #region load datenew
            this.datepickngayphieu.Value = DateTime.Today.Date;

            this.lbtenchitietno.Text = "";
            lb_machitietno.Text = "";

            this.lbtenchitietco.Text = "";
            lb_machitietco.Text = "";
            if (cbkhohang.SelectedItem != null)
            {
                this.makho = (cbkhohang.SelectedItem as ComboboxItem).Value.ToString();
            }
      

            #region load tk nợ

            //            tien  khacbiet   klabi    kabi
            //kho
            //tamung
            //xacdinhkqkd
            //taisan
            //nguonvon
            //doanhthu
            //chiphi
            //loinhuan



            var rs2 = from tk in dc.tbl_dstaikhoans
                      where tk.loaitkid == "kho" // mã 8 là tiền mặt
                      select tk;

            //      string drowdownshow = "";

            foreach (var item in rs2)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk;
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                this.cbtkco.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk nợ

            //  cbtkco


            #region load tk có




            var rs4 = from tk in dc.tbl_dstaikhoans
                      where tk.loaitkid != "kho"
                      select tk;

            //      string drowdownshow = "";

            foreach (var item in rs4)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk;
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                this.cbtkno.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk có



            #region load kho hàng


            var rs3 = from p in dc.tbl_khohangs
                          //    where p.loaitkid == "kho" // mã 8 là tiền mặt
                      select p;

            //      string drowdownshow = "";

            foreach (var item in rs3)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.makho;
                cb.Text = item.tenkho; //item.makho.Trim() + ": " +
                this.cbkhohang.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load kho hàng


            //       dataGridViewTkCo.DataSource = Model.Khohang.danhsachphieunhapkho(dc);
         

            dataGridViewTkCo = Model.Khohang.reloaddetailnewPXK(dataGridViewTkCo, this.makho);

            dataGridViewListPNK.DataSource = Model.Khohang.danhsachphieuxuatkho(dc);


            dataGridViewListPNK.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";
            dataGridViewListPNK.Columns["Số_tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // để hiện số có dấu phảy

            #endregion load datanew

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            main1.clearpannel();
            View.Beemainload main = new Beemainload(main1);

            main1.clearpannelload(main);
        }

        private void comboBox8_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                txttennguoinhan.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void datepickngayphieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // datepickngayphieu.
                e.Handled = true;
                //     txtquyenso.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }




        }

        private void cbtennguoinop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtlydoxuat.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void cbdiachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                //    txtdiengiai.Focus();


            }
        }

        private void cbdiengiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                //    txtsotien.Focus();



            }
        }

        private void cbsotien_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                //   txtsochungtugoc.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }

        }

        private void cbsochungtugoc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                datepickngayphieu.Focus();
                //  datepickngayphieu
                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void cbtkno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  e.Handled = true;
                //  cbtaikhoanco.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void cbtaikhoanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  e.Handled = true;
                //   datepickngayphieu.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void button1_Click(object sender, EventArgs e)  // new phieu 
        {

            bool checkdinhkhoan = true;


            if (dataGridViewTkCo.RowCount - 1 == 0)
            {

                MessageBox.Show("Bạn chưa nhập chi tiết phiếu xuất !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                dataGridViewTkCo.Focus();
                return;
            }



            for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            {
                #region  check từng dòng chi tiết phiếu nhập
                if (dataGridViewTkCo.Rows[idrow].Cells["masanpham"].Value != DBNull.Value)
                {


                    if (dataGridViewTkCo.Rows[idrow].Cells["Tên_sản_phẩm"].Value == DBNull.Value)
                    {

                        MessageBox.Show("Bạn kiểm tra tên sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkdinhkhoan = false;
                        return;
                    }


                    if (dataGridViewTkCo.Rows[idrow].Cells["Đơn_vị"].Value == DBNull.Value)
                    {

                        MessageBox.Show("Bạn kiểm tra lại đơn vị sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkdinhkhoan = false;
                        return;
                    }

                    if (dataGridViewTkCo.Rows[idrow].Cells["Số_lượng_xuất"].Value == DBNull.Value)
                    {

                        MessageBox.Show("Bạn kiểm tra lại số lượng", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkdinhkhoan = false;
                        return;
                    }
                    else
                    {
                        if (Utils.IsValidnumber(dataGridViewTkCo.Rows[idrow].Cells["Số_lượng_xuất"].Value.ToString()) != true)
                        {
                            MessageBox.Show("Bạn kiểm tra lại số lượng phải là số ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            checkdinhkhoan = false;
                            return;
                        }
                    }

                    if (dataGridViewTkCo.Rows[idrow].Cells["Đơn_giá"].Value == DBNull.Value)
                    {

                        MessageBox.Show("Bạn kiểm tra lại đơn giá", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkdinhkhoan = false;
                        return;
                    }
                    else
                    {
                        if (Utils.IsValidnumber(dataGridViewTkCo.Rows[idrow].Cells["Đơn_giá"].Value.ToString()) != true)
                        {
                            MessageBox.Show("Bạn kiểm tra lại đơn giá phải là số ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            checkdinhkhoan = false;
                            return;
                        }
                    }





                }// nếu là dòng data có masan phẩm
                else
                {

                    MessageBox.Show("Bạn kiểm tra dòng: " + idrow.ToString() + "Thiếu mã sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkdinhkhoan = false;
                    return;
                }


                #endregion


            }


            #region check chi tiết head phiếu
            #region  chcek so phieu co ký tu khong
            if (txtsophieu.Text == "")
            {
                MessageBox.Show("Phiếu số thiếu !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                txtsophieu.Focus();
                return;

            }


            #endregion  check so phieu co ky tu không


            #region check phieu so có lặp hay kkoog
            //  txtsophieu
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var sophieunhaplap = (from p in dc.tbl_kho_phieuxuat_heads
                                  where (p.phieuso == txtsophieu.Text.ToString().Trim())
                                  select p).FirstOrDefault();

            if (sophieunhaplap != null)
            {

                MessageBox.Show("Số phiếu bị lặp !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                txtsophieu.Focus();
                return;


            }


            #endregion check phieu so

            if (datepickngayphieu.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn ngày chứng từ !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                datepickngayphieu.Focus();
                return;

            }

            if (cbkhohang.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa nhập kho hàng !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                cbkhohang.Focus();
                return;

            }

            if (cbtkno.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản nợ !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                cbtkno.Focus();
                return;

            }

            if (cbtkco.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản có !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                cbtkco.Focus();
                return;

            }



            if (txtlydoxuat.Text == "")
            {
                MessageBox.Show("Kiểm tra lý do xuất chưa có thông tin!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                txtlydoxuat.Focus();
                return;

            }

            if (txtdiachibophan.Text == "")
            {
                MessageBox.Show("Kiểm tra địa chỉ / bộ phận !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                txtlydoxuat.Focus();
                return;

            }


            if (txttennguoinhan.Text == "")
            {
                MessageBox.Show("Kiểm tra tên người giao !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                txttennguoinhan.Focus();
                return;

            }

            if (this.makho == null)
            {
                MessageBox.Show("Bạn chưa chọn kho hàng !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                cbkhohang.Focus();
                return;
            }
            #endregion  end check chi tiết phieu thu

            #region     // save head phieu xuat
            if (checkdinhkhoan == true)
            {


                tbl_kho_phieuxuat_head headphieuxuat = new tbl_kho_phieuxuat_head();
                headphieuxuat.phieuso = txtsophieu.Text.Trim();

                //       headphieuxuat.diengiai = txtlydoxuat.Text;
                headphieuxuat.macty = Model.Username.getmacty();
                headphieuxuat.createby = Utils.getusername();
                headphieuxuat.createdate = DateTime.Today;
                headphieuxuat.diengiai = txtlydoxuat.Text.Trim();
                headphieuxuat.hoadondikhem = txthoadonkemtheo.Text;
                headphieuxuat.makho = (cbkhohang.SelectedItem as ComboboxItem).Value.ToString();

                headphieuxuat.tenkho = (cbkhohang.SelectedItem as ComboboxItem).Text.ToString();
                headphieuxuat.diachibophan = txtdiachibophan.Text;


                headphieuxuat.ngayphieuxuat = datepickngayphieu.Value;
                headphieuxuat.nguoinhanhang = txttennguoinhan.Text.Trim();

                headphieuxuat.notk = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
                if (lb_machitietno.Text != "" & Utils.IsValidnumber(lb_machitietno.Text))
                {
                    headphieuxuat.MaCTietTKNo = int.Parse(lb_machitietno.Text);
                }
                headphieuxuat.TenCTietTKNo = lbtenchitietno.Text;

                headphieuxuat.cotk = (cbtkco.SelectedItem as ComboboxItem).Value.ToString();

                if (lb_machitietco.Text != "" & Utils.IsValidnumber(lb_machitietco.Text))
                {
                    headphieuxuat.MaCTietTKCo = int.Parse(lb_machitietco.Text);
                }
                headphieuxuat.TenCTietTKCo = lbtenchitietco.Text;

                headphieuxuat.sotien = this.sotien;



                dc.tbl_kho_phieuxuat_heads.InsertOnSubmit(headphieuxuat);
                dc.SubmitChanges();

                headphieuxuat = null;

            }
            #endregion   /// save head phieu nhap




            #region   // save  detail phieu xuat
            for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            {

                tbl_kho_phieuxuat_detail detail = new tbl_kho_phieuxuat_detail();
                detail.macty = Model.Username.getmacty();
                detail.ngayphieuxuat = datepickngayphieu.Value;

                detail.makho = (cbkhohang.SelectedItem as ComboboxItem).Value.ToString();
                detail.dongia = float.Parse(dataGridViewTkCo.Rows[idrow].Cells["Đơn_giá"].Value.ToString());
                detail.donvi = dataGridViewTkCo.Rows[idrow].Cells["Đơn_vị"].Value.ToString();
                detail.mahang = dataGridViewTkCo.Rows[idrow].Cells["masanpham"].Value.ToString();
                detail.phieuso = txtsophieu.Text.Trim();
                detail.soluongxuat = float.Parse(dataGridViewTkCo.Rows[idrow].Cells["Số_lượng_xuất"].Value.ToString());
                detail.tenhang = dataGridViewTkCo.Rows[idrow].Cells["Tên_sản_phẩm"].Value.ToString();
                detail.thanhtien = float.Parse(dataGridViewTkCo.Rows[idrow].Cells["Thành_tiền"].Value.ToString());


                dc.tbl_kho_phieuxuat_details.InsertOnSubmit(detail);
                dc.SubmitChanges();
                detail = null;


            }
            #endregion   /// save  detail phieu nhap


            #region// save so cái phiếu nhập
            tbl_Socai socai = new tbl_Socai();
            socai.Diengiai = txtlydoxuat.Text;

            if (lb_machitietco.Text != "" & Utils.IsValidnumber(lb_machitietco.Text))
            {
                socai.MaCTietTKCo = int.Parse(lb_machitietco.Text);
            }
            socai.tenchitietCo = lbtenchitietco.Text;

            if (lb_machitietno.Text != "" & Utils.IsValidnumber(lb_machitietno.Text))
            {
                socai.MaCTietTKNo = int.Parse(lb_machitietno.Text);
            }
            socai.tenchitietNo = lbtenchitietno.Text;

            socai.manghiepvu = "PXK";
            socai.Ngayctu = datepickngayphieu.Value;
            socai.Ngayghiso = DateTime.Today;
            socai.PsCo = this.sotien;
            socai.PsNo = this.sotien;

            socai.Sohieuchungtu = txtsophieu.Text.Trim();
            socai.TkCo = (cbtkco.SelectedItem as ComboboxItem).Value.ToString();
            socai.TkNo = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();

            socai.username = Utils.getusername();


            Model.Taikhoanketoan.ghisocaitk(socai);

            #endregion// save so cái phiếu nhập
            this.makho = (cbkhohang.SelectedItem as ComboboxItem).Value.ToString();
            this.sophieuxuat = txtsophieu.Text.Trim();
            this.blankphieutonew(this.makho);

            dataGridViewListPNK.DataSource = Model.Khohang.danhsachphieuxuatkho(dc);
            MessageBox.Show("Số phiếu vừa lưu: " + this.sophieuxuat, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridViewListphieuthu_Paint(object sender, PaintEventArgs e)
        {

            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            foreach (var c in dataGridViewListPNK.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

            // Next





        }

        private void cbtkno_SelectionChangeCommitted(object sender, EventArgs e)
        {


            string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();


            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            var detail = (from c in db.tbl_dstaikhoans
                          where c.matk.Trim() == taikhoan.Trim()
                          select c).FirstOrDefault();



            if (detail.loaichitiet == true) // là co theo doi chi tiết
            {

                List<beeselectinput.ComboboxItem> listcb = new List<beeselectinput.ComboboxItem>();
                var rs = from tbl_machitiettk in db.tbl_machitiettks
                         where tbl_machitiettk.matk.Trim() == taikhoan.Trim()
                         orderby tbl_machitiettk.machitiet
                         select tbl_machitiettk;
                if (rs.Count() > 0)
                {


                    foreach (var item2 in rs)
                    {
                        beeselectinput.ComboboxItem cb = new beeselectinput.ComboboxItem();
                        cb.Value = item2.machitiet.ToString().Trim();
                        cb.Text = item2.tenchitiet; //item2.machitiet.ToString().Trim() + ": " +
                        listcb.Add(cb);
                    }





                    FormCollection fc = System.Windows.Forms.Application.OpenForms;

                    bool kq = false;
                    foreach (Form frm in fc)
                    {
                        if (frm.Text == "beeselectinput")


                        {
                            kq = true;
                            frm.Focus();

                        }
                    }

                    if (!kq)
                    {
                        //    View.BeeSeachtwofield sheaching = new BeeSeachtwofield(this, "Người nôp", "Địa chỉ", "Nội dung");
                        //   sheaching.Show();


                        View.beeselectinput selecdetail = new beeselectinput("Chọn chi tiết tài khoản ", listcb);

                        selecdetail.ShowDialog();
                        bool chon = selecdetail.kq;
                        if (chon)
                        {
                            string machitiet = selecdetail.value;
                            string namechitiet = selecdetail.valuetext;
                            //     lbmachitietco.Visible = true;

                            lbtenchitietno.Visible = true;
                            lb_machitietno.Visible = true;
                            this.tknochitiet = int.Parse(selecdetail.value.ToString());
                            //     lbmachitietco.Text = machitiet;
                            lbtenchitietno.Text = namechitiet;
                            lb_machitietno.Text = machitiet;
                        }
                        else
                        {

                            cbtkno.SelectedIndex = -1;

                        }
                    }
                    else
                    {
                        this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                              //     lbmachitietco.Text = machitiet;
                        lbtenchitietno.Text = "";//namechitiet;
                        lb_machitietno.Text = "";
                    }
                    //  selecdetail.Text;

                }
                else
                {
                    this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                          //     lbmachitietco.Text = machitiet;
                    lbtenchitietno.Text = "";//namechitiet;
                    lb_machitietno.Text = "";
                }




            }
            else
            {
                this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                      //     lbmachitietco.Text = machitiet;
                lbtenchitietno.Text = "";//namechitiet;
                lb_machitietno.Text = "";
            }

            //    dataGridViewTkCo.Focus();

        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.blankphieutonew(this.makho);

            tabControl1.SelectedTab = tabPage1;
            //      dataGridViewTkCo = Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);

        }

        private void button5_Click(object sender, EventArgs e)
        {

            string username = Utils.getusername();

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region xoa detail va head phieu xuat


            var xoahead = from p in dc.Rptphieuxuatkhoheads
                          where p.username == username
                          select p;

            dc.Rptphieuxuatkhoheads.DeleteAllOnSubmit(xoahead);
            dc.SubmitChanges();



            var xoadetail = from p in dc.Rptphieuxuatkhodetail01s
                            where p.username == username
                            select p;

            dc.Rptphieuxuatkhodetail01s.DeleteAllOnSubmit(xoadetail);
            dc.SubmitChanges();

            #endregion xoa detail va head pheiu xuat


            var phieuxuat = (from p in dc.tbl_kho_phieuxuat_heads
                             where p.id == this.phieuxuatid
                             select p).FirstOrDefault();


            if (phieuxuat != null)
            {

                #region  insert vao rpt head

                Rptphieuxuatkhohead pxk = new Rptphieuxuatkhohead();
                string macty = Model.Username.getmacty();

                pxk.tencongty = Model.Congty.getnamecongty(macty);
                pxk.diachicongty = Model.Congty.getdiachicongty(macty);
                pxk.masothue = Model.Congty.getmasothuecongty(macty);
                pxk.tengiamdoc = Model.Congty.gettengiamdoccongty(macty);
                pxk.tenketoantruong = Model.Congty.gettenketoantruongcongty(macty);
                pxk.phieuso = phieuxuat.phieuso;
                pxk.ngaychungtu = phieuxuat.ngayphieuxuat;
                pxk.nguoinhan = phieuxuat.nguoinhanhang;
                pxk.nguoilapphieu = Utils.getname();
                pxk.xuattaikho = phieuxuat.tenkho;
                pxk.lydoxuat = phieuxuat.diengiai;
                pxk.diachibophan = phieuxuat.diachibophan;
                //      pnk.s = phieunhap.sotien;
                if (phieuxuat.sotien != null)
                {
                    pxk.sotienbangchu = Utils.ChuyenSo(decimal.Parse(phieuxuat.sotien.ToString()));
                }

                pxk.sochungtugoc = phieuxuat.hoadondikhem;
                pxk.username = username;
                pxk.tkno = phieuxuat.notk;
                pxk.tkco = phieuxuat.cotk;

                dc.Rptphieuxuatkhoheads.InsertOnSubmit(pxk);
                dc.SubmitChanges();





                #endregion  inserphieu head

                #region inser detail phieu detail



                int i = 0;

                var detailphieu = from p in dc.tbl_kho_phieuxuat_details
                                  where p.phieuso == phieuxuat.phieuso
                                  select p;
                foreach (var item in detailphieu)
                {
                    Rptphieuxuatkhodetail01 detail = new Rptphieuxuatkhodetail01();
                    i = i + 1;
                    detail.dongia = item.dongia;
                    detail.donvi = item.donvi;
                    detail.masanpham = item.mahang;
                    detail.soluongthucte = item.soluongxuat;
                    detail.soluongyeucau = item.soluongyeucau;
                    detail.sophieu = item.phieuso;
                    detail.tensanpham = item.tenhang;
                    detail.thanhtien = item.thanhtien;
                    detail.username = username;
                    detail.stt = i;


                    dc.Rptphieuxuatkhodetail01s.InsertOnSubmit(detail);
                    dc.SubmitChanges();

                }





                #endregion inserd detail phiếu thu



                var datarptphieuxuat = from p in dc.Rptphieuxuatkhoheads
                                       where p.username == username
                                       select p;


                Utils ut = new Utils();
                var dataset1 = ut.ToDataTable(dc, datarptphieuxuat);

                var datadetailphieu = from p in dc.Rptphieuxuatkhodetail01s
                                      where p.username == username
                                      select p;

                var dataset2 = ut.ToDataTable(dc, datadetailphieu);

                Reportsview rpt = new Reportsview(dataset1, dataset2, "Phieuxuatkho.rdlc");
                rpt.ShowDialog();

            }
            else
            {

                MessageBox.Show("Phieu xuat ID : " + this.phieuxuatid.ToString(), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }



        }

        private void dataGridViewListphieuthu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region  danh sahc kho
            //#region load tk nợ
            List<ComboboxItem> cbcolectionkho = new List<ComboboxItem>();
            var dskho = from p in dc.tbl_khohangs
                            //   where p.loaitkid.Trim() == "kho" // tien mat la loai 8
                        orderby p.makho
                        select p;
            foreach (var item in dskho)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.makho.Trim();
                cb.Text = item.tenkho; //item.makho.Trim() + ": " + 
                cbcolectionkho.Add(cb);
            }

            cbkhohang.DataSource = cbcolectionkho;


            #endregion


            #region load tk nợ
            List<ComboboxItem> cbcolectiontkno = new List<ComboboxItem>();
            var rs = from p in dc.tbl_dstaikhoans
                     where p.loaitkid.Trim() == "kho" // tien mat la loai 8
                     orderby p.matk
                     select p;
            foreach (var item in rs)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk.Trim();
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                cbcolectiontkno.Add(cb);
            }

            cbtkco.DataSource = cbcolectiontkno;

            #endregion

            #region tai khoan có



            List<ComboboxItem> cbcolectiontkco = new List<ComboboxItem>();
            var rs2 = from p in dc.tbl_dstaikhoans
                      where p.loaitkid.Trim() != "kho" // tien mat la loai 8
                      orderby p.matk
                      select p;
            foreach (var item in rs2)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk.Trim();
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                cbcolectiontkco.Add(cb);
            }
            cbtkno.DataSource = cbcolectiontkco;
            #endregion tai khoan co

            try
            {
                this.phieuxuatid = (int)this.dataGridViewListPNK.Rows[this.dataGridViewListPNK.CurrentCell.RowIndex].Cells["ID"].Value;


            }
            catch (Exception)
            {

                this.phieuxuatid = 0;
            }

            if (this.phieuxuatid != 0)
            {


                #region view load form
                var phieuxuat = (from p in dc.tbl_kho_phieuxuat_heads
                                 where p.id == this.phieuxuatid
                                 select new
                                 {



                                     Phieuso = p.phieuso,
                                     ngaychungtu = p.ngayphieuxuat,
                                     nguoinhan = p.nguoinhanhang,
                                     //    nguoilapphieu = Utils.getname(),
                                     lydoxuat = p.diengiai,
                                     diengiai = p.diengiai,
                                     sotien = p.sotien,
                                     //   sotienbangchu = Utils.ChuyenSo(tbl_SoQuy.PsNo.ToString()),
                                     sochungtugoc = p.hoadondikhem,
                                     //    username = Utils.getusername(),
                                     diachibophan = p.diachibophan,
                                     notk = p.notk,
                                     cotk = p.cotk,
                                     machitietno = p.MaCTietTKNo,
                                     machitietco = p.MaCTietTKCo,
                                     tenchitietno = p.TenCTietTKNo,
                                     tenchitietco = p.TenCTietTKCo,
                                     tenkho = p.tenkho,
                                     makho = p.makho,
                                     //   tentkchitietno =p.
                                     //    tentkchitiet = p.,
                                     //      tkno = tbl_SoQuy.TKtienmat,

                                     //          taikhoandoiung = p.t,

                                 }).FirstOrDefault();


                if (phieuxuat != null)
                {
                    datepickngayphieu.Value = (DateTime)phieuxuat.ngaychungtu;
                    txtsophieu.Text = phieuxuat.Phieuso.ToString();
                    txttennguoinhan.Text = phieuxuat.nguoinhan;
                    //   txtlydoxuat.Text = phieunhap.ly;
                    txtlydoxuat.Text = phieuxuat.lydoxuat;
                    txtdiachibophan.Text = phieuxuat.diachibophan;

                    if (phieuxuat.sotien != null)
                    {
                        txtsotiensave.Text = phieuxuat.sotien.ToString();
                        this.sotien = double.Parse(phieuxuat.sotien.ToString());
                    }

                    lbtenchitietno.Text = phieuxuat.tenchitietno;
                    lbtenchitietco.Text = phieuxuat.tenchitietco;

                    foreach (ComboboxItem item in (List<ComboboxItem>)cbtkno.DataSource)
                    {
                        if (item.Value.ToString().Trim() == phieuxuat.notk.Trim())
                        {
                            cbtkno.SelectedItem = item;
                        }
                    }

                    foreach (ComboboxItem item in (List<ComboboxItem>)cbtkco.DataSource)
                    {
                        if (item.Value.ToString().Trim() == phieuxuat.cotk.Trim())
                        {
                            cbtkco.SelectedItem = item;
                        }
                    }

                    foreach (ComboboxItem item in (List<ComboboxItem>)cbkhohang.DataSource)
                    {
                        if (item.Value.ToString().Trim() == phieuxuat.makho.Trim())
                        {
                            cbkhohang.SelectedItem = item;
                        }
                    }



                    if (phieuxuat.machitietno != null)
                    {
                        lb_machitietno.Text = phieuxuat.machitietno.ToString();
                    }
                    else
                    {
                        lb_machitietno.Text = "";

                    }

                    if (phieuxuat.machitietco != null)
                    {
                        lb_machitietco.Text = phieuxuat.machitietco.ToString();
                    }
                    else
                    {
                        lb_machitietco.Text = "";

                    }

                    txthoadonkemtheo.Enabled = false;
                    txtdiachibophan.Enabled = false;
                    datepickngayphieu.Enabled = false;
                    txtsophieu.Enabled = false;
                    txttennguoinhan.Enabled = false;
                    txtlydoxuat.Enabled = false;
                    //  txtdiengiai.Enabled = false;

                    btsua.Enabled = true;
                    cbkhohang.Enabled = false;


                    cbtkno.Enabled = false;
                    cbtkco.Enabled = false;

                    this.statusphieuxuat = 3;// View
                                             //      Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);
                                             //        Model.Phieuthuchi.reloaddetailtaikhoancophieuthu(this.dataGridViewTkCo, this, phieuthu.tkno.Trim(), phieuthu.sophieuthu);
                    btluu.Visible = false;

                }


                dataGridViewTkCo = Model.Khohang.reloaddetailnewPXK(dataGridViewTkCo, this.makho);

                #region adđ detail san phẩm
                //     add_detailGridviewPNkho(tbl_kho_phieunhap_detail sanpham)


                var lisdetailphieuxuat = from p in dc.tbl_kho_phieuxuat_details
                                         where p.phieuso == phieuxuat.Phieuso
                                         select p;

                if (lisdetailphieuxuat.Count() >= 0)
                {
                    foreach (var item in lisdetailphieuxuat)
                    {


                        add_detailGridviewPXkho(item);



                    }




                }

                //     MessageBox.Show("SDádSDA", lisdetailphieunhap.Count().ToString());


                #endregion

                #endregion view load form

                //   dataGridViewTkCo.DataSource = null;


            }




        }

        private void dataGridViewListphieuthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            // nút xóa
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var phieuxuathead = (from p in dc.tbl_kho_phieuxuat_heads
                                 where p.id == this.phieuxuatid
                                 select p).FirstOrDefault();

            #region CÓ SỐ PHIÊU


            if (phieuxuathead != null)
            {
                //      this.phieuxuatid = phieuxuathead.id;

                dc.tbl_kho_phieuxuat_heads.DeleteOnSubmit(phieuxuathead);
                dc.SubmitChanges();


                #region      // xóa đetail phiếu xuat

                var phieuxuatdetail = from p in dc.tbl_kho_phieuxuat_details
                                      where p.phieuso.Trim() == phieuxuathead.phieuso.Trim()
                                      select p;

                if (phieuxuatdetail.Count() > 0)
                {
                    dc.tbl_kho_phieuxuat_details.DeleteAllOnSubmit(phieuxuatdetail);
                    dc.SubmitChanges();

                }
                #endregion     //    phieunhapdetail

                #region // xóa ở sổ cái phiếu xuất

                Model.hachtoantonghop.xoa("PXK", phieuxuathead.phieuso.Trim());

                #endregion                // xóa sổ cái nưa


                // xóa detail


                MessageBox.Show("Đã xóa phiếu xuất : " + phieuxuathead.phieuso, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //  Model.
                #region load list listphieunhapkho

                var listphieunhapkho = Model.Khohang.danhsachphieuxuatkho(dc);


                dataGridViewListPNK.DataSource = listphieunhapkho;
                #endregion


            }
            else
            {
                MessageBox.Show("Phiếu: " + this.sophieuxuat + " không tồn tại !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            #endregion có số phiếu



        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.statusphieuxuat = 2;

            btluu.Visible = true;


            datepickngayphieu.Enabled = true;
            cbtkco.Enabled = true;

            txtsophieu.Enabled = true;
            if (txtsophieu.Text != "")
            {
                this.sophieuxuat = txtsophieu.Text.ToString();
                this.maphieuthuOld = txtsophieu.Text.ToString();
            }

            txtdiachibophan.Enabled = true;
            txthoadonkemtheo.Enabled = true;
            cbkhohang.Enabled = true;
            txttennguoinhan.Enabled = true;
            txtlydoxuat.Enabled = true;
            //    txtdiengiai.Enabled = true;
            //    txtsotien.Enabled = true;
            //    txtsochungtugoc.Enabled = true;
            btluu.Enabled = true;

            //   cbtaikhoanco.Enabled = true;
            cbtkno.Enabled = true;

            this.statusphieuxuat = 2;

        }

        private void txtsophieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                txttennguoinhan.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txttennguoinop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                txtlydoxuat.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txtdiachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                //         txtdiengiai.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txtdiengiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                //            txtsotien.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txtsotien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                //      txtsochungtugoc.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txtsochungtugoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                cbtkno.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void bthachtoan_Click(object sender, EventArgs e)
        {


            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "BeeHtoansocaidoiung")


                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {
                //    View.BeeHtoansocaidoiungphieuthu BeeHtoansocaidoiung = new BeeHtoansocaidoiungphieuthu(this, "Địa chỉ", "", "");
                //            BeeHtoansocaidoiung.ShowDialog();
            }



        }

        private void txtsotien_TextChanged(object sender, EventArgs e)
        {

            //if (Utils.IsValidnumber(txtsotien.Text.ToString()))
            //{
            //    this.pssotienno = double.Parse(txtsotien.Text);
            //   // txtsotien.Text = pssotienno.pssotienno
            //}
            ////else
            //{
            //    txtsotien.Text = "";
            //}



        }

        private void txtsochungtugoc_TextChanged(object sender, EventArgs e)
        {
            //if (! Utils.IsValidnumber(txtsochungtugoc.Text.ToString()))
            //{
            //    txtsochungtugoc.Text = "";
            //}

        }

        private void dataGridViewTkCo_Paint(object sender, PaintEventArgs e)
        {

            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            foreach (var c in dataGridViewTkCo.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

            // Next

        }


        void cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(EndEdit));

        }
        ComboBox cbm;
        DataGridViewCell currentCell;

        //  private DateTimePicker cellDateTimePicker = new DateTimePicker();
        // DateTimePicker[] sp = new DateTimePicker[100];
        void EndEdit()
        {




            if (cbm != null)
            {
                if (cbm.SelectedItem != null)
                {
                    string SelectedItem = (cbm.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();


                    // int i = dataGridProgramdetail.CurrentRow.Index;
                    int i = currentCell.RowIndex;
                    string colname = this.dataGridViewTkCo.Columns[this.dataGridViewTkCo.CurrentCell.ColumnIndex].Name;

                    //   dataGridViewTkCo.Rows[i].Cells[colname].Value = SelectedItem;

                    dataGridViewTkCo.Rows[i].Cells[colname].Value = SelectedItem;

                    string connection_string = Utils.getConnectionstr();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
              
                    var sp = (from p in dc.tbl_kho_sanphams
                              where p.masp == SelectedItem
                              && p.makho == this.makho
                              orderby p.masp
                              select p).FirstOrDefault();


                    if (sp != null)
                    {
                        dataGridViewTkCo.Rows[i].Cells["Tên_sản_phẩm"].Value = sp.tensp;
                        dataGridViewTkCo.Rows[i].Cells["Đơn_vị"].Value = sp.donvi;

                    }
                    else
                    {
                        dataGridViewTkCo.Rows[i].Cells["Tên_sản_phẩm"].Value = "";
                        dataGridViewTkCo.Rows[i].Cells["Đơn_vị"].Value = "";

                    }

                    //dt.Columns.Add(new DataColumn("masanpham", typeof(string)));
                    //dt.Columns.Add(new DataColumn("Tên_sản_phẩm", typeof(string)));

                    //dt.Columns.Add(new DataColumn("Đơn_vị", typeof(string)));
                    //dt.Columns.Add(new DataColumn("Số_lượng_nhập", typeof(string)));

                    ////Threahold
                    ////      dt.Columns.Add(new DataColumn("Tk_Có", typeof(double)));
                    //dt.Columns.Add(new DataColumn("Đơn_giá", typeof(double)));
                    //dt.Columns.Add(new DataColumn("Thành_tiền", typeof(double)));


                }


            }


        }

        private void dataGridViewTkCo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {

                cbm = (ComboBox)e.Control;

                if (cbm != null)
                {
                    cbm.SelectedIndexChanged += new EventHandler(cbm_SelectedIndexChanged);
                }


                currentCell = this.dataGridViewTkCo.CurrentCell;




            }
        }

        private void txtquyenso_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                txtsophieu.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }




        }

        private void dataGridViewTkCo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            int i = e.RowIndex;
            string colname = view.Columns[e.ColumnIndex].Name;



            //       #region if la slect tai khoan co chi tiet

            // if (colname == "Tk_Có")
            // {


            //     //  string SelectedItem = view.Rows[i].Cells["Tk_Có"].Value.ToString();


            //     #region  view lai cac tk có

            //     String tkcotext = "";


            //     int dem = 0;
            //     for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            //     {

            //         if (dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value != null)
            //         {



            //             dem = dem + 1;
            //             if (dem > 1)
            //             {

            //                 tkcotext += ";" + dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim(); // chính la program

            //             }
            //             else
            //             {
            //                 tkcotext += dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim(); // chính la program
            //                                                                                                  //dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;


            //             }


            //         }


            //     }

            ////     txttaikhoanco.Text = tkcotext;
            //     #endregion

            // }


            //   if (colname == "Số_tiền")
            //   {


            //  string SelectedItem = view.Rows[i].Cells["Tk_Có"].Value.ToString();


            #region  view lai số tiền


            double tongcong = 0;


            for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            {


                if (dataGridViewTkCo.Rows[idrow].Cells["Thành_tiền"] != null)

                {
                    if (Utils.IsValidnumber(dataGridViewTkCo.Rows[idrow].Cells["Thành_tiền"].Value.ToString()))
                    {

                        tongcong += double.Parse(dataGridViewTkCo.Rows[idrow].Cells["Thành_tiền"].Value.ToString());
                    }
                }







            }

            //txtValueSotienCo.Text = tongcong.ToString();
            this.sotien = tongcong;
            txtsotiendisplay.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);
            #endregion



            //  }







        }

        private void dataGridViewTkCo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            int i = view.CurrentRow.Index;
            string colname = view.Columns[view.CurrentCell.ColumnIndex].Name;

            try
            {
                dataGridViewTkCo.Rows[i].Cells["Thành_tiền"].Value = float.Parse(dataGridViewTkCo.Rows[i].Cells["Số_lượng_xuất"].Value.ToString()) * float.Parse(dataGridViewTkCo.Rows[i].Cells["Đơn_giá"].Value.ToString());

            }
            catch (Exception)
            {

                dataGridViewTkCo.Rows[i].Cells["Thành_tiền"].Value = 0;
            }


            //    string SelectedItem = view.Rows[i].Cells["Tk_Có"].Value.ToString();

            //#region if la slect tai khoan co chi tiet

            //if (colname == "Tk_Có" && SelectedItem != "")
            //{
            //    string taikhoan = currentCell.Value.ToString();
            //    string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            //    var detail = (from c in db.tbl_dstaikhoans
            //                  where c.matk.Trim() == taikhoan.Trim()
            //                  select c).FirstOrDefault();

            //    if (detail.loaichitiet == true) // là co theo doi chi tiết
            //    {

            //        List<beeselectinput.ComboboxItem> listcb = new List<beeselectinput.ComboboxItem>();
            //        var rs = from tbl_machitiettk in db.tbl_machitiettks
            //                 where tbl_machitiettk.matk.Trim() == taikhoan.Trim()
            //                 orderby tbl_machitiettk.machitiet
            //                 select tbl_machitiettk;
            //        if (rs.Count() > 0)
            //        {


            //            foreach (var item2 in rs)
            //            {
            //                beeselectinput.ComboboxItem cb = new beeselectinput.ComboboxItem();
            //                cb.Value = item2.machitiet.ToString().Trim();
            //                cb.Text = item2.tenchitiet; //item2.machitiet.ToString().Trim() + ": " +
            //                listcb.Add(cb);
            //            }



            //            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            //            bool kq = false;
            //            foreach (Form frm in fc)
            //            {
            //                if (frm.Text == "beeselectinput")


            //                {
            //                    kq = true;
            //                    frm.Close();

            //                }
            //            }

            //            if (kq == false)
            //            {
            //                //        beeselectinput

            //                View.beeselectinput selecdetail = new beeselectinput("Chọn chi tiết tài khoản ", listcb);

            //                selecdetail.ShowDialog();


            //                bool chon = selecdetail.kq;
            //                if (chon)
            //                {
            //                    string machitiet = selecdetail.value;
            //                    string namechitiet = selecdetail.valuetext;

            //                    dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = machitiet;
            //                    dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = namechitiet;


            //                }
            //                else
            //                {
            //                    dataGridViewTkCo.Rows[i].Cells["Tk_Có"].Value = "";
            //                    dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //                    dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";
            //                }




            //            }
            //            else
            //            {
            //                dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //                dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";


            //            }


            //        }
            //    }


            //    else
            //    {
            //        dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //        dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";


            //    }

            //}

            //#endregion





        }

        private void dataGridViewTkCo_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridViewTkCo_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridViewTkCo_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {

        }

        private void dataGridViewTkCo_DataError_1(object sender, DataGridViewDataErrorEventArgs anError)
        {



            //String errortext = "Lỗi dữ liệu nhập vào ";


            //if (anError.Context == DataGridViewDataErrorContexts.Commit)
            //{
            //    errortext = "Dữ liệu nhập vào không phù hợp";
            //}
            //if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            //{
            //    errortext = "Lỗi khi sửa dữ liệu ô";
            //}
            //if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            //{
            //    errortext = "Lỗi khi chuyển kiểu dữ liệu";
            //}
            //if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            //{
            //    errortext = "Lỗi khi chuyển ô ";
            //}
            //if (anError.Context == DataGridViewDataErrorContexts.Formatting)
            //{
            //    errortext = "Loại dữ liệu nhập vào không đúng";
            //}


            //MessageBox.Show("Lỗi :" + errortext, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //if ((anError.Exception) is ConstraintException)
            //{
            //    DataGridView view = (DataGridView)sender;
            //    view.Rows[anError.RowIndex].ErrorText = "";
            //    view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "";

            //    anError.ThrowException = false;
            //}


        }

        private void dataGridViewTkCo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //int i = e.RowIndex;
            //DataGridView view = (DataGridView)sender;

            //for (int b = 0; b < view.ColumnCount; b++)
            //{
            //   // string colname = dataGridViewTkCo.Columns[b].Name;
            //    string colname = view.Columns[b].Name;
            //    //   dataGridViewTkCo.Rows[i].Cells[colname].Value = colname;
            // //   view.Rows[i].Cells[colname].Value = colname;
            //    //  view.Columns[b].Name;
            //}


            //   dataGridViewTkCo.Rows[e.RowIndex].Cells[0].Value = "xxx";
            //  DataGridView view = (DataGridView)sender;
            //  view.Rows[i].Cells[1].Value = "tesst";// view.Rows[i].Cells["tkCohide"].Value.ToString();
            //   view.Rows[i].Value = "tesst";// view.Rows[i].Cells["tkCohide"].Value.ToString();

            //   if ((String)dataGridViewTkCo.Rows[e.RowIndex].Cells["Tk_Có"].Value == null)
            //   {

            //    }

            //      string SelectedItem = (cbm.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();


            //if (dataGridViewTkCo.Rows[i].Cells[1].Value == null && dataGridViewTkCo.Rows[i].Cells["tkCohide"].Value != null)
            //{

            //    //     string colname = this.dataGridViewTkCo.Columns[this.dataGridViewTkCo.CurrentCell.ColumnIndex].Name;

            //    dataGridViewTkCo.Rows[i].Cells[1].Value = dataGridViewTkCo.Rows[i].Cells["tkCohide"].Value;


            //}

            // int i = dataGridProgramdetail.CurrentRow.Index;



            //    (String)dataGridViewTkCo.Rows[e.RowIndex].Cells["Tk_Có"]. != null

            // tkCohide

            //string SelectedItem = (cbm.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            //           // int i = dataGridProgramdetail.CurrentRow.Index;
            //           int i = currentCell.RowIndex;
            //           string colname = this.dataGridViewTkCo.Columns[this.dataGridViewTkCo.CurrentCell.ColumnIndex].Name;

            //           dataGridViewTkCo.Rows[i].Cells[colname].Value = SelectedItem;

            //  if (e.RowIndex is ComboBox)
            //  {

            //     cbm = (ComboBox)e.Control;

            //     if (cbm != null)
            //    {
            //   cbm.SelectedIndexChanged += new EventHandler(cbm_SelectedIndexChanged);
            //    }


            //currentCell = this.dataGridViewTkCo.CurrentCell;



            //   }
        }

        private void txtsotienco_TextChanged(object sender, EventArgs e)
        {
            if (Utils.IsValidnumber(txtsotiensave.Text.ToString()))
            {
                this.sotien = double.Parse(txtsotiensave.Text);
            }
            //else
            //{
            //    txtsotienco.Text = "";
            //}


        }

        private void dataGridViewTkCo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            //       #region  view lai cac tk có

            //       String tkcotext = "";


            //       int dem = 0;
            //       for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            //       {

            //           if (dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value != DBNull.Value)
            //           {



            //               dem = dem + 1;
            //               if (dem > 1)
            //               {

            //                   tkcotext += ";" + dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim(); // chính la program

            //               }
            //               else
            //               {
            //                   tkcotext += dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim(); // chính la program
            //                                                                                                    //dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;


            //               }


            //           }


            //       }

            ////       txttaikhoanco.Text = tkcotext;
            //       #endregion


            #region  view lai số tiền


            double tongcong = 0;


            for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            {


                if (dataGridViewTkCo.Rows[idrow].Cells["Thành_tiền"] != null)

                {
                    if (Utils.IsValidnumber(dataGridViewTkCo.Rows[idrow].Cells["Thành_tiền"].Value.ToString()))
                    {

                        tongcong += double.Parse(dataGridViewTkCo.Rows[idrow].Cells["Thành_tiền"].Value.ToString());
                    }
                }







            }

            //txtValueSotienCo.Text = tongcong.ToString();
            this.sotien = tongcong;
            txtsotiendisplay.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);
            #endregion



        }

        private void txtsotien_Leave(object sender, EventArgs e)
        {
            //if (txtsotien.Text != "")
            //{

            //    if (Utils.IsValidnumber(txtsotien.Text.Replace(",", "")))
            //    {
            //        //txtValueSotienNo.Text = txtsotien.Text.Replace(",","");
            //        this.pssotienno = double.Parse(txtsotien.Text.Replace(",", ""));
            //        txtsotien.Text = double.Parse(txtsotien.Text.Replace(",", "")).ToString("#,#", CultureInfo.InvariantCulture);

            //    }



            //}
        }

        private void cbtkco_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void cbtkco_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            //var rs = from tbl_Kafuctionlist in db.tbl_Kafuctionlists
            //         where tbl_Kafuctionlist.Code != "DIS"
            //         orderby tbl_Kafuctionlist.Code
            //         select tbl_Kafuctionlist;
            //foreach (var item2 in rs)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item2.Code.Trim();
            //    cb.Text = item2.Code.Trim() + ": " + item2.Description.Trim() + "    || Example: " + item2.Example;
            //    CombomCollection.Add(cb);
            //}

            string taikhoan = (cbtkco.SelectedItem as ComboboxItem).Value.ToString();
            //     this.matk = taikhoan;


            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            var detail = (from c in db.tbl_dstaikhoans
                          where c.matk.Trim() == taikhoan.Trim()
                          select c).FirstOrDefault();



            if (detail.loaichitiet == true) // là co theo doi chi tiết
            {

                List<beeselectinput.ComboboxItem> listcb = new List<beeselectinput.ComboboxItem>();
                var rs = from tbl_machitiettk in db.tbl_machitiettks
                         where tbl_machitiettk.matk.Trim() == taikhoan.Trim()
                         orderby tbl_machitiettk.machitiet
                         select tbl_machitiettk;
                if (rs.Count() > 0)
                {


                    foreach (var item2 in rs)
                    {
                        beeselectinput.ComboboxItem cb = new beeselectinput.ComboboxItem();
                        cb.Value = item2.machitiet.ToString().Trim();
                        cb.Text = item2.tenchitiet; //item2.machitiet.ToString().Trim() + ": " +
                        listcb.Add(cb);
                    }





                    FormCollection fc = System.Windows.Forms.Application.OpenForms;

                    bool kq = false;
                    foreach (Form frm in fc)
                    {
                        if (frm.Text == "beeselectinput")


                        {
                            kq = true;
                            frm.Focus();

                        }
                    }

                    if (!kq)
                    {
                        //    View.BeeSeachtwofield sheaching = new BeeSeachtwofield(this, "Người nôp", "Địa chỉ", "Nội dung");
                        //   sheaching.Show();


                        View.beeselectinput selecdetail = new beeselectinput("Chọn chi tiết tài khoản ", listcb);

                        selecdetail.ShowDialog();
                        bool chon = selecdetail.kq;
                        if (chon)
                        {
                            string machitiet = selecdetail.value;
                            string namechitiet = selecdetail.valuetext;
                            //     lbmachitietco.Visible = true;

                            lbtenchitietco.Visible = true;
                            lb_machitietco.Visible = true;
                            this.tknochitiet = int.Parse(selecdetail.value.ToString());
                            //     lbmachitietco.Text = machitiet;
                            lbtenchitietco.Text = namechitiet;
                            lb_machitietco.Text = machitiet;
                        }
                        else
                        {

                            cbtkco.SelectedIndex = -1;

                        }
                    }
                    else
                    {
                        this.tkcochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                              //     lbmachitietco.Text = machitiet;
                        lbtenchitietco.Text = "";//namechitiet;
                        lb_machitietco.Text = "";
                    }
                    //  selecdetail.Text;

                }
                else
                {
                    this.tkcochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                          //     lbmachitietco.Text = machitiet;
                    lbtenchitietco.Text = "";//namechitiet;
                    lb_machitietco.Text = "";
                }




            }
            else
            {
                this.tkcochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                      //     lbmachitietco.Text = machitiet;
                lbtenchitietco.Text = "";//namechitiet;
                lb_machitietco.Text = "";
            }

            //    dataGridViewTkCo.Focus();
        }

        private void dataGridViewListPNK_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            tabControl1.SelectedTab = tabPage1;
        }

        private void cbkhohang_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbkhohang.SelectedItem != null)
            {
                this.makho = (cbkhohang.SelectedItem as ComboboxItem).Value.ToString();
            }
            else
            {
                this.makho = null;
            }
            dataGridViewTkCo = Model.Khohang.reloaddetailnewPXK(dataGridViewTkCo, this.makho);
        }
    }
}

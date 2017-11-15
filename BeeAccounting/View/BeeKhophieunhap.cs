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
    public partial class BeeKhophieunhap : Form
    {
        public int statusphieunhap { get; set; } // mới  // 2 suawra // 3 display //
        public int phieunhapid { get; set; }
        public string sophieunhap { get; set; }
        public string tkno { get; set; }
        public int tknochitiet { get; set; }
        public string tkco { get; set; }
        public int tkcochitiet { get; set; }
        public double pssotienno { get; set; }
        public double pssotienco { get; set; }

        public int maphieuthuOld { get; set; }
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


        public void add_detailGridviewPNkho(tbl_kho_phieunhap_detail sanpham)
        {





            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //        //---------------
            //dt.Columns.Add(new DataColumn("Tên_sản_phẩm", typeof(string)));

            //dt.Columns.Add(new DataColumn("Đơn_vị", typeof(string)));
            //dt.Columns.Add(new DataColumn("Số_lượng_nhập", typeof(string)));

            ////Threahold
            ////      dt.Columns.Add(new DataColumn("Tk_Có", typeof(double)));
            //dt.Columns.Add(new DataColumn("Đơn_giá", typeof(double)));
            //dt.Columns.Add(new DataColumn("Thành_tiền", typeof(double)));
            ////    



            DataTable dataTable = (DataTable)dataGridViewTkCo.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            //  drToAdd["mahang"] = sanpham.mahang;
            drToAdd["Số_lượng_nhập"] = sanpham.soluongnhap;
            drToAdd["Đơn_giá"] = sanpham.dongia;
            drToAdd["Tên_sản_phẩm"] = sanpham.tenhang;

            drToAdd["Đơn_vị"] = sanpham.donvi;

            drToAdd["Thành_tiền"] = sanpham.thanhtien;


            //        if (socaitemp.PsCo != null)
            //        {
            //            drToAdd["Số_tiền"] = socaitemp.PsCo;
            //        }

            //        drToAdd["Mã_chi_tiết"] = socaitemp.MaCTietTKCo;
            //        drToAdd["Tên_chi_tiết"] = socaitemp.tenchitietCo;

            //        drToAdd["tkCohide"] = socaitemp.TkCo;


            //  //      drToAdd["ngayctuhide"] = socaitemp.Ngayctu;

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();



            int i = dataTable.Rows.Count - 1;
            //     dataGridViewTkCo.Rows[i].Cells["Đơn_giá"].EditedFormattedValue = true;
            //   int i = dataGridViewTkCo.RowCount -1;
            //dt.Columns.Add(new DataColumn("Tên_sản_phẩm", typeof(string)));

            //dt.Columns.Add(new DataColumn("Đơn_vị", typeof(string)));
            //dt.Columns.Add(new DataColumn("Số_lượng_nhập", typeof(string)));
            //   cmbdgv.HeaderText = "Mã_sản_phẩm";
            ////Threahold
            ////      dt.Columns.Add(new DataColumn("Tk_Có", typeof(double)));
            //dt.Columns.Add(new DataColumn("Đơn_giá", typeof(double)));
            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridViewTkCo.Rows[i].Cells["Mã_sản_phẩm"];
            DataGridViewCell dgvc = (DataGridViewCell)dataGridViewTkCo.Rows[i].Cells["Mã_sản_phẩm"];

            #region tim item comboboc

            foreach (ComboboxItem item in (List<ComboboxItem>)cb.DataSource)
            {

                if (item.Value.ToString().Trim() == sanpham.mahang.ToString().Trim())
                {

                    dataGridViewTkCo.Rows[i].Cells["Mã_sản_phẩm"].Value = item.Value;
                    //      cb.Selected = true;
                    //  cb.inde = true;
                }


            }

            //      dataGridViewTkCo.Rows[i].Cells["Số_lượng_nhập"].Value = 
            dataGridViewTkCo.Rows[i].Cells["Đơn_giá"].Selected = true;
            #endregion tom item comboubox


            //        //   ComboboxItem cbx = (ComboboxItem)cb.Items[3];
            //        //     dataGridViewTkCo.Rows[i].Cells["Tk_Có"].Value = cbx.Value;
            //        if (Utils.IsValidnumber(txtsotienco.Text))
            //        {
            //            this.pssotienco = double.Parse(txtsotienco.Text);

            //        }



        }

        public void blankphieunhapkho()
        {
            #region  list black phiếu
            datepickngayphieu.Enabled = true;
            //         txtquyenso.Enabled = true;
            txtsophieu.Enabled = true;
            txttennguoinop.Enabled = true;
            txtdiachi.Enabled = true;
            txtdiengiai.Enabled = true;
            //txtsotien.Enabled = true;
            //   txtsochungtugoc.Enabled = true;
            btluu.Visible = true;
            btluu.Enabled = true;
            //    cbtaikhoanco.Enabled = true;
            cbtkno.Enabled = true;
            btsua.Enabled = false;

            txtsophieu.Text = "";
            txttennguoinop.Text = "";
            txtdiachi.Text = "";
            txtdiengiai.Text = "";
            lbid.Text = "";
            //     txtsotien.Text = "";
            //     txtsochungtugoc.Text = "";
            //     txtquyenso.Text = "";
            lbtenchitietno.Text = "";

            cbtkno.SelectedIndex = -1;
            cbtkco.SelectedIndex = -1;
            cbkhohang.SelectedIndex = -1;

            lb_machitietno.Text = "";
            lbtenchitietno.Text = "";
            //    txttaikhoanco.Text = "";

            txtsophieu.Focus();


            this.phieunhapid = -1;

            this.statusphieunhap = 1; // tạo mới
            dataGridViewTkCo = Model.Khohang.reloaddetailnewPNK(dataGridViewTkCo);
            #endregion

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
                    if (frm.Text == "BeeHtdoiungphieunhapkho")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    View.BeeHtdoiungphieunhapkho BeeHtdoiungphieunhapkho = new BeeHtdoiungphieunhapkho(this, "Địa chỉ", "", "");
                    BeeHtdoiungphieunhapkho.Show();
                }




            }


        }

        public View.Main main1;
        public BeeKhophieunhap(View.Main Main)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);  // để đọc từ bàn phím phím tắt

            this.pssotienno = 0;
            this.pssotienco = 0;
            this.main1 = Main;
            lbid.Text = "";
            this.statusphieunhap = 1; // tạo mới

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


            #region load tk nợ

            //            tien
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
                this.cbtkno.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk nợ

            //  cbtkco


            #region load tk có

            //            tien
            //kho
            //tamung
            //xacdinhkqkd
            //taisan
            //nguonvon
            //doanhthu
            //chiphi
            //loinhuan



            var rs4 = from tk in dc.tbl_dstaikhoans
                      where tk.loaitkid != "kho" && tk.loaitkid != "tien" && tk.loaitkid != "xacdinhkqkd" && tk.loaitkid != "chiphi" && tk.loaitkid != "loinhuan" && tk.loaitkid != "doanhthu"
                      select tk;

            //      string drowdownshow = "";

            foreach (var item in rs4)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk;
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                this.cbtkco.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk nợ



            #region load kho hàng

            //            tien
            //kho
            //tamung
            //xacdinhkqkd
            //taisan
            //nguonvon
            //doanhthu
            //chiphi
            //loinhuan



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
            dataGridViewTkCo = Model.Khohang.reloaddetailnewPNK(dataGridViewTkCo);

            dataGridViewListPNK.DataSource = Model.Khohang.danhsachphieunhapkho(dc);

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
                txttennguoinop.Focus();

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

        private void cbtennguoinop_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void cbtennguoinop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtdiachi.Focus();

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
                txtdiengiai.Focus();


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
                MessageBox.Show("Bạn chưa nhập chi tiết phiếu nhập !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    if (dataGridViewTkCo.Rows[idrow].Cells["Số_lượng_nhập"].Value == DBNull.Value)
                    {

                        MessageBox.Show("Bạn kiểm tra lại số lượng", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkdinhkhoan = false;
                        return;
                    }
                    else
                    {
                        if (Utils.IsValidnumber(dataGridViewTkCo.Rows[idrow].Cells["Số_lượng_nhập"].Value.ToString()) != true)
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
            var sophieunhaplap = (from p in dc.tbl_kho_phieunhap_heads
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

            if (txtdiengiai.Text == "")
            {
                MessageBox.Show("Kiểm tra diễn giải !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                txtdiengiai.Focus();
                return;

            }

            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Kiểm tra địa chỉ, bộ phận !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                txtdiachi.Focus();
                return;

            }

            if (txttennguoinop.Text == "")
            {
                MessageBox.Show("Kiểm tra tên người giao !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkdinhkhoan = false;
                txttennguoinop.Focus();
                return;

            }


            #endregion  end check chi tiết phieu thu

            #region     // save head phieu nhap
            if (checkdinhkhoan == true)
            {


                tbl_kho_phieunhap_head headphieunhap = new tbl_kho_phieunhap_head();
                headphieunhap.phieuso = txtsophieu.Text.Trim();


                headphieunhap.createby = Utils.getusername();
                headphieunhap.createdate = DateTime.Today;
                headphieunhap.diachibophan = txtdiachi.Text.Trim();
                headphieunhap.hoadondikhem = txthoadonkemtheo.Text;
                headphieunhap.makho = (cbkhohang.SelectedItem as ComboboxItem).Value.ToString();
                headphieunhap.ngayphieunhap = datepickngayphieu.Value;
                headphieunhap.nguoigiao = txttennguoinop.Text.Trim();

                headphieunhap.notk = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
                if (lb_machitietno.Text != "" & Utils.IsValidnumber(lb_machitietno.Text))
                {
                    headphieunhap.MaCTietTKNo = int.Parse(lb_machitietno.Text);
                }


                headphieunhap.cotk = (cbtkco.SelectedItem as ComboboxItem).Value.ToString();

                if (lb_machitietco.Text != "" & Utils.IsValidnumber(lb_machitietco.Text))
                {
                    headphieunhap.MaCTietTKCo = int.Parse(lb_machitietco.Text);
                }

                dc.tbl_kho_phieunhap_heads.InsertOnSubmit(headphieunhap);
                dc.SubmitChanges();

                headphieunhap = null;

            }
            #endregion   /// save head phieu nhap


            #region data detail phieu nhap

            ////   dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DGV_DateTimePicker.DateTimePickerCell)));
            //dt.Columns.Add(new DataColumn("masanpham", typeof(string)));
            //dt.Columns.Add(new DataColumn("Tên_sản_phẩm", typeof(string)));

            //dt.Columns.Add(new DataColumn("Đơn_vị", typeof(string)));
            //dt.Columns.Add(new DataColumn("Số_lượng_nhập", typeof(string)));

            ////Threahold
            ////      dt.Columns.Add(new DataColumn("Tk_Có", typeof(double)));
            //dt.Columns.Add(new DataColumn("Đơn_giá", typeof(double)));
            //dt.Columns.Add(new DataColumn("Thành_tiền", typeof(double)));
            //if (cbtkno.SelectedItem == null)
            //{

            //    MessageBox.Show("Bạn chua định khoản tài khoản tiền mặt", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    checkdinhkhoanco = false;
            //    return;
            //}

            #endregion


            #region   // save  detail phieu nhap
            for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            {

                tbl_kho_phieunhap_detail detail = new tbl_kho_phieunhap_detail();

                detail.dongia = float.Parse(dataGridViewTkCo.Rows[idrow].Cells["Đơn_giá"].Value.ToString());
                detail.donvi = dataGridViewTkCo.Rows[idrow].Cells["Đơn_vị"].Value.ToString();
                detail.mahang = dataGridViewTkCo.Rows[idrow].Cells["masanpham"].Value.ToString();
                detail.phieuso = txtsophieu.Text.Trim();
                detail.soluongnhap = float.Parse(dataGridViewTkCo.Rows[idrow].Cells["Số_lượng_nhập"].Value.ToString());
                detail.tenhang = dataGridViewTkCo.Rows[idrow].Cells["Tên_sản_phẩm"].Value.ToString();
                detail.thanhtien = float.Parse(dataGridViewTkCo.Rows[idrow].Cells["Thành_tiền"].Value.ToString());


                dc.tbl_kho_phieunhap_details.InsertOnSubmit(detail);
                dc.SubmitChanges();
                detail = null;


            }
            #endregion   /// save  detail phieu nhap


            // save so cái phiếu nhập
            tbl_Socai socai = new tbl_Socai();
            //socai.nghiepvuso = txtsophieu.Text.Trim();


            //headphieunhap.createby = Utils.getusername();
            //headphieunhap.createdate = DateTime.Today;
            //headphieunhap.diachibophan = txtdiachi.Text.Trim();
            //headphieunhap.hoadondikhem = txthoadonkemtheo.Text;
            //headphieunhap.makho = (cbkhohang.SelectedItem as ComboboxItem).Value.ToString();
            //headphieunhap.ngayphieunhap = datepickngayphieu.Value;
            //headphieunhap.nguoigiao = txttennguoinop.Text.Trim();

            //headphieunhap.notk = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
            //if (lb_machitietno.Text != "" & Utils.IsValidnumber(lb_machitietno.Text))
            //{
            //    headphieunhap.MaCTietTKNo = int.Parse(lb_machitietno.Text);
            //}


            //headphieunhap.cotk = (cbtkco.SelectedItem as ComboboxItem).Value.ToString();

            //if (lb_machitietco.Text != "" & Utils.IsValidnumber(lb_machitietco.Text))
            //{
            //    headphieunhap.MaCTietTKCo = int.Parse(lb_machitietco.Text);
            //}

            //dc.tbl_kho_phieunhap_heads.InsertOnSubmit(headphieunhap);
            //dc.SubmitChanges();

            //headphieunhap = null;


            /// save so cái phiếu nhập


            //      MessageBox.Show("Số phiếu vừa lưu: " + this.sophieunhap, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.blankphieunhapkho();

            dataGridViewListPNK.DataSource = Model.Khohang.danhsachphieunhapkho(dc);

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

            string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
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


        private void cbtaikhoanco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.blankphieunhapkho();


            //      dataGridViewTkCo = Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);

        }

        private void button5_Click(object sender, EventArgs e)
        {

            string username = Utils.getusername();

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rptpthu = from phieuthud in dc.Rpt_PhieuThus
                          where phieuthud.username == username
                          select phieuthud;

            dc.Rpt_PhieuThus.DeleteAllOnSubmit(rptpthu);
            dc.SubmitChanges();


            var phieuthu = (from tbl_SoQuy in dc.tbl_SoQuys
                            where tbl_SoQuy.id == this.phieunhapid
                            select new
                            {

                                //     tencongty = Model.Congty.getnamecongty(),
                                //     diachicongty = Model.Congty.getdiachicongty(),
                                ////     masothue = Model.Congty.getmasothuecongty(),
                                //   tengiamdoc = Model.Congty.gettengiamdoccongty(),
                                //    tenketoantruong = Model.Congty.gettenketoantruongcongty(),

                                sophieuthu = tbl_SoQuy.Sophieu,
                                ngaychungtu = tbl_SoQuy.Ngayctu,
                                nguoinoptien = tbl_SoQuy.Nguoinopnhantien,
                                //    nguoilapphieu = Utils.getname(),
                                diachinguoinop = tbl_SoQuy.Diachinguoinhannop,
                                lydothu = tbl_SoQuy.Diengiai,
                                sotien = tbl_SoQuy.PsNo,
                                //   sotienbangchu = Utils.ChuyenSo(tbl_SoQuy.PsNo.ToString()),
                                sochungtugoc = tbl_SoQuy.Chungtugockemtheo,
                                //    username = Utils.getusername(),

                                tkno = tbl_SoQuy.TKtienmat,
                                tkco = tbl_SoQuy.TKdoiung,
                           
                            }).FirstOrDefault();

            //   this.dataGridViewListphieuthu.DataSource = phieuthu;

            #region  view reports payment request  

            //Control_ac ctrac = new Control_ac();

            //var rs1 = ctrac.KArptdataset1(dc);
            //var rs2 = ctrac.KArptdataset2(dc);



            if (phieuthu != null)
            {


                #region  insert vao rpt phieu thu

                Rpt_PhieuThu pt = new Rpt_PhieuThu();
                pt.tencongty = Model.Congty.getnamecongty();
                pt.diachicongty = Model.Congty.getdiachicongty();
                pt.masothue = Model.Congty.getmasothuecongty();
                pt.tengiamdoc = Model.Congty.gettengiamdoccongty();
                pt.tenketoantruong = Model.Congty.gettenketoantruongcongty();
                pt.phieuthuso = phieuthu.sophieuthu;
                pt.ngaychungtu = phieuthu.ngaychungtu;
                pt.nguoinoptien = phieuthu.nguoinoptien;
                pt.nguoilapphieu = Utils.getname();
                pt.diachinguoinop = phieuthu.diachinguoinop;
                pt.lydothu = phieuthu.lydothu;
                pt.sotien = phieuthu.sotien;
                pt.sotienbangchu = Utils.ChuyenSo(decimal.Parse(phieuthu.sotien.ToString()));
                pt.sochungtugoc = phieuthu.sochungtugoc;
                pt.username = Utils.getusername();
                pt.tkno = phieuthu.tkno;
                pt.tkco = phieuthu.tkco;
           
                dc.Rpt_PhieuThus.InsertOnSubmit(pt);
                dc.SubmitChanges();
                #endregion

                var rsphieuthu = from tblRpt_PhieuThu in dc.Rpt_PhieuThus
                                 where tblRpt_PhieuThu.username == username
                                 select tblRpt_PhieuThu;


                Utils ut = new Utils();
                var dataset1 = ut.ToDataTable(dc, rsphieuthu);

                Reportsview rpt = new Reportsview(dataset1, null, "Phieuthu.rdlc");
                rpt.ShowDialog();

            }

            #endregion view reports payment request  // 

        }

        private void dataGridViewListphieuthu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //#region load tk nợ
            List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            var rs = from tbl_dstaikhoan in dc.tbl_dstaikhoans
                     where tbl_dstaikhoan.loaitkid == "tien" // tien mat la loai 8
                     orderby tbl_dstaikhoan.matk
                     select tbl_dstaikhoan;
            foreach (var item in rs)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk.Trim();
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                CombomCollection.Add(cb);
            }

            cbtkno.DataSource = CombomCollection;

            //#endregion load tk nợ



            try
            {
                this.phieunhapid = (int)this.dataGridViewListPNK.Rows[this.dataGridViewListPNK.CurrentCell.RowIndex].Cells["ID"].Value;


            }
            catch (Exception)
            {

                this.phieunhapid = 0;
            }

            if (this.phieunhapid != 0)
            {



                #region view load form
                var phieuthu = (from tbl_SoQuy in dc.tbl_SoQuys
                                where tbl_SoQuy.id == this.phieunhapid
                                select new
                                {

                                    //     tencongty = Model.Congty.getnamecongty(),
                                    //     diachicongty = Model.Congty.getdiachicongty(),
                                    ////     masothue = Model.Congty.getmasothuecongty(),
                                    //   tengiamdoc = Model.Congty.gettengiamdoccongty(),
                                    //    tenketoantruong = Model.Congty.gettenketoantruongcongty(),

                                    sophieuthu = tbl_SoQuy.Sophieu,
                                    ngaychungtu = tbl_SoQuy.Ngayctu,
                                    nguoinoptien = tbl_SoQuy.Nguoinopnhantien,
                                    //    nguoilapphieu = Utils.getname(),
                                    diachinguoinop = tbl_SoQuy.Diachinguoinhannop,
                                    lydothu = tbl_SoQuy.Diengiai,
                                    sotien = tbl_SoQuy.PsNo,
                                    //   sotienbangchu = Utils.ChuyenSo(tbl_SoQuy.PsNo.ToString()),
                                    sochungtugoc = tbl_SoQuy.Chungtugockemtheo,
                                    //    username = Utils.getusername(),

                               
                                    machitietno = tbl_SoQuy.ChitietTM,
                                    tentkchitiet = tbl_SoQuy.TenchitietTM,
                                    tkno = tbl_SoQuy.TKtienmat,

                                    taikhoandoiung = tbl_SoQuy.TKdoiung,

                                }).FirstOrDefault();


                if (phieuthu != null)
                {
                    datepickngayphieu.Value = phieuthu.ngaychungtu;
                    txtsophieu.Text = phieuthu.sophieuthu.ToString();
                    txttennguoinop.Text = phieuthu.nguoinoptien;
                    txtdiachi.Text = phieuthu.diachinguoinop;
                    txtdiengiai.Text = phieuthu.lydothu;
                    //        txtsotien.Text = double.Parse(phieuthu.sotien.ToString()).ToString("#,#", CultureInfo.InvariantCulture);
                    //txtValueSotienNo.Text = phieuthu.sotien.ToString();
                    this.pssotienno = double.Parse(phieuthu.sotien.ToString());


                    //       txtsochungtugoc.Text = phieuthu.sochungtugoc.ToString();

                    //          txttaikhoanco.Text = phieuthu.taikhoandoiung;

                    if (phieuthu.machitietno != null)
                    {
                        lb_machitietno.Text = phieuthu.machitietno.ToString();
                    }
                    else
                    {
                        lb_machitietno.Text = "";

                    }

                    if (phieuthu.tentkchitiet != null)
                    {
                        lbtenchitietno.Text = phieuthu.tentkchitiet.ToString();
                    }
                    else
                    {
                        lbtenchitietno.Text = "";

                    }


                    foreach (ComboboxItem item in (List<ComboboxItem>)cbtkno.DataSource)
                    {
                        if (item.Value.ToString().Trim() == phieuthu.tkno.Trim())
                        {
                            cbtkno.SelectedItem = item;
                        }
                    }





                    //if (phieuthu.quyenso != null)
                    //{
                    //    txtquyenso.Text = phieuthu.quyenso.ToString();
                    //}
                    //else
                    //{
                    //    txtquyenso.Text = "";
                    //}


                    datepickngayphieu.Enabled = false;
                    txtsophieu.Enabled = false;
                    txttennguoinop.Enabled = false;
                    txtdiachi.Enabled = false;
                    txtdiengiai.Enabled = false;
                    //       txtsotien.Enabled = false;
                    //       txtsochungtugoc.Enabled = false;

                    btsua.Enabled = true;
                    //        txtquyenso.Enabled = false;




                    cbtkno.Enabled = false;



                    this.statusphieunhap = 3;// View
                                             //      Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);
                                             //        Model.Phieuthuchi.reloaddetailtaikhoancophieuthu(this.dataGridViewTkCo, this, phieuthu.tkno.Trim(), phieuthu.sophieuthu);
                    btluu.Visible = false;

                }



                #endregion view load form









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


            var phieunhaphead = (from p in dc.tbl_kho_phieunhap_heads
                                 where p.id == this.phieunhapid
                                 select p).FirstOrDefault();

            #region CÓ SỐ PHIÊU


            if (phieunhaphead != null)
            {
                this.phieunhapid = phieunhaphead.id;

                dc.tbl_kho_phieunhap_heads.DeleteOnSubmit(phieunhaphead);
                dc.SubmitChanges();


                #region      // xóa đetail phiếu nhâp

                var phieunhapdetail = from p in dc.tbl_kho_phieunhap_details
                                      where p.subid == this.phieunhapid
                                      select p;

                if (phieunhapdetail.Count() > 0)
                {
                    dc.tbl_kho_phieunhap_details.DeleteAllOnSubmit(phieunhapdetail);
                    dc.SubmitChanges();

                }
                #endregion     //    phieunhapdetail

                #region // xóa sổ cái

                //      Model.Socaitaikhoan.xoa("PT", phieunhapkho.Sochungtu);

                #endregion                // xóa sổ cái nưa


                // xóa detail


                MessageBox.Show("Đã xóa phiếu: " + this.sophieunhap, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //  Model.
                #region load list listphieunhapkho

                var listphieunhapkho = Model.Khohang.danhsachphieunhapkho(dc);


                dataGridViewListPNK.DataSource = listphieunhapkho;
                #endregion


            }
            else
            {
                MessageBox.Show("Phiếu: " + this.sophieunhap + " không tồn tại !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            #endregion có số phiếu




        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.statusphieunhap = 2;

            btluu.Visible = true;


            datepickngayphieu.Enabled = true;


            txtsophieu.Enabled = true;
            if (txtsophieu.Text != "")
            {
                this.sophieunhap = txtsophieu.Text.ToString();
                this.maphieuthuOld = int.Parse(txtsophieu.Text.ToString());
            }


            //  txtquyenso.Enabled = true;

            txttennguoinop.Enabled = true;
            txtdiachi.Enabled = true;
            txtdiengiai.Enabled = true;
            //    txtsotien.Enabled = true;
            //    txtsochungtugoc.Enabled = true;
            btluu.Enabled = true;

            //   cbtaikhoanco.Enabled = true;
            cbtkno.Enabled = true;

            this.statusphieunhap = 2;

        }

        private void txtsophieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                txttennguoinop.Focus();

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
                txtdiachi.Focus();

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
                txtdiengiai.Focus();

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
            this.pssotienco = tongcong;
            txtsotienco.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);
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
                dataGridViewTkCo.Rows[i].Cells["Thành_tiền"].Value = float.Parse(dataGridViewTkCo.Rows[i].Cells["Số_lượng_nhập"].Value.ToString()) * float.Parse(dataGridViewTkCo.Rows[i].Cells["Đơn_giá"].Value.ToString());

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
            if (Utils.IsValidnumber(txtsotienco.Text.ToString()))
            {
                this.pssotienco = double.Parse(txtsotienco.Text);
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
            this.pssotienco = tongcong;
            txtsotienco.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);
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
    }
}

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
    public partial class TaodonDHtheoSP : Form
    {
        public static DataGridView reloaddetailnew(DataGridView gridviewDH, string maKH)
        {



            gridviewDH.DataSource = null;

            #region datatable temp


            DataTable dt = new DataTable();



            //   dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DGV_DateTimePicker.DateTimePickerCell)));
            dt.Columns.Add(new DataColumn("masanpham", typeof(string)));
            dt.Columns.Add(new DataColumn("Tên_sản_phẩm", typeof(string)));

            dt.Columns.Add(new DataColumn("Đơn_vị", typeof(string)));
            dt.Columns.Add(new DataColumn("Số_lượng", typeof(double)));
            dt.Columns.Add(new DataColumn("Nhóm_sản_phẩm", typeof(double)));



            gridviewDH.DataSource = dt;


            //DGV_DateTimePicker.DateTimePickerColumn col = new DGV_DateTimePicker.DateTimePickerColumn();
            //col.HeaderText = "Ngày chứng từ";
            //col.Name = "Ngày_chứng_từ";
            //col.DataPropertyName = "ngayctuhide";
            //dataGridViewdetailPNK.Columns.Add(col);


            //    dataGridViewTkCo.Columns.Remove("Tk_Có");

            #region  //  mã sản phẩm
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();


            List<View.TaodonDHtheoSP.ComboboxItem> CombomCollection = new List<View.TaodonDHtheoSP.ComboboxItem>();

            string macty = Model.Username.getmacty();

            var rs = from p in dc.tbl_GiaHDtheoMCTvaSPs
                     where p.macty == macty && p.maKH == maKH
                     
                     orderby p.maSP
                     select p;
            foreach (var item in rs)
            {
                View.TaodonDHtheoSP.ComboboxItem cb = new View.TaodonDHtheoSP.ComboboxItem();
                cb.Value = item.maSP;
                cb.Text = item.maSP.Trim() + ": " + item.TENHANG;
                CombomCollection.Add(cb);
            }

            cmbdgv.DataSource = CombomCollection;
            cmbdgv.HeaderText = "Mã_sản_phẩm";
            cmbdgv.Name = "Mã_sản_phẩm";
            cmbdgv.ValueMember = "Value";
            cmbdgv.DisplayMember = "Text";
            cmbdgv.Width = 300;
            cmbdgv.DropDownWidth = 300;
            cmbdgv.DataPropertyName = "masanpham"; //Bound value to the datasource


            gridviewDH.Columns.Add(cmbdgv);





            #endregion binddata

            //gridviewDH.Columns["masanpham"].Visible = false;
            //dataGridViegridviewDHwdetailPXK.Columns["Mã_sản_phẩm"].DisplayIndex = 0;

            //dataGridViewdetailPXK.Columns["Tên_sản_phẩm"].ReadOnly = true;
            //dataGridViewdetailPXK.Columns["Đơn_vị"].ReadOnly = true;

            //dataGridViewdetailPXK.Columns["Tên_sản_phẩm"].DefaultCellStyle.BackColor = Color.LightGray;
            //dataGridViewdetailPXK.Columns["Đơn_vị"].DefaultCellStyle.BackColor = Color.LightGray;

            //dataGridViewdetailPXK.Columns["Số_lượng_xuất"].DefaultCellStyle.Format = "N0"; // để hiện số có dấu phảy
            //dataGridViewdetailPXK.Columns["Đơn_giá"].DefaultCellStyle.Format = "N0";
            //dataGridViewdetailPXK.Columns["Thành_tiền"].DefaultCellStyle.Format = "N0";


            //dataGridViewdetailPXK.Columns["Số_lượng_xuất"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // để hiện số có dấu phảy
            //dataGridViewdetailPXK.Columns["Đơn_giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewdetailPXK.Columns["Thành_tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

           



            #endregion datatable temp


            return gridviewDH;





            //  throw new NotImplementedException();
        }

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


            DataTable dataTable = (DataTable)gridviewDH.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            //  drToAdd["mahang"] = sanpham.mahang;
            drToAdd["Số_lượng_nhập"] = sanpham.soluongnhap;
            drToAdd["Đơn_giá"] = sanpham.dongia;
            drToAdd["Tên_sản_phẩm"] = sanpham.tenhang;

            drToAdd["Đơn_vị"] = sanpham.donvi;

            drToAdd["Thành_tiền"] = sanpham.thanhtien;



            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();



            int i = dataTable.Rows.Count - 1;

            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)gridviewDH.Rows[i].Cells["Mã_sản_phẩm"];
            DataGridViewCell dgvc = (DataGridViewCell)gridviewDH.Rows[i].Cells["Mã_sản_phẩm"];

            #region tim item comboboc

            foreach (ComboboxItem item in (List<ComboboxItem>)cb.DataSource)
            {

                if (item.Value.ToString().Trim() == sanpham.mahang.ToString().Trim())
                {

                    gridviewDH.Rows[i].Cells["Mã_sản_phẩm"].Value = item.Value;
                    //      cb.Selected = true;
                    //  cb.inde = true;
                }


            }

            //      dataGridViewTkCo.Rows[i].Cells["Số_lượng_nhập"].Value = 
            gridviewDH.Rows[i].Cells["Đơn_giá"].Selected = true;
            #endregion tom item comboubox





        }

        public void blankphieunhapkho()
        {
            #region  list black phiếu
            datepickngayphieu.Enabled = true;
      
            txtsophieu.Enabled = true;
      
            txtsophieu.Text = "";
            cbsanpham.Text = "";
            cbsanpham.SelectedIndex = -1;
            txtkhachhang.Text = "";

            txtsoluong.Text = "";

            txtsophieu.Focus();

           // this.makho = null;
        
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





                //FormCollection fc = System.Windows.Forms.Application.OpenForms;

                //bool kq = false;
                //foreach (Form frm in fc)
                //{
                //    if (frm.Text == "BeeSeach")


                //    {
                //        kq = true;
                //        frm.Focus();

                //    }
                //}

                //if (!kq)
                //{
                //    //               View.BeeSeachtwofield sheaching = new BeeSeachtwofield(this, "Người nôp", "Địa chỉ", "Nội dung");
                //    //             sheaching.Show();
                //}




            }


            if (e.Control == true && e.KeyCode == Keys.N)
            {





                //FormCollection fc = System.Windows.Forms.Application.OpenForms;

                //bool kq = false;
                //foreach (Form frm in fc)
                //{
                //    if (frm.Text == "BeeHtdoiungphieunhapkho")


                //    {
                //        kq = true;
                //        frm.Focus();

                //    }
                //}

                //if (!kq)
                //{
                //  //  View.BeeHtdoiungphieunhapkho BeeHtdoiungphieunhapkho = new BeeHtdoiungphieunhapkho(, "Địa chỉ", "", "");
                //  //  BeeHtdoiungphieunhapkho.Show();
                //}




            }


        }

        public View.Main main1;

        public TaodonDHtheoSP(View.Main Main, string macty, string maKH)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);  // để đọc từ bàn phím phím tắt

      
            this.main1 = Main;
       
            lbmaKH.Text = maKH;

            Model.Username used = new Model.Username();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            string username = Utils.getusername();

            gridviewDH = reloaddetailnew(gridviewDH, maKH);


            #region load mã sản phẩm



            //var rs2 = from tk in dc.tbl_GiaHDtheoMCTvaSPs
            //          where tk.loaitkid == "kho" // mã 8 là tiền mặt
            //          select tk;

            ////      string drowdownshow = "";

            //foreach (var item in rs2)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.matk;
            //    cb.Text = item.matk.Trim() + ": " + item.tentk;
            //    this.cbtkno.Items.Add(cb); // CombomCollection.Add(cb);

            //}

            //#endregion load tk nợ

            //  cbtkco


            //#region load tk có




            //var rs4 = from tk in dc.tbl_dstaikhoans
            //          where tk.loaitkid != "kho"
            //          select tk;

            ////      string drowdownshow = "";

            //foreach (var item in rs4)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.matk;
            //    cb.Text = item.matk.Trim() + ": " + item.tentk;
            //    this.cbtkco.Items.Add(cb); // CombomCollection.Add(cb);

            //}

            //#endregion load tk có



            //#region load kho hàng


            //var rs3 = from p in dc.tbl_khohangs
            //              //    where p.loaitkid == "kho" // mã 8 là tiền mặt
            //          select p;

            ////      string drowdownshow = "";

            //foreach (var item in rs3)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.makho;
            //    cb.Text = item.tenkho; //item.makho.Trim() + ": " +
            //    this.cbkhohang.Items.Add(cb); // CombomCollection.Add(cb);

            //}

            //#endregion load kho hàng



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
                //txttennguoigiao.Focus();

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
                //txtdonhang.Focus();

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
                //txtdiengiai.Focus();


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

        



            this.blankphieunhapkho();

         //   dataGridViewListPNK.DataSource = Model.Khohang.danhsachphieunhapkho(dc);
        //    MessageBox.Show("Số phiếu vừa lưu: " + this.sophieunhap, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridViewListphieuthu_Paint(object sender, PaintEventArgs e)
        {

            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns





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

       //    string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
            //     this.matk = taikhoan;


          

            //    dataGridViewTkCo.Focus();

        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.blankphieunhapkho();

            tabControl1.SelectedTab = tabPage1;
            //      dataGridViewTkCo = Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);

        }

        private void button5_Click(object sender, EventArgs e)
        {

            string username = Utils.getusername();

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var xoahead = from p in dc.Rptphieunhapkhoheads
                          where p.username == username
                          select p;
            if (xoahead != null)
            {
                dc.Rptphieunhapkhoheads.DeleteAllOnSubmit(xoahead);
                dc.SubmitChanges();

            }



            var xoadetail = from p in dc.Rptphieunhapkhodetail01s
                            where p.username == username
                            select p;

            dc.Rptphieunhapkhodetail01s.DeleteAllOnSubmit(xoadetail);
            dc.SubmitChanges();







        }

        private void dataGridViewListphieuthu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //#region  danh sahc kho
            ////#region load tk nợ
            //List<ComboboxItem> cbcolectionkho = new List<ComboboxItem>();
            //var dskho = from p in dc.tbl_khohangs
            //                //   where p.loaitkid.Trim() == "kho" // tien mat la loai 8
            //            orderby p.makho
            //            select p;
            //foreach (var item in dskho)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.makho.Trim();
            //    cb.Text = item.tenkho; //item.makho.Trim() + ": " + 
            //    cbcolectionkho.Add(cb);
            //}

            ////cbkhohang.DataSource = cbcolectionkho;


            //#endregion
     
      




        }

        private void dataGridViewListphieuthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            // nút xóa
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);




        }

        private void button2_Click(object sender, EventArgs e)
        {

       

            datepickngayphieu.Enabled = true;
            //cbtkco.Enabled = true;

       
        }

        private void txtsophieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
           //    txttennguoigiao.Focus();

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
                //txtdonhang.Focus();

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
                //txtdiengiai.Focus();

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
                //cbtkno.Focus();

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

            foreach (var c in gridviewDH.Columns)
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
                    string colname = this.gridviewDH.Columns[this.gridviewDH.CurrentCell.ColumnIndex].Name;

                    //   dataGridViewTkCo.Rows[i].Cells[colname].Value = SelectedItem;

                    gridviewDH.Rows[i].Cells[colname].Value = SelectedItem;

                    string connection_string = Utils.getConnectionstr();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                    var sp = (from p in dc.tbl_kho_sanphams
                              where p.masp == SelectedItem
                              orderby p.masp
                              select p).FirstOrDefault();

                    if (sp != null)
                    {
                        gridviewDH.Rows[i].Cells["Tên_sản_phẩm"].Value = sp.tensp;
                        gridviewDH.Rows[i].Cells["Đơn_vị"].Value = sp.donvi;

                    }
                    else
                    {
                        gridviewDH.Rows[i].Cells["Tên_sản_phẩm"].Value = "";
                        gridviewDH.Rows[i].Cells["Đơn_vị"].Value = "";

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


                currentCell = this.gridviewDH.CurrentCell;




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


            //#region  view lai số tiền


            //double tongcong = 0;


            //for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            //{


            //    if (dataGridViewTkCo.Rows[idrow].Cells["Thành_tiền"] != null)

            //    {
            //        if (Utils.IsValidnumber(dataGridViewTkCo.Rows[idrow].Cells["Thành_tiền"].Value.ToString()))
            //        {

            //            tongcong += double.Parse(dataGridViewTkCo.Rows[idrow].Cells["Thành_tiền"].Value.ToString());
            //        }
            //    }







            //}

            ////txtValueSotienCo.Text = tongcong.ToString();
            //this.sotien = tongcong;
            ////txtsotiendisplay.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);
            //#endregion



            //  }







        }

        private void dataGridViewTkCo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            int i = view.CurrentRow.Index;
            string colname = view.Columns[view.CurrentCell.ColumnIndex].Name;

            try
            {
                gridviewDH.Rows[i].Cells["Thành_tiền"].Value = float.Parse(gridviewDH.Rows[i].Cells["Số_lượng_nhập"].Value.ToString()) * float.Parse(gridviewDH.Rows[i].Cells["Đơn_giá"].Value.ToString());

            }
            catch (Exception)
            {

            //    gridviewDH.Rows[i].Cells["Thành_tiền"].Value = 0;
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

          //  string taikhoan = (cbtkco.SelectedItem as ComboboxItem).Value.ToString();
            //     this.matk = taikhoan;


         
            //    dataGridViewTkCo.Focus();
        }

        private void dataGridViewListPNK_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            tabControl1.SelectedTab = tabPage1;
        }

        private void cbkhohang_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cbkhohang.SelectedItem != null)
            //{
            //    this.makho = (cbkhohang.SelectedItem as ComboboxItem).Value.ToString();

            //}

            //dataGridViewTkCo = Model.Khohang.reloaddetailnewPNK(dataGridViewTkCo, this.makho);


        }
    }
}

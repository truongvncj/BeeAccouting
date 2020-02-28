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
    public partial class BeePhaithu : Form
    {
        public int statusphieu { get; set; } // 1 mới  // 2 suawra // 3 display //
        public int buttoanid { get; set; }
        public string sobuttoan { get; set; }

        //   public string makho { get; set; }
        public string tkno { get; set; }
        public int tknochitiet { get; set; }
        public string tkco { get; set; }
        public int tkcochitiet { get; set; }
        public double sotien { get; set; }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }


        public void add_detailGridviewexample(tbl_Socai socai)
        {





            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            DataTable dataTable = (DataTable)dataGridViewdetailexample.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            #region datatable temp




            //DataTable dt = new DataTable();

            //dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DateTime))); //adding column for combobox
            //dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(string)));
            //dt.Columns.Add(new DataColumn("Diễn_giải", typeof(string)));

            //dt.Columns.Add(new DataColumn("Nợ_TK", typeof(string)));
            //dt.Columns.Add(new DataColumn("Có_TK", typeof(string)));

            //dt.Columns.Add(new DataColumn("Số_tiền", typeof(double)));


            //dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Nợ", typeof(int)));
            //dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Có", typeof(string)));

            //dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Nợ", typeof(int)));
            //dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Có", typeof(string)));


            #endregion datatable temp


            drToAdd["Ngày_chứng_từ"] = socai.Ngayctu;
            drToAdd["Số_chứng_từ"] = socai.Sohieuchungtu;
            drToAdd["Diễn_giải"] = socai.Diengiai.Trim();

            drToAdd["Nợ_TK"] = socai.TkNo;

            drToAdd["Có_TK"] = socai.TkCo;


            if (socai.PsCo != null)
            {
                drToAdd["Số_tiền"] = socai.PsCo;
            }



            if (socai.MaCTietTKNo != null)
            {
                drToAdd["Mã_chi_tiết_TK_Nợ"] = socai.MaCTietTKNo;
            }


            if (socai.MaCTietTKCo != null)
            {
                drToAdd["Mã_chi_tiết_TK_Có"] = socai.MaCTietTKCo;
            }

            drToAdd["Tên_chi_tiết_TK_Nợ"] = socai.tenchitietNo;
            drToAdd["Tên_chi_tiết_TK_Có"] = socai.tenchitietCo;



            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();




        }

        public void add_detailGridviewcurrent(tbl_Socai socai)
        {





            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            DataTable dataTable = (DataTable)dataGridViewdetail.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            #region datatable temp




            //DataTable dt = new DataTable();

            //dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DateTime))); //adding column for combobox
            //dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(string)));
            //dt.Columns.Add(new DataColumn("Diễn_giải", typeof(string)));

            //dt.Columns.Add(new DataColumn("Nợ_TK", typeof(string)));
            //dt.Columns.Add(new DataColumn("Có_TK", typeof(string)));

            //dt.Columns.Add(new DataColumn("Số_tiền", typeof(double)));


            //dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Nợ", typeof(int)));
            //dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Có", typeof(string)));

            //dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Nợ", typeof(int)));
            //dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Có", typeof(string)));


            #endregion datatable temp


            drToAdd["Ngày_chứng_từ"] = socai.Ngayctu;
            drToAdd["Số_chứng_từ"] = socai.Sohieuchungtu;
            drToAdd["Diễn_giải"] = socai.Diengiai.Trim();

            drToAdd["Nợ_TK"] = socai.TkNo;

            drToAdd["Có_TK"] = socai.TkCo;


            if (socai.PsCo != null)
            {
                drToAdd["Số_tiền"] = socai.PsCo;
            }



            if (socai.MaCTietTKNo != null)
            {
                drToAdd["Mã_chi_tiết_TK_Nợ"] = socai.MaCTietTKNo;
            }


            if (socai.MaCTietTKCo != null)
            {
                drToAdd["Mã_chi_tiết_TK_Có"] = socai.MaCTietTKCo;
            }

            drToAdd["Tên_chi_tiết_TK_Nợ"] = socai.tenchitietNo;
            drToAdd["Tên_chi_tiết_TK_Có"] = socai.tenchitietCo;



            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();




        }


        public void blankbuttoantonghop()
        {
            #region  list black phiếu
            datepickngayphieu.Enabled = true;

            txtsophieu.Enabled = true;

            txtdiengiai.Enabled = true;
            txtsotien.Enabled = true;

            btluu.Visible = true;
            btluu.Enabled = true;

            cbtkno.Enabled = true;
            cbtkco.Enabled = true;
            btsua.Enabled = false;

            txtsotien.Text = "";
            txtsophieu.Text = "";

            txtdiengiai.Text = "";

            cbtkno.SelectedIndex = -1;
            cbtkco.SelectedIndex = -1;

            lb_machitietno.Text = "";
            lbtenchitietno.Text = "";

            lb_machitietco.Text = "";
            lbtenchitietco.Text = "";

            txtsophieu.Focus();


            this.buttoanid = -1;

            this.statusphieu = 1; // tạo mới

            dataGridViewdetailexample = Model.hachtoantonghop.reloaddetailnewbuttoanexample(dataGridViewdetailexample);

            dataGridViewdetail = Model.hachtoantonghop.reloaddetailnewbuttoandetail(dataGridViewdetail);
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
                    //     View.BeeHtdoiungphieunhapkho BeeHtdoiungphieunhapkho = new BeeHtdoiungphieunhapkho(this, "Địa chỉ", "", "");
                    //   BeeHtdoiungphieunhapkho.Show();
                }




            }


        }

        public View.Main main1;

        public BeePhaithu(View.Main Main)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);  // để đọc từ bàn phím phím tắt

            this.sotien = 0;
            //   this.pssotienco = 0;
            this.main1 = Main;
            //lbid.Text = "";
            this.statusphieu = 1; // tạo mới
                                  //     txtsotiensave.Visible = false;

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


            var rs2 = from tk in dc.tbl_dstaikhoans
                          //      where tk.loaitkid == "kho" // mã 8 là tiền mặt
                      select tk;

            //      string drowdownshow = "";

            foreach (var item in rs2)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk;
                cb.Text = item.matk.Trim() + ": " + item.tentk.Trim();
                this.cbtkno.Items.Add(cb); // CombomCollection.Add(cb);

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
                cb.Text = item.matk.Trim() + ": " + item.tentk.Trim();
                this.cbtkco.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk có




            //       dataGridViewTkCo.DataSource = Model.Khohang.danhsachphieunhapkho(dc);
            dataGridViewdetailexample = Model.hachtoantonghop.reloaddetailnewbuttoanexample(dataGridViewdetailexample);


            dataGridViewdetail = Model.hachtoantonghop.reloaddetailnewbuttoandetail(dataGridViewdetail);

            dataGridViewListBTTH.DataSource = Model.hachtoantonghop.danhsachbuttoantonghop(dc);


            dataGridViewListBTTH.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";
            dataGridViewListBTTH.Columns["Số_tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // để hiện số có dấu phảy


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
                //       txttennguoigiao.Focus();

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
                //  cbsophieu.
                //   e.Handled = true;
                txtsophieu.Focus();


            }



        }

        private void cbtennguoinop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                //  txtdonhang.Focus();

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
                e.Handled = true;
                //  cbtaikhoanco.Focus();
                cbtkco.Focus();
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
                e.Handled = true;
                //   datepickngayphieu.Focus();
                cbtkno.Focus();
                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void button1_Click(object sender, EventArgs e)  // new phieu 
        {

            bool checkbuttoan = true;

     
            if (dataGridViewdetail.RowCount - 1 == 0)
            {
                MessageBox.Show("Bạn chưa chưa có định khoản chi tiết !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkbuttoan = false;
                dataGridViewdetail.Focus();
                return;
            }

            #region datatable temp

            //DataTable dt = new DataTable();

            //dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DateTime))); //adding column for combobox
            //dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(string)));
            //dt.Columns.Add(new DataColumn("Diễn_giải", typeof(string)));

            //dt.Columns.Add(new DataColumn("Nợ_TK", typeof(string)));
            //dt.Columns.Add(new DataColumn("Có_TK", typeof(string)));

            //dt.Columns.Add(new DataColumn("Số_tiền", typeof(double)));


            //dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Nợ", typeof(int)));
            //dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Có", typeof(string)));

            //dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Nợ", typeof(int)));
            //dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Có", typeof(string)));


            #endregion datatable temp




            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            if (checkbuttoan == true)
            {
                #region  check từng dòng chi tiết phiếu nhập
                for (int idrow = 0; idrow < dataGridViewdetail.RowCount - 1; idrow++)
                {

                    if (dataGridViewdetail.Rows[idrow].Cells["Số_chứng_từ"].Value != DBNull.Value)
                    {

                        string Sochungtu = dataGridViewdetail.Rows[idrow].Cells["Số_chứng_từ"].Value.ToString();
                        this.sobuttoan = dataGridViewdetail.Rows[idrow].Cells["Số_chứng_từ"].Value.ToString();

                        var listbtthlap = (from p in dc.tbl_Socais
                                           where (p.Sohieuchungtu.Trim() == Sochungtu.Trim()
                                                 && (p.manghiepvu == "TH"))
                                           select p).FirstOrDefault();

                        if (listbtthlap != null)
                        {
                            MessageBox.Show("Bút toán có số bị lặp, bạn xem lại số chứng từ !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtsophieu.Focus();
                            return;
                        }



                    }// nếu là dòng data có masan phẩm





                }

                #endregion
                #region   // save  detail but toán
                for (int idrow = 0; idrow < dataGridViewdetail.RowCount - 1; idrow++)
                {
                    tbl_Socai detail = new tbl_Socai();



                    //       detail.Ngayctu = Utils.ChageExceldatetoDate( dataGridViewdetail.Rows[idrow].Cells["Ngày_chứng_từ"].Value.ToString());
                    // detail.macty = Model.Username.getmacty();
                    detail.Ngayghiso = DateTime.Today;
                    detail.username = Utils.getusername();
                    detail.manghiepvu = "TH";
                    detail.Ngayctu = (DateTime)dataGridViewdetail.Rows[idrow].Cells["Ngày_chứng_từ"].Value;
                    detail.Sohieuchungtu = dataGridViewdetail.Rows[idrow].Cells["Số_chứng_từ"].Value.ToString();

                    detail.Diengiai = dataGridViewdetail.Rows[idrow].Cells["Diễn_giải"].Value.ToString();
                    detail.TkNo = dataGridViewdetail.Rows[idrow].Cells["Nợ_TK"].Value.ToString();
                    detail.TkCo = dataGridViewdetail.Rows[idrow].Cells["Có_TK"].Value.ToString();
                    detail.PsCo = double.Parse(dataGridViewdetail.Rows[idrow].Cells["Số_tiền"].Value.ToString());
                    detail.PsNo = double.Parse(dataGridViewdetail.Rows[idrow].Cells["Số_tiền"].Value.ToString());

                    if (dataGridViewdetail.Rows[idrow].Cells["Mã_chi_tiết_TK_Có"].Value != null && Utils.IsValidnumber(dataGridViewdetail.Rows[idrow].Cells["Mã_chi_tiết_TK_Có"].Value.ToString()))
                    {
                        detail.MaCTietTKCo = int.Parse(dataGridViewdetail.Rows[idrow].Cells["Mã_chi_tiết_TK_Có"].Value.ToString());
                    }

                    if (dataGridViewdetail.Rows[idrow].Cells["Mã_chi_tiết_TK_Nợ"].Value != null && Utils.IsValidnumber(dataGridViewdetail.Rows[idrow].Cells["Mã_chi_tiết_TK_Nợ"].Value.ToString()))
                    {
                        detail.MaCTietTKNo = int.Parse(dataGridViewdetail.Rows[idrow].Cells["Mã_chi_tiết_TK_Nợ"].Value.ToString());
                    }

                    if (dataGridViewdetail.Rows[idrow].Cells["Tên_chi_tiết_TK_Có"].Value != null)
                    {
                        detail.tenchitietCo = dataGridViewdetail.Rows[idrow].Cells["Tên_chi_tiết_TK_Có"].Value.ToString();
                    }

                    if (dataGridViewdetail.Rows[idrow].Cells["Tên_chi_tiết_TK_Nợ"].Value != null)
                    {

                        detail.tenchitietNo = dataGridViewdetail.Rows[idrow].Cells["Tên_chi_tiết_TK_Nợ"].Value.ToString();
                    }

                    Model.Taikhoanketoan.ghisocaitk(detail);

                    //dc.tbl_Socais.InsertOnSubmit(detail);
                    //dc.SubmitChanges();
                    detail = null;


                }
                #endregion   /// save  detail phieu nhap

            }

            MessageBox.Show("Số bút vừa lưu: " + this.sobuttoan, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.statusphieu = 3;// chuyển qua trang thai view


            this.blankbuttoantonghop();
            dataGridViewListBTTH.DataSource = Model.hachtoantonghop.danhsachbuttoantonghop(dc);


        }

        private void dataGridViewListphieuthu_Paint(object sender, PaintEventArgs e)
        {

            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            foreach (var c in dataGridViewListBTTH.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

            // Next





        }

        private void cbtkno_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.blankbuttoantonghop();

            tabControl1.SelectedTab = tabPage1;
            //      dataGridViewTkCo = Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);
            //    dataGridViewTkCo


        }

        private void button5_Click(object sender, EventArgs e)
        {

            string username = Utils.getusername();

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region clear reports



            var xoahead = from p in dc.RptBTTHheads
                          where p.username == username
                          select p;
            if (xoahead != null)
            {
                dc.RptBTTHheads.DeleteAllOnSubmit(xoahead);
                dc.SubmitChanges();

            }



            var xoadetail = from p in dc.RptBTTHdetails
                            where p.username == username
                            select p;

            dc.RptBTTHdetails.DeleteAllOnSubmit(xoadetail);
            dc.SubmitChanges();

            #endregion clear reports

            var bttonghop = (from p in dc.tbl_Socais
                             where p.Sohieuchungtu == this.sobuttoan
                             && p.manghiepvu == "TH"
                             select p).FirstOrDefault();



            #region  view reports payment request  



            if (bttonghop != null)
            {


                #region  insert vao rpt phieu thu

                RptBTTHhead Btthop = new RptBTTHhead();
                Btthop.tencongty = Model.Congty.getnamecongty();
                Btthop.diachicongty = Model.Congty.getdiachicongty();
                Btthop.masothue = Model.Congty.getmasothuecongty();
                Btthop.tengiamdoc = Model.Congty.gettengiamdoccongty();
                Btthop.tenketoantruong = Model.Congty.gettenketoantruongcongty();
                Btthop.phieuso = bttonghop.Sohieuchungtu;
                Btthop.ngaychungtu = bttonghop.Ngayctu;
                Btthop.nguoilapphieu = Utils.getname();
                Btthop.username = username;
                dc.RptBTTHheads.InsertOnSubmit(Btthop);
                dc.SubmitChanges();


                #endregion  inserphieu thu


                #region inser detail phieu thu



                var detailphieu = from p in dc.tbl_Socais
                                  where p.Sohieuchungtu == this.sobuttoan
                                  && p.manghiepvu == "TH"
                                  select p;
                foreach (var item in detailphieu)
                {
                    RptBTTHdetail detail = new RptBTTHdetail();

                    detail.matk = item.TkCo.Trim();
                    detail.tentk = (from tk in dc.tbl_dstaikhoans
                                    where tk.matk.Trim() == item.TkCo.Trim()
                                    select tk.tentk).FirstOrDefault().Trim();
                    detail.noidung = item.Diengiai.Trim();
                    detail.psco = item.PsCo;
                    detail.psno = 0;

                    detail.username = username;

                    dc.RptBTTHdetails.InsertOnSubmit(detail);
                    dc.SubmitChanges();

                    RptBTTHdetail detail2 = new RptBTTHdetail();

                    detail2.matk = item.TkNo.Trim();
                    detail2.tentk = (from tk in dc.tbl_dstaikhoans
                                     where tk.matk.Trim() == item.TkNo.Trim()
                                     select tk.tentk).FirstOrDefault().Trim();
                    detail2.noidung = item.Diengiai.Trim();
                    detail2.psno = item.PsCo;
                    detail2.psco = 0;
                    detail2.username = username;


                    dc.RptBTTHdetails.InsertOnSubmit(detail2);
                    dc.SubmitChanges();

                }





                #endregion inserd detail phiếu thu






                var headbuttoan = from p in dc.RptBTTHheads
                                  where p.username == username
                                  select p;


                Utils ut = new Utils();
                var dataset1 = ut.ToDataTable(dc, headbuttoan);

                var detailbtth = from p in dc.RptBTTHdetails
                                 where p.username == username
                                 select p;

                var dataset2 = ut.ToDataTable(dc, detailbtth);

                Reportsview rpt = new Reportsview(dataset1, dataset2, "Phieuketoanth.rdlc");
                rpt.ShowDialog();

            }

            #endregion view reports payment request  // 

        }

        private void dataGridViewListphieuthu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            this.statusphieu = 3;  // chuyen qua che do view
            #region load tk nợ
            List<ComboboxItem> cbcolectiontkno = new List<ComboboxItem>();
            var rs = from p in dc.tbl_dstaikhoans
                         //  where p.loaitkid.Trim() == "kho" // tien mat la loai 8
                     orderby p.matk
                     select p;
            foreach (var item in rs)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk.Trim();
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                cbcolectiontkno.Add(cb);
            }

            cbtkno.DataSource = cbcolectiontkno;

            #endregion

            #region tai khoan có



            List<ComboboxItem> cbcolectiontkco = new List<ComboboxItem>();
            var rs2 = from p in dc.tbl_dstaikhoans
                          //  where p.loaitkid.Trim() != "kho" // tien mat la loai 8
                      orderby p.matk
                      select p;
            foreach (var item in rs2)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk.Trim();
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                cbcolectiontkco.Add(cb);
            }
            cbtkco.DataSource = cbcolectiontkco;
            #endregion tai khoan co

            try
            {
                this.buttoanid = (int)this.dataGridViewListBTTH.Rows[this.dataGridViewListBTTH.CurrentCell.RowIndex].Cells["ID"].Value;


            }
            catch (Exception)
            {

                this.buttoanid = 0;
            }

            if (this.buttoanid != 0)
            {


                #region view load form
                var buttoanth = (from p in dc.tbl_Socais
                                 where p.id == this.buttoanid
                                 select p).FirstOrDefault();


                if (buttoanth != null)
                {
                    datepickngayphieu.Value = (DateTime)buttoanth.Ngayctu;
                    txtsophieu.Text = buttoanth.Sohieuchungtu.ToString();

                    this.sobuttoan = buttoanth.Sohieuchungtu.ToString();  // để tìm số chứng từ
                    txtdiengiai.Text = buttoanth.Diengiai.Trim();

                    if (buttoanth.PsCo != null)
                    {

                        this.sotien = double.Parse(buttoanth.PsCo.ToString());
                        txtsotien.Text = buttoanth.PsCo.ToString();
                    }

                    lbtenchitietno.Text = buttoanth.tenchitietNo;
                    lbtenchitietco.Text = buttoanth.tenchitietCo;

                    //   cbtkno.Text = buttoanth.TkNo.Trim() + ": "

                    foreach (ComboboxItem item in (List<ComboboxItem>)cbtkno.DataSource)
                    {
                        if (item.Value.ToString().Trim() == buttoanth.TkNo.Trim())
                        {
                            cbtkno.SelectedItem = item;

                            cbtkno.Text = item.Text;


                        }
                    }

                    //    cbtkno.Text = item.

                    foreach (ComboboxItem item in (List<ComboboxItem>)cbtkco.DataSource)
                    {
                        if (item.Value.ToString().Trim() == buttoanth.TkCo.Trim())
                        {
                            cbtkco.SelectedItem = item;
                        }
                    }





                    if (buttoanth.MaCTietTKNo != null)
                    {
                        lb_machitietno.Text = buttoanth.MaCTietTKNo.ToString();
                    }
                    else
                    {
                        lb_machitietno.Text = "";

                    }

                    if (buttoanth.MaCTietTKCo != null)
                    {
                        lb_machitietco.Text = buttoanth.MaCTietTKCo.ToString();
                    }
                    else
                    {
                        lb_machitietco.Text = "";

                    }


                    datepickngayphieu.Enabled = false;
                    txtsophieu.Enabled = false;

                    txtdiengiai.Enabled = false;
                    txtsotien.Enabled = false;
                    btsua.Enabled = true;

                    cbtkno.Enabled = false;
                    cbtkco.Enabled = false;

                    this.statusphieu = 3;// View
                                         //      Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);
                                         //        Model.Phieuthuchi.reloaddetailtaikhoancophieuthu(this.dataGridViewTkCo, this, phieuthu.tkno.Trim(), phieuthu.sophieuthu);
                    btluu.Visible = false;

                }

                dataGridViewdetailexample = Model.hachtoantonghop.reloaddetailnewbuttoanexample(dataGridViewdetailexample);

                #region adđ detail san phẩm


                var lisdetailbuttoanTH = from p in dc.tbl_Socais
                                         where p.Sohieuchungtu == buttoanth.Sohieuchungtu
                                         select p;

                if (lisdetailbuttoanTH.Count() >= 0)
                {
                    foreach (var item in lisdetailbuttoanTH)
                    {


                        add_detailGridviewexample(item);



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


            var phieunhaphead = (from p in dc.tbl_Socais
                                 where p.id == this.buttoanid

                                 select p).FirstOrDefault();

            #region CÓ SỐ PHIÊU


            if (phieunhaphead != null)
            {
                this.buttoanid = phieunhaphead.id;

                Model.hachtoantonghop.xoa("TH", phieunhaphead.Sohieuchungtu.Trim());

                MessageBox.Show("Đã xóa phiếu hạch toán tổng hợp : " + phieunhaphead.Sohieuchungtu, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                #region load list listphieunhapkho

                var listphieuHTTH = Model.hachtoantonghop.danhsachbuttoantonghop(dc);//Model.Khohang.danhsachphieunhapkho(dc);


                dataGridViewListBTTH.DataSource = listphieuHTTH;
                #endregion


            }
            else
            {
                MessageBox.Show("Phiếu hạch toán tổng hợp : " + this.sobuttoan + " không tồn tại !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            #endregion có số phiếu



        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.statusphieu = 2;// SỬA

            btluu.Visible = true;


            datepickngayphieu.Enabled = true;
            cbtkco.Enabled = true;

            txtsophieu.Enabled = true;
            if (txtsophieu.Text != "")
            {
                this.sobuttoan = txtsophieu.Text.ToString();
            }


            txtsotien.Enabled = true;

            txtdiengiai.Enabled = true;

            btluu.Enabled = true;

            cbtkno.Enabled = true;

            this.statusphieu = 2;

        }

        private void txtsophieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                //   e.Handled = true;
                txtsotien.Focus();


            }
        }

        private void txttennguoinop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                //    txtdonhang.Focus();

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

            foreach (var c in dataGridViewdetailexample.Columns)
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
                    //string SelectedItem = (cbm.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();


                    //// int i = dataGridProgramdetail.CurrentRow.Index;
                    //int i = currentCell.RowIndex;
                    //string colname = this.dataGridViewTkCo.Columns[this.dataGridViewTkCo.CurrentCell.ColumnIndex].Name;

                    ////   dataGridViewTkCo.Rows[i].Cells[colname].Value = SelectedItem;

                    //dataGridViewTkCo.Rows[i].Cells[colname].Value = SelectedItem;

                    //string connection_string = Utils.getConnectionstr();
                    //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                    //var sp = (from p in dc.tbl_kho_sanphams
                    //          where p.masp == SelectedItem
                    //          orderby p.masp
                    //          select p).FirstOrDefault();

                    //if (sp != null)
                    //{
                    //    dataGridViewTkCo.Rows[i].Cells["Tên_sản_phẩm"].Value = sp.tensp;
                    //    dataGridViewTkCo.Rows[i].Cells["Đơn_vị"].Value = sp.donvi;

                    //}
                    //else
                    //{
                    //    dataGridViewTkCo.Rows[i].Cells["Tên_sản_phẩm"].Value = "";
                    //    dataGridViewTkCo.Rows[i].Cells["Đơn_vị"].Value = "";

                    //}

                    //dt.Columns.Add(new DataColumn("masanpham", typeof(string)));
                    //dt.Columns.Add(new DataColumn("Tên_sản_phẩm", typeof(string)));

                    //dt.Columns.Add(new DataColumn("Đơn_vị", typeof(string)));
                    //dt.Columns.Add(new DataColumn("Số_lượng_nhập", typeof(string)));

                    ////Threahold
                    ////      dt.Columns.Add(new DataColumn("Tk_Có", typeof(double)));
                    //dt.Columns.Add(new DataColumn("Đơn_giá", typeof(double)));
                    //dt.Columns.Add(new DataColumn("Thành_tiền", typeof(double)));


                    //   }
                }
                //}

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


                currentCell = this.dataGridViewdetailexample.CurrentCell;




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


            #region  view lai số tiền


            double tongcong = 0;


            for (int idrow = 0; idrow < dataGridViewdetail.RowCount - 1; idrow++)
            {


                if (dataGridViewdetail.Rows[idrow].Cells["Số_tiền"] != null)

                {
                    if (Utils.IsValidnumber(dataGridViewdetail.Rows[idrow].Cells["Số_tiền"].Value.ToString()))
                    {

                        tongcong += double.Parse(dataGridViewdetail.Rows[idrow].Cells["Số_tiền"].Value.ToString());
                    }
                }







            }

            //txtValueSotienCo.Text = tongcong.ToString();
            this.sotien = tongcong;
            txttongtien.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);

            #endregion



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
            //txttongtien.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);
            //#endregion



            //   }







        }

        private void dataGridViewTkCo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //string connection_string = Utils.getConnectionstr();
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //#region load tk nợ
            //List<ComboboxItem> cbcolectiontkno = new List<ComboboxItem>();
            //var rs = from p in dc.tbl_dstaikhoans
            //             //  where p.loaitkid.Trim() == "kho" // tien mat la loai 8
            //         orderby p.matk
            //         select p;
            //foreach (var item in rs)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.matk.Trim();
            //    cb.Text = item.matk.Trim() + ": " + item.tentk;
            //    cbcolectiontkno.Add(cb);
            //}

            //cbtkno.DataSource = cbcolectiontkno;

            //#endregion

            //#region tai khoan có



            //List<ComboboxItem> cbcolectiontkco = new List<ComboboxItem>();
            //var rs2 = from p in dc.tbl_dstaikhoans
            //              //  where p.loaitkid.Trim() != "kho" // tien mat la loai 8
            //          orderby p.matk
            //          select p;
            //foreach (var item in rs2)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.matk.Trim();
            //    cb.Text = item.matk.Trim() + ": " + item.tentk;
            //    cbcolectiontkco.Add(cb);
            //}
            //cbtkco.DataSource = cbcolectiontkco;
            //#endregion tai khoan co

            //#region datatable temp




            ////DataTable dt = new DataTable();

            ////dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DateTime))); //adding column for combobox
            ////dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(string)));
            ////dt.Columns.Add(new DataColumn("Diễn_giải", typeof(string)));

            ////dt.Columns.Add(new DataColumn("Nợ_TK", typeof(string)));
            ////dt.Columns.Add(new DataColumn("Có_TK", typeof(string)));

            ////dt.Columns.Add(new DataColumn("Số_tiền", typeof(double)));


            ////dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Nợ", typeof(int)));
            ////dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Nợ", typeof(string)));
            ////dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Có", typeof(int)));


            ////dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Có", typeof(string)));






            //#endregion datatable temp

            //DataGridView view = (DataGridView)sender;
            //int i = view.CurrentRow.Index;

            //if (dataGridViewdetail.Rows[i].Cells["Ngày_chứng_từ"].Value != DBNull.Value)
            //{

            //    #region view load form
            //    tbl_Socai buttoanth = new tbl_Socai();
            //    if (dataGridViewdetail.Rows[i].Cells["Diễn_giải"].Value != null)
            //    {
            //        buttoanth.Diengiai = dataGridViewdetail.Rows[i].Cells["Diễn_giải"].Value.ToString();
            //    }

            //    buttoanth.Ngayctu = (DateTime)dataGridViewdetail.Rows[i].Cells["Ngày_chứng_từ"].Value;
            //    buttoanth.Sohieuchungtu = dataGridViewdetail.Rows[i].Cells["Số_chứng_từ"].Value.ToString();
            //    buttoanth.PsCo = float.Parse(dataGridViewdetail.Rows[i].Cells["Số_tiền"].Value.ToString());

            //    buttoanth.PsNo = float.Parse(dataGridViewdetail.Rows[i].Cells["Số_tiền"].Value.ToString());
            //    if (Utils.IsValidnumber(dataGridViewdetail.Rows[i].Cells["Mã_chi_tiết_TK_Nợ"].Value.ToString()))
            //    {
            //        buttoanth.MaCTietTKNo = int.Parse(dataGridViewdetail.Rows[i].Cells["Mã_chi_tiết_TK_Nợ"].Value.ToString());
            //    }
            //    if (Utils.IsValidnumber(dataGridViewdetail.Rows[i].Cells["Mã_chi_tiết_TK_Có"].Value.ToString()))
            //    {
            //        buttoanth.MaCTietTKCo = int.Parse(dataGridViewdetail.Rows[i].Cells["Mã_chi_tiết_TK_Có"].Value.ToString());
            //    }
            //    buttoanth.tenchitietNo = dataGridViewdetail.Rows[i].Cells["Tên_chi_tiết_TK_Nợ"].Value.ToString();
            //    buttoanth.tenchitietCo = dataGridViewdetail.Rows[i].Cells["Tên_chi_tiết_TK_Có"].Value.ToString();
            //    buttoanth.TkCo = dataGridViewdetail.Rows[i].Cells["Có_TK"].Value.ToString();
            //    buttoanth.TkNo = dataGridViewdetail.Rows[i].Cells["Nợ_TK"].Value.ToString();

            //    //var buttoanth = (from p in dc.tbl_Socais
            //    //                 where p.id == this.buttoanid
            //    //                 select p).FirstOrDefault();

            //    // buttoanth
            //    //        if (buttoanth != null)
            //    //       {
            //    datepickngayphieu.Value = (DateTime)buttoanth.Ngayctu;
            //    txtsophieu.Text = buttoanth.Sohieuchungtu.ToString();

            //    txtdiengiai.Text = buttoanth.Diengiai;

            //    if (buttoanth.PsCo != null)
            //    {

            //        this.sotien = double.Parse(buttoanth.PsCo.ToString());
            //        txtsotien.Text = buttoanth.PsCo.ToString();
            //    }

            //    lbtenchitietno.Text = buttoanth.tenchitietNo;
            //    lbtenchitietco.Text = buttoanth.tenchitietCo;

            //    foreach (ComboboxItem item in (List<ComboboxItem>)cbtkno.DataSource)
            //    {
            //        if (item.Value.ToString().Trim() == buttoanth.TkNo.Trim())
            //        {
            //            cbtkno.SelectedItem = item;
            //        }
            //    }

            //    foreach (ComboboxItem item in (List<ComboboxItem>)cbtkco.DataSource)
            //    {
            //        if (item.Value.ToString().Trim() == buttoanth.TkCo.Trim())
            //        {
            //            cbtkco.SelectedItem = item;
            //        }
            //    }





            //    if (buttoanth.MaCTietTKNo != null)
            //    {
            //        lb_machitietno.Text = buttoanth.MaCTietTKNo.ToString();
            //    }
            //    else
            //    {
            //        lb_machitietno.Text = "";

            //    }

            //    if (buttoanth.MaCTietTKCo != null)
            //    {
            //        lb_machitietco.Text = buttoanth.MaCTietTKCo.ToString();
            //    }
            //    else
            //    {
            //        lb_machitietco.Text = "";

            //    }


            //    datepickngayphieu.Enabled = false;
            //    txtsophieu.Enabled = false;

            //    txtdiengiai.Enabled = false;
            //    txtsotien.Enabled = false;
            //    btsua.Enabled = true;

            //    cbtkno.Enabled = false;
            //    cbtkco.Enabled = false;

            //    this.statusphieu = 3;// View
            //                         //      Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);
            //                         //        Model.Phieuthuchi.reloaddetailtaikhoancophieuthu(this.dataGridViewTkCo, this, phieuthu.tkno.Trim(), phieuthu.sophieuthu);
            //    btluu.Visible = false;

            //    //        }



            //    #endregion view load form




            //}


            ////string colname = view.Columns[view.CurrentCell.ColumnIndex].Name;

            ////try
            ////{
            ////    dataGridViewTkCo.Rows[i].Cells["Thành_tiền"].Value = float.Parse(dataGridViewTkCo.Rows[i].Cells["Số_lượng_nhập"].Value.ToString()) * float.Parse(dataGridViewTkCo.Rows[i].Cells["Đơn_giá"].Value.ToString());

            ////}
            ////catch (Exception)
            ////{

            ////    dataGridViewTkCo.Rows[i].Cells["Thành_tiền"].Value = 0;
            ////}


            ////    string SelectedItem = view.Rows[i].Cells["Tk_Có"].Value.ToString();

            ////#region if la slect tai khoan co chi tiet

            ////if (colname == "Tk_Có" && SelectedItem != "")
            ////{
            ////    string taikhoan = currentCell.Value.ToString();
            ////    string connection_string = Utils.getConnectionstr();
            ////    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            ////    var detail = (from c in db.tbl_dstaikhoans
            ////                  where c.matk.Trim() == taikhoan.Trim()
            ////                  select c).FirstOrDefault();

            ////    if (detail.loaichitiet == true) // là co theo doi chi tiết
            ////    {

            ////        List<beeselectinput.ComboboxItem> listcb = new List<beeselectinput.ComboboxItem>();
            ////        var rs = from tbl_machitiettk in db.tbl_machitiettks
            ////                 where tbl_machitiettk.matk.Trim() == taikhoan.Trim()
            ////                 orderby tbl_machitiettk.machitiet
            ////                 select tbl_machitiettk;
            ////        if (rs.Count() > 0)
            ////        {


            ////            foreach (var item2 in rs)
            ////            {
            ////                beeselectinput.ComboboxItem cb = new beeselectinput.ComboboxItem();
            ////                cb.Value = item2.machitiet.ToString().Trim();
            ////                cb.Text = item2.tenchitiet; //item2.machitiet.ToString().Trim() + ": " +
            ////                listcb.Add(cb);
            ////            }



            ////            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            ////            bool kq = false;
            ////            foreach (Form frm in fc)
            ////            {
            ////                if (frm.Text == "beeselectinput")


            ////                {
            ////                    kq = true;
            ////                    frm.Close();

            ////                }
            ////            }

            ////            if (kq == false)
            ////            {
            ////                //        beeselectinput

            ////                View.beeselectinput selecdetail = new beeselectinput("Chọn chi tiết tài khoản ", listcb);

            ////                selecdetail.ShowDialog();


            ////                bool chon = selecdetail.kq;
            ////                if (chon)
            ////                {
            ////                    string machitiet = selecdetail.value;
            ////                    string namechitiet = selecdetail.valuetext;

            ////                    dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = machitiet;
            ////                    dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = namechitiet;


            ////                }
            ////                else
            ////                {
            ////                    dataGridViewTkCo.Rows[i].Cells["Tk_Có"].Value = "";
            ////                    dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            ////                    dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";
            ////                }




            ////            }
            ////            else
            ////            {
            ////                dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            ////                dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";


            ////            }


            ////        }
            ////    }


            ////    else
            ////    {
            ////        dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            ////        dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";


            ////    }

            ////}

            ////#endregion





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
            //if (Utils.IsValidnumber(txttongtien.Text.ToString()))
            //{
            //    this.sotien = double.Parse(txtsotiensave.Text);
            //}
            ////else
            ////{
            //    txtsotienco.Text = "";
            //}


        }

        private void dataGridViewTkCo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {



            //#region  view lai số tiền


            //double tongcong = 0;


            //for (int idrow = 0; idrow < dataGridViewdetailexample.RowCount - 1; idrow++)
            //{


            //    if (dataGridViewdetailexample.Rows[idrow].Cells["Số_tiền"] != null)

            //    {
            //        if (Utils.IsValidnumber(dataGridViewdetailexample.Rows[idrow].Cells["Số_tiền"].Value.ToString()))
            //        {

            //            tongcong += double.Parse(dataGridViewdetailexample.Rows[idrow].Cells["Số_tiền"].Value.ToString());
            //        }
            //    }







            //}

            ////txtValueSotienCo.Text = tongcong.ToString();
            //this.sotien = tongcong;
            //txttongtien.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);

            //#endregion



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
            //  cbtkco.SelectedItem = (ComboboxItem)sender;

            if (this.statusphieu == 1 || this.statusphieu == 2)
            {
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

        private void cbtkco_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }

        private void dataGridViewListPNK_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            tabControl1.SelectedTab = tabPage1;
            this.statusphieu = 3;  // chuyen qua che do view
        }

        private void cbkhohang_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cbkhohang.SelectedItem != null)
            //{
            //    this.makho = (cbkhohang.SelectedItem as ComboboxItem).Value.ToString();

            //}

            //dataGridViewTkCo = Model.Khohang.reloaddetailnewPNK(dataGridViewTkCo, this.makho);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //  bool check 
            #region check chi tiết head phiếu
            #region  chcek so phieu co ký tu khong
            if (txtsophieu.Text == "")
            {
                MessageBox.Show("Phiếu số chứng từ !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //   checkdinhkhoan = false;
                txtsophieu.Focus();
                return;

            }


            #endregion  check so phieu co ky tu không


            #region check phieu so có lặp hay kkoog
            //  txtsophieu
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var sophieunhaplap = (from p in dc.tbl_Socais
                                  where (p.Sohieuchungtu.Trim() == txtsophieu.Text.ToString().Trim())
                                  && p.manghiepvu == "TH"
                                  select p).FirstOrDefault();

            if (sophieunhaplap != null)
            {

                MessageBox.Show("Số phiếu bị lặp !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    checkdinhkhoan = false;
                txtsophieu.Focus();
                return;


            }


            #endregion check phieu so

            if (datepickngayphieu.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn ngày chứng từ !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //  checkdinhkhoan = false;
                datepickngayphieu.Focus();
                return;

            }



            if (cbtkno.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản nợ !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //  checkdinhkhoan = false;
                cbtkno.Focus();
                return;

            }

            if (cbtkco.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản có !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // checkdinhkhoan = false;
                cbtkco.Focus();
                return;

            }

            if (txtdiengiai.Text == "")
            {
                MessageBox.Show("Kiểm tra diễn giải !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    checkdinhkhoan = false;
                txtdiengiai.Focus();
                return;

            }

            if (txtsotien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số tiền !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    checkdinhkhoan = false;
                txtsotien.Focus();
                return;

            }
            if (txtsotien.Text != "" && Utils.IsValidnumber(txtsotien.Text) == false)
            {
                MessageBox.Show("Số tiền phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    checkdinhkhoan = false;
                txtsotien.Focus();
                return;

            }


            if (dataGridViewdetailexample.RowCount - 1 > 0) // check số phiếu phải cùng số phiếu
            {
                this.sobuttoan = dataGridViewdetailexample.Rows[0].Cells["Số_chứng_từ"].Value.ToString();
                if (this.sobuttoan != txtsophieu.Text)
                {
                    MessageBox.Show("Bạn kiểm tra lại số phiếu:  " + this.sobuttoan + " so với: " + txtsophieu.Text, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtsophieu.Focus();
                    return;
                }

            }

            #endregion  end check 


            tbl_Socai socai = new tbl_Socai();

            socai.Ngayctu = datepickngayphieu.Value;

            socai.manghiepvu = "TH";
            socai.Diengiai = txtdiengiai.Text;
            socai.Sohieuchungtu = txtsophieu.Text;
            if (cbtkco.SelectedItem != null)
            {
                socai.TkCo = (cbtkco.SelectedItem as ComboboxItem).Value.ToString();
            }

            if (cbtkno.SelectedItem != null)
            {
                socai.TkNo = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
            }

            if (Utils.IsValidnumber(txtsotien.Text))
            {
                socai.PsCo = double.Parse(txtsotien.Text.ToString());
                socai.PsNo = double.Parse(txtsotien.Text.ToString());

            }

            if (lb_machitietco.Text != "" && Utils.IsValidnumber(lb_machitietco.Text))
            {
                socai.MaCTietTKCo = int.Parse(lb_machitietco.Text.ToString());
            }
            if (lb_machitietno.Text != "" && Utils.IsValidnumber(lb_machitietno.Text))
            {
                socai.MaCTietTKNo = int.Parse(lb_machitietno.Text.ToString());
            }


            socai.tenchitietCo = lbtenchitietco.Text.ToString();
            socai.tenchitietNo = lbtenchitietno.Text.ToString();




            //      Model.hachtoantonghop.


            add_detailGridviewcurrent(socai);


            datepickngayphieu.Enabled = false;
            txtsophieu.Enabled = false;
            //  txtsotien.Text = "";

        }

        private void txtsophieu_TextChanged(object sender, EventArgs e)
        {

            if (this.statusphieu == 2 && dataGridViewdetailexample.RowCount > 0)
            {


                for (int idrow = 0; idrow < dataGridViewdetailexample.RowCount - 1; idrow++)
                {

                    dataGridViewdetailexample.Rows[idrow].Cells["Số_chứng_từ"].Value = txtsophieu.Text;

                    this.sobuttoan = txtsophieu.Text;
                }


            }


        }

        private void dataGridViewdetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            this.statusphieu = 3;// để view không sellect

            #region load tk nợ
            List<ComboboxItem> cbcolectiontkno = new List<ComboboxItem>();
            var rs = from p in dc.tbl_dstaikhoans
                         //  where p.loaitkid.Trim() == "kho" // tien mat la loai 8
                     orderby p.matk
                     select p;
            foreach (var item in rs)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk.Trim();
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                cbcolectiontkno.Add(cb);
            }

            cbtkno.DataSource = cbcolectiontkno;

            #endregion

            #region tai khoan có



            List<ComboboxItem> cbcolectiontkco = new List<ComboboxItem>();
            var rs2 = from p in dc.tbl_dstaikhoans
                          //  where p.loaitkid.Trim() != "kho" // tien mat la loai 8
                      orderby p.matk
                      select p;
            foreach (var item in rs2)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk.Trim();
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                cbcolectiontkco.Add(cb);
            }
            cbtkco.DataSource = cbcolectiontkco;
            #endregion tai khoan co

            #region datatable temp




            //DataTable dt = new DataTable();

            //dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DateTime))); //adding column for combobox
            //dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(string)));
            //dt.Columns.Add(new DataColumn("Diễn_giải", typeof(string)));

            //dt.Columns.Add(new DataColumn("Nợ_TK", typeof(string)));
            //dt.Columns.Add(new DataColumn("Có_TK", typeof(string)));

            //dt.Columns.Add(new DataColumn("Số_tiền", typeof(double)));


            //dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Nợ", typeof(int)));
            //dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Nợ", typeof(string)));
            //dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Có", typeof(int)));


            //dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Có", typeof(string)));






            #endregion datatable temp

            DataGridView view = (DataGridView)sender;
            int i = view.CurrentRow.Index;

            if (dataGridViewdetailexample.Rows[i].Cells["Ngày_chứng_từ"].Value != DBNull.Value)
            {

                #region view load form
                tbl_Socai buttoanth = new tbl_Socai();
                if (dataGridViewdetailexample.Rows[i].Cells["Diễn_giải"].Value != null)
                {
                    buttoanth.Diengiai = dataGridViewdetailexample.Rows[i].Cells["Diễn_giải"].Value.ToString();
                }

                buttoanth.Ngayctu = (DateTime)dataGridViewdetailexample.Rows[i].Cells["Ngày_chứng_từ"].Value;
                buttoanth.Sohieuchungtu = dataGridViewdetailexample.Rows[i].Cells["Số_chứng_từ"].Value.ToString();
                buttoanth.PsCo = double.Parse(dataGridViewdetailexample.Rows[i].Cells["Số_tiền"].Value.ToString());

                buttoanth.PsNo = double.Parse(dataGridViewdetailexample.Rows[i].Cells["Số_tiền"].Value.ToString());
                if (Utils.IsValidnumber(dataGridViewdetailexample.Rows[i].Cells["Mã_chi_tiết_TK_Nợ"].Value.ToString()))
                {
                    buttoanth.MaCTietTKNo = int.Parse(dataGridViewdetailexample.Rows[i].Cells["Mã_chi_tiết_TK_Nợ"].Value.ToString());
                }
                if (Utils.IsValidnumber(dataGridViewdetailexample.Rows[i].Cells["Mã_chi_tiết_TK_Có"].Value.ToString()))
                {
                    buttoanth.MaCTietTKCo = int.Parse(dataGridViewdetailexample.Rows[i].Cells["Mã_chi_tiết_TK_Có"].Value.ToString());
                }
                buttoanth.tenchitietNo = dataGridViewdetailexample.Rows[i].Cells["Tên_chi_tiết_TK_Nợ"].Value.ToString();
                buttoanth.tenchitietCo = dataGridViewdetailexample.Rows[i].Cells["Tên_chi_tiết_TK_Có"].Value.ToString();
                buttoanth.TkCo = dataGridViewdetailexample.Rows[i].Cells["Có_TK"].Value.ToString();
                buttoanth.TkNo = dataGridViewdetailexample.Rows[i].Cells["Nợ_TK"].Value.ToString();

                //var buttoanth = (from p in dc.tbl_Socais
                //                 where p.id == this.buttoanid
                //                 select p).FirstOrDefault();

                // buttoanth
                //        if (buttoanth != null)
                //       {
                datepickngayphieu.Value = (DateTime)buttoanth.Ngayctu;
                txtsophieu.Text = buttoanth.Sohieuchungtu.ToString();

                txtdiengiai.Text = buttoanth.Diengiai;

                if (buttoanth.PsCo != null)
                {

                    this.sotien = double.Parse(buttoanth.PsCo.ToString());
                    txtsotien.Text = buttoanth.PsCo.ToString();
                }

                lbtenchitietno.Text = buttoanth.tenchitietNo;
                lbtenchitietco.Text = buttoanth.tenchitietCo;

                foreach (ComboboxItem item in (List<ComboboxItem>)cbtkno.DataSource)
                {
                    if (item.Value.ToString().Trim() == buttoanth.TkNo.Trim())
                    {
                        cbtkno.SelectedItem = item;
                    }
                }

                foreach (ComboboxItem item in (List<ComboboxItem>)cbtkco.DataSource)
                {
                    if (item.Value.ToString().Trim() == buttoanth.TkCo.Trim())
                    {
                        cbtkco.SelectedItem = item;
                    }
                }





                if (buttoanth.MaCTietTKNo != null)
                {
                    lb_machitietno.Text = buttoanth.MaCTietTKNo.ToString();
                }
                else
                {
                    lb_machitietno.Text = "";

                }

                if (buttoanth.MaCTietTKCo != null)
                {
                    lb_machitietco.Text = buttoanth.MaCTietTKCo.ToString();
                }
                else
                {
                    lb_machitietco.Text = "";

                }


                datepickngayphieu.Enabled = false;
                txtsophieu.Enabled = false;

                txtdiengiai.Enabled = false;
                txtsotien.Enabled = false;
                btsua.Enabled = true;

                cbtkno.Enabled = false;
                cbtkco.Enabled = false;

                this.statusphieu = 3;// View
                                     //      Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);
                                     //        Model.Phieuthuchi.reloaddetailtaikhoancophieuthu(this.dataGridViewTkCo, this, phieuthu.tkno.Trim(), phieuthu.sophieuthu);
                btluu.Visible = false;

                //        }



                #endregion view load form




            }


            //string colname = view.Columns[view.CurrentCell.ColumnIndex].Name;

            //try
            //{
            //    dataGridViewTkCo.Rows[i].Cells["Thành_tiền"].Value = float.Parse(dataGridViewTkCo.Rows[i].Cells["Số_lượng_nhập"].Value.ToString()) * float.Parse(dataGridViewTkCo.Rows[i].Cells["Đơn_giá"].Value.ToString());

            //}
            //catch (Exception)
            //{

            //    dataGridViewTkCo.Rows[i].Cells["Thành_tiền"].Value = 0;
            //}


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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtsotien_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                //   e.Handled = true;
                txtdiengiai.Focus();


            }

        }

        private void cbtkco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                //  cbtaikhoanco.Focus();
                cbtkno.Focus();
                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void cbtkno_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewdetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewdetail_Paint(object sender, PaintEventArgs e)
        {
            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            foreach (var c in dataGridViewdetail.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

            // Next
        }

        private void txtdiengiai_TextChanged(object sender, EventArgs e)
        {
            if (this.statusphieu == 2 && dataGridViewdetailexample.RowCount > 0)
            {


                for (int idrow = 0; idrow < dataGridViewdetailexample.RowCount - 1; idrow++)
                {

                    dataGridViewdetailexample.Rows[idrow].Cells["Diễn_giải"].Value = txtdiengiai.Text;

                    this.sobuttoan = txtsophieu.Text;
                }


            }
        }

        private void dataGridViewdetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            #region  view lai số tiền


            double tongcong = 0;


            for (int idrow = 0; idrow < dataGridViewdetail.RowCount - 1; idrow++)
            {


                if (dataGridViewdetail.Rows[idrow].Cells["Số_tiền"] != null)

                {
                    if (Utils.IsValidnumber(dataGridViewdetail.Rows[idrow].Cells["Số_tiền"].Value.ToString()))
                    {

                        tongcong += double.Parse(dataGridViewdetail.Rows[idrow].Cells["Số_tiền"].Value.ToString());
                    }
                }







            }

            //txtValueSotienCo.Text = tongcong.ToString();
            this.sotien = tongcong;
            txttongtien.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);

            #endregion


        }

        private void dataGridViewdetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            #region  view lai số tiền


            double tongcong = 0;


            for (int idrow = 0; idrow < dataGridViewdetail.RowCount - 1; idrow++)
            {


                if (dataGridViewdetail.Rows[idrow].Cells["Số_tiền"] != null)

                {
                    if (Utils.IsValidnumber(dataGridViewdetail.Rows[idrow].Cells["Số_tiền"].Value.ToString()))
                    {

                        tongcong += double.Parse(dataGridViewdetail.Rows[idrow].Cells["Số_tiền"].Value.ToString());
                    }
                }







            }

            //txtValueSotienCo.Text = tongcong.ToString();
            this.sotien = tongcong;
            txttongtien.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);

            #endregion


        }

        private void cbtkno_SelectedIndexChanged(object sender, EventArgs e)
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
            //   cbtkno.SelectedItem = (ComboboxItem)sender;
            if (this.statusphieu == 1 || this.statusphieu == 2)
            {
                string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                //var danhsachtaikhoan = from c in db.tbl_dstaikhoans
                //                        // where c like 
                //                       select new {
                //                         Mã_tài_khoản =  c.matk,
                //                          Tên_tài_khoản = c.tentk,
                //                          c.id

                //                       };

                //Beeviewandchoose chontaikhoan = new Beeviewandchoose("CHỌN TÀI KHOẢN KẾ TOÁN", danhsachtaikhoan, db);



                //int idtaikhoan =-1;

                // chontaikhoan.ShowDialog();

                //if (chontaikhoan.kq)
                //{
                //    idtaikhoan = chontaikhoan.value;
                //}

                //string taikhoan = (from c in db.tbl_dstaikhoans
                //                   where c.id == idtaikhoan
                //                   select c.matk).FirstOrDefault().ToString();




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

        }

        private void datepickngayphieu_ValueChanged(object sender, EventArgs e)
        {
            if (this.statusphieu == 2 && dataGridViewdetailexample.RowCount > 0)
            {


                for (int idrow = 0; idrow < dataGridViewdetailexample.RowCount - 1; idrow++)
                {

                    dataGridViewdetailexample.Rows[idrow].Cells["Ngày_chứng_từ"].Value = datepickngayphieu.Value;
                 //   this.
                   // this.sobuttoan = txtsophieu.Text;
                }


            }
        }
    }
}
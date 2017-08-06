using BEEACCOUNT.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BEEACCOUNT.View
{
    public partial class BeePhieuThu : Form
    {
        public int statusphieuthu { get; set; } // mới  // 2 suawra // 3 display //
        public int phieuthuid { get; set; }
        public int sophieuthu { get; set; }
        public string tkno { get; set; }
        public int tknochitiet { get; set; }
        public string tkco { get; set; }
        public int tkcochitiet { get; set; }
        public string pssotienno { get; set; }
        public string pssotienco { get; set; }
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


        public void add_detailGridviewTkCo(tbl_Socai socaitemp)
        {


            //dataGridViewTkCo.Columns["Tk_Có"].DisplayIndex = 0;  0903496990 cv
            //dataGridViewTkCo.Columns["Tk_Có"].Width = 100;
            //dataGridViewTkCo.Columns["Tk_Có"].SortMode = DataGridViewColumnSortMode.NotSortable;

            //dataGridViewTkCo.Columns["Mã_chi_tiết"].DisplayIndex = 1;
            //dataGridViewTkCo.Columns["Mã_chi_tiết"].Width = 100;
            //dataGridViewTkCo.Columns["Mã_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridViewTkCo.Columns["Mã_chi_tiết"].ReadOnly = true;
            //dataGridViewTkCo.Columns["Mã_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;

            //dataGridViewTkCo.Columns["Tên_chi_tiết"].DisplayIndex = 2;
            //dataGridViewTkCo.Columns["Tên_chi_tiết"].Width = 200;
            //dataGridViewTkCo.Columns["Tên_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridViewTkCo.Columns["Tên_chi_tiết"].ReadOnly = true;
            //dataGridViewTkCo.Columns["Tên_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;


            //dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;
            //dataGridViewTkCo.Columns["Số_tiền"].Width = 100;
            //dataGridViewTkCo.Columns["Số_tiền"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridViewTkCo.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";


            //dataGridViewTkCo.Columns["Diễn_giải"].DisplayIndex = 4;
            //dataGridViewTkCo.Columns["Diễn_giải"].Width = 300;
            //dataGridViewTkCo.Columns["Diễn_giải"].SortMode = DataGridViewColumnSortMode.NotSortable;


            //dataGridViewTkCo.Columns["Ký_hiêu"].DisplayIndex = 5;
            //dataGridViewTkCo.Columns["Ký_hiêu"].Width = 100;
            //dataGridViewTkCo.Columns["Ký_hiêu"].SortMode = DataGridViewColumnSortMode.NotSortable;


            //dataGridViewTkCo.Columns["Ngày_chứng_từ"].DisplayIndex = 6;
            //dataGridViewTkCo.Columns["Ngày_chứng_từ"].Width = 100;
            //dataGridViewTkCo.Columns["Ngày_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;


            //dataGridViewTkCo.Columns["Số_chứng_từ"].DisplayIndex = 7;
            //dataGridViewTkCo.Columns["Số_chứng_từ"].Width = 200;
            //dataGridViewTkCo.Columns["Số_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //DataTable dt = dataGridView1.DataSource as DataTable;
            //  /-------------------
            //            1
            //down vote



            //After adding a new row, you have to set the row index in boundary of row count. You have to do these steps.

            //    First, add row in DataGridView:

            //            dataGridView1.Rows.Add();

            //            Second, set new row index to count - 1:

            //    int RowIndex = dataGridView1.RowCount - 1;

            //            Then at last, set the controls values in it:

            //            DataGridViewRow R = dataGridView1.Rows[RowIndex];
            //            R.Cells["YourName"].Value = tbName.Text;

            //            And if your datagrid's source is datattable you have to add row in that table.Give new values to the newly added row in data table and at last rebind the datagrid with updated datatable.

            //    DataRow row = dt.NewRow();
            //            row["columnname"] = tbName.Text.toString();
            //            dt.Rows.Add(row);
            //            dt.AcceptChanges();

            //            dataGridView1.DataSource = dt;
            //            dataGridView1.DataBind();

            //            Check if you have set the index o
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //---------------

            DataTable dataTable = (DataTable)dataGridViewTkCo.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            //    drToAdd["Tk_Có"] = socaitemp.TkCo;
            drToAdd["Diễn_giải"] = socaitemp.Diengiai;
            drToAdd["Số_chứng_từ"] = socaitemp.Soctu;
            drToAdd["Ký_hiêu"] = socaitemp.Kyhieuctu;
            drToAdd["Số_tiền"] = socaitemp.PsCo;
            drToAdd["Mã_chi_tiết"] = socaitemp.MaCTietTKCo;
            drToAdd["Tên_chi_tiết"] = socaitemp.tenchitietCo;

            drToAdd["tkCohide"] = socaitemp.TkCo;


            drToAdd["ngayctuhide"] = socaitemp.Ngayctu;

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();


      ////      int RowIndex = dataGridViewTkCo.RowCount - 1;
         //   DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridViewTkCo.Rows[RowIndex].Cells["Tk_Có"];

        
            //    cell.DisplayMember = socaitemp.TkCo;

         //   DataGridViewCell dgvc = (DataGridViewCell)dataGridViewTkCo.Rows[RowIndex].Cells["Tk_Có"];
         //   dgvc.Value = cell.Items[3];

            //  dataGridView1.Rows[0].Cells[2].Value = "1";
            //    DataGridViewRow R = dataGridViewTkCo.Rows[RowIndex];
            //  R.Cells["Tk_Có"].Value = socaitemp.TkCo;

            //    R.Cells["Tk_Có"]. = socaitemp.TkCo;



        }

        public void reloadseachview(string nguoinop, string diachi, string noidung)
        {



            dataGridViewListphieuthu.DataSource = Model.Phieuthuchi.reloadseachview("PT", nguoinop, diachi, noidung);


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
                    View.BeeSeachtwofield sheaching = new BeeSeachtwofield(this, "Người nôp", "Địa chỉ", "Nội dung");
                    sheaching.Show();
                }




            }


            if (e.Control == true && e.KeyCode == Keys.N)
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
                    View.BeeHtoansocaidoiungphieuthu BeeHtoansocaidoiung = new BeeHtoansocaidoiungphieuthu(this, "Địa chỉ", "", "");
                    BeeHtoansocaidoiung.ShowDialog();
                }




            }


        }

        public View.Main main1;
        public BeePhieuThu(View.Main Main)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);  // để đọc từ bàn phím phím tắt

            this.pssotienno = "0";
            this.pssotienco = "0";
            this.main1 = Main;

            this.statusphieuthu = 1; // tạo mới

            Model.Username used = new Model.Username();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            string username = Utils.getusername();

            //    var contractautolist = (from tbl_autodataContract in dc.tbl_autodataContracts
            //                            where tbl_autodataContract.Username == username
            //                            orderby tbl_autodataContract.id descending
            //                            select tbl_autodataContract.ContractNo).Take(10);
            #region load datenew
            this.datepickngayphieu.Value = DateTime.Today.Date;
            //    this.lbmachitetno.Visible = false;
            //  this.lbmachitietco.Visible = false;
            //   this.lbtenchitietco.Visible = false;
            this.lbtenchitietno.Visible = false;
            lb_machitietno.Text = "";
            //     this.lbmaso.Visible = false;

            #region load tk nợ


            var rs2 = from tk in dc.tbl_dstaikhoans
                      where tk.loaitkid == 8 // mã 8 là tiền mặt
                      select tk;

            //      string drowdownshow = "";

            foreach (var item in rs2)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk;
                cb.Text = item.matk + ":" + item.tentk;
                this.cbtkno.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk nợ

            #region datatable temp




            DataTable dt = new DataTable();



            //   dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DGV_DateTimePicker.DateTimePickerCell)));
            dt.Columns.Add(new DataColumn("Mã_chi_tiết", typeof(string)));
            dt.Columns.Add(new DataColumn("Tên_chi_tiết", typeof(string)));

            dt.Columns.Add(new DataColumn("Số_tiền", typeof(double)));
            dt.Columns.Add(new DataColumn("Diễn_giải", typeof(string)));

            //Threahold
            //      dt.Columns.Add(new DataColumn("Tk_Có", typeof(double)));
            dt.Columns.Add(new DataColumn("Ký_hiêu", typeof(string)));
            dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(int)));
            dt.Columns.Add(new DataColumn("tkCohide", typeof(string))); //comnoxxon

            dt.Columns.Add(new DataColumn("ngayctuhide", typeof(DateTime))); //adding column for combobox


            //#region comboud box value
            //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //cmb.HeaderText = "Tk_Có";
            //cmb.Name = "Tk_Có";
            ////   cmb.MaxDropDownItems = 300;
            //var rs = from tbl_dstaikhoan in dc.tbl_dstaikhoans
            //         orderby tbl_dstaikhoan.matk
            //         select tbl_dstaikhoan;
            //foreach (var item in rs)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.matk.Trim();
            //    cb.Text = item.matk.Trim() + ": " + item.tentk;
            //    cmb.Items.Add(cb);
            //}
            ////     cmb.Items.Add("real");
            ////   cmb.Items.Add("sham");
            //cmb.DataPropertyName = "Tk_Có"; //Bound value to the datasource
            //cmb.DropDownWidth = 300;

            //dataGridViewTkCo.Columns.Add(cmb);
            ////    dataGridView1.DataSource = dtCards;



            //#endregion


            #region example compound box
            //DataTable dtCards;
            //dtCards = new DataTable();
            //dtCards.Columns.Add("printedString");
            //dtCards.Columns.Add("comboboxValue", typeof(String)); //adding column for combobox
            //dtCards.Rows.Add("1", "real");
            //dtCards.Rows.Add("2", "real");
            //dtCards.Rows.Add("3", "real");
            //dtCards.Rows.Add("4", "real");


            //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //cmb.HeaderText = "Select Data";
            //cmb.Name = "cmb";
            //cmb.MaxDropDownItems = 2;
            //cmb.Items.Add("real");
            //cmb.Items.Add("sham");
            //cmb.DataPropertyName = "comboboxValue"; //Bound value to the datasource

            //dataGridView1.Columns.Add(cmb);
            //dataGridView1.DataSource = dtCards;

            #endregion



            dataGridViewTkCo.DataSource = dt;


            DGV_DateTimePicker.DateTimePickerColumn col = new DGV_DateTimePicker.DateTimePickerColumn();
            col.HeaderText = "Ngày chứng từ";
            col.Name = "Ngày_chứng_từ";
            col.DataPropertyName = "ngayctuhide";
            dataGridViewTkCo.Columns.Add(col);


            //    dataGridViewTkCo.Columns.Remove("Tk_Có");

            #region  //    bindDataToDataGridViewComboPrograme(); Tk_Có

            DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();


            List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            var rs = from tbl_dstaikhoan in dc.tbl_dstaikhoans
                     orderby tbl_dstaikhoan.matk
                     select tbl_dstaikhoan;
            foreach (var item in rs)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk.Trim();
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                CombomCollection.Add(cb);
            }

            cmbdgv.DataSource = CombomCollection;
            cmbdgv.HeaderText = "Tk_Có";
            cmbdgv.Name = "Tk_Có";
            cmbdgv.ValueMember = "Value";
            cmbdgv.DisplayMember = "Text";
            cmbdgv.Width = 100;
            cmbdgv.DropDownWidth = 300;
            cmbdgv.DataPropertyName = "tkCohide"; //Bound value to the datasource


            dataGridViewTkCo.Columns.Add(cmbdgv);





            #endregion binddata
            //    dataGridViewTkCo.Columns["tkCohide"].Visible = false;
            //    dataGridViewTkCo.Columns["ngayctuhide"].Visible = false;

            dataGridViewTkCo.Columns["Tk_Có"].DisplayIndex = 0;
            dataGridViewTkCo.Columns["Tk_Có"].Width = 100;
            dataGridViewTkCo.Columns["Tk_Có"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewTkCo.Columns["Mã_chi_tiết"].DisplayIndex = 1;
            dataGridViewTkCo.Columns["Mã_chi_tiết"].Width = 100;
            dataGridViewTkCo.Columns["Mã_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkCo.Columns["Mã_chi_tiết"].ReadOnly = true;
            dataGridViewTkCo.Columns["Mã_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;

            dataGridViewTkCo.Columns["Tên_chi_tiết"].DisplayIndex = 2;
            dataGridViewTkCo.Columns["Tên_chi_tiết"].Width = 200;
            dataGridViewTkCo.Columns["Tên_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkCo.Columns["Tên_chi_tiết"].ReadOnly = true;
            dataGridViewTkCo.Columns["Tên_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;


            dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;
            dataGridViewTkCo.Columns["Số_tiền"].Width = 100;
            dataGridViewTkCo.Columns["Số_tiền"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkCo.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";


            dataGridViewTkCo.Columns["Diễn_giải"].DisplayIndex = 4;
            dataGridViewTkCo.Columns["Diễn_giải"].Width = 300;
            dataGridViewTkCo.Columns["Diễn_giải"].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridViewTkCo.Columns["Ký_hiêu"].DisplayIndex = 5;
            dataGridViewTkCo.Columns["Ký_hiêu"].Width = 100;
            dataGridViewTkCo.Columns["Ký_hiêu"].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridViewTkCo.Columns["Ngày_chứng_từ"].DisplayIndex = 6;
            dataGridViewTkCo.Columns["Ngày_chứng_từ"].Width = 100;
            dataGridViewTkCo.Columns["Ngày_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridViewTkCo.Columns["Số_chứng_từ"].DisplayIndex = 7;
            dataGridViewTkCo.Columns["Số_chứng_từ"].Width = 200;
            dataGridViewTkCo.Columns["Số_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;



            //       dataGridViewTkCo.Columns["Ngày_chứng_từ"].DisplayIndex = 1;
            //       this.dataGridViewTkCo.Columns["Ngày_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;






            #endregion datatable temp



            dataGridViewListphieuthu.DataSource = Model.Phieuthuchi.LisDanhSachphieuthuchi("PT");

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
                txtquyenso.Focus();

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
                txtsotien.Focus();



            }
        }

        private void cbsotien_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtsochungtugoc.Focus();

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


            #region add new phieu thu


            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            tbl_SoQuy soquy = new tbl_SoQuy();


            soquy.quyenso = txtquyenso.Text.ToString();



            soquy.PsCo = 0;

            if (Utils.IsValidnumber(txtsotien.Text))
            {
                soquy.PsNo = double.Parse(txtsotien.Text.Trim());
            }
            else
            {
                MessageBox.Show("Số tiền gõ vào phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsotien.Focus();
                return;
            }

            //if (this.cb_channel.SelectedItem != null)
            if (cbtkno.SelectedItem != null)
            {
                soquy.TKtienmat = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài khoản tiền mặt ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbtkno.Focus();
                return;
            }

            if (txttaikhoanco.Text != null)
            {

                if (txttaikhoanco.Text.Length > 225)
                {
                    soquy.TKdoiung = txttaikhoanco.Text.ToString().Substring(225);
                }
                else
                {
                    soquy.TKdoiung = txttaikhoanco.Text.ToString();
                }

            }
            else
            {
                MessageBox.Show("Bạn chưa hạch toán tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridViewTkCo.Focus();
                return;
            }


            //     if (Utils.IsValidnumber(lbmachitetno.Text))
            //    {
            soquy.ChitietTM = this.tknochitiet;
            //    int.Parse(lbmachitetno.Text.Trim());
            //   }

            //     if (Utils.IsValidnumber(lbmachitietco.Text))
            //   {
            soquy.Chitietdoiung = this.tkcochitiet;
            //int.Parse(lbmachitietco.Text.Trim());
            //   }


            if (Utils.IsValidnumber(txtsophieu.Text)) //số phiếu thu phaair  lớn hơn 0 và không lặp
            {

                if (int.Parse(txtsophieu.Text.Trim()) > 0)
                {

                    // không lặp
                    if (this.statusphieuthu == 1 || (this.statusphieuthu == 2) && this.sophieuthu != int.Parse(txtsophieu.Text.Trim()))
                    {
                        var sophieuthu = (from tbl_SoQuy in dc.tbl_SoQuys
                                          where (tbl_SoQuy.Sochungtu == int.Parse(txtsophieu.Text.ToString()))
                                          //  && (tbl_SoQuy.TKtienmat == this.tkno)
                                          // && (tbl_SoQuy.ChitietTM == this.tknochitiet)
                                          select tbl_SoQuy).FirstOrDefault();

                        if (sophieuthu != null)
                        {
                            MessageBox.Show("Số phiếu bị lặp, bạn xem lại số phiếu", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtsophieu.Focus();
                            return;
                        }
                        else
                        {

                            soquy.Sochungtu = int.Parse(txtsophieu.Text.Trim());

                        }
                    }
                    else
                    {
                        soquy.Sochungtu = int.Parse(txtsophieu.Text.Trim());
                    }



                }
                else
                {
                    MessageBox.Show("Số phiếu thu phải là số dương", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsophieu.Focus();
                    return;
                }

                this.sophieuthu = int.Parse(txtsophieu.Text.Trim());



            }
            else
            {
                MessageBox.Show("Số phiếu gõ vào phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsophieu.Focus();
                return;
            }


            soquy.Ngayctu = datepickngayphieu.Value;
            if (Utils.IsValidnumber(txtsochungtugoc.Text))
            {
                soquy.Chungtugockemtheo = int.Parse(txtsochungtugoc.Text.Trim());
            }
            else
            {
                MessageBox.Show("Số chứng từ gốc kèm theo phải là số", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsochungtugoc.Focus();
                return;
            }

            if (txtdiengiai.Text.Trim() != "")
            {


                if (txtdiengiai.Text.Length > 225)
                {
                    soquy.Diengiai = txtdiengiai.Text.Trim().Substring(225);
                }
                else
                {
                    soquy.Diengiai = txtdiengiai.Text.Trim();
                }

            }
            else
            {
                MessageBox.Show("Phải nhập diễn giải nội dung nộp tiền ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiengiai.Focus();
                return;
            }


            if (txttennguoinop.Text.Trim() != "")
            {


                if (txttennguoinop.Text.Length > 100)
                {
                    soquy.Nguoinopnhantien = txttennguoinop.Text.Trim().Substring(100);
                }
                else
                {
                    soquy.Nguoinopnhantien = txttennguoinop.Text.Trim();
                }

            }
            else
            {
                MessageBox.Show("Phải nhập tên người nộp tiền ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennguoinop.Focus();
                return;
            }

            if (txtdiachi.Text.Trim() != "")
            {


                if (txtdiachi.Text.Length > 225)
                {
                    soquy.Diachinguoinhannop = txtdiachi.Text.Trim().Substring(225);
                }
                else
                {
                    soquy.Diachinguoinhannop = txtdiachi.Text.Trim();
                }

            }
            else
            {
                MessageBox.Show("Phải nhập tên người nộp tiền ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            soquy.Ngayghiso = DateTime.Today;
            soquy.Username = Utils.getusername();

            soquy.Machungtu = "PT";

            if (this.statusphieuthu == 1)// phieu thu mơi
            {

                dc.tbl_SoQuys.InsertOnSubmit(soquy);
                dc.SubmitChanges();

            }

            if (this.statusphieuthu == 2)
            {

                var phieuchange = (from tbl_SoQuy in dc.tbl_SoQuys
                                   where tbl_SoQuy.id == this.phieuthuid
                                   select tbl_SoQuy).FirstOrDefault();

                if (phieuchange != null)
                {
                    phieuchange.Machungtu = soquy.Machungtu;
                    phieuchange.Chitietdoiung = soquy.Chitietdoiung;
                    phieuchange.ChitietTM = soquy.ChitietTM;
                    phieuchange.Chungtugockemtheo = soquy.Chungtugockemtheo;
                    phieuchange.Diachinguoinhannop = soquy.Diachinguoinhannop;
                    phieuchange.Diengiai = soquy.Diengiai;
                    phieuchange.Machungtu = soquy.Machungtu;
                    phieuchange.Ngayctu = soquy.Ngayctu;
                    phieuchange.Ngayghiso = soquy.Ngayghiso;
                    phieuchange.Nguoinopnhantien = soquy.Nguoinopnhantien;
                    phieuchange.PsNo = soquy.PsNo;
                    phieuchange.Sochungtu = soquy.Sochungtu;

                    phieuchange.TKdoiung = soquy.TKdoiung;
                    phieuchange.TKtienmat = soquy.TKtienmat;
                    phieuchange.Username = soquy.Username;
                    phieuchange.quyenso = soquy.quyenso;
                    //phieuchange. = soquy.Sochungtu;
                    //phieuchange.Sochungtu = soquy.Sochungtu;
                    //phieuchange.Sochungtu = soquy.Sochungtu;
                    //phieuchange.Sochungtu = soquy.Sochungtu;
                    //phieuchange.Sochungtu = soquy.Sochungtu;
                    //phieuchange.Sochungtu = soquy.Sochungtu;




                    dc.SubmitChanges();
                }


            }
            //        newcontract.Customer = double.Parse(cb_customerka.Text.Trim());// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            //        newcontract.CustomerType = "SAP";

            //if (this.cb_channel.SelectedItem != null)
            //{
            //    //  newcontract.Channel = this.cb_channel.SelectedItem.ToString();

            //    newcontract.Channel = (cb_channel.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            //}


            #endregion add new phieu thu


            #region  ghi vao so cai

            string tkcotext = "";
            // int dem = 0;
            for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            {

                if ((string)dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value != "")
                {

                    tbl_Socai socai = new tbl_Socai();

                    //  //  string username, string tkno, string tkco, float psno, float psco, string diengiai, string manghiepvu, int sochunngtu, DateTime ngaychungtu, DateTime ngayghiso


                    socai.TkCo = dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim();
                    if ((string)dataGridViewTkCo.Rows[idrow].Cells["Mã_chi_tiết"].Value != "")
                    {
                        socai.MaCTietTKCo = int.Parse(dataGridViewTkCo.Rows[idrow].Cells["Mã_chi_tiết"].Value.ToString());

                    }

                    if (dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].Value != null)
                    {
                        socai.Kyhieuctu = dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].Value.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Bạn chua nhập ký hiệu chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].
                        return;
                    }

                    if (dataGridViewTkCo.Rows[idrow].Cells["Số_chứng_từ"].Value != null)
                    {
                        socai.Soctu = int.Parse(dataGridViewTkCo.Rows[idrow].Cells["Số_chứng_từ"].Value.ToString());

                    }
                    else
                    {
                        MessageBox.Show("Bạn chua nhập số chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].
                        return;
                    }

                    if ((string)dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].Value != "")
                    {
                        socai.Kyhieuctu = dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].Value.ToString();

                    }

                    if (cbtkno.SelectedItem != null)
                    {
                        socai.TkNo = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Bạn chua định khoản tài khoản tiền mặt", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataGridViewTkCo.Focus();
                        return;
                    }




                    if (lb_machitietno.Text != null)
                    {
                        socai.MaCTietTKNo = int.Parse(lb_machitietno.Text.ToString());
                    }



                    if (dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value != DBNull.Value)
                    {
                        socai.PsCo = double.Parse(dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value.ToString());
                        socai.PsNo = double.Parse(dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Bạn chua nhập số tiền", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataGridViewTkCo.Focus();
                        return;
                    }

                    socai.Diengiai = dataGridViewTkCo.Rows[idrow].Cells["Diễn_giải"].Value.ToString();
                    socai.manghiepvu = "PT";
                    socai.nghiepvuso = int.Parse(txtsophieu.Text.ToString());


                    if (dataGridViewTkCo.Rows[idrow].Cells["Ngày_chứng_từ"].Value != null)
                    {
                        socai.Ngayctu = (DateTime)dataGridViewTkCo.Rows[idrow].Cells["Ngày_chứng_từ"].Value;
                    }
                    else
                    {
                        MessageBox.Show("Bạn chua nhập ngày chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataGridViewTkCo.Focus();
                        return;
                    }

                    socai.Ngayghiso = DateTime.Today;
                    socai.username = Utils.getusername();

                    // ghi no tai kkhoan tien mat

                    // ghi co/ no vao so cai tai khoan so cai
                    Model.Taikhoanketoan.ghisocaitk(socai);


                    //dataGridViewTkCo.Columns["Tk_Có"].DisplayIndex = 0;
                    //dataGridViewTkCo.Columns["Tk_Có"].Width = 100;
                    //dataGridViewTkCo.Columns["Tk_Có"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    //dataGridViewTkCo.Columns["Mã_chi_tiết"].DisplayIndex = 1;
                    //dataGridViewTkCo.Columns["Mã_chi_tiết"].Width = 100;
                    //dataGridViewTkCo.Columns["Mã_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    //dataGridViewTkCo.Columns["Mã_chi_tiết"].ReadOnly = true;
                    //dataGridViewTkCo.Columns["Mã_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;

                    //dataGridViewTkCo.Columns["Tên_chi_tiết"].DisplayIndex = 2;
                    //dataGridViewTkCo.Columns["Tên_chi_tiết"].Width = 200;
                    //dataGridViewTkCo.Columns["Tên_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    //dataGridViewTkCo.Columns["Tên_chi_tiết"].ReadOnly = true;
                    //dataGridViewTkCo.Columns["Tên_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;


                    //dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;
                    //dataGridViewTkCo.Columns["Số_tiền"].Width = 100;
                    //dataGridViewTkCo.Columns["Số_tiền"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    //dataGridViewTkCo.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";


                    //dataGridViewTkCo.Columns["Diễn_giải"].DisplayIndex = 4;
                    //dataGridViewTkCo.Columns["Diễn_giải"].Width = 300;
                    //dataGridViewTkCo.Columns["Diễn_giải"].SortMode = DataGridViewColumnSortMode.NotSortable;


                    //dataGridViewTkCo.Columns["Ký_hiêu"].DisplayIndex = 5;
                    //dataGridViewTkCo.Columns["Ký_hiêu"].Width = 100;
                    //dataGridViewTkCo.Columns["Ký_hiêu"].SortMode = DataGridViewColumnSortMode.NotSortable;


                    //dataGridViewTkCo.Columns["Ngày_chứng_từ"].DisplayIndex = 6;
                    //dataGridViewTkCo.Columns["Ngày_chứng_từ"].Width = 100;
                    //dataGridViewTkCo.Columns["Ngày_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;


                    //dataGridViewTkCo.Columns["Số_chứng_từ"].DisplayIndex = 7;
                    //dataGridViewTkCo.Columns["Số_chứng_từ"].Width = 200;
                    //dataGridViewTkCo.Columns["Số_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;







                    //dem = dem + 1;
                    //if (dem > 1)
                    //{

                    //    tkcotext += ";" + dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim(); // chính la program

                    //}
                    //else
                    //{
                    //    tkcotext += dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim(); // chính la program

                    //}

                }





            }

            txttaikhoanco.Text = tkcotext;


            #endregion




            MessageBox.Show("Số phiếu vừa lưu: " + this.sophieuthu, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);


            #region  list black phiếu
            btsua.Enabled = false;

            txtsophieu.Text = "";
            txttennguoinop.Text = "";
            txtdiachi.Text = "";
            txtdiengiai.Text = "";
            txtsotien.Text = "";
            txtsochungtugoc.Text = "";

            lbtenchitietno.Text = "";

            cbtkno.SelectedIndex = -1;


            datepickngayphieu.Focus();



            #endregion

            dataGridViewListphieuthu.DataSource = Model.Phieuthuchi.LisDanhSachphieuthuchi("PT");

        }

        private void dataGridViewListphieuthu_Paint(object sender, PaintEventArgs e)
        {

            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            foreach (var c in dataGridViewListphieuthu.Columns)
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

            //    dataGridViewTkCo.Focus();

        }


        private void cbtaikhoanco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            #region  list black phiếu
            datepickngayphieu.Enabled = true;
            txtquyenso.Enabled = true;
            txtsophieu.Enabled = true;
            txttennguoinop.Enabled = true;
            txtdiachi.Enabled = true;
            txtdiengiai.Enabled = true;
            txtsotien.Enabled = true;
            txtsochungtugoc.Enabled = true;
            btluu.Enabled = true;
            //    cbtaikhoanco.Enabled = true;
            cbtkno.Enabled = true;
            btsua.Enabled = false;

            txtsophieu.Text = "";
            txttennguoinop.Text = "";
            txtdiachi.Text = "";
            txtdiengiai.Text = "";
            txtsotien.Text = "";
            txtsochungtugoc.Text = "";
            txtquyenso.Text = "";
            lbtenchitietno.Text = "";

            cbtkno.SelectedIndex = -1;

            lb_machitietno.Text = "";
            lbtenchitietno.Text = "";
            txttaikhoanco.Text = "";

            datepickngayphieu.Focus();


            this.phieuthuid = -1;

            this.statusphieuthu = 1; // tạo mới

            #endregion
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string username = Utils.getusername();

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rptpthu = from phieuthud in dc.tblRpt_PhieuThus
                          where phieuthud.username == username
                          select phieuthud;

            dc.tblRpt_PhieuThus.DeleteAllOnSubmit(rptpthu);
            dc.SubmitChanges();


            var phieuthu = (from tbl_SoQuy in dc.tbl_SoQuys
                            where tbl_SoQuy.id == this.phieuthuid
                            select new
                            {

                                //     tencongty = Model.Congty.getnamecongty(),
                                //     diachicongty = Model.Congty.getdiachicongty(),
                                ////     masothue = Model.Congty.getmasothuecongty(),
                                //   tengiamdoc = Model.Congty.gettengiamdoccongty(),
                                //    tenketoantruong = Model.Congty.gettenketoantruongcongty(),

                                sophieuthu = tbl_SoQuy.Sochungtu,
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
                                quyenso = tbl_SoQuy.quyenso,

                            }).FirstOrDefault();

            //   this.dataGridViewListphieuthu.DataSource = phieuthu;

            #region  view reports payment request  

            //Control_ac ctrac = new Control_ac();

            //var rs1 = ctrac.KArptdataset1(dc);
            //var rs2 = ctrac.KArptdataset2(dc);



            if (phieuthu != null)
            {


                #region  insert vao rpt phieu thu

                tblRpt_PhieuThu pt = new tblRpt_PhieuThu();
                pt.tencongty = Model.Congty.getnamecongty();
                pt.diachicongty = Model.Congty.getdiachicongty();
                pt.masothue = Model.Congty.getmasothuecongty();
                pt.tengiamdoc = Model.Congty.gettengiamdoccongty();
                pt.tenketoantruong = Model.Congty.gettenketoantruongcongty();
                pt.sophieuthu = phieuthu.sophieuthu;
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
                pt.quyenso = phieuthu.quyenso;

                dc.tblRpt_PhieuThus.InsertOnSubmit(pt);
                dc.SubmitChanges();
                #endregion

                var rsphieuthu = from tblRpt_PhieuThu in dc.tblRpt_PhieuThus
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

            try
            {
                this.phieuthuid = (int)this.dataGridViewListphieuthu.Rows[this.dataGridViewListphieuthu.CurrentCell.RowIndex].Cells["ID"].Value;


            }
            catch (Exception)
            {

                this.phieuthuid = 0;
            }

            if (this.phieuthuid != 0)
            {

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                #region view load form
                var phieuthu = (from tbl_SoQuy in dc.tbl_SoQuys
                                where tbl_SoQuy.id == this.phieuthuid
                                select new
                                {

                                    //     tencongty = Model.Congty.getnamecongty(),
                                    //     diachicongty = Model.Congty.getdiachicongty(),
                                    ////     masothue = Model.Congty.getmasothuecongty(),
                                    //   tengiamdoc = Model.Congty.gettengiamdoccongty(),
                                    //    tenketoantruong = Model.Congty.gettenketoantruongcongty(),

                                    sophieuthu = tbl_SoQuy.Sochungtu,
                                    ngaychungtu = tbl_SoQuy.Ngayctu,
                                    nguoinoptien = tbl_SoQuy.Nguoinopnhantien,
                                    //    nguoilapphieu = Utils.getname(),
                                    diachinguoinop = tbl_SoQuy.Diachinguoinhannop,
                                    lydothu = tbl_SoQuy.Diengiai,
                                    sotien = tbl_SoQuy.PsNo,
                                    //   sotienbangchu = Utils.ChuyenSo(tbl_SoQuy.PsNo.ToString()),
                                    sochungtugoc = tbl_SoQuy.Chungtugockemtheo,
                                    //    username = Utils.getusername(),

                                    quyenso = tbl_SoQuy.quyenso,
                                }).FirstOrDefault();


                if (phieuthu != null)
                {
                    datepickngayphieu.Value = phieuthu.ngaychungtu;
                    txtsophieu.Text = phieuthu.sophieuthu.ToString();
                    txttennguoinop.Text = phieuthu.nguoinoptien;
                    txtdiachi.Text = phieuthu.diachinguoinop;
                    txtdiengiai.Text = phieuthu.lydothu;
                    txtsotien.Text = phieuthu.sotien.ToString();
                    txtsochungtugoc.Text = phieuthu.sochungtugoc.ToString();


                    if (phieuthu.quyenso != null)
                    {
                        txtquyenso.Text = phieuthu.quyenso.ToString();
                    }
                    else
                    {
                        txtquyenso.Text = "";
                    }


                    datepickngayphieu.Enabled = false;
                    txtsophieu.Enabled = false;
                    txttennguoinop.Enabled = false;
                    txtdiachi.Enabled = false;
                    txtdiengiai.Enabled = false;
                    txtsotien.Enabled = false;
                    txtsochungtugoc.Enabled = false;

                    btsua.Enabled = true;
                    txtquyenso.Enabled = false;




                    cbtkno.Enabled = false;



                    this.statusphieuthu = 3;// View

                }



                #endregion view load form











            }


        }

        private void dataGridViewListphieuthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var phieuthu = (from tbl_SoQuy in dc.tbl_SoQuys
                            where tbl_SoQuy.id == this.phieuthuid
                            select tbl_SoQuy).FirstOrDefault();

            if (phieuthu != null)
            {
                this.sophieuthu = phieuthu.Sochungtu;

                dc.tbl_SoQuys.DeleteOnSubmit(phieuthu);
                dc.SubmitChanges();

                MessageBox.Show("Đã xóa phiếu thu: " + this.sophieuthu, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  Model.
                #region load list phieu thu
                var Listphieuthu = from listpt in dc.tbl_SoQuys
                                   where listpt.Machungtu == "PT" // mã 8 là tiền mặt
                                   select new
                                   {

                                       Ngày_chứng_từ = listpt.Ngayctu,
                                       Số_chứng_từ = "PT-" + listpt.Sochungtu,
                                       TK_Nợ = listpt.TKtienmat,
                                       TK_Có = listpt.TKdoiung,
                                       Số_Tiền = listpt.PsNo,
                                       Diễn_Giải = listpt.Diengiai,
                                       Người_nộp = listpt.Nguoinopnhantien,
                                       Địa_chỉ = listpt.Diachinguoinhannop,
                                       Username = listpt.Username,
                                       Ngày_nhập_liệu = listpt.Ngayghiso,
                                       ID = listpt.id

                                   };

                dataGridViewListphieuthu.DataSource = Listphieuthu;
                #endregion


            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            datepickngayphieu.Enabled = true;
            txtsophieu.Enabled = true;
            if (txtsophieu.Text != null)
            {
                this.sophieuthu = int.Parse(txtsophieu.Text.ToString());
            }


            txtquyenso.Enabled = true;

            txttennguoinop.Enabled = true;
            txtdiachi.Enabled = true;
            txtdiengiai.Enabled = true;
            txtsotien.Enabled = true;
            txtsochungtugoc.Enabled = true;
            btluu.Enabled = true;

            //   cbtaikhoanco.Enabled = true;
            cbtkno.Enabled = true;

            this.statusphieuthu = 2;

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
                txtsotien.Focus();

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
                txtsochungtugoc.Focus();

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
                View.BeeHtoansocaidoiungphieuthu BeeHtoansocaidoiung = new BeeHtoansocaidoiungphieuthu(this, "Địa chỉ", "", "");
                BeeHtoansocaidoiung.ShowDialog();
            }



        }

        private void txtsotien_TextChanged(object sender, EventArgs e)
        {

            //if (Utils.IsValidnumber(txtsotien.Text.ToString()))
            //{
            //    this.pssotienno = txtsotien.Text;
            //}
            //else
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

                    dataGridViewTkCo.Rows[i].Cells[colname].Value = SelectedItem;




                    //      MessageBox.Show(dataGridProgramdetail.Rows[i].Cells["Program"].Value.ToString());

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





        }

        private void dataGridViewTkCo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //currentCell = this.dataGridViewTkCo.CurrentCell;


            //if (currentCell.Value != null && currentCell.ColumnIndex == 1) // cot 1 la ve ma tai khoan
            //{

            //    #region điền thông tin code ma chi tiet luon


            //    string taikhoan = currentCell.Value.ToString();// currentCell.Value.ToString();// (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
            //    int i = currentCell.RowIndex;                              //     this.matk = taikhoan;


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

            //            if (!kq)
            //            {
            //                //        beeselectinput

            //                View.beeselectinput selecdetail = new beeselectinput("Chọn chi tiết tài khoản ", listcb);

            //                selecdetail.ShowDialog();







            //                bool chon = selecdetail.kq;
            //                if (chon)
            //                {
            //                    string machitiet = selecdetail.value;
            //                    string namechitiet = selecdetail.valuetext;
            //                    //     lbmachitietco.Visible = true;

            //                    //       lbtenchitietno.Visible = true;
            //                    //     this.tknochitiet = int.Parse(selecdetail.value.ToString());
            //                    //     lbmachitietco.Text = machitiet;
            //                    //   lbtenchitietno.Text = namechitiet;
            //                    // Tên_chi_tiết
            //                    dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = machitiet;
            //                    dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = namechitiet;


            //                }

            //            }
            //            else
            //            {
            //                dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //                dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";

            //            }
            //            //  selecdetail.Text;

            //        }
            //        else
            //        {
            //            dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //            dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";

            //        }




            //    }
            //    else
            //    {
            //        dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //        dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";

            //    }


            //    #region  view lai cac tk có

            //    String tkcotext = "";
            //    int dem = 0;
            //    for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            //    {





            //        //     tbl_kacontractsdatadetail newdetailContract = new tbl_kacontractsdatadetail();
            //        // //    newdetailContract.Customercode = newcontract.Customer;//double.Parse(cb_customerka.Text);// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            //        ///    newdetailContract.CustomerType = newcontract.CustomerType;

            //        if ((String)dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value != null)
            //        {
            //            dem = dem + 1;
            //            if (dem > 1)
            //            {

            //                tkcotext += ";" + dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim(); // chính la program

            //            }
            //            else
            //            {
            //                tkcotext += dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim(); // chính la program

            //            }

            //        }





            //    }

            //    txttaikhoanco.Text = tkcotext;


            //    #endregion




            //    #endregion


            //}


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
    }
}

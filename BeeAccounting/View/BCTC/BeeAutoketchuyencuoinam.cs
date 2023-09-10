using BEEACCOUNT.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BEEACCOUNT.View
{
    public partial class BeeAutoketchuyencuoinam : Form
    {

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public string namchon; 

        public void reloadgridview()
        {


            dataGridViewketchuyen.DataSource = Model.formatBCTC.LisDanhSachbuttoanketchuyen();
            dataGridViewketchuyen.Columns["ID"].Visible = false;

        }



        void Control_KeyPress(object sender, KeyEventArgs e)
        {






            if (e.Control == true && e.KeyCode == Keys.N)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "Tài khoản")
                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    // View.ThemtktinhCDKT ThemtktinhCDKT = new ThemtktinhCDKT(this);
                    //     ThemtktinhCDKT.Show();
                }





            }


        }

        public View.Main main1;
        public BeeAutoketchuyencuoinam(View.Main Main)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);  // để đọc từ bàn phím phím tắt
            this.main1 = Main;

            Model.Username used = new Model.Username();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            string username = Utils.getusername();





            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            string yearchon;
            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Chọn năm")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {

              //  this.namchon = 

                View.Beeyearsellect Beeyearsellect = new View.Beeyearsellect();
                Beeyearsellect.ShowDialog();

                yearchon = Beeyearsellect.year;
                chon = Beeyearsellect.chon;


                if (chon)
                {

                    this.namchon = yearchon;


                    #region caculation tinhsoducactaikhoanketchuyen
                    SqlConnection conn2 = null;
                    SqlDataReader rdr1 = null;

                    string destConnString = Utils.getConnectionstr();
                    try
                    {

                        conn2 = new SqlConnection(destConnString);
                        conn2.Open();
                        SqlCommand cmd1 = new SqlCommand("tinhsoducactaikhoanketchuyen", conn2);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandTimeout = 0;
                        cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = Utils.getusername();
                        cmd1.Parameters.Add("@yearchon", SqlDbType.Int).Value = int.Parse(yearchon);
                        //   cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;




                        rdr1 = cmd1.ExecuteReader();



                    }
                    finally
                    {
                        if (conn2 != null)
                        {
                            conn2.Close();
                        }
                        if (rdr1 != null)
                        {
                            rdr1.Close();
                        }
                    }
                    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #endregion



                }

            }


            #region load datenew

            reloadgridview();
            //            dataGridViewformatBCTC.DataSource = // Model.formatBCTC.LisDanhSachformat();



            //    dataGridViewformatBCTC = Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewformatBCTC);


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


            }
        }

        private void datepickngayphieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // datepickngayphieu.
                e.Handled = true;



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



            }
        }

        private void cbdiachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;


            }
        }

        private void cbdiengiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;




            }
        }

        private void cbsotien_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;


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

        public static void ghisoQuy(tbl_SoQuy soquy)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            dc.tbl_SoQuys.InsertOnSubmit(soquy);
            dc.SubmitChanges();

        }

        private void button1_Click(object sender, EventArgs e)  // new phieu thu
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);








        }

        private void dataGridViewListphieuthu_Paint(object sender, PaintEventArgs e)
        {

            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            //foreach (var c in dataGridViewListphieuthu.Columns)
            //{
            //    DataGridViewColumn clm = (DataGridViewColumn)c;
            //    clm.HeaderText = clm.HeaderText.Replace("_", " ");
            //}

            // Next





        }

        private void cbtkno_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }


        private void cbtaikhoanco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {



        }

        private void dataGridViewListphieuthu_CellClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void dataGridViewListphieuthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void txtsophieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;


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

            foreach (var c in dataGridViewketchuyen.Columns)
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
                    string colname = this.dataGridViewketchuyen.Columns[this.dataGridViewketchuyen.CurrentCell.ColumnIndex].Name;

                    dataGridViewketchuyen.Rows[i].Cells[colname].Value = SelectedItem;





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


                currentCell = this.dataGridViewketchuyen.CurrentCell;




            }
        }


        private void dataGridViewTkCo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            int i = e.RowIndex;
            string colname = view.Columns[e.ColumnIndex].Name;

            //       #region if la slect tai khoan co chi tiet








        }

        private void dataGridViewTkCo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            //DataGridView view = (DataGridView)sender;
            //int i = view.CurrentRow.Index;
            //string colname = view.Columns[view.CurrentCell.ColumnIndex].Name;
            ////      string SelectedItem = view.Rows[i].Cells["Tk_Có"].Value.ToString();

            //#region if la slect tai khoan co chi tiet

            //if (colname == "Tk_Có" && SelectedItem != "" && currentCell != null)
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

            //                    dataGridViewformatBCTC.Rows[i].Cells["Mã_chi_tiết"].Value = machitiet;
            //                    dataGridViewformatBCTC.Rows[i].Cells["Tên_chi_tiết"].Value = namechitiet;


            //                }
            //                else
            //                {
            //                    dataGridViewformatBCTC.Rows[i].Cells["Tk_Có"].Value = "";
            //                    dataGridViewformatBCTC.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //                    dataGridViewformatBCTC.Rows[i].Cells["Tên_chi_tiết"].Value = "";
            //                }




            //            }
            //            else
            //            {
            //                dataGridViewformatBCTC.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //                dataGridViewformatBCTC.Rows[i].Cells["Tên_chi_tiết"].Value = "";


            //            }


            //        }
            //    }


            //    else
            //    {
            //        dataGridViewformatBCTC.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //        dataGridViewformatBCTC.Rows[i].Cells["Tên_chi_tiết"].Value = "";


            //    }

            //}

            //#endregion





        }

        private void dataGridViewTkCo_Leave(object sender, EventArgs e)
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




        }

        private void txtsotien_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridViewListphieuthu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void datechonnam_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbthang_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbnam_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var ds = from p in dc.CDKTtempketchuyens
                     where p.DuCock - p.DuNock != 0
                     && p.chon == true
                     select p;


            foreach (var item in ds)
            {
                tbl_Socai socai = new tbl_Socai();


                #region  ghi vao so cai

                if (item.DuCock > 0) // sẽ kết chuyển từ có qua nợ của tk kết chuyển == > nọ tk kc  có tk đích
                {
                    socai.TkCo = item.matkketchuyen;
                    socai.TkNo = item.matk;
                    socai.Sohieuchungtu = "AutoKC" + item.nam;
                    socai.PsCo = item.DuCock;
                    socai.PsNo = item.DuCock;
                    //   DateTime tem = new DateTime(int.Parse(item.nam.ToString()), 12, 31);
                    socai.Ngayctu = new DateTime(int.Parse(item.nam.ToString()), 12, 31); // ngay 31 tháng 12 năm đó
                    socai.manghiepvu = "TH";
                    socai.Ngayghiso = new DateTime(int.Parse(item.nam.ToString()), 12, 31); // ngay 31 tháng 12 năm đó
                    socai.username = Utils.getusername();
                    socai.Diengiai = "Auto Kết chuyển cuối năm";



                }

                if (item.DuNock > 0) // sẽ kết chuyển từ no qua co của tk kết chuyển == > co tk kc  no tk đích
                {
                 
                    socai.TkCo = item.matk;
                    socai.TkNo = item.matkketchuyen;
                    socai.Sohieuchungtu = "AutoKC" + item.nam;
                    socai.PsCo = item.DuNock;
                    socai.PsNo = item.DuNock;
                    //   DateTime tem = new DateTime(int.Parse(item.nam.ToString()), 12, 31);
                    socai.Ngayctu = new DateTime(int.Parse(item.nam.ToString()), 12, 31); // ngay 31 tháng 12 năm đó
                    socai.manghiepvu = "TH";
                    socai.Ngayghiso = new DateTime(int.Parse(item.nam.ToString()), 12, 31); // ngay 31 tháng 12 năm đó
                    socai.username = Utils.getusername();
                    socai.Diengiai = "Auto Kết chuyển cuối năm";



                }




                Model.Taikhoanketoan.ghisocaitk(socai);


                // = yearchon;


                #region caculation tinhsoducactaikhoanketchuyen
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("tinhsoducactaikhoanketchuyen", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandTimeout = 0;
                    cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = Utils.getusername();
                    cmd1.Parameters.Add("@yearchon", SqlDbType.Int).Value = int.Parse(this.namchon);
                    //   cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;




                    rdr1 = cmd1.ExecuteReader();



                }
                finally
                {
                    if (conn2 != null)
                    {
                        conn2.Close();
                    }
                    if (rdr1 != null)
                    {
                        rdr1.Close();
                    }
                }
                //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #endregion




                #endregion






            }


            MessageBox.Show("Kết chuyển thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            reloadgridview(); //   this.u


        }

        private void txtmachitieu_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtchuoicachtinh_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtmachitieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewformatBCTC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewketchuyen.RowCount > 0)
            {




                if (this.dataGridViewketchuyen.CurrentCell.RowIndex >= 0)
                {
                    int id = int.Parse(this.dataGridViewketchuyen.Rows[this.dataGridViewketchuyen.CurrentCell.RowIndex].Cells["ID"].Value.ToString());


                    string connection_string = Utils.getConnectionstr();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                    var kq = (from p in dc.CDKTtempketchuyens
                              where p.id == id
                              select p).FirstOrDefault();

                    if (kq != null)
                    {
                        kq.chon = !kq.chon;
                        dc.SubmitChanges();

                        reloadgridview(); //   this.u
                        //         txtmachitieu.Text = chitieuchon.machitieu;
                        //       txtchuoicachtinh.Text = chitieuchon.cachtinh;
                    }

                }




            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewformatBCTC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}

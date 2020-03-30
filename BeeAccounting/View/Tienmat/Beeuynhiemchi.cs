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
using BEEACCOUNT.shared;


namespace BEEACCOUNT.View
{
    public partial class Beeuynhiemchi : Form
    {
        public int statusphieu { get; set; } // mới  // 2 suawra // 3 display //
        public int phieuuynhiemchiID { get; set; }
        public string sophieuuynhiemchi { get; set; }
        public string sophieuuynhiemchiold { get; set; }

        //    public string sophieuchi { get; set; }
        //      public string tkno { get; set; }
        //   public int tknochitiet { get; set; }
        public string tkno { get; set; }
        public int tknochitiet { get; set; }
        public double pssotienno { get; set; }
        public double pssotienco { get; set; }


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


        public void add_detailGridviewTkNoUNC(tbl_Socai socaitemp)
        {





            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //---------------

            DataTable dataTable = (DataTable)dataGridViewTkNo.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            //    drToAdd["Tk_Có"] = socaitemp.TkCo;
            drToAdd["Diễn_giải"] = socaitemp.Diengiai;
            //      drToAdd["Số_chứng_từ"] = socaitemp.Soctu;
            //   drToAdd["Ký_hiêu"] = socaitemp.Kyhieuctu;

            if (socaitemp.PsNo != null)
            {
                drToAdd["Số_tiền"] = socaitemp.PsNo;
            }

            drToAdd["Mã_chi_tiết"] = socaitemp.MaCTietTKCo;
            drToAdd["Tên_chi_tiết"] = socaitemp.tenchitietCo;

            drToAdd["tkNohide"] = socaitemp.TkNo;
            drToAdd["Nợ_TK"] = socaitemp.TkNo;

            //     drToAdd["ngayctuhide"] = socaitemp.Ngayctu;

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();



            //int i = dataTable.Rows.Count - 1;
            ////   int i = dataGridViewTkCo.RowCount -1;

            //DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridViewTkNo.Rows[i].Cells["Nợ_TK"];
            //DataGridViewCell dgvc = (DataGridViewCell)dataGridViewTkNo.Rows[i].Cells["Nợ_TK"];

            //#region tim item comboboc

            //foreach (ComboboxItem item in (List<ComboboxItem>)cb.DataSource)
            //{

            //    if (item.Value.ToString().Trim() == socaitemp.TkNo.ToString().Trim())
            //    {

            //        dataGridViewTkNo.Rows[i].Cells["Nợ_TK"].Value = item.Value;
            //    }

            //}


            //#endregion tom item comboubox


            //   ComboboxItem cbx = (ComboboxItem)cb.Items[3];
            //     dataGridViewTkCo.Rows[i].Cells["Tk_Có"].Value = cbx.Value;
            if (Utils.IsValidnumber(txtsotienno.Text))
            {
                this.pssotienno = double.Parse(txtsotienno.Text);


            }



        }

        public void add_detailGridviewTkCoUNC(tbl_Socai socaitemp)
        {





            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //---------------

            DataTable dataTable = (DataTable)dataGridViewTkNo.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            //    drToAdd["Tk_Có"] = socaitemp.TkCo;
            drToAdd["Diễn_giải"] = socaitemp.Diengiai;
            //     drToAdd["Số_chứng_từ"] = socaitemp.Soctu;
            //    drToAdd["Ký_hiêu"] = socaitemp.Kyhieuctu;
            drToAdd["Số_tiền"] = socaitemp.PsNo;
            drToAdd["Mã_chi_tiết"] = socaitemp.MaCTietTKCo;
            drToAdd["Tên_chi_tiết"] = socaitemp.tenchitietCo;

            drToAdd["tkCohide"] = socaitemp.TkNo;


            drToAdd["ngayctuhide"] = socaitemp.Ngayctu;

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();




            if (Utils.IsValidnumber(txtsotienno.Text))
            {
                this.pssotienno = double.Parse(txtsotienno.Text);

            }



        }

        public void reloadseachview(string nguoinop, string diachi, string noidung)
        {



            dataGridViewListphieuchi.DataSource = Model.Phieuthuchi.reloadseachview("UNC", nguoinop, diachi, noidung);


        }

        public void cleartoblankphieu()
        {

            #region  list black phiếu
            ngaychungtu.Enabled = true;

            txtsophieu.Enabled = true;
            txttendonvithuhuong.Enabled = true;
            txtsotaikhoan.Enabled = true;
            txtnoidung.Enabled = true;
            txtsotien.Enabled = true;
            txttainganhang.Enabled = true;
            txttinhthanh.Enabled = true;

            btluu.Visible = true;
            btluu.Enabled = true;

            tbchontkco.Enabled = true;
            btsua.Enabled = false;

            txtsophieu.Text = "";
            txttendonvithuhuong.Text = "";
            txtsotaikhoan.Text = "";
            txtnoidung.Text = "";
            txtsotien.Text = "";
            txttainganhang.Text = "";
            txttinhthanh.Text = "";

            cbluudanhsach.Checked = false;
            txttengoinhotaikhoan.Text = "";

            lbtenchitietco.Text = "";

            //     tbchontkco.SelectedIndex = -1;
            lb_machitietco.Text = "";
            //         lb_machitietco.Text = "";
            lbtenchitietco.Text = "";
            txttaikhoanno.Text = "";

            ngaychungtu.Focus();


            this.phieuuynhiemchiID = -1;

            this.statusphieu = 1; // tạo mới
            dataGridViewTkNo = Model.Uynhiemchi.reloadnewdetailtaikhoanNo(dataGridViewTkNo);
            //  dataGridViewTkNo = Model.Phieuthuchi.reloadnewdetailtaikhoanNo(dataGridViewTkNo);
            #endregion


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
                    //  View.BeeSeachtwofield sheaching = new BeeSeachtwofield(this, "Người nôp", "Địa chỉ", "Nội dung");
                    // sheaching.Show();
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
                    View.Beehtsocaiuynhiemchi BeeHtoansocaidoiung = new Beehtsocaiuynhiemchi(this, "Địa chỉ", "", "");
                    BeeHtoansocaidoiung.Show();
                }




            }


        }

        public View.Main main1;
        public Beeuynhiemchi(View.Main Main)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);  // để đọc từ bàn phím phím tắt

            this.pssotienno = 0;
            this.pssotienco = 0;
            this.main1 = Main;

            this.statusphieu = 1; // tạo mới

            Model.Username used = new Model.Username();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            string username = Utils.getusername();


            #region load datenew
            this.ngaychungtu.Value = DateTime.Today.Date;
            datechonnam.Value = DateTime.Today.Date;

            this.lbtenchitietco.Text = "";
            lb_machitietco.Text = "";


            //#region load tk tmat


            //var rs2 = from tk in dc.tbl_dstaikhoans
            //          where tk.loaitkid == "tien" // mã 8 là tiền mặt
            //          select tk;

            ////      string drowdownshow = "";

            //foreach (var item in rs2)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.matk;
            //    cb.Text = item.matk + ":" + item.tentk;
            //    this.tbchontkco.Items.Add(cb); // CombomCollection.Add(cb);

            //}

            //#endregion load tk nợ



            //    dataGridViewTkNo = Model.Phieuthuchi.reloadnewdetailtaikhoanNo(dataGridViewTkNo);

            dataGridViewTkNo = Model.Uynhiemchi.reloadnewdetailtaikhoanNo(dataGridViewTkNo);
            dataGridViewListphieuchi.DataSource = Model.Uynhiemchi.LisDanhSachuynhiemchi("UNC", datechonnam.Value);


            //  dataGridViewListphieuchi.DataSource = Model.Phieuthuchi.LisDanhSachphieuchi("PC");

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
                txttendonvithuhuong.Focus();

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
                txtsophieu.Focus();

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
                bttimkiem.Focus();

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
                txttainganhang.Focus();


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
                tbchontkco.Focus();



            }

        }

        private void cbsochungtugoc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                tbchontkco.Focus();
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

        public static void ghisoBank(tbl_SoBANK soBank)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            dc.tbl_SoBANKs.InsertOnSubmit(soBank);
            dc.SubmitChanges();

        }

        private void button1_Click(object sender, EventArgs e)  // new phieu 
        {


            #region check đối ứng unc

            if (Utils.IsValidnumber(txtsotien.Text.ToString()))
            {
                this.pssotienco = double.Parse(txtsotien.Text);
            }
            else
            {
                MessageBox.Show("Kiểm tra lại số tiền của ủy nhiệm chi", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].
                return;
            }



            #endregion


            bool checkhead = true;

            #region  check từng dong sổ tk nợ
            for (int idrow = 0; idrow < dataGridViewTkNo.RowCount - 1; idrow++) // 'dataGridViewTkNo'
            {
                if (dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value != DBNull.Value)
                {




                    if (dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value == DBNull.Value)
                    {

                        MessageBox.Show("Bạn chua nhập số tiền", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkhead = false;
                        return;
                    }


                }
                else
                {
                    //if (dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value == "")
                    //{

                    MessageBox.Show("Bạn chua định khoản tài khoản tiền mặt", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkhead = false;
                    return;
                    //}

                }

            }


            #endregion


            if (this.pssotienco - this.pssotienno != 0)
            {
                MessageBox.Show("Phát sinh nợ và có phải bảng nhau, bạn hãy kiểm tra lại", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].
                return;
            }






            if (checkhead == true)
            {

                #region add new phieu chi

                bool checkdetail = true;
                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                tbl_SoBANK soBank = new tbl_SoBANK();




                soBank.PsNo = 0;

                if (Utils.IsValidnumber(txtsotien.Text.Replace(",", "")))
                {
                    soBank.PsCo = double.Parse(txtsotien.Text.Replace(",", "").Trim());

                    soBank.sotienbangchu = Utils.ChuyenSo(decimal.Parse(txtsotien.Text.Replace(",", "").Trim()));

                }
                else
                {
                    MessageBox.Show("Số tiền gõ vào phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsotien.Focus();
                    soBank = null;
                    checkdetail = false;
                    return;
                }

                //if (this.cb_channel.SelectedItem != null)
                if (this.tkno != "")
                {
                    soBank.TKBANk = this.tkno;// this.tkco;//;
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn tài khoản Bank ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbchontkco.Focus();
                    soBank = null;
                    checkdetail = false;
                    return;
                }

                if (txttaikhoanno.Text != null)
                {

                    if (txttaikhoanno.Text.Length > 225)
                    {
                        soBank.TKdoiung = txttaikhoanno.Text.Truncate(225);
                    }
                    else
                    {
                        soBank.TKdoiung = txttaikhoanno.Text.Truncate(225);
                    }

                }
                else
                {
                    MessageBox.Show("Bạn chưa hạch toán tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridViewTkNo.Focus();
                    soBank = null;
                    checkdetail = false;
                    return;
                }




                if (lb_machitietco.Text != "")
                {
                    soBank.ChitietBAnk = int.Parse(lb_machitietco.Text.ToString());
                }
                else
                {
                    soBank.ChitietBAnk = 0;
                }

                if (lbtenchitietco.Text != "")
                {
                    soBank.TenchitietTM = lbtenchitietco.Text.Truncate(225);
                }



                soBank.Chitietdoiung = this.tknochitiet;


                if (Utils.IsValidnumber(txtsophieu.Text)) //số phiếu thu phaair  lớn hơn 0 và không lặp
                {

                    if (int.Parse(txtsophieu.Text.Trim()) > 0)
                    {

                        // không lặp
                        //if (this.statusphieuchi == 1 || (this.statusphieuchi == 2) && this.sophieuchi != txtsophieu.Text.Trim())
                        //{
                        var uynhiemchi = (from ppbank in dc.tbl_SoBANKs
                                          where (ppbank.Sophieu.Trim() == txtsophieu.Text.ToString().Trim())
                                                && (ppbank.Machungtu == "UNC")
                                          select ppbank).FirstOrDefault();

                        if (uynhiemchi != null)
                        {
                            if (this.statusphieu == 1)
                            {
                                MessageBox.Show("Số phiếu bị lặp, bạn xem lại số phiếu", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtsophieu.Focus();
                                soBank = null;
                                checkdetail = false;
                                return;
                            }


                        }
                        else
                        {

                            soBank.Sophieu = txtsophieu.Text.Truncate(50);

                        }



                    }
                    else
                    {
                        MessageBox.Show("Số phiếu phải là số dương", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtsophieu.Focus();
                        soBank = null;
                        checkdetail = false;
                        return;
                    }

                    this.sophieuuynhiemchi = txtsophieu.Text.Truncate(50);



                }
                else
                {
                    MessageBox.Show("Số phiếu gõ vào phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsophieu.Focus();
                    soBank = null;
                    checkdetail = false;
                    return;
                }


                soBank.Ngayctu = ngaychungtu.Value;


                if (txtnoidung.Text.Trim() != "")
                {
                    soBank.noidung = txtnoidung.Text.Truncate(225);



                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập nội dung !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtnoidung.Focus();
                    soBank = null;
                    checkdetail = false;
                    return;
                }


                if (txttendonvithuhuong.Text.Trim() != "")
                {


                    soBank.nguoithuhuong = txttendonvithuhuong.Text.Truncate(225);

                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên đơn vị thụ hưởng ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttendonvithuhuong.Focus();
                    soBank = null;
                    checkdetail = false;
                    return;
                }

                if (txtsotaikhoan.Text.Trim() != "")
                {


                    soBank.sotknguoithuhuong = txtsotaikhoan.Text.Truncate(225);

                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập số tài khoản ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsotaikhoan.Focus();
                    soBank = null;
                    checkdetail = false;
                    return;
                }

                // txttainganhang
                if (txttainganhang.Text.Trim() != "")
                {


                    soBank.tainganhang = txttainganhang.Text.Truncate(225);

                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập ngân hàng ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttainganhang.Focus();
                    soBank = null;
                    checkdetail = false;
                    return;
                }

                if (txttinhthanh.Text.Trim() != "")
                {

                    soBank.tinhthanhcuanganhang = txttinhthanh.Text.Truncate(225);

                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tỉnh thành của tài khoản ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttinhthanh.Focus();
                    soBank = null;
                    checkdetail = false;
                    return;
                }

                if (cbluudanhsach.Checked == true)
                {

                    if (txttengoinhotaikhoan.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tên gợi nhớ của tài khoản ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txttengoinhotaikhoan.Focus();
                        soBank = null;
                        checkdetail = false;
                        return;

                    }
                    

              
                }


                soBank.Ngayghiso = DateTime.Today;
                soBank.Username = Utils.getusername();
                //          soBank.macty = Model.Username.getmacty();
                soBank.Machungtu = "UNC";

                if (this.statusphieu == 1 || this.statusphieu == 2)// phieu thu mơi, hoặc sửa
                {

                    string tkcotext = "";



                    #region  check so cai



                    // int dem = 0;
                    for (int idrow = 0; idrow < dataGridViewTkNo.RowCount - 1; idrow++) //' Nợ_TK'
                    {

                        if (dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value != DBNull.Value && checkhead == true)
                        {

                            if (dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value == DBNull.Value)
                            {
                                MessageBox.Show("Bạn chua nhập số tiền dòng: " + idrow.ToString(), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    dataGridViewTkNo.Focus();
                                //  socai = null;
                                checkdetail = false;
                                return;
                            }




                        }
                        else
                        {
                            checkdetail = false;
                            return;
                        }




                    }

                    #endregion

                    if (checkdetail == true && checkhead == true)
                    {
                        if (this.statusphieu == 2)
                        {
                            #region  xóa phiếu thu cũ nếu staus = 2  chang

                            var phieubank = (from p in dc.tbl_SoBANKs
                                             where p.Sophieu == this.sophieuuynhiemchiold
                                             select p).FirstOrDefault();

                            if (phieubank != null)
                            {
                                //   this.sophieuchi = phieuthu.Sophieu;

                                Model.hachtoantonghop.xoa("UNC", this.sophieuuynhiemchiold);

                                dc.tbl_SoBANKs.DeleteOnSubmit(phieubank);
                                dc.SubmitChanges();



                            }




                            #endregion

                        }



                        ghisoBank(soBank);




                        #region  ghi vao so cai


                        //       string tkcotext = "";
                        // int dem = 0;
                        for (int idrow = 0; idrow < dataGridViewTkNo.RowCount - 1; idrow++)
                        {

                            if (dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value != DBNull.Value && checkhead == true)
                            {
                                tkcotext = tkcotext + dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value.ToString().Trim();
                                txttaikhoanno.Text = tkcotext;

                                tbl_Socai socai = new tbl_Socai();

                                //  //  string username, string tkno, string tkco, float psno, float psco, string diengiai, string manghiepvu, int sochunngtu, DateTime ngaychungtu, DateTime ngayghiso


                                socai.TkNo = dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value.ToString().Trim();
                                if (dataGridViewTkNo.Rows[idrow].Cells["Mã_chi_tiết"].Value != DBNull.Value)///zcxzv
                                {


                                    if (Utils.IsValidnumber((string)dataGridViewTkNo.Rows[idrow].Cells["Mã_chi_tiết"].Value))
                                    {
                                        socai.MaCTietTKCo = int.Parse(dataGridViewTkNo.Rows[idrow].Cells["Mã_chi_tiết"].Value.ToString());
                                    }
                                    else
                                    {
                                        socai.MaCTietTKCo = null;
                                    }


                                }
                                if (dataGridViewTkNo.Rows[idrow].Cells["Tên_chi_tiết"].Value != DBNull.Value)
                                {

                                    socai.tenchitietCo = dataGridViewTkNo.Rows[idrow].Cells["Tên_chi_tiết"].Value.ToString().Truncate(225);

                                }



                                if (dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value != DBNull.Value)
                                {
                                    socai.TkCo = this.tkno; //this.tkco;//;

                                }
                                else
                                {
                                    MessageBox.Show("Bạn chua định khoản tài khoản !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    dataGridViewTkNo.Focus();
                                    return;
                                }




                                if (lb_machitietco.Text != "")
                                {
                                    if (Utils.IsValidnumber(lb_machitietco.Text.ToString()))
                                    {
                                        socai.MaCTietTKNo = int.Parse(lb_machitietco.Text.ToString());

                                    }
                                    else
                                    {
                                        socai.MaCTietTKNo = null;
                                    }

                                }


                                if (lbtenchitietco.Text != "")
                                {

                                    socai.tenchitietNo = lbtenchitietco.Text.ToString().Truncate(225);


                                }



                                if (dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value != DBNull.Value)
                                {
                                    socai.PsCo = double.Parse(dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value.ToString());
                                    socai.PsNo = double.Parse(dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value.ToString());
                                }
                                else
                                {
                                    MessageBox.Show("Bạn chua nhập số tiền", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    dataGridViewTkNo.Focus();
                                    return;
                                }

                                socai.Diengiai = dataGridViewTkNo.Rows[idrow].Cells["Diễn_giải"].Value.ToString();
                                socai.manghiepvu = "UNC";
                                socai.Sohieuchungtu = txtsophieu.Text.Truncate(50);


                                socai.Ngayctu = ngaychungtu.Value;
                                socai.Ngayghiso = DateTime.Today;
                                socai.username = Utils.getusername();

                                //        socai.macty = Model.Username.getmacty();
                                // ghi no tai kkhoan tien mat

                                // ghi co/ no vao so cai tai khoan so cai


                                Model.Taikhoanketoan.ghisocaitk(socai);




                            }





                        }

                        txttaikhoanno.Text = tkcotext;


                        #endregion



                    }








                }


                #endregion add new phieu chi

                MessageBox.Show("Số phiếu vừa lưu: " + this.sophieuuynhiemchi, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cbluudanhsach.Checked == true)
                {
                    tbl_dstknganhang taikhoan = new tbl_dstknganhang();

                    taikhoan.nguoithuhuong = txttendonvithuhuong.Text.Truncate(225);
                    taikhoan.sotknguoithuhuong = txtsotaikhoan.Text.Truncate(225);
                    taikhoan.tainganhang = txttainganhang.Text.Truncate(225);
                    taikhoan.tinhthanhcuanganhang = txttinhthanh.Text.Truncate(225);
                    taikhoan.ghichu = txttengoinhotaikhoan.Text.Truncate(225);


                    dc.tbl_dstknganhangs.InsertOnSubmit(taikhoan);
                    dc.SubmitChanges();

                    cbluudanhsach.Checked = false;
                    txttengoinhotaikhoan.Text = "";
                }


            }


            this.cleartoblankphieu();

            dataGridViewListphieuchi.DataSource = Model.Uynhiemchi.LisDanhSachuynhiemchi("UNC", ngaychungtu.Value);

        }

        private void dataGridViewListphieuthu_Paint(object sender, PaintEventArgs e)
        {

            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            foreach (var c in dataGridViewListphieuchi.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

            // Next





        }



        private void cbtaikhoanco_SelectedIndexChanged(object sender, EventArgs e)
        {

            //    dataGridViewTkCo.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            this.cleartoblankphieu();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            string username = Utils.getusername();

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var sophieuunc = (from ppunc in dc.tbl_SoBANKs
                              where ppunc.id == this.phieuuynhiemchiID
                              select new
                              {

                                  nguoithuhuong = ppunc.nguoithuhuong,
                                  sotknguoithuhuong = ppunc.sotknguoithuhuong,
                                  tainganhang = ppunc.tainganhang,
                                  tinhthanhcuanganhang = ppunc.tinhthanhcuanganhang,

                                  sotienchuyen = ppunc.PsCo,
                                  sotienbangchu = ppunc.sotienbangchu,// Utils.ChuyenSo(decimal.Parse(ppunc.PsCo.ToString())),
                                  noidung = ppunc.noidung,
                                  ngaychungtu = ppunc.Ngayctu,



                              });

            //   this.dataGridViewListphieuthu.DataSource = phieuthu;

            #region  view unc

            if (sophieuunc != null)
            {

                Utils ut = new Utils();
                var dataset1 = ut.ToDataTable(dc, sophieuunc);

                Reportsview rpt = new Reportsview(dataset1, null, "Uynhiemchi.rdlc");
                rpt.ShowDialog();

            }

            #endregion view unc

        }

        private void dataGridViewListphieuthu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewListphieuthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbxoa_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var phieuunc = (from ppbank in dc.tbl_SoBANKs
                            where ppbank.id == this.phieuuynhiemchiID
                            select ppbank).FirstOrDefault();

            if (phieuunc != null)
            {
                this.sophieuuynhiemchi = phieuunc.Sophieu;

                Model.hachtoantonghop.xoa("UNC", phieuunc.Sophieu);

                dc.tbl_SoBANKs.DeleteOnSubmit(phieuunc);
                dc.SubmitChanges();




                MessageBox.Show("Đã xóa UNC: " + this.sophieuuynhiemchi, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                dataGridViewListphieuchi.DataSource = Model.Uynhiemchi.LisDanhSachuynhiemchi("UNC",DateTime.Today);




            }
            else
            {
                MessageBox.Show("Không tìm thấy số phiếu: " + this.sophieuuynhiemchi, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }




        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.statusphieu = 2;

            btluu.Visible = true;


            ngaychungtu.Enabled = true;


            txtsophieu.Enabled = true;
            //if (txtsophieu.Text != "")
            //{
            //    this.sophieuchi = txtsophieu.Text.ToString();
            //    this.sophieuchiold = txtsophieu.Text.ToString();
            //}



            txttendonvithuhuong.Enabled = true;
            txtsotaikhoan.Enabled = true;
            txtnoidung.Enabled = true;
            txtsotien.Enabled = true;
            txttainganhang.Enabled = true;
            btluu.Enabled = true;

            txttinhthanh.Enabled = true;
            tbchontkco.Enabled = true;

            this.statusphieu = 2;

        }

        private void txtsophieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                txttendonvithuhuong.Focus();

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
                txtsotaikhoan.Focus();

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
                txtnoidung.Focus();

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
                // txtsochungtugoc.Focus();

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
                tbchontkco.Focus();

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
                View.Beehtsocaiuynhiemchi BeeHtoansocaidoiung = new Beehtsocaiuynhiemchi(this, "Địa chỉ", "", "");
                BeeHtoansocaidoiung.ShowDialog();
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

            foreach (var c in dataGridViewTkNo.Columns)
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
                    string colname = this.dataGridViewTkNo.Columns[this.dataGridViewTkNo.CurrentCell.ColumnIndex].Name;

                    dataGridViewTkNo.Rows[i].Cells[colname].Value = SelectedItem;





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


                currentCell = this.dataGridViewTkNo.CurrentCell;




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

            //DataGridView view = (DataGridView)sender;
            //int i = e.RowIndex;
            //string colname = view.Columns[e.ColumnIndex].Name;

            ////       #region if la slect tai khoan co chi tiet

            //if (colname == "Nợ_TK")
            //{



            //    #region  view lai cac tk có

            //    String tkcotext = "";


            //    int dem = 0;
            //    for (int idrow = 0; idrow < dataGridViewTkNo.RowCount - 1; idrow++)
            //    {

            //        if (dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value != null)
            //        {



            //            dem = dem + 1;
            //            if (dem > 1)
            //            {

            //                tkcotext += ";" + dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value.ToString().Trim(); // chính la program

            //            }
            //            else
            //            {
            //                tkcotext += dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value.ToString().Trim(); // chính la program
            //                                                                                                 //dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;


            //            }


            //        }


            //    }

            //    txttaikhoanno.Text = tkcotext;
            //    #endregion

            //}



            //#region  view lai cac tk nợ


            //double tongcong = 0;


            //for (int idrow = 0; idrow < dataGridViewTkNo.RowCount - 1; idrow++)
            //{


            //    if (dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"] != null)

            //    {
            //        if (Utils.IsValidnumber(dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value.ToString()))
            //        {

            //            tongcong += double.Parse(dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value.ToString());
            //        }
            //    }







            //}

            ////txtValueSotienCo.Text = tongcong.ToString();
            //this.pssotienno = tongcong;
            //txtsotienno.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);
            //#endregion








        }

        private void dataGridViewTkCo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            //DataGridView view = (DataGridView)sender;
            //int i = view.CurrentRow.Index;
            //string colname = view.Columns[view.CurrentCell.ColumnIndex].Name;
            //string SelectedItem = view.Rows[i].Cells["Nợ_TK"].Value.ToString();

            //#region if la slect tai khoan co chi tiet

            //if (colname == "Nợ_TK" && SelectedItem != "")
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

            //                    dataGridViewTkNo.Rows[i].Cells["Mã_chi_tiết"].Value = machitiet;
            //                    dataGridViewTkNo.Rows[i].Cells["Tên_chi_tiết"].Value = namechitiet;


            //                }
            //                else
            //                {
            //                    dataGridViewTkNo.Rows[i].Cells["Nợ_TK"].Value = "";
            //                    dataGridViewTkNo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //                    dataGridViewTkNo.Rows[i].Cells["Tên_chi_tiết"].Value = "";
            //                }




            //            }
            //            else
            //            {
            //                dataGridViewTkNo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //                dataGridViewTkNo.Rows[i].Cells["Tên_chi_tiết"].Value = "";


            //            }


            //        }
            //    }


            //    else
            //    {
            //        dataGridViewTkNo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //        dataGridViewTkNo.Rows[i].Cells["Tên_chi_tiết"].Value = "";


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

            #region  view lai cac tk nợ


            double tongcong = 0;


            for (int idrow = 0; idrow < dataGridViewTkNo.RowCount - 1; idrow++)
            {


                if (dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"] != null)

                {
                    if (Utils.IsValidnumber(dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value.ToString()))
                    {

                        tongcong += double.Parse(dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value.ToString());



                    }
                }



            }

            //txtValueSotienCo.Text = tongcong.ToString();
            this.pssotienno = tongcong;
            txtsotienno.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);
            #endregion


            #region  view lai cac tk có

            String tkcotext = "";


            int dem = 0;
            for (int idrow = 0; idrow < dataGridViewTkNo.RowCount - 1; idrow++)
            {

                if (dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value != null)
                {



                    dem = dem + 1;
                    if (dem > 1)
                    {

                        tkcotext += ";" + dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value.ToString().Trim(); // chính la program

                    }
                    else
                    {
                        tkcotext += dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value.ToString().Trim(); // chính la program
                                                                                                         //dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;


                    }


                }


            }

            txttaikhoanno.Text = tkcotext;
            #endregion


        }

        private void txtsotienco_TextChanged(object sender, EventArgs e)
        {
            //  if (Utils.IsValidnumber(txtsotienno.Text.ToString()))
            // {
            //      this.pssotienco = double.Parse(txtsotienno.Text);
            //   }
            //else
            //{
            //    txtsotienco.Text = "";
            //}


        }

        private void dataGridViewTkNo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {


            #region  view lai cac tk có

            String tkcotext = "";


            int dem = 0;
            for (int idrow = 0; idrow < dataGridViewTkNo.RowCount - 1; idrow++)
            {

                if (dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value != null)
                {



                    dem = dem + 1;
                    if (dem > 1)
                    {

                        tkcotext += ";" + dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value.ToString().Trim(); // chính la program

                    }
                    else
                    {
                        tkcotext += dataGridViewTkNo.Rows[idrow].Cells["Nợ_TK"].Value.ToString().Trim(); // chính la program
                                                                                                         //dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;


                    }


                }


            }

            txttaikhoanno.Text = tkcotext;
            #endregion

            #region  view lai cac tk nợ


            double tongcong = 0;


            for (int idrow = 0; idrow < dataGridViewTkNo.RowCount - 1; idrow++)
            {


                if (dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value != DBNull.Value)

                {
                    if (Utils.IsValidnumber(dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value.ToString()))
                    {

                        tongcong += double.Parse(dataGridViewTkNo.Rows[idrow].Cells["Số_tiền"].Value.ToString());
                    }
                }







            }

            //txtValueSotienCo.Text = tongcong.ToString();
            this.pssotienno = tongcong;
            txtsotienno.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);
            #endregion



        }

        private void txtsotien_Leave(object sender, EventArgs e)
        {
            if (txtsotien.Text != "")
            {

                if (Utils.IsValidnumber(txtsotien.Text.Replace(",", "")))
                {
                    //txtValueSotienNo.Text = txtsotien.Text.Replace(",","");
                    this.pssotienno = double.Parse(txtsotien.Text.Replace(",", ""));
                    txtsotien.Text = double.Parse(txtsotien.Text.Replace(",", "")).ToString("#,#", CultureInfo.InvariantCulture);

                }



            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tbchontkco_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string taikhoan = this.tkno;// this.tkco;//;
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
                            lb_machitietco.Visible = true;

                            lbtenchitietco.Visible = true;
                            lb_machitietco.Visible = true;
                            this.tknochitiet = int.Parse(selecdetail.value.ToString());
                            lb_machitietco.Text = machitiet;
                            lbtenchitietco.Text = namechitiet;

                        }

                    }
                    else
                    {
                        this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                              //     lb_machitietco.Text = machitiet;
                        lbtenchitietco.Text = "";//namechitiet;
                        lb_machitietco.Text = "";
                    }
                    //  selecdetail.Text;

                }
                else
                {
                    this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                          //     lb_machitietco.Text = machitiet;
                    lbtenchitietco.Text = "";//namechitiet;
                    lb_machitietco.Text = "";
                }




            }
            else
            {
                this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                      //     lb_machitietco.Text = machitiet;
                lbtenchitietco.Text = "";//namechitiet;
                lb_machitietco.Text = "";
            }

        }

        private void dataGridViewListphieuchi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            try
            {
                this.phieuuynhiemchiID = (int)this.dataGridViewListphieuchi.Rows[this.dataGridViewListphieuchi.CurrentCell.RowIndex].Cells["ID"].Value;


            }
            catch (Exception)
            {

                this.phieuuynhiemchiID = 0;
            }

            if (this.phieuuynhiemchiID != 0)
            {


                #region view load form
                var uynhiemchi = (from pp in dc.tbl_SoBANKs
                                  where pp.id == this.phieuuynhiemchiID
                                  //       && tbl_SoQuy.macty == macty
                                  select new
                                  {

                                      //     tencongty = Model.Congty.getnamecongty(),
                                      //     diachicongty = Model.Congty.getdiachicongty(),
                                      ////     masothue = Model.Congty.getmasothuecongty(),
                                      //   tengiamdoc = Model.Congty.gettengiamdoccongty(),
                                      //    tenketoantruong = Model.Congty.gettenketoantruongcongty(),

                                      sophieu = pp.Sophieu,
                                      ngaychungtu = pp.Ngayctu,
                                      nguoithuhuong = pp.nguoithuhuong,
                                      nganhangnguoithuhuong = pp.tainganhang,
                                      tinhthanhcuanganhang = pp.tinhthanhcuanganhang,
                                      //    nguoilapphieu = Utils.getname(),
                                      sotaikhoan = pp.sotknguoithuhuong,
                                      noidung = pp.noidung,
                                      sotien = pp.PsCo,
                                      //   sotienbangchu = Utils.ChuyenSo(tbl_SoQuy.PsNo.ToString()),

                                      //    username = Utils.getusername(),


                                      machitietco = pp.ChitietBAnk,
                                      tentkchitiet = pp.TenchitietTM,
                                      tkco = pp.TKBANk,

                                      taikhoandoiung = pp.TKdoiung,

                                  }).FirstOrDefault();


                if (uynhiemchi != null)
                {
                    ngaychungtu.Value = uynhiemchi.ngaychungtu;
                    if (uynhiemchi.sophieu != null)
                    {
                        txtsophieu.Text = uynhiemchi.sophieu.ToString();

                    }
                    else
                    {
                        txtsophieu.Text = "";
                    }
                    this.sophieuuynhiemchiold = uynhiemchi.sophieu;
                    this.sophieuuynhiemchi = uynhiemchi.sophieu;

                    txttendonvithuhuong.Text = uynhiemchi.nguoithuhuong;



                    txtsotaikhoan.Text = uynhiemchi.sotaikhoan;
                    txttinhthanh.Text = uynhiemchi.tinhthanhcuanganhang;

                    txttainganhang.Text = uynhiemchi.nganhangnguoithuhuong;


                    txtnoidung.Text = uynhiemchi.noidung;
                    txtsotien.Text = double.Parse(uynhiemchi.sotien.ToString()).ToString("#,#", CultureInfo.InvariantCulture);
                    //txtValueSotienNo.Text = phieuthu.sotien.ToString();
                    this.pssotienco = double.Parse(uynhiemchi.sotien.ToString());


                    //        txtsochungtugoc.Text = phieuchi.sochungtugoc.ToString();

                    txttaikhoanno.Text = uynhiemchi.taikhoandoiung;
                    if (uynhiemchi.machitietco != null)
                    {
                        lb_machitietco.Text = uynhiemchi.machitietco.ToString();
                    }
                    else
                    {
                        lbtenchitietco.Text = "";
                        lb_machitietco.Text = "";
                    }

                    if (uynhiemchi.tentkchitiet != null)
                    {
                        lbtenchitietco.Text = uynhiemchi.tentkchitiet.ToString();
                    }
                    else
                    {
                        lbtenchitietco.Text = "";
                        lb_machitietco.Text = "";
                    }
                    if (uynhiemchi.tkco != null)
                    {
                        this.tkno = uynhiemchi.tkco.Trim();
                        lbtkco.Text = uynhiemchi.tkco.Trim();
                    }

                    ngaychungtu.Enabled = false;
                    txtsophieu.Enabled = false;
                    txttendonvithuhuong.Enabled = false;
                    txtsotaikhoan.Enabled = false;
                    txtnoidung.Enabled = false;
                    txtsotien.Enabled = false;

                    txttinhthanh.Enabled = false; ;

                    txttainganhang.Enabled = false;

                    //       txtsochungtugoc.Enabled = false;

                    btsua.Enabled = true;




                    tbchontkco.Enabled = false;


                    this.statusphieu = 3;// View

                    Model.Phieuthuchi.reloadnewdetailtaikhoanNo(dataGridViewTkNo);

                    if (uynhiemchi.tkco != null)
                    {
                        Model.Phieuthuchi.reloaddetailuynhiemchi(this.dataGridViewTkNo, this, uynhiemchi.tkco.Trim(), uynhiemchi.sophieu);

                    }

                    btluu.Visible = false;

                }



                #endregion view load form


            }





            tabControl1.SelectedTab = tabPage1;
        }

        private void txtsotien_TextChanged_1(object sender, EventArgs e)
        {


            //if (Utils.IsValidnumber(txtsotien.Text))
            //{

            //    this.pssotienco = double.Parse(txtsotien.Text);

            //}






        }

        private void dataGridViewListphieuchi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbchontkno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
                string seaching = tbchontkco.Text.Trim();

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                var danhsachtaikhoan = from c in db.tbl_dstaikhoans
                                       where c.matk.Contains(seaching)
                                       && c.loaitkid == "nganhang"// == "tien"
                                       select new
                                       {
                                           Mã_tài_khoản = c.matk,
                                           Tên_tài_khoản = c.tentk,
                                           c.id

                                       };
                if (danhsachtaikhoan.Count() > 0)
                {
                    Beeviewandchoose chontaikhoan = new Beeviewandchoose("CHỌN TÀI KHOẢN KẾ TOÁN", danhsachtaikhoan, db);
                    chontaikhoan.ShowDialog();
                    int idtaikhoan = chontaikhoan.value;
                    bool kq = chontaikhoan.kq;


                    if (kq)
                    {
                        var taikhoanchon = (from c in db.tbl_dstaikhoans
                                            where c.id == idtaikhoan
                                            select c).FirstOrDefault();


                        this.tkno = taikhoanchon.matk;
                        lbtkco.Text = taikhoanchon.matk + ": " + taikhoanchon.tentk.Trim();


                        #region chọn tài khoản chi tiết
                        //var detail = (from c in db.tbl_dstaikhoans
                        //              where c.matk.Trim() == tkno.Trim()
                        //              select c).FirstOrDefault();



                        if (taikhoanchon.loaichitiet == true) // là co theo doi chi tiết
                        {

                            List<beeselectinput.ComboboxItem> listcb = new List<beeselectinput.ComboboxItem>();
                            var rs = from tbl_machitiettk in db.tbl_machitiettks
                                     where tbl_machitiettk.matk.Trim() == this.tkno.Trim()
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

                                bool kq2 = false;
                                foreach (Form frm in fc)
                                {
                                    if (frm.Text == "beeselectinput")


                                    {
                                        kq2 = true;
                                        frm.Focus();

                                    }
                                }

                                if (!kq2)
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
                                        //     lb_machitietco.Visible = true;

                                        lbtenchitietco.Visible = true;
                                        lb_machitietco.Visible = true;
                                        this.tknochitiet = int.Parse(selecdetail.value.ToString());
                                        //     lb_machitietco.Text = machitiet;
                                        lbtenchitietco.Text = namechitiet;
                                        lb_machitietco.Text = machitiet;
                                    }

                                }
                                else
                                {
                                    this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                                          //     lb_machitietco.Text = machitiet;
                                    lbtenchitietco.Text = "";//namechitiet;
                                    lb_machitietco.Text = "";
                                }
                                //  selecdetail.Text;

                            }
                            else
                            {
                                this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                                      //     lb_machitietco.Text = machitiet;
                                lbtenchitietco.Text = "";//namechitiet;
                                lb_machitietco.Text = "";
                            }




                        }
                        else
                        {
                            this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                                  //     lb_machitietco.Text = machitiet;
                            lbtenchitietco.Text = "";//namechitiet;
                            lb_machitietco.Text = "";
                        }



                        #endregion

                        txtsophieu.Focus();
                    }
                    else
                    {
                        this.tkno = "";
                        this.tknochitiet = -1;
                        lbtkco.Text = "";
                        lb_machitietco.Text = "";
                        tbchontkco.Focus();
                    }


                } // nếu danh sách tài khoản có

                txtsophieu.Focus();

                //      xx

            }// end chon tai khoan no







        }

        private void txtsophieu_TextChanged(object sender, EventArgs e)
        {
            // this.sophieuuynhiemchi = txtsophieu.Text.ToString();
        }

        private void txttainganhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txttinhthanh.Focus();


            }
        }

        private void txttinhthanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtnoidung.Focus();


            }
        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            string seaching = txttendonvithuhuong.Text.Trim();

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            var dstknganhang = from c in db.tbl_dstknganhangs
                               where c.nguoithuhuong.Contains(seaching)
                               select new
                               {
                                   Tên_đơn_vị_thụ_hưởng = c.nguoithuhuong,
                                   Số_tài_khoản_ngân_hàng = c.sotknguoithuhuong,
                                   Tại_ngân_hàng = c.tainganhang,
                                   Chi_nhánh_ngân_hàng_tại = c.tinhthanhcuanganhang,
                                   Ghi_chú = c.ghichu,
                                   c.id

                               };
            if (dstknganhang.Count() > 0)
            {
                Beeviewandchoose chontaikhoan = new Beeviewandchoose("CHỌN TÀI KHOẢN NGÂN HÀNG", dstknganhang, db);
                chontaikhoan.ShowDialog();
                int idtaikhoan = chontaikhoan.value;
                bool kq = chontaikhoan.kq;


                if (kq)
                {
                    var taikhoanchon = (from c in db.tbl_dstknganhangs
                                        where c.id == idtaikhoan
                                        select c).FirstOrDefault();

                    if (taikhoanchon != null)
                    {
                        txttendonvithuhuong.Text = taikhoanchon.nguoithuhuong;
                        txtsotaikhoan.Text = taikhoanchon.sotknguoithuhuong;
                        txttainganhang.Text = taikhoanchon.tainganhang;
                        txttinhthanh.Text = taikhoanchon.tinhthanhcuanganhang;
                        txtnoidung.Focus();
                    }

                    //  txtsophieu.Focus();
                }
                else
                {
                    txttendonvithuhuong.Text = "";
                    txtsotaikhoan.Text = "";
                    txttainganhang.Text = "";
                    txttinhthanh.Text = "";


                    txttendonvithuhuong.Focus();
                }


            }
            else
            {
                txttendonvithuhuong.Text = "";
                txtsotaikhoan.Text = "";
                txttainganhang.Text = "";
                txttinhthanh.Text = "";

                MessageBox.Show("Không có tài khoản nào tìm thấy !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txttendonvithuhuong.Focus();

            }
            // nếu danh sách tài khoản có

            //  txtsophieu.Focus();
        }

        private void datechonnam_ValueChanged(object sender, EventArgs e)
        {

            dataGridViewListphieuchi.DataSource = Model.Uynhiemchi.LisDanhSachuynhiemchi("UNC", datechonnam.Value);

        }
    }
}

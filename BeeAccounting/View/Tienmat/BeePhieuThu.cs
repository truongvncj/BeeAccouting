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
    public partial class BeePhieuThu : Form
    {
        public int statusphieuthu { get; set; } // mới  // 2 suawra // 3 display //
        public int phieuthuid { get; set; }
        public string sophieuthu { get; set; }
        public string tkno { get; set; }
        public int tknochitiet { get; set; }
        public string tkco { get; set; }
        public int tkcochitiet { get; set; }
        public double pssotienno { get; set; }
        public double pssotienco { get; set; }

        public string sophieuthuOld { get; set; }
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

        public void cleartoblankphieu()
        {

            #region  list black phiếu
            ngaychungtu.Enabled = true;

            txtsophieu.Enabled = true;
            txttennguoi.Enabled = true;
            txtdiachi.Enabled = true;
            txtdiengiai.Enabled = true;
            txtsotien.Enabled = true;
            txtsochungtugoc.Enabled = true;
            btluu.Visible = true;
            btluu.Enabled = true;
            //    cbtaikhoanco.Enabled = true;
            tbchontkno.Enabled = true;
            btsua.Enabled = false;

            txtsophieu.Text = "";
            txttennguoi.Text = "";
            txtdiachi.Text = "";
            txtdiengiai.Text = "";
            txtsotien.Text = "";
            txtsochungtugoc.Text = "";

            lbtenchitietno.Text = "";

            //     tbchontkco.SelectedIndex = -1;
            lb_machitietno.Text = "";
            //         lb_machitietco.Text = "";
            lbtenchitietno.Text = "";
            txttaikhoanco.Text = "";

            ngaychungtu.Focus();


            this.phieuthuid = -1;

            this.statusphieuthu = 1; // tạo mới
            dataGridViewTkCo = Model.Phieuthuchi.reloadnewdetailphieuthu(dataGridViewTkCo);
            #endregion


        }
        public void add_detailGridviewTkCophieuthu(tbl_Socai socaitemp)
        {


            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //---------------

            DataTable dataTable = (DataTable)dataGridViewTkCo.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            drToAdd["Có_TK"] = socaitemp.TkCo;
            drToAdd["Diễn_giải"] = socaitemp.Diengiai;
            //        drToAdd["Số_chứng_từ"] = socaitemp.Soctu;
            //       drToAdd["Ký_hiêu"] = socaitemp.Kyhieuctu;

            if (socaitemp.PsCo != null)
            {
                drToAdd["Số_tiền"] = socaitemp.PsCo;
            }

            drToAdd["Mã_chi_tiết"] = socaitemp.MaCTietTKCo;
            drToAdd["Tên_chi_tiết"] = socaitemp.tenchitietCo;

            drToAdd["tkCohide"] = socaitemp.TkCo;


            //      drToAdd["ngayctuhide"] = socaitemp.Ngayctu;

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();





            if (Utils.IsValidnumber(txtsotienco.Text))
            {
                this.pssotienno = double.Parse(txtsotienco.Text);

            }



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
                    View.BeeHtoansocaiphieuthu BeeHtoansocaidoiung = new BeeHtoansocaiphieuthu(this, "Địa chỉ", "", "");
                    BeeHtoansocaidoiung.Show();
                }




            }


        }

        public View.Main main1;
        public BeePhieuThu(View.Main Main)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);  // để đọc từ bàn phím phím tắt

            this.pssotienno = 0;
            this.pssotienco = 0;
            this.main1 = Main;

            this.statusphieuthu = 1; // tạo mới

            Model.Username used = new Model.Username();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            string username = Utils.getusername();


            #region load datenew
            this.ngaychungtu.Value = DateTime.Today.Date;
            cbthang.Text = DateTime.Today.Date.Month.ToString();
            cbnam.Text = DateTime.Today.Date.Year.ToString();
            this.lbtenchitietno.Text = "";
            lb_machitietno.Text = "";
            //    lb_matktm.Text = "";





            dataGridViewTkCo = Model.Phieuthuchi.reloadnewdetailphieuthu(dataGridViewTkCo);





            dataGridViewListphieuthu.DataSource = Model.Phieuthuchi.LisDanhSachphieuthu("PT", cbthang.Text, cbnam.Text);

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
                txttennguoi.Focus();

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
                ngaychungtu.Focus();
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



            #region check phieu chi

            if (this.pssotienco - this.pssotienno != 0)
            {
                MessageBox.Show("Phát sinh nợ và có phải bảng nhau, bạn hãy kiểm tra lại", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].
                return;
            }


            #endregion


            bool checkhead = true;

            #region  check từng dong sổ tk nợ
            for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++) // 'dataGridViewTkNo'
            {
                if (dataGridViewTkCo.Rows[idrow].Cells["Nợ_TK"].Value != DBNull.Value)
                {




                    if (dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value == DBNull.Value)
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


            if (checkhead == true)
            {

                #region add new phieu 

                bool checkdetail = true;
                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                tbl_SoQuy soquy = new tbl_SoQuy();




                soquy.PsCo = 0;

                if (Utils.IsValidnumber(txtsotien.Text))
                {
                    soquy.PsNo = double.Parse(txtsotien.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Số tiền gõ vào phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsotien.Focus();
                    soquy = null;
                    checkdetail = false;
                    return;
                }

                //if (this.cb_channel.SelectedItem != null)
                if (this.tkno != "")
                {
                    soquy.TKtienmat = this.tkno;// this.tkco;//;
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn tài khoản tiền mặt ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbchontkno.Focus();
                    soquy = null;
                    checkdetail = false;
                    return;
                }

                if (txttaikhoanco.Text != null)
                {

                    if (txttaikhoanco.Text.Length > 225)
                    {
                        soquy.TKdoiung = txttaikhoanco.Text.Truncate(225);
                    }
                    else
                    {
                        soquy.TKdoiung = txttaikhoanco.Text.Truncate(225);
                    }

                }
                else
                {
                    MessageBox.Show("Bạn chưa hạch toán tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridViewTkCo.Focus();
                    soquy = null;
                    checkdetail = false;
                    return;
                }




                if (lb_machitietno.Text != "")
                {
                    soquy.ChitietTM = int.Parse(lb_machitietno.Text.ToString());
                }
                else
                {
                    soquy.ChitietTM = 0;
                }

                if (lbtenchitietno.Text != "")
                {
                    soquy.TenchitietTM = lbtenchitietno.Text.Truncate(225);
                }



                soquy.Chitietdoiung = this.tkcochitiet;


                if (Utils.IsValidnumber(txtsophieu.Text)) //số phiếu thu phaair  lớn hơn 0 và không lặp
                {

                    if (int.Parse(txtsophieu.Text.Trim()) > 0)
                    {

                        // không lặp
                        //if (this.statusphieuchi == 1 || (this.statusphieuchi == 2) && this.sophieuchi != txtsophieu.Text.Trim())
                        //{
                        var sophieuthu = (from tbl_SoQuy in dc.tbl_SoQuys
                                          where (tbl_SoQuy.Sophieu.Trim() == txtsophieu.Text.ToString().Trim())
                                                && (tbl_SoQuy.Machungtu == "PT")
                                          select tbl_SoQuy).FirstOrDefault();

                        if (sophieuthu != null)
                        {
                            //    if (this.statusphieuchi == 1)
                            //     {

                            MessageBox.Show("Số phiếu bị lặp, bạn xem lại số phiếu", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtsophieu.Focus();
                            soquy = null;
                            checkdetail = false;
                            return;

                            //    }

                        }
                        else
                        {

                            soquy.Sophieu = txtsophieu.Text.Truncate(50);
                            this.sophieuthu = txtsophieu.Text.Truncate(50);


                        }
                        //}
                        //else
                        //{
                        //    soquy.Sophieu = txtsophieu.Text.Trim();
                        //}



                    }
                    else
                    {
                        MessageBox.Show("Số phiếu thu phải là số dương", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtsophieu.Focus();
                        soquy = null;
                        checkdetail = false;
                        return;
                    }




                }
                else
                {
                    MessageBox.Show("Số phiếu gõ vào phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsophieu.Focus();
                    soquy = null;
                    checkdetail = false;
                    return;
                }


                soquy.Ngayctu = ngaychungtu.Value;
                if (Utils.IsValidnumber(txtsochungtugoc.Text))
                {
                    soquy.Chungtugockemtheo = int.Parse(txtsochungtugoc.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Số chứng từ gốc kèm theo phải là số", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsochungtugoc.Focus();
                    soquy = null;
                    checkdetail = false;
                    return;
                }

                if (txtdiengiai.Text.Trim() != "")
                {
                    soquy.Diengiai = txtdiengiai.Text.Truncate(225);



                }
                else
                {
                    MessageBox.Show("Phải nhập diễn giải nội dung nộp tiền ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtdiengiai.Focus();
                    soquy = null;
                    checkdetail = false;
                    return;
                }


                if (txttennguoi.Text.Trim() != "")
                {


                    if (txttennguoi.Text.Length > 100)
                    {
                        soquy.Nguoinopnhantien = txttennguoi.Text.Truncate(100);
                    }
                    else
                    {
                        soquy.Nguoinopnhantien = txttennguoi.Text.Truncate(100);
                    }

                }
                else
                {
                    MessageBox.Show("Phải nhập tên người nộp tiền ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttennguoi.Focus();
                    soquy = null;
                    checkdetail = false;
                    return;
                }

                if (txtdiachi.Text.Trim() != "")
                {


                    if (txtdiachi.Text.Length > 225)
                    {
                        soquy.Diachinguoinhannop = txtdiachi.Text.Truncate(225);
                    }
                    else
                    {
                        soquy.Diachinguoinhannop = txtdiachi.Text.Truncate(225);
                    }

                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập địa chỉ ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtdiachi.Focus();
                    soquy = null;
                    checkdetail = false;
                    return;
                }
                soquy.Ngayghiso = DateTime.Today;
                soquy.Username = Utils.getusername();
                //          soquy.macty = Model.Username.getmacty();
                soquy.Machungtu = "PT";

                if (this.statusphieuthu == 1 || this.statusphieuthu == 2)// phieu thu mơi, hoặc sửa
                {

                    string tkcotext = "";



                    #region  check so cai



                    // int dem = 0;
                    for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++) //' Nợ_TK'
                    {

                        if (dataGridViewTkCo.Rows[idrow].Cells["Có_TK"].Value != DBNull.Value && checkhead == true)
                        {

                            if (dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value == DBNull.Value)
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
                  //  MessageBox.Show("gi so cai tk check detail " + checkdetail.ToString() + "head" + checkhead.ToString());
                    if (checkdetail == true && checkhead == true)
                    
                    {

                      //  MessageBox.Show("gi so cai tk" + checkdetail.ToString() + "va" + checkhead.ToString());
                        
                        if (this.statusphieuthu == 2)
                        {
                            #region  xóa phiếu thu cũ nếu staus = 2  chang

                            var phieuthu2 = (from tbl_SoQuy in dc.tbl_SoQuys
                                             where tbl_SoQuy.Sophieu == this.sophieuthuOld
                                             select tbl_SoQuy).FirstOrDefault();

                            if (phieuthu2 != null)
                            {
                                //   this.sophieuchi = phieuthu.Sophieu;

                                Model.hachtoantonghop.xoa("PT", this.sophieuthuOld);

                                dc.tbl_SoQuys.DeleteOnSubmit(phieuthu2);
                                dc.SubmitChanges();



                            }




                            #endregion

                           // xóa bút toán sổ cái của phiếu thu cũ

                        }




                        ghisoQuy(soquy);


                        #region  ghi vao so cai

                        // MessageBox.Show("gi so cai tk tak sai chưa cont  : " + dataGridViewTkCo.RowCount);

                        //       string tkcotext = "";
                        // int dem = 0;
                        for (int idrow = 0; idrow <= dataGridViewTkCo.RowCount - 1; idrow++)
                        {
                          //  MessageBox.Show("gi so cai tk tak sai chưa vapf  : " + idrow.ToString());

                            if (dataGridViewTkCo.Rows[idrow].Cells["Có_TK"].Value != DBNull.Value && checkhead == true)
                            {
                                tkcotext = tkcotext + dataGridViewTkCo.Rows[idrow].Cells["Có_TK"].Value.ToString().Trim();
                                txttaikhoanco.Text = tkcotext;

                             //   MessageBox.Show("gi so cai tk check tex  : " + tkcotext);


                                tbl_Socai socai = new tbl_Socai();

                                //  //  string username, string tkno, string tkco, float psno, float psco, string diengiai, string manghiepvu, int sochunngtu, DateTime ngaychungtu, DateTime ngayghiso


                                socai.TkCo = dataGridViewTkCo.Rows[idrow].Cells["Có_TK"].Value.ToString().Trim();


                                if (dataGridViewTkCo.Rows[idrow].Cells["Mã_chi_tiết"].Value != DBNull.Value)///zcxzv
                                {
                                    socai.MaCTietTKCo = int.Parse(dataGridViewTkCo.Rows[idrow].Cells["Mã_chi_tiết"].Value.ToString());
                                }
                                if (dataGridViewTkCo.Rows[idrow].Cells["Tên_chi_tiết"].Value != DBNull.Value)
                                {

                                    socai.tenchitietCo = dataGridViewTkCo.Rows[idrow].Cells["Tên_chi_tiết"].Value.ToString();

                                }



                                if (this.tkno != "")// xác định có đinh khoản
                                {
                                    socai.TkNo = this.tkno; //this.tkco;//;

                                }
                                else
                                {
                                    MessageBox.Show("Bạn chua định khoản tài khoản tiền mặt", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    dataGridViewTkCo.Focus();
                                    return;
                                }


                                if (lb_machitietno.Text != "")
                                {
                                    if (Utils.IsValidnumber(lb_machitietno.Text.ToString()))
                                    {
                                        socai.MaCTietTKNo = int.Parse(lb_machitietno.Text.ToString());

                                    }
                                    else
                                    {
                                        socai.MaCTietTKNo = null;
                                    }

                                }


                                if (lbtenchitietno.Text != "")
                                {

                                    socai.tenchitietNo = lbtenchitietno.Text.ToString().Truncate(225);


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

                                socai.Diengiai = dataGridViewTkCo.Rows[idrow].Cells["Diễn_giải"].Value.ToString().Truncate(225);
                                socai.manghiepvu = "PT";
                                socai.Sohieuchungtu = txtsophieu.Text.Truncate(50);


                                socai.Ngayctu = ngaychungtu.Value;
                                socai.Ngayghiso = DateTime.Today;
                                socai.username = Utils.getusername();

                                //        socai.macty = Model.Username.getmacty();
                                // ghi no tai kkhoan tien mat

                                // ghi co/ no vao so cai tai khoan so cai

                                //    MessageBox.Show("gi so cai tk" + socai.TkCo + "va" + socai.TkCo);

                                Model.Taikhoanketoan.ghisocaitk(socai);




                            }





                        }

                        //   txttaikhoano.Text = tkcotext;


                        #endregion




                    }








                }


                #endregion add new phieu chi

                MessageBox.Show("Số phiếu vừa lưu: " + this.sophieuthu, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);




            }


            this.cleartoblankphieu();

            dataGridViewListphieuthu.DataSource = Model.Phieuthuchi.LisDanhSachphieuthu("PT", cbthang.Text, cbnam.Text);















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



        private void cbtaikhoanco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
          

            this.cleartoblankphieu();


            //   dataGridViewTkCo = Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);

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
                            where tbl_SoQuy.id == this.phieuthuid
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
                                //    quyenso = tbl_SoQuy.quyenso,

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
                pt.phieuthuso = phieuthu.sophieuthu;
                //   pt.quyenso = phieuthu.quyenso;

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


            string username = Utils.getusername();

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

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



                #region view load form
                var phieuthu = (from tbl_SoQuy in dc.tbl_SoQuys
                                where tbl_SoQuy.id == this.phieuthuid
                                select new
                                {


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

                                    //    quyenso = tbl_SoQuy.quyenso,
                                    machitietno = tbl_SoQuy.ChitietTM,
                                    tentkchitiet = tbl_SoQuy.TenchitietTM,
                                    tkno = tbl_SoQuy.TKtienmat,

                                    taikhoandoiung = tbl_SoQuy.TKdoiung,

                                }).FirstOrDefault();


                if (phieuthu != null)
                {
                    ngaychungtu.Value = phieuthu.ngaychungtu;
                    txtsophieu.Text = phieuthu.sophieuthu.ToString();
                    txttennguoi.Text = phieuthu.nguoinoptien;
                    txtdiachi.Text = phieuthu.diachinguoinop;
                    txtdiengiai.Text = phieuthu.lydothu;
                    txtsotien.Text = double.Parse(phieuthu.sotien.ToString()).ToString("#,#", CultureInfo.InvariantCulture);
                    //txtValueSotienNo.Text = phieuthu.sotien.ToString();
                    this.pssotienno = double.Parse(phieuthu.sotien.ToString());


                    txtsochungtugoc.Text = phieuthu.sochungtugoc.ToString();

                    txttaikhoanco.Text = phieuthu.taikhoandoiung;
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
                        lb_machitietno.Text = "";

                    }





                    tbchontkno.Text = phieuthu.tkno.Trim();




                    ngaychungtu.Enabled = false;
                    txtsophieu.Enabled = false;
                    txttennguoi.Enabled = false;
                    txtdiachi.Enabled = false;
                    txtdiengiai.Enabled = false;
                    txtsotien.Enabled = false;
                    txtsochungtugoc.Enabled = false;

                    btsua.Enabled = true;



                    tbchontkno.Enabled = false;



                    this.statusphieuthu = 3;// View
                    //         Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);
                    //       Model.Phieuthuchi.reloaddetailtaikhoancophieuthu(this.dataGridViewTkCo, this, phieuthu.tkno.Trim(), phieuthu.sophieuthu);
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
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var phieuthu = (from tbl_SoQuy in dc.tbl_SoQuys
                            where tbl_SoQuy.id == this.phieuthuid
                            select tbl_SoQuy).FirstOrDefault();

            if (phieuthu != null)
            {
                this.sophieuthu = phieuthu.Sophieu;

                dc.tbl_SoQuys.DeleteOnSubmit(phieuthu);
                dc.SubmitChanges();


                Model.hachtoantonghop.xoa("PT", phieuthu.Sophieu);

                MessageBox.Show("Đã xóa phiếu thu: " + this.sophieuthu, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  Model.
                #region load list phieu thu
                var Listphieuthu = from listpt in dc.tbl_SoQuys
                                   where listpt.Machungtu == "PT" // mã 8 là tiền mặt
                                   select new
                                   {

                                       Ngày_chứng_từ = listpt.Ngayctu,
                                       Số_chứng_từ = "PT-" + listpt.Sophieu,
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

            this.statusphieuthu = 2;

            btluu.Visible = true;


            ngaychungtu.Enabled = true;


            txtsophieu.Enabled = true;
            if (txtsophieu.Text != "")
            {
                this.sophieuthu = txtsophieu.Text.ToString().Trim();
                this.sophieuthuOld = txtsophieu.Text.ToString().Trim();
            }




            txttennguoi.Enabled = true;
            txtdiachi.Enabled = true;
            txtdiengiai.Enabled = true;
            txtsotien.Enabled = true;
            txtsochungtugoc.Enabled = true;
            btluu.Enabled = true;

            //   cbtaikhoanco.Enabled = true;
            tbchontkno.Enabled = true;

            this.statusphieuthu = 2;

        }

        private void txtsophieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                txttennguoi.Focus();

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
                tbchontkno.Focus();



            }
        }


        private void txtsotien_TextChanged(object sender, EventArgs e)
        {

            if (Utils.IsValidnumber(txtsotien.Text.ToString()))
            {
                this.pssotienno = double.Parse(txtsotien.Text);
                // txtsotien.Text = pssotienno.pssotienno
            }
            else
            {
                txtsotien.Text = "";
            }



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

            if (colname == "Tk_Có")
            {


                //  string SelectedItem = view.Rows[i].Cells["Tk_Có"].Value.ToString();


                #region  view lai cac tk có

                String tkcotext = "";


                int dem = 0;
                for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
                {

                    if (dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value != null)
                    {



                        dem = dem + 1;
                        if (dem > 1)
                        {

                            tkcotext += ";" + dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim(); // chính la program

                        }
                        else
                        {
                            tkcotext += dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim(); // chính la program
                            //dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;


                        }


                    }


                }

                txttaikhoanco.Text = tkcotext;
                #endregion

            }


            //   if (colname == "Số_tiền")
            //   {


            //  string SelectedItem = view.Rows[i].Cells["Tk_Có"].Value.ToString();


            #region  view lai cac tk có


            double tongcong = 0;


            for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            {


                if (dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"] != null)
                {
                    if (Utils.IsValidnumber(dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value.ToString()))
                    {

                        tongcong += double.Parse(dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value.ToString());
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

            //DataGridView view = (DataGridView)sender;
            //if (view.CurrentRow != null)
            //{


            //    int i = view.CurrentRow.Index;
            //    string colname = view.Columns[view.CurrentCell.ColumnIndex].Name;
            //    string SelectedItem = view.Rows[i].Cells["Tk_Có"].Value.ToString();

            //    #region if la slect tai khoan co chi tiet

            //    if (colname == "Tk_Có" && SelectedItem != "" && currentCell != null)
            //    {
            //        string taikhoan = currentCell.Value.ToString();
            //        string connection_string = Utils.getConnectionstr();
            //        LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            //        var detail = (from c in db.tbl_dstaikhoans
            //                      where c.matk.Trim() == taikhoan.Trim()
            //                      select c).FirstOrDefault();

            //        if (detail.loaichitiet == true) // là co theo doi chi tiết
            //        {

            //            List<beeselectinput.ComboboxItem> listcb = new List<beeselectinput.ComboboxItem>();
            //            var rs = from tbl_machitiettk in db.tbl_machitiettks
            //                     where tbl_machitiettk.matk.Trim() == taikhoan.Trim()
            //                     orderby tbl_machitiettk.machitiet
            //                     select tbl_machitiettk;
            //            if (rs.Count() > 0)
            //            {


            //                foreach (var item2 in rs)
            //                {
            //                    beeselectinput.ComboboxItem cb = new beeselectinput.ComboboxItem();
            //                    cb.Value = item2.machitiet.ToString().Trim();
            //                    cb.Text = item2.tenchitiet; //item2.machitiet.ToString().Trim() + ": " +
            //                    listcb.Add(cb);
            //                }



            //                FormCollection fc = System.Windows.Forms.Application.OpenForms;

            //                bool kq = false;
            //                foreach (Form frm in fc)
            //                {
            //                    if (frm.Text == "beeselectinput")
            //                    {
            //                        kq = true;
            //                        frm.Close();

            //                    }
            //                }

            //                if (kq == false)
            //                {
            //                    //        beeselectinput

            //                    View.beeselectinput selecdetail = new beeselectinput("Chọn chi tiết tài khoản ", listcb);

            //                    selecdetail.ShowDialog();


            //                    bool chon = selecdetail.kq;
            //                    if (chon)
            //                    {
            //                        string machitiet = selecdetail.value;
            //                        string namechitiet = selecdetail.valuetext;

            //                        dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = machitiet;
            //                        dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = namechitiet;


            //                    }
            //                    else
            //                    {
            //                        dataGridViewTkCo.Rows[i].Cells["Tk_Có"].Value = "";
            //                        dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //                        dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";
            //                    }




            //                }
            //                else
            //                {
            //                    dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //                    dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";


            //                }


            //            }
            //        }


            //        else
            //        {
            //            dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
            //            dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";


            //        }

            //    }

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

        private void dataGridViewTkCo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            #region  view lai cac tk co


            double tongcong = 0;


            for (int idrow = 0; idrow <= dataGridViewTkCo.RowCount - 1; idrow++)
            {


                if (dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"] != null)
                {
                    if (Utils.IsValidnumber(dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value.ToString()))
                    {

                        tongcong += double.Parse(dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value.ToString());



                    }
                }



            }

            //txtValueSotienCo.Text = tongcong.ToString();
            this.pssotienco = tongcong;
            txtsotienco.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);
            #endregion


            #region  view lai cac tk có

            String tkcotext = "";


            int dem = 0;
            for (int idrow = 0; idrow <= dataGridViewTkCo.RowCount - 1; idrow++)
            {

                if (dataGridViewTkCo.Rows[idrow].Cells["Có_TK"].Value != null)
                {



                    dem = dem + 1;
                    if (dem > 1)
                    {

                        tkcotext += ";" + dataGridViewTkCo.Rows[idrow].Cells["Có_TK"].Value.ToString().Trim(); // chính la program

                    }
                    else
                    {
                        tkcotext += dataGridViewTkCo.Rows[idrow].Cells["Có_TK"].Value.ToString().Trim(); // chính la program
                        //dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;


                    }


                }


            }

            txttaikhoanco.Text = tkcotext;
            #endregion

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

            #region  view lai cac tk co


            double tongcong = 0;


            for (int idrow = 0; idrow <= dataGridViewTkCo.RowCount - 1; idrow++)
            {


                if (dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"] != null)
                {
                    if (Utils.IsValidnumber(dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value.ToString()))
                    {

                        tongcong += double.Parse(dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value.ToString());



                    }
                }



            }

            //txtValueSotienCo.Text = tongcong.ToString();
            this.pssotienco = tongcong;
            txtsotienco.Text = tongcong.ToString("#,#", CultureInfo.InvariantCulture);
            #endregion


            #region  view lai cac tk có

            String tkcotext = "";


            int dem = 0;
            for (int idrow = 0; idrow <= dataGridViewTkCo.RowCount - 1; idrow++)
            {

                if (dataGridViewTkCo.Rows[idrow].Cells["Có_TK"].Value != null)
                {



                    dem = dem + 1;
                    if (dem > 1)
                    {

                        tkcotext += ";" + dataGridViewTkCo.Rows[idrow].Cells["Có_TK"].Value.ToString().Trim(); // chính la program

                    }
                    else
                    {
                        tkcotext += dataGridViewTkCo.Rows[idrow].Cells["Có_TK"].Value.ToString().Trim(); // chính la program
                        //dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;


                    }


                }


            }

            txttaikhoanco.Text = tkcotext;
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

        private void dataGridViewListphieuthu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


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


                #region view load form
                var phieuthu = (from tbl_SoQuy in dc.tbl_SoQuys
                                where tbl_SoQuy.id == this.phieuthuid
                                //       && tbl_SoQuy.macty == macty
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


                                    machitietco = tbl_SoQuy.ChitietTM,
                                    tentkchitiet = tbl_SoQuy.TenchitietTM,
                                    tkno = tbl_SoQuy.TKtienmat,

                                    taikhoandoiung = tbl_SoQuy.TKdoiung,

                                }).FirstOrDefault();


                if (phieuthu != null)
                {
                    ngaychungtu.Value = phieuthu.ngaychungtu;
                    txtsophieu.Text = phieuthu.sophieuthu;

                    this.sophieuthuOld = phieuthu.sophieuthu;
                    this.sophieuthu = phieuthu.sophieuthu;

                    txttennguoi.Text = phieuthu.nguoinoptien;
                    txtdiachi.Text = phieuthu.diachinguoinop;
                    txtdiengiai.Text = phieuthu.lydothu;
                    txtsotien.Text = phieuthu.sotien.ToString();// double.Parse(phieuthu.sotien.ToString()).ToString("#,#", CultureInfo.InvariantCulture);

                    //   txtsotien.Text = phieuthu.sotien.ToString();

                    //txtValueSotienNo.Text = phieuthu.sotien.ToString();
                    this.pssotienco = double.Parse(phieuthu.sotien.ToString());


                    txtsochungtugoc.Text = phieuthu.sochungtugoc.ToString();

                    txttaikhoanco.Text = phieuthu.taikhoandoiung;
                    if (phieuthu.machitietco != null)
                    {
                        lb_machitietno.Text = phieuthu.machitietco.ToString();
                    }
                    else
                    {
                        lbtenchitietno.Text = "";
                        lb_machitietno.Text = "";
                    }

                    if (phieuthu.tentkchitiet != null)
                    {
                        lbtenchitietno.Text = phieuthu.tentkchitiet.ToString();
                    }
                    else
                    {
                        lbtenchitietno.Text = "";
                        lb_machitietno.Text = "";
                    }
                    if (phieuthu.tkno != null)
                    {
                        this.tkno = phieuthu.tkno.Trim();
                        //   txttaikhoanco.Text = phieuthu.tkno.Trim();
                    }

                    ngaychungtu.Enabled = false;
                    txtsophieu.Enabled = false;
                    txttennguoi.Enabled = false;
                    txtdiachi.Enabled = false;
                    txtdiengiai.Enabled = false;
                    txtsotien.Enabled = false;
                    txtsochungtugoc.Enabled = false;

                    btsua.Enabled = true;




                    tbchontkno.Enabled = false;


                    this.statusphieuthu = 3;// View


                    Model.Phieuthuchi.reloadnewdetailphieuthu(dataGridViewTkCo);

                    if (phieuthu.tkno != null)
                    {
                        Model.Phieuthuchi.reloaddetailtaikhoancophieuthu(this.dataGridViewTkCo, this, phieuthu.tkno.Trim(), phieuthu.sophieuthu);

                    }

                    btluu.Visible = false;

                }



                #endregion view load form


            }



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
            dataGridViewListphieuthu.DataSource = Model.Phieuthuchi.LisDanhSachphieuthu("PT", cbthang.Text, cbnam.Text);

        }

        private void cbnam_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridViewListphieuthu.DataSource = Model.Phieuthuchi.LisDanhSachphieuthu("PT", cbthang.Text, cbnam.Text);

        }

        private void tbchontkco_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == (char)Keys.Enter)
            {
                //  string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
                string seaching = tbchontkno.Text.Trim();

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                var danhsachtaikhoan = from c in db.tbl_dstaikhoans
                                       where c.matk.Contains(seaching)
                                       && c.loaitkid == "tienmat" // mã 8 là tiền mặt
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
                        //    lb_matktm.Text = taikhoanchon.matk;

                        lbtkno.Text = taikhoanchon.matk + ": " + taikhoanchon.tentk.Trim();


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
                                        //     lbmachitietco.Visible = true;

                                        // lbtenchitietno.Visible = true;
                                        // lb_machitietno.Visible = true;
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
                        else
                        {
                            this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                            //     lbmachitietco.Text = machitiet;
                            lbtenchitietno.Text = "";//namechitiet;
                            lb_machitietno.Text = "";
                        }



                        #endregion

                        txtsotien.Focus();
                    }
                    else
                    {
                        this.tkno = "";
                        //     lb_matktm.Text = "";
                        lbtkno.Text = "";
                        lb_machitietno.Text = "";

                        this.tkcochitiet = -1;
                        tbchontkno.Focus();
                    }


                    //string taikhoan = (from c in db.tbl_dstaikhoans
                    //                   where c.id == idtaikhoan
                    //                   select c.matk).FirstOrDefault().ToString();

                } // nếu danh sách tài khoản có


                //      xx


            }// end chon tai khoan no






        }
    }
}

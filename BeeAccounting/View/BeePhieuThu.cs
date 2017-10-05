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
    public partial class BeePhieuThu : Form
    {
        public int statusphieuthu { get; set; } // mới  // 2 suawra // 3 display //
        public int phieuthuid { get; set; }
        public int sophieuthu { get; set; }
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


        public void add_detailGridviewTkCophieuthu(tbl_Socai socaitemp)
        {





            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //---------------

            DataTable dataTable = (DataTable)dataGridViewTkCo.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            //    drToAdd["Tk_Có"] = socaitemp.TkCo;
            drToAdd["Diễn_giải"] = socaitemp.Diengiai;
            drToAdd["Số_chứng_từ"] = socaitemp.Soctu;
            drToAdd["Ký_hiêu"] = socaitemp.Kyhieuctu;

            if (socaitemp.PsCo != null)
            {
                drToAdd["Số_tiền"] = socaitemp.PsCo;
            }
          
            drToAdd["Mã_chi_tiết"] = socaitemp.MaCTietTKCo;
            drToAdd["Tên_chi_tiết"] = socaitemp.tenchitietCo;

            drToAdd["tkCohide"] = socaitemp.TkCo;


            drToAdd["ngayctuhide"] = socaitemp.Ngayctu;

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();



            int i = dataTable.Rows.Count - 1;
            //   int i = dataGridViewTkCo.RowCount -1;
            
            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridViewTkCo.Rows[i].Cells["Tk_Có"];
            DataGridViewCell dgvc = (DataGridViewCell)dataGridViewTkCo.Rows[i].Cells["Tk_Có"];

            #region tim item comboboc

            foreach (ComboboxItem item in (List<ComboboxItem>)cb.DataSource)
            {

                if (item.Value.ToString().Trim() == socaitemp.TkCo.ToString().Trim())
                    {

                        dataGridViewTkCo.Rows[i].Cells["Tk_Có"].Value = item.Value;
                    }
               

            }


            #endregion tom item comboubox


            //   ComboboxItem cbx = (ComboboxItem)cb.Items[3];
            //     dataGridViewTkCo.Rows[i].Cells["Tk_Có"].Value = cbx.Value;
            if (Utils.IsValidnumber(txtsotienco.Text))
            {
                this.pssotienco = double.Parse(txtsotienco.Text);

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
                    View.BeeHtoansocaidoiungphieuthu BeeHtoansocaidoiung = new BeeHtoansocaidoiungphieuthu(this, "Địa chỉ", "", "");
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
            this.datepickngayphieu.Value = DateTime.Today.Date;

            this.lbtenchitietno.Text = "";
            lb_machitietno.Text = "";


            #region load tk nợ


            var rs2 = from tk in dc.tbl_dstaikhoans
                      where tk.loaitkid == "tien" // mã 8 là tiền mặt
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



            dataGridViewTkCo = Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);

            dataGridViewListphieuthu.DataSource = Model.Phieuthuchi.LisDanhSachphieuthu("PT");

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


            #region check phieu thu

            if (this.pssotienco - this.pssotienno != 0)
            {
                MessageBox.Show("Phát sinh nợ và có phải bảng nhau, bạn hãy kiểm tra lại", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].
                return;
            }


            #endregion


            bool checkdinhkhoanco = true;
            #region  check từng dong sổ tk có
            for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            {
                if (dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value != DBNull.Value)
                {


                    if (dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].Value == DBNull.Value)
                    {

                        MessageBox.Show("Bạn chua nhập ký hiệu chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkdinhkhoanco = false;
                        return;
                    }


                    if (cbtkno.SelectedItem == null)
                    {

                        MessageBox.Show("Bạn chua định khoản tài khoản tiền mặt", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkdinhkhoanco = false;
                        return;
                    }


                    if (dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value == DBNull.Value)
                    {

                        MessageBox.Show("Bạn chua nhập số tiền", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkdinhkhoanco = false;
                        return;
                    }


                    if (dataGridViewTkCo.Rows[idrow].Cells["Số_chứng_từ"].Value == DBNull.Value)
                    {

                        MessageBox.Show("Bạn chua nhập ngày chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkdinhkhoanco = false;
                        return;
                    }

                    if (dataGridViewTkCo.Rows[idrow].Cells["Ngày_chứng_từ"].Value == null)
                    {

                        MessageBox.Show("Bạn chua nhập ngày chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkdinhkhoanco = false;
                        return;
                    }





                }





            }


            #endregion


            if (checkdinhkhoanco == true)
            {

                #region add new phieu thu


                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                tbl_SoQuy soquy = new tbl_SoQuy();


                soquy.quyenso = txtquyenso.Text.ToString();



                soquy.PsCo = 0;

                if (Utils.IsValidnumber(txtsotien.Text.Replace(",", "")))
                {
                    soquy.PsNo = double.Parse(txtsotien.Text.Replace(",", "").Trim());
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
                    soquy.TenchitietTM = lbtenchitietno.Text;
                }



                soquy.Chitietdoiung = this.tkcochitiet;


                if (Utils.IsValidnumber(txtsophieu.Text)) //số phiếu thu phaair  lớn hơn 0 và không lặp
                {

                    if (int.Parse(txtsophieu.Text.Trim()) > 0)
                    {

                        // không lặp
                        if (this.statusphieuthu == 1 || (this.statusphieuthu == 2) && this.sophieuthu != int.Parse(txtsophieu.Text.Trim()))
                        {
                            var sophieuthu = (from tbl_SoQuy in dc.tbl_SoQuys
                                              where (tbl_SoQuy.Sochungtu == int.Parse(txtsophieu.Text.ToString())
                                                && (tbl_SoQuy.quyenso.Trim() == txtquyenso.Text.ToString().Trim()))
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
                    MessageBox.Show("Bạn chưa nhập địa chỉ ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


                    #region  ghi vao so cai


                    string tkcotext = "";
                    // int dem = 0;
                    for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
                    {

                        if (dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value != DBNull.Value && checkdinhkhoanco == true)
                        {

                            tbl_Socai socai = new tbl_Socai();

                            //  //  string username, string tkno, string tkco, float psno, float psco, string diengiai, string manghiepvu, int sochunngtu, DateTime ngaychungtu, DateTime ngayghiso


                            socai.TkCo = dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim();

                            if (dataGridViewTkCo.Rows[idrow].Cells["Mã_chi_tiết"].Value != DBNull.Value)
                            {

                                socai.MaCTietTKCo = int.Parse(dataGridViewTkCo.Rows[idrow].Cells["Mã_chi_tiết"].Value.ToString());

                            }
                            else
                            {
                                socai.MaCTietTKCo = 0;
                            }



                            if (dataGridViewTkCo.Rows[idrow].Cells["Tên_chi_tiết"].Value != DBNull.Value)
                            {

                                socai.tenchitietCo = dataGridViewTkCo.Rows[idrow].Cells["Tên_chi_tiết"].Value.ToString();

                            }



                            if (dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].Value != DBNull.Value)
                            {
                                socai.Kyhieuctu = dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].Value.ToString();

                            }
                            else
                            {
                                MessageBox.Show("Bạn chua nhập ký hiệu chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].
                                return;
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




                            if (lb_machitietno.Text != "")
                            {
                                socai.MaCTietTKNo = int.Parse(lb_machitietno.Text.ToString());
                              
                            }

                            if (lbtenchitietno.Text != "")
                            {
                                socai.tenchitietNo = lbtenchitietno.Text.ToString().Trim();

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

                            if (dataGridViewTkCo.Rows[idrow].Cells["Số_chứng_từ"].Value != DBNull.Value)
                            {
                                socai.Soctu = int.Parse(dataGridViewTkCo.Rows[idrow].Cells["Số_chứng_từ"].Value.ToString());
                            }
                            else
                            {
                                MessageBox.Show("Bạn chua nhập ngày chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dataGridViewTkCo.Focus();
                                return;
                            }

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



                        }





                    }

                    txttaikhoanco.Text = tkcotext;


                    #endregion



                }

                if (this.statusphieuthu == 2)
                {


                    Model.Socaitaikhoan.xoa("PT", maphieuthuOld);



                    var phieuchange = (from tbl_SoQuy in dc.tbl_SoQuys
                                       where tbl_SoQuy.id == this.phieuthuid
                                       select tbl_SoQuy).FirstOrDefault();

                    if (phieuchange != null)
                    {
                        phieuchange.Machungtu = soquy.Machungtu;
                        phieuchange.Chitietdoiung = soquy.Chitietdoiung;
                        phieuchange.TenchitietTM = soquy.TenchitietTM;
                        phieuchange.ChitietTM = soquy.ChitietTM;
                        phieuchange.Chungtugockemtheo = soquy.Chungtugockemtheo;
                        phieuchange.Diachinguoinhannop = soquy.Diachinguoinhannop;
                        phieuchange.Diengiai = soquy.Diengiai;
                        phieuchange.Machungtu = soquy.Machungtu;


                        phieuchange.Nguoinopnhantien = soquy.Nguoinopnhantien;
                        phieuchange.PsNo = soquy.PsNo;


                        phieuchange.TKdoiung = soquy.TKdoiung;
                        phieuchange.TKtienmat = soquy.TKtienmat;
                        phieuchange.Username = soquy.Username;
                        phieuchange.quyenso = soquy.quyenso;

                        phieuchange.Sochungtu = soquy.Sochungtu;
                        phieuchange.Ngayctu = soquy.Ngayctu;
                        phieuchange.Ngayghiso = soquy.Ngayghiso;




                        dc.SubmitChanges();
                    }


                    #region  ghi vao so cai


                    string tkcotext = "";
                    // int dem = 0;
                    for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
                    {

                        if (dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value != DBNull.Value && checkdinhkhoanco == true)
                        {

                            tbl_Socai socai = new tbl_Socai();

                            //  //  string username, string tkno, string tkco, float psno, float psco, string diengiai, string manghiepvu, int sochunngtu, DateTime ngaychungtu, DateTime ngayghiso


                            socai.TkCo = dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value.ToString().Trim();

                            if (dataGridViewTkCo.Rows[idrow].Cells["Mã_chi_tiết"].Value != DBNull.Value )///zcxzv
                            {


                                if (Utils.IsValidnumber((string)dataGridViewTkCo.Rows[idrow].Cells["Mã_chi_tiết"].Value ))
                                {
                                    socai.MaCTietTKCo = int.Parse(dataGridViewTkCo.Rows[idrow].Cells["Mã_chi_tiết"].Value.ToString());
                                }
                                else
                                {
                                    socai.MaCTietTKCo = null;
                                }
                             

                            }
                            if (dataGridViewTkCo.Rows[idrow].Cells["Tên_chi_tiết"].Value != DBNull.Value)
                            {

                                socai.tenchitietCo = dataGridViewTkCo.Rows[idrow].Cells["Tên_chi_tiết"].Value.ToString();

                            }



                            if (dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].Value != DBNull.Value)
                            {
                                socai.Kyhieuctu = dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].Value.ToString();

                            }
                            else
                            {
                                MessageBox.Show("Bạn chua nhập ký hiệu chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //dataGridViewTkCo.Rows[idrow].Cells["Ký_hiêu"].
                                return;
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

                            if (dataGridViewTkCo.Rows[idrow].Cells["Số_chứng_từ"].Value != DBNull.Value)
                            {
                                socai.Soctu = int.Parse(dataGridViewTkCo.Rows[idrow].Cells["Số_chứng_từ"].Value.ToString());
                            }
                            else
                            {
                                MessageBox.Show("Bạn chua nhập ngày chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dataGridViewTkCo.Focus();
                                return;
                            }

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



                        }





                    }

                    txttaikhoanco.Text = tkcotext;


                    #endregion


                }


                #endregion add new phieu thu




                MessageBox.Show("Số phiếu vừa lưu: " + this.sophieuthu, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }








            #region  list black phiếu
            btsua.Enabled = false;

            txtsophieu.Text = "";
            txttennguoinop.Text = "";
            txtdiachi.Text = "";
            txtdiengiai.Text = "";
            txtsotien.Text = "";
            txtsochungtugoc.Text = "";

            lbtenchitietno.Text = "";
            lb_machitietno.Text = "";
            cbtkno.SelectedIndex = -1;
            txtquyenso.Text = "";

            datepickngayphieu.Focus();


            #endregion
            dataGridViewTkCo = Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);

            dataGridViewListphieuthu.DataSource = Model.Phieuthuchi.LisDanhSachphieuthu("PT");

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
            #region  list black phiếu
            datepickngayphieu.Enabled = true;
            txtquyenso.Enabled = true;
            txtsophieu.Enabled = true;
            txttennguoinop.Enabled = true;
            txtdiachi.Enabled = true;
            txtdiengiai.Enabled = true;
            txtsotien.Enabled = true;
            txtsochungtugoc.Enabled = true;
            btluu.Visible = true;
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

            dataGridViewTkCo = Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);

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

                Rpt_PhieuThu pt = new Rpt_PhieuThu();
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

                    }


                    foreach (ComboboxItem item in (List<ComboboxItem>)cbtkno.DataSource)
                    {
                        if (item.Value.ToString().Trim() == phieuthu.tkno.Trim())
                        {
                            cbtkno.SelectedItem = item;
                        }
                    }





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
                    Model.Phieuthuchi.reloadnewdetailtaikhoanco(dataGridViewTkCo);
                    Model.Phieuthuchi.reloaddetailtaikhoancophieuthu(this.dataGridViewTkCo, this, phieuthu.tkno.Trim(), phieuthu.sophieuthu);
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
                this.sophieuthu = phieuthu.Sochungtu;

                dc.tbl_SoQuys.DeleteOnSubmit(phieuthu);
                dc.SubmitChanges();


                Model.Socaitaikhoan.xoa("PT", phieuthu.Sochungtu);

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

            this.statusphieuthu = 2;

            btluu.Visible = true;


            datepickngayphieu.Enabled = true;


            txtsophieu.Enabled = true;
            if (txtsophieu.Text != "")
            {
                this.sophieuthu = int.Parse(txtsophieu.Text.ToString());
                this.maphieuthuOld = int.Parse(txtsophieu.Text.ToString());
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

            DataGridView view = (DataGridView)sender;
            int i = view.CurrentRow.Index;
            string colname = view.Columns[view.CurrentCell.ColumnIndex].Name;
            string SelectedItem = view.Rows[i].Cells["Tk_Có"].Value.ToString();

            #region if la slect tai khoan co chi tiet

            if (colname == "Tk_Có" && SelectedItem != "")
            {
                string taikhoan = currentCell.Value.ToString();
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
                                frm.Close();

                            }
                        }

                        if (kq == false)
                        {
                            //        beeselectinput

                            View.beeselectinput selecdetail = new beeselectinput("Chọn chi tiết tài khoản ", listcb);

                            selecdetail.ShowDialog();


                            bool chon = selecdetail.kq;
                            if (chon)
                            {
                                string machitiet = selecdetail.value;
                                string namechitiet = selecdetail.valuetext;

                                dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = machitiet;
                                dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = namechitiet;


                            }
                            else
                            {
                                dataGridViewTkCo.Rows[i].Cells["Tk_Có"].Value = "";
                                dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
                                dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";
                            }




                        }
                        else
                        {
                            dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
                            dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";


                        }


                    }
                }


                else
                {
                    dataGridViewTkCo.Rows[i].Cells["Mã_chi_tiết"].Value = "";
                    dataGridViewTkCo.Rows[i].Cells["Tên_chi_tiết"].Value = "";


                }

            }

            #endregion





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

            #region  view lai cac tk có

            String tkcotext = "";


            int dem = 0;
            for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            {

                if (dataGridViewTkCo.Rows[idrow].Cells["Tk_Có"].Value != DBNull.Value)
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


            #region  view lai cac tk có


            double tongcong = 0;


            for (int idrow = 0; idrow < dataGridViewTkCo.RowCount - 1; idrow++)
            {


                if (dataGridViewTkCo.Rows[idrow].Cells["Số_tiền"].Value != DBNull.Value)

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
    }
}

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

        public void reloadseachview(string labe1, string labe2, string labe3)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            var Listphieuthu = from listpt in dc.tbl_SoQuys
                               where listpt.Machungtu == "PT"    // mã 8 là tiền mặt
                                                                 //     ((int)tbl_KaCustomer.Customer).ToString().Contains(valueinput)
                      && listpt.Nguoinopnhantien.Contains(labe1)
                      && listpt.Diachinguoinhannop.Contains(labe2)
                      && listpt.Diengiai.Contains(labe3)
                               select new
                               {

                                   Ngày_chứng_từ = listpt.Ngayctu,
                                   Số_chứng_từ = "PT-" + listpt.Sochungtu,
                                   TK_Nợ = listpt.TKtienmat,
                                   TK_Có = listpt.TKdoiung,
                                   Số_Tiền = listpt.PsNo,
                                   Diễn_Giải = listpt.Diengiai,
                                   Người_nộp_tiền = listpt.Nguoinopnhantien,
                                   Địa_chỉ_người_nộp_tiền = listpt.Diachinguoinhannop,
                                   User_name = listpt.Username,
                                   Ngày_nhập_liệu = listpt.Ngayghiso,
                                   ID = listpt.id

                               };



            dataGridViewListphieuthu.DataSource = Listphieuthu;


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
                    View.BeeHtoansocaidoiungphieuthu BeeHtoansocaidoiung = new BeeHtoansocaidoiungphieuthu(this, "Địa chỉ", "","");
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


            //#region load tk nợ


            //var rs1 = from tk in dc.tbl_dstaikhoans
            //          where tk.loaitkid == 5 || tk.loaitkid == 9 || tk.loaitkid == 7  // 5.nguon von;  7 phai tra; 9. tam ung
            //          select tk;

            ////      string drowdownshow = "";

            //foreach (var item in rs1)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.matk;
            //    cb.Text = item.matk + ":" + item.tentk;
            //    this.cbtaikhoanco.Items.Add(cb); // CombomCollection.Add(cb);

            //}

            //#endregion load tk nợ


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
                                   Người_nộp_tiền = listpt.Nguoinopnhantien,
                                   Địa_chỉ_người_nộp_tiền = listpt.Diachinguoinhannop,
                                   User_name = listpt.Username,
                                   Ngày_nhập_liệu = listpt.Ngayghiso,
                                   ID = listpt.id

                               };

            dataGridViewListphieuthu.DataSource = Listphieuthu;
            #endregion

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


            MessageBox.Show("Số phiếu vừa lưu: " + this.sophieuthu, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



                    View.beeselectinput selecdetail = new beeselectinput("Chọn chi tiết tài khoản ", listcb);

                    selecdetail.ShowDialog();
                    bool chon = selecdetail.kq;
                    if (chon)
                    {
                        string machitiet = selecdetail.value;
                        string namechitiet = selecdetail.valuetext;
                        //     lbmachitietco.Visible = true;

                        lbtenchitietno.Visible = true;
                        this.tknochitiet = int.Parse(selecdetail.value.ToString());
                        //     lbmachitietco.Text = machitiet;
                        lbtenchitietno.Text = namechitiet;
                    }

                }
                else
                {
                   this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                          //     lbmachitietco.Text = machitiet;
                    lbtenchitietno.Text = "";//namechitiet;
                }
                //  selecdetail.Text;

            }
            else
            {
             this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                      //     lbmachitietco.Text = machitiet;
                lbtenchitietno.Text = "";//namechitiet;
            }







        }

     
        private void cbtaikhoanco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            #region  list black phiếu
            datepickngayphieu.Enabled = true;
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

            lbtenchitietno.Text = "";
      
            cbtkno.SelectedIndex = -1;
    

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

                    datepickngayphieu.Enabled = false;
                    txtsophieu.Enabled = false;
                    txttennguoinop.Enabled = false;
                    txtdiachi.Enabled = false;
                    txtdiengiai.Enabled = false;
                    txtsotien.Enabled = false;
                    txtsochungtugoc.Enabled = false;

                    btsua.Enabled = true;




               
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
                datepickngayphieu.Focus();

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
    }
}

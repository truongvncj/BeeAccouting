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
        public int sophieuthu { get; set; }
        public string tkno { get; set; }
        public int tknochitiet { get; set; }
        public string tkco { get; set; }
        public int tkcochitiet { get; set; }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }


        public View.Main main1;
        public BeePhieuThu(View.Main Main)
        {
            InitializeComponent();
            this.main1 = Main;



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
            this.lbtenchitietco.Visible = false;
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


            #region load tk nợ


            var rs1 = from tk in dc.tbl_dstaikhoans
                      where tk.loaitkid == 5 || tk.loaitkid == 9 || tk.loaitkid == 7  // 5.nguon von;  7 phai tra; 9. tam ung
                      select tk;

            //      string drowdownshow = "";

            foreach (var item in rs1)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk;
                cb.Text = item.matk + ":" + item.tentk;
                this.cbtaikhoanco.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk nợ


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
                cbtennguoinop.Focus();

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
                cbsophieu.Focus();

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
                cbdiachi.Focus();

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
                cbdiengiai.Focus();


            }
        }

        private void cbdiengiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                cbsotien.Focus();



            }
        }

        private void cbsotien_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                cbsochungtugoc.Focus();

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


            if (Utils.IsValidnumber(cbsotien.Text))
            {
                soquy.PsNo = double.Parse(cbsotien.Text.Trim());
            }
            else
            {
                MessageBox.Show("Số tiền gõ vào phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbsotien.Focus();
                return;
            }

            if (Utils.IsValidnumber(cbsophieu.Text))
            {
                soquy.Sochungtu = int.Parse(cbsophieu.Text.Trim());
                this.sophieuthu = int.Parse(cbsophieu.Text.Trim());
            }
            else
            {
                MessageBox.Show("Số phiếu gõ vào phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbsophieu.Focus();
                return;
            }


            soquy.Ngayctu = datepickngayphieu.Value;
            if (Utils.IsValidnumber(cbsochungtugoc.Text))
            {
                soquy.Chungtugockemtheo = int.Parse(cbsochungtugoc.Text.Trim());
            }
            else
            {
                MessageBox.Show("Số chứng từ gốc kèm theo phải là số", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbsochungtugoc.Focus();
                return;
            }

            if (cbdiengiai.Text.Trim() != "")
            {


                if (cbdiengiai.Text.Length > 225)
                {
                    soquy.Diengiai = cbdiengiai.Text.Trim().Substring(225);
                }
                else
                {
                    soquy.Diengiai = cbdiengiai.Text.Trim();
                }

            }
            else
            {
                MessageBox.Show("Phải nhập diễn giải nội dung nộp tiền ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbdiengiai.Focus();
                return;
            }


            if (cbtennguoinop.Text.Trim() != "")
            {


                if (cbtennguoinop.Text.Length > 100)
                {
                    soquy.Nguoinopnhantien = cbtennguoinop.Text.Trim().Substring(100);
                }
                else
                {
                    soquy.Nguoinopnhantien = cbtennguoinop.Text.Trim();
                }

            }
            else
            {
                MessageBox.Show("Phải nhập tên người nộp tiền ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbtennguoinop.Focus();
                return;
            }

            if (cbdiachi.Text.Trim() != "")
            {


                if (cbdiachi.Text.Length > 225)
                {
                    soquy.Diachinguoinhannop = cbdiachi.Text.Trim().Substring(225);
                }
                else
                {
                    soquy.Diachinguoinhannop = cbdiachi.Text.Trim();
                }

            }
            else
            {
                MessageBox.Show("Phải nhập tên người nộp tiền ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbdiachi.Focus();
                return;
            }
            soquy.Ngayghiso = DateTime.Today;
            soquy.Username = Utils.getusername();
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

            if (cbtaikhoanco.SelectedItem != null)
            {
                soquy.TKdoiung = (cbtaikhoanco.SelectedItem as ComboboxItem).Value.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài khoản đối ứng", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbtaikhoanco.Focus();
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

            soquy.Machungtu = "PT";

            dc.tbl_SoQuys.InsertOnSubmit(soquy);
            dc.SubmitChanges();

            //        newcontract.Customer = double.Parse(cb_customerka.Text.Trim());// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            //        newcontract.CustomerType = "SAP";

            //if (this.cb_channel.SelectedItem != null)
            //{
            //    //  newcontract.Channel = this.cb_channel.SelectedItem.ToString();

            //    newcontract.Channel = (cb_channel.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            //}


            #endregion add new phieu thu

            #region  list black phiếu

            cbsophieu.Text = "";
            cbtennguoinop.Text = "";
            cbdiachi.Text = "";
            cbdiengiai.Text = "";
            cbsotien.Text = "";
            cbsochungtugoc.Text = "";

            lbtenchitietno.Text = "";
            lbtenchitietco.Text = "";
            cbtkno.SelectedIndex = -1;
            cbtaikhoanco.SelectedIndex = -1;

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


            MessageBox.Show("Số phiếu vừa tạo: " + this.sophieuthu, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cbtaikhoanco_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string taikhoan = (cbtaikhoanco.SelectedItem as ComboboxItem).Value.ToString();
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
                         where tbl_machitiettk.matk == taikhoan
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

                        lbtenchitietco.Visible = true;
                        this.tkcochitiet = int.Parse(selecdetail.value.ToString());
                        //     lbmachitietco.Text = machitiet;
                        lbtenchitietco.Text = namechitiet;
                    }
                    //else
                    //{
                    //    //  string machitiet = "";// selecdetail.value;
                    //    //   string namechitiet = "";//selecdetail.valuetext;
                    //    //     lbmachitietco.Visible = true;

                    //    lbtenchitietco.Visible = true;
                    //    this.tkcochitiet = -1;// int.Parse(selecdetail.value.ToString());
                    //                          //     lbmachitietco.Text = machitiet;
                    //    lbtenchitietco.Text = "";//namechitiet;
                    //}
                }
                else
                {
                    this.tkcochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                          //     lbmachitietco.Text = machitiet;
                    lbtenchitietco.Text = "";//namechitiet;
                }
                //  selecdetail.Text;

            }
            else
            {
                this.tkcochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                      //     lbmachitietco.Text = machitiet;
                lbtenchitietco.Text = "";//namechitiet;
            }




        }

        private void cbtaikhoanco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            #region  list black phiếu

            cbsophieu.Text = "";
            cbtennguoinop.Text = "";
            cbdiachi.Text = "";
            cbdiengiai.Text = "";
            cbsotien.Text = "";
            cbsochungtugoc.Text = "";

            lbtenchitietno.Text = "";
            lbtenchitietco.Text = "";
            cbtkno.SelectedIndex = -1;
            cbtaikhoanco.SelectedIndex = -1;

            datepickngayphieu.Focus();



            #endregion
        }

        private void button5_Click(object sender, EventArgs e)
        {



            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var phieuthu = from tbl_SoQuy in dc.tbl_SoQuys
                           where tbl_SoQuy.id == 38
                           select new
                           {

                               tencongty = Model.Congty.getnamecongty(),
                               diachicongty = Model.Congty.getdiachicongty(),
                               masothue = Model.Congty.getmasothuecongty(),
                               tengiamdoc = Model.Congty.gettengiamdoccongty(),
                               tenketoantruong = Model.Congty.gettenketoantruongcongty(),

                               sophieuthu = tbl_SoQuy.Sochungtu,
                               ngaychungtu = tbl_SoQuy.Ngayctu,
                               nguoinoptien = tbl_SoQuy.Nguoinopnhantien,
                               nguoilapphieu = Utils.getname(),
                               diachinguoinop = tbl_SoQuy.Diachinguoinhannop,
                               lydothu = tbl_SoQuy.Diengiai,
                               sotien = tbl_SoQuy.PsNo,
                               sotienbangchu = Utils.ChuyenSo(tbl_SoQuy.PsNo.ToString()),
                               sochungtugoc = tbl_SoQuy.Chungtugockemtheo,
                               username = Utils.getusername(),


                           };

            this.dataGridViewListphieuthu.DataSource = phieuthu;

            #region  view reports payment request  

            //Control_ac ctrac = new Control_ac();

            //var rs1 = ctrac.KArptdataset1(dc);
            //var rs2 = ctrac.KArptdataset2(dc);



            if (phieuthu.Count() == 1)
            {

                Utils ut = new Utils();
                var dataset1 = ut.ToDataTable(dc, phieuthu);

                Reportsview rpt = new Reportsview(dataset1, null, "Phieuthu.rdlc");
                rpt.ShowDialog();

            }

            #endregion view reports payment request  // 

        }
    }
}

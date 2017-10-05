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
    public partial class BeeHtoansocaidoiungphieuthu : Form
    {
    //    View.BeePhieuThu phieuchi;
        View.BeePhieuThu phieuthu;
        public int tkcochitiet { get; set; }
        public bool click { get; set; }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public double pssotienno { get; set; }
        public double pssotienco { get; set; }

        public BeeHtoansocaidoiungphieuthu(View.BeePhieuThu phieuthu, string labe1, string labe2, string labe3)
        {




            InitializeComponent();
            //if (phieuthu.pssotienno =="")
            //{
            //    phieuthu.pssotienno = "0";
            //}
            //if (phieuthu.pssotienco == "")
            //{
            //    phieuthu.pssotienco = "0";
            //}
            txtTongno.Text = phieuthu.pssotienno.ToString("#,#", CultureInfo.InvariantCulture);
            txtTongco.Text = phieuthu.pssotienco.ToString("#,#", CultureInfo.InvariantCulture);
            this.pssotienco = phieuthu.pssotienco;
            this.pssotienno = phieuthu.pssotienno;

            txtChenlech.Text = (this.pssotienno - this.pssotienco).ToString("#,#", CultureInfo.InvariantCulture);

            #region clearr to new

            cbtkco.SelectedIndex = -1;
            tbmachitiet.Text = "";
            lbtenchitiet.Text = "";
            txtsotien.Text = "";
            txtdiachi.Text = "";
            txtkyhieuctu.Text = "";
            txtsochungtu.Text = "";

            #endregion




            this.click = false;
            this.phieuthu = phieuthu;



            #region load tk nợ

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            tbl_loaitk tkkt = new tbl_loaitk();

            var rs1 = from tk in dc.tbl_dstaikhoans
                      where tk.loaitkid == "nguonvon" || tk.loaitkid == "phaitra" || tk.loaitkid == "tamung"  // 5.nguon von;  7 phai tra; 9. tam ung
                      select tk;

            //      string drowdownshow = "";

        //            tien
        //kho
        //taisan
        //nguonvon
        //doanhthu
        //chiphi
        //xacdinhkqkd
        //loinhuan
        //phaithu
        //phaichi
        //tamung

            foreach (var item in rs1)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk;
                cb.Text = item.matk + ":" + item.tentk;
                this.cbtkco.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk nợ





        }

  


        private void Seachcode_Deactivate(object sender, EventArgs e)
        {
             //   this.Close();
        }


        public void sendingtext_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void sendingcontract_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    txt03.Focus();

            //    //if (tablename == "KASeachcontract")
            //    //{
            //    //   // Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    //}



            //}
        }

        private void sendingname_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtvat_KeyPress(object sender, KeyPressEventArgs e)
        {
            //   if (e.KeyChar == (char)Keys.Enter)
            //   {


            //       this.text01.Focus();

            ////       if (tablename == "KASeachcontract")
            ////       {
            //////           Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            ////       }



            //   }
        }


        private void bt_timkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //       this.text01.Focus();
            //   // this.bt_timkiem.Focus();

            //    //if (tablename == "KASeachcontract")
            //    //{
            //    //  //  Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    //}



            //}
        }

        private void BeeHtoansocaidoiungphieuthu_Load(object sender, EventArgs e)
        {

        }

        private void cbtkco_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lbtenchitiet.Visible = true;

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



                    View.beeselectinput selecdetail = new beeselectinput("Chọn chi tiết tài khoản ", listcb);

                    selecdetail.ShowDialog();
                    bool chon = selecdetail.kq;
                    if (chon)
                    {
                        string machitiet = selecdetail.value;
                        string namechitiet = selecdetail.valuetext;
                        //     lbmachitietco.Visible = true;

                        lbtenchitiet.Visible = true;
                        this.tkcochitiet = int.Parse(selecdetail.value.ToString());


                        tbmachitiet.Text = machitiet;
                        lbtenchitiet.Text = namechitiet;
                    }
                    else
                    {
                        cbtkco.SelectedIndex = -1;
                    }

                }
                else
                {
                    tbmachitiet.Text = "";
                    lbtenchitiet.Text = "";//namechitiet;
                }
                //  selecdetail.Text;

            }
            else
            {
                tbmachitiet.Text = "";
                lbtenchitiet.Text = "";//namechitiet;
            }


            txtsotien.Focus();




        }

        private void txtsotien_KeyPress(object sender, KeyPressEventArgs e)
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
                datepickngayphieu.Focus();

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
                e.Handled = true;
                txtkyhieuctu.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txtkyhieuctu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                txtsochungtu.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txtsochungtu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                bt_themvao.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txtsotien_TextChanged(object sender, EventArgs e)
        {
            //if (!Utils.IsValidnumber(txtsotien.Text.ToString()))
            //{
            //    txtsotien.Text = "";
            //}

        }

        private void bt_themvao_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            tbl_Socai socaitemp = new tbl_Socai();

            //if (this.cb_channel.SelectedItem != null)
            if (cbtkco.SelectedItem != null)
            {
                socaitemp.TkCo = (cbtkco.SelectedItem as ComboboxItem).Value.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbtkco.Focus();
                return;
            }

            if (Utils.IsValidnumber(txtsotien.Text))
            {
                socaitemp.PsCo = double.Parse(txtsotien.Text.Trim());
            }
            else
            {
                MessageBox.Show("Số tiền gõ vào phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsotien.Focus();
                return;
            }



            // txtdiachi

            if (txtdiachi.Text != "")
            {
                socaitemp.Diengiai = txtdiachi.Text;
            }
            else
            {
                MessageBox.Show("Bạn chưa gõ diễn giải", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            //datepickngayphieu

            socaitemp.Ngayctu = datepickngayphieu.Value;

            //     txtkyhieuctu
            if (txtkyhieuctu.Text != "")
            {
                socaitemp.Kyhieuctu = txtkyhieuctu.Text;
            }
            //else
            //{
            //    MessageBox.Show("Bạn chưa gõ Tên chi tiét", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtkyhieuctu.Focus();
            //    return;
            //}

            //lbtenchitiet
            if (lbtenchitiet.Text != "")
            {
                socaitemp.tenchitietCo = lbtenchitiet.Text;
            }
            //else
            //{
            //    MessageBox.Show("Bạn chưa gõ mã chi tiết", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtkyhieuctu.Focus();
            //    return;
            //}


            // tbmachitiet

            if (tbmachitiet.Text != "")
            {
                socaitemp.MaCTietTKCo = int.Parse(tbmachitiet.Text.ToString());
            }



            //   txtsochungtu


            if (Utils.IsValidnumber(txtsochungtu.Text))
            {
                socaitemp.Soctu = int.Parse(txtsochungtu.Text.Trim());
            }
            else
            {
                MessageBox.Show("Kiểm tra lại số chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsochungtu.Focus();
                return;
            }




            this.phieuthu.add_detailGridviewTkCophieuthu(socaitemp);

            txtTongco.Text = phieuthu.pssotienco.ToString("#,#", CultureInfo.InvariantCulture);
            this.pssotienco = phieuthu.pssotienco;
            this.pssotienno = phieuthu.pssotienno;

            txtChenlech.Text = (this.pssotienno - this.pssotienco).ToString("#,#", CultureInfo.InvariantCulture);

            #region clearr to new

            cbtkco.SelectedIndex = -1;
            tbmachitiet.Text = "";
            lbtenchitiet.Text = "";
            txtsotien.Text = "";
            txtdiachi.Text = "";
            txtkyhieuctu.Text = "";
            txtsochungtu.Text = "";

            #endregion






        }

        private void BeeHtoansocaidoiungphieuthu_Deactivate(object sender, EventArgs e)
        {
           // this.Close();
        }
    }
}

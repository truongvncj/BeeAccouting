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
    public partial class BeeHtoansocaiphieuthu : Form
    {
        View.BeePhieuThu phieuthu;

        public string diengiaitxt { get; set; }
        public string sotientxt { get; set; }
        public string machitiettxt { get; set; }

        public string tenchitiettxt { get; set; }


        public string tkco { get; set; }
        public string tkcoten { get; set; }
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

        public BeeHtoansocaiphieuthu(View.BeePhieuThu phieuthu, string labe1, string labe2, string labe3)
        {




            InitializeComponent();

            txtTongno.Text = phieuthu.pssotienno.ToString("#,#", CultureInfo.InvariantCulture);
            txtTongco.Text = phieuthu.pssotienco.ToString("#,#", CultureInfo.InvariantCulture);


            this.pssotienco = phieuthu.pssotienco;
            this.pssotienno = phieuthu.pssotienno;

            txtChenlech.Text = (-this.pssotienno + this.pssotienco).ToString("#,#", CultureInfo.InvariantCulture);

            #region clearr to new

            this.tkco = "";
            lb_machitietco.Text = "";
            lbtenchitietco.Text = "";
            txtsotien.Text = "";
            txtdiengiai.Text = "";
            diengiaitxt = "";// { get; set; }
            sotientxt = "";// { get; set; }
            machitiettxt = "";

            tenchitiettxt = "";//
            lbtaikhoancotext.Text = "";

            #endregion




            this.click = false;
            this.phieuthu = phieuthu;





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
            lbtenchitietco.Visible = true;

            string taikhoan = this.tkco;//(cbtkno.SelectedItem as ComboboxItem).Value.ToString();
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

                        lbtenchitietco.Visible = true;
                        this.tkcochitiet = int.Parse(selecdetail.value.ToString());


                        lb_machitietco.Text = machitiet;
                        lbtenchitietco.Text = namechitiet;
                    }


                }
                else
                {
                    lb_machitietco.Text = "";
                    lbtenchitietco.Text = "";//namechitiet;
                }
                //  selecdetail.Text;

            }
            else
            {
                lb_machitietco.Text = "";
                lbtenchitietco.Text = "";//namechitiet;
            }


            txtsotien.Focus();




        }

        private void txtsotien_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtdiachi_KeyPress(object sender, KeyPressEventArgs e)
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

        private void datepickngayphieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                //        txtkyhieuctu.Focus();

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
                //     txtsochungtu.Focus();

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

            //if (this.pssotienco == this.pssotienno)
            //{
            //    this.Close();
            //}

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            tbl_Socai socaitemp = new tbl_Socai();

            //if (this.cb_channel.SelectedItem != null)
            if (this.tkco != "")
            {
                socaitemp.TkCo = this.tkco;//(cbtkno.SelectedItem as ComboboxItem).Value.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài khoản có !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbchontkco.Focus();
                return;
            }

            // txt dien giảu
            //      txtdiengiai.Focus();
            //    txtdiengiai.Enabled = true;
            //   MessageBox.Show("....dien giai nhu sau:" + txtdiengiai.Text.ToString());
            if (this.diengiaitxt != "")
            {

                socaitemp.Diengiai = this.diengiaitxt;
            }
            else
            {
                MessageBox.Show("Bạn chưa gõ diễn giải", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiengiai.Focus();
                return;
            }



            //    MessageBox.Show("....so tien dang la:" + txtsotieno.Text.ToString());

            //  txtsotieno.Focus();
            //txtsotieno.Enabled = true;

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


        

            if (tenchitiettxt != "")
            {
                socaitemp.tenchitietCo = tenchitiettxt;
            }

            // tbmachitiet

            if (machitiettxt != "")
            {
                socaitemp.MaCTietTKCo = int.Parse(machitiettxt);
            }




            this.phieuthu.add_detailGridviewTkCophieuthu(socaitemp);




            txtTongco.Text = phieuthu.pssotienco.ToString("#,#", CultureInfo.InvariantCulture);
            txtTongno.Text = phieuthu.pssotienno.ToString("#,#", CultureInfo.InvariantCulture);

            this.pssotienco = phieuthu.pssotienco;
            this.pssotienno = phieuthu.pssotienno;

            txtChenlech.Text = (-phieuthu.pssotienno + phieuthu.pssotienco).ToString("#,#", CultureInfo.InvariantCulture);

            #region clearr to new
            this.tkco = "";

            lb_machitietco.Text = "";
            lbtenchitietco.Text = "";
            txtsotien.Text = "";
            txtdiengiai.Text = "";
            machitiettxt = "";

            tenchitiettxt = "";//
            diengiaitxt = "";// { get; set; }
            sotientxt = "";// { get; set; }
            #endregion






        }

        private void BeeHtoansocaidoiungphieuthu_Deactivate(object sender, EventArgs e)
        {
            // this.Close();
        }

        private void tbchontkco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
                string seaching = tbchontkco.Text.Trim();

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                var danhsachtaikhoan = from c in db.tbl_dstaikhoans
                                       where c.matk.Contains(seaching)
                                       && c.loaitkid != "tienmat"
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


                        this.tkco = taikhoanchon.matk;
                        this.tkcoten = taikhoanchon.tentk.Trim();
                        lbtaikhoancotext.Text = taikhoanchon.matk.Trim() + ": " + taikhoanchon.tentk.Trim();

                        #region chọn tài khoản chi tiết



                        if (taikhoanchon.loaichitiet == true) // là co theo doi chi tiết
                        {

                            List<beeselectinput.ComboboxItem> listcb = new List<beeselectinput.ComboboxItem>();
                            var rs = from tbl_machitiettk in db.tbl_machitiettks
                                     where tbl_machitiettk.matk.Trim() == this.tkco.Trim()
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
                                        this.tkcochitiet = int.Parse(selecdetail.value.ToString());
                                        //     lb_machitietco.Text = machitiet;
                                        lbtenchitietco.Text = namechitiet;
                                        lb_machitietco.Text = machitiet;
                                    }

                                }
                                else
                                {
                                    this.tkcochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                                          //     lb_machitietco.Text = machitiet;
                                    lbtenchitietco.Text = "";//namechitiet;
                                    lb_machitietco.Text = "";
                                }
                                //  selecdetail.Text;

                            }
                            else
                            {
                                this.tkcochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                                      //     lb_machitietco.Text = machitiet;
                                lbtenchitietco.Text = "";//namechitiet;
                                lb_machitietco.Text = "";
                            }




                        }
                        else
                        {
                            this.tkcochitiet = -1;// int.Parse(selecdetail.value.ToString());
                                                  //     lb_machitietco.Text = machitiet;
                            lbtenchitietco.Text = "";//namechitiet;
                            lb_machitietco.Text = "";
                        }



                        #endregion

                        // txtsophieu.Focus();
                    }
                    else
                    {
                        this.tkco = "";
                        this.tkcochitiet = -1;
                        lbtenchitietco.Text = "";
                        lb_machitietco.Text = "";
                        // tbchontkco.Focus();
                    }


                } // nếu danh sách tài khoản có


                //      xx
                txtsotien.Focus();

            }// end chon tai khoan no











        }

        private void bt_themvao_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                tbchontkco.Focus();


            }


        }

        private void txtsotieno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtsotieno_TextChanged(object sender, EventArgs e)
        {
            //this.sotientxt = txtsotien.Text;
        }

        private void txtdiengiai_TextChanged(object sender, EventArgs e)
        {
            this.diengiaitxt = txtdiengiai.Text;
        }

        private void lbtenchitietno_TextChanged(object sender, EventArgs e)
        {
            this.tenchitiettxt = lbtenchitietco.Text;
        }

        private void lb_machitietno_TextChanged(object sender, EventArgs e)
        {
            this.machitiettxt = lb_machitietco.Text;
        }
    }
}

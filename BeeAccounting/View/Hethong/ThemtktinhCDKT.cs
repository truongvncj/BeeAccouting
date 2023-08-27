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
    public partial class ThemtktinhCDKT : Form
    {
        View.BeeformatCDKT BeeformatCDKT;

        

        public string matk { get; set; }

        public string congtru { get; set; }
  
        public string laynohayco { get; set; }
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

        public ThemtktinhCDKT(View.BeePhieuchi phieuchi, string labe1, string labe2, string labe3)
        {




            InitializeComponent();

          //  txtTongno.Text = phieuchi.pssotienno.ToString("#,#", CultureInfo.InvariantCulture);
           // txtTongco.Text = phieuchi.pssotienco.ToString("#,#", CultureInfo.InvariantCulture);


            this.pssotienco = phieuchi.pssotienco;
            this.pssotienno = phieuchi.pssotienno;

          //  txtChenlech.Text = (-this.pssotienno + this.pssotienco).ToString("#,#", CultureInfo.InvariantCulture);

            #region clearr to new

            this.matk = "";

            this.congtru = "";// { get; set; }
            this.laynohayco = "";// { get; set; }
         
            #endregion




            this.click = false;
         




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
          ////  lbtenchitietno.Visible = true;

          

          //  string connection_string = Utils.getConnectionstr();
          //  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


          //  var detail = (from c in db.tbl_dstaikhoans
          //                where c.matk.Trim() == taikhoan.Trim()
          //                select c).FirstOrDefault();



          //  if (detail.loaichitiet == true) // là co theo doi chi tiết

          //  {

          //      List<beeselectinput.ComboboxItem> listcb = new List<beeselectinput.ComboboxItem>();
          //      var rs = from tbl_machitiettk in db.tbl_machitiettks
          //               where tbl_machitiettk.matk.Trim() == taikhoan.Trim()
          //               orderby tbl_machitiettk.machitiet
          //               select tbl_machitiettk;
          //      if (rs.Count() > 0)
          //      {


          //          foreach (var item2 in rs)
          //          {
          //              beeselectinput.ComboboxItem cb = new beeselectinput.ComboboxItem();
          //              cb.Value = item2.machitiet.ToString().Trim();
          //              cb.Text = item2.tenchitiet; //item2.machitiet.ToString().Trim() + ": " +
          //              listcb.Add(cb);
          //          }



          //          View.beeselectinput selecdetail = new beeselectinput("Chọn chi tiết tài khoản ", listcb);

          //          selecdetail.ShowDialog();
          //          bool chon = selecdetail.kq;
          //          if (chon)
          //          {
          //              string machitiet = selecdetail.value;
          //              string namechitiet = selecdetail.valuetext;
          //              //     lbmachitietco.Visible = true;

                  
          //          }


          //      }
          //      else
          //      {
                   
          //      }
          //      //  selecdetail.Text;

          //  }
          //  else
          //  {
               
          //  }


          




        }

        private void txtsotien_KeyPress(object sender, KeyPressEventArgs e)
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

          


        }

        private void BeeHtoansocaidoiungphieuthu_Deactivate(object sender, EventArgs e)
        {
            // this.Close();
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

        private void tbchontkco_KeyPress(object sender, KeyPressEventArgs e)
        {
           


        }

        

        private void txtsotieno_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtdiengiai_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void lbtenchitietno_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lb_machitietno_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void tbchontkco_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbchontkco_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                //  string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
                string seaching = tbchontkco.Text.Trim();
                MessageBox.Show("test" + seaching, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                var danhsachtaikhoan = from c in db.tbl_dstaikhoans
                                       where c.matk.Contains(seaching)
                                       //      && c.loaitkid == "tienmat"//
                                       select new
                                       {
                                           Mã_tài_khoản = c.matk,
                                           Tên_tài_khoản = c.tentk,
                                           c.id

                                       };
                if (danhsachtaikhoan.Count() > 0)
                {
                    Beeviewandchoose chontaikhoan = new Beeviewandchoose("CHỌN TÀI KHOẢN ", danhsachtaikhoan, db);
                    chontaikhoan.ShowDialog();
                    int idtaikhoan = chontaikhoan.value;
                    bool kq = chontaikhoan.kq;


                    if (kq)
                    {
                        var taikhoanchon = (from c in db.tbl_dstaikhoans
                                            where c.id == idtaikhoan
                                            select c).FirstOrDefault();


                        this.matk = taikhoanchon.matk;



                    }
                    else
                    {
                        this.matk = "";



                        tbchontkco.Focus();
                    }


                } // nếu danh sách tài khoản có

                //   txtsophieu.Focus();

                //      xx

            }// end chon tai khoan no





        }
    }
}

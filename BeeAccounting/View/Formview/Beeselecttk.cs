using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEEACCOUNT.shared;

namespace BEEACCOUNT.View
{
    public partial class Beeselecttk : Form
    {
        public Boolean chon { get; set; }
        public string mataikhoan { get; set; }
        public string tentaikhoan { get; set; }
        public int machitiettaikhoan { get; set; }
        public string tentaikhoanchitiet { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public Beeselecttk(string loaitaikhoan)
        {
            InitializeComponent();

            lb_machitietno.Text = "";
            lbtenchitietno.Text = "";
            this.tentaikhoan = "";
            this.tentaikhoanchitiet = "";

            pk_todate.Value = DateTime.Today;
            pkfromdate.Value = Utils.getFirstOfMonth(DateTime.Today); // DateTime.Today.AddDays(-double.Parse(DateTime.Today.Day.ToString()));


            chon = false;

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region load tk tmat

            var rs2 = from tk in dc.tbl_dstaikhoans
                  //    where tk.loaitkid == 8 // mã 8 là tiền mặt
                      select tk;

           

            if (loaitaikhoan == "tienmat")
            {
            rs2 = from tk in dc.tbl_dstaikhoans
                          where tk.loaitkid == "tienmat" // mã 8 là tiền mặt
                  select tk;

            }

            if (loaitaikhoan == "chitiet")
            {
                rs2 = from tk in dc.tbl_dstaikhoans
                      where tk.loaichitiet == true // mã 8 là tiền mặt
                      select tk;

            }
            







            foreach (var item in rs2)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk;
                cb.Text = item.matk + ":" + item.tentk;
                this.cbtk.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk nợ







            //  priod = null;
        }

        private void cb_year_SelectedValueChanged(object sender, EventArgs e)
        {
            //  bl_priod.Text = StringExtensions.Right(cb_year.Text,2) + cb_month.Text ;
        }

        private void cb_month_SelectedValueChanged(object sender, EventArgs e)
        {
            //      bl_priod.Text = StringExtensions.Right(cb_year.Text, 2) + cb_month.Text;
        }


        private void bl_priod_Click(object sender, EventArgs e)
        {



        }

        private void pkfromdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbtk_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string taikhoan = (cbtk.SelectedItem as ComboboxItem).Value.ToString();
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

                            ////   lbtenchitietno.Visible = true;
                            //   lb_machitietno.Visible = true;
                            //     this.tknochitiet = int.Parse(selecdetail.value.ToString());
                            //     lbmachitietco.Text = machitiet;
                            lbtenchitietno.Text = namechitiet;
                            lb_machitietno.Text = machitiet;
                        }
                        else
                        {

                            cbtk.SelectedIndex = -1;

                        }
                    }
                    else
                    {
                        // this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                        //     lbmachitietco.Text = machitiet;
                        lbtenchitietno.Text = "";//namechitiet;
                        lb_machitietno.Text = "";
                    }
                    //  selecdetail.Text;

                }
                else
                {
                    // this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                    //     lbmachitietco.Text = machitiet;
                    lbtenchitietno.Text = "";//namechitiet;
                    lb_machitietno.Text = "";
                }




            }
            else
            {
                // this.tknochitiet = -1;// int.Parse(selecdetail.value.ToString());
                //     lbmachitietco.Text = machitiet;
                lbtenchitietno.Text = "";//namechitiet;
                lb_machitietno.Text = "";
            }

        }

        private void bt_thuchien_Click(object sender, EventArgs e)
        {
            if (cbtk.SelectedItem != null)
            {
               this.mataikhoan = (cbtk.SelectedItem as ComboboxItem).Value.ToString();
                this.tentaikhoan = (cbtk.SelectedItem as ComboboxItem).Text.ToString();
            //    tentaikhoanchitiet = (cbtk.SelectedItem as ComboboxItem).Text.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chon = false;
                return;
            }

            if (pkfromdate.Value <= pk_todate.Value)
            {
                fromdate = pkfromdate.Value;
                todate = pk_todate.Value;


            }
            else
            {
                MessageBox.Show("Từ ngày phải nhỏ hơn đến ngày ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chon = false;
                return;
            }

            if (Utils.IsValidnumber(lb_machitietno.Text))
            {
               
                    this.machitiettaikhoan = int.Parse(lb_machitietno.Text.Trim());
                    this.tentaikhoanchitiet = lbtenchitietno.Text.Trim();
             
             
            }
         
        


            chon = true;
            if (chon == true)
            {
                this.Close();
            }
        




        }

        private void pkfromdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                pk_todate.Focus();


            }
        }

        private void pk_todate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pk_todate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                pkfromdate.Focus();


            }
        }

        private void cbtk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                pkfromdate.Focus();


            }
        }
    }
}

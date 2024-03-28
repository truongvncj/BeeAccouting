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
    public partial class Dinhkhoanphaitra : Form
    {
        public Boolean chon { get; set; }

        public Boolean hoadonkhongkevat { get; set; }
        public string mataikhoan { get; set; }
        public string tentaikhoan { get; set; }
        public int machitiettaikhoan { get; set; }
        public string tentaikhoanchitiet { get; set; }

        public int idsanpham { get; set; }

        public string noidung { get; set; }

        //public DateTime fromdate { get; set; }
        //public DateTime todate { get; set; }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public Dinhkhoanphaitra(string noidung, string mactphaitra, string tenchitiet)
        {
            InitializeComponent();

            lb_machitietno.Text = "";
            lbtenchitietno.Text = "";
            lb_tkno.Text = "";
            lb_mactco.Text = mactphaitra;
            lb_tenctco.Text = tenchitiet;

            this.tentaikhoan = "";
            this.tentaikhoanchitiet = "";

         //   lb_sotien.Text = sotien;
            txt_noidung.Text = noidung;// = 

            chon = false;

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

     








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

    
        private void bt_thuchien_Click(object sender, EventArgs e)
        {
            if (lb_tkno.Text =="")//this.mataikhoan == "")
            {
              
                MessageBox.Show("Bạn chưa chọn tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chon = false;
                return;
            }

            this.noidung = txt_noidung.Text.Truncate(225);
             //  this.hoadonkhongkevat = 

            if (Utils.IsValidnumber(lb_machitietno.Text))
            {
               
                    this.machitiettaikhoan = int.Parse(lb_machitietno.Text.Trim());
                    this.tentaikhoanchitiet = lbtenchitietno.Text.Trim();
             
             
            }
            chon = true;


         #region  // CHỌN SẢN PHẨM nếu mã tk là tk loại sản xuất thì sẽ phải chọn sẩn phẩm để tập hợp cf theo sản phẩm//


                      //  MessageBox.Show(this.mataikhoan);

                        if (this.mataikhoan.Trim() == "154" || this.mataikhoan.Trim() == "621" || this.mataikhoan.Trim() == "622" || this.mataikhoan.Trim() == "627") // nếu mã tk là tk loại sản xuất thì sẽ phải chọn sẩn phẩm để tập hợp cf theo sản phẩm
                        {
                            //  public int machitiettaikhoan { get; set; }

                            string seaching = tbchontkno.Text.Trim();

                            string connection_string = Utils.getConnectionstr();
                            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                            var dssanpham = from c in db.tbl_sx_sanphams
                                            //   where c.matk.Contains(seaching)
                                            select new
                                            {
                                                Mã_sản_phẩm = c.masp,
                                                Tên_sản_phẩm = c.tensp,
                                                Sản_xuất_tại = c.maphanxuong,
                                              //  Loại_sản_phẩm = c.loaisp,
                                                c.id

                                            };
                            if (dssanpham.Count() > 0)
                            {
                                Beeviewandchoose chonsanpham = new Beeviewandchoose("CHỌN SẢN PHẨM ", dssanpham, db);
                                chonsanpham.ShowDialog();
                                int idtaikhoan = chonsanpham.value;
                                bool kq = chonsanpham.kq;


                                if (kq)
                                {

                                    this.idsanpham = chonsanpham.value;

                                }
                                else
                                {
                                    this.idsanpham = -1;
                                    chon = false;
                                    return;
                                }






                            }

                        }

            #endregion


            if (chon == true)
            {
                this.Close();
            }
        




        }

        private void pkfromdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


            


            }
        }

        private void pk_todate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pk_todate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


      


            }
        }

        private void cbtk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


             


            }
        }

        private void tbsochitiet_Click(object sender, EventArgs e)
        {

            mosochitiettaikhoanloai2 mochitiet = new mosochitiettaikhoanloai2(5, "", 0);
            mochitiet.ShowDialog();


        }

        private void tbchontkno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
                string seaching = tbchontkno.Text.Trim();

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                var danhsachtaikhoan = from c in db.tbl_dstaikhoans
                                       where c.matk.Contains(seaching)
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


                        this.mataikhoan = taikhoanchon.matk;
                        lb_tkno.Text = taikhoanchon.matk + ": " + taikhoanchon.tentk.Trim();


                        #region chọn tài khoản chi tiết
                        //var detail = (from c in db.tbl_dstaikhoans
                        //              where c.matk.Trim() == tkno.Trim()
                        //              select c).FirstOrDefault();



                        if (taikhoanchon.loaichitiet == true) // là co theo doi chi tiết
                        {

                            List<beeselectinput.ComboboxItem> listcb = new List<beeselectinput.ComboboxItem>();
                            var rs = from tbl_machitiettk in db.tbl_machitiettks
                                     where tbl_machitiettk.matk.Trim() == this.mataikhoan.Trim()
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
                                    if (frm.Text == "selecChitietTK")
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

                                        lbtenchitietno.Visible = true;
                                        lb_machitietno.Visible = true;
                                        this.machitiettaikhoan = int.Parse(selecdetail.value.ToString());
                                        //     lbmachitietco.Text = machitiet;
                                        lbtenchitietno.Text = namechitiet;
                                        lb_machitietno.Text = machitiet;
                                    }

                                }
                                else
                                {
                                    this.machitiettaikhoan = -1;// int.Parse(selecdetail.value.ToString());
                                    //     lbmachitietco.Text = machitiet;
                                    lbtenchitietno.Text = "";//namechitiet;
                                    lb_machitietno.Text = "";
                                }
                                //  selecdetail.Text;

                            }
                            else
                            {
                                this.machitiettaikhoan = -1;// int.Parse(selecdetail.value.ToString());
                                //     lbmachitietco.Text = machitiet;
                                lbtenchitietno.Text = "";//namechitiet;
                                lb_machitietno.Text = "";
                            }




                        }
                        else
                        {
                            this.machitiettaikhoan = -1;// int.Parse(selecdetail.value.ToString());
                            //     lbmachitietco.Text = machitiet;
                            lbtenchitietno.Text = "";//namechitiet;
                            lb_machitietno.Text = "";
                        }



                        #endregion

                        txt_noidung.Focus();

                    }
                    else
                    {
                      this.tentaikhoanchitiet = "";
                        this.machitiettaikhoan = -1;
                        lb_tkno.Text = "";
                        lb_machitietno.Text = "";
                        tbchontkno.Focus();
                    }


                    //string taikhoan = (from c in db.tbl_dstaikhoans
                    //                   where c.id == idtaikhoan
                    //                   select c.matk).FirstOrDefault().ToString();

                } // nếu danh sách tài khoản có


                //      xx


            }// end chon tai khoan no

        }

        private void Dinhkhoanphaitra_Load(object sender, EventArgs e)
        {

        }

        private void cb_khongkekhaivat_CheckedChanged(object sender, EventArgs e)
        {
          
            this.hoadonkhongkevat = cb_khongkekhaivat.Checked;


        }
    }
}

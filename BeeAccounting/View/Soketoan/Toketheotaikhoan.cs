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
    public partial class Toketheotaikhoan : Form
    {
        public int statusphieu { get; set; } // mới  // 2 suawra // 3 display //
        public int buttoanid { get; set; }
        public string sobuttoan { get; set; }
        public LinqtoSQLDataContext dcchung { get; set; }
        //   public string makho { get; set; }
        public string tkno { get; set; }
        public int tknochitiet { get; set; }
        public string tkco { get; set; }
        public int tkcochitiet { get; set; }
        public double tongsotien { get; set; }
        public double sotienct { get; set; }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
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
                    //               View.BeeSeachtwofield sheaching = new BeeSeachtwofield(this, "Người nôp", "Địa chỉ", "Nội dung");
                    //             sheaching.Show();
                }




            }


            if (e.Control == true && e.KeyCode == Keys.N)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "BeeHtdoiungphieunhapkho")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    //     View.BeeHtdoiungphieunhapkho BeeHtdoiungphieunhapkho = new BeeHtdoiungphieunhapkho(this, "Địa chỉ", "", "");
                    //   BeeHtdoiungphieunhapkho.Show();
                }




            }


        }

        public View.Main main1;

        public Toketheotaikhoan(View.Main Main)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);  // để đọc từ bàn phím phím tắt

            this.sotienct = 0;
            this.tongsotien = 0;
            //   this.pssotienco = 0;
            this.main1 = Main;
            //lbid.Text = "";
            this.statusphieu = 1; // tạo mới
                                  //     txtsotiensave.Visible = false;

            Model.Username used = new Model.Username();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            this.dcchung = dc;

            string username = Utils.getusername();


            
            dataGridViewListBTTH.DataSource = Model.hachtoantonghop.danhsachbuttoansocai(dc, DateTime.Today.Date, txttkNo.Text.Trim(), txttkco.Text.Trim());
            //try
            //{
            //    dataGridViewListBTTH.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";
            //}
            //catch (Exception)
            //{

            ////    throw;
            //}
          



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
                //       txttennguoigiao.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

   
    

       
      

  
        private void dataGridViewListphieuthu_Paint(object sender, PaintEventArgs e)
        {

            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            foreach (var c in dataGridViewListBTTH.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

            // Next





        }

    

    
     
    
 
  
    

  
     

  
   
       

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tbchontkno_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridViewListBTTH.DataSource = Model.hachtoantonghop.danhsachbuttoansocai(dcchung, DateTime.Today.Date, txttkNo.Text.Trim(), txttkco.Text.Trim());
            //try
            //{
            //    dataGridViewListBTTH.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";
            //}
            //catch (Exception)
            //{

            //    //    throw;
            //}
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridViewListBTTH.DataSource = Model.hachtoantonghop.danhsachbuttoansocai(dcchung, DateTime.Today.Date, txttkNo.Text.Trim(), txttkco.Text.Trim());
            //try
            //{
            //    dataGridViewListBTTH.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";
            //}
            //catch (Exception)
            //{

            //    //    throw;
            //}

        }

        private void txttkNo_TextChanged(object sender, EventArgs e)
        {
            dataGridViewListBTTH.DataSource = Model.hachtoantonghop.danhsachbuttoansocai(dcchung, DateTime.Today.Date, txttkNo.Text.Trim(), txttkco.Text.Trim());

        }

        private void txttkco_TextChanged(object sender, EventArgs e)
        {
            dataGridViewListBTTH.DataSource = Model.hachtoantonghop.danhsachbuttoansocai(dcchung, DateTime.Today.Date, txttkNo.Text.Trim(), txttkco.Text.Trim());
        //    dataGridViewListBTTH.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";

        }

        private void txttkNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
                string seaching = txttkNo.Text.Trim();

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

                        txttkNo.Text = taikhoanchon.matk;
                        //      this.tkno = taikhoanchon.matk;
                        //    lbtkno.Text = taikhoanchon.matk + ": " + taikhoanchon.tentk.Trim();



                    }
                    else
                    {
                        txttkNo.Text = "";
                    }


                } // nếu danh sách tài khoản có


            }// end chon tai khoan no
        }

        private void txttkco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
                string seaching = txttkco.Text.Trim();

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

                        txttkco.Text = taikhoanchon.matk;
                        //      this.tkno = taikhoanchon.matk;
                        //    lbtkno.Text = taikhoanchon.matk + ": " + taikhoanchon.tentk.Trim();



                    }
                    else
                    {
                        txttkco.Text = "";
                    }


                } // nếu danh sách tài khoản có


            }// end chon tai khoan no
        }
    }
}
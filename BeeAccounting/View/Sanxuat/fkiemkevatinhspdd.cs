using BEEACCOUNT.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BEEACCOUNT.View
{
    public partial class fkiemkevatinhspdd : Form
    {

        public class ComboboxItem
        {
            public string Text { get; set; }
       
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public int nam { get; set; }
        public int thang { get; set; }

        public string manhamay { get; set; }

        public string masanpham { get; set; }

        public string maphanxuong { get; set; }

        public string pptinhgiaspdd { get; set; }

        public tbl_sx_phieutinhspddcuoiky phieutinhdd { get; set; }

        void Control_KeyPress(object sender, KeyEventArgs e)
        {






            if (e.Control == true && e.KeyCode == Keys.N)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "Tài khoản")
                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    // View.ThemtktinhCDKT ThemtktinhCDKT = new ThemtktinhCDKT(this);
                    //     ThemtktinhCDKT.Show();
                }





            }


        }

        public View.Main main1;
        public fkiemkevatinhspdd(View.Main Main, string namchon,string thangchon)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);  // để đọc từ bàn phím phím tắt
            this.main1 = Main;

            phieutinhdd = new tbl_sx_phieutinhspddcuoiky();

            lbnamchon.Text = namchon;
            lbtxtthangchon.Text = thangchon;
            thang = int.Parse(thangchon);
            nam = int.Parse(namchon);

            phieutinhdd.namdd = nam;
            phieutinhdd.thangdd = thang;


            lbpptinhddcuoiky.Text = "";

            blcongdoan.Visible = false;
            txtcbcongdoan.Visible = false;

            groupgiadinhmuc.Visible = false;
            grmucdohoanthanh.Visible = false;

            Model.Username used = new Model.Username();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            string username = Utils.getusername();



       



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


            }
        }

        private void datepickngayphieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // datepickngayphieu.
                e.Handled = true;



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



            }
        }

        private void cbdiachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;


            }
        }

        private void cbdiengiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;




            }
        }

        private void cbsotien_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;


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
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);








        }

        private void dataGridViewListphieuthu_Paint(object sender, PaintEventArgs e)
        {

            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            //foreach (var c in dataGridViewListphieuthu.Columns)
            //{
            //    DataGridViewColumn clm = (DataGridViewColumn)c;
            //    clm.HeaderText = clm.HeaderText.Replace("_", " ");
            //}

            // Next





        }

        private void cbtkno_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }


        private void cbtaikhoanco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {



        }

        private void dataGridViewListphieuthu_CellClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void dataGridViewListphieuthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void txtsophieu_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txttennguoinop_KeyPress(object sender, KeyPressEventArgs e)
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

      

    
     
  


   
        private void txtsotienco_TextChanged(object sender, EventArgs e)
        {


        }

        private void dataGridViewTkCo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {




        }

        private void txtsotien_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridViewListphieuthu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
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

        }

        private void cbnam_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var ds = from p in dc.CDKTtempketchuyens
                     where p.DuCock - p.DuNock != 0
                     && p.chon == true
                     select p;


            foreach (var item in ds)
            {
                tbl_Socai socai = new tbl_Socai();


                #region  ghi vao so cai

                if (item.DuCock > 0) // sẽ kết chuyển từ có qua nợ của tk kết chuyển == > nọ tk kc  có tk đích
                {
                    socai.TkCo = item.matkketchuyen;
                    socai.TkNo = item.matk;
                    socai.Sohieuchungtu = "AutoKC" + item.nam;
                    socai.PsCo = item.DuCock;
                    socai.PsNo = item.DuCock;
                    //   DateTime tem = new DateTime(int.Parse(item.nam.ToString()), 12, 31);
                    socai.Ngayctu = new DateTime(int.Parse(item.nam.ToString()), 12, 31); // ngay 31 tháng 12 năm đó
                    socai.manghiepvu = "TH";
                    socai.Ngayghiso = new DateTime(int.Parse(item.nam.ToString()), 12, 31); // ngay 31 tháng 12 năm đó
                    socai.username = Utils.getusername();
                    socai.Diengiai = "Auto Kết chuyển cuối năm";



                }

                if (item.DuNock > 0) // sẽ kết chuyển từ no qua co của tk kết chuyển == > co tk kc  no tk đích
                {
                 
                    socai.TkCo = item.matk;
                    socai.TkNo = item.matkketchuyen;
                    socai.Sohieuchungtu = "AutoKC" + item.nam;
                    socai.PsCo = item.DuNock;
                    socai.PsNo = item.DuNock;
                    //   DateTime tem = new DateTime(int.Parse(item.nam.ToString()), 12, 31);
                    socai.Ngayctu = new DateTime(int.Parse(item.nam.ToString()), 12, 31); // ngay 31 tháng 12 năm đó
                    socai.manghiepvu = "TH";
                    socai.Ngayghiso = new DateTime(int.Parse(item.nam.ToString()), 12, 31); // ngay 31 tháng 12 năm đó
                    socai.username = Utils.getusername();
                    socai.Diengiai = "Auto Kết chuyển cuối năm";



                }




                Model.Taikhoanketoan.ghisocaitk(socai);


                // = yearchon;


                #region caculation tinhsoducactaikhoanketchuyen
                SqlConnection conn2 = null;
                SqlDataReader rdr1 = null;

                string destConnString = Utils.getConnectionstr();
                try
                {

                    conn2 = new SqlConnection(destConnString);
                    conn2.Open();
                    SqlCommand cmd1 = new SqlCommand("tinhsoducactaikhoanketchuyen", conn2);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandTimeout = 0;
                    cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = Utils.getusername();
                    cmd1.Parameters.Add("@yearchon", SqlDbType.Int).Value = this.nam;
                    //   cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;




                    rdr1 = cmd1.ExecuteReader();



                }
                finally
                {
                    if (conn2 != null)
                    {
                        conn2.Close();
                    }
                    if (rdr1 != null)
                    {
                        rdr1.Close();
                    }
                }
                //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #endregion




                #endregion






            }


            MessageBox.Show("Kết chuyển thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

         

        }

        private void txtmachitieu_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtchuoicachtinh_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtmachitieu_TextChanged(object sender, EventArgs e)
        {

        }

    
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewformatBCTC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void txtcbmanhamay_SelectedValueChanged(object sender, EventArgs e)
        {
            this.manhamay = (string)(txtcbmanhamay.SelectedItem as ComboboxItem).Value;
            this.txtcbphanxuong.Items.Clear();

            #region load ds phân xưorng

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs2 = from p in dc.tbl_sx_dsphanxuongs

           
                      select p;

            //      string drowdownshow = "";

            foreach (var item in rs2)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.maphanxuong;
                cb.Text = item.tenphanxuong;
                this.txtcbphanxuong.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk nợ
        }

        private void txtcbphanxuong_SelectedValueChanged(object sender, EventArgs e)
        {
            this.maphanxuong = (string)(txtcbphanxuong.SelectedItem as ComboboxItem).Value;
            this.txtcbsanpham.Items.Clear();

            #region load ds phân xưorng

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs2 = from p in dc.tbl_sx_sanphams

                      where 
                     p.maphanxuong  == maphanxuong
                      select p;

            //      string drowdownshow = "";

            foreach (var item in rs2)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.masp;
                cb.Text = item.tensp;
                this.txtcbsanpham.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk nợ
        }

       

        private void txtcbsanpham_SelectedValueChanged(object sender, EventArgs e)
        {
            //  lbpptinhddcuoiky

            this.masanpham = (string)(txtcbsanpham.SelectedItem as ComboboxItem).Value;
            this.txtcbcongdoan.Items.Clear();


            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var sp = (from p in dc.tbl_sx_sanphams

                      where 
                  p.maphanxuong == maphanxuong
                          && p.masp == masanpham


                      select p).FirstOrDefault();

            if (sp != null)
            {
                lbpptinhddcuoiky.Text = sp.PPspdodang;
                pptinhgiaspdd = sp.PPspdodang;


                #region // tìm dơ dang dau ky
            

                var dk = (from c in dc.tbl_sx_phieutinhspddcuoikies
                          where
                          c.manhamay == manhamay
                       && c.maphaxuong == maphanxuong
                       && c.thangdd == thang

                       && c.namdd == nam


                           && c.masp == masanpham
                          select c.giatrispdauky).FirstOrDefault();

                if (dk != null)
                {
                    txtgtspdddauky.Text = dk.ToString();
                    phieutinhdd.giatrispdauky = dk;

                }

                #endregion


         







            };




        }
    }
}

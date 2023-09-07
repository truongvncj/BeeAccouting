using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEEACCOUNT.Control;

namespace BEEACCOUNT.View
{


    public partial class BeeLCDPSdauky : Form
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

        public int namchon { get; set; }

        public BeeLCDPSdauky(int namchon)
        {
            InitializeComponent();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            this.namchon = namchon;
            txtnam.Text = namchon.ToString();
            txtnam.Enabled = false;

            Utils ut = new Utils();

            var kq = from p in dc.CDPSdaukies
                     where p.nam == namchon // ((p.Nodk != 0) || (p.Codk != 0))
                     select new
                     {
                         //       Năm = p.nam,
                         Mã_tài_khoản = p.matk,
                         Tên_tài_khoản = p.tentk,
                         Nợ_ĐK = p.Nodk,
                         Có_ĐK = p.Codk,
                         Mã_chi_tiết = p.machitiet,
                         Tên_TK_chi_tiết = p.tentkchitiet,

                         //    ID = p.id

                     };

            if (kq.Count() == 0)
            {
                CDPSdauky p = new CDPSdauky();
                p.nam = this.namchon;

                //   p.Machitieu = (int)ro.Cells["Mã_số"].Value;
                p.matk = "111";
                p.Nodk = 0;
                p.Codk = 0;


                //    p.username = Utils.getname();

                dc.CDPSdaukies.InsertOnSubmit(p);
                dc.SubmitChanges();

                var kq2 = from p2 in dc.CDPSdaukies
                          where p2.nam == namchon  //&& ((p.Nodk != 0) || (p.Codk != 0))
                          select new
                          {
                              //       Năm = p.nam,
                              Mã_tài_khoản = p2.matk,

                              Nợ_ĐK = p2.Nodk,
                              Có_ĐK = p2.Codk,
                              //    ID = p.id

                          };


                var tble1 = ut.ToDataTable(dc, kq2);
                dataGridView1.DataSource = tble1;

            }
            if (kq.Count() > 0)
            {

                var tble1 = ut.ToDataTable(dc, kq);

                dataGridView1.DataSource = tble1;




            }



            dataGridView1.Columns["Mã_tài_khoản"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //    dataGridView1.Columns["Mã_tài_khoản"].ReadOnly = true;

            dataGridView1.Columns["Nợ_ĐK"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Nợ_ĐK"].DefaultCellStyle.BackColor = Color.BurlyWood;
            dataGridView1.Columns["Nợ_ĐK"].Width = 9000;
            //    dataGridView1.Columns["Nợ_ĐK"].ReadOnly = true;

            dataGridView1.Columns["Có_ĐK"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Có_ĐK"].DefaultCellStyle.BackColor = Color.BurlyWood;
            dataGridView1.Columns["Có_ĐK"].Width = 9000;





        }


        private void txt_vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //      cb_subid.Focus();


            }

        }

        private void txt_represennt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_sponsoramt.Focus();


            }
        }

        private void txt_chananame_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                // txt_paidamt.Focus();


            }
        }

        private void txt_houseno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_balance.Focus();


            }
        }

        private void txt_district_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_paymentamount.Focus();


            }
        }

        private void txt_provicen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_balancenew.Focus();


            }
        }

        private void txt_description_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_contractno.Focus();


            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }


        private void txt_paymentamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_paymentamount_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                //txt_note.Focus();
            }








        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Createpayment_Load(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btchangecontractitem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region  // kiểm tra tài khoản, nếu ok thì tiếp ko thì thoát


            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (r.Cells["Mã_tài_khoản"].Value != null)
                {



                    string matk = r.Cells["Mã_tài_khoản"].Value.ToString();

                    var kq1 = from p in dc.tbl_dstaikhoans
                              where p.matk == matk
                              select p;


                    if (kq1.Count() == 0)
                    {
                        r.Cells["Mã_tài_khoản"].DataGridView.BackColor = Color.Red;
                        MessageBox.Show("Mã tài khoản bị sai ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;



                    }
                }
            }
            #endregion


            #region  //  Xóa các cdps dầu kỳ cũ

            var kq = (from p in dc.CDPSdaukies
                      where p.nam == namchon
                      select p);
            if (kq.Count() > 0)
            {
                dc.CDPSdaukies.DeleteAllOnSubmit(kq);
                dc.SubmitChanges();
            }

            #endregion

            #region  // insert psdky mới


            foreach (var c in dataGridView1.Rows)
            {
                //  string matk = r.Cells["Mã_tài_khoản"].Value.ToString();
                //     dataGridView1.Columns["Nợ_ĐK"].SortMode = DataGridViewColumnSortMode.NotSortable;
                //    dataGridView1.Columns["Nợ_ĐK"].DefaultCellStyle.BackColor = Color.BurlyWood;
                //    dataGridView1.Columns["Nợ_ĐK"].Width = 900;
                //    dataGridView1.Columns["Nợ_ĐK"].ReadOnly = true;

                //   dataGridView1.Columns["Có_ĐK"].SortMode = DataGridViewColumnSortMode.NotSortable;


                DataGridViewRow ro = (DataGridViewRow)c;
                CDPSdauky p = new CDPSdauky();
                p.nam = this.namchon;

                //   p.Machitieu = (int)ro.Cells["Mã_số"].Value;

                if (ro.Cells["Mã_tài_khoản"].Value != null)
                {
                    p.matk = (string)ro.Cells["Mã_tài_khoản"].Value;
                    p.Nodk = (double)ro.Cells["Nợ_ĐK"].Value;
                    p.Codk = (double)ro.Cells["Có_ĐK"].Value;
                    dc.CDPSdaukies.InsertOnSubmit(p);
                    dc.SubmitChanges();
                }


                //    p.username = Utils.getname();


            }
            MessageBox.Show("Đã cập nhật theo dữ liệu nhập vào ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();


            #endregion










        }

        private void txtten_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            foreach (var c in dataGridView1.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

            // Next
        }
    }


}

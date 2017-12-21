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


    public partial class BeeCDKT200nhapsocho : Form
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

        public BeeCDKT200nhapsocho(int namchon)
        {
            InitializeComponent();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            this.namchon = namchon;
            txtnam.Text = namchon.ToString();
            txtnam.Enabled = false;


            var kq = from p in dc.CDKT200s
                     where p.nam == namchon
                     select new
                     {
                         Chỉ_tiêu = p.Tenchitieu,
                         Mã_số = p.Machitieu,
                         Cách_ghi = p.Cachghi,
                         Số_cuối_năm = p.Sotien,
                         ID = p.id

                     }; ;
            if (kq.Count() > 0)
            {

                Utils ut = new Utils();
                var tble1 = ut.ToDataTable(dc, kq);

                dataGridView1.DataSource = tble1;


             



            }
            else
            {
                var kq2 = from p in dc.CDKT200s
                          where p.nam == 2006
                          select new
                          {
                              Chỉ_tiêu = p.Tenchitieu,
                              Mã_số = p.Machitieu,
                              Cách_ghi = p.Cachghi,
                              Số_cuối_năm = p.Sotien,
                              ID = p.id

                          };

                Utils ut = new Utils();
                var tble2 = ut.ToDataTable(dc, kq2);

                dataGridView1.DataSource = tble2;

            
            }

            dataGridView1.Columns["ID"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["ID"].ReadOnly = true;

            dataGridView1.Columns["Mã_số"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Mã_số"].ReadOnly = true;
            dataGridView1.Columns["Cách_ghi"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Cách_ghi"].ReadOnly = true;

            dataGridView1.Columns["Chỉ_tiêu"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Chỉ_tiêu"].ReadOnly = true;

            dataGridView1.Columns["Số_cuối_năm"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Số_cuối_năm"].DefaultCellStyle.BackColor = Color.BurlyWood;

            //        idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



            //    }
            //            catch (Exception)
            //            {

            //                MessageBox.Show("Bạn phải chọn một xe !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }
            //Model.Nhacungcap.suathongtinxe(idtk);
            //            var rs = Model.Nhacungcap.danhsachxe(dc);
            //dataGridView1.DataSource = rs;

            //            //   Tải_trọng = p.sotantai,
            //            //      Kích_thước_thùng = p.sokhoithungxe,
            //            dataGridView1.Columns["Tải_trọng"].DefaultCellStyle.Format = "N0"; // để hiện số có dấu phảy
            //            dataGridView1.Columns["Kích_thước_thùng"].DefaultCellStyle.Format = "N0"; // để hiện số có dấu phảy

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

            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //#region  kiểm tra
            //if (Utils.IsValidnumber(txtdk111.Text) ==false)
            //{
            //    //   Control.Control_ac ctr12 = new Control_ac();
            //    MessageBox.Show("Kiểm tra doanh thu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //    ctr12.

            //    txtdk111.Focus();
            //    return;
            //}



            //#endregion

            //var kq = (from p in dc.KQKD200s
            //          where p.nam == namchon
            //          select p).FirstOrDefault();
            //if (kq != null)
            //{

            //    kq.dthu01 = float.Parse(txtdk111.Text); // 




            //    dc.SubmitChanges();
            //}
            //else
            //{
            //    KQKD200 p = new KQKD200();

            //    p.dthu01 = float.Parse(txtdk111.Text); // 

            //    p.nam = this.namchon;




            //    dc.KQKD200s.InsertOnSubmit(p);
            //    dc.SubmitChanges();



            //}
            //MessageBox.Show("Đã cập nhật theo dữ liệu nhập vào ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Close();

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

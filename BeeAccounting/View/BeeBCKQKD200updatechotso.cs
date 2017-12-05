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


    public partial class BeeBCKQKD200updatechotso : Form
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

        public BeeBCKQKD200updatechotso(int namchon)
        {
            InitializeComponent();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            this.namchon = namchon;
            txtnam.Text = namchon.ToString();
            txtnam.Enabled = false;


            var kq = (from p in dc.KQKD200s
                      where p.nam == namchon
                      select p).FirstOrDefault();
            if (kq != null)
            {


                txtdoanhthu.Text = kq.dthu01.ToString();
                txtgiamtrudoanhthu.Text = kq.giamdt02.ToString();
                txtnam.Text = namchon.ToString();


                txtgiavonhangban.Text = kq.giavon11.ToString();

                txtdoanhthutaichinh.Text = kq.dttaichinh.ToString();
                txtchiphitaichinh.Text = kq.cftaichinh.ToString();
                txtchiphilaivay.Text = kq.cflaivay.ToString();
                txtchiphibanhang.Text = kq.cfbanhang.ToString();

                txtcfqldn.Text = kq.cfquanlydn.ToString();

                txtdthukhac.Text = kq.thunhapkhac.ToString();
                txtcfkhac.Text = kq.cfkhac.ToString();
                txtcfthueTNDNhienhanh.Text = kq.cftndnhienhanh.ToString();
                txtcfthuetndnhoanlai.Text = kq.cfdnhoanlai.ToString();
                txtlaitrencophieu.Text = kq.laicbcophieu.ToString();
                txtsuygiamtrencophieu.Text = kq.laigiaomtrencphieu.ToString();

            }




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

            #region  kiểm tra
            if (Utils.IsValidnumber(txtdoanhthu.Text) ==false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra doanh thu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtdoanhthu.Focus();
                return;
            }
            if (Utils.IsValidnumber(txtgiamtrudoanhthu.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra giảm trừ doanh thu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtgiamtrudoanhthu.Focus();
                return;
            }
            if (Utils.IsValidnumber(txtgiavonhangban.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra giá vốn hàng bán ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtgiavonhangban.Focus();
                return;


            }


            if (Utils.IsValidnumber(txtdoanhthutaichinh.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra doanh thu tài chính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtdoanhthutaichinh.Focus();
                return;
            }


            if (Utils.IsValidnumber(txtdoanhthutaichinh.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra doanh thu tài chính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtdoanhthutaichinh.Focus();
                return;
            }

            if (Utils.IsValidnumber(txtchiphitaichinh.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra chi phí hoạt động tài chính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtchiphitaichinh.Focus();
                return;
            }


            if (Utils.IsValidnumber(txtchiphilaivay.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra chi phí lãi vay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtchiphilaivay.Focus();
                return;
            }

            if (Utils.IsValidnumber(txtchiphibanhang.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra chi phí bán hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtchiphibanhang.Focus();
                return;
            }
            if (Utils.IsValidnumber(txtcfqldn.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra chi phí quản lý doanh nghiệp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtcfqldn.Focus();
                return;
            }
            if (Utils.IsValidnumber(txtdthukhac.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra daonh thu khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtdthukhac.Focus();
                return;
            }

            if (Utils.IsValidnumber(txtcfkhac.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra chi phí khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtcfkhac.Focus();
                return;
            }
            if (Utils.IsValidnumber(txtcfthueTNDNhienhanh.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra chi phí thuế TNDN hiện hành ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtcfthueTNDNhienhanh.Focus();
                return;
            }

            if (Utils.IsValidnumber(txtcfthuetndnhoanlai.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra chi phí thuế TNDN hoãn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtcfthuetndnhoanlai.Focus();
                return;
            }

            if (Utils.IsValidnumber(txtlaitrencophieu.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra lãi trên cổ phiếu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtlaitrencophieu.Focus();
                return;
            }

            if (Utils.IsValidnumber(txtsuygiamtrencophieu.Text) == false)
            {
                //   Control.Control_ac ctr12 = new Control_ac();
                MessageBox.Show("Kiểm tra giảm trên cổ phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctr12.

                txtsuygiamtrencophieu.Focus();
                return;
            }
            #endregion

            var kq = (from p in dc.KQKD200s
                      where p.nam == namchon
                      select p).FirstOrDefault();
            if (kq != null)
            {

                kq.dthu01 = float.Parse(txtdoanhthu.Text); // 


                kq.giamdt02 = float.Parse(txtgiamtrudoanhthu.Text); // 
                                                                    //    namchon = txtnam.Text ; // 
                                                                    //     false; txtnam.Enabled ; // 

                kq.giavon11 = float.Parse(txtgiavonhangban.Text); // 

                kq.dttaichinh = float.Parse(txtdoanhthutaichinh.Text); // 
                kq.cftaichinh = float.Parse(txtchiphitaichinh.Text); // 
                kq.cflaivay = float.Parse(txtchiphilaivay.Text); //
                kq.cfbanhang = float.Parse(txtchiphibanhang.Text); // 

                kq.cfquanlydn = float.Parse(txtcfqldn.Text); //

                kq.thunhapkhac = float.Parse(txtdthukhac.Text); // 
                kq.cfkhac = float.Parse(txtcfkhac.Text); // 
                kq.cftndnhienhanh = float.Parse(txtcfthueTNDNhienhanh.Text); //  
                kq.cfdnhoanlai = float.Parse(txtcfthuetndnhoanlai.Text); //  
                kq.laicbcophieu = float.Parse(txtlaitrencophieu.Text); // 
                kq.laigiaomtrencphieu = float.Parse(txtsuygiamtrencophieu.Text); // 

                dc.SubmitChanges();
            }
            else
            {
                KQKD200 p = new KQKD200();

                p.dthu01 = float.Parse(txtdoanhthu.Text); // 

                p.nam = this.namchon;
                p.giamdt02 = float.Parse(txtgiamtrudoanhthu.Text); // 
                                                                    //    namchon = txtnam.Text ; // 
                                                                    //     false; txtnam.Enabled ; // 

                p.giavon11 = float.Parse(txtgiavonhangban.Text); // 

                p.dttaichinh = float.Parse(txtdoanhthutaichinh.Text); // 
                p.cftaichinh = float.Parse(txtchiphitaichinh.Text); // 
                p.cflaivay = float.Parse(txtchiphilaivay.Text); //
                p.cfbanhang = float.Parse(txtchiphibanhang.Text); // 

                p.cfquanlydn = float.Parse(txtcfqldn.Text); //

                p.thunhapkhac = float.Parse(txtdthukhac.Text); // 
                p.cfkhac = float.Parse(txtcfkhac.Text); // 
                p.cftndnhienhanh = float.Parse(txtcfthueTNDNhienhanh.Text); //  
                p.cfdnhoanlai = float.Parse(txtcfthuetndnhoanlai.Text); //  
                p.laicbcophieu = float.Parse(txtlaitrencophieu.Text); // 
                p.laigiaomtrencphieu = float.Parse(txtsuygiamtrencophieu.Text); // 




                dc.KQKD200s.InsertOnSubmit(p);
                dc.SubmitChanges();



            }
            MessageBox.Show("Đã cập nhật theo dữ liệu nhập vào ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void txtten_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }


}

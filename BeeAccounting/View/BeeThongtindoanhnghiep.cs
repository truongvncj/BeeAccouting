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


    public partial class BeeThongtindoanhnghiep : Form
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

        public string unitvalue { get; set; }

        public BeeThongtindoanhnghiep()
        {
            InitializeComponent();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //        tbl_congty cty = new tbl_congty();

            var cty = (from ctyi in dc.tbl_congties
                       select ctyi).FirstOrDefault();
            if (cty != null)
            {
                txtten.Text = cty.tencongty;

                txtdiachi.Text = cty.diachicoty;
                txtmasothue.Text = cty.Masothue;
                txttengiamdoc.Text = cty.tengiamdoc;
                txttenketoantruong.Text = cty.tenketoantruong;
                //txtmasothue.Text = cty.Masothue;
                //txtmasothue.Text = cty.Masothue;
                //txtmasothue.Text = cty.Masothue;




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

            //   tbl_congty cty = new tbl_congty();
            //        tbl_congty cty = new tbl_congty();

            var cty = (from ctyi in dc.tbl_congties
                       select ctyi).FirstOrDefault();
            if (cty != null)
            {
                cty.tencongty = txtten.Text;

                cty.diachicoty = txtdiachi.Text;
                cty.Masothue = txtmasothue.Text;
                cty.tengiamdoc = txttengiamdoc.Text;
                cty.tenketoantruong = txttenketoantruong.Text;


                dc.SubmitChanges();
            }
            else
            {
                tbl_congty p = new tbl_congty();
                p.tencongty = txtten.Text;

                p.diachicoty = txtdiachi.Text;
                p.Masothue = txtmasothue.Text;
                p.tengiamdoc = txttengiamdoc.Text;
                p.tenketoantruong = txttenketoantruong.Text;
                dc.tbl_congties.InsertOnSubmit(p);
                dc.SubmitChanges();



            }
        //    MessageBox.Show("Thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }


}

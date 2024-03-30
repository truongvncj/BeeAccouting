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
    public partial class ChonHanghoahayDv : Form
    {
        public Boolean chon { get; set; }

       

        public Boolean chonHanghoanhapkho { get; set; }
       // public Boolean chonNV { get; set; }

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
        public ChonHanghoahayDv()
        {
            InitializeComponent();

        
        

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



            if (cb_sphanghoanhapkho.Checked)
            {
                chonHanghoanhapkho = true;
            }
            else
            {
                chonHanghoanhapkho = false;
            } 


            chon = true;
         //   if (chon == true)
         //   {
                this.Close();
         //   }
        




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

          


        }

   
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cb_spdichvu.Checked = !cb_sphanghoanhapkho.Checked;

        }

        private void cb_nhanvientamung_CheckedChanged(object sender, EventArgs e)
        {
            cb_sphanghoanhapkho.Checked = !cb_spdichvu.Checked;
        }
    }
}

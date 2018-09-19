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
    public partial class Beefromdatetodate : Form
    {
        public Boolean chon { get; set; }
  
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
        public Beefromdatetodate()
        {
            InitializeComponent();

            pkfromdate.Value = Utils.getFirstOfMonth(DateTime.Today); // DateTime.Today.AddDays(-double.Parse(DateTime.Today.Day.ToString()));

            pk_todate.Value = DateTime.Today;
          

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

        private void cbtk_SelectionChangeCommitted(object sender, EventArgs e)
        {
         

        
        }

        private void bt_thuchien_Click(object sender, EventArgs e)
        {
          

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

        


            chon = true;
            if (chon == true)
            {
                this.Close();
            }
        




        }
    }
}

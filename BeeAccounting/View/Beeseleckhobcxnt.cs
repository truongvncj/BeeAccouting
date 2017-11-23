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
    public partial class Beeseleckhobcxnt : Form
    {
        public Boolean chon { get; set; }
        public string makho { get; set; }
        public string tenkho { get; set; }
     //   public int machitiettaikhoan { get; set; }
       // public string tentaikhoanchitiet { get; set; }
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
        public Beeseleckhobcxnt( )
        {
            InitializeComponent();

        
            this.tenkho = "";


            chon = false;

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region load kho
            var rs2 = from tk in dc.tbl_khohangs
                             select tk;

            
            foreach (var item in rs2)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.makho;
                cb.Text = item.makho + ":" + item.tenkho;
                this.cbkhohang.Items.Add(cb); // CombomCollection.Add(cb);

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
            string khohang = (cbkhohang.SelectedItem as ComboboxItem).Value.ToString();
            //     this.matk = taikhoan;


        
            

        }

        private void bt_thuchien_Click(object sender, EventArgs e)
        {
            if (cbkhohang.SelectedItem != null)
            {
               this.makho = (cbkhohang.SelectedItem as ComboboxItem).Value.ToString();
                this.tenkho = (cbkhohang.SelectedItem as ComboboxItem).Text.ToString();
            //    tentaikhoanchitiet = (cbtk.SelectedItem as ComboboxItem).Text.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn kho", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //if (Utils.IsValidnumber(lb_machitietno.Text))
            //{
               
            //        this.machitiettaikhoan = int.Parse(lb_machitietno.Text.Trim());
            //        this.tentaikhoanchitiet = lbtenchitietno.Text.Trim();
             
             
            //}
         
        


            chon = true;
            if (chon == true)
            {
                this.Close();
            }
        




        }
    }
}

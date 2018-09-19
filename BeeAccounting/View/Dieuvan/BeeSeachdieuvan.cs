using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BEEACCOUNT.View
{
    public partial class BeeSeachdieuvan : Form
    {
      //  public KAcontractlisting Fromviewable;
    //    public DataGridView Dtgridview;
       
        public string tablename;





        public BeeSeachdieuvan( )
        {


            //   return false;





            InitializeComponent();
          //  this.Fromviewable = Fromviewable;

           // this.tablename = tablename;

        }



        private void Seachcode_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }


        public void sendingtext_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txtdiachihanghoas.Focus();

                if (tablename == "KASeachcontract")
                {
             //       Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
                }



            }

        }

        private void sendingcontract_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtsovandon.Focus();

                if (tablename == "KASeachcontract")
                {
                  //  Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
                }



            }
        }

        private void sendingname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                this.txthanghoa.Focus();




            }
        }

        private void txtvat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                this.txttenkhachhang.Focus();

                if (tablename == "KASeachcontract")
                {
         //           Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
                }



            }
        }
    }
}

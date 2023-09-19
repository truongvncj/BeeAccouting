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
    public partial class Seachproductofchoose : Form
    {

        View.Chooseproductsx phieu;
        public string kq1 { get; set; }
        public string kq2 { get; set; }

        public string kq3 { get; set; }
        public bool  click { get; set; }



        public Seachproductofchoose(View.Chooseproductsx phieu, string labe1, string labe2, string labe3)
        {

          
         

            InitializeComponent();
            this.lb01.Text = labe1;
            this.lb02.Text = labe2;
            this.lb03.Text = labe3;
            this.click = false;
            this.phieu = phieu;


        }



        private void Seachcode_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }


        public void sendingtext_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                text02.Focus();


                this.kq1 = text01.Text;
                this.kq2 = text02.Text;
                this.kq3 = txt03.Text;
                this.click = true;
                // text01.Focus();



                //  if (true)
                // {

                // }


                this.phieu.reloadseachview(this.kq1, this.kq2, this.kq3);


            }

        }

        private void sendingcontract_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt03.Focus();

                this.kq1 = text01.Text;
                this.kq2 = text02.Text;
                this.kq3 = txt03.Text;
                this.click = true;
                // text01.Focus();



                //  if (true)
                // {

                // }


                this.phieu.reloadseachview(this.kq1, this.kq2, this.kq3);



            }
        }

        private void sendingname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


             this.text01.Focus();

                this.kq1 = text01.Text;
                this.kq2 = text02.Text;
                this.kq3 = txt03.Text;
                this.click = true;
                // text01.Focus();



                //  if (true)
                // {

                // }


                this.phieu.reloadseachview(this.kq1, this.kq2, this.kq3);


            }
        }

        private void txtvat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                this.text01.Focus();

         //       if (tablename == "KASeachcontract")
         //       {
         ////           Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
         //       }



            }
        }

        private void bt_timkiem_Click(object sender, EventArgs e)
        {






        }

        private void bt_timkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                   this.text01.Focus();
               // this.bt_timkiem.Focus();

                //if (tablename == "KASeachcontract")
                //{
                //  //  Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
                //}



            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BEEACCOUNT.View
{
    public partial class kareportsform : Form
    {
        public kareportsform()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "kaPriodpicker")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                View.kaPriodpicker kaPriodpicker = new View.kaPriodpicker();


                kaPriodpicker.ShowDialog();
                string priod = kaPriodpicker.priod;

                //var rs = from tbl_kasale in dc.tbl_kasales
                //         where tbl_kasale.Priod == priod
                //         group tbl_kasale by new
                //         {
                //             tbl_kasale.Sold_to,
                //             tbl_kasale.Sales_Org

                //         }
                //          into g
                //         select new
                //         {
                //             Priod = g.Select(gg => gg.Priod).FirstOrDefault(),
                //             Region = g.Key.Sales_Org,
                //             Sold_to = g.Key.Sold_to,
                //             Name = g.Select(gg => gg.Cust_Name).FirstOrDefault(),
                //             PCs = g.Sum(gg => gg.EC).GetValueOrDefault(0),
                //             EC = Math.Ceiling(g.Sum(gg => gg.PC).GetValueOrDefault(0)),
                //             UC = Math.Ceiling(g.Sum(gg => gg.UC).GetValueOrDefault(0)),
                //             Litter = Math.Ceiling(g.Sum(gg => gg.Litter).GetValueOrDefault(0)),
                //             NSR = Math.Ceiling(g.Sum(gg => gg.NSR).GetValueOrDefault(0)),
                //             GSR = Math.Ceiling(g.Sum(gg => gg.GSR).GetValueOrDefault(0)),



                //         };

                //Viewtable viewtbl = new Viewtable(rs, dc, "SALES DATA PRIOD: " + priod, 2);// view code 1 la can viet them lenh

                //viewtbl.Show();

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ////LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            ////var typeffmain = typeof(tbl_KaCustomer);

            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //var rscustemp2 = from tbl_KaCustomer in dc.tbl_KaCustomers


            //                 select tbl_KaCustomer;
            //Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST CUSTOMER DATA", 3);// view code 1 la can viet them lenh

            //viewtbl.Show();



        }
        class dateacrrual
        {

            public DateTime Accrualdate { get; set; }

        }

        public void Accrualmake(object Objdateacrrual)
        {
            dateacrrual dat = (dateacrrual)Objdateacrrual;

            DateTime Accrualdate = dat.Accrualdate;




      //      Control.Control_ac.AccrualContractinSQL(Accrualdate);


        }



    
        private void button5_Click(object sender, EventArgs e)
        {




            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //var rscustemp2 = from tbl_kaProductlist in dc.tbl_kaProductlists


            //                 select tbl_kaProductlist;
            //Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST PRODUCTS DATA", 3);// view code 1 la can viet them lenh

            //viewtbl.Show();






        }

    
  
        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

 
    
        private void button13_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}

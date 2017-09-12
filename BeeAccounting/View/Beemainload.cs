using BEEACCOUNT.Model;
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
    public partial class Beemainload : Form
    {

        public View.Main main1;

        public Beemainload(View.Main Main)
        {
            InitializeComponent();

            Model.Username used = new Username();
            this.main1 = Main;
            //if (used.masterbegin)
            //{
            //    begin.Enabled = true;
            //}
            //else
            //{
            //    begin.Enabled = false;
            //}

            ////  masterdatafuction

            //if (used.masterdatafuction)
            //{
            //    masterdatafuction.Enabled = true;
            //}
            //else
            //{
            //    masterdatafuction.Enabled = false;
            //}


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void KAmasterinput_Deactivate(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Product prd = new Product();
            //DialogResult kq1 = MessageBox.Show("Xóa toàn bộ Product ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //bool kq;
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            //switch (kq1)
            //{

            //    case DialogResult.None:
            //        break;
            //    case DialogResult.Yes:
            //        DialogResult kq2 = MessageBox.Show("Yes là xóa toàn bộ data product, are you sure ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        //  this.uploadCustomerToolStripMenuItem.Enabled = false;

            //        //    this.reportsToolStripMenuItem.Enabled = false;

            //        if (kq2 == DialogResult.Yes)
            //        {
            //            prd.productlistinput();



            //            VInputchange inputcdata2 = new VInputchange("", "LIST MASTER DATA PRODUCTS ", dc, "tbl_kaProductlist", "tbl_kaProductlist", typeff, typeff, "id", "id", "");
            //            inputcdata2.Show();
            //        }


            //        break;
            //    case DialogResult.Cancel:
            //        break;
            //    case DialogResult.Abort:
            //        break;
            //    case DialogResult.Retry:
            //        break;
            //    case DialogResult.Ignore:
            //        break;
            //    case DialogResult.OK:
            //        break;
            //    case DialogResult.No:

            //var typeff = typeof(tbl_kaProductlist);
            //VInputchange inputcdata = new VInputchange("", "LIST MASTER DATA PRODUCTS ", dc, "tbl_kaProductlist", "tbl_kaProductlist", typeff, typeff, "id", "id", "");
            //inputcdata.Show();



            //    break;
            //default:
            //    break;
            //     }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //var typeff = typeof(tbl_kacontractbegindata);

            //VInputchange inputcdata = new VInputchange("", "LIST MASTER DATA CONTRACTS ", dc, "tbl_kacontractbegindata", "tbl_kacontractbegindata", typeff, typeff, "id", "id", "");
            //inputcdata.Show();


            //#region


            //Contract ctract = new Contract();
            //DialogResult kq1 = MessageBox.Show("Xóa toàn bộ begin contract ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            ////      bool kq;
            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tbl_kacontractbegindata);
            //switch (kq1)
            //{

            //    case DialogResult.None:
            //        break;
            //    case DialogResult.Yes:

            //        //  this.uploadCustomerToolStripMenuItem.Enabled = false;
            //        DialogResult kq2 = MessageBox.Show("YEs là xóa dữ liệu begin Contract, bạn định xóa ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (kq2 == DialogResult.Yes)
            //        {
            //            ctract.deleteallbegincontract();


            //        }


            //        ctract.inputcontract();




            //        var rscustemp2 = from tbl_kacontractmasterdata in dc.tbl_kacontractbegindatas


            //                         select tbl_kacontractmasterdata;
            //        Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST MASTER DATA CONTRACTS", 3);// view code 1 la can viet them lenh

            //        viewtbl.Show();



            //        break;
            //    case DialogResult.Cancel:
            //        break;
            //    case DialogResult.Abort:
            //        break;
            //    case DialogResult.Retry:
            //        break;
            //    case DialogResult.Ignore:
            //        break;
            //    case DialogResult.OK:
            //        break;
            //    case DialogResult.No:



            //        ctract.inputcontract();


            //        rscustemp2 = from tbl_kacontractmasterdata in dc.tbl_kacontractbegindatas
            //                     select tbl_kacontractmasterdata;

            //        viewtbl = new Viewtable(rscustemp2, dc, "LIST MASTER DATA CONTRACTS", 3);// view code 1 la can viet them lenh

            //        viewtbl.Show();





            //        break;
            //    default:
            //        break;
            //}
            //#endregion



        }

        private void button4_Click(object sender, EventArgs e)
        {
            fuctionprog fuct = new fuctionprog();
            //       DialogResult kq1 = MessageBox.Show("Xóa toàn bộ Fuction ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //      bool kq;
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //     var typeff = typeof(tbl_Kafuctionlist);
            //switch (kq1)
            //{

            //    case DialogResult.None:
            //        break;
            //    case DialogResult.Yes:

            //        //  this.uploadCustomerToolStripMenuItem.Enabled = false;

            //        //    this.reportsToolStripMenuItem.Enabled = false;


            //        fuct.Fuction_input();



            //    VInputchange inputcdata = new VInputchange("", "LIST PROGRAM FUCTIONS ", dc, "tbl_Kafuctionlist", "tbl_Kafuctionlist", typeff, typeff, "id", "id", "");
            //        inputcdata.Show();




            //        break;
            //    case DialogResult.Cancel:
            //        break;
            //    case DialogResult.Abort:
            //        break;
            //    case DialogResult.Retry:
            //        break;
            //    case DialogResult.Ignore:
            //        break;
            //    case DialogResult.OK:
            //        break;
            //    case DialogResult.No:




            //        inputcdata = new VInputchange("", "LIST PROGRAM FUCTION ", dc, "tbl_Kafuctionlist", "tbl_Kafuctionlist", typeff, typeff, "id", "id", "");
            //        inputcdata.Show();


            //        break;
            //    default:
            //        break;
            //}

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    tbl_karegion

            //    var typeff = typeof(tbl_kaPrdgrp);



            //string sql =" IF OBJECT_ID(N'tbl_kaPrdgrpTMP" + urs + @"', N'U') IS NOT NULL
            //                 DROP TABLE tbl_kaPrdgrpTMP" + urs;

            //db.ExecuteCommand(sql);

            //db.SubmitChanges();

            //sql ="CREATE TABLE tbl_kaPrdgrpTMP" + urs + @"
            //    ( [PrdGrp] [niewarchar](255) NULL,
            //     [ProductGroup]  [nvarchar](255) NULL,
            //    	[WStatement]    [nvarchar](255) NULL,
            //    [id]  [int] IDENTITY(1,1) NOT NULL)
            //    ";


            //db.ExecuteCommand(sql);

            //db.SubmitChanges();







            //   VInputchange inputcdata = new VInputchange("", "LIST PRODUCT GROUP", db, "tbl_kaPrdgrp", "tbl_kaPrdgrp", typeff, typeff, "id", "id", "");
            //  inputcdata.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            programlist proglist = new programlist();
            //    DialogResult kq1 = MessageBox.Show("Xóa toàn bộ Program ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //      bool kq;
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //    var typeff = typeof(tbl_kaprogramlist);
            //switch (kq1)
            //{

            //    case DialogResult.None:
            //        break;
            //    case DialogResult.Yes:

            //        //  this.uploadCustomerToolStripMenuItem.Enabled = false;

            //        //    this.reportsToolStripMenuItem.Enabled = false;


            //        proglist.input();



            //     VInputchange inputcdata = new VInputchange("", "LIST PROGRAM LIST ", dc, "tbl_kaprogramlist", "tbl_kaprogramlist", typeff, typeff, "id", "id", "");
            //      inputcdata.Show();




            //        break;
            //    case DialogResult.Cancel:
            //        break;
            //    case DialogResult.Abort:
            //        break;
            //    case DialogResult.Retry:
            //        break;
            //    case DialogResult.Ignore:
            //        break;
            //    case DialogResult.OK:
            //        break;
            //    case DialogResult.No:





            //inputcdata = new VInputchange("", "LIST PROGRAM LIST ", dc, "tbl_kaprogramlist", "tbl_kaprogramlist", typeff, typeff, "id", "id", "");
            //inputcdata.Show();


            //        break;
            //    default:
            //        break;
            //}

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //    SetGroupFrom
            SetGroupFrom prdgroup = new SetGroupFrom("PRODUCT GROUP MEMBER");

            prdgroup.ShowDialog();






        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    tbl_karegion

            //   var typeff = typeof(tbl_karegion);



            //string sql =" IF OBJECT_ID(N'tbl_kaPrdgrpTMP" + urs + @"', N'U') IS NOT NULL
            //                 DROP TABLE tbl_kaPrdgrpTMP" + urs;

            //db.ExecuteCommand(sql);

            //db.SubmitChanges();

            //sql ="CREATE TABLE tbl_kaPrdgrpTMP" + urs + @"
            //    ( [PrdGrp] [nvarchar](255) NULL,
            //     [ProductGroup]  [nvarchar](255) NULL,
            //    	[WStatement]    [nvarchar](255) NULL,
            //    [id]  [int] IDENTITY(1,1) NOT NULL)
            //    ";


            //db.ExecuteCommand(sql);

            //db.SubmitChanges();







            //   VInputchange inputcdata = new VInputchange("", "LIST REGION", db, "tbl_karegion", "tbl_karegion", typeff, typeff, "id", "id", "");
            //  inputcdata.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            //  string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    tbl_karegion

            //      var typeff = typeof(tbl_kacurrency);







            //    VInputchange inputcdata = new VInputchange("", "LIST CURRENCY", db, "tbl_kacurrency", "tbl_kacurrency", typeff, typeff, "id", "id", "");
            //    inputcdata.Show();
        }

        private void KAmasterinput_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    tbl_karegion

            //    var typeff = typeof(tbl_kacontracttype);
            //   VInputchange inputcdata = new VInputchange("", "LIST CONTRACT TYPE", db, "tbl_kacontracttype", "tbl_kacontracttype", typeff, typeff, "id", "id", "");
            //    inputcdata.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    tbl_karegion

            //     var typeff = typeof(tbl_PaymentTerm);
            //     VInputchange inputcdata = new VInputchange("", "LIST PAYMENT TERM", db, "tbl_PaymentTerm", "tbl_PaymentTerm", typeff, typeff, "id", "id", "");
            //     inputcdata.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            //string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    tbl_karegion

            //    var typeff = typeof(tbl_kaChannel);
            //     VInputchange inputcdata = new VInputchange("", "LIST CHANNEL", db, "tbl_kaChannel", "tbl_kaChannel", typeff, typeff, "id", "id", "");
            //    inputcdata.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {


            kaPriodmake makepriod = new kaPriodmake();

            makepriod.ShowDialog();




            string connection_string = Utils.getConnectionstr();
            //    string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    tbl_karegion

            //    var typeff = typeof(tbl_Kapriod);
            //     VInputchange inputcdata = new VInputchange("", "LIST PRIOD", db, "tbl_Kapriod", "tbl_Kapriod", typeff, typeff, "id", "id", "");
            // inputcdata.Show();




        }

        private void button16_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //       var typeff = typeof(tbl_kacontractsdatadetail);

            //      VInputchange inputcdata = new VInputchange("", "LIST DATA CONTRACTS DETAIL ", dc, "tbl_kacontractsdatadetail", "tbl_kacontractsdatadetail", typeff, typeff, "id", "id", "");
            //    inputcdata.Show();


            //#region


            //Contract ctract = new Contract();
            //DialogResult kq1 = MessageBox.Show("Delete all begin contract detail ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            ////      bool kq;
            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tbl_kacontractbegindatadetail);
            //switch (kq1)
            //{

            //    case DialogResult.None:
            //        break;
            //    case DialogResult.Yes:
            //        DialogResult kq2 = MessageBox.Show("YEs là xóa dữ liệu begin Contract, bạn định xóa ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (kq2 == DialogResult.Yes)
            //        {
            //            Contract Rm = new Contract();
            //            bool kq = Rm.deleteallcontractbegindetail();


            //        }




            //        ctract.inputcontractdetail();

            //        //VInputchange inputcdata = new VInputchange("", "LIST DATA CONTRACTS DETAIL ", dc, "tbl_kacontractmasterdatadetail", "tbl_kacontractmasterdatadetail", typeff, typeff, "id", "id", "");
            //        //inputcdata.Show();

            //        var rscustemp2 = from tbl_kacontractmasterdatadetail in dc.tbl_kacontractbegindatadetails


            //                         select tbl_kacontractmasterdatadetail;
            //        Viewtable viewtbl = new Viewtable(rscustemp2, dc, "LIST DATA CONTRACTS DETAIL", 3);// view code 1 la can viet them lenh

            //        viewtbl.Show();



            //        break;
            //    case DialogResult.Cancel:
            //        break;
            //    case DialogResult.Abort:
            //        break;
            //    case DialogResult.Retry:
            //        break;
            //    case DialogResult.Ignore:
            //        break;
            //    case DialogResult.OK:
            //        break;
            //    case DialogResult.No:
            //        ctract.inputcontractdetail();

            //        rscustemp2 = from tbl_kacontractmasterdatadetail in dc.tbl_kacontractbegindatadetails
            //                     select tbl_kacontractmasterdatadetail;

            //        viewtbl = new Viewtable(rscustemp2, dc, "LIST DATA CONTRACTS DETAIL", 3);// view code 1 la can viet them lenh

            //        viewtbl.Show();

            //        break;
            //    default:
            //        break;
            //}


            //#endregion



        }

        //private void button17_Click(object sender, EventArgs e)
        //{
        //    string connection_string = Utils.getConnectionstr();
        //    //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
        //    //   LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    SqlConnection conn2 = null;
        //    SqlDataReader rdr1 = null;
        //    try
        //    {

        //        conn2 = new SqlConnection(connection_string);
        //        conn2.Open();
        //        SqlCommand cmd1 = new SqlCommand("KaFillfullnameofmasterContractbyCustomerName", conn2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        //      cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;
        //        cmd1.CommandTimeout = 0;
        //        rdr1 = cmd1.ExecuteReader();

        //        MessageBox.Show("Fill name done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    finally
        //    {
        //        if (conn2 != null)
        //        {
        //            conn2.Close();
        //        }
        //        if (rdr1 != null)
        //        {
        //            rdr1.Close();
        //        }
        //    }
        //}


        public void converttonew()
        {


            //     Control.Control_ac.DeleteALLConvertContract();
            //    Control.Control_ac.ConvertALLBeginMasterCont();

        }
        private void button18_Click(object sender, EventArgs e)
        {


            //Thread t1 = new Thread(converttonew);
            //t1.IsBackground = true;
            //t1.Start();

            //Thread t2 = new Thread(Control.Control_ac.showwait);
            //t2.Start();
            //t1.Join();
            //if (t1.ThreadState != ThreadState.Running)
            //{


            //    Thread.Sleep(1999);
            //    t2.Abort();


            //}





        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            // tbl_kaPrcingreportsTem
            //   var typeff = typeof(tbl_KAlistpricefunction);
            //      VInputchange inputcdata = new VInputchange("", "LIST CONDITION TYPE TO CONVER FUCTION AND PROMOTION ", dc, "tbl_KAlistpricefunction", "tbl_KAlistpricefunction", typeff, typeff, "id", "id", "");
            //   inputcdata.Show();




        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            View.SetCustGroup cusgrp = new SetCustGroup();
            cusgrp.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //     var rscustemp2 = from tbl_kacontractdata in dc.tbl_kacontractdatas
            //     where tbl_kacontractdata.Consts == "ALV"


            //                       select tbl_kacontractdata;
            //       Viewtable viewtbl = new Viewtable(rscustemp2, dc, "List All Contract Master ", 3);// view code 1 la can viet them lenh

            //     viewtbl.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //     var rscustemp2 = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
            //      where tbl_kacontractsdatadetail.Constatus == "ALV"

            //                     select tbl_kacontractsdatadetail;
            //     Viewtable viewtbl = new Viewtable(rscustemp2, dc, "List All Contract Detail", 3);// view code 1 la can viet them lenh

            //        viewtbl.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //  var rscustemp2 = from tbl_kacontractbegindata in dc.tbl_kacontractbegindatas


            //                   select tbl_kacontractbegindata;
            //     Viewtable viewtbl = new Viewtable(rscustemp2, dc, "List Begin Master Contract", 3);// view code 1 la can viet them lenh

            //  viewtbl.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //       var rscustemp2 = from tbl_kacontractbegindatadetail in dc.tbl_kacontractbegindatadetails


            //                 select tbl_kacontractbegindatadetail;
            //         Viewtable viewtbl = new Viewtable(rscustemp2, dc, "List Detail Master Contract ", 3);// view code 1 la can viet them lenh

            //        viewtbl.Show();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    tbl_karegion

            //      var typeff = typeof(Tka_RegionRight);
            //     VInputchange inputcdata = new VInputchange("", "LIST EDIT REGION VIEW RIGHT", db, "Tka_RegionRight", "Tka_RegionRight", typeff, typeff, "id", "id", "");
            //          inputcdata.Show();
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    tbl_karegion

            //        var typeff = typeof(Tka_RightContracttypeview);
            //      VInputchange inputcdata = new VInputchange("", "LIST CONTRACT TYPE VIEW RIGHT", db, "Tka_RightContracttypeview", "Tka_RightContracttypeview", typeff, typeff, "id", "id", "");
            //          inputcdata.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            //  Main.clearpannel();

            main1.clearpannel();


            View.BeePhieuThu accsup = new BeePhieuThu(main1);
            main1.clearpannelload(accsup);
            //    accsup.TopLevel = false;
            //  accsup.AutoScroll = true;
            //    panelmain.Controls.Add(accsup);
            //    accsup.Show();


        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            //  Main.clearpannel();

            main1.clearpannel();


            View.BeePhieuchi accsup = new BeePhieuchi(main1);
            main1.clearpannelload(accsup);
            //    accsup.TopLevel = false;
            //  accsup.AutoScroll = true;
            //    panelmain.Controls.Add(accsup);
            //    accsup.Show();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            #region  chọn sổ quỹ chi tiết


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Chọn tài khoản")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {



                View.Beeselecttk Beeselecttk = new View.Beeselecttk("tienmat");
                Beeselecttk.ShowDialog();

                chon = Beeselecttk.chon;
                DateTime fromdate = Beeselecttk.fromdate;
                DateTime todate = Beeselecttk.todate;

                string mataikhoan = Beeselecttk.mataikhoan;
                string tentaikhoan = Beeselecttk.tentaikhoan;
                int machitiettaikhoan = Beeselecttk.machitiettaikhoan;
                string tentaikhoanchitiet = Beeselecttk.tentaikhoanchitiet;


                if (chon)
                {

                    #region showreport
                    // xoa data cũ
                    string username = Utils.getusername();

                    var listRptdetailSoQuy = from RptdetailSoQuy in dc.RptdetailSoQuys
                                             where RptdetailSoQuy.username == username
                                             select RptdetailSoQuy;

                    dc.RptdetailSoQuys.DeleteAllOnSubmit(listRptdetailSoQuy);
                    dc.SubmitChanges();


                    var listRPtsoQuy = from RPtsoQuy in dc.RPtsoQuys
                                       where RPtsoQuy.username == username
                                       select RPtsoQuy;

                    dc.RPtsoQuys.DeleteAllOnSubmit(listRPtsoQuy);
                    dc.SubmitChanges();

                    RptdetailSoQuy detailSoquy = new RptdetailSoQuy();
                    // update data mới   RPtsoQuy


                    RPtsoQuy headSoquy = new RPtsoQuy();


                    headSoquy.taikhoan = tentaikhoan.Trim(); //mataikhoan.Trim() + "-" + 
                    headSoquy.loaiquy = tentaikhoanchitiet;
                    headSoquy.tencongty = Model.Congty.getnamecongty();
                    headSoquy.username = username;
                    headSoquy.diachicongty = Model.Congty.getdiachicongty();
                    headSoquy.masothue = Model.Congty.getmasothuecongty();
                    headSoquy.tungay = fromdate;
                    headSoquy.denngay = todate;

                    if (machitiettaikhoan != 0)
                    {

                        headSoquy.codauky = (from tbl_SoQuy in dc.tbl_SoQuys
                                             where tbl_SoQuy.Ngayctu < fromdate
                                             && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                             && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                             select tbl_SoQuy.PsCo).Sum().GetValueOrDefault(0) + (from tbl_machitiettk in dc.tbl_machitiettks
                                                                                                  where tbl_machitiettk.machitiet == machitiettaikhoan
                                                                                                  && tbl_machitiettk.matk == mataikhoan
                                                                                                  select tbl_machitiettk.codk).FirstOrDefault();

                        headSoquy.nodauky = (from tbl_SoQuy in dc.tbl_SoQuys
                                             where tbl_SoQuy.Ngayctu < fromdate
                                                  && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                      && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                             select tbl_SoQuy.PsNo).Sum().GetValueOrDefault(0) + (from tbl_machitiettk in dc.tbl_machitiettks
                                                                                                  where tbl_machitiettk.machitiet == machitiettaikhoan
                                                                                                  && tbl_machitiettk.matk == mataikhoan
                                                                                                  select tbl_machitiettk.nodk).FirstOrDefault();

                    }
                    else
                    {

                        headSoquy.codauky = (from tbl_SoQuy in dc.tbl_SoQuys
                                             where tbl_SoQuy.Ngayctu < fromdate
                                             && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                             && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                             select tbl_SoQuy.PsCo).Sum().GetValueOrDefault(0) + (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                                                                                                  where tbl_dstaikhoan.matk == mataikhoan
                                                                                                  select tbl_dstaikhoan.codk).FirstOrDefault();

                        headSoquy.nodauky = (from tbl_SoQuy in dc.tbl_SoQuys
                                             where tbl_SoQuy.Ngayctu < fromdate
                                                  && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                      && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                             select tbl_SoQuy.PsNo).Sum().GetValueOrDefault(0) + (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                                                                                                  where tbl_dstaikhoan.matk == mataikhoan
                                                                                                  select tbl_dstaikhoan.nodk).FirstOrDefault();



                    }






                    headSoquy.psco = (from tbl_SoQuy in dc.tbl_SoQuys
                                      where tbl_SoQuy.Ngayctu >= fromdate && tbl_SoQuy.Ngayctu <= todate
                                           && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                         && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                      select tbl_SoQuy.PsCo).Sum().GetValueOrDefault(0);

                    headSoquy.psno = (from tbl_SoQuy in dc.tbl_SoQuys
                                      where tbl_SoQuy.Ngayctu >= fromdate && tbl_SoQuy.Ngayctu <= todate
                                           && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                         && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                      select tbl_SoQuy.PsNo).Sum().GetValueOrDefault(0);


                    headSoquy.nocuoiky = headSoquy.nodauky + headSoquy.psno;

                    headSoquy.cocuoiky = headSoquy.codauky + headSoquy.psco;


                    double daukysave = (double)headSoquy.nodauky - (double)headSoquy.codauky;



                    dc.RPtsoQuys.InsertOnSubmit(headSoquy);
                    dc.SubmitChanges();



                    var headerquy = from RPtsoQuy in dc.RPtsoQuys
                                    where RPtsoQuy.username == username
                                    select RPtsoQuy;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, headerquy);

                    //-----------------------



                    //  RptdetailSoQuy
                    //        RptdetailSoQuy q = new RptdetailSoQuy();
                    //   machitiettaikhoan

                    //       MessageBox.Show(machitiettaikhoan.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    var detairpt = from tbl_SoQuy in dc.tbl_SoQuys
                                   where tbl_SoQuy.Ngayctu >= fromdate && tbl_SoQuy.Ngayctu <= todate
                                        && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                         && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                   orderby tbl_SoQuy.Ngayctu
                                   select tbl_SoQuy;

                    foreach (var item in detairpt)
                    {
                        RptdetailSoQuy q = new RptdetailSoQuy();
                        q.diengiai = item.Diengiai;

                        if (item.Machungtu == "PC")
                        {
                            q.machungtuchi = item.Machungtu + " " + item.Sochungtu.ToString().Trim();
                            q.machungtuthu = "";
                        }
                        else
                        {
                            q.machungtuthu = item.Machungtu + " " + item.Sochungtu.ToString().Trim();
                            q.machungtuchi = "";
                        }

                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;
                        q.psco = item.PsCo;
                        q.psno = item.PsNo;
                        q.taikhoandoiung = item.TKdoiung;
                        q.ton = daukysave + item.PsNo - item.PsCo;
                        daukysave = daukysave + (double)item.PsNo - (double)item.PsCo;

                        dc.RptdetailSoQuys.InsertOnSubmit(q);
                        dc.SubmitChanges();


                    }
                    //   let ton1 = daukysave + tbl_SoQuy.PsNo - tbl_SoQuy.PsCo
                    //   where tbl_SoQuy.Ngayctu >= fromdate && tbl_SoQuy.Ngayctu <= todate
                    //select new
                    //{
                    // diengiai = tbl_SoQuy,

                    //username = urs,


                    //machungtuchi = tbl_SoQuy.Machungtu == "PC"
                    //? tbl_SoQuy.Machungtu + " " + tbl_SoQuy.Sochungtu.ToString().Trim()
                    //: "",

                    //machungtuthu = tbl_SoQuy.Machungtu == "PT"
                    //? tbl_SoQuy.Machungtu + " " + tbl_SoQuy.Sochungtu.ToString().Trim()
                    //: "",



                    //machungtuchi = tbl_SoQuy.Machungtu + " " + tbl_SoQuy.Sochungtu.ToString().Trim(),
                    //machungtuthu = tbl_SoQuy.Machungtu + " " + tbl_SoQuy.Sochungtu.ToString().Trim(),




                    //    Ngaychungtu = tbl_SoQuy.Ngayctu,
                    //   psco = tbl_SoQuy.PsCo,
                    //  psno = tbl_SoQuy.PsNo,

                    ////  daukysave = daukysave + tbl_SoQuy.PsNo - tbl_SoQuy.PsCo,

                    //  taikhoandoiung = tbl_SoQuy.TKdoiung,






                    //           };

                    //   daukysave
                    //foreach (var item in detairpt)
                    //{

                    //    daukysave = daukysave + (double)item.ton;
                    //    item.ton = daukysave;

                    //}
                    //var rsphieuchi = from RptdetailSoQuy in dc.RptdetailSoQuys
                    //                 where RptdetailSoQuy.username == urs
                    //                 select RptdetailSoQuy;

                    var rptdetail = from RptdetailSoQuy in dc.RptdetailSoQuys
                                    where RptdetailSoQuy.username == username
                                    orderby RptdetailSoQuy.Ngaychungtu

                                    select RptdetailSoQuy;

                    var dataset2 = ut.ToDataTable(dc, rptdetail);







                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Soquy.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports

                }


            }





            #endregion





        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            #region  chọn sổ cái


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            bool kq = false;
            foreach (Form frm in fc)
            {
                ///  KAcontractlisting
                ///    if (frm.Text == "CreatenewContract")
                if (frm.Text == "Chọn tài khoản")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {



                View.BeeselecSocai BeeselecSocai = new View.BeeselecSocai("socai");
                BeeselecSocai.ShowDialog();

                chon = BeeselecSocai.chon;
                DateTime fromdate = BeeselecSocai.fromdate;
                DateTime todate = BeeselecSocai.todate;

                string mataikhoan = BeeselecSocai.mataikhoan;
                string tentaikhoan = BeeselecSocai.tentaikhoan;
                //   int machitiettaikhoan = Beeselecttk.machitiettaikhoan;
                //    string tentaikhoanchitiet = Beeselecttk.tentaikhoanchitiet;


                if (chon)
                {

                    #region showreport
                    // xoa data cũ
                    string username = Utils.getusername();

                    var listRptdetailSocai = from RptdetailSocai in dc.RptdetailSoCais
                                             where RptdetailSocai.username == username
                                             select RptdetailSocai;

                    dc.RptdetailSoCais.DeleteAllOnSubmit(listRptdetailSocai);
                    dc.SubmitChanges();


                    var listRPtsocai = from RPtsocai in dc.RPtheadSocais
                                       where RPtsocai.username == username
                                       select RPtsocai;

                    dc.RPtheadSocais.DeleteAllOnSubmit(listRPtsocai);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadSocai headSocai = new RPtheadSocai();


                    headSocai.taikhoan = tentaikhoan.Trim(); //mataikhoan.Trim() + "-" + 
                    headSocai.tencongty = Model.Congty.getnamecongty();
                    headSocai.username = username;
                    headSocai.diachicongty = Model.Congty.getdiachicongty();
                    headSocai.masothue = Model.Congty.getmasothuecongty();
                    headSocai.tungay = fromdate;
                    headSocai.denngay = todate;



                    headSocai.codauky = (from tbl_Socai in dc.tbl_Socais
                                         where tbl_Socai.Ngayctu < fromdate
                                         && tbl_Socai.TkCo.Trim() == mataikhoan
                                         select tbl_Socai.PsCo).Sum().GetValueOrDefault(0) + (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                                                                                              where tbl_dstaikhoan.matk == mataikhoan
                                                                                              select tbl_dstaikhoan.codk).FirstOrDefault();

                    headSocai.nodauky = (from tbl_Socai in dc.tbl_Socais
                                         where tbl_Socai.Ngayctu < fromdate
                                              && tbl_Socai.TkNo.Trim() == mataikhoan
                                         //  && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                         select tbl_Socai.PsNo).Sum().GetValueOrDefault(0) + (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                                                                                              where tbl_dstaikhoan.matk == mataikhoan
                                                                                              select tbl_dstaikhoan.nodk).FirstOrDefault();







                    headSocai.psco = (from tbl_Socai in dc.tbl_Socais
                                      where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkCo.Trim() == mataikhoan
                                      //   && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                      select tbl_Socai.PsCo).Sum().GetValueOrDefault(0);

                    headSocai.psno = (from tbl_Socai in dc.tbl_Socais
                                      where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkNo.Trim() == mataikhoan
                                      //    && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                      select tbl_Socai.PsNo).Sum().GetValueOrDefault(0);


                    headSocai.nocuoiky = headSocai.nodauky + headSocai.psno;

                    headSocai.cocuoiky = headSocai.codauky + headSocai.psco;


                    double daukysave = (double)headSocai.nodauky - (double)headSocai.codauky;



                    dc.RPtheadSocais.InsertOnSubmit(headSocai);
                    dc.SubmitChanges();



                    var headerquy = from tbl_Socai in dc.RPtheadSocais
                                    where tbl_Socai.username == username
                                    select tbl_Socai;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, headerquy);

                    //-----------------------



                    //  RptdetailSoQuy
                    //        RptdetailSoQuy q = new RptdetailSoQuy();
                    //   machitiettaikhoan

                    //       MessageBox.Show(machitiettaikhoan.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    var detairpt = from tbl_Socai in dc.tbl_Socais
                                   where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                        && tbl_Socai.TkCo.Trim() == mataikhoan
                                   orderby tbl_Socai.Ngayctu
                                   select tbl_Socai;

                    foreach (var item in detairpt)
                    {
                        RptdetailSoCai q = new RptdetailSoCai();
                        if (item.Diengiai != "")
                        {
                            q.diengiai = item.Diengiai.Trim();
                        }

                        q.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;


                        q.taikhoandoiung = item.TkNo.Trim();
                        q.psno = 0;
                        q.psco = item.PsCo;


                        //       q.ton = daukysave + item.PSNo - item.PSCo;
                        //        daukysave = daukysave + (double)item.PSNo - (double)item.PSCo;

                        dc.RptdetailSoCais.InsertOnSubmit(q);
                        dc.SubmitChanges();


                    }

                    var detairptno = from tbl_Socai in dc.tbl_Socais
                                     where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                          && tbl_Socai.TkNo.Trim() == mataikhoan
                                     orderby tbl_Socai.Ngayctu
                                     select tbl_Socai;

                    foreach (var item in detairptno)
                    {
                        RptdetailSoCai q = new RptdetailSoCai();
                        if (item.Diengiai != "")
                        {
                            q.diengiai = item.Diengiai.Trim();
                        }

                        q.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;


                        q.taikhoandoiung = item.TkCo.Trim();
                        q.psno = item.PsNo;
                        q.psco = 0;


                        //       q.ton = daukysave + item.PSNo - item.PSCo;
                        //        daukysave = daukysave + (double)item.PSNo - (double)item.PSCo;

                        dc.RptdetailSoCais.InsertOnSubmit(q);
                        dc.SubmitChanges();


                    }






                    var rptdetail = from RptdetailSocai in dc.RptdetailSoCais
                                    where RptdetailSocai.username == username
                                    orderby RptdetailSocai.Ngaychungtu

                                    select RptdetailSocai;


                    foreach (var item in rptdetail)
                    {

                        item.ton = daukysave + item.psno - item.psco;
                        daukysave = daukysave + (double)item.psno - (double)item.psco;

                    }

                    var dataset2 = ut.ToDataTable(dc, rptdetail);







                    Reportsview rpt = new Reportsview(dataset1, dataset2, "SoCai.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports

                }


            }





            #endregion



        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            #region  chọn sổ quỹ chi tiết


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Chọn tài khoản")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {



                View.Beeselecttk Beeselecttk = new View.Beeselecttk("chitiet");
                Beeselecttk.ShowDialog();

                chon = Beeselecttk.chon;
                DateTime fromdate = Beeselecttk.fromdate;
                DateTime todate = Beeselecttk.todate;

                string mataikhoan = Beeselecttk.mataikhoan;
                string tentaikhoan = Beeselecttk.tentaikhoan;
                int machitiettaikhoan = Beeselecttk.machitiettaikhoan;
                string tentaikhoanchitiet = Beeselecttk.tentaikhoanchitiet;


                if (chon)
                {
                    #region showreport
                    // xoa data cũ
                    string username = Utils.getusername();

                    var listRptdetailSocaichitiet = from p in dc.RptdetailSocaichitiets
                                                    where p.username == username
                                                    select p;

                    dc.RptdetailSocaichitiets.DeleteAllOnSubmit(listRptdetailSocaichitiet);
                    dc.SubmitChanges();


                    var listRPtheadsocaichitiet = from p in dc.RPtheadSocaichitiets
                                                  where p.username == username
                                                  select p;

                    dc.RPtheadSocaichitiets.DeleteAllOnSubmit(listRPtheadsocaichitiet);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadSocaichitiet headSocai = new RPtheadSocaichitiet();


                    headSocai.taikhoan = tentaikhoan.Trim(); //mataikhoan.Trim() + "-" + 
                    headSocai.tencongty = Model.Congty.getnamecongty();
                    headSocai.username = username;
                    headSocai.diachicongty = Model.Congty.getdiachicongty();
                    headSocai.masothue = Model.Congty.getmasothuecongty();
                    headSocai.tungay = fromdate;
                    headSocai.denngay = todate;
                    headSocai.tenchitiettk = tentaikhoanchitiet;


                    headSocai.codauky = (from tbl_Socai in dc.tbl_Socais
                                         where tbl_Socai.Ngayctu < fromdate
                                         && tbl_Socai.TkCo.Trim() == mataikhoan
                                         && tbl_Socai.MaCTietTKCo == machitiettaikhoan
                                         select tbl_Socai.PsCo).Sum().GetValueOrDefault(0) + (from p in dc.tbl_machitiettks
                                                                                              where p.matk == mataikhoan
                                                                                              && p.machitiet == machitiettaikhoan
                                                                                              select p.codk).FirstOrDefault().GetValueOrDefault(0);

                    headSocai.nodauky = (from tbl_Socai in dc.tbl_Socais
                                         where tbl_Socai.Ngayctu < fromdate
                                              && tbl_Socai.TkNo.Trim() == mataikhoan
                                          && tbl_Socai.MaCTietTKNo == machitiettaikhoan
                                         select tbl_Socai.PsNo).Sum().GetValueOrDefault(0) + (from p in dc.tbl_machitiettks
                                                                                              where p.matk == mataikhoan
                                                                                              && p.machitiet == machitiettaikhoan
                                                                                              select p.nodk).FirstOrDefault().GetValueOrDefault(0);






                    headSocai.psco = (from tbl_Socai in dc.tbl_Socais
                                      where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkCo.Trim() == mataikhoan
                                          && tbl_Socai.MaCTietTKCo == machitiettaikhoan
                                      select tbl_Socai.PsCo).Sum().GetValueOrDefault(0);

                    headSocai.psno = (from tbl_Socai in dc.tbl_Socais
                                      where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkNo.Trim() == mataikhoan
                                       && tbl_Socai.MaCTietTKNo == machitiettaikhoan
                                      select tbl_Socai.PsNo).Sum().GetValueOrDefault(0);


                    headSocai.nocuoiky = headSocai.nodauky.GetValueOrDefault(0) + headSocai.psno;

                    headSocai.cocuoiky = headSocai.codauky.GetValueOrDefault(0) + headSocai.psco;


                    double daukysave = (double)headSocai.nodauky - (double)headSocai.codauky;



                    dc.RPtheadSocaichitiets.InsertOnSubmit(headSocai);
                    dc.SubmitChanges();



                    var header = from tbl_Socai in dc.RPtheadSocaichitiets
                                 where tbl_Socai.username == username
                                 select tbl_Socai;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, header);



                    var detairpt = from tbl_Socai in dc.tbl_Socais
                                   where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                        && tbl_Socai.TkCo.Trim() == mataikhoan
                                                && tbl_Socai.MaCTietTKCo == machitiettaikhoan
                                   orderby tbl_Socai.Ngayctu
                                   select tbl_Socai;

                    foreach (var item in detairpt)
                    {
                        RptdetailSocaichitiet q = new RptdetailSocaichitiet();
                        if (item.Diengiai != "")
                        {
                            q.diengiai = item.Diengiai.Trim();
                        }

                        q.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;


                        q.taikhoandoiung = item.TkNo.Trim();
                        q.psno = 0;
                        q.psco = item.PsCo;


                        //       q.ton = daukysave + item.PSNo - item.PSCo;
                        //        daukysave = daukysave + (double)item.PSNo - (double)item.PSCo;

                        dc.RptdetailSocaichitiets.InsertOnSubmit(q);
                        dc.SubmitChanges();


                    }

                    var detairptno = from tbl_Socai in dc.tbl_Socais
                                     where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                          && tbl_Socai.TkNo.Trim() == mataikhoan
                                                  && tbl_Socai.MaCTietTKNo == machitiettaikhoan
                                     orderby tbl_Socai.Ngayctu
                                     select tbl_Socai;

                    foreach (var item in detairptno)
                    {
                        RptdetailSocaichitiet q = new RptdetailSocaichitiet();
                        if (item.Diengiai != "")
                        {
                            q.diengiai = item.Diengiai.Trim();
                        }

                        q.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;


                        q.taikhoandoiung = item.TkCo.Trim();
                        q.psno = item.PsNo;
                        q.psco = 0;


                        //       q.ton = daukysave + item.PSNo - item.PSCo;
                        //        daukysave = daukysave + (double)item.PSNo - (double)item.PSCo;

                        dc.RptdetailSocaichitiets.InsertOnSubmit(q);
                        dc.SubmitChanges();


                    }






                    var rptdetail = from p in dc.RptdetailSocaichitiets
                                    where p.username == username
                                    orderby p.Ngaychungtu

                                    select p;


                    foreach (var item in rptdetail)
                    {

                        item.ton = daukysave + item.psno - item.psco;
                        daukysave = daukysave + (double)item.psno - (double)item.psco;

                    }

                    var dataset2 = ut.ToDataTable(dc, rptdetail);







                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Sochitetsocai.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports




                }


            }





            #endregion



        }

        private void button16_Click_2(object sender, EventArgs e)
        {
            //  Beeyearsellect
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            string yearchon;
            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Chọn năm")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {



                View.Beeyearsellect Beeyearsellect = new View.Beeyearsellect();
                Beeyearsellect.ShowDialog();

                yearchon = Beeyearsellect.year;
                chon = Beeyearsellect.chon;


                if (chon)
                {



                    #region showreport
                    // xoa data cũ
                    string username = Utils.getusername();

                    var detailrptNKc = from P in dc.RptdetaiNKCs
                                       where P.username == username
                                       select P;

                    dc.RptdetaiNKCs.DeleteAllOnSubmit(detailrptNKc);
                    dc.SubmitChanges();


                    var headrptnkc = from p in dc.RPtheadNKCs
                                     where p.username == username
                                     select p;

                    dc.RPtheadNKCs.DeleteAllOnSubmit(headrptnkc);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadNKC HeadHKC = new RPtheadNKC();


                    HeadHKC.nam = yearchon;
                    HeadHKC.tencongty = Model.Congty.getnamecongty();
                    HeadHKC.username = username;
                    HeadHKC.diachicongty = Model.Congty.getdiachicongty();
                    HeadHKC.masothue = Model.Congty.getmasothuecongty();
                    //      pt.tencongty = Model.Congty.getnamecongty();
                    //    pt.diachicongty = Model.Congty.getdiachicongty();
                    //  pt.masothue = Model.Congty.getmasothuecongty();
                    HeadHKC.giamdoc = Model.Congty.gettengiamdoccongty();
                    HeadHKC.ketoantruong = Model.Congty.gettenketoantruongcongty();
                    HeadHKC.nguoighiso = Utils.getname();





                    dc.RPtheadNKCs.InsertOnSubmit(HeadHKC);
                    dc.SubmitChanges();



                    var headNKC = from p in dc.RPtheadNKCs
                                  where p.username == username
                                  select p;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, headNKC);

                    //-----------------------




                    var detairpt = from tbl_Socai in dc.tbl_Socais
                                   where tbl_Socai.Ngayctu.Value.Year.ToString().Trim() == yearchon.Trim()
                                   orderby tbl_Socai.Ngayctu
                                   select tbl_Socai;

                    foreach (var item in detairpt)
                    {
                        RptdetaiNKC q = new RptdetaiNKC();
                        if (item.Diengiai != "")
                        {
                            q.diengiai = item.Diengiai.Trim();
                        }

                        q.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;


                        q.taikhoandoiung = item.TkNo.Trim();
                        q.psno = item.PsNo;
                        q.psco = 0;


                        //       q.ton = daukysave + item.PSNo - item.PSCo;
                        //        daukysave = daukysave + (double)item.PSNo - (double)item.PSCo;

                        dc.RptdetaiNKCs.InsertOnSubmit(q);
                        dc.SubmitChanges();

                        RptdetaiNKC q2 = new RptdetaiNKC();


                        //         RptdetaiNKC q = new RptdetaiNKC();
                        if (item.Diengiai != "")
                        {
                            q2.diengiai = item.Diengiai.Trim();
                        }

                        q2.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q2.username = username;
                        q2.Ngaychungtu = item.Ngayctu;


                        q2.taikhoandoiung = item.TkCo.Trim();
                        q2.psno = 0;
                        q2.psco = item.PsCo;


                        dc.RptdetaiNKCs.InsertOnSubmit(q2);
                        dc.SubmitChanges();





                    }






                    var rptdetail = from p in dc.RptdetaiNKCs
                                    where p.username == username
                                    orderby p.Ngaychungtu

                                    select p;



                    var dataset2 = ut.ToDataTable(dc, rptdetail);



                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Sonhatkychung.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports








                }





            }



        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            #region  chọn sổ quỹ chi tiết


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Chọn tài khoản")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {


                View.BeeselecSocai BeeselecSocai = new View.BeeselecSocai("chitiet");
                BeeselecSocai.ShowDialog();

                chon = BeeselecSocai.chon;
                DateTime fromdate = BeeselecSocai.fromdate;
                DateTime todate = BeeselecSocai.todate;

                string mataikhoan = BeeselecSocai.mataikhoan;
                string tentaikhoan = BeeselecSocai.tentaikhoan;



                if (chon)
                {
                    #region showreport
                    // xoa data cũ
                    //    string username = Utils.getusername();

                    var listRptthchitiet = from p in dc.RptdetaiTHchitiets
                                           where p.username == username
                                           select p;

                    dc.RptdetaiTHchitiets.DeleteAllOnSubmit(listRptthchitiet);
                    dc.SubmitChanges();


                    var listrptheadchitiet = from p in dc.RPtheadTHchitiets
                                             where p.username == username
                                             select p;

                    dc.RPtheadTHchitiets.DeleteAllOnSubmit(listrptheadchitiet);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadTHchitiet headTHchitiet = new RPtheadTHchitiet();


                    headTHchitiet.taikhoan = tentaikhoan.Trim(); //mataikhoan.Trim() + "-" + 
                    headTHchitiet.tencongty = Model.Congty.getnamecongty();
                    headTHchitiet.username = username;
                    headTHchitiet.diachicongty = Model.Congty.getdiachicongty();
                    headTHchitiet.masothue = Model.Congty.getmasothuecongty();
                    headTHchitiet.tungay = fromdate;
                    headTHchitiet.denngay = todate;



                    dc.RPtheadTHchitiets.InsertOnSubmit(headTHchitiet);
                    dc.SubmitChanges();



                    var header = from p in dc.RPtheadTHchitiets
                                 where p.username == username
                                 select p;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, header);

                    var machitiet = from p in dc.tbl_machitiettks
                                    where p.matk == mataikhoan
                                    select p;

                    if (machitiet.Count() > 0)
                    {
                        foreach (var item in machitiet)
                        {





                        }


                    }




                    var rptdetail = from p in dc.RptdetaiTHchitiets
                                    where p.username == username
                                    orderby p.stt

                                    select p;



                    var dataset2 = ut.ToDataTable(dc, rptdetail);



                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Sotonghopchitiet.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports




                }


            }





            #endregion

        }
    }
}

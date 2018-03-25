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
            treeView1.Visible = false;
            panel1.Visible = false;

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


            //        ctract.phanquyen();




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



            //        ctract.phanquyen();


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
            //SetGroupFrom prdgroup = new SetGroupFrom("PRODUCT GROUP MEMBER");

            //prdgroup.ShowDialog();






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


            Beekyketoan makepriod = new Beekyketoan();

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
            //View.SetCustGroup cusgrp = new SetCustGroup();
            //cusgrp.Show();
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



        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Model.Soketoan.soQuy();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Model.Soketoan.socaitaikhoan();


        }

        private void button4_Click_2(object sender, EventArgs e)
        {



        }

        private void button16_Click_2(object sender, EventArgs e)
        {




        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            //Model.Soketoan.sotonghoptaikhoanchitiet();

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {


        }

        private void btsanhsachkhohang_Click(object sender, EventArgs e)
        {

        }

        private void btdanhsachnhomsanpham_Click(object sender, EventArgs e)
        {






        }

        private void btdanhsachsanpham_Click(object sender, EventArgs e)
        {



















        }

        private void button42_Click(object sender, EventArgs e)
        {



        }

        private void button53_Click(object sender, EventArgs e)
        {



        }

        private void button54_Click(object sender, EventArgs e)
        {

        }

        private void button52_Click(object sender, EventArgs e)
        {

        }

        private void button51_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //var rs1 = from dschitiet in dc.tbl_machitiettks
            //          select new
            //          {
            //              Mã_tài_khoản = dschitiet.matk,
            //              Tên_tài_khoản_chi_tiết = dschitiet.tenchitiet,
            //              Mã_chi_tiết = dschitiet.machitiet,
            //              ID = dschitiet.id
            //          };

            var rs1 = Model.Danhsachtkchitiet.danhsachtaikhoanchitiet(dc);

            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH MÃ CHI TIẾT TÀI KHOẢN", 2, "tk");// view code 2 mo so chi tiet tai khoan
            viewtbl.Show();

        }

        private void button41_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button56_Click(object sender, EventArgs e)
        {


        }

        private void btdanhsachnhavantai_Click(object sender, EventArgs e)
        {
            //    NPDanhsachnhavantai
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachNVT(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH NHÀ VẬN TẢI", 8, "tk");// mã 8 là danh sach nha nha van tai

            viewtbl.Show();



        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachxe(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH XE", 9, "tk");// mã 8 là danh sach nha nha van tai

            viewtbl.Show();





        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {


        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {


        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string name = e.Node.Name;
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //bangsoducd
            //     bangnhapsodulctt


           



            //     npdanhsachxe



            //dsxenp









            //            dsloaitk

            //            dstaikhoanketoan

         
            //hethongtk

            //phanquyen

          

            //btoanth


            // dsnhacungcap











        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachkhachhangvantai(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH KHÁCH HÀNG VẬN TẢI", 10, "tk");// mã 8 là danh sach nha nha van tai

            viewtbl.Show();

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
         

        }

        private void button4_Click_3(object sender, EventArgs e)
        {

            #region//bcsonhatkychung
            //if (name == "bcsonhatkychung")
            //{

            Model.Soketoan.baocaokqkd();

            //  }
            #endregion

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            Model.Soketoan.xemvaupdatekqkd200();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {

            #region//bccan doi ke toan
            //if (name == "bcsonhatkychung")
            //{

            Model.Soketoan.baocaocandoiketoantt200lientuc();

            //  }
            #endregion
        }

        private void tiềnMặtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void phiếuThuToolStripMenuItem_Click(object sender, EventArgs e)
        {




        }

        private void phiếuChiToolStripMenuItem_Click(object sender, EventArgs e)
        {





        }

        private void sổQuỹToolStripMenuItem_Click(object sender, EventArgs e)
        {






        }

        private void bútToánTổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {

           

        }

        private void sổTàiKhoảnTổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {

          
        }

        private void bảnCấnĐốiTàiKhoảnPhátSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region//bcbangcandoitaikhoan


            Model.Soketoan.bangcandoiphatsinhtaikhoan();


            #endregion

        }

        private void sổChiTiếtTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sổNhậtKýChungToolStripMenuItem_Click(object sender, EventArgs e)
        {

          
        }

        private void sổCáiTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        
        }

        private void danhSáchLoạiTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

       
        }

        private void phiếuNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private void phiếuXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {

          
        }

        private void sổKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sổQuỹToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}

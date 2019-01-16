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
    public partial class Beedieudongxe : Form
    {

        View.Main main { get; set; }



        void Control_KeyPress(object sender, KeyEventArgs e)
        {
            // if (viewcode == 2)// nuew la bàng salsetemp update

            //if ((viewcode == 2) && e.KeyCode == Keys.F3)
            //{

            if (e.KeyCode == Keys.F3)
            {
                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "Tìm kiếm")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    BeeSeachdieuvan sheaching = new BeeSeachdieuvan();
                    sheaching.Show();
                }





            }


        }



        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }


        public Beedieudongxe(Main main)
        {
            InitializeComponent();


            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);

            //     Model.Username used = new Username();
            string username = Utils.getusername();
            this.main = main;
            cbngaythang.Value = DateTime.Today;

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //  masterdatafuction
            #region  // load cbkhach hang

            var rs2 = from kh in dc.tbl_NP_khachhangvanchuyens
                      orderby kh.maKH
                      //   where kh.ma
                      select kh;


            foreach (var item in rs2)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.maKH;
                cb.Text = item.maKH + ":" + item.tenKH;
                this.cbkhachhang.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion

            #region    //cbbiensoxe
            var rs3 = from kh in dc.tbl_NP_danhsachxes
                      orderby kh.maNVT
                      //   where kh.ma
                      select kh;


            foreach (var item in rs3)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.bienso;
                cb.Text = item.bienso + ":" + item.maNVT;
                this.cbbiensoxe.Items.Add(cb); // CombomCollection.Add(cb);

            }
            #endregion cbbiensoxe


            #region   //cbloaidon




            ComboboxItem cb1 = new ComboboxItem();
            cb1.Value = 1;
            cb1.Text = 1 + ":" + "- Đơn hàng theo sản phẩm";
            this.cbloaidon.Items.Add(cb1); // CombomCollection.Add(cb);


            ComboboxItem cb2 = new ComboboxItem();
            cb2.Value = 2;
            cb2.Text = 2 + ":" + "- Đơn hàng theo chuyến";
            this.cbloaidon.Items.Add(cb2); // CombomCollection.Add(cb);


            #endregion cbloaidon

            #region    //cbnahxe
            var rs4 = from kh in dc.tbl_NP_Nhacungungvantais
                      orderby kh.maNVT
                      //   where kh.ma
                      select kh;


            foreach (var item in rs4)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.maNVT;
                cb.Text = item.maNVT + ":" + item.tenNVT;
                this.cbnhaxe.Items.Add(cb); // CombomCollection.Add(cb);

            }
            #endregion cbnahxe


            Model.dieuvan.deleteAlldonhangtmp(dc);
            Model.dieuvan.deleteAlltheoSPPricetmp(dc);
            //   Model.dieuvan.listsanphamtheoSPchuacogia(dc);




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
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //var rs1 = from loaitks in dc.tbl_loaitks
            //          select new
            //          {
            //          Mã_loại_tài_khoản =    loaitks.idloaitk,
            //          Tên_mã_loại_tài_khoản =    loaitks.name,
            //          ID = loaitks.id
            //          };

            var rs1 = Model.loaitaikhoanketoan.danhsachloaitaikhoan(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH LOẠI TÀI KHOẢN", 1, "tk");// danh sach loại tài khoản kế toán

            viewtbl.Show();


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
            //var rs1 = from dstaikhoan in dc.tbl_dstaikhoans
            //          select new
            //          {
            //              Mã_tài_khoản = dstaikhoan.matk,
            //              Tên_tài_khoản = dstaikhoan.tentk,
            //              Mã_tài_khoản_cấp_trên =dstaikhoan.matktren,
            //              Cấp_tài_khoản = dstaikhoan.captk,
            //              ID = dstaikhoan.id


            //          };

            var rs = Model.Taikhoanketoan.danhsachtaikhoan(dc);
            Viewtable viewtbl = new Viewtable(rs, dc, "DANH SÁCH TÀI KHOẢN KẾ TOÁN", 0, "tk");// view code 0 la danh sach tai khoan ke toan

            viewtbl.Show();
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

            //     string connection_string = Utils.getConnectionstr();
            //View.Main.pane.Controls.Clear();  //PosmCreateTK


            //View.Beemainload Beemainload = new View.Beemainload();

            //Beemainload.TopLevel = false;
            //Beemainload.AutoScroll = true;
            //panelmain.Controls.Add(Beemainload);
            //Beemainload.Show();



        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.main.clearpannel();
            View.Beemainload main = new Beemainload(this.main);

            this.main.clearpannelload(main);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {

            this.pictureBox2.Image = global::BEEACCOUNT.Properties.Resources.exit_2;



        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.Image = global::BEEACCOUNT.Properties.Resources.exit;
        }

        private void button7_Click_2(object sender, EventArgs e)
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

        private void button4_Click_2(object sender, EventArgs e)
        {
            View.BeeThongtindoanhnghiep doanhnghiep = new BeeThongtindoanhnghiep();
            doanhnghiep.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    NPDanhsachnhavantai
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachNVT(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH NHÀ VẬN TẢI", 8, "tk");// mã 8 là danh sach nha nha van tai

            viewtbl.Show();

            this.Close();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachxe(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH XE", 9, "tk");// mã 8 là danh sach nha nha van tai

            viewtbl.Show();
            this.Close();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachkhachhangvantai(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH KHÁCH HÀNG VẬN TẢI", 10, "tk");// mã 8 là danh sach nha nha van tai

            viewtbl.Show();
            this.Close();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Model.dieuvan dv = new dieuvan();
            dv.donhangnetcoinput();

        }

        private void cbkhachhang_SelectedValueChanged(object sender, EventArgs e)
        {
            //string connection_string = Utils.getConnectionstr();
            //string username = Utils.getusername();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //if (cbkhachhang.SelectedItem != null && cbloaidon.SelectedItem != null)
            //{
            //    #region nếu là đơn hàng theo sản phẩm




            //    if ((cbloaidon.SelectedItem as ComboboxItem).Value.ToString() == "1") // Nếu là đơn hàng theo sản phẩm
            //    {

            //        Model.dieuvan.listsanphamtheoSPchuacogia(dc);


            //        var rs = from p in dc.tbl_DonhangtheoSPvaMKHs
            //                 where p.Username == username && p.loadnumber == ""
            //                 && p.maKH == (cbkhachhang.SelectedItem as ComboboxItem).Value.ToString()
            //                 select p;

            //        foreach (var item in rs)
            //        {
            //            item.Gia_VChuyen = Model.dieuvan.getpriceHDtheosanphamvamacty(dc, item.TEN_HANG, item.City);
            //            dc.SubmitChanges();
            //        }


            //        var rs1 = Model.dieuvan.selectDonhangtheoSPPendingChuaghep(dc, (cbkhachhang.SelectedItem as ComboboxItem).Value.ToString());

            //        griddonpending.DataSource = rs1;

            //        Model.dieuvan.deleteAlldonhangtmp(dc);

            //        gripghepxe.DataSource = Model.dieuvan.selectDonhangghep(dc);


            //    }

            //    #endregion nếu là đơn hàng theo sản phẩm
            //}


        }

        private void griddonpending_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //   DataGridViewRow rowid = new DataGridViewRow
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            int idtk = 0;
            try
            {
                idtk = (int)this.griddonpending.Rows[this.griddonpending.CurrentCell.RowIndex].Cells["id"].Value;
                //    parent.rows[currentRowIndex].style.backgroundColor = "#FFFFD6";
                //  int x = griddonpending.CurrentRow.Index;

                // this.griddonpending.Rows.Remove(griddonpending.CurrentRow);

                //if ((cbkhachhang.SelectedItem as ComboboxItem).Value.ToString() == "04") //  netco
                //{
                // chuyen data thành view =0

                Model.dieuvan.updatehidedonhangtheoSPvaID(dc, idtk);
                // }
                //   this.griddonpending.Rows[currentRowIndex].
            }
            catch (Exception)
            {

                //    MessageBox.Show("Bạn phải chọn một tuyến !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //  return;
            }


            //if ((cbkhachhang.SelectedItem as ComboboxItem).Value.ToString() == "04") //  netco
            //{

            Model.dieuvan.themvaodonhangTEMPtheoSPvaID(dc, idtk);

            string maKH = (cbkhachhang.SelectedItem as ComboboxItem).Value.ToString();










        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            //this.Close();
            Model.dieuvan dv = new dieuvan();
            dv.donhangnetcoinput();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            Model.dieuvan.deleteAlldonhangtmp(dc);
        }

        private void button3_Click_4(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachxe(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH XE", 9, "tk");// mã 8 là danh sach nha nha van tai

            viewtbl.Show();
            // this.Close();
        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            //    NPDanhsachnhavantai
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachNVT(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH NHÀ VẬN TẢI", 8, "tk");// mã 8 là danh sach nha nha van tai

            viewtbl.Show();

            //    this.Close();
        }

        private void gripghepxe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idtk = 0;
            int mainid = 0;
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            try
            {
                idtk = (int)this.gripghepxe.Rows[this.gripghepxe.CurrentCell.RowIndex].Cells["id"].Value;
                mainid = (int)this.gripghepxe.Rows[this.gripghepxe.CurrentCell.RowIndex].Cells["mainid"].Value;

                this.gripghepxe.Rows.Remove(gripghepxe.CurrentRow);
                //if ((cbkhachhang.SelectedItem as ComboboxItem).Value.ToString() == "04") //  netco
                //{
                // chuyen data thành view =0

                Model.dieuvan.updateunhidedonhangtheoSanphamvaID(dc, mainid);
                //   }

                Model.dieuvan.deleteAlldonhangtmptheoID(dc, idtk);
            }
            catch (Exception)
            {

                //    MessageBox.Show("Bạn phải chọn một tuyến !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //  return;
            }




        }

        private void gripghepxe_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {




        }

        private void gripghepxe_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void cbnhaxe_SelectedValueChanged(object sender, EventArgs e)
        {

            this.cbbiensoxe.Items.Clear();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region    //cbbiensoxe
            var rs3 = from kh in dc.tbl_NP_danhsachxes
                      orderby kh.maNVT
                      where kh.maNVT == (cbnhaxe.SelectedItem as ComboboxItem).Value.ToString()
                      select kh;


            foreach (var item in rs3)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.bienso;
                cb.Text = item.bienso + " : " + item.tenlaixe;
                this.cbbiensoxe.Items.Add(cb); // CombomCollection.Add(cb);

            }
            #endregion cbbiensoxe
            if (this.cbbiensoxe.Items.Count >= 0)
            {
                this.cbbiensoxe.SelectedIndex = -1;

            }
            //this.cbbiensoxe.SelectedIndex = 0;


            //#region    //cbnahxe
            //var rs4 = from kh in dc.tbl_NP_Nhacungungvantais
            //          orderby kh.maNVT
            //          //   where kh.ma
            //          select kh;


            //foreach (var item in rs4)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.maNVT;
            //    cb.Text = item.maNVT + ":" + item.tenNVT;
            //    this.cbnhaxe.Items.Add(cb); // CombomCollection.Add(cb);

            //}
            //#endregion cbnahxe












        }

        private void cbbiensoxe_SelectedValueChanged(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rs3 = (from kh in dc.tbl_NP_danhsachxes
                       orderby kh.bienso
                       where kh.bienso == (cbbiensoxe.SelectedItem as ComboboxItem).Value.ToString()
                       select kh.maNVT).FirstOrDefault();
            if (rs3 != null)
            {
                foreach (var item in this.cbnhaxe.Items)
                {

                    if (((ComboboxItem)item).Value.ToString() == rs3)
                    {


                        this.cbnhaxe.SelectedItem = item;

                    }



                }
            }











        }

        private void button1_Click_2(object sender, EventArgs e)
        {




        }

        private void button5_Click_1(object sender, EventArgs e)
        {
        






        }

        private void button6_Click_2(object sender, EventArgs e)
        {

          



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {







        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {




            }

        }

        private void button2_Click_2(object sender, EventArgs e)
        {


        }
    }
}
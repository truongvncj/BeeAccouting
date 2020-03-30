using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using BEEACCOUNT.Model;
using BEEACCOUNT.Control;
//using BEEACCOUNT.Entity;

using System.Threading;
using System.Data.SqlClient;
//using System.Collections.Generic;
//using System.Linq;

namespace BEEACCOUNT.View
{
    public partial class Main : Form
    {

        // public 
        //   private string rptname;
        //    private IQueryable rs1;
        //      private IQueryable rs2;
        //
        public void messagetext(string message, Color colornen)
        {
            messageinfor.Text = message;
            messageinfor.BackColor = colornen;

        }

        public void clearpannel()
        {


            panelmain.Controls.Clear();


        }

        public void clearpannelload(Form Formload)
        {


            //   View.Beemainload accsup = new Beemainload(this);

            Formload.TopLevel = false;
            Formload.AutoScroll = true;
            panelmain.Controls.Add(Formload);
            Formload.Show();



        }
        public Main()
        {


            InitializeComponent();

            string username = Utils.getusername();
            lbusername.Text = username;

            string tencty = Model.Username.getnamecty();
            lbtencty.Text = tencty;

            panelmain.Controls.Clear();

            View.Beemainload accsup = new Beemainload(this);

            accsup.TopLevel = false;
            accsup.AutoScroll = true;
            panelmain.Controls.Add(accsup);
            accsup.Show();




        }


        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {







        }

        private void bt_caculating_Click(object sender, EventArgs e)
        {
            //var db = new LinqtoSQLDataContext(connection_string);
            //var cltour = from p in db.tours
            //             where p.TourID != 0
            //             select p;

            //dataGridView1.DataSource = cltour;

        }

        private void button1_Click(object sender, EventArgs e)
        {


            //var db = new LinqtoSQLDataContext(connection_string);


            //tour tour = db.tours.Single(p => p.TourID == 20);
            ////  Tourid.TourID =  Convert.ToInt32(cb_id.Text);
            //tour.TourName = cb_name.Text;
            ////   db.
            //db.SubmitChanges();

            //string[] days = { "Sunday", "Monday", "TuesDay", "Wednesday", "Thursday", "Friday", "Saturday" };
            //foreach (string day in days)
            //{
            //    MessageBox.Show("The day is : " + day, "The day ");


            //           }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void bt_insert_Click(object sender, EventArgs e)
        {

            //var db = new LinqtoSQLDataContext(connection_string);

            //tour tb = new tour();

            //tb.TourID = int.Parse(cb_id.Text);
            //tb.TourName = cb_name.Text;
            //tb.Image = cb_image.Text;
            //tb.Nights = byte.Parse(cb_night.Text);
            //tb.Price = int.Parse(cb_price.Text);


            //db.tours.InsertOnSubmit(tb);

            //db.SubmitChanges();


            //  dataGridView1.Refresh();

        }

        private void dataGridView1_DataMemberChanged(object sender, EventArgs e)
        {



        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var db = new LinqtoSQLDataContext(connection_string);
            //var rs = from Tour in db.tours
            //         select Tour;


            //db.tours.DeleteAllOnSubmit(rs);
            //db.SubmitChanges();

        }

        private void button3_Click(object sender, EventArgs e)
        {


            //Form.ActiveForm(MasterdataInput);


        }

        private void bt_inputcsv_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {







        }

        private void fBL5nInputToolStripMenuItem_Click(object sender, EventArgs e)
        {





        }

        private void masterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void upLoadProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void updateNewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product md = new Product();
            //   customerinput_ctrl md = new customerinput_ctrl();
            DialogResult kq1 = MessageBox.Show("Xóa tblFBL5n thay thế bằng bảng mới ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // bool kq;
            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:


                    //   this.updateNewAllToolStripMenuItem.Enabled = false;
                    //   this.reportsToolStripMenuItem.Enabled = false;


                    md.productlistinput();


                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }





        }

        private void addCustormerToolStripMenuItem_Click(object sender, EventArgs e)
        {




        }

        private void changeProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {




        }

        private void addUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  fbl5n_ctrl md = new fbl5n_ctrl();
            //   md.Fbl5n_input();





        }

        private void uploadAndChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        //private void viewFBL5NToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string connection_string = Utils.getConnectionstr();

        //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

        //    Product md = new Product();
        //    var rs = md.product_select_all(db);

        //    Viewtable viewtbl = new Viewtable(rs, db, "FBL5n data");
        //}

        private void viewCustomerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        //private void viewCustomerDataToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    string connection_string = Utils.getConnectionstr();

        //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
        //    customerinput_ctrl md = new customerinput_ctrl();
        //    var rs = md.customersetlect_all(db);

        //    //  MessageBox.Show("Data add/ change Customer done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    Viewtable viewtbl = new Viewtable(rs, db, "CUSTOMER DATA");

        //}


        private void updateNewAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //     bool kq;
            programlist md = new programlist();

            DialogResult kq1 = MessageBox.Show("Xóa VAT out thay thế bằng bảng mới ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:


                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:


                    md.input();


                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }



        }

        //private void viewVATDataToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string connection_string = Utils.getConnectionstr();

        //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
        //    programlist md = new programlist();
        //    var rs = md.setlect_all(db);
        //    Viewtable viewtbl = new Viewtable(rs, db, "VAT ZFI data uploaded ");
        //}

        private void addUpdateAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            programlist md = new programlist();
            md.input();



        }

        private void setCustomerRecieveReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        //    private void dataCheckToolStripMenuItem_Click(object sender, EventArgs e)
        //    {
        //        string connection_string = Utils.getConnectionstr();

        ////        LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
        //        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


        //        Control_ac ct = new Control_ac(); 
        //        DialogResult Kq = MessageBox.Show("Bạn xóa workingdata bởi bản mới hay chỉ add thêm ?" + "\n" + "                 Xóa->Yes/ Add thêm->No !", "Thông báo !", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);


        //        switch (Kq)
        //        {
        //            case DialogResult.None:
        //                break;
        //            case DialogResult.OK:
        //                break;
        //            case DialogResult.Cancel:
        //                //  this.Close();
        //                break;
        //            case DialogResult.Abort:
        //                break;
        //            case DialogResult.Retry:
        //                break;
        //            case DialogResult.Ignore:
        //                break;
        //            case DialogResult.Yes:
        //                {


        //                    #region // XÓA toàn bộ xóa data cũ
        //                    dc.ExecuteCommand("DELETE FROM tblFBL5Nnewthisperiod");
        //                    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //                    dc.SubmitChanges();

        //                    #endregion



        //                    #region    ClearABbelanceZezoinFbl5n

        //                    SqlConnection conn2 = null;
        //                    SqlDataReader rdr1 = null;
        //                    string destConnString = Utils.getConnectionstr();
        //                    try
        //                    {

        //                        conn2 = new SqlConnection(destConnString);
        //                        conn2.Open();
        //                        SqlCommand cmd1 = new SqlCommand("ClearABbelanceZezo", conn2);
        //                        cmd1.CommandType = CommandType.StoredProcedure;
        //                        //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //                        rdr1 = cmd1.ExecuteReader();



        //                        //       rdr1 = cmd1.ExecuteReader();

        //                    }
        //                    finally
        //                    {
        //                        if (conn2 != null)
        //                        {
        //                            conn2.Close();
        //                        }
        //                        if (rdr1 != null)
        //                        {
        //                            rdr1.Close();
        //                        }
        //                    }
        //                    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);





        //                    #endregion



        //                    bool kq1 = ct.checkVATandFBL5n();


        //                    if (kq1)
        //                    {

        //                        ct.UpdateVATregionFromFBL5Nregion();

        //                        bool kq2 = ct.checkVATnameanddtodata();
        //                        // nếu không ok data khong có data trong  fbl5new

        //                        if (kq1 && kq2)// new data ok thi updload data
        //                        {

        //                            Thread t1 = new Thread(new ThreadStart(ct.inputVATandFBL5toFBL5newthisperiod));

        //                            t1.Start();


        //                            Thread t2 = new Thread(showwait);
        //                            t2.Start();

        //                            t1.Join();
        //                            if (t1.ThreadState != ThreadState.Running)
        //                            {
        //                                Thread.Sleep(555);
        //                                t2.Abort();

        //                            }


        //                        }

        //                        //---kiểm tra data nếu khác thì showmessage/ deleted toadn bộ các dòng đó trên thispreriod


        //                        var eror = from tblFBL5Nnewthisperiod in dc.tblFBL5Nnewthisperiods
        //                                   where tblFBL5Nnewthisperiod.COL_value != tblFBL5Nnewthisperiod.Empty_Amount
        //                                   select new
        //                                   {
        //                                       Account_Group = tblFBL5Nnewthisperiod.codeGroup,
        //                                       Account = tblFBL5Nnewthisperiod.Account,
        //                                       Doc_Number = tblFBL5Nnewthisperiod.Document_Number,
        //                                       Customer_Name = tblFBL5Nnewthisperiod.name,
        //                                       coL_EDLP_Value = tblFBL5Nnewthisperiod.COL_value,
        //                                       Empty_AmountinVAT = tblFBL5Nnewthisperiod.Empty_Amount,


        //                                   };
        //                        if (eror.Count() > 0)
        //                        {
        //                            Viewtable viewtbl = new Viewtable(eror, dc, "List các doc chưa update được do có lệch giữ data FBL5n Và VAT/Edlp về phần vỏ , please check !");
        //                        }


        //                        //     xóa trên deleteLisColandEmptydifferentinThis các list không update đuocwj


        //                        #region    deleteLisColandEmptydifferentinThis

        //                        //     SqlConnection conn2 = null;
        //                        //       SqlDataReader rdr1 = null;
        //                        //    string destConnString = Utils.getConnectionstr();
        //                        try
        //                        {

        //                            conn2 = new SqlConnection(destConnString);
        //                            conn2.Open();
        //                            SqlCommand cmd1 = new SqlCommand("deleteLisColandEmptydifferentinThis", conn2);
        //                            cmd1.CommandType = CommandType.StoredProcedure;
        //                            //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //                            rdr1 = cmd1.ExecuteReader();



        //                            //       rdr1 = cmd1.ExecuteReader();

        //                        }
        //                        finally
        //                        {
        //                            if (conn2 != null)
        //                            {
        //                                conn2.Close();
        //                            }
        //                            if (rdr1 != null)
        //                            {
        //                                rdr1.Close();
        //                            }
        //                        }
        //                        //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);





        //                        #endregion

        //                        //  updatetblFBL5NTempRPtview

        //                        #region    updatetblFBL5NTempRPtview tinh tong va so du luon

        //                        //     SqlConnection conn2 = null;
        //                        //       SqlDataReader rdr1 = null;
        //                        //    string destConnString = Utils.getConnectionstr();
        //                        try
        //                        {

        //                            conn2 = new SqlConnection(destConnString);
        //                            conn2.Open();
        //                            SqlCommand cmd1 = new SqlCommand("updatetblFBL5NTempRPtview", conn2);
        //                            cmd1.CommandType = CommandType.StoredProcedure;
        //                            //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //                            rdr1 = cmd1.ExecuteReader();



        //                            //       rdr1 = cmd1.ExecuteReader();

        //                        }
        //                        finally
        //                        {
        //                            if (conn2 != null)
        //                            {
        //                                conn2.Close();
        //                            }
        //                            if (rdr1 != null)
        //                            {
        //                                rdr1.Close();
        //                            }
        //                        }
        //                        //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);





        //                        #endregion
        //                        //    xóa trên tblFBL5Nnewthisperiod


        //                        ///-kiểm tra data

        //                    }

        //                    //---------





        //                    break;
        //                }
        //            case DialogResult.No:

        //                {


        //                    #region    ClearABbelanceZezoinFbl5n

        //                    SqlConnection conn2 = null;
        //                    SqlDataReader rdr1 = null;
        //                    string destConnString = Utils.getConnectionstr();
        //                    try
        //                    {

        //                        conn2 = new SqlConnection(destConnString);
        //                        conn2.Open();
        //                        SqlCommand cmd1 = new SqlCommand("ClearABbelanceZezo", conn2);
        //                        cmd1.CommandType = CommandType.StoredProcedure;
        //                        //  cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = userupdate;

        //                        rdr1 = cmd1.ExecuteReader();



        //                        //       rdr1 = cmd1.ExecuteReader();

        //                    }
        //                    finally
        //                    {
        //                        if (conn2 != null)
        //                        {
        //                            conn2.Close();
        //                        }
        //                        if (rdr1 != null)
        //                        {
        //                            rdr1.Close();
        //                        }
        //                    }
        //                    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);





        //                    #endregion

        //                    // loại toàn bộ các doc trùng trong thispreiod tại cá bảng fbl5m/ vat/ edln

        //                    ct.xoavatEDLPandFBL5nDochaveinFbl5nthis();


        //                    // loại toàn bộ các doc trùng trong thispreiod


        //                    bool kq1 = ct.checkVATandFBL5n();


        //                    if (kq1)
        //                    {

        //                        ct.UpdateVATregionFromFBL5Nregion();

        //                        bool kq2 = ct.checkVATnameanddtodata();


        //                        if (kq1 && kq2)// new data ok thi updload data
        //                        {

        //                            Thread t1 = new Thread(new ThreadStart(ct.inputVATandFBL5toFBL5newthisperiod));

        //                            t1.Start();


        //                            Thread t2 = new Thread(showwait);
        //                            t2.Start();

        //                            t1.Join();
        //                            if (t1.ThreadState != ThreadState.Running)
        //                            {
        //                                Thread.Sleep(555);
        //                                t2.Abort();

        //                            }


        //                        }



        //                    }

        //                    //---------


        //                    break;
        //                }
        //            default:
        //                break;
        //        }







        //    }

        private void uploadCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {




        }

        private void addChangeCustomerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerinput_ctrl md = new customerinput_ctrl();





        }

        private void productCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {




            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tbl_kaProductlist);

            //VInputchange inputcdata = new VInputchange("", "LIST PRODUCT AND EMPTY GROUP", dc, "tbl_kaProductlist", "tbl_kaProductlist", typeff, typeff, "id", "id","");
            //inputcdata.Show();
            //View.Inputchange kq = new View.Inputchange
        }

        //private void viewProductsListToolStripMenuItem_Click(object sender, EventArgs e)
        //{



        //    string connection_string = Utils.getConnectionstr();

        //    var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = (from tbl_kaProductlist in db.tbl_kaProductlists
        //              join tbl_EmptyGroup in db.tbl_EmptyGroups on tbl_kaProductlist.Empty_Group equals tbl_EmptyGroup.id into tblnew
        //              from cat in tblnew
        //              select new
        //              {

        //                  tbl_kaProductlist.Mat_Number,
        //                  tbl_kaProductlist.Mat_Text,
        //                  tbl_kaProductlist.Empty_Group,
        //                  tbl_kaProductlist.Mat_Group,
        //                  tbl_kaProductlist.Mat_Group_Text,
        //                  cat.Name_Group_Emptty



        //                  //tbl_kaProductlist.Empty_Group


        //              }
        //              );



        //    Viewtable viewtbl = new Viewtable(rs, db, "List of product");






        //}



        private void byMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ////var db = new LinqtoSQLDataContext(connection_string);
            ////      fRM_AROPTION fromoptiong = new fRM_AROPTION("ARletter.rdlc");
            ////     fromoptiong.Show();

            ////
            //string connection_string = Utils.getConnectionstr();

            //var db = new LinqtoSQLDataContext(connection_string);

            //Control_ac ctrac = new Control_ac();

            //rs1 = ctrac.KArptdataset1(db);
            //rs2 = ctrac.KArptdataset2(db);





            //if (rs1 != null && rs2 != null)
            //{

            //    Utils ut = new Utils();
            //    var dataset1 = ut.ToDataTable(db, rs1);
            //    var dataset2 = ut.ToDataTable(db, rs2);
            //    Reportsview rpt = new Reportsview(dataset1, dataset2, "ARletter.rdlc");
            //    rpt.Show();

            //}




        }

        private void byDateFromToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //// fRM_AROPTION fromoptiong = new fRM_AROPTION("ARletterdetail.rdlc");
            ////fRM_AROPTION fromoptiong = new fRM_AROPTION("SubARletterdetail.rdlc");

            //string connection_string = Utils.getConnectionstr();

            ////    var db = new LinqtoSQLDataContext(connection_string);
            //var db = new LinqtoSQLDataContext(connection_string);


            //string rptname = "ARletterdetail.rdlc";
            ////      string rptname = "SubARletterdetail.rdlc";
            //Control_ac ctrac = new Control_ac();

            //var rs1 = ctrac.letterdetaildataset1(db);
            //var rs2 = ctrac.letterdetaildataset2(db);


            //if (rs1 != null && rs2 != null)
            //{
            //    //      var db = new LinqtoSQLDataContext(connection_string);
            //    Utils ut = new Utils();
            //    var dataset1 = ut.ToDataTable(db, rs1);
            //    var dataset2 = ut.ToDataTable(db, rs2);
            //    Reportsview rpt = new Reportsview(dataset1, dataset2, rptname);
            //    rpt.Show();

            //}
        }

        private void cOLReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        //private void viewDataLetterReportsToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    string connection_string = Utils.getConnectionstr();
        //    var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = from tbl_ArletterRpt in db.tbl_ArletterRpts
        //             select tbl_ArletterRpt;


        //    Viewtable viewtbl = new Viewtable(rs, db, "Letter data reports");


        //}

        private void groupCustomerSentARLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void viewEdlpDataToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //string connection_string = Utils.getConnectionstr();

            ////  var db = new LinqtoSQLDataContext(connection_string);
            //LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //edlpinput_ctrl md = new edlpinput_ctrl();
            //var rs = md.Edlpsetlect_all(db);
            //Viewtable viewtbl = new Viewtable(rs, db, "EDLP data uploaded ");
        }

        private void addUpdateAndReplaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            ////    bool kq;
            //edlpinput_ctrl md = new edlpinput_ctrl();

            //DialogResult kq1 = MessageBox.Show("Xóa Edlpinput thay thế bằng bảng mới ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //switch (kq1)
            //{
            //    case DialogResult.None:
            //        break;
            //    case DialogResult.OK:


            //        break;
            //    case DialogResult.Cancel:
            //        break;
            //    case DialogResult.Abort:
            //        break;
            //    case DialogResult.Retry:
            //        break;
            //    case DialogResult.Ignore:
            //        break;
            //    case DialogResult.Yes:


            //        //     this.addUpdateAndReplaceToolStripMenuItem1.Enabled = false;
            //        //    this.reportsToolStripMenuItem.Enabled = false;

            //        md.edlpinput();



            //        break;
            //    case DialogResult.No:
            //        break;
            //    default:
            //        break;
            //}






        }

        private void vATInputToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eDLPInputToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void viewDataCOLReportsToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);





        //    var dc = new LinqtoSQLDataContext(connection_string);



        //    IQueryable q3 = from Productlist in dc.tbl_ColdetailRpts
        //                    select Productlist;




        //    Viewtable viewtbl = new Viewtable(q3, dc, "Col Reports detail data");










        //}

        private void viewChangeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //string connection_string = Utils.getConnectionstr();

            ////  var db = new LinqtoSQLDataContext(connection_string);
            //LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tbl_Remark);

            //VInputchange inputcdata = new VInputchange("", "LIST REMARK TO UPDATE ", dc, "tbl_Remark", "tbl_Remark", typeff, typeff, "id", "id","");
            //inputcdata.Show();
            ////View.Inputchange kq = new View.Inputchange



        }

        private void viewChangeDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            //string connection_string = Utils.getConnectionstr();

            ////  var db = new LinqtoSQLDataContext(connection_string);
            ////    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tbl_FreGlass);

            //VInputchange inputcdata = new VInputchange("", "LIST FREE GLASS PROGRAM ", dc, "tbl_FreGlass", "tbl_FreGlass", typeff,typeff ,"id", "id","");
            //inputcdata.Show();
            ////View.Inputchange kq = new View.Inputchange
        }

        private void lETTERCOLREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //string connection_string = Utils.getConnectionstr();

            ////  var db = new LinqtoSQLDataContext(connection_string);
            ////    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);



            //var db = new LinqtoSQLDataContext(connection_string);


            //string rptname = "ARCOLrpt.rdlc";
            ////      string rptname = "SubARletterdetail.rdlc";
            //Control_ac ctrac = new Control_ac();

            //var rs1 = ctrac.ARcoldataset1(db);
            //var rs2 = ctrac.ARcoldataset2(db);


            //if (rs1 != null && rs2 != null)
            //{
            //    //      var db = new LinqtoSQLDataContext(connection_string);
            //    Utils ut = new Utils();
            //    var dataset1 = ut.ToDataTable(db, rs1);
            //    var dataset2 = ut.ToDataTable(db, rs2);
            //    Reportsview rpt = new Reportsview(dataset1, dataset2, rptname);
            //    rpt.Show();



            //}

        }

        //private void eDITCUSTOMERDATAToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


        //    var typeff = typeof(tblCustomer);

        //    VInputchange inputcdata = new VInputchange("", "LIST MASTER DATA CUSTOMER ", dc, "tblCustomer", "tblCustomer", typeff, "id", "id");
        //    inputcdata.Show();

        //}

        private void eDITLETTERDATAREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string connection_string = Utils.getConnectionstr();

            ////  var db = new LinqtoSQLDataContext(connection_string);
            ////     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tbl_ArletterRpt);

            //VInputchange inputcdata = new VInputchange("", "DATA ARLETTER REPORTS- CAREFULLY BEFORE CHANGE IT ! ", dc, "tbl_ArletterRpt", "tbl_ArletterRpt", typeff, typeff, "id", "id","");
            //inputcdata.Show();


        }

        private void editFBL5NDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //string connection_string = Utils.getConnectionstr();

            ////  var db = new LinqtoSQLDataContext(connection_string);
            ////  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tblFBL5N);

            //VInputchange inputcdata = new VInputchange("", "FBL5N PREPRAIRE TO UP TO DATA  ", dc, "tblFBL5N", "tblFBL5N", typeff, typeff, "Fbl5nID", "Fbl5nID","");
            //inputcdata.Show();





        }

        private void eDITVATDATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   Control_ac ct = new Control_ac();
            // ct.UpdateVATregionFromFBL5Nregion();

            //string connection_string = Utils.getConnectionstr();

            ////  var db = new LinqtoSQLDataContext(connection_string);
            ////  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tblVat);

            //VInputchange inputcdata = new VInputchange("", "VAT PREPRAIRE TO UP TO DATA  ", dc, "tblVat", "tblVat", typeff, typeff, "id", "id","");
            //inputcdata.Show();

        }

        private void eDITEDLPDATAToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //string connection_string = Utils.getConnectionstr();

            ////  var db = new LinqtoSQLDataContext(connection_string);
            ////   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tblEDLP);

            //VInputchange inputcdata = new VInputchange("", "EDLP PREPRAIRE TO UP TO DATA  ", dc, "tblEDLP", "tblEDLP", typeff, typeff, "id", "id","");
            //inputcdata.Show();
        }

        private void vIEWPRODUCTGROUPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eDITPRODUCTSGROUPToolStripMenuItem_Click(object sender, EventArgs e)
        {






        }

        private void beginingBalanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            //string connection_string = Utils.getConnectionstr();

            ////  var db = new LinqtoSQLDataContext(connection_string);
            ////  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tblFBL5beginbalace);

            //VInputchange inputcdata = new VInputchange("", "BEGINNING BALANCE ARCONFIRMATION LETTER", dc, "tblFBL5beginbalace", "tblFBL5beginbalace", typeff, typeff, "id", "id","");
            //inputcdata.Show();

        }

        private void eDITPRODUCTSGROUPToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


            //string connection_string = Utils.getConnectionstr();

            ////  var db = new LinqtoSQLDataContext(connection_string);
            ////  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tbl_kaCustomerGroup);

            //VInputchange inputcdata = new VInputchange("", "LIST CUSTOMER GROUP  ", dc, "tbl_kaCustomerGroup", "tbl_kaCustomerGroup", typeff, typeff, "id", "id","");
            //inputcdata.Show();




        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  bool kq;
            Contract md = new Contract();

            DialogResult kq1 = MessageBox.Show("Xóa Remark thay thế bằng bảng mới ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:


                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:



                    //this.updateNewAllToolStripMenuItem1.Enabled = false;

                    //this.reportsToolStripMenuItem.Enabled = false;
                    md.inputcontract();


                    //      var rs = md.setlect_all();
                    //        Viewtable viewtbl = new Viewtable(rs, "VAT ZFI data uploaded ");













                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }


        }

        //private void vIEWREMARKLISTToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


        //    Contract md = new Contract();
        //    var rs = md.Setlect_all_begin(db);
        //    Viewtable viewtbl = new Viewtable(rs, db, "LIST OF UPDAD REMARKS  ");
        //}

        //private void vIEWREMARKSLISTToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


        //    fuctionprog md = new fuctionprog();
        //    var rs = md.Funtionsetlect_all(db);
        //    Viewtable viewtbl = new Viewtable(rs, db, "LIST OF REEGALSSES TABLE ");




        //}

        private void uploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            //  bool kq;
            fuctionprog md = new fuctionprog();

            DialogResult kq1 = MessageBox.Show("Xóa FREEGALSSES  thay thế bằng bảng mới ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:


                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:



                    //this.updateNewAllToolStripMenuItem1.Enabled = false;

                    //this.reportsToolStripMenuItem.Enabled = false;
                    md.Fuction_input();


                    //      var rs = md.setlect_all();
                    //        Viewtable viewtbl = new Viewtable(rs, "VAT ZFI data uploaded ");













                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }




        }

        private void rEPORTSMAKEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////var db = new LinqtoSQLDataContext(connection_string);
            //fRM_AROPTION fromoptiong = new fRM_AROPTION();//("ARletter.rdlc");
            //fromoptiong.Show();

        }

        //private void sETLISTCUSTOMERMAKEREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

        //    customerinput_ctrl md = new customerinput_ctrl();
        //    var rs = md.customersetlect_all(db);
        //    Viewtable viewtbl = new Viewtable(rs, db, "Update Customer make reports !");



        //}

        //private void vIEWLISTCUSTMAKEREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    Control_ac ct = new Control_ac();
        //    //    ct.updateCustgoupinListcustmakeRpt();

        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    var rsCust2 = from tblCustomer in dc.tblCustomers
        //             //     where tblCustomer.Reportsend == true
        //                  orderby tblCustomer.Customer
        //                  select tblCustomer;

        //    //  MessageBox.Show("Data add/ change Customer done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    Viewtable viewtbl = new Viewtable(rsCust2, dc, "LIST CUSTOMER MAKE REPORTS");

        //}

        private void rEPORTSMAKEToolStripMenuItem_Click_1(object sender, EventArgs e)
        {







            ////

        }

        private void eDITLISTCUSTMAKEREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        //private void vIEWALLDATABASEONSERVERToolStripMenuItem_Click(object sender, EventArgs e)
        //{



        //    fromdate fromtochoice = new View.fromdate();
        //    Control_ac ctrac = new Control_ac();

        //    fromtochoice.ShowDialog();


        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    //      LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

        //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);




        //    DateTime fromdate = fromtochoice.tungay;
        //    DateTime todate = fromtochoice.denngay;
        //    bool choice = fromtochoice.chon;




        //    if (choice == true)
        //    {



        //        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //        var rs2 = from tblFBL5Nnew in dc.tblFBL5Nnews
        //                  where tblFBL5Nnew.Posting_Date >= fromdate && tblFBL5Nnew.Posting_Date <= todate
        //                  select tblFBL5Nnew;


        //        Viewtable viewtbl = new Viewtable(rs2, dc, "VIEWLIST DATABASE UPLOADED ON SYSYEM FROM-" + fromdate.Day + "/" + fromdate.Month + "/" + fromdate.Year + " -TO- " + todate.Day + "/" + todate.Month + "/" + todate.Year);




        //    }
        //}

        //private void vIEWLETTERDETAILREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

        //    var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = from tbl_ArletterdetailRpt in db.tbl_ArletterdetailRpts
        //             select tbl_ArletterdetailRpt;


        //    Viewtable viewtbl = new Viewtable(rs, db, "Letter data detail reporst");
        //}

        //private void vIEWLETTERCOLREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


        //    var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = from tbl_ColdetailRpt in db.tbl_ColdetailRpts
        //             select tbl_ColdetailRpt;


        //    Viewtable viewtbl = new Viewtable(rs, db, "Letter COL detail reporst");
        //}

        //private void eDITLETTERDETAILREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


        //    var typeff = typeof(tbl_ArletterdetailRpt);

        //    VInputchange inputcdata = new VInputchange("", "DATA Arletter DetailRpt REPORTS- CAREFULLY BEFORE CHANGE IT ! ", dc, "tbl_ArletterdetailRpt", "tbl_ArletterdetailRpt", typeff, "id", "id");
        //    inputcdata.Show();

        //}

        ////private void vIEWLETTERCOLREPORTSToolStripMenuItem1_Click(object sender, EventArgs e)
        ////{

        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


        //    var typeff = typeof(tbl_ColdetailRpt);

        //    VInputchange inputcdata = new VInputchange("", "DATA Arletter Col Detail Reports- CAREFULLY BEFORE CHANGE IT ! ", dc, "tbl_ColdetailRpt", "tbl_ColdetailRpt", typeff, "id", "id");
        //    inputcdata.Show();
        //}

        private void eDITALLDATABASEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //string connection_string = Utils.getConnectionstr();

            ////  var db = new LinqtoSQLDataContext(connection_string);
            //// LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var typeff = typeof(tblFBL5Nnew);

            //VInputchange inputcdata = new VInputchange("", "ALL DATA FBL5N NEW ON SERVER, BECAREFULLY BEFORE CHANGE IT ! ", dc, "tblFBL5Nnew", "tblFBL5Nnew", typeff, typeff, "id", "id","");
            //inputcdata.Show();
        }

        private void uploadFreeGlassToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void iNPUTPERIODDEPOSITAMOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    //  LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);



        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    var rsthisperiod = from tblFBL5Nnewthisperiod in dc.tblFBL5Nnewthisperiods

        //                       select tblFBL5Nnewthisperiod;

        //    if (rsthisperiod.Count() != 0)
        //    {
        //        // fbl5n_ctrl md = new fbl5n_ctrl();
        //        //var rs = md.product_select_all();

        //        Viewtable viewtbl = new Viewtable(rsthisperiod, dc, "iNPUT DEPOSIT AMOUNTT !");

        //    }



        //}
        public void showwait()
        {
            View.BeeCaculating wat = new View.BeeCaculating();


            wat.ShowDialog();






        }




        //private void cLOSETHISPRERIODToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    DialogResult kq1 = MessageBox.Show("ENDMONTH DATA CLOSE ? ", "CONFIRN CLOSE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


        //    switch (kq1)
        //    {
        //        case DialogResult.None:
        //            break;
        //        case DialogResult.OK:
        //            break;
        //        case DialogResult.Cancel:
        //            break;
        //        case DialogResult.Abort:
        //            break;
        //        case DialogResult.Retry:
        //            break;
        //        case DialogResult.Ignore:
        //            break;
        //        case DialogResult.Yes:

        //            //   string filename = theDialog.FileName.ToString();updatetoFBL5nnew
        //            //    updatetoFBL5nnew(); // teo xoa sau


        //            #region q List các document có trong bảng VAT không có trong bảng FBL5N !
        //            //---

        //            string connection_string = Utils.getConnectionstr();

        //            //  var db = new LinqtoSQLDataContext(connection_string);
        //            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);



        //            var q = from tblFBL5Nnewthisperiod in db.tblFBL5Nnewthisperiods
        //                    where (from tblFBL5Nnew in db.tblFBL5Nnews
        //                           select tblFBL5Nnew.Document_Number).Contains(tblFBL5Nnewthisperiod.Document_Number)
        //                    //Tương đương từ khóa NOT IN trong SQL
        //                    select tblFBL5Nnewthisperiod;



        //            if (q.Count() != 0)
        //            {



        //                Viewtable viewtbl = new Viewtable(q, db, "Data không close được do có List các document sau đã update lên rồi !");

        //            }
        //            if (q.Count() == 0)
        //            {

        //                Control_ac ct = new Control_ac();

        //                Thread t1 = new Thread(ct.inputthisisperiodtoFBL5nnew);
        //                //   t1.IsBackground = true;
        //                t1.Start();


        //                Thread t2 = new Thread(showwait);
        //                t2.Start();

        //                t1.Join();
        //                if (t1.ThreadState != ThreadState.Running)
        //                {
        //                    Thread.Sleep(555);
        //                    t2.Abort();

        //                }





        //            }
        //            #endregion q "List các document có trong bảng VAT không có trong bảng FBL5N !





        //            break;
        //        case DialogResult.No:
        //            break;
        //        default:
        //            break;
        //    }




        //}

        private void bYTIMEPICKERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bYPRERIODToolStripMenuItem_Click(object sender, EventArgs e)
        {





        }


        class Runreports
        {
            public LinqtoSQLDataContext dc { get; set; }
            public DateTime fromdate { get; set; }
            public DateTime todate { get; set; }
            public DateTime returndate { get; set; }


        }


        static void ReportVNRun(object objextRPt)
        {

            //Runreports dat = (Runreports)objextRPt;
            //LinqtoSQLDataContext db = dat.dc;
            //DateTime fromdate = dat.fromdate;
            //DateTime todate = dat.todate;
            //DateTime returndate = dat.returndate;
            //Control_ac ctrac = new Control_ac();
            //ctrac.ARlettermakebyGroupcode2(db, fromdate, todate, returndate);





        }


        static void ReportVNRegiom(object objextRPt)
        {

            //Runreports dat = (Runreports)objextRPt;
            //LinqtoSQLDataContext db = dat.dc;
            //DateTime fromdate = dat.fromdate;
            //DateTime todate = dat.todate;
            //DateTime returndate = dat.returndate;
            //Control_ac ctrac = new Control_ac();
            //ctrac.ARlettermakebyGroupcodeRegion(db, fromdate, todate, returndate);





        }



        private void userAndRightToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void serverNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.BeeServersetup stup = new BeeServersetup();
            stup.Show();
        }



        //private void bEGINBALANCEVIEWToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    var rsthisperiod = from tblFBL5beginbalace in dc.tblFBL5beginbalaces
        //                       orderby tblFBL5beginbalace.Account
        //                       select tblFBL5beginbalace;

        //    if (rsthisperiod.Count() != 0)
        //    {
        //        // fbl5n_ctrl md = new fbl5n_ctrl();
        //        //var rs = md.product_select_all();

        //        Viewtable viewtbl = new Viewtable(rsthisperiod, dc, "LIST BEGIN BALANCE !");

        //    }


        //}

        private void dELETEALLDATABASEEDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult kq1 = MessageBox.Show(" XÓA TOÀN BỘ DỮ LIỆU TRÊN SERVER ! ", "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            // bool kq;
            switch (kq1)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:


                    //   this.updateNewAllToolStripMenuItem.Enabled = false;
                    //   this.reportsToolStripMenuItem.Enabled = false;

                    string connection_string = Utils.getConnectionstr();

                    //  var db = new LinqtoSQLDataContext(connection_string);
                    //     LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
                    //    var rs2 = from tblFBL5Nnew in dc.tblFBL5Nnews
                    //             select tblFBL5Nnew;

                    dc.ExecuteCommand("DELETE FROM tblFBL5Nnew");
                    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
                    dc.SubmitChanges();
                    //   dc.tblFBL5Nnews.DeleteAllOnSubmit(rs2);
                    //   dc.SubmitChanges();


                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }

        }

        //   private void pRINTREPORTSBYOPTIONToolStripMenuItem_Click(object sender, EventArgs e)
        //   {
        //       PrintLetterOption PrintOption = new PrintLetterOption();
        //       // Control_ac ctrac = new Control_ac();

        //       PrintOption.ShowDialog();


        // //      int choice = PrintOption.choice;

        ////       double onlycode = PrintOption.onlycode;
        ////       double fromcode = PrintOption.fromcode;
        // //      double tocode = PrintOption.tocode;

        // //      string groupsending = PrintOption.groupsending;


        //       if (choice == 1)//grooup print
        //       {
        //           // string groupsending = PrintOption.groupsending;
        //           //    MessageBox.Show(groupsending + "-groupprint--" );

        //           string connection_string = Utils.getConnectionstr();


        //      //     MessageBox.Show(groupsending + "-groupprint--");


        //           #region  updatepriterinvoice grouppriter
        //           SqlConnection conn2 = null;
        //           SqlDataReader rdr1 = null;

        //           string destConnString = Utils.getConnectionstr();
        //           try
        //           {

        //               conn2 = new SqlConnection(destConnString);
        //               conn2.Open();
        //               SqlCommand cmd1 = new SqlCommand("updategroupprintletterChoice", conn2);
        //               cmd1.CommandType = CommandType.StoredProcedure;
        //               cmd1.Parameters.Add("@groupsending", SqlDbType.VarChar).Value = groupsending;

        //               rdr1 = cmd1.ExecuteReader();



        //               //       rdr1 = cmd1.ExecuteReader();

        //           }
        //           finally
        //           {
        //               if (conn2 != null)
        //               {
        //                   conn2.Close();
        //               }
        //               if (rdr1 != null)
        //               {
        //                   rdr1.Close();
        //               }
        //           }
        //           //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //           #endregion


        //       }
        //       if (choice == 2)//fromcode to code print
        //       {

        //           //double fromcode = PrintOption.fromcode;
        //           //double tocode = PrintOption.tocode;
        //           //         MessageBox.Show(fromcode.ToString() + "-fromto--" + tocode.ToString());


        //           #region  updatepriterinvoice grouppriter
        //           SqlConnection conn2 = null;
        //           SqlDataReader rdr1 = null;

        //           string destConnString = Utils.getConnectionstr();
        //           try
        //           {

        //               conn2 = new SqlConnection(destConnString);
        //               conn2.Open();
        //               SqlCommand cmd1 = new SqlCommand("updategroupprintletterfromcodetocodeChoice", conn2);
        //               cmd1.CommandType = CommandType.StoredProcedure;
        //               cmd1.Parameters.Add("@fromcode", SqlDbType.Float).Value = fromcode;
        //               cmd1.Parameters.Add("@tocode", SqlDbType.Float).Value = tocode;

        //               rdr1 = cmd1.ExecuteReader();



        //               //       rdr1 = cmd1.ExecuteReader();

        //           }
        //           finally
        //           {
        //               if (conn2 != null)
        //               {
        //                   conn2.Close();
        //               }
        //               if (rdr1 != null)
        //               {
        //                   rdr1.Close();
        //               }
        //           }
        //           //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //           #endregion






        //       }

        //       if (choice == 3)   //only code
        //       {
        //           //   MessageBox.Show(onlycode.ToString() + "-onlycepde--");

        //           #region  updatepriterinvoice grouppriter
        //           SqlConnection conn2 = null;
        //           SqlDataReader rdr1 = null;

        //           string destConnString = Utils.getConnectionstr();
        //           try
        //           {

        //               conn2 = new SqlConnection(destConnString);
        //               conn2.Open();
        //               SqlCommand cmd1 = new SqlCommand("updategroupprintletterOnlycodeChoice", conn2);
        //               cmd1.CommandType = CommandType.StoredProcedure;
        //               cmd1.Parameters.Add("@onlycode", SqlDbType.Float).Value = onlycode;

        //               rdr1 = cmd1.ExecuteReader();



        //               //       rdr1 = cmd1.ExecuteReader();

        //           }
        //           finally
        //           {
        //               if (conn2 != null)
        //               {
        //                   conn2.Close();
        //               }
        //               if (rdr1 != null)
        //               {
        //                   rdr1.Close();
        //               }
        //           }
        //           //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //           #endregion




        //       }
        //       if (choice == 4)   //all code
        //       {



        //           #region update cho view heet baso caso

        //           //     updategroupprintletterChoiceALL

        //           #region  updatepriterinvoice updategroupprintletterChoiceALL
        //           SqlConnection conn2 = null;
        //       SqlDataReader rdr1 = null;

        //       string destConnString = Utils.getConnectionstr();
        //       try
        //       {

        //           conn2 = new SqlConnection(destConnString);
        //           conn2.Open();
        //           SqlCommand cmd1 = new SqlCommand("updategroupprintletterChoiceALL", conn2);
        //           cmd1.CommandType = CommandType.StoredProcedure;
        //           //    cmd1.Parameters.Add("@groupsending", SqlDbType.VarChar).Value = groupsending;

        //           rdr1 = cmd1.ExecuteReader();



        //           //       rdr1 = cmd1.ExecuteReader();

        //       }
        //       finally
        //       {
        //           if (conn2 != null)
        //           {
        //               conn2.Close();
        //           }
        //           if (rdr1 != null)
        //           {
        //               rdr1.Close();
        //           }
        //       }
        //           //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //           #endregion


        //           #endregion


        //       }



        //       if (choice ==1 || choice == 2 || choice == 3 || choice == 4)
        //       {
        //           #region print invoce


        //           string connection_string = Utils.getConnectionstr();

        //           var db = new LinqtoSQLDataContext(connection_string);

        //           Control_ac ctrac = new Control_ac();

        //           rs1 = ctrac.KArptdataset1(db);
        //           rs2 = ctrac.KArptdataset2(db);





        //           if (rs1 != null && rs2 != null)
        //           {

        //               Utils ut = new Utils();
        //               var dataset1 = ut.ToDataTable(db, rs1);
        //               var dataset2 = ut.ToDataTable(db, rs2);
        //               Reportsview rpt = new Reportsview(dataset1, dataset2, "ARletter.rdlc");
        //               rpt.Show();

        //           }


        //           #endregion

        //           #region print detail

        //        //   string connection_string = Utils.getConnectionstr();

        //           //    var db = new LinqtoSQLDataContext(connection_string);
        //      //     var db = new LinqtoSQLDataContext(connection_string);


        //        //   string rptname = "ARletterdetail.rdlc";
        //           //      string rptname = "SubARletterdetail.rdlc";
        //       //    Control_ac ctrac = new Control_ac();

        //           var rs3 = ctrac.letterdetaildataset1(db);
        //           var rs4 = ctrac.letterdetaildataset2(db);


        //           if (rs1 != null && rs2 != null)
        //           {
        //               //      var db = new LinqtoSQLDataContext(connection_string);
        //               Utils ut = new Utils();
        //               var dataset1 = ut.ToDataTable(db, rs3);
        //               var dataset2 = ut.ToDataTable(db, rs4);
        //               Reportsview rpt = new Reportsview(dataset1, dataset2, "ARletterdetail.rdlc");
        //               rpt.Show();

        //           }

        //           #endregion

        //           #region print col
        //      //     string connection_string = Utils.getConnectionstr();

        //           //  var db = new LinqtoSQLDataContext(connection_string);
        //           //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);



        //         //  var db = new LinqtoSQLDataContext(connection_string);


        //        //   string rptname3 = "ARCOLrpt.rdlc";
        //           //      string rptname = "SubARletterdetail.rdlc";
        //     //      Control_ac ctrac = new Control_ac();

        //           var rs5 = ctrac.ARcoldataset1(db);
        //           var rs6 = ctrac.ARcoldataset2(db);


        //           if (rs1 != null && rs2 != null)
        //           {
        //               //      var db = new LinqtoSQLDataContext(connection_string);
        //               Utils ut = new Utils();
        //               var dataset1 = ut.ToDataTable(db, rs5);
        //               var dataset2 = ut.ToDataTable(db, rs6);
        //               Reportsview rpt = new Reportsview(dataset1, dataset2, "ARCOLrpt.rdlc");
        //               rpt.Show();



        //           }



        //           #endregion

        //       }




        //   }

        //private void lETTERRETURNUPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        //{



        //    fromdate fromtochoice = new View.fromdate();
        //    Control_ac ctrac = new Control_ac();

        //    fromtochoice.ShowDialog();


        //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    //      LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

        //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);




        //    DateTime fromdate = fromtochoice.tungay;
        //    DateTime todate = fromtochoice.denngay;
        //    bool choice = fromtochoice.chon;




        //    if (choice == true)
        //    {
        //        var rs = from tbl_Preriod in db.tbl_Preriods
        //                 where tbl_Preriod.fromdate >= fromdate && tbl_Preriod.todate <= todate
        //                 select tbl_Preriod;



        //        Viewtable viewtbl = new Viewtable(rs, db, "LETTER RETURN STATUS UPDATE");



        //    }






        //    //    string connection_string = Utils.getConnectionstr();

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        ////    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


        //}

        private void aRBalanceAndReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            View.Passwordchange changep = new Passwordchange();
            changep.ShowDialog();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }


        //private void pictureBox1_MouseHover(object sender, EventArgs e)
        //{
        //   this.phanquyen.Image = global::BEEACCOUNT.Properties.Resources.input21;
        //}

        //private void pictureBox1_MouseLeave(object sender, EventArgs e)
        //{
        // this.phanquyen.Image = global::BEEACCOUNT.Properties.Resources.input1;
        //}

        //private void pictureBox4_MouseHover(object sender, EventArgs e)
        //{
        //  this.inputpayment.Image = global::BEEACCOUNT.Properties.Resources.payment2;
        //}

        //private void pictureBox4_MouseLeave(object sender, EventArgs e)
        //{
        // this.inputpayment.Image = global::BEEACCOUNT.Properties.Resources.payment1;
        //}

        //private void pictureBox6_MouseHover(object sender, EventArgs e)
        //{
        //   this.inputmarterdata.Image = global::BEEACCOUNT.Properties.Resources.master2;
        //}

        //private void pictureBox6_MouseLeave(object sender, EventArgs e)
        //{
        //   this.inputmarterdata.Image = global::BEEACCOUNT.Properties.Resources.master1;
        //}

        //private void pictureBox2_MouseHover(object sender, EventArgs e)
        //{
        //  this.inpucvolume.Image = global::BEEACCOUNT.Properties.Resources.saleupdate2;
        //}

        //private void pictureBox2_MouseLeave(object sender, EventArgs e)
        //{
        //  this.inpucvolume.Image = global::BEEACCOUNT.Properties.Resources.saleupdate1;
        //}

        //private void pictureBox5_MouseHover(object sender, EventArgs e)
        //{
        //  this.reports.Image = global::BEEACCOUNT.Properties.Resources.Reports2;
        //}

        //private void pictureBox5_MouseLeave(object sender, EventArgs e)
        //{
        //  this.reports.Image = global::BEEACCOUNT.Properties.Resources.Reports1;
        //}

        private void pictureBox6_Click(object sender, EventArgs e)
        {






        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                ///  KAcontractlisting
                ///    if (frm.Text == "CreatenewContract")
                if (frm.Text == "KAcontractlisting")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {


                //string connection_string = Utils.getConnectionstr();
                //string username = Utils.getusername();

                //LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


                //var rs = Control.Control_ac.getViewcontractMaster(db);


                //View.KAcontractlisting KAcontractlisting = new View.KAcontractlisting(rs,db,"Input Contract");


                //KAcontractlisting.Show();
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                ///  KAcontractlisting
                ///    if (frm.Text == "CreatenewContract")
                if (frm.Text == "KAcontractlisting")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {

                string connection_string = Utils.getConnectionstr();
                string username = Utils.getusername();

                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);



                //var rs = Control.Control_ac.getViewcontractMaster(db);

                //View.KAcontractlisting KAcontractlisting = new View.KAcontractlisting(rs, db, "Payment Input");


                //KAcontractlisting.Show();
            }



            //FormCollection fc = System.Windows.Forms.Application.OpenForms;

            //bool kq = false;
            //foreach (Form frm in fc)
            //{
            //    if (frm.Text == "KAinputpayment")
            //    {
            //        kq = true;
            //        frm.Focus();

            //    }
            //}

            //if (!kq)
            //{

            //    View.KAinputpayment KAinputpayment = new View.KAinputpayment();


            //    KAinputpayment.Show();
            //}
        }

   
        private void iNPUTPERIODDEPOSITAMOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            //         kareportsform


            FormCollection fc = System.Windows.Forms.Application.OpenForms;

            bool kq = false;
            foreach (Form frm in fc)
            {
                if (frm.Text == "Reports")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {

                View.kareportsform kareportsform = new View.kareportsform();


                kareportsform.Show();
            }



        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //     View.kapricingcheck pricecheck = new kapricingcheck();

            //     pricecheck.ShowDialog();

        }

        private void btusersetup_Click(object sender, EventArgs e)
        {

        }

        private void btMasterdata_Click(object sender, EventArgs e)
        {



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void dfasfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ádfasdfToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void nhậpSốĐầuKỳToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void hủyLoadMKtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cậpNhậtTrạngTháiCácPhiếuMKtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void usersSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mKTLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoGiaoHàngMKtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tạoPhiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //panelmain.Controls.Clear();  //PosmCreateTK


            //View.PosmCreateTK PosmCreateTK = new View.PosmCreateTK();

            //PosmCreateTK.TopLevel = false;
            //PosmCreateTK.AutoScroll = true;
            //panelmain.Controls.Add(PosmCreateTK);
            //PosmCreateTK.Show();
        }

        private void fINToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sôKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSachTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //var typeffmain = typeof(tbl_KaCustomer);

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            var rstk = from tbl_dstaikhoan in dc.tbl_dstaikhoans


                       select new

                       {
                           matk = tbl_dstaikhoan.matk,

                           tentk = tbl_dstaikhoan.tentk,


                       };


            Viewtable viewtbl = new Viewtable(rstk, dc, "DANH SÁCH TÀI KHOẢN", 3, "tk");// view code 1 la can viet them lenh

            viewtbl.Show();





        }

        private void sưaDanhSachTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            //    panelmain.Controls.Clear();
            //  var db = new LinqtoSQLDataContext(connection_string);
            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var typeff = typeof(tbl_Socai);

            BeeInputchange inputcdata = new BeeInputchange("", "DANH SÁCH TÀI KHOẢN ", dc, "tbl_Socai", "tbl_Socai", typeff, typeff, "id", "id", "");
            inputcdata.TopLevel = false;
            inputcdata.AutoScroll = true;

            panelmain.Controls.Add(inputcdata);
            inputcdata.Show();

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void thêmMơiTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hêThôngTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {







        }

        private void button12_Click(object sender, EventArgs e)
        {




        }

        private void button7_Click(object sender, EventArgs e)
        {
            //panelmain.Controls.Clear();

            // View.BeePhieuThu accsup = new BeePhieuThu();

            // accsup.TopLevel = false;
            // accsup.AutoScroll = true;
            // panelmain.Controls.Add(accsup);
            // accsup.Show();

            // Beemainload

            //  panelmain.Controls.Add(inputcdata);
            // inputcdata.Show();

        }

        private void báoCáoNhậpXuấtTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Model.Soketoan.socaitaikhoan();

        }

        private void inputMinuteTransferPOSMTicketToMKTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Model.Soketoan.soQuy();

        }

        private void báoCáoGiaoHàngHàngTrênĐườngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Model.Soketoan.sochitiettaikhoan();
        }

        private void sôNhâtKyToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Model.Soketoan.sonhatkychung();



        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Model.Soketoan.sotonghoptaikhoanchitiet();
        }

        private void banCânĐôiTaiKhoanPhatSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Model.Soketoan.bangcandoiphatsinhtaikhoan();
        }

        private void pHẦNHÀNHKẾTOÁNToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void phiếuNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void phiếuXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void bútToánTổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void sổCáiTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region  // bcsocai


            Model.Soketoan.socaitaikhoan();

            #endregion

        }

        private void sổTàiKhoảnTổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region// bcsotonghop


            Model.Soketoan.sotonghoptaikhoanchitiet();



            #endregion

        }

        private void sổChiTiếtTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {



            #region//bcsochitiet


            Model.Soketoan.sochitiettaikhoan();


            #endregion

        }

        private void sổNhậtKýChungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region//bcsonhatkychung


            Model.Soketoan.sonhatkychung();


            #endregion

        }

        private void sổQuỹToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            #region//soquy


            Model.Soketoan.soQuy();


            #endregion

        }

        private void danhSáchLoạiTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinDoanhNghiệpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void hệThốngTàiKhoảnKếToánToolStripMenuItem_Click(object sender, EventArgs e)
        {


















        }

        private void phânQuyềnNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!Username.getphanquyen())
            {
                View.Noouthourise view = new Noouthourise();
                view.ShowDialog();
                return;
            }

            #region//phanquyen

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var typeff = typeof(tbl_Temp);

            BeeInputchange inputcdata = new BeeInputchange("", "Thiết lập và phân quyền người dùng", dc, "tbl_Temp", "tbl_Temp", typeff, typeff, "id", "id", "");
            inputcdata.TopLevel = false;
            inputcdata.AutoScroll = true;

            //    main1.clearpannel();


            Controls.Add(inputcdata);
            inputcdata.Show();


            //Formload.TopLevel = false;
            //Formload.AutoScroll = true;
            //panelmain.Controls.Add(Formload);
            //Formload.Show();




            #endregion

        }

        private void danhSáchKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void danhSáchNhómSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void danhSáchSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTínDoanhNghiệpToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void danhSáchLoạiTàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void danhSáchLoạiTàiKhoảnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
         

        }

        private void danhSáchTàiKhoảnKếToánToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void hệThốngTàiKhoảnKếToánToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void mởSổTheoDõiChiTiếtTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void báoCáoNhậpXuấtTồnKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            #region//bcxuatnhapton


            Model.Soketoan.sotonghopbaocaonhapxuatton();

            #endregion

        }

        private void sổKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //   Model.Soketoan();

        }

        private void danhSáchNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //    Model.Soketoan.sotonghopbaocaonhapxuatton();

        }

        private void báoCáoKQKDToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region//xem báo cóa ckqkd


            Model.Soketoan.baocaokqkd();

            #endregion

        }

        private void nhậpSốĐầuKỳKQKDToolStripMenuItem_Click(object sender, EventArgs e)
        {


            #region//xem nhập số dư dầu bckqkd

            Model.Soketoan.xemvaupdatekqkd200();


            #endregion




        }

        private void nhậpSốĐầuKỳCĐKTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region//xem nhập số dư dầu bckqkd

            Model.Soketoan.xemvaupdauCDKT200();


            #endregion
        }

        private void bảngCĐKTToolStripMenuItem_Click(object sender, EventArgs e)
        {


            #region//bccan doi ke toan
            //if (name == "bcsonhatkychung")
            //{

            Model.Soketoan.baocaocandoiketoantt200lientuc();

            //  }
            #endregion


        }

        private void bảnCấnĐốiTàiKhoảnPhátSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {


            #region//bangsoducd
            //if (name == "bcsonhatkychung")
            //{

            Model.Soketoan.Bangcandoiphatsinhketoantt200lientuc();

            //  }
            #endregion


        }

        private void báoCáoLCTTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region//bangsoducd
            //if (name == "bcsonhatkychung")
            //{

            Model.Soketoan.baocaoluuchuyentiente();

            //  }
            #endregion


        }

        private void nhậpSốĐầuKỳLCTTToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Model.Soketoan.nhapsodudaukylctt();




        }

        private void danhSáchNhàXeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region//dsxenp

            //    NPDanhsachnhavantai
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachNVT(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH NHÀ VẬN TẢI", 8, "tk");// mã 8 là danh sach nha nha van tai

            viewtbl.Show();


            #endregion


        }

        private void danhSáchXeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachxe(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH XE", 9, "tk");// mã 8 là danh sach nha nha van tai

            viewtbl.Show();





        }

        private void danhSáchKháchHàngVậnTảiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region//dskhachhangvantai

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachkhachhangvantai(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH KHÁCH HÀNG VẬN TẢI", 10, "tk");// mã 8 là danh sach nha nha van tai

            viewtbl.Show();



            #endregion


        }

        private void báoCáoNhậpXuấtTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void bảngGiáVậnTảiTheoTuyếnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<View.beeselectinput.ComboboxItem> CombomCollection = new List<View.beeselectinput.ComboboxItem>();
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = from p in dc.tbl_NP_khachhangvanchuyens
                         //     where p.Code != "DIS"
                     orderby p.maKH
                     select p;
            foreach (var item2 in rs)
            {
                View.beeselectinput.ComboboxItem cb = new View.beeselectinput.ComboboxItem();
                cb.Value = item2.maKH.Trim();
                cb.Text = item2.maKH.Trim() + ": " + item2.tenKH.Trim();// + "    || Example: " + item2.Example;
                CombomCollection.Add(cb);
            }


            beeselectinput choosesl = new beeselectinput("Chọn khách hàng vận tải", CombomCollection);
            choosesl.ShowDialog();

            if (choosesl.kq == true)
            {
                string makh = choosesl.value;
                String tenkh = choosesl.valuetext;
                //string connection_string = Utils.getConnectionstr();

                //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                var rs1 = Model.Nhacungcap.danhsachgiatheotuyenvamanhavantai(dc, makh);
                Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH GIÁ THEO TUYẾN CỦA KHÁCH HÀNG " + tenkh.ToUpper(), 11, makh);// mã 8 là danh sach nha nha van tai

                viewtbl.Show();
            }
        }

        private void danhSáchNhàCungCấpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            #region//dsnhacungcap

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachNhacungcap(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH NHÀ CUNG CẤP", 5, "tk");// mã 5 là danh sach nha cung cap

            viewtbl.Show();


            #endregion

        }

        private void đăngKýTàiKhoảnTheoDõiChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void sổCânĐốiTàiKhoảnPhátSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region//bccan doi ke toan
            //if (name == "bcsonhatkychung")
            //{

            Model.Soketoan.bangcandoiphatsinhtaikhoan();

            //  }
            #endregion




        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {



        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {


        }

        private void hạchToánKếToánToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void hệThốngKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hệThốngTàiKhoảnKếToánToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void sổQuỹToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void phiếuChiToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void phiếuThuToolStripMenuItem1_Click(object sender, EventArgs e)
        {



        }

        private void bútToánTổngHợpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            #region//btoanth



            clearpannel();


            View.BeeButtoantonghop buttoantonghop = new BeeButtoantonghop(this);
            clearpannelload(buttoantonghop);



            #endregion

        }

        private void danhSáchKhoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void danhSáchNhómSảnPhẩmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


        }

        private void danhSáchSảnPhẩmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void phiếuNhậpKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void phiếuXuấtKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoNhậpXuấtTồnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void bánHàngTạiCửaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mởKỳKếToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.Beekyketoan view = new Beekyketoan();
            view.ShowDialog();
        }

        private void phiếuTínhGiáVàXácNhậnSảnPhẩmHoànThànhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void phiếuNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void kếToánTiềnMặtToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {

            #region//soquy


            Model.Soketoan.soQuy();


            #endregion

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            #region//tmphieuthu
            //if (name == "tmphieuthu")
            //{

            //  Main.clearpannel();
            //   Formload.
            // clearpannel();
            clearpannel();


            View.BeePhieuThu accsup = new BeePhieuThu(this);
            clearpannelload(accsup);
            //    accsup.TopLevel = false;
            //  accsup.AutoScroll = true;
            //    panelmain.Controls.Add(accsup);
            //    accsup.Show();

            //   }
            #endregion

        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {

        }

        private void danhSáchNhàCungỨngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    NPDanhsachnhavantai
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Nhacungcap.danhsachNhacungcap(dc);
            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH NHÀ CUNG CẤP", 5, "tk");// mã 5 là danh sach nha nha ccaaps

            viewtbl.Show();

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void thôngTínDoanhNghiệpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            View.BeeThongtindoanhnghiep view = new BeeThongtindoanhnghiep();
            view.ShowDialog();
        }

        private void danhSáchLoạiTàiKhoảnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            #region//dsloaitk
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs8 = Model.loaitaikhoanketoan.danhsachloaitaikhoan(dc);
            Viewtable viewtblrs8 = new Viewtable(rs8, dc, "DANH SÁCH LOẠI TÀI KHOẢN", 1, "tk");// danh sach loại tài khoản kế toán

            viewtblrs8.Show();


            #endregion
        }

        private void hệThốngTàiKhoảnKếToánToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {

            #region//dstaikhoanketoan
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rs = Model.Taikhoanketoan.danhsachtaikhoan(dc);
            Viewtable viewtblrs55 = new Viewtable(rs, dc, "DANH SÁCH TÀI KHOẢN KẾ TOÁN", 0, "tk");// view code 0 la danh sach tai khoan ke toan

            viewtblrs55.Show();

            #endregion

        }

        private void đăngKýTàiKhoảnTheoDõiChiTiếtToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            #region//dstaikhoanketoan
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rs = Model.Taikhoanketoan.danhsachtaikhoandangkychitiet(dc);
            Viewtable viewtblrs55 = new Viewtable(rs, dc, "DANH SÁCH TÀI KHOẢN KẾ TOÁN ĐĂNG KÝ THEO DÕI CHI TIẾT", 114, "tk");// view code 114 la dang ký tài khoản kế toán

            viewtblrs55.Show();

            #endregion

        }

        private void mởSốChiTiếtTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region//sochitiet
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = Model.Danhsachtkchitiet.danhsachtaikhoanchitiet(dc);

            Viewtable viewtbl = new Viewtable(rs1, dc, "DANH SÁCH MÃ CHI TIẾT TÀI KHOẢN", 2, "tk");// view code 2 mo so chi tiet tai khoan
            viewtbl.Show();



            #endregion

        }

        private void đơnBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bánHàngTạiQuầyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void phảiThuToolStripMenuItem_Click(object sender, EventArgs e)
        {

           


        }

        private void phiếuThuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            #region//tmphieuthu
            //if (name == "tmphieuthu")
            //{

            //  Main.clearpannel();
            //   Formload.
            // clearpannel();
            clearpannel();


            View.BeePhieuThu accsup = new BeePhieuThu(this);
            clearpannelload(accsup);
            //    accsup.TopLevel = false;
            //  accsup.AutoScroll = true;
            //    panelmain.Controls.Add(accsup);
            //    accsup.Show();

            //   }
            #endregion

        }

        private void phiếuChiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            #region//tmphieuchi


            //  Main.clearpannel();

            clearpannel();


            View.BeePhieuchi accsup = new BeePhieuchi(this);
            clearpannelload(accsup);
            //    accsup.TopLevel = false;
            //  accsup.AutoScroll = true;
            //    panelmain.Controls.Add(accsup);
            //    accsup.Show();


            #endregion

        }

        private void sổQuỹToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            #region//soquy


            Model.Soketoan.soQuy();


            #endregion
        }

        private void phiếuNhậpKhoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            #region//khophieuxuat

            //  Main.clearpannel();

            clearpannel();


            View.BeeKhophieuxuat accsup = new BeeKhophieuxuat(this);
            clearpannelload(accsup);
            //    accsup.TopLevel = false;
            //  accsup.AutoScroll = true;
            //    panelmain.Controls.Add(accsup);
            //    accsup.Show();


            #endregion

        }

        private void báoCáoNhậpXuấtTồnToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            #region//bcxuatnhapton


            Model.Soketoan.sotonghopbaocaonhapxuatton();

            #endregion

        }

        private void danhSáchKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            #region//khodskho
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs5 = Model.Khohang.Danhsachkho(dc);
            Viewtable viewtbl66 = new Viewtable(rs5, dc, "DANH SÁCH KHO HÀNG", 4, "tk");// mã 4 là danh sách kho

            viewtbl66.Show();

            //  }
            #endregion

        }

        private void danhSáchNhómSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            #region//khonhomsanpham

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs6 = Model.Khohang.danhsachnhomsanpham(dc);
            Viewtable viewtbl2 = new Viewtable(rs6, dc, "DANH SÁCH NHÓM SẢN PHẨM", 6, "tk");// mã 6 là danh sách nhóm sản phẩm

            viewtbl2.Show();

            #endregion

        }

        private void phảiThuToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            //#region//btoanth



            //clearpannel();


            //View.BeePhaithu BeePhaithu = new BeePhaithu(this);
            //clearpannelload(BeePhaithu);



            //#endregion


        }

        private void danhSáchSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {



            #region//BeeDanhsachsanpham

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs6 = Model.Khohang.danhsachnhomsanpham(dc);
            Viewtable viewtbl2 = new Viewtable(rs6, dc, "DANH SÁCH SẢN PHẨM", 7, "tk");// mã 7 là danh sách  sản phẩm


       //     xxxx
            viewtbl2.Show();

            #endregion






        }

        private void tờKêPhátSinhNợTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region//btoanth



            clearpannel();


            View.Toketheotaikhoan Toketheotaikhoan = new Toketheotaikhoan(this);
            clearpannelload(Toketheotaikhoan);



            #endregion

        }
    }



}



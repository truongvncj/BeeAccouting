using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEEACCOUNT.Control;
using BEEACCOUNT.shared;
using System.Globalization;
using System.Threading;
using BEEACCOUNT.Model;
using System.Data.SqlClient;

namespace BEEACCOUNT.View
{

    //   public static DataGridView dataGridView2;// = new DataGridView();

    public partial class Viewtable : Form
    {

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public int viewcode;
        public IQueryable rs;
        LinqtoSQLDataContext db;
        public DataGridView Dtgridview;


        public static string connection_string = Utils.getConnectionstr();

        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


        //   public List<ComboboxItem> dataCollectionaccount;

        //  public List<ComboboxItem> dataCollectiongroup;//{ get; private set; }
        //1. Định nghĩa 1 delegate


        class datatoExport
        {
            //public DataGridView dataGrid1 { get; set; }
            public System.Data.DataTable datatble { get; set; } // = new System.Data.DataTable();
        }


        public void sumtitleGrid(object inptgridobjiec)
        {

            datatoExport dat = (datatoExport)inptgridobjiec;
            System.Data.DataTable datatble = dat.datatble;
            //    DataGridView dataGrid1 = new DataGridView();
            //   dataGrid1.DataSource = datatble;
            //      double k = dataGrid1.Rows.Count;
            int k = datatble.Rows.Count;
            double Billed_Qty = 0;
            double GSR = 0;
            double UC = 0;
            double PC = 0;
            double NSR = 0;

            try
            {

                for (int i = 0; i < k; i++)
                {
                    #region forr

                    //  datatble.Columns["Billed_Qty"].v


                    if (datatble.Rows[i]["PCs"] != null && Utils.IsValidnumber(datatble.Rows[i]["PCs"].ToString()))
                    {

                        Billed_Qty += double.Parse(datatble.Rows[i]["PCs"].ToString());
                    }

                    if (datatble.Rows[i]["NSR"] != null && Utils.IsValidnumber(datatble.Rows[i]["NSR"].ToString()))
                    {

                        NSR += double.Parse(datatble.Rows[i]["NSR"].ToString());
                    }
                    if (datatble.Rows[i]["UC"] != null && Utils.IsValidnumber(datatble.Rows[i]["UC"].ToString()))
                    {

                        UC += double.Parse(datatble.Rows[i]["UC"].ToString());
                    }
                    if (datatble.Rows[i]["EC"] != null && Utils.IsValidnumber(datatble.Rows[i]["EC"].ToString()))
                    {

                        PC += double.Parse(datatble.Rows[i]["EC"].ToString());
                    }
                    if (datatble.Rows[i]["GSR"] != null && Utils.IsValidnumber(datatble.Rows[i]["GSR"].ToString()))
                    {

                        GSR += double.Parse(datatble.Rows[i]["GSR"].ToString());
                    }

                    //======



                    #endregion forr
                }



                //     Billed_Qty = 100;
                this.lb_bilingqtt.Invoke(new UpdateTextCallback(this.UpdateText),
                                             new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });


                this.lb_netvalue.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });



                this.lb_countvalue.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });


                this.lb_pc.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });


                this.lb_uc.Invoke(new UpdateTextCallback(this.UpdateText),
                                                 new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });

                //   MyGetData( tongamount,  tongdeposit,  fullGoodamount,  sumempty);
            }
            catch (Exception)
            {
                Thread.CurrentThread.Abort();
                //       MessageBox.Show(ex.ToString());

                // MessageBox.Show(hh44.ToString());


            }




        }



        private void UpdateText(string Billed_Qty, string NSR, string UC, string PC, string GSR)
        {


            this.lb_bilingqtt.Text = double.Parse(Billed_Qty).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_netvalue.Text = double.Parse(GSR).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_countvalue.Text = double.Parse(NSR).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_pc.Text = double.Parse(PC).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_uc.Text = double.Parse(UC).ToString("#,#", CultureInfo.InvariantCulture);

            this.Status.Text = "DONE";
            //  this.dataGridView1.Refresh();
        }

        public delegate void UpdateTextCallback(string Billed_Qty, string NSR, string UC, string PC, string GSR);
        //    In your thread, you can call the Invoke method on m_TextBox, passing the delegate to call, as well as the parameters.



        //public void Reloadcustomer(String inutstring)

        //{
        //    string connection_string = Utils.getConnectionstr();
        //    //      UpdateDatagridview
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    //   LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    var rsthisperiod = from tbl_KaCustomer in dc.tbl_PosCustomers
        //                       where ((int)tbl_KaCustomer.Customer).ToString().Contains(inutstring)
        //                       select tbl_KaCustomer;

        //    Utils ut = new Utils();
        //    dt = ut.ToDataTable(dc, rsthisperiod);

        //    this.dataGridView1.DataSource = dt;


        //}



        void Control_KeyPress(object sender, KeyEventArgs e)
        {
            // if (viewcode == 2)// nuew la bàng salsetemp update

            if ((viewcode == 2) && e.KeyCode == Keys.F3)
            {





                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    if (frm.Text == "tblsales")


                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {
                    Seachcode sheaching = new Seachcode(this, "tblsales");
                    sheaching.Show();
                }




            }


        }


        public BindingSource source2;
        public Viewtable(IQueryable rs, LinqtoSQLDataContext dc, string fornname, int viewcode)
        {
            //    this.dataGridView1.DataSource = rs;
            InitializeComponent();



            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);

            this.dataGridView1.DataSource = rs;
            this.Dtgridview = dataGridView1;

            this.db = dc;
            this.viewcode = viewcode;
            this.rs = rs;
            this.lb_seach.Text = "F3 TÌM KIẾM";
            //      this.bt_sendinggroup.Visible = false;
            this.lb_seach.Visible = false;
            this.Pl_endview.Visible = false;
         //   gboxUnpaid.Visible = false; // an nhom field upaid

            this.formlabel.Text = fornname;

            bt_addtomaster.Visible = false;
            this.bt_addtomaster.Visible = false;

            this.lb_totalrecord.Text = dataGridView1.RowCount.ToString("#,#", CultureInfo.InvariantCulture);// ;//String.Format("{0:0,0}", k33q); 
                                                                                                            //  this.lb_totalrecord.ForeColor = Color.Chocolate;
                                                                                                            //   this.Show();
            this.KeyPreview = true;

            //if (viewcode == 5)// tuwc la view mastercontract
            //{
            //    #region viewcode = 5 tuwc la view mastercontract
            //    #region  format lsstmatercontracts
            //    //                  tbl_kacontractdata.ContractNo,
            //    //                           tbl_kacontractdata.SalesOrg,
            //    //                           tbl_kacontractdata.ConType,//contract type
            //    //                           tbl_kacontractdata.Consts, //contract status
            //    //                           tbl_kacontractdata.Currency,
            //    //                           Validfrom = tbl_kacontractdata.EffDate,
            //    //                           Validto = tbl_kacontractdata.EftDate,

            //    //                           tbl_kacontractdata.Customer,
            //    //                           tbl_kacontractdata.Fullname,
            //    //                           tbl_kacontractdata.Channel,
            //    //                           FullCommitment = tbl_kacontractdata.TotSponsoredcommit,
            //    this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    //                           AchivedCommitment = tbl_kacontractdata.TotDeal,
            //    this.dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["AchivedCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dataGridView1.Columns["AchivedCommitment"].HeaderText = "Achived Commitment";

            //    //                           tbl_kacontractdata.Tot_paid,
            //    this.dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["Tot_paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dataGridView1.Columns["Tot_paid"].HeaderText = "Total Paid";

            //    //                           Balance = tbl_kacontractdata.TotDeal - tbl_kacontractdata.Tot_paid,
            //    this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //                                                                                                                //       this.dataGridView1.Columns["Balance"].HeaderText = "Total Paid";
            //                                                                                                                //                           VolumeCommit = tbl_kacontractdata.VolComm,
            //    this.dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["VolumeCommit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dataGridView1.Columns["VolumeCommit"].HeaderText = "Volume Commit";

            //    //                           tbl_kacontractdata.PCVolAched,
            //    this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dataGridView1.Columns["PCVolAched"].HeaderText = "PC VolAched";

            //    //                           tbl_kacontractdata.NSRAched,
            //    this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dataGridView1.Columns["NSRAched"].HeaderText = "NSR Ached";


            //    //                           tbl_kacontractdata.UCVolAched,
            //    this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dataGridView1.Columns["UCVolAched"].HeaderText = "UC VolAched";

            //    //                           tbl_kacontractdata.CRDDAT,
            //    //                           tbl_kacontractdata.CRDUSR,



            //    #endregion


            //    #endregion viewcpde = 5
            //}


            //if (viewcode == 4)// tuwc la view detailcontract
            //{

            //    #region format





            //    //ContractNo = tbl_kacontractsdatadetail.ContractNo,
            //    //Region = tbl_kacontractsdatadetail.SalesOrg,

            //    //Constatus = tbl_kacontractsdatadetail.Constatus,
            //    //Contracttype = tbl_kacontractsdatadetail.ConType,
            //    //EffFrm = tbl_kacontractsdatadetail.EffFrm,

            //    //EffTo = tbl_kacontractsdatadetail.EffTo,
            //    //CustomerCode = tbl_kacontractsdatadetail.Customercode,
            //    //EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
            //    //CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,

            //    //PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
            //    this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //                                                                                                                   //UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
            //    this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    //LitAched = tbl_kacontractsdatadetail.LitAched,
            //    this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    //FTNAched = tbl_kacontractsdatadetail.ECAched,
            //    this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    //NSRAched = tbl_kacontractsdatadetail.NSRAched,
            //    this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //                                                                                                                 //AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
            //    this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    //PayControl = tbl_kacontractsdatadetail.PayControl,


            //    //Description = tbl_kacontractsdatadetail.Description,
            //    //PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
            //    //FundPercentage = tbl_kacontractsdatadetail.FundPercentage,
            //    //SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
            //    this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    //AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
            //    //FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,

            //    this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    //CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
            //    this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //                                                                                                                          //TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
            //    this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //                                                                                                                  //Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)


            //    this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";



            //    #endregion


            //}

            //if (viewcode == 1 || viewcode == 2)// nếu là hiện salevolum ta cộng salesvolume
            //{
            //    #region view code = 1 hoac 2


            //    Pl_endview.Visible = true;
            //    bt_addtomaster.Visible = true;

            //    if (viewcode == 2)
            //    {
            //        bt_addtomaster.Visible = false;
            //        lb_seach.Visible = true;




            //        this.dataGridView1.Columns["PCs"].DefaultCellStyle.Format = "N0";
            //        this.dataGridView1.Columns["GSR"].DefaultCellStyle.Format = "N0";

            //        this.dataGridView1.Columns["Litter"].DefaultCellStyle.Format = "N0";
            //        this.dataGridView1.Columns["NSR"].DefaultCellStyle.Format = "N0";


            //        this.dataGridView1.Columns["EC"].DefaultCellStyle.Format = "N0";
            //        this.dataGridView1.Columns["UC"].DefaultCellStyle.Format = "N0";


            //    }

            //    #region// tính sum of biliing q ty, ....




            //    #endregion

            //    System.Data.DataTable dt = new System.Data.DataTable();



            //    Utils ut = new Utils();
            //    dt = ut.ToDataTable(db, rs);



            //    this.dataGridView1.DataSource = dt;


            //    this.Status.Text = "Caculating ...";

            //    Thread tt1 = new Thread(sumtitleGrid);

            //    tt1.IsBackground = true;
            //    tt1.Start(new datatoExport() { datatble = dt });

            //#endregion




            //}



        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            foreach (var c in dataGridView1.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

            // Next


        }

        private void bt_exporttoex_Click(object sender, EventArgs e)
        {
            Control_ac ctrex = new Control_ac();


             ctrex.exportexceldatagridtofile(this.rs, this.db, this.Text);




        }
    }


    

   
}

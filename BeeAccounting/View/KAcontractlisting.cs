using BEEACCOUNT.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BEEACCOUNT.View
{
    public partial class KAcontractlisting : Form
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


        public IQueryable rs;
    //    LinqtoSQLDataContext db;
        public DataGridView Dtgridview;
        public List<ComboboxItem> dataCollectionaccount;

        public List<ComboboxItem> dataCollectiongroup;//{ get; private set; }
                                                      //1. Định nghĩa 1 delegate


        class datatoExport
        {
            public DataGridView dataGrid1 { get; set; }

        }

        public KAcontractlisting(IQueryable rs, LinqtoSQLDataContext db, string fornname)
        {
            InitializeComponent();

            //this.KeyPreview = true;
            //this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);

            //filterlabel.Visible = false;
            //cbcontracttypefil.Visible = false;
            //this.db = db;

            //this.rs = rs;

            //if (fornname == "Accrual reports detail")
            //{

            //    button1.Visible = false;
            //    Bt_Adddata.Visible = false;
            //    label1.Text = "                                                        F7: Detail list     F8: Master list";

            //}
            //this.dataGridView1.DataSource = rs;
            //if (this.dataGridView1.Columns["ContractNo"] != null)
            //{
            //    this.dataGridView1.Columns["ContractNo"].DefaultCellStyle.ForeColor = Color.DarkBlue;
            //    this.dataGridView1.Columns["ContractNo"].DefaultCellStyle.BackColor = Color.LightYellow;


            //}

        
            //this.formname.Text = fornname;
            //if ((fornname == "Input Contract" || fornname == "Payment Input") && statusview.Text == "Master")
            //{

            //    Control.Control_ac.FormatViewcontractmaster(this.dataGridView1);



            //}

            //if ((fornname == "Input Contract" || fornname == "Payment Input") && statusview.Text == "Master")
            //{

            //    filterlabel.Visible = true;
            //    cbcontracttypefil.Visible = true;

            //    string username = Utils.getusername();

            //    var typecontract = from Tka_RightContracttypeview in db.Tka_RightContracttypeviews
            //                       where Tka_RightContracttypeview.UserName == username
            //                       select Tka_RightContracttypeview.Contracttype;


            //    this.cbcontracttypefil.Items.Clear();

            //    foreach (var item in typecontract)
            //    {
            //        cbcontracttypefil.Items.Add(item);
            //    }

         //   }

            if (fornname == "Accrual reports detail")
            {

                //#region formta detail accrual


                ////   ContractNo = tbl_kacontractsdatadetail.ContractNo,
                ////             Region = tbl_kacontractsdatadetail.SalesOrg,

                ////             Constatus = tbl_kacontractsdatadetail.Constatus,
                ////             Contracttype = tbl_kacontractsdatadetail.ConType,
                //this.dataGridView1.Columns["Contracttype"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["Contracttype"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //this.dataGridView1.Columns["Contracttype"].HeaderText = "Contract Type";
                ////             EffFrm = tbl_kacontractsdatadetail.EffFrm,

                ////             EffTo = tbl_kacontractsdatadetail.EffTo,
                ////             CustomerCode = tbl_kacontractsdatadetail.Customercode,
                //this.dataGridView1.Columns["CustomerCode"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["CustomerCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //this.dataGridView1.Columns["CustomerCode"].HeaderText = "Customer Code";
                ////             EftNoOfMonth = tbl_kacontractsdatadetail.EftNoOfMonth,
                ////             CurrentMonth = tbl_kacontractsdatadetail.CurrentMonth,

                ////             PCVolAched = tbl_kacontractsdatadetail.PCVolAched,
                //this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["PCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //                                                                                                               //  this.dataGridView1.Columns["CustomerCode"].HeaderText = "Customer Code";
                //                                                                                                               //             UCVolAched = tbl_kacontractsdatadetail.UCVolAched,
                //this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["UCVolAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
                //                                                                                                               //  this.dataGridView1.Columns["CustomerCode"].HeaderText = "Customer Code";
                //                                                                                                               //             LitAched = tbl_kacontractsdatadetail.LitAched,
                //this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["LitAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ////             FTNAched = tbl_kacontractsdatadetail.ECAched,
                //this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["FTNAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ////             NSRAched = tbl_kacontractsdatadetail.NSRAched,
                //this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["NSRAched"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ////             AccruedAmt = tbl_kacontractsdatadetail.AccruedAmt,
                //this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["AccruedAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ////             PayControl = tbl_kacontractsdatadetail.PayControl,
                ////             Description = tbl_kacontractsdatadetail.Description,
                ////             PrdGrp = tbl_kacontractsdatadetail.PrdGrp,
                ////             FundPercentage = tbl_kacontractsdatadetail.FundPercentage,

                ////             SponsoredAmtperPC = tbl_kacontractsdatadetail.SponsoredAmtperPC,
                //this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["SponsoredAmtperPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ////             AccruedDate = tbl_kacontractsdatadetail.AccruedDate,
                ////             FullCommitment = tbl_kacontractsdatadetail.SponsoredAmt,
                //this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["FullCommitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridView1.Columns["FullCommitment"].HeaderText = "SponsoredAmt (Full commitment)";
                ////             CommitmentCurrent = tbl_kacontractsdatadetail.SponsoredTotal,
                //this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["CommitmentCurrent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridView1.Columns["CommitmentCurrent"].HeaderText = "Commitment Current";
                ////             TotalPaid = tbl_kacontractsdatadetail.PaidAmt,
                //this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["TotalPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridView1.Columns["TotalPaid"].HeaderText = "Total Paid";
                ////             Balance = tbl_kacontractsdatadetail.Balance, //(to be accrual)
                //this.dataGridView1.Columns["Balance"].DefaultCellStyle.Format = "N0";
                //this.dataGridView1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //this.dataGridView1.Columns["Balance"].HeaderText = "Balance (to be accrual)";
                //#endregion


            }

        }


        void Control_KeyPress(object sender, KeyEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control_ac ctrex = new Control_ac();


       //     ctrex.exportExceldatagridtofile(this.rs, this.db, this.Text);

        }


        private void button1_Click(object sender, EventArgs e)
        {


            //Thread t1 = new Thread(Control.Control_ac.CaculationALLContractinSQL);
            //t1.IsBackground = true;
            //t1.Start();

            //Thread t2 = new Thread(Control.Control_ac.showwait);
            //t2.Start();
            ////   autoEvent.WaitOne(); //join
            //t1.Join();
            //if (t1.ThreadState != ThreadState.Running)
            //{


            //    Thread.Sleep(100);
            //    t2.Abort();

        
            //    System.Data.DataTable dt = new System.Data.DataTable();
            
            //    string connection_string = Utils.getConnectionstr();
            //    string username = Utils.getusername();

            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);



            //    Utils ut = new Utils();
            //    dt = ut.ToDataTable(db, rs);
            //    this.rs = rs;
            //    this.dataGridView1.DataSource = dt;


            //}









        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        //private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string ContractNo = "";
        //    try
        //    {
        //         ContractNo = (string)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ContractNo"].Value;
        //    }
        //    catch (Exception)
        //    {

        //        return;
        //       // throw;
        //    }
            
        //    string connection_string = Utils.getConnectionstr();

        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


        //    var rs = (from tbl_kacontractdata in dc.tbl_kacontractdatas
        //             where tbl_kacontractdata.ContractNo == ContractNo
        //             select tbl_kacontractdata.ContractNo).FirstOrDefault();
        //    if (rs == null)
        //    {
        //        MessageBox.Show("Please select another contract !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

                     
        //    if (this.formname.Text == "Input Contract")
        //    {
        //        if (ContractNo != "" && ContractNo != null)
        //        {
        //            CreatenewContract newcontrac = new CreatenewContract("ENTRY SCREEN DISPLAY CONTRACT", ContractNo);
        //            newcontrac.Text = "Input Contract";
        //            newcontrac.ShowDialog();
        //        //    newcontrac.BringToFront();
        //            newcontrac.Focus();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please check contract no", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }


        //    }

        //    if (this.formname.Text == "Payment Input")
        //    {
        //        if (ContractNo != "" && ContractNo != null)
        //        {
        //            CreatenewContract newcontrac = new CreatenewContract("DISPLAY PAYMENT CONTRACT", ContractNo);
        //            newcontrac.Text = "Payment Input";
        //            newcontrac.ShowDialog();
        //     //     newcontrac.BringToFront();
        //            newcontrac.Focus();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please check contract no", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }


        //    }
        //    ///




        //    if (this.formname.Text == "Accrual reports detail" || this.formname.Text == "Accrual reports master")
        //    {
        //        if (ContractNo != "" && ContractNo != null)
        //        {
        //            CreatenewContract newcontrac = new CreatenewContract("VIEW SCREEN DISPLAY CONTRACT", ContractNo);
        //            newcontrac.Text = "Display Contract";
        //            newcontrac.ShowDialog();
        //    //        newcontrac.BringToFront();
        //            newcontrac.Focus();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please check contract no", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }


        //    }


        //}

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void statusview_Click(object sender, EventArgs e)
        {

        }

        private void Bt_Adddata_Click(object sender, EventArgs e)
        {

        }

        //private void cbcontracttypefil_SelectedValueChanged(object sender, EventArgs e)
        //{

        //    string contractype = cbcontracttypefil.Text;
        //    ReloadKASeachcontractype("","","",contractype);



        //}



    }
}

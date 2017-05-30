using BEEACCOUNT.View;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BEEACCOUNT.Model
{
    class Contract
    {



        public bool deleteallbegincontract()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            // var rs = from tbl_Remark in db.tbl_Remarks
            //            select tbl_Remark;
          db.ExecuteCommand("DELETE FROM tbl_kacontractbegindata");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();
            return true;
        }



        //var rsdetaildele = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
        //                    where tbl_kacontractsdetailpayment.ContractNo.Equals(ContractNoin)
        //                    && tbl_kacontractsdetailpayment.BatchNo == 0
        //                    select tbl_kacontractsdetailpayment);
        //if (rsdetaildele != null)
        //{
        //    dc.tbl_kacontractsdetailpayments.DeleteAllOnSubmit(rsdetaildele);
        //    dc.SubmitChanges();

        //}




        //public static bool checkispaidandalive(string contractNo)
        //{
        //    string connection_string = Utils.getConnectionstr();
        //    var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = (from tbl_kacontractsdetailpayment in db.tbl_kacontractsdetailpayments
        //               where tbl_kacontractsdetailpayment.ContractNo.Equals( contractNo) && tbl_kacontractsdetailpayment.PayControl == "REQ" 
        //               && tbl_kacontractsdetailpayment.BatchNo != 0
        //              select tbl_kacontractsdetailpayment.ContractNo).FirstOrDefault();

        //    var rs1 = (from tbl_kacontractdata in db.tbl_kacontractdatas
        //               where tbl_kacontractdata.ContractNo == contractNo && tbl_kacontractdata.Consts != "ALV"
        //               select tbl_kacontractdata.Consts).FirstOrDefault();

        //    if (rs != null || rs1!= null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
            
        //}


        public bool deleteallcontractbegindetail()
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);
            // var rs = from tbl_Remark in db.tbl_Remarks
            //            select tbl_Remark;

            db.ExecuteCommand("DELETE FROM tbl_kacontractbegindatadetail");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();
            return true;
        }


        //public IQueryable Setlect_all_begin(LinqtoSQLDataContext db)
        //{

        //    //var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = from tbl_kacontractbegindata in db.tbl_kacontractbegindatas
        //             select tbl_kacontractbegindata;

        //    return rs;

        //}




        class datainportF
        {

            public string filename { get; set; }

        }



        public void inputcontract()
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Contract excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();


                Thread t1 = new Thread(importexcelcontract);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });


                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {



                    Thread.Sleep(1211);
                    t2.Abort();
                }





            }


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }

        public void inputcontractdetail()
        {


            //      BackgroundWorker backgroundWorker1;
            //   CultureInfo provider = CultureInfo.InvariantCulture;
            //     backgroundWorker1 = new BackgroundWorker();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Contract excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName.ToString();


                Thread t1 = new Thread(importexcelcontractdetail);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });


                Thread t2 = new Thread(showwait);
                t2.Start();
                //   autoEvent.WaitOne(); //join
                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {



                    Thread.Sleep(1211);
                    t2.Abort();
                }





            }


            // MessageBox.Show(theDialog.FileName.ToString());
            //    return true;

            //    


        }

        private void showwait()
        {
            View.BeeCaculating wat = new View.BeeCaculating();
            wat.ShowDialog();


        }


        private void importexcelcontract(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();
            //Contract Rm = new Contract();

            //bool kq = Rm.deleteallbegincontract();



            datainportF inf = (datainportF)obj;

            string filename = inf.filename;

            string connectionString = "";
            if (filename.Contains(".xlsx") || filename.Contains(".XLSX"))
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";" + "Extended Properties=Excel 12.0;";
            }
            else
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + filename + ";" + "Extended Properties=Excel 8.0;";
            }

            //------
            //---------------fill data

            System.Data.DataTable sourceData = new System.Data.DataTable();
            using (OleDbConnection conn =
                                   new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Open connextion !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // Get the data from the source table as a SqlDataReader.

          //            

OleDbCommand command = new OleDbCommand(
                                    @"SELECT ContractNo, SalesOrg,Consts,
ConType, MEANo,EffDate,
EftDate, ExtDate,Customer,


Representative, Channel,DeliveredBy,
CreditLimit, CreditTerm,ConTerm,
AnnualVolume, VolComm,UN,
NSRComm, NSRPer,PrdGrp,
Revenue, VolAched,VolAched_S,
VolPer, VolPer_S,LitPer,
LitAched, FTNAched,NSRAched,
TotDeal, Currency,Cash,
POS, FreeGood,Promotion,


MKTFunPer, MKTFun,Cash_Acc,
POS_Acc, FreeGood_Acc,Promotion_Acc,
MKTFun_Acc, SponsorPerCase,TotDealPC,
CashPC, POSPC,FreeGoodPC,
PromotionPC, MKTFunPC,Tot_paid,
Cash_paid, POS_paid,FreeGood_paid,
Promotion_paid, MKTFun_paid,Tot_rem,
Cash_rem, POS_rem,FreeGood_rem,
Promotion_rem, MKTFun_rem,Remarks,
CRDDAT, CRDUSR,UPDDAT,


UPDUSR, BatchNo,SignOn,
MFD, SALORG_CTR,EftNoOfMonth,
CurrentMonth



                                     FROM [Sheet1$]
                                     WHERE ( ContractNo is not null ) ", conn);


                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                //adapter.FillSchema(sourceData, SchemaType.Source);
                //sourceData.Columns["Posting Date"].DataType = typeof(DateTime);
                //sourceData.Columns["Invoice Doc Nr"].DataType = typeof(float);
                //sourceData.Columns["Billed Qty"].DataType = typeof(float);
                //sourceData.Columns["Cond Value"].DataType = typeof(float);
                //sourceData.Columns["Sales Org"].DataType = typeof(string);
                //sourceData.Columns["Cust Name"].DataType = typeof(string);
                //sourceData.Columns["Outbound Delivery"].DataType = typeof(string);
                //sourceData.Columns["Mat Group"].DataType = typeof(string);
                //sourceData.Columns["Mat Group Text"].DataType = typeof(string);
                //sourceData.Columns["UoM"].DataType = typeof(string);


                try
                {

                    adapter.Fill(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }

            //   Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                //                @"SELECT ContractNo, SalesOrg,ConType,
                //  Consts, Currency,EffDate,
                //  ExtDate, Customer,CustomerGroup,
                //  FullName, Channel,TotDeal,
                //  Tot_paid, Tot_rem,VolComm,
                //  VolAched, VolPer,CRDDAT,
                //  CRDUSR, UPDDAT,UPDUSR,
                //  SignOn



                bulkCopy.DestinationTableName = "tbl_kacontractbegindata";
                // Write from the source to the destination.

                bulkCopy.ColumnMappings.Add("ContractNo", "ContractNo");
                bulkCopy.ColumnMappings.Add("SalesOrg", "SalesOrg");
                bulkCopy.ColumnMappings.Add("Consts", "Consts");
                bulkCopy.ColumnMappings.Add("ConType", "ConType");
                bulkCopy.ColumnMappings.Add("MEANo", "MEANo");
                bulkCopy.ColumnMappings.Add("EffDate", "EffDate");
                bulkCopy.ColumnMappings.Add("EftDate", "EftDate");
                bulkCopy.ColumnMappings.Add("ExtDate", "ExtDate");
                bulkCopy.ColumnMappings.Add("Customer", "Customer");
                bulkCopy.ColumnMappings.Add("Representative", "Representative");
                bulkCopy.ColumnMappings.Add("Channel", "Channel");
                bulkCopy.ColumnMappings.Add("DeliveredBy", "DeliveredBy");
                bulkCopy.ColumnMappings.Add("CreditLimit", "CreditLimit");
                bulkCopy.ColumnMappings.Add("CreditTerm", "CreditTerm");
                bulkCopy.ColumnMappings.Add("ConTerm", "ConTerm");
                bulkCopy.ColumnMappings.Add("AnnualVolume", "AnnualVolume");
                bulkCopy.ColumnMappings.Add("VolComm", "VolComm");
                bulkCopy.ColumnMappings.Add("UN", "UN");
                bulkCopy.ColumnMappings.Add("NSRComm", "NSRComm");
                bulkCopy.ColumnMappings.Add("PrdGrp", "PrdGrp");
                bulkCopy.ColumnMappings.Add("Revenue", "Revenue");


                bulkCopy.ColumnMappings.Add("VolAched", "VolAched");




                bulkCopy.ColumnMappings.Add("VolAched_S", "VolAched_S");
                bulkCopy.ColumnMappings.Add("VolPer", "VolPer");
                bulkCopy.ColumnMappings.Add("VolPer_S", "VolPer_S");
                bulkCopy.ColumnMappings.Add("LitPer", "LitPer");
                bulkCopy.ColumnMappings.Add("LitAched", "LitAched");
                bulkCopy.ColumnMappings.Add("FTNAched", "FTNAched");
                bulkCopy.ColumnMappings.Add("NSRAched", "NSRAched");
                bulkCopy.ColumnMappings.Add("TotDeal", "TotDeal");
                bulkCopy.ColumnMappings.Add("Currency", "Currency");
                bulkCopy.ColumnMappings.Add("Cash", "Cash");
                bulkCopy.ColumnMappings.Add("POS", "POS");
                bulkCopy.ColumnMappings.Add("FreeGood", "FreeGood");
                bulkCopy.ColumnMappings.Add("Promotion", "Promotion");
                bulkCopy.ColumnMappings.Add("MKTFunPer", "MKTFunPer");
                bulkCopy.ColumnMappings.Add("MKTFun", "MKTFun");
                bulkCopy.ColumnMappings.Add("Cash_Acc", "Cash_Acc");
                bulkCopy.ColumnMappings.Add("POS_Acc", "POS_Acc");
                bulkCopy.ColumnMappings.Add("FreeGood_Acc", "FreeGood_Acc");
                bulkCopy.ColumnMappings.Add("Promotion_Acc", "Promotion_Acc");
                bulkCopy.ColumnMappings.Add("MKTFun_Acc", "MKTFun_Acc");
                bulkCopy.ColumnMappings.Add("SponsorPerCase", "SponsorPerCase");
                bulkCopy.ColumnMappings.Add("TotDealPC", "TotDealPC");
                bulkCopy.ColumnMappings.Add("CashPC", "CashPC");
                bulkCopy.ColumnMappings.Add("POSPC", "POSPC");
                bulkCopy.ColumnMappings.Add("FreeGoodPC", "FreeGoodPC");
                bulkCopy.ColumnMappings.Add("PromotionPC", "PromotionPC");
                bulkCopy.ColumnMappings.Add("MKTFunPC", "MKTFunPC");
                bulkCopy.ColumnMappings.Add("Tot_paid", "Tot_paid");
                bulkCopy.ColumnMappings.Add("Cash_paid", "Cash_paid");
                bulkCopy.ColumnMappings.Add("POS_paid", "POS_paid");
                bulkCopy.ColumnMappings.Add("FreeGood_paid", "FreeGood_paid");
                bulkCopy.ColumnMappings.Add("Promotion_paid", "Promotion_paid");
                bulkCopy.ColumnMappings.Add("MKTFun_paid", "MKTFun_paid");
                bulkCopy.ColumnMappings.Add("Tot_rem", "Tot_rem");
                bulkCopy.ColumnMappings.Add("Cash_rem", "Cash_rem");
                bulkCopy.ColumnMappings.Add("POS_rem", "POS_rem");
                bulkCopy.ColumnMappings.Add("FreeGood_rem", "FreeGood_rem");
                bulkCopy.ColumnMappings.Add("Promotion_rem", "Promotion_rem");
                bulkCopy.ColumnMappings.Add("MKTFun_rem", "MKTFun_rem");
                bulkCopy.ColumnMappings.Add("Remarks", "Remarks");
                bulkCopy.ColumnMappings.Add("CRDDAT", "CRDDAT");
                bulkCopy.ColumnMappings.Add("CRDUSR", "CRDUSR");
                bulkCopy.ColumnMappings.Add("UPDDAT", "UPDDAT");
                bulkCopy.ColumnMappings.Add("UPDUSR", "UPDUSR");
                bulkCopy.ColumnMappings.Add("BatchNo", "BatchNo");
                bulkCopy.ColumnMappings.Add("SignOn", "SignOn");
                bulkCopy.ColumnMappings.Add("MFD", "MFD");
                bulkCopy.ColumnMappings.Add("SALORG_CTR", "SALORG_CTR");
                bulkCopy.ColumnMappings.Add("EftNoOfMonth", "EftNoOfMonth");
                bulkCopy.ColumnMappings.Add("CurrentMonth", "CurrentMonth");



                #region   tìm id



                #endregion




                try
                {
                    bulkCopy.WriteToServer(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Bulk Copy !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }
        }

        private void importexcelcontractdetail(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //     List<tblFBL5N> fbl5n_ctrllist = new List<tblFBL5N>();



            datainportF inf = (datainportF)obj;

            string filename = inf.filename;

            string connectionString = "";
            if (filename.Contains(".xlsx") || filename.Contains(".XLSX"))
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";" + "Extended Properties=Excel 12.0;";
            }
            else
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + filename + ";" + "Extended Properties=Excel 8.0;";
            }

            //------
            //---------------fill data

            System.Data.DataTable sourceData = new System.Data.DataTable();
            using (OleDbConnection conn =
                                   new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Open connextion !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

   


        // Get the data from the source table as a SqlDataReader.
        OleDbCommand command = new OleDbCommand(
                                    @"SELECT ContractNo, PayType,PayID,
           SubID,PayControl,Description,PrdGrp,FundPercentage,AmountPC,
               SponsoredAmt,DisAmount,VolAchvmt,Unit,CommittedDate_frm,
CommittedDate,AccruedAmt,AccruedDate,PaidOn,PaidAmt,ConfAmt,Balance,
PrintChk,BatchNo,DoneOn,IntOrdNum,APDocNum,Remark,CRDDAT,CRDUSR,
UPDDAT,UPDUSR,MFD,BLOCKED,VAT,EffFrm,EffTo,EffDays,Days,EFFPCs,EFFNSR
                                     FROM [Sheet1$]
                                     WHERE ( ContractNo is not null ) ", conn);


                OleDbDataAdapter adapter = new OleDbDataAdapter(command);




                //   adapter.FillSchema(sourceData, SchemaType.Source);
                //   sourceData.Columns["Posting Date"].DataType = typeof(DateTime);
                //   sourceData.Columns["Invoice Doc Nr"].DataType = typeof(float);
                //   sourceData.Columns["Billed Qty"].DataType = typeof(float);
                //   sourceData.Columns["Cond Value"].DataType = typeof(float);
                //   sourceData.Columns["Sales Org"].DataType = typeof(string);
                //   sourceData.Columns["Cust Name"].DataType = typeof(string);
                //   sourceData.Columns["Outbound Delivery"].DataType = typeof(string);
                //   sourceData.Columns["Mat Group"].DataType = typeof(string);
                //   sourceData.Columns["Mat Group Text"].DataType = typeof(string);
                //   sourceData.Columns["UoM"].DataType = typeof(string);


                try
                {

                    adapter.Fill(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }

            //   Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();

            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {
                bulkCopy.BulkCopyTimeout = 0;

                bulkCopy.DestinationTableName = "tbl_kacontractbegindatadetail";

                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("ContractNo", "ContractNo");
                bulkCopy.ColumnMappings.Add("PayType", "PayType");

                bulkCopy.ColumnMappings.Add("PayID", "PayID");
                bulkCopy.ColumnMappings.Add("SubID", "SubID");
                bulkCopy.ColumnMappings.Add("PayControl", "PayControl");
                
                
                bulkCopy.ColumnMappings.Add("Description", "Description");
                
                bulkCopy.ColumnMappings.Add("PrdGrp", "PrdGrp");
                bulkCopy.ColumnMappings.Add("FundPercentage", "FundPercentage");
                bulkCopy.ColumnMappings.Add("AmountPC", "AmountPC");
                bulkCopy.ColumnMappings.Add("SponsoredAmt", "SponsoredAmt");
                bulkCopy.ColumnMappings.Add("DisAmount", "DisAmount");
                bulkCopy.ColumnMappings.Add("VolAchvmt", "VolAchvmt");

                bulkCopy.ColumnMappings.Add("Unit", "Unit");

                bulkCopy.ColumnMappings.Add("CommittedDate_frm", "CommittedDate_frm");
                
                bulkCopy.ColumnMappings.Add("CommittedDate", "CommittedDate");
                bulkCopy.ColumnMappings.Add("AccruedAmt", "AccruedAmt");
                bulkCopy.ColumnMappings.Add("AccruedDate", "AccruedDate");
                bulkCopy.ColumnMappings.Add("PaidOn", "PaidOn");
                bulkCopy.ColumnMappings.Add("PaidAmt", "PaidAmt");
                bulkCopy.ColumnMappings.Add("ConfAmt", "ConfAmt");
                bulkCopy.ColumnMappings.Add("Balance", "Balance");
                bulkCopy.ColumnMappings.Add("PrintChk", "PrintChk");
                bulkCopy.ColumnMappings.Add("BatchNo", "BatchNo");
                bulkCopy.ColumnMappings.Add("DoneOn", "DoneOn");
                bulkCopy.ColumnMappings.Add("IntOrdNum", "IntOrdNum");
                bulkCopy.ColumnMappings.Add("APDocNum", "APDocNum");
                bulkCopy.ColumnMappings.Add("Remark", "Remark");

                bulkCopy.ColumnMappings.Add("CRDDAT", "CRDDAT");
                bulkCopy.ColumnMappings.Add("CRDUSR", "CRDUSR");
                bulkCopy.ColumnMappings.Add("UPDDAT", "UPDDAT");
                bulkCopy.ColumnMappings.Add("UPDUSR", "UPDUSR");
                bulkCopy.ColumnMappings.Add("MFD", "MFD");
                bulkCopy.ColumnMappings.Add("BLOCKED", "BLOCKED");
                bulkCopy.ColumnMappings.Add("VAT", "VAT");
                bulkCopy.ColumnMappings.Add("EffFrm", "EffFrm");
                bulkCopy.ColumnMappings.Add("EffTo", "EffTo");
                bulkCopy.ColumnMappings.Add("EffDays", "EffDays");

                bulkCopy.ColumnMappings.Add("Days", "Days");

                bulkCopy.ColumnMappings.Add("EFFPCs", "EFFPCs");
                bulkCopy.ColumnMappings.Add("EFFNSR", "EFFNSR");
              

                #region   tìm id



                #endregion




                try
                {
                    bulkCopy.WriteToServer(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Bulk Copy !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }
        }





    }
}

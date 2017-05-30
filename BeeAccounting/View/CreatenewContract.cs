using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEEACCOUNT.Control;
using System.Globalization;

namespace BEEACCOUNT.View
{


    public partial class CreatenewContract : Form
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


        public void loadpaymentstausgridview(IQueryable rs)
        {

            //  dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView7.DataSource = rs;



            //  throw new NotImplementedException();
        }

        public void Uploadcutomercode(String code, String name)

        {
            this.cb_customerka.Text = code;
            //this.cb_customerka.SelectedIndex = 

            ComboboxItem cb = new ComboboxItem();
            cb.Value = code;
            cb.Text = code + ": " + name;
            this.cb_customerka.Items.Add(cb); // CombomCollection.Add(cb);
            //this.cb_customerka.se = cb_customerka.Items.Count+1;
            this.cb_delivery.Items.Add(cb);



        }

        public void loadtotaldContractnew()
        {
            //       [Programe]
            //,[CommitmentAmount]
            //,[CommitmentPerPC]
            //,[CommitmentPercentage]
            //,[Total Achived]
            //,[Total Paid]
            //,[Balance]


            //#region load teamtotal
            //string connection_string = Utils.getConnectionstr();
            //string username = Utils.getusername();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //var rs1 = from tbl_KaCreatCrtracttemp in dc.tbl_KaCreatCrtracttemps
            //          where tbl_KaCreatCrtracttemp.Username == username // && tbl_KaCreatCrtracttemp.
            //          select tbl_KaCreatCrtracttemp;

            //this.dataGridViewtotal.DataSource = rs1;


            //this.dataGridViewtotal.Columns["id"].Visible = false;
            //this.dataGridViewtotal.Columns["Username"].Visible = false;
            //this.dataGridViewtotal.Columns["Total_Achived"].DefaultCellStyle.Format = "N0";
            //this.dataGridViewtotal.Columns["Total_Paid"].DefaultCellStyle.Format = "N0";
            //this.dataGridViewtotal.Columns["Total_Paid"].DefaultCellStyle.Format = "N0";
            //this.dataGridViewtotal.Columns["Balance"].DefaultCellStyle.Format = "N0";
            //this.dataGridViewtotal.Columns["CommitmentAmount"].DefaultCellStyle.Format = "N0";
            //this.dataGridViewtotal.Columns["CommitmentPerPC"].DefaultCellStyle.Format = "N0";


            ////this.dataGridViewtotal.Columns["Commitment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            ////this.dataGridViewtotal.Columns["Commitment"].HeaderText = "Commitment";

            ////this.dataGridViewtotal.Columns["FundPercentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            ////this.dataGridViewtotal.Columns["FundPercentage"].HeaderText = "Percent";

            ////this.dataGridViewtotal.Columns["CommitPercentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            ////this.dataGridViewtotal.Columns["CommitPercentage"].HeaderText = "Commitment";


            //this.dataGridViewtotal.Columns["Total_Achived"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridViewtotal.Columns["Total_Achived"].HeaderText = "Total Achived";

            //this.dataGridViewtotal.Columns["CommitmentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridViewtotal.Columns["CommitmentAmount"].HeaderText = "Sponror Amount";

            //this.dataGridViewtotal.Columns["CommitmentPerPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridViewtotal.Columns["CommitmentPerPC"].HeaderText = " Amount byPC";



            //this.dataGridViewtotal.Columns["CommitmentPercentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridViewtotal.Columns["CommitmentPercentage"].HeaderText = "Percentage   ";



            //this.dataGridViewtotal.Columns["Total_Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridViewtotal.Columns["Total_Paid"].HeaderText = "Total Paid     ";

            //this.dataGridViewtotal.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //this.dataGridViewtotal.Columns["Balance"].HeaderText = "Balance       ";


            //this.dataGridViewtotal.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            //this.dataGridViewtotal.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            //this.dataGridViewtotal.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            //this.dataGridViewtotal.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            //this.dataGridViewtotal.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            //this.dataGridViewtotal.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            //this.dataGridViewtotal.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            //this.dataGridViewtotal.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            ////    this.dataGridViewtotal.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;


            //#endregion


            //dataGridViewtotal.ReadOnly = false;
            //dataGridViewtotal.Rows[3].Cells["Balance"].Style.BackColor = Color.Blue;
            //dataGridViewtotal.Rows[2].Cells["Balance"].Style.ForeColor = Color.Red;
            //dataGridViewtotal.ReadOnly = true;




        }

        public void loadtotaldContractView(string ContractNoin)
        {

        //    #region load total

        //    #region  create temtoatalcontract

        //    #region delete  tbl_KaCreatCrtracttemp


        //    string username = Utils.getusername();
        //    string connection_string = Utils.getConnectionstr();
        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    string sqltext = "DELETE FROM tbl_KaCreatCrtracttemp WHERE tbl_KaCreatCrtracttemp.Username = '" + username + "'";
        //    dc.ExecuteCommand(sqltext);
        //    dc.SubmitChanges();


        //    #endregion


        //    //      float totalcommit = 0;

        //    tbl_KaCreatCrtracttemp temptotal2 = new tbl_KaCreatCrtracttemp();  // hàng tổng kết
        //    temptotal2.CommitmentAmount = 0;
        //    temptotal2.CommitmentPerPC = 0;
        //    temptotal2.CommitmentPercentage = 0;
        //    temptotal2.Total_Achived = 0;
        //    temptotal2.Total_Paid = 0;
        //    temptotal2.Balance = 0;


        //    var rss1 = from tbl_kaprogramlist in dc.tbl_kaprogramlists
        //               where tbl_kaprogramlist.Code != "DIS"
        //               select tbl_kaprogramlist;

        //    foreach (var item in rss1)
        //    {
        //        tbl_KaCreatCrtracttemp temptotal = new tbl_KaCreatCrtracttemp();  // các hàng chi tiết

        //        string filter = "";
        //        string statusview = (from tbl_kacontractdata in dc.tbl_kacontractdatas
        //                             where tbl_kacontractdata.ContractNo.Equals(ContractNoin)
        //                             select tbl_kacontractdata.Consts).FirstOrDefault();

        //        if (statusview != null)
        //        {
        //            if (statusview == "ALV")
        //            {
        //                filter = "ALV";
        //            }
        //            else
        //            {
        //                filter = "";
        //            }
        //        }
        //        else
        //        {
        //            filter = "";
        //        }


        //        temptotal.Programe = item.Name;
        //        //  totalcommit = totalcommit + item.c
        //        //   temptotal.Analyses = item.Name + "/CS";
        //        var totaldetailrs = (from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
        //                             where tbl_kacontractsdatadetail.PayType == item.Code && tbl_kacontractsdatadetail.ContractNo.Equals(ContractNoin)
        //                             && tbl_kacontractsdatadetail.Constatus.Contains(filter)
        //                             group tbl_kacontractsdatadetail by tbl_kacontractsdatadetail.PayType into g
        //                             select new
        //                             {
        //                                 CommitPercentage = g.Sum(gg => gg.FundPercentage).GetValueOrDefault(0),
        //                                 Commitment = g.Sum(gg => gg.SponsoredAmt).GetValueOrDefault(0),
        //                                 Commitment_cs = g.Sum(gg => gg.SponsoredAmtperPC).GetValueOrDefault(0),

        //                                 Total_Achived = g.Sum(gg => gg.SponsoredTotal).GetValueOrDefault(0), // ConfAmt lấy confirm amount làm tinh tong tien 
        //                                                                                                      //   Balance = g.Sum(gg => gg.Balance).GetValueOrDefault(0)

        //                             }).FirstOrDefault();

        //        if (totaldetailrs != null)
        //        {
        //            temptotal.CommitmentAmount = totaldetailrs.Commitment;
        //            temptotal.Total_Achived = totaldetailrs.Total_Achived;
        //            temptotal.CommitmentPerPC = totaldetailrs.Commitment_cs;
        //            temptotal.CommitmentPercentage = totaldetailrs.CommitPercentage;
        //            temptotal.Total_Paid = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
        //                                    where tbl_kacontractsdetailpayment.PayType == item.Code && tbl_kacontractsdetailpayment.ContractNo.Equals(ContractNoin)
        //                                    select tbl_kacontractsdetailpayment.PaidAmt).Sum().GetValueOrDefault(0);
        //            temptotal.Balance = totaldetailrs.Total_Achived - temptotal.Total_Paid;
        //        }
        //        else
        //        {
        //            temptotal.CommitmentAmount = 0;
        //            temptotal.CommitmentPerPC = 0;
        //            temptotal.CommitmentPercentage = 0;
        //            temptotal.Total_Achived = 0;
        //            temptotal.Total_Paid = 0;
        //            temptotal.Balance = 0;
        //        }

        //        //  paid = g.Sum(gg => gg.PaidAmt).GetValueOrDefault(0),


        //        temptotal2.CommitmentAmount = temptotal2.CommitmentAmount + temptotal.CommitmentAmount;
        //        temptotal2.CommitmentPerPC = temptotal2.CommitmentPerPC + temptotal.CommitmentPerPC;
        //        temptotal2.CommitmentPercentage = temptotal2.CommitmentPercentage + temptotal2.CommitmentPercentage;
        //        temptotal2.Total_Achived = temptotal2.Total_Achived + temptotal.Total_Achived;
        //        temptotal2.Total_Paid = temptotal2.Total_Paid + temptotal.Total_Paid;
        //        temptotal2.Balance = temptotal2.Balance + temptotal.Balance;


        //        temptotal.Username = username;
        //        dc.CommandTimeout = 0;
        //        dc.tbl_KaCreatCrtracttemps.InsertOnSubmit(temptotal);
        //        dc.SubmitChanges();

        //    }


        //    temptotal2.Programe = "Total";

        //    temptotal2.Username = username;
        //    // temptotal2.Analyses = "Total";


        //    dc.tbl_KaCreatCrtracttemps.InsertOnSubmit(temptotal2);
        //    dc.SubmitChanges();


        //    #endregion

        //    #region load teamtotal

        //    var rs1 = from tbl_KaCreatCrtracttemp in dc.tbl_KaCreatCrtracttemps
        //              where tbl_KaCreatCrtracttemp.Username == username
        //              select tbl_KaCreatCrtracttemp;

        //    this.dataGridViewtotal.DataSource = rs1;


        //    this.dataGridViewtotal.Columns["id"].Visible = false;
        //    this.dataGridViewtotal.Columns["Username"].Visible = false;

        //    this.dataGridViewtotal.Columns["CommitmentAmount"].DefaultCellStyle.Format = "N0";
        //    this.dataGridViewtotal.Columns["CommitmentPerPC"].DefaultCellStyle.Format = "N0";
        //    this.dataGridViewtotal.Columns["Total_Paid"].DefaultCellStyle.Format = "N0";
        //    this.dataGridViewtotal.Columns["Balance"].DefaultCellStyle.Format = "N0";
        //    this.dataGridViewtotal.Columns["Total_Achived"].DefaultCellStyle.Format = "N0";

        //    //this.dataGridViewtotal.Columns["CommitmentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //    //   this.dataGridViewtotal.Columns["CommitmentAmount"].HeaderText = "Commitment";

        //    this.dataGridViewtotal.Columns["Total_Achived"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //    this.dataGridViewtotal.Columns["Total_Achived"].HeaderText = "Total Achived";

        //    this.dataGridViewtotal.Columns["CommitmentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //    this.dataGridViewtotal.Columns["CommitmentAmount"].HeaderText = "Sponror Amount";

        //    this.dataGridViewtotal.Columns["CommitmentPerPC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //    this.dataGridViewtotal.Columns["CommitmentPerPC"].HeaderText = " Amount byPC  ";


        //    this.dataGridViewtotal.Columns["CommitmentPercentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //    this.dataGridViewtotal.Columns["CommitmentPercentage"].HeaderText = "Percentage   ";


        //    this.dataGridViewtotal.Columns["Total_Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //    this.dataGridViewtotal.Columns["Total_Paid"].HeaderText = "Total Paid    ";
        //    this.dataGridViewtotal.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //    this.dataGridViewtotal.Columns["Balance"].HeaderText = "Balance       ";

        //    this.dataGridViewtotal.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    this.dataGridViewtotal.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

        //    this.dataGridViewtotal.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

        //    this.dataGridViewtotal.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    this.dataGridViewtotal.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

        //    this.dataGridViewtotal.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

        //    this.dataGridViewtotal.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    this.dataGridViewtotal.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    //this.dataGridViewtotal.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    #endregion





        //}

        //public void loadDetaildContractcreatenew()
        //{


        //    #region  DETAIL datagridview [tbl_kaProgramedetailTemp]

        //    label36.Visible = false;
        //    label35.Visible = false;
        //    label34.Visible = false;
        //    label33.Visible = false;
        //    label32.Visible = false;
        //    Achivedvol.Visible = false;
        //    RevenueAched.Visible = false;
        //    AchievdVolPCs.Visible = false;
        //    Funpercentage.Visible = false;
        //    Costpercase.Visible = false;


        //    //bt_fin.Visible = false;
        //    //bt_finundo.Visible = false;
        //    //bt_cancel.Visible = false;
        //    //bt_close.Visible = false;
        //    //bt_undoclose.Visible = false;
        //    //bt_undocancel.Visible = false;

        //    #region load detail pg




        //    // tbl_kaProgramedetailTemp tb = new tbl_kaProgramedetailTemp();

        //    //  tb.

        //    DataTable dt = new DataTable();

        //    //dt.Columns.Add(new DataColumn("Program", typeof(String)));
        //    //dt.Columns.Add(new DataColumn("Payment_Control", typeof(String)));
        //    dt.Columns.Add(new DataColumn("VAT", typeof(Boolean)));


        //    //       dt.Columns.Add(new DataColumn("Product_Group", typeof(Double)));



        //    dt.Columns.Add(new DataColumn("Fund_Percent", typeof(double)));
        //    dt.Columns.Add(new DataColumn("Amount_Per_Pc_Lit_FTN", typeof(double)));
        //    dt.Columns.Add(new DataColumn("Sponsored_Amount", typeof(double)));
        //    dt.Columns.Add(new DataColumn("SponsortUnit", typeof(string)));

        //    //Threahold
        //    dt.Columns.Add(new DataColumn("Taget_Percentage", typeof(double)));
        //    dt.Columns.Add(new DataColumn("Taget_Achivement", typeof(double)));
        //    dt.Columns.Add(new DataColumn("TargetUnit", typeof(string)));
        //    //  dt.Columns.Add(new DataColumn("Payment_Commit_Date", typeof(DateTime)));
        //    //Time Frame
        //    //           dt.Columns.Add(new DataColumn("Effect_From", typeof(DateTime)));

        //    //           dt.Columns.Add(new DataColumn("Effect_To", typeof(DateTime)));
        //    //Remark
        //    dt.Columns.Add(new DataColumn("Remark", typeof(string)));

        //    //dt.Columns.Add(new DataColumn("Start-Date", typeof(DateTime)));

        //    //dt.Columns.Add(new DataColumn("Start-Date", typeof(DateTime)));

        //    //  dataGridView1.DataSource = dt;


        //    //    tb.Remark
        //    //   tb.Amount_Per_Pc_Lit_FTN
        //    //   tb.To_Date
        //    //          tb.From_Date
        //    //    tb.Ditributor__s_Amount
        //    //   tb.VAT
        //    //  tb.Achivement;
        //    //  tb.Amount_Per_Pc;
        //    //  tb.Balance;
        //    //  tb.Date;
        //    //  tb.Done_On;
        //    //  tb.Percent;
        //    //  tb.id;
        //    //  tb.Paid_Amount;
        //    //  tb.Payment_Control;
        //    //  tb.Payment_Description;
        //    //  tb.Prepered_On;
        //    //  tb.Print;
        //    //  tb.Product_Group;
        //    //  tb.Program;
        //    //  tb.Ref_No;
        //    //  tb.Sponsored_Amount;
        //    //  tb.Tracking_id;
        //    //  tb.Unit;
        //    //  tb.Username;
        //    //   tb.dis

        //    //    dt.Columns["Program"].
        //    this.dataGridProgramdetail.DataSource = dt;
        //    // this.dataGridProgramdetail.DataSource = detailprogarmers;



        //    //this.dataGridProgramdetail.Columns["id"].Visible = false;
        //    //this.dataGridProgramdetail.Columns["Username"].Visible = false;





        //    #endregion


        //    //    dgv_list_EditingControlShowing;



        //    //   dataGridProgramdetail.Columns.Remove("Program");

        //    bindDataToDataGridViewComboPrograme();
        //    bindDataToDataGridViewComboPayment_Control();
        //    bindDataToDataGridViewComboproductgroup_Control();



        //    DGV_DateTimePicker.DateTimePickerColumn col = new DGV_DateTimePicker.DateTimePickerColumn();
        //    col.HeaderText = "Payment Commit Date";
        //    col.Name = "Payment_Commit_Date";
        //    dataGridProgramdetail.Columns.Add(col);
        //    //dataGridProgramdetail.RowCount = 5;
        //    DGV_DateTimePicker.DateTimePickerColumn col2 = new DGV_DateTimePicker.DateTimePickerColumn();
        //    col2.HeaderText = "Effect From";
        //    col2.Name = "Effect_From";

        //    dataGridProgramdetail.Columns.Add(col2);



        //    DGV_DateTimePicker.DateTimePickerColumn col3 = new DGV_DateTimePicker.DateTimePickerColumn();
        //    col3.HeaderText = "Effect To";
        //    col3.Name = "Effect_To";
        //    dataGridProgramdetail.Columns.Add(col3);
        //    //   -----\\\\ batdau load



        //    dataGridProgramdetail.Columns["Program"].DisplayIndex = 0;
        //    dataGridProgramdetail.Columns["Program"].Width = 70;
        //    this.dataGridProgramdetail.Columns["Program"].SortMode = DataGridViewColumnSortMode.NotSortable;

        //    dataGridProgramdetail.Columns["Payment_Control"].DisplayIndex = 1;
        //    dataGridProgramdetail.Columns["Payment_Control"].Width = 70;
        //    dataGridProgramdetail.Columns["Payment_Control"].HeaderText = "Payment\nControl";
        //    this.dataGridProgramdetail.Columns["Payment_Control"].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    // Product_Group
        //    dataGridProgramdetail.Columns["Remark"].DisplayIndex = 2;
        //    dataGridProgramdetail.Columns["Remark"].Width = 300;
        //    dataGridProgramdetail.Columns["Remark"].HeaderText = "Description";
        //    this.dataGridProgramdetail.Columns["Remark"].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    //  this.dataGridProgramdetail.Columns["Remark"].SortMode = DataGridViewColumnSortMode.NotSortable;

        //    dataGridProgramdetail.Columns["Product_Group"].DisplayIndex = 3;
        //    dataGridProgramdetail.Columns["Product_Group"].Width = 80;
        //    dataGridProgramdetail.Columns["Product_Group"].HeaderText = "Product \nGroup";
        //    this.dataGridProgramdetail.Columns["Product_Group"].SortMode = DataGridViewColumnSortMode.NotSortable;


        //    dataGridProgramdetail.Columns["VAT"].DisplayIndex = 4;
        //    dataGridProgramdetail.Columns["VAT"].Width = 50;
        //    this.dataGridProgramdetail.Columns["VAT"].SortMode = DataGridViewColumnSortMode.NotSortable;


        //    //      this.dataGridProgramdetail.Columns["Fund_Percent"].DefaultCellStyle.Format = "N0";
        //    dataGridProgramdetail.Columns["Fund_Percent"].DisplayIndex = 5;
        //    //   dataGridProgramdetail.Columns["Fund_Percent"].Width = 150;
        //    dataGridProgramdetail.Columns["Fund_Percent"].HeaderText = "Sponsor \nPercent";
        //    this.dataGridProgramdetail.Columns["Fund_Percent"].SortMode = DataGridViewColumnSortMode.NotSortable;



        //    dataGridProgramdetail.Columns["Amount_Per_Pc_Lit_FTN"].DisplayIndex = 6;
        //    //     dataGridProgramdetail.Columns["Amount_Per_Pc_Lit_FTN"].Width = 120;
        //    this.dataGridProgramdetail.Columns["Amount_Per_Pc_Lit_FTN"].DefaultCellStyle.Format = "N0";
        //    this.dataGridProgramdetail.Columns["Amount_Per_Pc_Lit_FTN"].HeaderText = "Sponsor Per \nPC\\UC\\Litter";
        //    this.dataGridProgramdetail.Columns["Amount_Per_Pc_Lit_FTN"].SortMode = DataGridViewColumnSortMode.NotSortable;




        //    dataGridProgramdetail.Columns["Sponsored_Amount"].DisplayIndex = 7;
        //    this.dataGridProgramdetail.Columns["Sponsored_Amount"].HeaderText = "Sponsor Amount";
        //    this.dataGridProgramdetail.Columns["Sponsored_Amount"].DefaultCellStyle.Format = "N0";
        //    this.dataGridProgramdetail.Columns["Sponsored_Amount"].SortMode = DataGridViewColumnSortMode.NotSortable;

        //    //     dt.Columns.Add(new DataColumn("SponsortUnit", typeof(string)));

        //    dataGridProgramdetail.Columns["SponsortUnit"].DisplayIndex = 8;
        //    this.dataGridProgramdetail.Columns["SponsortUnit"].HeaderText = "Sponsor \nUnit";
        //    this.dataGridProgramdetail.Columns["SponsortUnit"].DefaultCellStyle.Format = "N0";
        //    this.dataGridProgramdetail.Columns["SponsortUnit"].SortMode = DataGridViewColumnSortMode.NotSortable;

        //    //this.dataGridProgramdetail.Columns["Taget_Percentage"].DefaultCellStyle.Format = "N0";
        //    dataGridProgramdetail.Columns["Taget_Percentage"].DisplayIndex = 9;
        //    this.dataGridProgramdetail.Columns["Taget_Percentage"].DefaultCellStyle.Format = "N0";
        //    this.dataGridProgramdetail.Columns["Taget_Percentage"].HeaderText = "Target \nPercentage";
        //    this.dataGridProgramdetail.Columns["Taget_Percentage"].SortMode = DataGridViewColumnSortMode.NotSortable;


        //    dataGridProgramdetail.Columns["Taget_Achivement"].DisplayIndex = 10;
        //    dataGridProgramdetail.Columns["Taget_Achivement"].HeaderText = "Target Achivement";
        //    this.dataGridProgramdetail.Columns["Taget_Achivement"].DefaultCellStyle.Format = "N0";
        //    dataGridProgramdetail.Columns["Taget_Achivement"].Width = 80;
        //    this.dataGridProgramdetail.Columns["Taget_Achivement"].SortMode = DataGridViewColumnSortMode.NotSortable;




        //    dataGridProgramdetail.Columns["TargetUnit"].DisplayIndex = 11;
        //    dataGridProgramdetail.Columns["TargetUnit"].HeaderText = "Target Unit";
        //    this.dataGridProgramdetail.Columns["TargetUnit"].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    dataGridProgramdetail.Columns["TargetUnit"].Width = 80;

        //    //     this.dataGridViewtotal.Columns["TargetUnit"].DefaultCellStyle.Format = "N0";


        //    dataGridProgramdetail.Columns["Payment_Commit_Date"].DisplayIndex = 12;
        //    dataGridProgramdetail.Columns["Payment_Commit_Date"].HeaderText = "Payment \nCommitment Date";
        //    this.dataGridProgramdetail.Columns["Payment_Commit_Date"].SortMode = DataGridViewColumnSortMode.NotSortable;



        //    dataGridProgramdetail.Columns["Effect_From"].DisplayIndex = 13;
        //    dataGridProgramdetail.Columns["Effect_From"].HeaderText = "From Date";
        //    this.dataGridProgramdetail.Columns["Effect_From"].SortMode = DataGridViewColumnSortMode.NotSortable;

        //    dataGridProgramdetail.Columns["Effect_To"].DisplayIndex = 14;
        //    dataGridProgramdetail.Columns["Effect_To"].HeaderText = "To Date";
        //    this.dataGridProgramdetail.Columns["Effect_To"].SortMode = DataGridViewColumnSortMode.NotSortable;



        //    #endregion


        //}

        //public void loadDetailContractView(string ContractNoin)
        //{

        //    string connection_string = Utils.getConnectionstr();
        //    //  string username = Utils.getusername();

        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


        //    //var rsdetaildele = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
        //    //                    where tbl_kacontractsdetailpayment.ContractNo.Equals(ContractNoin)
        //    //                    && tbl_kacontractsdetailpayment.BatchNo == 0
        //    //                    select tbl_kacontractsdetailpayment);
        //    //if (rsdetaildele != null)
        //    //{
        //    //    dc.tbl_kacontractsdetailpayments.DeleteAllOnSubmit(rsdetaildele);
        //    //    dc.SubmitChanges();

        //    //}



        //    #region  load detail dataGridView1

        //    var updatePayID = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
        //                      where tbl_kacontractsdatadetail.ContractNo == ContractNoin
        //                      select tbl_kacontractsdatadetail;

        //    foreach (var item in updatePayID)
        //    {
        //        if (item.PayID == null)
        //        {
        //            item.PayID = item.id;

        //        }

        //        dc.SubmitChanges();
        //    }


        //    var dataGridProgramdetailrs = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
        //                                  where tbl_kacontractsdatadetail.ContractNo == ContractNoin && tbl_kacontractsdatadetail.PayControl != "PAY" && tbl_kacontractsdatadetail.PayControl != "DIS"
        //                                  select new
        //                                  {
        //                                      Programe = tbl_kacontractsdatadetail.PayType.Trim(),
        //                                      PayControl = tbl_kacontractsdatadetail.PayControl.Trim() + ": " + tbl_kacontractsdatadetail.Description.Trim(),
        //                                      Description = tbl_kacontractsdatadetail.Remark,
        //                                      //       Description = tbl_kacontractsdatadetail.Description.Trim(),
        //                                      PayID = tbl_kacontractsdatadetail.PayID,

        //                                      Product_Group = tbl_kacontractsdatadetail.PrdGrp,
        //                                      //        this.dataGridProgramdetail.Columns["Fund_Percent"].DefaultCellStyle.Format = "N0";
        //                                      SponsorPercent = tbl_kacontractsdatadetail.FundPercentage,
        //                                      SponsorByUnit = tbl_kacontractsdatadetail.SponsoredAmtperPC,

        //                                      SponsorAmount = tbl_kacontractsdatadetail.SponsoredAmt,
        //                                      Unit = tbl_kacontractsdatadetail.SponsorUnit,
        //                                      Target_Percentage = tbl_kacontractsdatadetail.TagetPercentage,

        //                                      Target_Achivement = tbl_kacontractsdatadetail.TagetAchivement,


        //                                      Achivement = tbl_kacontractsdatadetail.VolAchvmt.GetValueOrDefault(0),//+ tbl_kacontractsdatadetail.BeginAchvmt.GetValueOrDefault(0),
        //                                      TargetUnit = tbl_kacontractsdatadetail.TargetUnit,
        //                                      Sponsor_Total = tbl_kacontractsdatadetail.SponsoredTotal,
        //                                      //     Distribution_Amt = tbl_kacontractsdatadetail.DisAmount,

        //                                      PaidRequest = tbl_kacontractsdatadetail.PaidRequestAmt,
        //                                      Paid_Amount = tbl_kacontractsdatadetail.PaidAmt,

        //                                      Payment_Commit_Date = tbl_kacontractsdatadetail.CommittedDate,
        //                                      Effect_From = tbl_kacontractsdatadetail.EffFrm,
        //                                      Effect_To = tbl_kacontractsdatadetail.EffTo,

        //                                      Status = tbl_kacontractsdatadetail.Constatus,

        //                                      VAT = tbl_kacontractsdatadetail.VAT,
        //                                      Print = tbl_kacontractsdatadetail.PrintChk,

        //                                      Done_On = tbl_kacontractsdatadetail.DoneOn



        //                                  };

        //    dataGridProgramdetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        //    dataGridProgramdetail.DataSource = dataGridProgramdetailrs;
        //    this.dataGridProgramdetail.Columns["Sponsor_Total"].DefaultCellStyle.Format = "N0";
        //    this.dataGridProgramdetail.Columns["PaidRequest"].DefaultCellStyle.Format = "N0";
        //    this.dataGridProgramdetail.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
        //    this.dataGridProgramdetail.Columns["SponsorByUnit"].DefaultCellStyle.Format = "N0";
        //    this.dataGridProgramdetail.Columns["SponsorAmount"].DefaultCellStyle.Format = "N0";
        //    this.dataGridProgramdetail.Columns["Target_Achivement"].DefaultCellStyle.Format = "N0";

        //    this.dataGridProgramdetail.Columns["Achivement"].DefaultCellStyle.Format = "N0";

        //    this.dataGridProgramdetail.Columns["Sponsor_Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //    this.dataGridProgramdetail.Columns["PaidRequest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //    this.dataGridProgramdetail.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //    this.dataGridProgramdetail.Columns["SponsorAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //    this.dataGridProgramdetail.Columns["Achivement"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //                                                                                                                           //   this.dataGridProgramdetail.Columns["Taget_Percentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

        //    dataGridProgramdetail.AllowUserToOrderColumns = true;
        //    dataGridProgramdetail.AllowUserToResizeColumns = true;
        

        //    #endregion

        //    #region dataGridView7  detail pay ment

        //    var dataGridProgramdetailrs7 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
        //                                   where tbl_kacontractsdetailpayment.ContractNo == ContractNoin // && tbl_kacontractsdetailpayment.PayControl == "PAY"
        //                                   select new
        //                                   {

        //                                       Programe = tbl_kacontractsdetailpayment.PayType.Trim(),
        //                                       PayControlID = tbl_kacontractsdetailpayment.PayControl.Trim(),
        //                                       Description = tbl_kacontractsdetailpayment.Remark.Trim(),

        //                                       Paid_Amount = tbl_kacontractsdetailpayment.PaidAmt,
        //                                       tbl_kacontractsdetailpayment.PaidRequestAmt,

        //                                       //    PaidNote = tbl_kacontractsdetailpayment.PaidNote,
        //                                       PaymentDoc = tbl_kacontractsdetailpayment.PaymentDoc,
        //                                       tbl_kacontractsdetailpayment.DoneOn,

        //                                       tbl_kacontractsdetailpayment.PrintChk,
        //                                       tbl_kacontractsdetailpayment.Reprint,
        //                                       tbl_kacontractsdetailpayment.PrintDate,
        //                                       //     Remarks = tbl_kacontractsdetailpayment.Remark.Trim(),
        //                                       tbl_kacontractsdetailpayment.BatchNo,
        //                                       tbl_kacontractsdetailpayment.CRDDAT,
        //                                       tbl_kacontractsdetailpayment.CRDUSR,
        //                                       //   tbl_kacontractsdetailpayment.DoneOn,
        //                                       Paid_Note = tbl_kacontractsdetailpayment.PaidNote,

        //                                       tbl_kacontractsdetailpayment.UPDDAT,
        //                                       tbl_kacontractsdetailpayment.UPDUSR,

        //                                       PayID = tbl_kacontractsdetailpayment.PayID,
        //                                       SubID = tbl_kacontractsdetailpayment.SubID,


        //                                   };

        //    //   dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        //    dataGridView7.DataSource = dataGridProgramdetailrs7;

        //    if (dataGridProgramdetailrs7.Count() > 0)
        //    {

        //        this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
        //        this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Format = "N0";



        //        this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
        //        this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

        //    }

        //    #endregion





        //}

        //public AutoCompleteStringCollection contractdata = new AutoCompleteStringCollection();
        //public CreatenewContract(string formlabel, string ContractNoin)
        //{
        //    InitializeComponent();
        //    //    btupdatecontract.Visible = false;
        //    Model.Username used = new Model.Username();
        //    string connection_string = Utils.getConnectionstr();
        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    string username = Utils.getusername();

           


        //    AutoCompleteStringCollection contractdata = new AutoCompleteStringCollection();

        //    var contractautolist = (from tbl_autodataContract in dc.tbl_autodataContracts
        //                            where tbl_autodataContract.Username == username
        //                            orderby tbl_autodataContract.id descending
        //                            select tbl_autodataContract.ContractNo).Take(10);

        //    if (contractautolist.Count() > 0)
        //    {
        //        foreach (var item in contractautolist)
        //        {
        //            if (item != null)
        //            {
        //                contractdata.Add(item);
        //            }

        //        }


        //        var deletelist = from tbl_autodataContract in dc.tbl_autodataContracts
        //                         where !contractautolist.Contains(tbl_autodataContract.ContractNo)
        //                         select tbl_autodataContract;

        //        dc.tbl_autodataContracts.DeleteAllOnSubmit(deletelist);
        //        dc.SubmitChanges();

        //    }


        //    this.contractdata = contractdata;
        //    tb_contractno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    tb_contractno.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    tb_contractno.AutoCompleteCustomSource = contractdata;

        //    //            tb_contractno.AutoCompleteSource = contractdata;



        //    btchangecontractitem.Visible = false;
        //    btaddnewItem.Visible = false;


        //    this.formlabel.Text = formlabel;

        //    cbcust.Enabled = false;
        //    //   txtfindsacode.Enabled = false;
        //    cbgroup.Enabled = false;
        //    cbsfa.Enabled = false;
        //    txtinfor.Visible = false;

        //    btdelete.Enabled = false;
        //    bt_fin.Visible = false;
        //    bt_finundo.Visible = false;
        //    bt_cancel.Visible = false;
        //    bt_close.Visible = false;
        //    btchangeRemark.Visible = false;

        //    btchangecontrcatype.Visible = false;
        //    btchangeregion.Visible = false;

        //    btchanegcontract.Visible = false;

        //    btcfromdate.Visible = false;
        //    btchagetodate.Visible = false;



        //    btchangecret.Visible = false;
        //    //
        //    btrepresent.Visible = false;
        //    btchangetradename.Visible = false;
        //    bthomeso.Visible = false;
        //    btchangedistric.Visible = false;
        //    btchangeprovince.Visible = false;
        //    btvatchange.Visible = false;

        //    ///
        //    bt_undoclose.Visible = false;
        //    bt_undocancel.Visible = false;



        //    cbocindirect.Enabled = false;

        //    #region neu laf "CREATING NEW CONTRACT")


        //    if (formlabel == "CREATING NEW CONTRACT")

        //    {


        //        btaddnewItem.Visible = false;



        //        this.Nsaperyear.Enabled = false;
        //        //   groupBox3.Enabled = false;
        //        this.txt_annualvolume.Enabled = false;
        //        this.txt_term.Enabled = false;
        //        txt_annualvolume.Text = "0";
        //        Nsaperyear.Text = "0";

        //        this.tb_creditlimit.Text = "0";
        //        this.bt_etcontract.Visible = false;
        //        //     this.bt_changecontracts.Visible = false;
        //        this.txt_volumecomit.Text = "0";

        //        tabControl1.TabPages.RemoveAt(1);

        //        tabControl1.TabPages.RemoveAt(2);

        //        tabControl1.TabPages.RemoveAt(3);

        //        tabControl1.TabPages.RemoveAt(1);

        //        tabControl1.TabPages.RemoveAt(1);



        //        if (Utils.IsValidnumber(txt_volumecomit.Text))
        //        {


        //            #region load term and yeayr  

        //            this.txt_term.Text = "1";

        //            //this.txt_term.Text = (Math.Ceiling((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365))).ToString();
        //            this.txt_annualvolume.Text = "0";// (double.Parse(txt_volumecomit.Text) / double.Parse(txt_term.Text)).ToString();


        //            #endregion

        //        }


        //        #region load cb currency

        //        var rs2 = from tbl_kacurrency in dc.tbl_kacurrencies

        //                  select tbl_kacurrency;

        //        string drowdownshow = "";

        //        foreach (var item in rs2)
        //        {
        //            drowdownshow = item.Currency;
        //            this.cb_curency.Items.Add(drowdownshow);


        //        }
        //        this.cb_curency.SelectedIndex = 0;
        //        this.cb_contractstatus.SelectedIndex = 0;
        //        #endregion

        //        #region load cb tbl_karegion

        //        var rs4 = from tbl_karegion in dc.tbl_karegions
        //                      //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
        //                  select tbl_karegion;

        //        drowdownshow = "";

        //        foreach (var item in rs4)
        //        {
        //            drowdownshow = item.Region;
        //            this.cb_salesogr.Items.Add(drowdownshow);


        //        }

        //        #endregion


        //        #region load cb contractype

        //        var rs3 = from tbl_kacontracttype in dc.tbl_kacontracttypes
        //                      //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
        //                  select tbl_kacontracttype;

        //        drowdownshow = "";

        //        foreach (var item in rs3)
        //        {
        //            drowdownshow = item.Contractype;
        //            this.cb_contracttype.Items.Add(drowdownshow);


        //        }

        //        #endregion



        //        #region load tbl_PaymentTerm,

        //        var rs5 = from tbl_PaymentTerm in dc.tbl_PaymentTerms
        //                      //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
        //                  select tbl_PaymentTerm;

        //        drowdownshow = "";

        //        foreach (var item in rs5)
        //        {
        //            drowdownshow = item.PaymentTerm;
        //            this.cb_paymentterm.Items.Add(drowdownshow);


        //        }

        //        #endregion



        //        #region load tbl_kaChannel



        //        //       List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
        //        var rs6 = from tbl_kaChannel in dc.tbl_kaChannels
        //                      //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
        //                  select tbl_kaChannel;

        //        foreach (var item in rs6)
        //        {
        //            ComboboxItem cb = new ComboboxItem();
        //            cb.Value = item.Channel;
        //            cb.Text = item.Channel + " : " + item.Detail;
        //            this.cb_channel.Items.Add(cb); // CombomCollection.Add(cb);

        //        }


        //        this.cb_channel.DropDownWidth = 230;

        //        #endregion


        //        this.cb_customerka.DropDownStyle = ComboBoxStyle.Simple;
        //        this.cb_delivery.DropDownStyle = ComboBoxStyle.Simple;
        //        this.txtfindsacode.DropDownStyle = ComboBoxStyle.Simple;


        //        //#region load cobcusstomer data


        //        //List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
        //        //var rscustomer = from tbl_KaCustomer in dc.tbl_KaCustomers
        //        //                     //   group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
        //        //                 select tbl_KaCustomer;
        //        //foreach (var item in rscustomer)
        //        //{
        //        //    ComboboxItem cb = new ComboboxItem();
        //        //    cb.Value = item.Customer;
        //        //    cb.Text = item.Customer + ": " + item.FullNameN;
        //        //    this.cb_customerka.Items.Add(cb); // CombomCollection.Add(cb);
        //        //    this.cb_delivery.Items.Add(cb);
        //        //}


        //        //this.cb_customerka.DropDownWidth = 350;
        //        //this.cb_delivery.DropDownWidth = 300;


        //        ////drowdownshow = "";

        //        ////foreach (var item in rscustomer)
        //        ////{
        //        ////    drowdownshow = item.Customer.;
        //        ////    this.cb_channel.Items.Add(drowdownshow);


        //        ////}

        //        //#endregion






        //        #region  loadttal datagridview temp

        //        #region delete  tbl_KaCreatCrtracttemp


        //        //  string username = Utils.getusername();
        //        LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
        //        string sqltext = "DELETE FROM tbl_KaCreatCrtracttemp WHERE tbl_KaCreatCrtracttemp.Username = '" + username + "'";
        //        db.CommandTimeout = 0;
        //        db.ExecuteCommand(sqltext);

        //        db.SubmitChanges();


        //        #endregion


        //        #region  create temtoatalcontract


        //        //      float totalcommit = 0;
        //        var rs = from tbl_kaprogramlist in db.tbl_kaprogramlists
        //                 where tbl_kaprogramlist.Code != "DIS"
        //                 select tbl_kaprogramlist;

        //        foreach (var item in rs)
        //        {
        //            tbl_KaCreatCrtracttemp temptotal = new tbl_KaCreatCrtracttemp();

        //            temptotal.Programe = item.Name;
        //            //  totalcommit = totalcommit + item.c
        //            //  temptotal.Analyses = item.Name + "/CS";
        //            temptotal.CommitmentAmount = 0;
        //            temptotal.CommitmentPerPC = 0;
        //            temptotal.CommitmentPercentage = 0;
        //            temptotal.Total_Achived = 0;
        //            temptotal.Total_Paid = 0;
        //            temptotal.Balance = 0;
        //            temptotal.Username = username;
        //            db.tbl_KaCreatCrtracttemps.InsertOnSubmit(temptotal);
        //            db.SubmitChanges();

        //        }

        //        tbl_KaCreatCrtracttemp temptotal2 = new tbl_KaCreatCrtracttemp();

        //        temptotal2.Programe = "Total";
        //        temptotal2.CommitmentAmount = 0;
        //        temptotal2.CommitmentPerPC = 0;
        //        temptotal2.CommitmentPerPC = 0;
        //        temptotal2.Total_Achived = 0;

        //        temptotal2.Total_Paid = 0;
        //        temptotal2.Balance = 0;
        //        temptotal2.Username = username;
        //        //    temptotal2.Analyses = "Total";


        //        db.tbl_KaCreatCrtracttemps.InsertOnSubmit(temptotal2);
        //        db.SubmitChanges();


        //        #endregion



        //        #endregion

        //        loadtotaldContractnew();


        //        loadDetaildContractcreatenew();

        //    }

        //    #endregion neu laf "CREATING NEW CONTRACT")

        //    #region // newu la dispaly con tract


        //    if (formlabel == "DISPLAY PAYMENT CONTRACT" || formlabel == "ENTRY SCREEN DISPLAY CONTRACT" || formlabel == "VIEW SCREEN DISPLAY CONTRACT")
        //    {

        //        if (used.changeitem)
        //        {
        //            btchangecontractitem.Visible = true;
        //        }
        //        else
        //        {
        //            btchangecontractitem.Visible = false;
        //        }


        //        if (used.btaddnewItem)
        //        {
        //            btaddnewItem.Visible = true;
        //        }
        //        else
        //        {
        //            btaddnewItem.Visible = false;
        //        }



        //        //groupBox3.Enabled = false;
        //        Control.Control_ac.VolumeupdateperContract(ContractNoin);
        //        Control.Control_ac.VolumeupdateperContractbyPRdgrp(ContractNoin);

        //        //Control.Control_ac.CaculationContract(contractno);//  CaculationContract();
        //        //                                                  //    string contractno = tb_contractno.Text;
        //        //Control.Control_ac.CaculationContractinSQLmaster(contractno);
        //        txtVATno.Enabled = false;
        //        txtcustgroup.Enabled = false;
        //        btfindcust.Enabled = false;
        //        btfingroup.Enabled = false;
        //        btfinddeliveryby.Enabled = false;
        //        btfindsfa.Enabled = false;
        //        this.cb_contractstatus.Enabled = false;

        //        Control_ac.CaculationContract(ContractNoin); // tinhs toasn contract truo c khi view

        //        Control.Control_ac.CaculationContractinSQLmaster(ContractNoin);

        //        #region loaddata 


        //        var rs = (from tbl_kacontractdata in dc.tbl_kacontractdatas
        //                  where tbl_kacontractdata.ContractNo == ContractNoin
        //                  select tbl_kacontractdata).FirstOrDefault();


        //        if (rs != null)
        //        {

        //            #region delete  tbl_KaCreatCrtracttemp


        //            //    string username = Utils.getusername();
        //            // LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //            string sqltext = "DELETE FROM tbl_KaCreatCrtracttemp WHERE tbl_KaCreatCrtracttemp.Username = '" + username + "'";
        //            dc.ExecuteCommand(sqltext);
        //            dc.SubmitChanges();


        //            #endregion


        //            #region load data master contrac

        //            bt_creatnewCust.Visible = false;
        //            bt_creatnewcontract.Visible = false;
        //            //   but_releaseprint.Visible = false;

        //            this.tb_contractno.Text = rs.ContractNo;
        //            this.tb_contractno.Enabled = false;

        //            this.dateTimePicker1.Value = rs.EffDate.Value;
        //            this.dateTimePicker1.Enabled = false;


        //            this.dateTimePicker2.Value = rs.EftDate.Value;
        //            this.dateTimePicker2.Enabled = false;

        //            this.dateTimePicker3.Value = rs.ExtDate.Value;
        //            this.dateTimePicker3.Enabled = false;


        //            // ToString("#,#", CultureInfo.InvariantCulture);
        //            this.txt_term.Text = rs.ConTerm.ToString();// (this.dateTimePicker2.Value.Year - this.dateTimePicker1.Value.Year + 1).ToString();

        //            if (rs.ConTerm == null)
        //            {
        //                int varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());
        //                this.txt_term.Text = varyear.ToString();
        //            }



        //            this.txt_term.Enabled = false;
        //            if (rs.NSRComm != null)
        //            {
        //                NSRcommit.Text = ((double)rs.NSRComm).ToString("#,#", CultureInfo.InvariantCulture);

        //            }
        //            else
        //            {
        //                NSRcommit.Text = "0";
        //            }

        //            NSRcommit.Enabled = false;

        //            if (rs.ConTerm != null && rs.ConTerm > 0 && rs.NSRComm != null)
        //            {
        //                Nsaperyear.Text = ((double)(rs.NSRComm / rs.ConTerm)).ToString("#,#", CultureInfo.InvariantCulture);

        //            }
        //            else
        //            {
        //                Nsaperyear.Text = "0";
        //            }

        //            this.Nsaperyear.Enabled = false;

        //            Achivedvol.Enabled = false;
        //            if (rs.PCVolAched != null)
        //            {
        //                Achivedvol.Text = double.Parse(rs.PCVolAched.ToString()).ToString("#,#", CultureInfo.InvariantCulture);
        //            }

        //            if (rs.Revenue != null)
        //            {
        //                RevenueAched.Text = double.Parse(rs.Revenue.ToString()).ToString("#,#", CultureInfo.InvariantCulture);
        //            }
        //            RevenueAched.Enabled = false;

        //            if (rs.ECAched != null)
        //            {
        //                AchievdVolPCs.Text = double.Parse(rs.ECAched.ToString()).ToString("#,#", CultureInfo.InvariantCulture);

        //            }
        //            AchievdVolPCs.Enabled = false;


        //            Funpercentage.Enabled = false;
        //            if (rs.VolComm > 0)
        //            {

        //                Funpercentage.Text = Math.Round((double)((rs.PCVolAched.GetValueOrDefault(0) / rs.VolComm) * 100)).ToString("#,#", CultureInfo.InvariantCulture);

        //            }

        //            Costpercase.Enabled = false;
        //            if (rs.ECAched > 0)
        //            {

        //                Costpercase.Text = ((double)(rs.TotDeal.GetValueOrDefault(0) / rs.ECAched)).ToString("#,#", CultureInfo.InvariantCulture);

        //            }

        //            if (rs.VolComm != null)
        //            {
        //                this.txt_volumecomit.Text = ((double)rs.VolComm).ToString("#,#", CultureInfo.InvariantCulture);
        //            }

        //            this.txt_volumecomit.Enabled = false;

        //            if (rs.AnnualVolume != null)
        //            {
        //                this.txt_annualvolume.Text = ((double)rs.AnnualVolume).ToString("#,#", CultureInfo.InvariantCulture);
        //            }

        //            this.txt_annualvolume.Enabled = false;

        //            this.Nsaperyear.Enabled = false;
        //            if (rs.NSRPer != null)
        //            {
        //                this.Nsaperyear.Text = ((double)rs.NSRPer).ToString("#,#", CultureInfo.InvariantCulture);
        //            }




        //            txtfindsacode.Enabled = false;


        //            if (rs.CreditLimit != null)
        //            {
        //                this.tb_creditlimit.Text = ((double)rs.CreditLimit).ToString("#,#", CultureInfo.InvariantCulture);
        //                //     this.tb_creditlimit.Text = rs.CreditLimit.ToString();
        //            }

        //            this.tb_creditlimit.Enabled = false;


        //            this.cb_customerka.DropDownStyle = ComboBoxStyle.Simple;// = false;

        //            if (rs.CustomerType.Trim() == "SAP" || rs.CustomerType == null)
        //            {
        //                this.cb_customerka.Text = rs.Customer.ToString();
        //                cbcust.Checked = true;
        //            }
        //            if (rs.CustomerType.Trim() == "GRP")
        //            {
        //                this.txtcustgroup.Text = rs.Customer.ToString();
        //                cbgroup.Checked = true;
        //            }
        //            if (rs.CustomerType.Trim() == "SFA")
        //            {
        //                this.txtfindsacode.Text = rs.Customer.ToString();
        //                cbsfa.Checked = true;
        //                cbocindirect.Checked = true;
        //            }




        //            this.cb_customerka.Enabled = false;


        //            this.cb_contracttype.DropDownStyle = ComboBoxStyle.Simple;// = false;
        //            this.cb_contracttype.Text = rs.ConType;
        //            this.cb_contracttype.Enabled = false;

        //            this.cb_salesogr.DropDownStyle = ComboBoxStyle.Simple;// = false;
        //            this.cb_salesogr.Text = rs.SalesOrg;
        //            this.cb_salesogr.Enabled = false;



        //            this.cb_channel.DropDownStyle = ComboBoxStyle.Simple;// = false;
        //            this.cb_channel.Text = rs.Channel;
        //            this.cb_channel.Enabled = false;



        //            //this.cb_channel.DropDownStyle = ComboBoxStyle.Simple;// = false;
        //            //this.cb_channel.Text = rs.Channel;
        //            //this.cb_channel.Enabled = false;


        //            this.cb_paymentterm.DropDownStyle = ComboBoxStyle.Simple;// = false;
        //            this.cb_paymentterm.Text = rs.CreditTerm;
        //            this.cb_paymentterm.Enabled = false;


        //            this.cb_curency.DropDownStyle = ComboBoxStyle.Simple;// = false;
        //            this.cb_curency.Text = rs.Currency;
        //            this.cb_curency.Enabled = false;

        //            this.cb_delivery.DropDownStyle = ComboBoxStyle.Simple;// = false;
        //            this.cb_delivery.Text = rs.DeliveredBy;
        //            this.cb_delivery.Enabled = false;


        //            this.txt_represennt.Text = rs.Representative;
        //            this.txt_represennt.Enabled = false;


        //            this.txt_chananame.Text = rs.Fullname;
        //            this.txt_chananame.Enabled = false;

        //            this.txt_houseno.Text = rs.HouseNo;
        //            this.txt_houseno.Enabled = false;

        //            this.txt_provicen.Text = rs.Province;
        //            this.txt_provicen.Enabled = false;


        //            this.txt_district.Text = rs.District;
        //            this.txt_district.Enabled = false;


        //            //this.Achivedvol.Enabled = false;
        //            //this.Achivedvol.Text = rs.VolAched.ToString();


        //            //this.RevenueAched.Enabled = false;
        //            //this.RevenueAched.Text = rs.Revenue.ToString();


        //            //this.AchievdVolPCs.Enabled = false;
        //            //this.AchievdVolPCs.Text = rs.VolAched_S.ToString();


        //            //this.Funpercentage.Enabled = false;
        //            //this.Funpercentage.Text = ((rs.Tot_paid*100) / rs.TotDeal).ToString();




        //            //this.Costpercase.Enabled = false;
        //            //this.Costpercase.Text = (rs.TotDeal/rs.VolAched).ToString();

        //            this.txt_remarkstt.Text = rs.Remarks;


        //            this.txt_remarkstt.Enabled = false;



        //            txtinfor.Visible = true;
        //            //          MessageBox.Show("Are you sure to change status of contract ?", "Thông báo" ,MessageBoxButtons.YesNo, MessageBoxIcon.Information);

        //            txtinfor.Text = "Create by: " + rs.CRDUSR + ", Update by: " + rs.UPDUSR;

        //            //        Model.Username used = new Model.Username();

        //            if (formlabel == "ENTRY SCREEN DISPLAY CONTRACT")
        //            {
        //                //   this.cb_contractstatus.DropDownStyle = ComboBoxStyle.Simple;// = false;
        //                this.cb_contractstatus.Text = rs.Consts;
        //                //  this.cb_contractstatus.Enabled = false;
        //                this.bt_etcontract.Visible = true;



        //                if (used.inputcontractfinalcontrol == true)
        //                {


        //                    undogroup.Visible = true;

        //                    undogroup.Enabled = true;
        //                    // bt_fin.Visible = true;
        //                    bt_finundo.Visible = true;
        //                    bt_cancel.Visible = true;
        //                    bt_close.Visible = true;
        //                    btchangeRemark.Visible = true;
        //                    btchangecontrcatype.Visible = true;
        //                    btchangeregion.Visible = true;


        //                    btchanegcontract.Visible = true;

        //                    btchangecret.Visible = true;
        //                    btchangecret.Visible = true;
        //                    btcfromdate.Visible = true;
        //                    btchagetodate.Visible = true;


        //                    btrepresent.Visible = true;
        //                    btchangetradename.Visible = true;
        //                    bthomeso.Visible = true;
        //                    btchangedistric.Visible = true;
        //                    btchangeprovince.Visible = true;
        //                    btvatchange.Visible = true;


        //                    bt_undoclose.Visible = true;
        //                    bt_undocancel.Visible = true;



        //                }
        //                else
        //                {
        //                    undogroup.Visible = false;
        //                }
        //                // undogroup

        //            }
        //            else
        //            {
        //                this.cb_contractstatus.DropDownStyle = ComboBoxStyle.Simple;// = false;
        //                this.cb_contractstatus.Text = rs.Consts;
        //                this.cb_contractstatus.Enabled = false;
        //                this.bt_etcontract.Visible = false;
        //            }

        //            //     MessageBox.Show(this.Text);

        //            // txt_term
        //            //  MessageBox.Show(rs.ConType);


        //            #endregion

        //            if (formlabel == "DISPLAY PAYMENT CONTRACT")
        //            {

        //                btchangecontractitem.Visible = false;
        //                btaddnewItem.Visible = false;

        //            }   // formlabel == "DISPLAY PAYMENT CONTRACT"


        //            loadtotaldContractView(ContractNoin);

        //            loadDetailContractView(ContractNoin);






        //            undogroup.Visible = true;

        //            //           Model.Username used = new Model.Username();
        //            if (used.inputcontractfinalcontrol == true)
        //            {


        //                undogroup.Visible = true;

        //                undogroup.Enabled = true;
        //                // bt_fin.Visible = true;
        //                bt_finundo.Visible = true;
        //                bt_cancel.Visible = true;
        //                bt_close.Visible = true;
        //                btchangeRemark.Visible = true;

        //                btchangecontrcatype.Visible = true;
        //                btchangeregion.Visible = true;

        //                btchanegcontract.Visible = true;
        //                btchangecret.Visible = true;
        //                btrepresent.Visible = true;
        //                btchangetradename.Visible = true;
        //                bthomeso.Visible = true;
        //                btchangedistric.Visible = true;
        //                btchangeprovince.Visible = true;
        //                btvatchange.Visible = true;




        //                bt_undoclose.Visible = true;
        //                bt_undocancel.Visible = true;


        //            }
        //            else
        //            {
        //                undogroup.Enabled = false;
        //            }
        //            //    undogroup
        //            if (cb_contractstatus.Text == "CRT")
        //            {

        //                bt_fin.Visible = true;
        //                btdelete.Enabled = true;
        //                // btcfromdate.Visible = true;
        //                //     btchagetodate.Visible = true;

        //                //bt_finundo.Visible = false;
        //                //bt_cancel.Visible = false;
        //                //bt_close.Visible = false;
        //                //bt_undoclose.Visible = false;
        //                //bt_undocancel.Visible = false;
        //            }
        //        }
        //        #endregion view

        //        // addcombound






        //        var rs2 = from tbl_Kapriod in dc.tbl_Kapriods
        //                      //  group tbl_Comboundtemp by tbl_Comboundtemp.Region into grthis2
        //                  select tbl_Kapriod;

        //        string drowdownshow = "";

        //        foreach (var item in rs2)
        //        {
        //            drowdownshow = item.Priod;
        //            cb_priod.Items.Add(drowdownshow);
        //            cb_priod2.Items.Add(drowdownshow);

        //        }


        //    }

        //    #endregion


        //    #endregion



        }




        private void bindDataToDataGridViewComboPrograme()
        {


            //#region

            
            //DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();

            ////  dataGridProgramdetail.Columns["Program"].
            //// List<String> itemCodeList = new List<String>();
            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            ////  CombomCollection = null;
            //List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            //var rs = from tbl_kaprogramlist in dc.tbl_kaprogramlists
            //         orderby tbl_kaprogramlist.Name
            //         select tbl_kaprogramlist;
            //foreach (var item in rs)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.Code;
            //    cb.Text = item.Code.Trim() + ": " + item.Name;
            //    CombomCollection.Add(cb);
            //}
            //cmbdgv.DataSource = CombomCollection;
            //cmbdgv.HeaderText = "Program";
            //cmbdgv.Name = "Program";
            //cmbdgv.ValueMember = "Value";
            //cmbdgv.DisplayMember = "Text";
            //cmbdgv.Width = 100;
            //cmbdgv.DropDownWidth = 180;
            //dataGridProgramdetail.Columns.Add(cmbdgv);

            //#endregion



        }
        private void bindDataToDataGridViewComboPayment_Control()
        {

            //#region

            
            //DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();

            ////  dataGridProgramdetail.Columns["Program"].
            //// List<String> itemCodeList = new List<String>();
            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            ////  CombomCollection = null;
            //List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            //var rs = from tbl_Kafuctionlist in dc.tbl_Kafuctionlists
            //         orderby tbl_Kafuctionlist.Code
            //         select tbl_Kafuctionlist;
            //foreach (var item in rs)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.Code;
            //    cb.Text = item.Code + ": " + item.Description + "    || Example: " + item.Example;
            //    CombomCollection.Add(cb);
            //}
            //cmbdgv.DataSource = CombomCollection;
            //cmbdgv.HeaderText = "Payment_Control";
            //cmbdgv.Name = "Payment_Control";
            //cmbdgv.ValueMember = "Value";
            //cmbdgv.DisplayMember = "Text";
            //cmbdgv.Width = 300;
            //cmbdgv.DropDownWidth = 800;

            //dataGridProgramdetail.Columns.Add(cmbdgv);

            //#endregion


        }

        private void bindDataToDataGridViewComboproductgroup_Control()
        {


            //#region

            
            //DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();

            ////  dataGridProgramdetail.Columns["Program"].
            //// List<String> itemCodeList = new List<String>();
            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            ////  CombomCollection = null;
            //List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            //var rs = from tbl_kaPrdgrp in dc.tbl_kaPrdgrps
            //         orderby tbl_kaPrdgrp.PrdGrp
            //         select tbl_kaPrdgrp;
            //foreach (var item in rs)
            //{
            //    ComboboxItem cb = new ComboboxItem();
            //    cb.Value = item.PrdGrp;
            //    cb.Text = item.PrdGrp + ": " + item.ProductGroup;// + "- Exp : " + item.Example;
            //    CombomCollection.Add(cb);
            //}
            //cmbdgv.DataSource = CombomCollection;
            //cmbdgv.HeaderText = "Product Group";
            //cmbdgv.Name = "Product_Group";
            //cmbdgv.ValueMember = "Value";
            //cmbdgv.DisplayMember = "Text";
            //cmbdgv.Width = 70;
            //cmbdgv.DropDownWidth = 200;

            //dataGridProgramdetail.Columns.Add(cmbdgv);


            //#endregion

        }


        //  cmbdgv.Items.Add("Test");


        void cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(EndEdit));

        }
        ComboBox cbm;
        DataGridViewCell currentCell;
        //  private DateTimePicker cellDateTimePicker = new DateTimePicker();
        // DateTimePicker[] sp = new DateTimePicker[100];
        void EndEdit()
        {




            if (cbm != null)
            {
                if (cbm.SelectedItem != null)
                {
                    string SelectedItem = (cbm.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

                    // int i = dataGridProgramdetail.CurrentRow.Index;
                    int i = currentCell.RowIndex;
                    string colname = this.dataGridProgramdetail.Columns[this.dataGridProgramdetail.CurrentCell.ColumnIndex].Name;

                    dataGridProgramdetail.Rows[i].Cells[colname].Value = SelectedItem;
                    //      MessageBox.Show(dataGridProgramdetail.Rows[i].Cells["Program"].Value.ToString());

                }





            }


            //}
        }

        private void dataGridProgramdetail_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {

                cbm = (ComboBox)e.Control;

                if (cbm != null)
                {
                    cbm.SelectedIndexChanged += new EventHandler(cbm_SelectedIndexChanged);
                }

                currentCell = this.dataGridProgramdetail.CurrentCell;

            }
        }

        private void dataGridProgramdetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            //string colheadertext = this.dataGridProgramdetail.Columns[this.dataGridProgramdetail.CurrentCell.ColumnIndex].HeaderText;
            //if (colheadertext == "TargetUnit")
            //{

            //    if (this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Payment_Control"].Value != null && this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null)
            //    {

            //        string paymentcontrol = this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Payment_Control"].Value.ToString();
            //        string progarme = this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value.ToString();



            //        MessageBox.Show("ok done !" + paymentcontrol + ":" + progarme);
            //    }
            //}


        }

        private void dataGridProgramdetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


            //#region

            
            //string colname = this.dataGridProgramdetail.Columns[this.dataGridProgramdetail.CurrentCell.ColumnIndex].Name;

            ////  MessageBox.Show(colname);
            //if (colname == "Program")
            //{
            //    if (this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null) // && this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null
            //    {
            //        string programe = this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value.ToString();

            //        #region pdis programe


            //        if (programe.Trim() == "DIS")  //     discount on invocie
            //        {
            //            //   MessageBox.Show(programe);
            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Style.ForeColor = Color.Blue;

            //            if (dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Value == null || dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Value.ToString().Trim() != "DIS")
            //            {
            //                dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Control"].Value = "DIS";
            //            }

            //            #region viewdetail
            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all



            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "";

            //            #endregion view detail


            //            #endregion nomale all


            //        }
            //        #endregion




            //    }

            //}


            //#region control_payment


            //if (colname == "Payment_Control")
            //{

            //    if (this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Payment_Control"].Value != null) // && this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Program"].Value != null
            //    {

            //        string paymentcontrol = this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["Payment_Control"].Value.ToString();


            //        #region payment type DIs


            //        if (paymentcontrol == "DIS")
            //        {
            //            //if (dataGridProgramdetail.Rows[e.RowIndex].Cells["Program"].Value == null || dataGridProgramdetail.Rows[e.RowIndex].Cells["Program"].Value.ToString().Trim() != "DIS")
            //            //{
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Program"].Value = "DIS";
            //            //}


            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all



            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "";

            //        }
            //        #endregion


            //        #region payment type  C00  tra khong dieu kien


            //        if (paymentcontrol == "C00")
            //        {

            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;


            //        }
            //        #endregion


            //        #region payment type  C01 //- tra bao nhieu do vao ngay co dinh


            //        if (paymentcontrol == "C01")
            //        {


            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all


            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            // dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;

            //        }
            //        #endregion



            //        #region payment type  C02  - dat bao nhieu phan tram doanh so


            //        if (paymentcontrol == "C02")
            //        {


            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            ////dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = double.Parse(txtvaluevolumecommit);//System.DBNull.Value;
            //                                                                                                                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //                                                                                                                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;                                                                                                   //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



            //        }
            //        #endregion


            //        #region payment type  C03  - dat doanh so krt thung


            //        if (paymentcontrol == "C03")
            //        {


            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
            //            // dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;




            //        }
            //        #endregion


            //        #region payment type  C04  - dat so doanh thu thi tra tien


            //        if (paymentcontrol == "C04")
            //        {

            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all


            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = cb_curency.Text;
            //            // dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;



            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



            //        }
            //        #endregion



            //        #region payment type  C05 //- tra bao nhieu do vao ngay co dinh


            //        if (paymentcontrol == "C05")
            //        {


            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all


            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = dateTimePicker1.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;




            //        }
            //        #endregion


            //        #region payment type  C06  - dat bao nhieu phan tram doanh so


            //        if (paymentcontrol == "C06")
            //        {


            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all



            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            ////dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = double.Parse(txtvaluevolumecommit);//System.DBNull.Value;
            //                                                                                                                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //                                                                                                                        //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //                                                                                                                        //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



            //        }
            //        #endregion




            //        #region payment type  D01  - Trả theo két thùng bán được


            //        if (paymentcontrol == "D01")
            //        {



            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all



            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
            //            // dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;




            //        }
            //        #endregion

            //        #region payment type  D02  - Trả theo két thùng bán được


            //        if (paymentcontrol == "D02")
            //        {


            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "LITTER";
            //            // dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;




            //        }
            //        #endregion

            //        #region payment type  D03  - Trả theo pc


            //        if (paymentcontrol == "D03")
            //        {

            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all



            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;


            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "KÉT";
            //            // dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;

            //        }
            //        #endregion


            //        #region payment type  P00  tra khong dieu kien


            //        if (paymentcontrol == "P00")
            //        {


            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all


            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "% NSR";
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = cb_curency.Text;// System.DBNull.Value;
            //                                                                                               //    dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //                                                                                               //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;



            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;




            //        }
            //        #endregion


            //        #region payment type  P01  tra khong dieu kien


            //        if (paymentcontrol == "P01")
            //        {



            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all


            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = cb_curency.Text;// System.DBNull.Value;
            //                                                                                               //    dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //                                                                                               //   dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "% NSR";

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = true;




            //        }
            //        #endregion


            //        #region payment type  P02  - dat bao nhieu phan tram doanh so tra thepo % NSR


            //        if (paymentcontrol == "P02")
            //        {


            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all


            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            ////dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = double.Parse(txtvaluevolumecommit);//System.DBNull.Value;
            //                                                                                                                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "% NSR";                                                                                                          //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //                                                                                                                                                                                                   //   dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;                                                                                                   //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



            //        }
            //        #endregion


            //        #region payment type  P03  - dat bao nhieu phan tram doanh so tra thepo % NSR


            //        if (paymentcontrol == "P03")
            //        {


            //            #region nomal all
            //            //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = false;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = false;

            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = false;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].ReadOnly = false;

            //            //     dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = false;




            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = false;

            //            //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = false;


            //            //        dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = false;


            //            //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.White;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].ReadOnly = false;


            //            #endregion nomale all


            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Fund_Percent"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Percentage"].ReadOnly = true;

            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Value = System.DBNull.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].Style.ForeColor = Color.DarkGray;
            //            ////dataGridProgramdetail.Rows[e.RowIndex].Cells["VAT"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Sponsored_Amount"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].ReadOnly = true;

            //            string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Value = double.Parse(txtvaluevolumecommit);//System.DBNull.Value;
            //                                                                                                                        //    dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = "% NSR";                                                                                                          //   dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].Style.ForeColor = Color.DarkGray;
            //                                                                                                                                                                                                   //   dataGridProgramdetail.Rows[e.RowIndex].Cells["SponsortUnit"].Value = cb_curency.Text;                                                                                                   //dataGridProgramdetail.Rows[e.RowIndex].Cells["Taget_Achivement"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Value = "PC";
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].Style.ForeColor = Color.Blue;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["TargetUnit"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Value = System.DBNull.Value;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.BackColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].Style.ForeColor = Color.DarkGray;
            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Payment_Commit_Date"].ReadOnly = true;

            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Value = dateTimePicker1.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.BackColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].Style.ForeColor = Color.DarkGray;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_From"].ReadOnly = true;


            //            dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Value = dateTimePicker2.Value;
            //            //dataGridProgramdetail.Rows[e.RowIndex].Cells["Effect_To"].Style.BackColor = Color.DarkGray;



            //        }
            //        #endregion



            //    }

            //}

            //#endregion control payment


            //#endregion




        }

        private void dataGridViewtotal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewtotal.Rows[e.RowIndex].Cells["Programe"].Value.ToString() == "Total")
            { // condition


                e.CellStyle.BackColor = Color.LightSteelBlue;
                e.CellStyle.ForeColor = Color.OrangeRed;


            }
        }

        private void cb_customerka_KeyPress(object sender, KeyPressEventArgs e)
        {

            //#region


            

            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    string valueinput = cb_customerka.Text;

            //    string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //    string username = Utils.getusername();

            //    var regioncode = (from tbl_Temp in dc.tbl_Temps
            //                      where tbl_Temp.username == username
            //                      select tbl_Temp.RegionCode).FirstOrDefault();


            //    var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
            //                 where ((int)tbl_KaCustomer.Customer).ToString().Contains(valueinput) && tbl_KaCustomer.SapCode == true
            //                 && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
            //                   ).Contains(tbl_KaCustomer.SALORG_CTR)
            //                 select new
            //                 {
            //                     tbl_KaCustomer.Region,
            //                     tbl_KaCustomer.Customer,
            //                     tbl_KaCustomer.FullNameN,
            //                     tbl_KaCustomer.SapCode,

            //                 };




            //    Utils ut = new Utils();
            //    var tblcustomer = ut.ToDataTable(dc, rscode);

            //    Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one code !");
            //    viewtb.ShowDialog();
            //    string codetemp = viewtb.valuecode;
            //    //  string region = viewtb.region;


            //    if (codetemp != "0" && codetemp != null)
            //    {
            //        cb_customerka.Text = codetemp;
            //        cb_customerka.Enabled = false;
            //        txtcustgroup.Text = "";
            //        txtfindsacode.Text = "";
            //        cbcust.Checked = true;
            //        cbgroup.Checked = false;
            //        cbsfa.Checked = false;



            //    }
            //    else
            //    {
            //        cb_customerka.Text = "";
            //        cb_customerka.Enabled = true;
            //        cbcust.Checked = false;

            //    }



            //}

            //#endregion



        }

        private void cb_delivery_KeyPress(object sender, KeyPressEventArgs e)
        {

            //#region


            


            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    string valueinput = cb_delivery.Text;

            //    string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //    var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
            //                 where tbl_KaCustomer.Customer.ToString().Contains(valueinput) && (tbl_KaCustomer.SapCode == true)
            //                 select new
            //                 {
            //                     tbl_KaCustomer.Region,
            //                     tbl_KaCustomer.Customer,
            //                     tbl_KaCustomer.FullNameN,
            //                     tbl_KaCustomer.SapCode,

            //                 };




            //    Utils ut = new Utils();
            //    var tblcustomer = ut.ToDataTable(dc, rscode);

            //    Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one  delivery code !");
            //    viewtb.ShowDialog();
            //    string codetemp = viewtb.valuecode;

            //    if (codetemp != "0" && codetemp != null)
            //    {
            //        cb_delivery.Text = codetemp;
            //        cb_delivery.Enabled = false;
            //        //  cb_customerka.Text = "";
            //        //  txtfindsacode.Text = "";

            //        //   cbcust.Checked = false;
            //        //    cbgroup.Checked = true;
            //        //    cbsfa.Checked = false;
            //        //



            //    }
            //    else
            //    {
            //        cb_delivery.Text = "";
            //        cb_delivery.Enabled = true;
            //        //   cbgroup.Checked = false;

            //    }


            //    txt_volumecomit.Focus();
            //}


            //#endregion


        }

        private void cb_customerka_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void cb_customerka_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }

        private void cb_customerka_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_represennt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                cb_channel.Focus();




            }
        }

        private void cb_channel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                cb_delivery.Focus();




            }
        }

        private void button6_Click(object sender, EventArgs e)
        {


            //#region


            

            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //tbl_kacontractdata newcontract = new tbl_kacontractdata();


            //#region kiểm tra contract có dublicate ??
            //if (this.tb_contractno.Text != null)
            //{


            //    string ContractNo = this.tb_contractno.Text.Trim();

            //    var rs = (from tbl_kacontractmasterdata in dc.tbl_kacontractdatas
            //              where tbl_kacontractmasterdata.ContractNo == ContractNo
            //              select tbl_kacontractmasterdata.ContractNo).FirstOrDefault();

            //    if (rs != null)
            //    {
            //        MessageBox.Show("Contract No. existed, please check ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //        return;
            //    }

            //}

            //#endregion

            //#region  update data   check

            //#region  // customer tyoe

            //newcontract.Customer = 0;

            //if (this.cbcust.Checked == true)
            //{
            //    try
            //    {
            //        newcontract.Customer = double.Parse(cb_customerka.Text.Trim());// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            //        newcontract.CustomerType = "SAP";

            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("Code khách hàng update sai, please check ! \n " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;


            //    }


            //}


            //if (this.cbgroup.Checked == true)
            //{
            //    try
            //    {
            //        newcontract.Customer = double.Parse(txtcustgroup.Text.Trim());// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            //        newcontract.CustomerType = "GRP";

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Code nhóm update sai, please check ! \n " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;

            //    }


            //}

            //if (this.cbsfa.Checked == true)
            //{
            //    try
            //    {
            //        newcontract.Customer = double.Parse(txtfindsacode.Text.Trim());// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            //        newcontract.CustomerType = "SFA";

            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("Code SFA upate sai, please check ! \n " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;

            //    }


            //}


            //if (newcontract.Customer == 0)
            //{
            //    MessageBox.Show("Please select a Customer ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            //#endregion

            //#region cac nut



            //// nếu không duplicate thì tiết hành add new contract
            //if (this.cb_channel.SelectedItem != null)
            //{
            //    //  newcontract.Channel = this.cb_channel.SelectedItem.ToString();

            //    newcontract.Channel = (cb_channel.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            //}
            //else
            //{
            //    MessageBox.Show("Please select a Chanel ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}



            //if (this.cb_contractstatus.SelectedItem != null)
            //{
            //    newcontract.Consts = this.cb_contractstatus.SelectedItem.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Please select a Contract status ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}



            //if (this.tb_contractno.Text != "")
            //{
            //    newcontract.ContractNo = this.tb_contractno.Text.Trim();

            //}
            //else
            //{
            //    MessageBox.Show("Please input Contract No. ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (this.cb_contracttype.SelectedItem != null)
            //{
            //    newcontract.ConType = this.cb_contracttype.SelectedItem.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Please select a Contract Type ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //string usrname = Utils.getusername();


            //if (this.cb_curency.SelectedItem != null)
            //{
            //    newcontract.Currency = this.cb_curency.SelectedItem.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Please check Currency ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}



            //if (this.txt_represennt.Text != "")
            //{
            //    newcontract.Representative = this.txt_represennt.Text;
            //}
            //else
            //{
            //    //  MessageBox.Show("Please update Representative !  ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //  return;

            //    newcontract.Representative = "";

            //}


            //// txt_chananame


            //if (this.txt_chananame.Text != "")
            //{
            //    newcontract.Fullname = this.txt_chananame.Text;
            //}
            //else
            //{
            //    MessageBox.Show("Please update Trade Name !  ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (tb_creditlimit.Text !="" && tb_creditlimit.Text != null)
            //{

            //    string txtvaluetb_creditlimit = (tb_creditlimit.Text.Replace(",", "")).Replace(".", "");

            //    if (Utils.IsValidnumber(txtvaluetb_creditlimit))
            //    {
            //        newcontract.CreditLimit = double.Parse(txtvaluetb_creditlimit);
            //    }
            //    else
            //    {


            //        MessageBox.Show("Please check credit limit number !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }

            //}
            //else
            //{
            //    newcontract.CreditLimit = 0;
            //}



            //if (this.cb_paymentterm.SelectedItem != null)
            //{
            //    newcontract.CreditTerm = this.cb_paymentterm.SelectedItem.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Please select credit term ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            ////      newcontract.FullName = txt_chananame.Text;
            ////  cb_delivery
            //if (this.cb_delivery.SelectedItem != null)
            //{
            //    newcontract.DeliveredBy = (cb_delivery.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            //}


            ////   newcontract.SalesOrg = cb_salesogr
            //if (this.cb_salesogr.SelectedItem != null)
            //{
            //    newcontract.SalesOrg = this.cb_salesogr.SelectedItem.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Please check Sales Org ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            //double volcom = 0;
            //if (txt_volumecomit.Text != "" && txt_volumecomit.Text != null)
            //{

            //    string txtvaluetxt_volumecomit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
            
            //    if (Utils.IsValidnumber(txtvaluetxt_volumecomit))
            //    {
            //        newcontract.VolComm = double.Parse(txtvaluetxt_volumecomit);
            //        volcom = double.Parse(txtvaluetxt_volumecomit);
            //    }
            //    else
            //    {
            //        // txt_volumecomit.Text = "0";
            //        //    newcontract.VolComm = 0;
            //        MessageBox.Show("Please check Commitment volume ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //}

            

            //int varyear = 1;

            //try
            //{
            //    varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());

            //    if (varyear <= 0)
            //    {

            //        varyear = 1;
            //    }

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Please check Eff and EFT date ! " + ex.ToString(), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;


            //}
            ////   newcontract.ConTerm = int.Parse(txt_term.Text);
            //this.txt_term.Text = varyear.ToString();
            //newcontract.ConTerm = varyear;//int.Parse(txt_term.Text);






            //if (Utils.IsValidnumber(txt_volumecomit.Text))
            //{


            //    #region load term and yeayr  


            //    this.txt_annualvolume.Text = (volcom / varyear).ToString();
            //    newcontract.AnnualVolume = volcom / varyear;
            //    #endregion

            //}




            //if (this.txt_district.Text != "")
            //{
            //    newcontract.District = this.txt_district.Text;//.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Please check District ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            //if (this.txt_provicen.Text != "")
            //{
            //    newcontract.Province = this.txt_provicen.Text;//.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Please check Province ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            //if (this.txt_houseno.Text != "")
            //{
            //    newcontract.HouseNo = this.txt_houseno.Text;//.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Please check House No ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //#endregion cacs nut 


            //#region kiem tra va updaate dataGridProgramdetail vao detail

            ////  dataGridProgramdetail
            ////  newdetailContract

            //List<tbl_kacontractsdatadetail> tbl_kacontractsdatadetaillist = new List<tbl_kacontractsdatadetail>();

            //for (int idrow = 0; idrow < dataGridProgramdetail.RowCount - 1; idrow++)
            //{


            //    #region product group type


            //    tbl_kacontractsdatadetail newdetailContract = new tbl_kacontractsdatadetail();
            //    newdetailContract.Customercode = newcontract.Customer;//double.Parse(cb_customerka.Text);// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            //    newdetailContract.CustomerType = newcontract.CustomerType;

            //    if ((String)dataGridProgramdetail.Rows[idrow].Cells["Program"].Value != null)
            //    {
            //        newdetailContract.PayType = dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString().Trim(); // chính la program
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please check Program ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }

            //    if ((String)dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value != null)
            //    {
            //        newdetailContract.PayControl = dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString();
            //        var rsDescription = (from tbl_Kafuctionlist in dc.tbl_Kafuctionlists
            //                             where tbl_Kafuctionlist.Code == newdetailContract.PayControl
            //                             select tbl_Kafuctionlist).FirstOrDefault();
            //        if (rsDescription != null)
            //        {
            //            newdetailContract.Description = rsDescription.Code + ": " + rsDescription.Description;
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("Please check Payment_Control ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }

            //    newdetailContract.ContractNo = this.tb_contractno.Text.Trim();
            //    newdetailContract.VATregistrationNo = this.txtVATno.Text.Trim();

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Product_Group"].Value != null)
            //    {

            //        newdetailContract.PrdGrp = dataGridProgramdetail.Rows[idrow].Cells["Product_Group"].Value.ToString();

            //    }
            //    else
            //    {
            //        MessageBox.Show("Please check Product_Group ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }

            //    #endregion product group type

            //    //condition Cells["Payment_Control"].Value.ToString() == "C00"



            //    #region //condition Cells["Payment_Control"].Value.ToString() == "DIS"

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString().Trim() != "DIS" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString().Trim() == "DIS")
            //    {

            //        MessageBox.Show("Please check Program line: " + (idrow + 1) + "must be DIS", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Program"].Value.ToString().Trim() == "DIS" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString().Trim() != "DIS")
            //    {

            //        MessageBox.Show("Please check Payment_Control line: " + (idrow + 1) + "must be DIS", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
            //    {
            //        MessageBox.Show("Please check Amount_Per_Pc_Lit_FTN and  Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
            //    {

            //        newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
            //        dataGridProgramdetail.Rows[idrow].Cells["SponsortUnit"].Value = cb_curency.Text;



            //    }

            //    if ((dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "") && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
            //    {

            //        //     newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
            //        newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
            //        dataGridProgramdetail.Rows[idrow].Cells["SponsortUnit"].Value = "%";


            //    }

            //    if ((dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "") && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
            //    {

            //        //     newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
            //        newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;



            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "DIS")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }





            //    #endregion



            //    #region //condition Cells["Payment_Control"].Value.ToString() == "C00"

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C00")
            //    {

            //        newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C00")
            //    {
            //        MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }






            //    #endregion


            //    //condition Cells["Payment_Control"].Value.ToString() == "C01"

            //    #region //condition Cells["Payment_Control"].Value.ToString() == "C01"

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C01")
            //    {

            //        newdetailContract.CommittedDate = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C01")
            //    {
            //        MessageBox.Show("Please check Payment Date line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C01")
            //    {

            //        newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C01")
            //    {
            //        MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }




            //    #endregion

            //    //C02


            //    #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02"


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
            //    {

            //        newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
            //    {
            //        MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
            //    {

            //        if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value > 0)
            //        {
            //            newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;
            //        }
            //        else
            //        {

            //            MessageBox.Show("Please check Taget_Achivement must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;

            //        }
            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
            //    {
            //        MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
            //    {
            //        if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value >= 0 && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value <= 100)
            //        {
            //            newdetailContract.TagetPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Taget Percentage must between 100 %, please check line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;

            //        }

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
            //    {
            //        MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }



            //    //---
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }

            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C02")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }


            //    //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



            //    #endregion


            //    #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03"


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    {

            //        newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    {
            //        MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    {

            //        newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    {
            //        MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }
            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    //{
            //    //    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value >= 0 && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value <= 100)
            //    //    {
            //    //        newdetailContract.TagetPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value;
            //    //    }
            //    //    else
            //    //    {
            //    //        MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //        return;

            //    //    }



            //    //    //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //    //    //      dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].ValueType = typeof(System.Double)
            //    //}
            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    //{
            //    //    MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //    return;



            //    //}

            //    //---
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }


            //    //       newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



            //    #endregion



            //    #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04"


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
            //    {

            //        newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
            //    {
            //        MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
            //    {

            //        newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
            //    {
            //        MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }
            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    //{
            //    //    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value >= 0 && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value <= 100)
            //    //    {
            //    //        newdetailContract.TagetPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value;
            //    //    }
            //    //    else
            //    //    {
            //    //        MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //        return;

            //    //    }



            //    //    //       dataGridProgramdetail.Rows[e.RowIndex].Cells["Amount_Per_Pc_Lit_FTN"].Value = System.DBNull.Value;
            //    //    //      dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].ValueType = typeof(System.Double)
            //    //}
            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C03")
            //    //{
            //    //    MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //    return;



            //    //}

            //    //---
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C04")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }


            //    //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



            //    #endregion



            //    #region //condition Cells["Payment_Control"].Value.ToString() == "C05"



            //    //}

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C05")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C05")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C05")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }



            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C05")
            //    {

            //        newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C05")
            //    {
            //        MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }




            //    #endregion



            //    #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06"


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
            //    {

            //        newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
            //    {
            //        MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
            //    {
            //        if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value > 0)
            //        {
            //            newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;
            //        }
            //        else
            //        {

            //            MessageBox.Show("Please check Taget_Achivement must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;

            //        }

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06" && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value <= 0)
            //    {
            //        MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }


            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "c06")
            //    //{
            //    //    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value >= 0 && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value <= 100)
            //    //    {
            //    //        newdetailContract.TagetPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value;
            //    //    }
            //    //    else
            //    //    {
            //    //        MessageBox.Show("Taget Percentage must between 100 %, please check line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //        return;

            //    //    }

            //    //}

            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "c06")
            //    //{
            //    //    MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //    return;



            //    //}



            //    //---
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }

            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }
            //    //    else
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "C06")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }


            //    //  newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



            //    #endregion






            //    #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01"

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
            //    {
            //        //newdetailContract.SponsoredAmtperPC
            //        newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
            //    {
            //        MessageBox.Show("Please check Amount Per Pc/Lit/FTN  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //---
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D01")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }


            //    //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



            //    #endregion


            //    #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02"

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
            //    {
            //        //newdetailContract.SponsoredAmtperPC
            //        newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
            //    {
            //        MessageBox.Show("Please check Amount Per Pc/Lit/FTN  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //---
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D02")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }


            //    //      newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



            //    #endregion



            //    #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03"

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
            //    {
            //        //newdetailContract.SponsoredAmtperPC
            //        newdetailContract.SponsoredAmtperPC = (double)dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value;
            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Amount_Per_Pc_Lit_FTN"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
            //    {
            //        MessageBox.Show("Please check Amount Per Pc/Lit/FTN  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //---
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "D03")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }


            //    //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



            //    #endregion



            //    #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00"
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
            //    {
            //        //newdetailContract.SponsoredAmtperPC
            //        newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
            //        if (newdetailContract.FundPercentage > 100 || newdetailContract.FundPercentage <= 0)
            //        {
            //            MessageBox.Show("Please check  % Sponsor must between 0% to 100%  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;


            //        }
            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
            //    {
            //        MessageBox.Show("Please check Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }


            //    //        newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
            //    {
            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;
            //    }


            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P00")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }


            //    #endregion



            //    #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01"
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
            //    {
            //        //newdetailContract.SponsoredAmtperPC
            //        newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
            //        if (newdetailContract.FundPercentage > 100 || newdetailContract.FundPercentage <= 0)
            //        {
            //            MessageBox.Show("Please check  % Sponsor must between 0% to 100%  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;


            //        }
            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
            //    {
            //        MessageBox.Show("Please check Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //---



            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
            //    {

            //        newdetailContract.CommittedDate = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Payment_Commit_Date"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P01")
            //    {
            //        MessageBox.Show("Please check Payment Date line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }


            //    if (dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value != null)
            //    {

            //        if ((string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value != "")
            //        {
            //            newdetailContract.TargetUnit = (String)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value.ToString().Trim();
            //        }

            //    }




            //    #endregion



            //    #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02"


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    {
            //        //newdetailContract.SponsoredAmtperPC
            //        newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
            //        if (newdetailContract.FundPercentage > 100 || newdetailContract.FundPercentage <= 0)
            //        {
            //            MessageBox.Show("Please check  % Sponsor must between 0% to 100%  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;


            //        }
            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    {
            //        MessageBox.Show("Please check Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //---



            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    //{

            //    //    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

            //    //}
            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    //{
            //    //    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //    return;



            //    //}


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    {

            //        if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value > 0)
            //        {
            //            newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;
            //        }
            //        else
            //        {

            //            MessageBox.Show("Please check Taget_Achivement must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;

            //        }
            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    {
            //        MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    {
            //        if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value >= 0 && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value <= 100)
            //        {
            //            newdetailContract.TagetPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Taget Percentage must between 100 %, please check line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;

            //        }

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    {
            //        MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }



            //    //---
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }

            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }


            //    //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



            //    #endregion


            //    #region dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03"


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
            //    {
            //        //newdetailContract.SponsoredAmtperPC
            //        newdetailContract.FundPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value;
            //        if (newdetailContract.FundPercentage > 100 || newdetailContract.FundPercentage <= 0)
            //        {
            //            MessageBox.Show("Please check  % Sponsor must between 0% to 100%  line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;


            //        }
            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Fund_Percent"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
            //    {
            //        MessageBox.Show("Please check Fund_Percent line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }
            //    //---



            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    //{

            //    //    newdetailContract.SponsoredAmt = (double)dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value;

            //    //}
            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Sponsored_Amount"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P02")
            //    //{
            //    //    MessageBox.Show("Please check SponsoredAmt line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //    return;



            //    //}


            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
            //    {

            //        if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value > 0)
            //        {
            //            newdetailContract.TagetAchivement = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value;
            //        }
            //        else
            //        {

            //            MessageBox.Show("Please check Taget_Achivement must be greater than 0 line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;

            //        }
            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Achivement"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
            //    {
            //        MessageBox.Show("Please check Taget_Achivement line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;



            //    }


            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() != "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
            //    //{
            //    //    if ((double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value >= 0 && (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value <= 100)
            //    //    {
            //    //        newdetailContract.TagetPercentage = (double)dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value;
            //    //    }
            //    //    else
            //    //    {
            //    //        MessageBox.Show("Taget Percentage must between 100 %, please check line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //        return;

            //    //    }

            //    //}

            //    //if (dataGridProgramdetail.Rows[idrow].Cells["Taget_Percentage"].Value.ToString() == "" && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
            //    //{
            //    //    MessageBox.Show("Please check Taget_Percentage line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //    return;



            //    //}



            //    //---
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
            //    {

            //        newdetailContract.EffFrm = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value;

            //    }
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_From"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
            //    {
            //        MessageBox.Show("Please check Effect_From line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }

            //    //--
            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value != null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
            //    {

            //        newdetailContract.EffTo = (DateTime)dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value;

            //    }

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Effect_To"].Value == null && dataGridProgramdetail.Rows[idrow].Cells["Payment_Control"].Value.ToString() == "P03")
            //    {
            //        MessageBox.Show("Please check Effect_To line: " + (idrow + 1), "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;

            //    }


            //    //     newdetailContract.TargetUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["TargetUnit"].Value;



            //    #endregion






            //    newdetailContract.CRDDAT = DateTime.Today;
            //    newdetailContract.CRDUSR = Utils.getusername();

            //    if (dataGridProgramdetail.Rows[idrow].Cells["Remark"].Value.ToString().Length < 225)
            //    {
            //        newdetailContract.Remark = dataGridProgramdetail.Rows[idrow].Cells["Remark"].Value.ToString().Trim();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please check Remarks line: " + (idrow + 1) + " is Too Long", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }


            //    newdetailContract.SALORG_CTR = Utils.getfirstusersalescontrolregion();
            //    newdetailContract.SalesOrg = this.cb_salesogr.SelectedItem.ToString();
            //    newdetailContract.Constatus = "CRT";
            //    newdetailContract.Fullname = this.txt_chananame.Text;
            //    newdetailContract.ConType = this.cb_contracttype.SelectedItem.ToString().Trim();
            //    newdetailContract.CustomerType = newcontract.CustomerType;
            //    newdetailContract.Address = this.txt_houseno.Text.Trim() + " " + txt_district.Text.Trim() + " " + txt_provicen.Text.Trim();


            //    if (dataGridProgramdetail.Rows[idrow].Cells["SponsortUnit"].Value != null)
            //    {
            //        if ((string)dataGridProgramdetail.Rows[idrow].Cells["SponsortUnit"].Value != "")
            //        {
            //            newdetailContract.SponsorUnit = (string)dataGridProgramdetail.Rows[idrow].Cells["SponsortUnit"].Value.ToString().Trim();
            //        }


            //    }



            //    if (dataGridProgramdetail.Rows[idrow].Cells["VAT"].Value.ToString() != "")
            //    {
            //        newdetailContract.VAT = true;

            //    }
            //    else
            //    {
            //        newdetailContract.VAT = false;
            //    }



            //    tbl_kacontractsdatadetaillist.Add(newdetailContract);

            //    //dc.tbl_kacontractsdatadetails.InsertOnSubmit(newdetailContract);




            //}







            //#endregion
            //if (tbl_kacontractsdatadetaillist.Count > 0)
            //{



            //    dc.tbl_kacontractsdatadetails.InsertAllOnSubmit(tbl_kacontractsdatadetaillist);
            //    dc.SubmitChanges();

            //    //   double contractno = double.Parse(this.tb_contractno.Text.Trim());
            //    newcontract.VATregistrationNo = txtVATno.Text.Trim();
            //    newcontract.CRDUSR = usrname;
            //    newcontract.SignOn = dateTimePicker1.Value;
            //    newcontract.CRDDAT = DateTime.Today;

            //    if (this.txt_remarkstt.Text.Length < 255)
            //    {

            //        newcontract.Remarks = this.txt_remarkstt.Text;

            //    }
            //    else
            //    {
            //        newcontract = null;
            //        MessageBox.Show("Remarks is too long, please check !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    newcontract.EffDate = this.dateTimePicker1.Value;
            //    newcontract.EftDate = this.dateTimePicker2.Value;
            //    newcontract.ExtDate = this.dateTimePicker3.Value;

            //    //   newcontract.VolPer

            //    //  newdetailContract.
            //    newcontract.SALORG_CTR = Utils.getfirstusersalescontrolregion();

            //    dc.tbl_kacontractdatas.InsertOnSubmit(newcontract);
            //    dc.SubmitChanges();
            //    MessageBox.Show("Contract " + tb_contractno.Text + " create done !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    //-------------
            //    #region  changr display 


            //    cb_customerka.Enabled = true;
            //    txtcustgroup.Enabled = true;
            //    txtfindsacode.Enabled = true;
            //    txtVATno.Text = "";

            //    contractdata.Add(tb_contractno.Text);
            //    // AD VAO SERVER DE LAM LAN SAU
            //    //contractautolist
            //    string username = Utils.getusername();
            //    tbl_autodataContract newauto = new tbl_autodataContract();
            //    newauto.ContractNo = tb_contractno.Text;
            //    newauto.Username = username;
            //    dc.tbl_autodataContracts.InsertOnSubmit(newauto);
            //    dc.SubmitChanges();
            //    //

            //    //     data.Add("Mac Jocky");
            //    //   data.Add("Millan Peter");
            //    // comboBox1.AutoCompleteCustomSource = data;
            //    tb_contractno.Text = "";
            //    //        tb_contractno.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    tb_contractno.AutoCompleteCustomSource = contractdata;

            //    //AutoCompleteSource.ListItems;
            //    //     tb_contractno.
            //    cb_contracttype.SelectedIndex = -1;
            //    cb_salesogr.SelectedIndex = -1;
            //    cb_paymentterm.SelectedIndex = -1;
            //    cb_channel.SelectedIndex = -1;
            //    cb_customerka.Text = "";
            //    txtcustgroup.Text = "";
            //    txtfindsacode.Text = "";
            //    txt_represennt.Text = "";
            //    txt_chananame.Text = "";
            //    txt_houseno.Text = "";

            //    txt_district.Text = "";

            //    txt_provicen.Text = "";
            //    cb_delivery.SelectedIndex = -1;
            //    txt_volumecomit.Text = "0";
            //    NSRcommit.Text = "0";
            //    txt_remarkstt.Text = "";
            //    txt_annualvolume.Text = "0";
            //    Nsaperyear.Text = "0";
            //    tb_creditlimit.Text = "0";



            //    loadDetaildContractcreatenew();

            //    //       panel1.Enabled = false;

            //    //                btupdatecontract.Visible = true;
            //    #endregion



            //}
            //else
            //{
            //    tbl_kacontractsdatadetaillist = null;
            //    newcontract = null;
            //    MessageBox.Show("Please add detail contract !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //#endregion update datato masterdata


            //#endregion


        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            int varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());
            if (varyear >= 0)
            {
                if (varyear == 0)
                {
                    varyear = 1;
                }


                this.txt_term.Text = varyear.ToString();


                string txtvaluetxt_volumecomit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
                string txtvaluensrcomit = (NSRcommit.Text.Replace(",", "")).Replace(".", "");

                #region load term and yeayr
                if (Utils.IsValidnumber(txt_volumecomit.Text) && Utils.IsValidnumber(txtvaluensrcomit))
                {
                    //this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker2.Value.Year + 1).ToString();
                    this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / double.Parse(txt_term.Text))).ToString();

                    this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvaluensrcomit) / double.Parse(txt_term.Text))).ToString();
                }
                #endregion

            }
            else
            {

                //     dateTimePicker1.Value = dateTimePicker2.Value;
                //   MessageBox.Show("Todate and Extdate must later Fromdate!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                varyear = 1;
                this.txt_term.Text = varyear.ToString();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            int varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());

            if (varyear == 0)
            {
                varyear = 1;
            }

            if (varyear >= 0)
            {

                this.txt_term.Text = varyear.ToString();


                #region load term and yeayr
                string txtvaluetxt_volumecomit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");
                string txtvalueNSRcommit = (NSRcommit.Text.Replace(",", "")).Replace(".", "");

                if (Utils.IsValidnumber(txtvalueNSRcommit))
                {
                    //   this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker2.Value.Year + 1).ToString();
                    //    this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / double.Parse(txt_term.Text))).ToString();
                    this.dateTimePicker3.Value = this.dateTimePicker2.Value;
                    this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / double.Parse(txt_term.Text))).ToString();
                }
                else
                {
                    txtvalueNSRcommit = "0";
                    //this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / double.Parse(txt_term.Text))).ToString();
                    this.dateTimePicker3.Value = this.dateTimePicker2.Value;
                    this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / double.Parse(txt_term.Text))).ToString();


                }


                if (Utils.IsValidnumber(txtvaluetxt_volumecomit))
                {
                    //   this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker2.Value.Year + 1).ToString();
                    this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / double.Parse(txt_term.Text))).ToString();
                    this.dateTimePicker3.Value = this.dateTimePicker2.Value;
                    //     this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / double.Parse(txt_term.Text))).ToString();
                }
                else
                {
                    txtvaluetxt_volumecomit = "0";
                    this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluetxt_volumecomit) / double.Parse(txt_term.Text))).ToString();
                    this.dateTimePicker3.Value = this.dateTimePicker2.Value;


                }
                #endregion




            }


        }

        private void txt_volumecomit_TextChanged_1(object sender, EventArgs e)
        {
            string txtvaluevolumecommit = (txt_volumecomit.Text.Replace(",", "")).Replace(".", "");

            #region load term and yeayr
            if (Utils.IsValidnumber(txtvaluevolumecommit))
            {

                int varyear = 1;
                if (Utils.IsValidnumber(this.txt_term.Text))
                {


                    if (int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString()) != 0)
                    {
                        varyear = int.Parse(Math.Round((double)((this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).TotalDays / 365)).ToString());
                    }
                    else
                    {
                        varyear = 1;
                    }


                }
                else
                {
                    varyear = 1;
                }


                this.txt_annualvolume.Text = Math.Ceiling((double.Parse(txtvaluevolumecommit) / double.Parse(txt_term.Text))).ToString();
                this.txt_term.Text = varyear.ToString();

            }
            #endregion




        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.Text == "Input Contract")
            {
                FormCollection fc = System.Windows.Forms.Application.OpenForms;

                bool kq = false;
                foreach (Form frm in fc)
                {
                    ///  KAcontractlisting
                    ///    if (frm.Text == "CreatenewContract")
                    if (frm.Text == "Creat New Customer")
                    {
                        kq = true;
                        frm.Focus();

                    }
                }

                if (!kq)
                {



                    View.CreatnewCust CreatnewCust = new View.CreatnewCust(this);


                    CreatnewCust.Show();
                }





            }




        }

        private void dataGridProgramdetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormCollection fc = System.Windows.Forms.Application.OpenForms;

        //    bool kq = false;
            foreach (Form frm in fc)
            {


                if (frm.Text == "Payment request")
                {
                //    kq = true;
                    frm.Close();

                }
            }



            if (this.Text == "Payment Input" && formlabel.Text == "DISPLAY PAYMENT CONTRACT")  // pahir la pay ment requyet mowi sduoc tra tien 
            {

                //string ContractNo = (string)this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["ContractNo"].Value;
                string ContractNo = tb_contractno.Text;
                int PayID = int.Parse(this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["PayID"].Value.ToString());

                Model.Username used = new Model.Username();

                if (used.paymentcreate)
                {
                    View.Createpayment Createpayment = new View.Createpayment(this, ContractNo, PayID);



                    Createpayment.ShowDialog();
                }


            }


        }

        private void dataGridProgramdetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cb_channel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string ContractNo = this.tb_contractno.Text;


            //Control.Control_ac.CaculationContract(ContractNo);





            //loadtotaldContractView(ContractNo);
            //loadDetailContractView(ContractNo);







        }

        private void dataGridView7_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void dataGridView7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //#region

            

            //FormCollection fc = System.Windows.Forms.Application.OpenForms;

            //bool kq = false;
            //foreach (Form frm in fc)
            //{

            //    if (frm.Text == "Payment control")
            //    {
            //        kq = true;
            //        frm.Focus();

            //    }
            //}
            //if (!kq && this.Text == "Input Contract")  // pahir la pay ment requyet mowi sduoc tra tien 
            //                                           //     if (!kq)
            //{

            //    //string ContractNo = (string)this.dataGridProgramdetail.Rows[this.dataGridProgramdetail.CurrentCell.RowIndex].Cells["ContractNo"].Value;
            //    string ContractNo = tb_contractno.Text;
            //    int PayID = int.Parse(this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["PayID"].Value.ToString());

            //    int SubID = int.Parse(this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["SubID"].Value.ToString());



            //    int BatchNo = int.Parse(this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["BatchNo"].Value.ToString());
            //    string Programe = this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["PayControlID"].Value.ToString();

            //    string Description = "";
            //    if (this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["Description"].Value != null)
            //    {
            //        Description = this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["Description"].Value.ToString();
            //    }


            //    string PaymentDoc = "";
            //    if (this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["PaymentDoc"].Value != null)
            //    {
            //        PaymentDoc = this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["PaymentDoc"].Value.ToString();
            //    }

            //    double PaidRequestAmt = double.Parse(this.dataGridView7.Rows[this.dataGridView7.CurrentCell.RowIndex].Cells["PaidRequestAmt"].Value.ToString());
            //    //     public string header { get; set; }





            //    //        //   public string header { get; set; }
            //    //public kaconfirmPayment(View.CreatenewContract Contract, string ContractNo, string Batchno, string Programe, int PayID, int SubID, double PaidRequestAmt)
            //    //{
            //    if (PaidRequestAmt > 0)
            //    {

            //        Model.Username used = new Model.Username();

            //        if (used.inputcontractconfirm)
            //        {


            //            View.kaconfirmPayment paymentconf = new View.kaconfirmPayment(this, ContractNo, BatchNo, Programe, PayID, SubID, PaidRequestAmt, Description, PaymentDoc);


            //            paymentconf.Show();



            //        }





            //    }

            //    //            dataGridView7.DefaultCellStyle.kac

            //}

            //#endregion


        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

            //#region

            
            //string contractno = tb_contractno.Text.Trim(); //111

            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //// CaculationContract


            //#region (tabControl1.SelectedIndex == 0 )  // nuew la volume
            //if (tabControl1.SelectedIndex == 0 && formlabel.Text != "CREATING NEW CONTRACT")  // nuew la volume
            //{

            //    loadDetailContractView(contractno);


            //}

            //#endregion

            //#region  new la tab1 và tạo hợp đồng mới
            //if (tabControl1.SelectedIndex == 1 && formlabel.Text == "CREATING NEW CONTRACT")  // nuew la volume
            //{






            //}

            //#endregion

            //if (tabControl1.SelectedIndex == 1 && formlabel.Text != "CREATING NEW CONTRACT")  // nuew la volume
            //{

            //    #region  new la tab1 và display



            //    if (tabControl1.SelectedIndex == 1 && formlabel.Text != "CREATING NEW CONTRACT")  // nuew la volume
            //    {

            //        //              dataGriddiscountoninvoice.DataSource = dataGriddiscononinvocie;

            //        var dataGriddiscononinvocie = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
            //                                      where tbl_kacontractsdatadetail.ContractNo.Equals(contractno) && tbl_kacontractsdatadetail.PayControl == "DIS"
            //                                      select new
            //                                      {
            //                                          Programe = tbl_kacontractsdatadetail.PayType.Trim(),
            //                                          Description = tbl_kacontractsdatadetail.Description.Trim(),

            //                                          Product_Group = tbl_kacontractsdatadetail.PrdGrp,

            //                                          SponsorPercent = tbl_kacontractsdatadetail.FundPercentage,
            //                                          SponsorByUnit = tbl_kacontractsdatadetail.SponsoredAmtperPC,

            //                                          //        SponsorAmount = tbl_kacontractsdatadetail.SponsoredAmt,
            //                                          Unit = tbl_kacontractsdatadetail.SponsorUnit,
            //                                          Effect_From = tbl_kacontractsdatadetail.EffFrm,
            //                                          Effect_To = tbl_kacontractsdatadetail.EffTo,
            //                                          Remarks = tbl_kacontractsdatadetail.Remark,


            //                                      };

            //        dataGriddiscountoninvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //        dataGriddiscountoninvoice.DataSource = dataGriddiscononinvocie;


            //        //     this.dataGriddiscountoninvoice.Columns["Sponsor_Total"].DefaultCellStyle.Format = "N0";
            //        //        this.dataGriddiscountoninvoice.Columns["PaidRequest"].DefaultCellStyle.Format = "N0";
            //        //        this.dataGriddiscountoninvoice.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
            //        this.dataGridProgramdetail.Columns["SponsorByUnit"].DefaultCellStyle.Format = "N0";
            //        //this.dataGriddiscountoninvoice.Columns["SponsorAmount"].DefaultCellStyle.Format = "N0";
            //        //       this.dataGriddiscountoninvoice.Columns["Target_Achivement"].DefaultCellStyle.Format = "N0";
            //        //       this.dataGriddiscountoninvoice.Columns["Achivement"].DefaultCellStyle.Format = "N0";

            //        //     this.dataGriddiscountoninvoice.Columns["Sponsor_Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //        //        this.dataGriddiscountoninvoice.Columns["PaidRequest"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //        //       this.dataGriddiscountoninvoice.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //        //        this.dataGriddiscountoninvoice.Columns["SponsorAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //        //      this.dataGriddiscountoninvoice.Columns["Achivement"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            //    }
            //    #endregion


            //}



            //#region (tabControl1.SelectedIndex == 2)  // nuew la volume



            //if (tabControl1.SelectedIndex == 2)  // nuew la volume
            //{




            //    var rs1 = from tbl_kacontractsvolume in dc.tbl_kacontractsvolumes
            //              where tbl_kacontractsvolume.ContractNo.Equals(contractno)
            //              select new
            //              {

            //                  tbl_kacontractsvolume.Priod,
            //              PCs =    tbl_kacontractsvolume.EC,
            //              EC =    tbl_kacontractsvolume.PC,
            //                  tbl_kacontractsvolume.UC,
            //                  tbl_kacontractsvolume.Litter,
            //                  //     tbl_kacontractsvolume.Net_value,
            //                  NSR = tbl_kacontractsvolume.NSR,




            //              };


            //    //    dtg_volumeachived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //    dtg_volumeachived.DataSource = rs1;
            //    this.dtg_volumeachived.Columns["EC"].DefaultCellStyle.Format = "N0";
            //    this.dtg_volumeachived.Columns["PCs"].DefaultCellStyle.Format = "N0";
            //    this.dtg_volumeachived.Columns["UC"].DefaultCellStyle.Format = "N0";
            //    this.dtg_volumeachived.Columns["Litter"].DefaultCellStyle.Format = "N0";
            //    //     this.dtg_volumeachived.Columns["Net_value"].DefaultCellStyle.Format = "N0";
            //    this.dtg_volumeachived.Columns["NSR"].DefaultCellStyle.Format = "N0";

            //    //this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
            //    //this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Format = "N0";



            //    this.dtg_volumeachived.Columns["EC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dtg_volumeachived.Columns["PCs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    this.dtg_volumeachived.Columns["UC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dtg_volumeachived.Columns["Litter"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";
            //    this.dtg_volumeachived.Columns["NSR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";





            //}

            //#endregion



            //#region (tabControl1.SelectedIndex == 3)  // nuew la volume by grop



            //if (tabControl1.SelectedIndex == 3)  // nuew la volume
            //{
                
            //    var rs1 = from tbl_kacontractsvolumePrductGRP in dc.tbl_kacontractsvolumePrductGRPs
            //              where tbl_kacontractsvolumePrductGRP.ContractNo.Equals(contractno)
            //              orderby tbl_kacontractsvolumePrductGRP.Priod, tbl_kacontractsvolumePrductGRP.ProductGRP
            //              select new
            //              {
            //                  tbl_kacontractsvolumePrductGRP.Priod,
            //                  tbl_kacontractsvolumePrductGRP.ProductGRP,
            //                  PCs =     tbl_kacontractsvolumePrductGRP.EC,
            //                  EC =      tbl_kacontractsvolumePrductGRP.PC,
            //                  tbl_kacontractsvolumePrductGRP.UC,
            //                  tbl_kacontractsvolumePrductGRP.Litter,
            //                  //     tbl_kacontractsvolumePrductGRP.Net_value,
            //                  NSR = tbl_kacontractsvolumePrductGRP.NSR,



            //              }; // tbl_kacontractsvolumePrductGRP;



            //    dtagrviewvolumebyGRP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //    dtagrviewvolumebyGRP.DataSource = rs1;

            //    this.dtagrviewvolumebyGRP.Columns["EC"].DefaultCellStyle.Format = "N0";
            //    this.dtagrviewvolumebyGRP.Columns["PCs"].DefaultCellStyle.Format = "N0";
            //    this.dtagrviewvolumebyGRP.Columns["UC"].DefaultCellStyle.Format = "N0";
            //    this.dtagrviewvolumebyGRP.Columns["Litter"].DefaultCellStyle.Format = "N0";
            //    this.dtagrviewvolumebyGRP.Columns["NSR"].DefaultCellStyle.Format = "N0";



            //    this.dtagrviewvolumebyGRP.Columns["EC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    this.dtagrviewvolumebyGRP.Columns["PCs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    this.dtagrviewvolumebyGRP.Columns["UC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    this.dtagrviewvolumebyGRP.Columns["Litter"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            //    this.dtagrviewvolumebyGRP.Columns["NSR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            //}

            //#endregion


            //#region (tabControl1.SelectedIndex == 4)  // nuew batchno
            //if (tabControl1.SelectedIndex == 4)  // nuew la volume
            //{


            //    #region loaddatagridview


            //    var dataGridProgramdetailrs7 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
            //                                   where tbl_kacontractsdetailpayment.ContractNo == contractno // && tbl_kacontractsdetailpayment.BatchNo == BatchNo
            //                                   group tbl_kacontractsdetailpayment by tbl_kacontractsdetailpayment.BatchNo into g
            //                                   select new
            //                                   {

            //                                       BatchNo = g.Key,
            //                                       Paid_Amount = g.Sum(gg => gg.PaidAmt).GetValueOrDefault(0),// tbl_kacontractsdetailpayment.PaidAmt,
            //                                       PaidRequestAmt = g.Sum(gg => gg.PaidRequestAmt).GetValueOrDefault(0),//   tbl_kacontractsdetailpayment.PaidRequestAmt,
            //                                                                                                            // PaidConfAmt = g.Sum(gg => gg.PaidConfAmt).GetValueOrDefault(0),//   tbl_kacontractsdetailpayment.PaidRequestAmt,

            //                                       PrintChk = g.Select(gg => gg.PrintChk).FirstOrDefault(),//        tbl_kacontractsdetailpayment.PrintChk,
            //                                       Reprint = g.Select(gg => gg.Reprint).FirstOrDefault(),// tbl_kacontractsdetailpayment.Reprint,
            //                                       PrintDate = g.Select(gg => gg.PrintDate).FirstOrDefault(),//   tbl_kacontractsdetailpayment.PrintDate,

            //                                       CRDUSR = g.Select(gg => gg.CRDUSR).FirstOrDefault(),//  tbl_kacontractsdetailpayment.CRDUSR,
            //                                       DoneOn = g.Select(gg => gg.DoneOn).FirstOrDefault(),//  tbl_kacontractsdetailpayment.CRDUSR,tbl_kacontractsdetailpayment.DoneOn,





            //                                   };

            //    dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

            //    dataGridView6.DataSource = dataGridProgramdetailrs7;

            //    this.dataGridView6.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView6.Columns["PaidRequestAmt"].DefaultCellStyle.Format = "N0";




            //    this.dataGridView6.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    this.dataGridView6.Columns["PaidRequestAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    #endregion







            //}

            //#endregion




            //#region (tabControl1.SelectedIndex == 5)  // nuew la volume
            //if (tabControl1.SelectedIndex == 5)  // nuew la volume
            //{


            //    #region loaddatagridview
            //    if (Utils.IsValidnumber(cb_batchno.Text) == true)
            //    {
            //        //  MessageBox.Show("Please check Batchno doc. " + this.txt_batchno.Text, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        int BatchNo = int.Parse(cb_batchno.Text);
            //        // return;
            //    }




            //    var dataGridProgramdetailrs7 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
            //                                   where tbl_kacontractsdetailpayment.ContractNo == contractno // && tbl_kacontractsdetailpayment.BatchNo == BatchNo

            //                                   select new
            //                                   {

            //                                       Programe = tbl_kacontractsdetailpayment.PayType.Trim(),
            //                                       PayControlID = tbl_kacontractsdetailpayment.PayControl.Trim(),
            //                                       Description = tbl_kacontractsdetailpayment.Remark.Trim(),

            //                                       Paid_Amount = tbl_kacontractsdetailpayment.PaidAmt,
            //                                       tbl_kacontractsdetailpayment.PaidRequestAmt,
            //                                       //          PaidNote = tbl_kacontractsdetailpayment.PaidNote,
            //                                       PaymentDoc = tbl_kacontractsdetailpayment.PaymentDoc,
            //                                       tbl_kacontractsdetailpayment.DoneOn,

            //                                       tbl_kacontractsdetailpayment.PrintChk,
            //                                       tbl_kacontractsdetailpayment.Reprint,
            //                                       tbl_kacontractsdetailpayment.PrintDate,

            //                                       //        Remarks = tbl_kacontractsdetailpayment.Remark.Trim(),
            //                                       tbl_kacontractsdetailpayment.BatchNo,
            //                                       tbl_kacontractsdetailpayment.CRDDAT,
            //                                       tbl_kacontractsdetailpayment.CRDUSR,

            //                                       Paid_Note = tbl_kacontractsdetailpayment.PaidNote,

            //                                       tbl_kacontractsdetailpayment.UPDDAT,
            //                                       tbl_kacontractsdetailpayment.UPDUSR,
            //                                       PayID = tbl_kacontractsdetailpayment.PayID,
            //                                       SubID = tbl_kacontractsdetailpayment.SubID,



            //                                   };

            //    //    dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //    dataGridView7.DataSource = dataGridProgramdetailrs7;

            //    this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
            //    this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Format = "N0";
            //    // this.dtg_volumeachived.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";

            //    this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //    this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            //    #endregion


            //    #region   loadcomoub
            //    cb_batchno.Items.Clear();

            //    var rsbactchno = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
            //                     where tbl_kacontractsdetailpayment.ContractNo == contractno //&& tbl_kacontractsdetailpayment.BatchNo == BatchNo
            //                     group tbl_kacontractsdetailpayment by tbl_kacontractsdetailpayment.BatchNo into g
            //                     select g.Key;
            //    if (rsbactchno != null)
            //    {
            //        foreach (var item in rsbactchno)
            //        {
            //            cb_batchno.Items.Add(item.ToString());
            //        }
            //    }






            //    #endregion






            //}

            //#endregion



            //#endregion


        }
        private void cb_priod_SelectedValueChanged(object sender, EventArgs e)
        {


            //#region

            
            //string contractno = tb_contractno.Text.Trim();
            //string priod = cb_priod.Text;

            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //var rs1 = from tbl_kacontractsvolume in dc.tbl_kacontractsvolumes
            //          where tbl_kacontractsvolume.ContractNo.Equals(contractno) && priod == tbl_kacontractsvolume.Priod
            //          select new
            //          {

            //              tbl_kacontractsvolume.Priod,
            //              tbl_kacontractsvolume.EC,
            //              tbl_kacontractsvolume.PC,
            //              tbl_kacontractsvolume.UC,
            //              tbl_kacontractsvolume.Litter,
            //              //   tbl_kacontractsvolume.Net_value,
            //              NSR = tbl_kacontractsvolume.NSR,




            //          };


            //dtg_volumeachived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //dtg_volumeachived.DataSource = rs1;
            //this.dtg_volumeachived.Columns["EC"].DefaultCellStyle.Format = "N0";
            //this.dtg_volumeachived.Columns["PC"].DefaultCellStyle.Format = "N0";
            //this.dtg_volumeachived.Columns["UC"].DefaultCellStyle.Format = "N0";
            //this.dtg_volumeachived.Columns["Litter"].DefaultCellStyle.Format = "N0";
            ////    this.dtg_volumeachived.Columns["Net_value"].DefaultCellStyle.Format = "N0";
            //this.dtg_volumeachived.Columns["NSR"].DefaultCellStyle.Format = "N0";


            //this.dtg_volumeachived.Columns["EC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //this.dtg_volumeachived.Columns["PC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //this.dtg_volumeachived.Columns["UC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //this.dtg_volumeachived.Columns["NSR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";






            //#endregion

        }

        private void cb_priod2_SelectedValueChanged(object sender, EventArgs e)
        {

            //#region

            
            //string contractno = tb_contractno.Text;
            //string priod = cb_priod2.Text;

            //string connection_string = Utils.getConnectionstr();

            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            //var rs1 = from tbl_kacontractsvolumePrductGRP in dc.tbl_kacontractsvolumePrductGRPs
            //          where tbl_kacontractsvolumePrductGRP.ContractNo.Equals(contractno) && tbl_kacontractsvolumePrductGRP.Priod == priod
            //          orderby tbl_kacontractsvolumePrductGRP.Priod, tbl_kacontractsvolumePrductGRP.ProductGRP
            //          select new
            //          {
            //              tbl_kacontractsvolumePrductGRP.Priod,
            //              tbl_kacontractsvolumePrductGRP.ProductGRP,
            //              tbl_kacontractsvolumePrductGRP.EC,
            //              tbl_kacontractsvolumePrductGRP.PC,
            //              tbl_kacontractsvolumePrductGRP.UC,
            //              tbl_kacontractsvolumePrductGRP.Litter,
            //              //    tbl_kacontractsvolumePrductGRP.Net_value,
            //              NSR = tbl_kacontractsvolumePrductGRP.NSR,



            //          }; // tbl_kacontractsvolumePrductGRP;



            //dtagrviewvolumebyGRP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //dtagrviewvolumebyGRP.DataSource = rs1;

            //this.dtagrviewvolumebyGRP.Columns["EC"].DefaultCellStyle.Format = "N0";
            //this.dtagrviewvolumebyGRP.Columns["PC"].DefaultCellStyle.Format = "N0";
            //this.dtagrviewvolumebyGRP.Columns["UC"].DefaultCellStyle.Format = "N0";
            //this.dtagrviewvolumebyGRP.Columns["Litter"].DefaultCellStyle.Format = "N0";
            ////     this.dtagrviewvolumebyGRP.Columns["Net_value"].DefaultCellStyle.Format = "N0";
            //this.dtagrviewvolumebyGRP.Columns["NSR"].DefaultCellStyle.Format = "N0";

            //this.dtagrviewvolumebyGRP.Columns["EC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            //this.dtagrviewvolumebyGRP.Columns["PC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //this.dtagrviewvolumebyGRP.Columns["UC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //this.dtagrviewvolumebyGRP.Columns["NSR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";


            //#endregion

        }

        private void CreatenewContract_Activated(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {




        }

        private void cb_batchno_TextChanged(object sender, EventArgs e)
        {

            //#region


            

            //string contractno = tb_contractno.Text;
            //string connection_string = Utils.getConnectionstr();

            //if (Utils.IsValidnumber(cb_batchno.Text) == false)
            //{
            //    //  MessageBox.Show("Please check Batchno doc. " + cb_batchno.Text, "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return;
            //}

            //int BatchNo = int.Parse(cb_batchno.Text);
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            ////       cb_batchno.DroppedDown = true;

            //#region dataGridView7  detail pay ment

            //var dataGridProgramdetailrs7 = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
            //                               where tbl_kacontractsdetailpayment.ContractNo.Equals(contractno) && tbl_kacontractsdetailpayment.BatchNo == BatchNo

            //                               select new
            //                               {

            //                                   Programe = tbl_kacontractsdetailpayment.PayType.Trim(),
            //                                   PayControlID = tbl_kacontractsdetailpayment.PayControl.Trim(),
            //                                   Description = tbl_kacontractsdetailpayment.Remark.Trim(),

            //                                   Paid_Amount = tbl_kacontractsdetailpayment.PaidAmt,
            //                                   tbl_kacontractsdetailpayment.PaidRequestAmt,
            //                                   tbl_kacontractsdetailpayment.PrintChk,
            //                                   //    PaidNote = tbl_kacontractsdetailpayment.PaidNote,
            //                                   PaymentDoc = tbl_kacontractsdetailpayment.PaymentDoc,
            //                                   tbl_kacontractsdetailpayment.DoneOn,

            //                                   tbl_kacontractsdetailpayment.Reprint,
            //                                   tbl_kacontractsdetailpayment.PrintDate,
            //                                   //  Remarks = tbl_kacontractsdetailpayment.Remark.Trim(),
            //                                   tbl_kacontractsdetailpayment.BatchNo,
            //                                   tbl_kacontractsdetailpayment.CRDDAT,
            //                                   tbl_kacontractsdetailpayment.CRDUSR,
            //                                   // tbl_kacontractsdetailpayment.DoneOn,
            //                                   Paid_Note = tbl_kacontractsdetailpayment.PaidNote,

            //                                   tbl_kacontractsdetailpayment.UPDDAT,
            //                                   tbl_kacontractsdetailpayment.UPDUSR,
            //                                   PayID = tbl_kacontractsdetailpayment.PayID,
            //                                   SubID = tbl_kacontractsdetailpayment.SubID,



            //                               };

            ////   dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //dataGridView7.DataSource = dataGridProgramdetailrs7;
            //this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Format = "N0";
            //this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Format = "N0";


            //this.dataGridView7.Columns["Paid_Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //this.dataGridView7.Columns["PaidRequestAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //#endregion


            //#endregion


        }

        private void cb_batchno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void but_contractcaculatin_Click(object sender, EventArgs e)
        {



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            //#region

            
            ////this.txt_term.Text = (this.dateTimePicker2.Value.Year - this.dateTimePicker1.Value.Year + 1).ToString();
            //string txtvalueNSRcommit = (NSRcommit.Text.Replace(",", "")).Replace(".", "").Trim();
            //if (Utils.IsValidnumber(txtvalueNSRcommit) && txtvalueNSRcommit != "")
            //{

            //    #region load term and yeayr


            //    this.Nsaperyear.Text = Math.Ceiling((double.Parse(txtvalueNSRcommit) / double.Parse(txt_term.Text))).ToString();



            //    #endregion

            //}
            //#endregion


        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void cb_contractstatus_SelectedValueChanged(object sender, EventArgs e)
        {

            //#region


            





            //string contractstatus = this.cb_contractstatus.SelectedItem.ToString();
            //string contractno = tb_contractno.Text;
            //string connection_string = Utils.getConnectionstr();
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //var contractstatusrs = from tbl_kacontractdata in dc.tbl_kacontractdatas
            //                       where tbl_kacontractdata.ContractNo == contractno
            //                       select tbl_kacontractdata;

            //if (contractstatusrs.Count() > 0)
            //{
            //    foreach (var item in contractstatusrs)
            //    {
            //        item.Consts = contractstatus;
            //    }

            //    dc.SubmitChanges();
            //}

            //#endregion


        }

        private void CreatenewContract_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void txt_district_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void bt_etcontract_Click(object sender, EventArgs e)
        {

            //    dateTimePicker3.Enabled = true;

            //#region


            //View.Datepick exdate = new Datepick("Choose Ext Date");
            //exdate.ShowDialog();


            //DateTime olđate = dateTimePicker3.Value;
            //DateTime extdate = exdate.accrualdate;
            //bool chon1 = exdate.chon;


            //if (extdate > olđate && chon1 == true)
            //{
            //    //}
            //    //  el        MessageBox.Show("Ext date must be greater!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //se
            //    //  {
            //    dateTimePicker3.Value = extdate;



            //    // update extdate tble master

            //    //   string contractno = tb_contractno.Text;
            //    string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //    var contractstatusrs = from tbl_kacontractdata in dc.tbl_kacontractdatas
            //                           where tbl_kacontractdata.ContractNo.Equals(tb_contractno.Text.Trim())
            //                           select tbl_kacontractdata;

            //    if (contractstatusrs.Count() > 0)
            //    {
            //        foreach (var item in contractstatusrs)
            //        {
            //            item.ExtDate = extdate;
            //        }

            //        dc.SubmitChanges();
            //    }



            //    // update extdate tbl detail ??


            //}




            //#endregion


        }

        private void btfindcust_Click(object sender, EventArgs e)
        {

            //#region


            
            //View.valueinput inputval = new valueinput("Input some text in Name to seach code");

            //inputval.ShowDialog();

            //bool chon = inputval.kq;
            //string valueinput = inputval.valuetext;
            //if (valueinput == null)
            //{
            //    valueinput = "";
            //}
            //if (chon)
            //{



            //    string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //    string username = Utils.getusername();

            //    var regioncode = (from tbl_Temp in dc.tbl_Temps
            //                      where tbl_Temp.username == username
            //                      select tbl_Temp.RegionCode).FirstOrDefault();





            //    //var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
            //    //             where ((int)tbl_KaCustomer.Customer).ToString().Contains(valueinput) && (tbl_KaCustomer.SFAcode == true)



            //    var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
            //                 where tbl_KaCustomer.FullNameN.Contains(valueinput) && tbl_KaCustomer.indirectCode == true // || tbl_KaCustomer.SapCode ==true)
            //                     && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
            //                      ).Contains(tbl_KaCustomer.SALORG_CTR)
            //                 select new
            //                 {
            //                     tbl_KaCustomer.Region,
            //                     tbl_KaCustomer.Customer,
            //                     tbl_KaCustomer.FullNameN,
            //                     tbl_KaCustomer.SapCode,

            //                 };




            //    Utils ut = new Utils();
            //    var tblcustomer = ut.ToDataTable(dc, rscode);

            //    Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please,cChoose one code !");
            //    viewtb.ShowDialog();
            //    string codetemp = viewtb.valuecode;
            //    if (codetemp != "0" && chon == true && codetemp != null)
            //    {
            //        cb_customerka.Text = codetemp;
            //        cb_customerka.Enabled = false;
            //        cbcust.Checked = true;
            //    }
            //    else
            //    {
            //        cb_customerka.Text = "";
            //        cb_customerka.Enabled = true;
            //        cbcust.Checked = false;

            //    }
            //}
            //#endregion


        }

        private void btfindsfa_Click(object sender, EventArgs e)
        {


            //#region


            

            //View.valueinput inputval = new valueinput("Input some text in Name to seach SFA code");

            //inputval.ShowDialog();

            //bool chon = inputval.kq;
            //string valueinput = inputval.valuetext;

            ////  string valueinput = txtcustgroup.Text;

            //string connection_string = Utils.getConnectionstr();
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //string username = Utils.getusername();

            //var regioncode = (from tbl_Temp in dc.tbl_Temps
            //                  where tbl_Temp.username == username
            //                  select tbl_Temp.RegionCode).FirstOrDefault();


            ////&& (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
            ////               ).Contains(tbl_KaCustomer.SALORG_CTR)



            //var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
            //             where tbl_KaCustomer.FullNameN.ToString().Contains(valueinput) && (tbl_KaCustomer.SFAcode == true)
            //                         && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
            //               ).Contains(tbl_KaCustomer.SALORG_CTR)
            //             select new
            //             {
            //                 tbl_KaCustomer.Region,
            //                 tbl_KaCustomer.Customer,
            //                 tbl_KaCustomer.FullNameN,
            //                 tbl_KaCustomer.SFAcode,

            //             };




            //Utils ut = new Utils();
            //var tblcustomer = ut.ToDataTable(dc, rscode);

            //Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one  sfa code !");
            //viewtb.ShowDialog();
            //string codetemp = viewtb.valuecode;

            //if (codetemp != "0" && codetemp != null)
            //{
            //    txtfindsacode.Text = codetemp;
            //    txtfindsacode.Enabled = false;
            //    cb_customerka.Text = "";
            //    txtcustgroup.Text = "";

            //    cbcust.Checked = false;
            //    cbgroup.Checked = false;
            //    cbsfa.Checked = true;
            //    //



            //}
            //else
            //{
            //    txtfindsacode.Text = "";
            //    txtfindsacode.Enabled = true;
            //    cbsfa.Checked = false;

            //}



            //#endregion

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //#region

            

            //View.valueinput inputval = new valueinput("Input some text in Name to seach Group code");

            //inputval.ShowDialog();

            //bool chon = inputval.kq;
            //string valueinput = inputval.valuetext;
            //if (valueinput == null)
            //{
            //    valueinput = "";
            //}
            ////  string valueinput = txtcustgroup.Text;
            //if (chon)
            //{


            //    string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            //    string username = Utils.getusername();

            //    var regioncode = (from tbl_Temp in dc.tbl_Temps
            //                      where tbl_Temp.username == username
            //                      select tbl_Temp.RegionCode).FirstOrDefault();


            //    //&& (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
            //    //               ).Contains(tbl_KaCustomer.SALORG_CTR)





            //    var rscode = from tbl_KaCustomer in dc.tbl_KaCustomers
            //                 where tbl_KaCustomer.FullNameN.ToString().Contains(valueinput) && (tbl_KaCustomer.Grpcode == true)
            //                    && (from Tka_RegionRight in dc.Tka_RegionRights where Tka_RegionRight.RegionCode == regioncode select Tka_RegionRight.Region
            //                      ).Contains(tbl_KaCustomer.SALORG_CTR)
            //                 select new
            //                 {
            //                     tbl_KaCustomer.Region,
            //                     tbl_KaCustomer.Customer,
            //                     tbl_KaCustomer.FullNameN,
            //                     tbl_KaCustomer.Grpcode,

            //                 };




            //    Utils ut = new Utils();
            //    var tblcustomer = ut.ToDataTable(dc, rscode);

            //    Viewdatatable viewtb = new Viewdatatable(tblcustomer, "Please, choose one  Group code !");
            //    viewtb.ShowDialog();
            //    string codetemp = viewtb.valuecode;

            //    if (codetemp != "0" && codetemp != null)
            //    {
            //        txtcustgroup.Text = codetemp;
            //        txtcustgroup.Enabled = false;
            //        cb_customerka.Text = "";
            //        txtfindsacode.Text = "";

            //        cbcust.Checked = false;
            //        cbgroup.Checked = false;
            //        cbsfa.Checked = true;
            //        //



            //    }
            //    else
            //    {
            //        txtcustgroup.Text = "";
            //        txtcustgroup.Enabled = true;
            //        cbgroup.Checked = false;

            //    }


            //}
            //#endregion


        }

   
   



    }


}

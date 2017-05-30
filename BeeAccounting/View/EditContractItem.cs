using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEEACCOUNT.Control;

namespace BEEACCOUNT.View
{


    public partial class EditContractItem : Form
    {
        public string contractno { get; set; }
        public string programe { get; set; }
        public int payiD { get; set; }

        public View.CreatenewContract formcreatCtract { get; set; }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public string unitvalue { get; set; }

        public EditContractItem(View.CreatenewContract formcreatCtract, string contractno, string formtype, string programe, int payid)
        {

            //// contractno = contractno;
            //this.programe = programe;
            //this.payiD = payid;
            //this.formcreatCtract = formcreatCtract;
            //InitializeComponent();

            //lbcontractno.Text = contractno;
            //this.contractno = contractno;
            //formlabelED.Text = formtype;

            //if (formtype == "EDIT ITEM TERM OF CONTRACT")  // edit loadcontract to edit
            //{

            //    cb_program.Enabled = true;


            //    #region  //LOAD  and edit



            //    string connection_string = Utils.getConnectionstr();

            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //    addnewitem.Visible = false;
            //    //      #region load combound program

            //    //       cb_program

            //    var contractitem = from tbl_kacontractsdatadetail in dc.tbl_kacontractsdatadetails
            //                       where tbl_kacontractsdatadetail.ContractNo == contractno && tbl_kacontractsdatadetail.PayID == payid
            //                       && tbl_kacontractsdatadetail.PayType == programe
            //                       select tbl_kacontractsdatadetail;
            //    if (contractitem.Count() == 1)
            //    {
            //        foreach (var item in contractitem)
            //        {

            //            cb_program.Text = item.PayType;
            //            //            cb_program.Enabled = false;

            //            #region programe
            //            //  cb_paycontrol.Enabled = false;  load paycontrol to change
            //            //    string connection_string = Utils.getConnectionstr();

            //            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //            //  CombomCollection = null;
            //            List<ComboboxItem> CombomCollection1 = new List<ComboboxItem>();
            //            var rs22 = from tbl_kaprogramlist in db.tbl_kaprogramlists
            //                           //  where tbl_Kafuctionlist.Code != "DIS"
            //                       orderby tbl_kaprogramlist.Code
            //                     select tbl_kaprogramlist;
            //            foreach (var item2 in rs22)
            //            {
            //                ComboboxItem cb2 = new ComboboxItem();
            //                cb2.Value = item2.Code.Trim();
            //                cb2.Text = item2.Code.Trim() + ": " + item2.Name;
            //                CombomCollection1.Add(cb2);
            //            }


            //            cb_program.DataSource = CombomCollection1;
            //            cb_program.ValueMember = "Value";
            //            cb_program.DisplayMember = "Text";
            //            cb_program.DropDownWidth = 300;


            //            int j = 0;
            //            foreach (var i in CombomCollection1)
            //            {


            //                if ((string)i.Value == item.PayType.Trim())
            //                {

            //                    cb_program.SelectedIndex = j;
            //                    //  MessageBox.Show(j.ToString());
            //                }

            //                j++;
            //            }
            //            #endregion




            //            #region paycontrong
            //            //  cb_paycontrol.Enabled = false;  load paycontrol to change
            //            //    string connection_string = Utils.getConnectionstr();

            //         //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //            //  CombomCollection = null;
            //            List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            //            var rs = from tbl_Kafuctionlist in db.tbl_Kafuctionlists
            //                     where tbl_Kafuctionlist.Code != "DIS"
            //                     orderby tbl_Kafuctionlist.Code
            //                     select tbl_Kafuctionlist;
            //            foreach (var item2 in rs)
            //            {
            //                ComboboxItem cb = new ComboboxItem();
            //                cb.Value = item2.Code.Trim();
            //                cb.Text = item2.Code.Trim() + ": " + item2.Description.Trim() + "    || Example: " + item2.Example;
            //                CombomCollection.Add(cb);
            //            }


            //            cb_paycontrol.DataSource = CombomCollection;
            //            cb_paycontrol.ValueMember = "Value";
            //            cb_paycontrol.DisplayMember = "Text";
            //            cb_paycontrol.DropDownWidth = 600;


            //            int j1 = 0;
            //            foreach (var i in CombomCollection)
            //            {


            //                if ((string)i.Value == item.PayControl.Trim())
            //                {

            //                    cb_paycontrol.SelectedIndex = j1;
            //                    //  MessageBox.Show(j.ToString());
            //                }

            //                j1++;
            //            }
            //            #endregion


            //            //  cbProductGR


            //            #region PRODUCT GROUP

            //            List<ComboboxItem> CombomCollection2 = new List<ComboboxItem>();
            //            var rs2 = from tbl_kaPrdgrp in db.tbl_kaPrdgrps
            //                      orderby tbl_kaPrdgrp.PrdGrp
            //                      select tbl_kaPrdgrp;
            //            foreach (var item2 in rs2)
            //            {
            //                ComboboxItem cb = new ComboboxItem();
            //                cb.Value = item2.PrdGrp;
            //                cb.Text = item2.PrdGrp.Trim() + ": " + item2.ProductGroup;// + "- Exp : " + item.Example;
            //                CombomCollection2.Add(cb);
            //            }


            //            cbProductGR.DataSource = CombomCollection2;
            //            cbProductGR.ValueMember = "Value";
            //            cbProductGR.DisplayMember = "Text";
            //            cbProductGR.DropDownWidth = 350;


            //            int k = 0;
            //            foreach (var i in CombomCollection)
            //            {


            //                if ((string)i.Value == item.PayControl)
            //                {

            //                    cbProductGR.SelectedIndex = k;
            //                    //  MessageBox.Show(j.ToString());
            //                }

            //                k++;
            //            }
            //            #endregion



            //            status.Text = item.Constatus;
            //            unitvalue = (from tbl_kacontractdata in db.tbl_kacontractdatas where tbl_kacontractdata.ContractNo == contractno select tbl_kacontractdata.Currency).FirstOrDefault();

            //            cbIDprg.Text = item.PayID.ToString();
            //            cbIDprg.Enabled = false;


            //            //       cbProductGR.Text = item.PrdGrp;

            //            fromdatep.Value = item.EffFrm.Value;
            //            todatep.Value = item.EffTo.Value;


            //            cbDescristion.Text = item.Remark;
            //            if (item.CommittedDate != null)
            //            {
            //                paymentdatep.Value = item.CommittedDate.Value;

            //            }
            //            else
            //            {

            //                paymentdatep.Visible = false;
            //                lbdatepaid.Visible = false;


            //            }
            //            if (item.FundPercentage != null)
            //            {
            //                spercent.Text = item.FundPercentage.ToString();
            //            }
            //            else
            //            {
            //                spercent.Enabled = false;
            //            }

            //            if (item.SponsoredAmtperPC != null)
            //            {
            //                ucpcsponsor.Text = item.SponsoredAmtperPC.ToString();
            //            }
            //            else
            //            {
            //                ucpcsponsor.Enabled = false;
            //            }

            //            if (item.SponsoredAmt != null)
            //            {
            //                amountsponsor.Text = item.SponsoredAmt.ToString();
            //            }
            //            else
            //            {
            //                amountsponsor.Enabled = false;
            //            }

            //            if (item.SponsorUnit != null)
            //            {
            //                sunit.Text = item.SponsorUnit.ToString();
            //            }
            //            else
            //            {
            //                sunit.Enabled = false;
            //            }

            //            if (item.TagetPercentage != null)
            //            {
            //                tprcent.Text = item.TagetPercentage.ToString();
            //            }
            //            else
            //            {
            //                tprcent.Enabled = false;
            //            }

            //            if (item.TagetAchivement != null)
            //            {
            //                tachive.Text = item.TagetAchivement.ToString();
            //            }
            //            else
            //            {
            //                tachive.Enabled = false;
            //            }


            //            if (item.TargetUnit != null)
            //            {
            //                tunit.Text = item.TargetUnit.ToString();
            //            }
            //            else
            //            {
            //                tunit.Enabled = false;
            //            }

            //            //  cb_paycontrol.Focus();
            //            ///   status.Focus();






            //        }


            //    }









            //    #endregion

            //}



            //if (formtype == "CREATE NEW ITEM TERM")  // create newcontract iteam
            //{
            //    #region  load new to create
            //    lbprogramid.Visible = false;

            //    cbIDprg.Visible = false;


            //    btchangecontractitem.Visible = false;
            //    btactive.Visible = false;
            //    btchange.Visible = false;
            //    status.Text = "CRT";

            //    //unitvalue = (from tbl_kacontractdata in db.tbl_kacontractdatas where tbl_kacontractdata.ContractNo == contractno select tbl_kacontractdata.Currency).FirstOrDefault();
            //    #region paycontrong
            //    //  cb_paycontrol.Enabled = false;  load paycontrol to change
            //    //    string connection_string = Utils.getConnectionstr();


            //    string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            //    unitvalue = (from tbl_kacontractdata in db.tbl_kacontractdatas where tbl_kacontractdata.ContractNo == contractno select tbl_kacontractdata.Currency).FirstOrDefault();
            //    //  CombomCollection = null;
            //    List<ComboboxItem> CombomCollection = new List<ComboboxItem>();
            //    var rs = from tbl_Kafuctionlist in db.tbl_Kafuctionlists
            //         //    where tbl_Kafuctionlist.Code != "DIS"
            //             orderby tbl_Kafuctionlist.Code
            //             select tbl_Kafuctionlist;
            //    foreach (var item2 in rs)
            //    {
            //        ComboboxItem cb = new ComboboxItem();
            //        cb.Value = item2.Code;
            //        cb.Text = item2.Code + ": " + item2.Description + "    || Example: " + item2.Example;
            //        CombomCollection.Add(cb);
            //    }


            //    cb_paycontrol.DataSource = CombomCollection;
            //    cb_paycontrol.ValueMember = "Value";
            //    cb_paycontrol.DisplayMember = "Text";
            //    cb_paycontrol.DropDownWidth = 600;
            //    cb_paycontrol.DropDownStyle = ComboBoxStyle.DropDownList;

            //    #endregion


            //    //  cbProductGR


            //    #region PRODUCT GROUP

            //    List<ComboboxItem> CombomCollection2 = new List<ComboboxItem>();
            //    var rs2 = from tbl_kaPrdgrp in db.tbl_kaPrdgrps
            //              orderby tbl_kaPrdgrp.PrdGrp
            //              select tbl_kaPrdgrp;
            //    foreach (var item2 in rs2)
            //    {
            //        ComboboxItem cb = new ComboboxItem();
            //        cb.Value = item2.PrdGrp;
            //        cb.Text = item2.PrdGrp.Trim() + ": " + item2.ProductGroup;// + "- Exp : " + item.Example;
            //        CombomCollection2.Add(cb);
            //    }


            //    cbProductGR.DataSource = CombomCollection2;
            //    cbProductGR.ValueMember = "Value";
            //    cbProductGR.DisplayMember = "Text";
            //    cbProductGR.DropDownWidth = 350;
            //    cbProductGR.DropDownStyle = ComboBoxStyle.DropDownList;

            //    //
            //    #endregion




            //    #region PROGRAME

            //    List<ComboboxItem> CombomCollection3 = new List<ComboboxItem>();
            //    var rs3 = from tbl_kaprogramlist in db.tbl_kaprogramlists
            //              orderby tbl_kaprogramlist.Code
            //              select tbl_kaprogramlist;
            //    foreach (var item3 in rs3)
            //    {
            //        ComboboxItem cb = new ComboboxItem();
            //        cb.Value = item3.Code;
            //        cb.Text = item3.Code.Trim() + ": " + item3.Name;// + "- Exp : " + item.Example;
            //        CombomCollection3.Add(cb);
            //    }


            //    cb_program.DataSource = CombomCollection3;

            //    cb_program.ValueMember = "Value";
            //    cb_program.DisplayMember = "Text";
            //    cb_program.DropDownWidth = 350;
            //    cb_program.DropDownStyle = ComboBoxStyle.DropDownList;

            //    //
            //    #endregion






            //    #endregion


            //}

        }

        private void txtCustcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                cb_paycontrol.Focus();


            }




        }

        private void txt_vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //      cb_subid.Focus();


            }

        }

        private void txt_represennt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_sponsoramt.Focus();


            }
        }

        private void txt_chananame_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                // txt_paidamt.Focus();


            }
        }

        private void txt_houseno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_balance.Focus();


            }
        }

        private void txt_district_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_paymentamount.Focus();


            }
        }

        private void txt_provicen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_balancenew.Focus();


            }
        }

        private void txt_description_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //txt_contractno.Focus();


            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();


            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext da = new LinqtoSQLDataContext(connection_string);

            //if (this.txt_batchno.Text == "" )
            //{
            //    this.txt_batchno.Text = "0";
            //}

            //if ( Utils.IsValidnumber(this.txt_batchno.Text) == false)
            //{
            //    MessageBox.Show("Please check Batch No !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            //int Batchno = int.Parse(this.txt_batchno.Text);


            #region delete  DETAIL AND GRUOP RPT BY USER


            string username = Utils.getusername();
            //  string connection_string = Utils.getConnectionstr();
            //   LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            string sqltext = "DELETE FROM tbl_KAdetailprogrRpt WHERE tbl_KAdetailprogrRpt.Username = '" + username + "'";
            dc.ExecuteCommand(sqltext);
            dc.SubmitChanges();

            sqltext = "DELETE FROM tbl_KapaymentrequestRpt WHERE tbl_KapaymentrequestRpt.Username = '" + username + "'";
            dc.ExecuteCommand(sqltext);
            dc.SubmitChanges();


            sqltext = "DELETE FROM tbl_KapaymentrequestRpt WHERE tbl_KapaymentrequestRpt.Username = '" + username + "'";
            dc.ExecuteCommand(sqltext);
            dc.SubmitChanges();

            #endregion

            

        }


        private void txt_paymentamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_paymentamount_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                //txt_note.Focus();
            }








        }


        private void cb_payid_SelectedValueChanged(object sender, EventArgs e)
        {

            String paycontrol = (cb_paycontrol.SelectedItem as ComboboxItem).Value.ToString();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            if (paycontrol == "DIS")
            {
                #region


              //  cb_program.SelectedItem = "DIS";
                foreach (var item in cb_program.Items)
                {
                   
                    if ((item as ComboboxItem).Value.ToString().Trim().Equals("DIS"))
                    {
                    //    MessageBox.Show((item as ComboboxItem).Value.ToString());
                        cb_program.SelectedItem = item;
                        cb_program.Text = (item as ComboboxItem).Text.ToString();
                                                                                // cb_program.DisplayMember = item;
                    }

                }

                //cb_program.Text = "DIS";

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = true;
                   spercent.Text = "0";


                ucpcsponsor.Enabled = true;
                 ucpcsponsor.Text = "0";

                amountsponsor.Enabled = false;
              //    amountsponsor.Text = "0";

                sunit.Text = "%";

                sunit.Enabled = true;

                tprcent.Enabled = false;
                //   tprcent.Text = "";

                tachive.Enabled = false;
                // tachive.Text = "";

                tunit.Enabled = false;
             //   sunit.Enabled = false;

                tunit.Text = "";

                #endregion



            }




            if (paycontrol == "C00")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //    spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //  ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //   amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                //   tprcent.Text = "";

                tachive.Enabled = false;
                // tachive.Text = "";

                tunit.Enabled = false;
                sunit.Enabled = false;
                tunit.Text = "";

                #endregion



            }

            if (paycontrol == "C01")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = true;
                lbdatepaid.Visible = true;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //  spercent.Text = "";


                ucpcsponsor.Enabled = false;
                // ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //  amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                //  tprcent.Text = "";

                tachive.Enabled = false;
                //  tachive.Text = "";

                //   tunit.Enabled = false;
                tunit.Enabled = false;
                sunit.Enabled = false;
                tunit.Text = "";
                #endregion

            }

            if (paycontrol == "C02")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //  spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //    ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //      amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = true;
                //     tprcent.Text = "";

                tachive.Enabled = true;
                //   tachive.Text = "";

                tunit.Text = "PC";
                tunit.Enabled = false;
                sunit.Enabled = false;
                #endregion

            }

            if (paycontrol == "C03")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //      spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //  ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                // amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                //    tprcent.Text = "";

                tachive.Enabled = true;
                //    tachive.Text = "";

                //   tunit.Enabled = true;
                tunit.Text = "PC";
                tunit.Enabled = false;
                sunit.Enabled = false;
                #endregion

            }

            if (paycontrol == "C04")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //     spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //   ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //  amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                //  tprcent.Text = "";

                tachive.Enabled = true;
                // tachive.Text = "";

                //  tunit.Enabled = true;
                tunit.Text = unitvalue;
                tunit.Enabled = false;
                sunit.Enabled = false;

                #endregion

            }
            if (paycontrol == "C05")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
            //    spercent.Text = "";


                ucpcsponsor.Enabled = false;
          //      ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
           //     amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
           //     tprcent.Text = "";

                tachive.Enabled = false;
           //     tachive.Text = "";

                //   tunit.Enabled = false;
                tunit.Text = "";
                tunit.Enabled = false;
                sunit.Enabled = false;
                #endregion

            }
            if (paycontrol == "C06")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //      spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //    ucpcsponsor.Text = "";

                amountsponsor.Enabled = true;
                //       amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = true;
                //    tprcent.Text = "";

                tachive.Enabled = true;
                //        tachive.Text = "";

                //tunit.Enabled = false;
                tunit.Text = "PC";
                tunit.Enabled = false;
                sunit.Enabled = false;

                #endregion

            }

            if (paycontrol == "D01")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //  spercent.Text = "";


                ucpcsponsor.Enabled = true;
                //    ucpcsponsor.Text = "";

                amountsponsor.Enabled = false;
                //  amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                tprcent.Text = "";

                tachive.Enabled = false;
                tachive.Text = "";

                //    tunit.Enabled = false;
                tunit.Text = "PC";
                tunit.Enabled = false;
                sunit.Enabled = false;
                #endregion

            }

            if (paycontrol == "D02")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                //      spercent.Text = "";


                ucpcsponsor.Enabled = true;
                //     ucpcsponsor.Text = "";

                amountsponsor.Enabled = false;
                //      amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                ///    tprcent.Text = "";

                tachive.Enabled = false;
                //     tachive.Text = "";

                //  tunit.Enabled = false;
                tunit.Text = "Litter";
                tunit.Enabled = false;
                sunit.Enabled = false;
                #endregion

            }
            if (paycontrol == "D03")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = true;
                lbdatepaid.Visible = true;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = false;
                // spercent.Text = "";


                ucpcsponsor.Enabled = true;
                //   ucpcsponsor.Text = "";

                amountsponsor.Enabled = false;
                //amountsponsor.Text = "0";

                sunit.Text = unitvalue;

                tprcent.Enabled = false;
                //  tprcent.Text = "";

                tachive.Enabled = false;
                //   tachive.Text = "";

                //       tunit.Enabled = false;
                tunit.Text = "PC";
                tunit.Enabled = false;
                sunit.Enabled = false;


                #endregion

            }
            if (paycontrol == "P00")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = false;
                lbdatepaid.Visible = false;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = true;
                //   spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //  ucpcsponsor.Text = "%";

                amountsponsor.Enabled = false;
                //   amountsponsor.Text = "0";

                sunit.Text = "%";

                tprcent.Enabled = false;
                //tprcent.Text = "";

                tachive.Enabled = false;
                //     tachive.Text = "";

                //     tunit.Enabled = false;
                tunit.Text = unitvalue;
                tunit.Enabled = false;
                sunit.Enabled = false;


                #endregion

            }
            if (paycontrol == "P01")
            {
                #region

                //paymentdatep.Value = DBNull.Value; //DBNull.Value;
                paymentdatep.Visible = true;
                lbdatepaid.Visible = true;
                //DateTime t = d;
                //paymentdatep.Value = null;

                spercent.Enabled = true;
                //   spercent.Text = "";


                ucpcsponsor.Enabled = false;
                //   ucpcsponsor.Text = "";

                amountsponsor.Enabled = false;
                //   amountsponsor.Text = "0";

                sunit.Text = "%";

                tprcent.Enabled = false;
                //    tprcent.Text = "";

                tachive.Enabled = false;
                //    tachive.Text = "";

                //      tunit.Enabled = false;
                //tunit.Text = "";
                tunit.Enabled = false;
                sunit.Enabled = false;


                #endregion

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void button3_Click(object sender, EventArgs e)
        //{

        //    string connection_string = Utils.getConnectionstr();

        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    tbl_kacontractsdatadetail newrequestpayment = new tbl_kacontractsdatadetail();



        //    var maxbatcno = (from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments

        //                     select tbl_kacontractsdetailpayment.BatchNo).Max();



        //    var newrequestpaymentRS = from tbl_kacontractsdetailpayment in dc.tbl_kacontractsdetailpayments
        //                              where tbl_kacontractsdetailpayment.ContractNo == contractno && tbl_kacontractsdetailpayment.PayControl == "REQ" && tbl_kacontractsdetailpayment.BatchNo == 0 && tbl_kacontractsdetailpayment.CRDUSR == Utils.getusername()
        //                              select tbl_kacontractsdetailpayment;

        //    if (newrequestpaymentRS != null && newrequestpaymentRS.Count() > 0)
        //    {
        //        foreach (var item in newrequestpaymentRS)
        //        {

        //            item.BatchNo = maxbatcno + 1;
        //            item.CRDDAT = DateTime.Today;
        //            dc.SubmitChanges();
        //        }




        //    }

          





        //}

        private void Createpayment_Load(object sender, EventArgs e)
        {

        }

        
    }


}

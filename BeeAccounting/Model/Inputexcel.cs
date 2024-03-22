using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEEACCOUNT.shared;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Data.OleDb;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace BEEACCOUNT.Model
{
    class Inputexcel
    {

        //--------


        //public IQueryable customersetlect_all(LinqtoSQLDataContext db)
        //{

        //    //  var db = new LinqtoSQLDataContext(connection_string);
        //    var rs = from tbl_KaCustomer in db.tbl_KaCustomers
        //             orderby tbl_KaCustomer.Customer
        //             select tbl_KaCustomer;

        //    return rs;

        //}

        //public bool customerdeleted()
        //{
        //    #region // xóa data bảng tblCustomer
        //    string connection_string = Utils.getConnectionstr();
        //    var db = new LinqtoSQLDataContext(connection_string);

        //    db.ExecuteCommand("DELETE FROM tbl_KaCustomer");
        //    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    db.SubmitChanges();



        //    return true;
        //    #endregion

        //}


        class datainportF
        {

            public string filename { get; set; }

        }

        private void importsexcel2(object obj)
        {
            string connection_string = Utils.getConnectionstr();
            var db = new LinqtoSQLDataContext(connection_string);

            db.ExecuteCommand("DELETE FROM tbl_KaCustomer");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            db.SubmitChanges();


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

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Get the data from the source table as a SqlDataReader.

                //  Customer	Vendor	SalesOrg	FullName	TradingName	Street	District	City	Telephone1	Telephone2	FaxNumber	VATregistrationNo	Indirect	CustomerGroup	SALORG_CTR

                OleDbCommand command = new OleDbCommand(
                                        @"SELECT Customer, 
                                    SalesOrg, 
FullName, 
TradingName ,
  Street,
District,
City ,    Telephone1,  VATregistrationNo, Indirect, 
    SALORG_CTR  FROM [Sheet1$]

                                     WHERE  (Customer IS NOT NULL)", conn);


                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                try
                {
                    adapter.Fill(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Fill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                conn.Close();
            }

            ///     Utils util = new Utils();
            string destConnString = Utils.getConnectionstr();
            //      sourceData.Columns.Add("SapCode");
            //        sourceData.Columns["SapCode"].DefaultValue = true;
            //---------------fill data


            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {

              
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.DestinationTableName = "tbl_KaCustomer";
                // Write from the source to the destination.
                bulkCopy.ColumnMappings.Add("Customer", "Customer");
                bulkCopy.ColumnMappings.Add("SalesOrg", "Region");
                bulkCopy.ColumnMappings.Add("FullName", "FullNameN");
                bulkCopy.ColumnMappings.Add("TradingName", "KANAME");
                bulkCopy.ColumnMappings.Add("Street", "Street");
                bulkCopy.ColumnMappings.Add("District", "District");
                bulkCopy.ColumnMappings.Add("City", "City");
                bulkCopy.ColumnMappings.Add("Telephone1", "Telephone1");
                bulkCopy.ColumnMappings.Add("VATregistrationNo", "VATregistrationNo");

                //    bulkCopy.ColumnMappings.Add("CustomerGroup", "CustomerGroup");

                bulkCopy.ColumnMappings.Add("Indirect", "indirectCode");
                bulkCopy.ColumnMappings.Add("SALORG_CTR", "SALORG_CTR");



                try
                {
                    bulkCopy.WriteToServer(sourceData);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }

            }


            //   Thread.CurrentThread.Abort();

        }


        public void importbankexceldata(object obj)
        {




            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;

            //   string filename = theDialog.FileName.ToString();

            //   string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            dc.ExecuteCommand("DELETE FROM tbl_tempbankupload");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.CommandTimeout = 0;
            dc.SubmitChanges();


            ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvide.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();
            batable.Columns.Add("ngayhachtoan", typeof(string));

         //   batable.Columns.Add("ngayhachtoan", typeof(DateTime));
            batable.Columns.Add("Username", typeof(string));
            batable.Columns.Add("NHpsNo", typeof(double));
            batable.Columns.Add("NHpsCo", typeof(double));
            batable.Columns.Add("Nguoithuhuong", typeof(string));
            batable.Columns.Add("Noidung", typeof(string));
            batable.Columns.Add("mabuttoanNH", typeof(string));



            int ngayhachtoanid = 0;
            int NHpsNoid = 0;
            int NHpsCoid = 0;
            int Nguoithuhuongid = 0;
            int Noidungid = 0;
            int mabuttoanNHid = 0;

       //     View.Viewdatatable vi1 = new View.Viewdatatable(sourceData, "Test");

       //     vi1.ShowDialog();
            int headindex =-2;

            for (int rowid = 0; rowid < 3; rowid++)
            {
               // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {

                    string value = sourceData.Rows[rowid][columid].ToString();
      //            MessageBox.Show(value +":"+ rowid);

                    if (value != null )
                    {

                        #region setcolum
                        if (value.Trim().Contains("NGÀY HẠCH TOÁN"))
                        {
                            ngayhachtoanid = columid;
                            headindex = rowid;
                        }

                        if (value.Trim().Contains("PHÁT SINH NỢ") && headindex == rowid)
                        {

                            NHpsNoid = columid;
                      //    headindex = 0;

                        }


                        if (value.Trim().Contains("PHÁT SINH CÓ") && headindex == rowid)
                        {

                            NHpsCoid = columid;
                         //   headindex = 0;



                        }


                        if (value.Trim().Contains("ĐƠN VỊ THỤ HƯỞNG/ĐƠN VỊ CHUYỂN") && headindex == rowid)
                        {
                            Nguoithuhuongid = columid;
                           
                        }
                        if (value.Trim().Contains("NỘI DUNG") && headindex == rowid)
                        {
                            Noidungid = columid;
                           
                        }

                        if (value.Trim().Contains("BÚT TOÁN") && headindex == rowid)
                        {
                            mabuttoanNHid = columid;
                           
                        }

                   
                        #endregion

                    }


                }// colum
                
            }// roww off heatder


            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

              
                    #region setvalue of bankdata
                    //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string chekdata = sourceData.Rows[rowixd][ngayhachtoanid].ToString();
                if (chekdata != "") // && Utils.IsValidnumber(customer)
                {
                  
           
                    DataRow dr = batable.NewRow();

                    dr["ngayhachtoan"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][ngayhachtoanid].ToString());// Utils.GetValueOfCellInExcel(worksheet, rowid, columValid_to);
                    dr["Username"] = Utils.getusername();

                    dr["NHpsNo"] = double.Parse(sourceData.Rows[rowixd][NHpsNoid].ToString());
                    dr["NHpsCo"] = double.Parse(sourceData.Rows[rowixd][NHpsCoid].ToString());

                    dr["Nguoithuhuong"] = sourceData.Rows[rowixd][Nguoithuhuongid].ToString().Trim();



                    dr["Noidung"] = sourceData.Rows[rowixd][Noidungid].ToString().Trim();



                    dr["mabuttoanNH"] = sourceData.Rows[rowixd][mabuttoanNHid].ToString().Trim();

             
                    batable.Rows.Add(dr);


                }

                #endregion

            }// row

            //conpy to server
            string destConnString = Utils.getConnectionstr();

             using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {

                //batable.Columns.Add("", typeof(DateTime));
                //batable.Columns.Add("", typeof(string));
                //batable.Columns.Add("", typeof(double));
                //batable.Columns.Add("", typeof(double));
                //batable.Columns.Add("", typeof(string));
                //batable.Columns.Add("", typeof(string));
                //batable.Columns.Add("", typeof(string));


                bulkCopy.DestinationTableName = "tbl_tempbankupload";
                // Write from the source to the destination.
                bulkCopy.BulkCopyTimeout = 0;

                bulkCopy.ColumnMappings.Add("ngayhachtoan", "ngayhachtoan");

                bulkCopy.ColumnMappings.Add("Username", "Username");
                bulkCopy.ColumnMappings.Add("NHpsNo", "NHpsNo");
                bulkCopy.ColumnMappings.Add("NHpsCo", "NHpsCo");

                bulkCopy.ColumnMappings.Add("Nguoithuhuong", "Nguoithuhuong");
                bulkCopy.ColumnMappings.Add("Noidung", "Noidung");
                bulkCopy.ColumnMappings.Add("mabuttoanNH", "mabuttoanNH");
           
              
             


                try
                {
                    bulkCopy.WriteToServer(batable);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Thông báo lỗi Bulk Copy !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.CurrentThread.Abort();
                }


            }
            //copy to server
            //   string connection_string = Utils.getConnectionstr();

            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //    var typeffmain = typeof(tbl_KAbaseprice);
            //     var typeffsub = typeof(tbl_KAbaseprice);

            //    VInputchange inputcdata1 = new VInputchange("", "Base price list", dc, "tbl_KAbaseprice", "tbl_KAbaseprice", typeffmain, typeffsub, "id", "id", "");
            //    inputcdata1.ShowDialog();
            //  View.Viewdatatable TB = new View.Viewdatatable(batable, "lIST DATA");
            //  TB.ShowDialog();

            //  }
        }



        class datashowwait
        {

            public View.BeeCaculating wat { get; set; }


        }



        private void showwait(object obj)
        {
            // View.Caculating wat = new View.Caculating();

            //            View.Caculating wat = (View.Caculating)obj;
            datashowwait obshow = (datashowwait)obj;

            View.BeeCaculating wat = obshow.wat;

            wat.ShowDialog();


        }



        public void Bankinput()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Bank excel data !";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(importbankexceldata);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });

                View.BeeCaculating wat = new View.BeeCaculating();
                Thread t2 = new Thread(showwait);
                t2.Start(new datashowwait() { wat = wat });


                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {

                    // t2.Abort();

                    wat.Invoke(wat.myDelegate);



                }



            }





        }
        public void customerinputpriceingupdate()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File ZNKA1 Customer excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(importbankexceldata);
                t1.IsBackground = true;
                t1.Start(new datainportF() { filename = filename });


                View.BeeCaculating wat = new View.BeeCaculating();
                Thread t2 = new Thread(showwait);
                t2.Start(new datashowwait() { wat = wat });


                t1.Join();
                if (t1.ThreadState != ThreadState.Running)
                {

                    // t2.Abort();

                    wat.Invoke(wat.myDelegate);



                }


            }





        }

      








        //----
    }
}

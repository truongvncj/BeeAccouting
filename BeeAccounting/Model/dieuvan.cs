using System;
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
    class dieuvan
    {


        public static IQueryable selectDonhangghep(LinqtoSQLDataContext db)
        {
            string Username = Utils.getusername();

            var rs = from dh in db.tbl_netcoDonhangTMPs
                     where dh.Username == Username
                     select new
                     {
                         dh.So_van_don,
                         dh.TEN_HANG,
                         dh.ShipTo_Name,

                         dh.A_R_Amount,
                         dh.City,
                         dh.Dia_chi,
                         dh.District,
                         dh.Material,
                         dh.Delivery_Qty,
                         dh.id,



                     };

            return rs;

        }
        public static void deleteAlldonhangtmp(LinqtoSQLDataContext db)
        {
            string Username = Utils.getusername();

            var rs = from dh in db.tbl_netcoDonhangTMPs
                     where dh.Username == Username
                     select dh;
                   
            db.tbl_netcoDonhangTMPs.DeleteAllOnSubmit(rs);
            db.SubmitChanges();


        }

        //public bool customerdeleted()
        //{
        //    #region // xóa data bảng tblCustomer
        //    string connection_string = Utils.getConnectionstr();
        //    var db = new LinqtoSQLDataContext(connection_string);

        //    db.ExecuteCommand("DELETE FROM tbl_PosCustomer");
        //    //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
        //    db.SubmitChanges();



        //    return true;
        //    #endregion

        //}


        class datainportF
        {

            public string filename { get; set; }

        }



        public void inputdonhangnetco(object obj)
        {




            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            datainportF inf = (datainportF)obj;

            string filename = inf.filename;

            //   string filename = theDialog.FileName.ToString();

            //   string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            string Username1 = Utils.getusername();

            dc.ExecuteCommand("DELETE FROM tbl_netcoDonhangTMP   where  tbl_netcoDonhangTMP.Username = '" + Username1 + "'");
            //    dc.tblFBL5Nnewthisperiods.DeleteAllOnSubmit(rsthisperiod);
            dc.CommandTimeout = 0;
            dc.SubmitChanges();




            ExcelProvider ExcelProvide = new ExcelProvider();
            //#endregion
            System.Data.DataTable sourceData = ExcelProvide.GetDataFromExcel(filename);

            System.Data.DataTable batable = new System.Data.DataTable();
            //   batable.Columns.Add("Delivery_No", typeof(double));
            batable.Columns.Add("So_van_don", typeof(string));
            batable.Columns.Add("A/R_Amount", typeof(double));
            batable.Columns.Add("Material", typeof(string));

            batable.Columns.Add("Seri", typeof(string));
            batable.Columns.Add("TEN_HANG", typeof(string));
            batable.Columns.Add("ShipTo_Name", typeof(string));

            batable.Columns.Add("ShipTo_Tel", typeof(string));
            batable.Columns.Add("City", typeof(string));
            batable.Columns.Add("Deadline", typeof(string));

            batable.Columns.Add("NOTE", typeof(string));
            batable.Columns.Add("District", typeof(string));
            batable.Columns.Add("Dia_chi", typeof(string));
            batable.Columns.Add("Delivery_Qty", typeof(double));
            batable.Columns.Add("Username", typeof(string));
            batable.Columns.Add("macty", typeof(string));

            batable.Columns.Add("makhachhang", typeof(string));
            //     batable.Columns.Add("Username", typeof(string));
            //      batable.Columns.Add("Username", typeof(string));
            //   batable.Columns.Add("Username", typeof(string));


            //   " where " + tblnamesub + ".Username ='" + Username + "'"
            //     int Delivery_Noid = 0;
            int So_van_donid = 0;
            int Amountid = 0;
            int Materialid = 0;
            int Seriid = 0;
            int TEN_HANGid = 0;
            int ShipTo_Nameid = 0;
            int ShipTo_Telid = 0;
            int Cityid = 0;

            int Deadlineid = 0;

            int NOTEid = 0;

            int Districtid = 0;

            int Dia_chiid = 0;
            int Delivery_Qtyid = 0;



            //     View.Viewdatatable vi1 = new View.Viewdatatable(sourceData, "Test");

            //     vi1.ShowDialog();
            int rowheadindex = -2;

            for (int rowid = 0; rowid < 3; rowid++)
            {
                // headindex = 1;
                for (int columid = 0; columid < sourceData.Columns.Count; columid++)
                {

                    string value = sourceData.Rows[rowid][columid].ToString();
                    //            MessageBox.Show(value +":"+ rowid);

                    if (value != null)
                    {

                        #region setcolum
                        //if (value.Trim().Contains("Delivery No."))
                        //{
                        //    Delivery_Noid = columid;
                        //    rowheadindex = rowid;
                        //}

                        if (value.Trim().Contains("so van don"))
                        {

                            So_van_donid = columid;
                            rowheadindex = rowid;
                            //    headindex = 0;

                        }


                        if (value.Trim().Contains("A/R Amount"))
                        {

                            Amountid = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim().Contains("Material"))
                        {
                            Materialid = columid;

                        }

                        if (value.Trim().Contains("seri"))
                        {
                            Seriid = columid;

                        }

                        if (value.Trim().Contains("TEN HANG"))
                        {
                            TEN_HANGid = columid;

                        }

                        if (value.Trim().Contains("ShipTo Name"))
                        {
                            ShipTo_Nameid = columid;
                            // headindex = 0;
                        }

                        if (value.Trim().Contains("ShipTo Tel."))
                        {
                            ShipTo_Telid = columid;

                        }

                        if (value.Trim().Contains("City"))
                        {
                            Cityid = columid;

                        }
                        if (value.Trim().Contains("deadline"))
                        {
                            Deadlineid = columid;
                            //    headindex = 0;
                        }
                        if (value.Trim().Contains("NOTE"))
                        {
                            NOTEid = columid;

                        }
                        if (value.Trim().Contains("District"))
                        {
                            Districtid = columid;

                        }
                        if (value.Trim().Contains("dia chi"))
                        {
                            Dia_chiid = columid;

                        }
                        if (value.Trim().Contains("Delivery Qty") || value.Trim().Contains("Total"))
                        {
                            Delivery_Qtyid = columid;

                        }


                        #endregion

                    }


                }// colum

            }// roww off heatder


            for (int rowixd = 0; rowixd < sourceData.Rows.Count; rowixd++)
            {

                #region setvalue of pricelist
                //   string valuepricelist = Utils.GetValueOfCellInExcel(worksheet, rowid, columpricelist);
                string Sovandon = sourceData.Rows[rowixd][So_van_donid].ToString();
                if (Sovandon != "" && rowheadindex != rowixd)
                {


                    DataRow dr = batable.NewRow();
                    //  dr["Delivery_No"] = double.Parse(sourceData.Rows[rowixd][Delivery_Noid].ToString());
                    dr["So_van_don"] = sourceData.Rows[rowixd][So_van_donid].ToString().Trim();

                    if (Utils.IsValidnumber(sourceData.Rows[rowixd][Amountid].ToString()))
                    {
                        dr["A/R_Amount"] = double.Parse(sourceData.Rows[rowixd][Amountid].ToString());
                    }
                    else
                    {
                        dr["A/R_Amount"] = 0;
                    }

                    dr["Material"] = sourceData.Rows[rowixd][Materialid].ToString().Trim();
                    dr["Seri"] = sourceData.Rows[rowixd][Seriid].ToString().Trim();
                    dr["TEN_HANG"] = sourceData.Rows[rowixd][TEN_HANGid].ToString().Trim();
                    dr["ShipTo_Name"] = sourceData.Rows[rowixd][ShipTo_Nameid].ToString().Trim();

                    dr["ShipTo_Tel"] = sourceData.Rows[rowixd][ShipTo_Telid].ToString().Trim();

                    dr["City"] = sourceData.Rows[rowixd][Cityid].ToString().Trim();

                    dr["Deadline"] = sourceData.Rows[rowixd][Deadlineid].ToString().Trim();

                    dr["NOTE"] = sourceData.Rows[rowixd][NOTEid].ToString().Trim();

                    dr["District"] = sourceData.Rows[rowixd][Districtid].ToString();//.Trim();

                    dr["Dia_chi"] = sourceData.Rows[rowixd][Dia_chiid].ToString().Trim();

                    dr["Delivery_Qty"] = double.Parse(sourceData.Rows[rowixd][Delivery_Qtyid].ToString()); //sourceData.Rows[rowixd][Delivery_Qtyid].ToString().Trim();
                    dr["Username"] = Username1; // double.Parse(sourceData.Rows[rowixd][Delivery_Qtyid].ToString()); //sourceData.Rows[rowixd][Delivery_Qtyid].ToString().Trim();
                    dr["macty"] = Model.Username.getmacty();// Username1; // double.Parse(sourceData.Rows[rowixd][Delivery_Qtyid].ToString()); //sourceData.Rows[rowixd][Delivery_Qtyid].ToString().Trim();
                    dr["makhachhang"] = "04";// Model.Username.getmacty();// Username1; // double.Parse(sourceData.Rows[rowixd][Delivery_Qtyid].ToString()); //sourceData.Rows[rowixd][Delivery_Qtyid].ToString().Trim();



                    //   " where " + tblnamesub + ".Username ='" + Username + "'"
                    batable.Rows.Add(dr);


                }

                #endregion

            }// row

            //conpy to server
            string destConnString = Utils.getConnectionstr();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnString))
            {


                bulkCopy.DestinationTableName = "tbl_netcoDonhangTMP";
                // Write from the source to the destination.
                bulkCopy.BulkCopyTimeout = 0;

                //       bulkCopy.ColumnMappings.Add("Delivery_No", "Delivery_No");
                bulkCopy.ColumnMappings.Add("So_van_don", "So_van_don");
                bulkCopy.ColumnMappings.Add("A/R_Amount", "A/R_Amount");

                bulkCopy.ColumnMappings.Add("Material", "Material");
                bulkCopy.ColumnMappings.Add("Seri", "Seri");
                bulkCopy.ColumnMappings.Add("TEN_HANG", "TEN_HANG");

                bulkCopy.ColumnMappings.Add("ShipTo_Name", "ShipTo_Name");
                bulkCopy.ColumnMappings.Add("ShipTo_Tel", "ShipTo_Tel");
                bulkCopy.ColumnMappings.Add("City", "City");
                bulkCopy.ColumnMappings.Add("Deadline", "Deadline");

                bulkCopy.ColumnMappings.Add("NOTE", "NOTE");
                bulkCopy.ColumnMappings.Add("District", "District");
                bulkCopy.ColumnMappings.Add("Dia_chi", "Dia_chi");
                bulkCopy.ColumnMappings.Add("Delivery_Qty", "Delivery_Qty");
                bulkCopy.ColumnMappings.Add("Username", "Username");
                bulkCopy.ColumnMappings.Add("macty", "macty");
                bulkCopy.ColumnMappings.Add("makhachhang", "makhachhang");


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
            //     copy to server
            //     string connection_string = Utils.getConnectionstr();

            //   LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var typeffmain = typeof(tbl_netcoDonhangTMP);
            var typeffsub = typeof(tbl_netcoDonhangTMP);

            View.BeeInputchange inputcdata1 = new View.BeeInputchange("", "ĐƠN HÀNG NETCO ", dc, "tbl_netcoDonhangTMP", "tbl_netcoDonhangTMP", typeffmain, typeffsub, "id", "id", Username1);
            inputcdata1.ShowDialog();



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


        public void donhangnetcoinput()
        {


            //   CultureInfo provider = CultureInfo.InvariantCulture;


            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File Đơn hàng netco excel";
            theDialog.Filter = "Excel files|*.xlsx; *.xls";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                //  AutoResetEvent autoEvent = new AutoResetEvent(false); //join



                string filename = theDialog.FileName.ToString();
                Thread t1 = new Thread(inputdonhangnetco);
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








    }
}

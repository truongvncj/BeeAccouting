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


        public static void deleteAlldonhangtmp(LinqtoSQLDataContext db)
        {
       

        }
        public static void deleteAlldonhangtmptheoID(LinqtoSQLDataContext db, int id)
        {
           

        }
        public static void updatehidedonhangtheoSPvaID(LinqtoSQLDataContext db, int id)
        {
     

        }

        public static void themvaodonhangTEMPtheoSPvaID(LinqtoSQLDataContext dc, int id)
        {
          

        }

        public static void updateunhidedonhangtheoSanphamvaID(LinqtoSQLDataContext db, int id)
        {
           


        }

        public static void deleteAlltheoSPPricetmp(LinqtoSQLDataContext db)
        {
           
        }

     

        public static void listsanphamtheoSPchuacogia(LinqtoSQLDataContext dc)
        {
            //Model.dieuvan.deleteAlltheoSPPricetmp(dc);
            //#region q8 List các document có deposit trong fbl5n  không có trong tblEDLP



            //var q8 = from sp in dc.tbl_DonhangtheoSPvaMKHs
            //         where !(from sp1 in dc.tbl_GiaHDtheoMCTvaSPs
            //                 select sp1.TENHANG
            //                           ).Contains(sp.TEN_HANG)
            //         group sp by new
            //         {
            //             sp.TEN_HANG,
            //             sp.City,


            //         }
            //     into p

            //         select p;


            //if (q8.Count() != 0)
            //{
            //    foreach (var item in q8)
            //    {
            //        tbl_GiaHDtheoMCTvaSPTemp temp = new tbl_GiaHDtheoMCTvaSPTemp();

            //        temp.macty = Model.Username.getmacty();
            //        temp.Username = Utils.getusername();
            //        temp.TENHANG = item.Key.TEN_HANG;
            //        temp.Fromdate = DateTime.Today;
            //        temp.Todate = DateTime.Today.AddYears(100);
            //        temp.City = item.Key.City;
            //        temp.District = item.FirstOrDefault().District;
            //        temp.Gia = 0;

            //        dc.tbl_GiaHDtheoMCTvaSPTemps.InsertOnSubmit(temp);
            //        dc.SubmitChanges();

            //    }




            //    var typeff2 = typeof(tbl_GiaHDtheoMCTvaSPTemp);
            //    var typeff = typeof(tbl_GiaHDtheoMCTvaSP);
            //    string username = Utils.getusername();

            //    View.BeeInputchange inputcdata = new View.BeeInputchange("BẢNG GIÁ ", "LIST SẢN PHẨM CHƯA CÓ GIÁ HÓA ĐƠN ", dc, "tbl_GiaHDtheoMCTvaSP", "tbl_GiaHDtheoMCTvaSPTemp", typeff, typeff2, "id", "id", username);
            //    inputcdata.ShowDialog();// = false;

            //}

            //#endregion List các document có trong tblEDLP không có trong VAT


        }





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

            dc.ExecuteCommand("DELETE FROM tbl_DonhangtheoSPvaMKHTemp   where  tbl_DonhangtheoSPvaMKHTemp.Username = '" + Username1 + "'");
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
            batable.Columns.Add("Ngaytaodon", typeof(DateTime));
            //      batable.Columns.Add("Username", typeof(string));
            //   batable.Columns.Add("Username", typeof(string));


            //   " where " + tblnamesub + ".Username ='" + Username + "'"
            //     int Delivery_Noid = 0;
            int So_van_donid = -1;
            int Amountid = -1;
            int Materialid = -1;
            int Seriid = -1;
            int TEN_HANGid = -1;
            int ShipTo_Nameid = -1;
            int ShipTo_Telid = -1;
            int Cityid = -1;
            int Ngaytaodonid = -1;
            int Deadlineid = -1;

            int NOTEid = -1;

            int Districtid = -1;

            int Dia_chiid = -1;
            int Delivery_Qtyid = -1;



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

                        if (value.Trim().Contains("Date"))
                        {

                            Ngaytaodonid = columid;
                            //  rowheadindex = rowid;
                            //    headindex = 0;

                        }
                        if (value.Trim().Contains("A/R Amount"))
                        {

                            Amountid = columid;
                            //   headindex = 0;



                        }


                        if (value.Trim().Contains("Material")) //seri up
                        {
                            Materialid = columid;

                        }

                        if (value.Trim().Contains("seri") || value.Trim().Contains("MA HANG") || value.Trim().Contains("ma hang up"))
                        {
                            Seriid = columid;

                        }

                        if (value.Trim().Contains("TEN HANG") || value.Trim().Contains("ten hang"))    //ten hang
                        {
                            TEN_HANGid = columid;

                        }

                        if (value.Trim().Contains("ShipTo Name") || value.Trim().Contains("ten up"))
                        {
                            ShipTo_Nameid = columid;
                            // headindex = 0;
                        }

                        if (value.Trim().Contains("ShipTo Tel.") || value.Trim().Contains("Shipping_Phone"))
                        {
                            ShipTo_Telid = columid;

                        }

                        if (value.Trim().Contains("City") || value.Trim().Contains("Shipping_Region"))
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
                        if (value.Trim().Contains("dia chi") || value.Trim().Contains("DIA CHI")) //dia chi
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
                string quanTyti = sourceData.Rows[rowixd][Delivery_Qtyid].ToString();
                if (Utils.IsValidnumber(quanTyti) && rowheadindex != rowixd)
                {


                    DataRow dr = batable.NewRow();
                    //  dr["Delivery_No"] = double.Parse(sourceData.Rows[rowixd][Delivery_Noid].ToString());
                    if (So_van_donid >= 0)
                    {
                        dr["So_van_don"] = sourceData.Rows[rowixd][So_van_donid].ToString().Trim();

                    }
                    if (Amountid >= 0)
                    {
                        if (Utils.IsValidnumber(sourceData.Rows[rowixd][Amountid].ToString()))
                        {
                            dr["A/R_Amount"] = double.Parse(sourceData.Rows[rowixd][Amountid].ToString());
                        }
                        else
                        {
                            dr["A/R_Amount"] = 0;
                        }
                    }
                    if (Materialid >= 0)
                    {
                        dr["Material"] = sourceData.Rows[rowixd][Materialid].ToString().Trim();
                    }

                    if (Seriid >= 0)
                    {
                        dr["Seri"] = sourceData.Rows[rowixd][Seriid].ToString().Trim();
                    }

                    if (TEN_HANGid >= 0)
                    {
                        dr["TEN_HANG"] = sourceData.Rows[rowixd][TEN_HANGid].ToString().Trim();
                    }
                    if (ShipTo_Nameid >= 0)
                    {
                        dr["ShipTo_Name"] = sourceData.Rows[rowixd][ShipTo_Nameid].ToString().Trim();
                    }
                    if (ShipTo_Telid >= 0)
                    {
                        dr["ShipTo_Tel"] = sourceData.Rows[rowixd][ShipTo_Telid].ToString().Trim();
                    }


                    if (Cityid >= 0)
                    {
                        dr["City"] = sourceData.Rows[rowixd][Cityid].ToString().Trim();
                    }
                    if (Deadlineid >= 0)
                    {
                        dr["Deadline"] = sourceData.Rows[rowixd][Deadlineid].ToString().Trim();
                    }
                    if (NOTEid >= 0)
                    {
                        dr["NOTE"] = sourceData.Rows[rowixd][NOTEid].ToString().Trim();
                    }

                    if (Districtid >= 0)
                    {

                        dr["District"] = sourceData.Rows[rowixd][Districtid].ToString();//.Trim();

                    }

                    if (Dia_chiid >= 0)
                    {

                        dr["Dia_chi"] = sourceData.Rows[rowixd][Dia_chiid].ToString().Trim();

                    }

                    dr["Ngaytaodon"] = Utils.chageExceldatetoData(sourceData.Rows[rowixd][Ngaytaodonid].ToString().Trim());


                    if (Delivery_Qtyid >= 0)
                    {
                        dr["Delivery_Qty"] = double.Parse(sourceData.Rows[rowixd][Delivery_Qtyid].ToString()); //sourceData.Rows[rowixd][Delivery_Qtyid].ToString().Trim();

                    }
                    dr["Username"] = Username1; // double.Parse(sourceData.Rows[rowixd][Delivery_Qtyid].ToString()); //sourceData.Rows[rowixd][Delivery_Qtyid].ToString().Trim();
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


                bulkCopy.DestinationTableName = "tbl_DonhangtheoSPvaMKHTemp";
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
                bulkCopy.ColumnMappings.Add("makhachhang", "maKH");
                bulkCopy.ColumnMappings.Add("Ngaytaodon", "Ngayvanchuyen");


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

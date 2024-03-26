using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using cExcel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

using System.Threading;     // For setting the Localization of the thread to fit
using System.Globalization; // the of the MS Excel localization, because of the MS bug
//--

using System.ComponentModel;

using BEEACCOUNT.shared;

//--
namespace BEEACCOUNT
{


    /// <summary>
    /// Provides linq querying functionality towards Excel (xls) files
    /// </summary>
    /// 

    public class ExcelProvider
    {
        /// <summary>
        /// Gets or sets the Excel filename
        /// </summary>
        //  private string FileName { get; set; }
        //   public System.Data.DataTable exceldatatb {get;set; }
        /// <summary>
        /// Template connectionstring for Excel connections
        /// </summary>
        //   public string ConnectionStringTemplate = "";
        /// <summary>
        /// Default constructor
        /// </summary>
        //   /// <param name="fileName">The Excel file to process</param>

        //    public LinQToExcelProvider() { }

        //public ExcelProvider()
        //{
        ////    FileName = fileName;
        //}


        /// <summary>
        /// Returns a worksheet as a linq-queryable enumeration
        /// </summary>
        //    /// <param name="sheetName">The name of the worksheet</param>
        /// <returns>An enumerable collection of the worksheet</returns>
        /// 
        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        public DataTable GetDataFromExcel(string filename)
        {

            var missing = System.Reflection.Missing.Value;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
         //   excelFileName = System.IO.Path.Combine(excelPath, "Ziperty Buy Model for Web 11_11_2011.xlsm");


            cExcel.Application xlApp = new cExcel.Application();
            //cExcel.Workbooks xlWorkBook = null;

            cExcel.Worksheet xlWorkSheet = GetworksheetObject(filename);

            cExcel.Range xlRange = xlWorkSheet.UsedRange;


       



            Array myValues = (Array)xlRange.Cells.Value2;

            int vertical = myValues.GetLength(0);
            int horizontal = myValues.GetLength(1);

            DataTable mainDt = new DataTable();
            DataTable MiscDt = new DataTable();


            

            // must start with index = 1
            // get header information
            for (int i = 1; i <= horizontal; i++)
            {
                if (myValues.GetValue(1, i) == null)
                {
                    mainDt.Columns.Add(new DataColumn(i.ToString()).ToString());
                }
                else
                {
                    mainDt.Columns.Add(new DataColumn(myValues.GetValue(1, i).ToString()));
                }

            }

            // Get the row information
            for (int a = 1; a <= vertical; a++)
            {



             


                //SEE Below line for QUESTION..
               // for (int a = 2; a <= vertical; a++)
                //{
                  //  if (a.Date.HasValue)
                    //    worksheet.Cells[recordIndex, 15].Value = item.Date.Value.ToShortDateString();
               // }

                //Excel sheet cell has data as "11-30-11" but when i import it convert to "78608".  So i want import those data with data as "11-30-11".  


                string x = Convert.ToString(myValues.GetValue(a, 2));
                object[] poop = new object[horizontal];
                //if (x == "11-30-11")
                //{                    
                for (int b = 1; b <= horizontal; b++)
                {

                    


                       

                              //  (DateTime)(myValues.GetValue(a, b)).ToString("dd/MM/yyyy");// ("dd/MM/YYYY");
	                    poop[b - 1] = myValues.GetValue(a, b);
	               

                    

                }
                DataRow row = mainDt.NewRow();
                row.ItemArray = poop;
                mainDt.Rows.Add(row);
                //}                
            }

            // assign table to default data grid view
            //    dataGridView1.DataSource = mainDt;

            //     xlWorkBook.Close(true, missing, missing);

            //     xlWorkSheet = null;
            //     xlWorkBook = null;
            //     xlApp = null;
            xlApp.Quit();
            releaseObject(xlRange);
            releaseObject(xlWorkSheet);
            releaseObject(xlApp);
            GC.Collect();

            return mainDt;
        }


    

        public static string GetExcelCellFormat(string cellFormat )//= "G")
        {
            // MessageBox.Show("ok date !" + cellFormat);
            //switch (cellFormat.Substring(0, 1))
            //{
               if (cellFormat.Contains("#"))
	            {
		        return "Number";
                  
	            }       
                if (cellFormat.Contains("d"))
	            {
		        return "Date";
                     
	            } 
      

                
               
                    return "General";
                    
           // }
        }


        public static cExcel.Worksheet GetworksheetObject(string FileName)
        {


            //       SetConnectionString();
       

            // tim sheetName
            cExcel.Application ExcelObj = new cExcel.Application();

            cExcel.Workbook theWorkbook = null;

            string strPath = FileName;// "MENTION PATH OF EXCEL FILE HERE";

            theWorkbook = ExcelObj.Workbooks.Open(strPath);
            cExcel.Sheets sheets = theWorkbook.Worksheets;

            cExcel.Worksheet worksheet = (cExcel.Worksheet)sheets.get_Item(1);//Get the reference of second worksheet

             cExcel.Range xlRange = worksheet.UsedRange;

            //
         //    int vertical = xlRange.VerticalAlignment;
            //go through each 


             foreach (var item in xlRange)
             {
                 cExcel.Range rg = (cExcel.Range)item;

             
                 String format =  GetExcelCellFormat(rg.NumberFormat.ToString());
              
                      if (format == "Date")
	                    {
                            string strdate;

                          if (Utils.IsValidnumber(rg.Value.ToString()))  //Value2
                            {
                               
                                strdate = Convert.ToDateTime(rg.Value).ToString("dd/MM/yyyy");
                              //  MessageBox.Show("ok date !" + strdate);
                            }
                            else
                            {
                                strdate = rg.Value.ToString();
                            }
                          

                      //   MessageBox.Show("ok date !" + strdate);
                        rg.Value = strdate;


                         // rg.set_Value( string , strdate);

	                    } 
                 
                 

             }



            return worksheet;
            //  string sheetName =  worksheet.Name;//Get the name of worksheet.
            // return sheetName;
        }


    }






}


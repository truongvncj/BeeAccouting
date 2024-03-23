using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cExcel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using BEEACCOUNT.shared;
using System.Globalization;
using System.Data.Sql;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.IO;

namespace BEEACCOUNT
{
    class Utils
    {
        public static DateTime getEndOfMonth(DateTime date)
        {
            if (date.Month == 12)
            {
                // nếu là tháng 12 thì trả về ngày 31
                return new DateTime(date.Year, date.Month, 31);
            }
            // chuyển tới ngày đầu tiên của tháng kế tiếp
            DateTime tem = new DateTime(date.Year, date.Month + 1, 1);
            // lùi lại 1 ngày là về ngày cuối tháng của tháng hiện tại rồi. 
            return tem.AddDays(-1);
        }


        public static DateTime getFirstOfMonth(DateTime date)
        {
            if (date.Month == 1)
            {
                // nếu là tháng 12 thì trả về ngày 31
                return new DateTime(date.Year, date.Month, 01);
            }
            // chuyển tới ngày đầu tiên của tháng kế tiếp
            DateTime tem = new DateTime(date.Year, date.Month, 01);
            // lùi lại 1 ngày là về ngày cuối tháng của tháng hiện tại rồi. 
            return tem;
        }

        // public static string ChuyenSo(string number)
        public static string ChuyenSo(decimal total)  //đọc đc 18 số vd: 999999999999999999
        {
            {
                try
                {
                    string rs = "";
                    total = Math.Round(total, 0);
                    string[] ch = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                    string[] rch = { "lẻ", "mốt", "", "", "", "lăm" };
                    string[] u = { "", "mươi", "trăm", "ngàn", "", "", "triệu", "", "", "tỷ", "", "", "ngàn", "", "", "triệu" };
                    string nstr = total.ToString();
                    int[] n = new int[nstr.Length];
                    int len = n.Length;
                    for (int i = 0; i < len; i++)
                    {
                        n[len - 1 - i] = Convert.ToInt32(nstr.Substring(i, 1));
                    }
                    for (int i = len - 1; i >= 0; i--)
                    {
                        if (i % 3 == 2)// số 0 ở hàng trăm
                        {
                            if (n[i] == 0 && n[i - 1] == 0 && n[i - 2] == 0) continue;//nếu cả 3 số là 0 thì bỏ qua không đọc
                        }
                        else if (i % 3 == 1) // số ở hàng chục
                        {
                            if (n[i] == 0)
                            {
                                if (n[i - 1] == 0) { continue; }// nếu hàng chục và hàng đơn vị đều là 0 thì bỏ qua.
                                else
                                {
                                    rs += " " + rch[n[i]]; continue;// hàng chục là 0 thì bỏ qua, đọc số hàng đơn vị
                                }
                            }
                            if (n[i] == 1)//nếu số hàng chục là 1 thì đọc là mười
                            {
                                rs += " mười"; continue;
                            }
                        }
                        else if (i != len - 1)// số ở hàng đơn vị (không phải là số đầu tiên)
                        {
                            if (n[i] == 0)// số hàng đơn vị là 0 thì chỉ đọc đơn vị
                            {
                                if (i + 2 <= len - 1 && n[i + 2] == 0 && n[i + 1] == 0) continue;
                                rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                                continue;
                            }
                            if (n[i] == 1)// nếu là 1 thì tùy vào số hàng chục mà đọc: 0,1: một / còn lại: mốt
                            {
                                rs += " " + ((n[i + 1] == 1 || n[i + 1] == 0) ? ch[n[i]] : rch[n[i]]);
                                rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                                continue;
                            }
                            if (n[i] == 5) // cách đọc số 5
                            {
                                if (n[i + 1] != 0) //nếu số hàng chục khác 0 thì đọc số 5 là lăm
                                {
                                    rs += " " + rch[n[i]];// đọc số 
                                    rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                                    continue;
                                }
                            }
                        }
                    //    rs += (rs == "" ? " " : ", ") + ch[n[i]];// đọc số
                        rs += (rs == "" ? " " : " ") + ch[n[i]];// đọc số
                        rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                    }
                    if (rs[rs.Length - 1] != ' ')
                        rs += " đồng.";
                    else
                        rs += "đồng.";
                    if (rs.Length > 2)
                    {
                        string rs1 = rs.Substring(0, 2);
                        rs1 = rs1.ToUpper();
                        rs = rs.Substring(2);
                        rs = rs1 + rs;
                    }
                    return rs.Trim().Replace("lẻ,", "lẻ").Replace("mươi,", "mươi").Replace("trăm,", "trăm").Replace("mười,", "mười");
                }
                catch
                {
                    return "Số bạn nhập vào quá lớn";
                }
            }
        }

        public static bool ChangeColumnDataType(DataTable table, string columnname, Type newtype)
        {
            if (table.Columns.Contains(columnname) == false)
                return false;

            DataColumn column = table.Columns[columnname];
            if (column.DataType == newtype)
                return true;

            try
            {
                DataColumn newcolumn = new DataColumn("temporary", newtype);
                table.Columns.Add(newcolumn);
                foreach (DataRow row in table.Rows)
                {
                    try
                    {
                        row["temporary"] = Convert.ChangeType(row[columnname], newtype);
                    }
                    catch
                    {
                    }
                }
                table.Columns.Remove(columnname);
                newcolumn.ColumnName = columnname;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        //public static string getfirstusersalescontrolregion()
        ////{
        ////    string username = Utils.getusername();
        ////        string connection_string = Utils.getConnectionstr();
        ////    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
        ////    var regioncode = (from tbl_Temp in db.tbl_Temps
        ////                      where tbl_Temp.username == username
        ////                      select tbl_Temp.RegionCode).FirstOrDefault();
        ////    string rs = (from Tka_RegionRight in db.Tka_RegionRights
        ////                 where Tka_RegionRight.RegionCode == regioncode
        ////                 select Tka_RegionRight.Region).FirstOrDefault();

        ////    return rs;
        //}

        public static string getusername()
        {
            String current = System.IO.Directory.GetCurrentDirectory();

            string fileName = current + "\\String.txt";
            const Int32 BufferSize = 128;

            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                string st4;
                while ((line = streamReader.ReadLine()) != null)

                {
                    string[] parts = line.Split(';');
                    if (parts.Count() >= 4)
                    {
                        st4 = parts[4].Trim();
                    }
                    else
                    {
                        st4 = "";
                    }
                    //       string st1 = parts[0].Trim();
                    //       string st2 = parts[1].Trim();
                    //  string st3 = parts[2].Trim();


                    string username = st4;
                    return username;



                }

                return "";

            }

        }




        public static int getrightnumber()
        {
            string username = Utils.getusername();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = (from tbl_Temp in dc.tbl_Temps
                      where tbl_Temp.Username == username

                      select tbl_Temp.Userright).FirstOrDefault();
            if (rs == null)
            {
                return 0;
            }
            else
            {

                return rs.Value;
            }

        }
        public static string getname()
        {
            string username = Utils.getusername();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = (from tbl_Temp in dc.tbl_Temps
                      where tbl_Temp.Username.Trim() == username.Trim()

                      select tbl_Temp.Name).FirstOrDefault();
            if (rs == null)
            {
                return "";
            }
            else
            {

                return rs.ToString().Truncate(50);
            }

        }




        public static string getConnectionstr()
        {
            String current = System.IO.Directory.GetCurrentDirectory();

            string fileName = current + "\\String.txt";
            string connection_string = "";
            const Int32 BufferSize = 128;

            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)

                {
                    string[] parts = line.Split(';');

                    string st1 = parts[0].Trim();
                    string st2 = parts[1].Trim();
                    string st3 = parts[2].Trim();
                    string st4 = parts[3].Trim();
                    // chua8923_BEE  BEE
                    connection_string = ("Data Source =" + st1 + "; Initial Catalog = " + st4+"; User Id =" + st2 + "; Password =" + st3).Trim();
                    return connection_string;



                }

                return "";


            }

        }




        public static bool IsValidnumber(string number)
        {


            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(number);


        }


        public DataTable ToDataTable(System.Data.Linq.DataContext ctx, object query)
        {
            if (query == null)
            {
            throw new ArgumentNullException("query");


            }

            IDbCommand cmd = ctx.GetCommand(query as IQueryable);
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
            adapter.SelectCommand = (System.Data.SqlClient.SqlCommand)cmd;
            DataTable dt = new DataTable();


            try
            {

                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }





                adapter.FillSchema(dt, SchemaType.Source);
                adapter.Fill(dt);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }
        //run other app
        public static void RunOtherApp(string filename, bool isOpenInventer)
        {
            try
            {
                if (System.IO.File.Exists(filename))
                {
                    var p = new Process();
                    p.StartInfo.FileName = filename;
                    p.Start();
                    //p.WaitForExit(120000);
                    if (!isOpenInventer)
                    {
                        p.WaitForInputIdle(120000);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }


     


        public static bool SetValueOfCellInExcel(cExcel.Worksheet sheet, int rowIndex, int clmIndex, string value)
        {
            // sheet.Cells[rowIndex,co]
            try
            {
                // cExcel.Range rng = sheet.Cells[rowIndex, clmIndex]; //get_Range("B5", "B5");
                cExcel.Range rng = (cExcel.Range)sheet.Cells[rowIndex, clmIndex];


                rng.Value2 = value;
                return true;
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.ToString());
                return false;
            }

        }


        //get value of specific cell in excel
        public static string GetValueOfCellInExcel(cExcel.Worksheet sheet, int rowIndex, int clmIndex)
        {
            try
            {
                cExcel.Range rng = (cExcel.Range)sheet.Cells[rowIndex, clmIndex]; //get_Range("B5", "B5");         
                if (rng.Value != null)
                {
                    return ((object)rng.Value).ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
                return null;
            }

        }

       

        public static DateTime chageExceldatetoData(string exceldatedotstring)  // dd.MM.YYYY to date
        {

            string get_data = exceldatedotstring;//.Replace("9999",(DateTime.Now.Year +1).ToString());
            get_data = get_data.Replace(" ", "");
            get_data = get_data.Left(10);
            get_data = get_data.Replace("/", ".");
            get_data = get_data.Replace("-", ".");

            
            char spl2 = '.';
          

            List<string> lst_get_data = get_data.Split(spl2).ToList();
            // cmd.Parameters.AddWithValue("?", GetDateWithoutMilliseconds(DateTime.Now));
            // 30.12.2023
            //private DateTime GetDateWithoutMilliseconds(DateTime d)
            //        {
            //            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
            //        }
            DateTime kq;
            try
            {
                kq = new DateTime(int.Parse(lst_get_data[2]), int.Parse(lst_get_data[1]), int.Parse(lst_get_data[0]));

            }
            catch (Exception) //DateTime year, month, day
            {
                kq = new DateTime(9999, 12, 31);


                //  throw;
            }

            //     DateTime result = new DateTime(kq.Year, kq.Month, kq.Day, kq.Hour, kq.Minute, kq.Second);
            // string result =  lst_get_data[2] + "-" + lst_get_data[1] + "-" + lst_get_data[0] ;
            return kq;
            //throw new NotImplementedException();
        }



        //public static DateTime ChageExceldatetoDate(string get_data)


        //{
        //    //   DateTime result_date;
        //    CultureInfo provider = CultureInfo.InvariantCulture;
        //    //     this.Clearing_date = DateTime.ParseExact("21/10/1979", "{dd/mm/yyyy }", provider);


        //    DateTime result_date;//= DateTime.Now;
        //                         //   get_data = "";
        //                         //   if (excelDate != "")
        //                         // {
        //                         //    string get_data = excelDate;
        //                         //  }

        //    #region // lấy format hệ thống , kiểm tra xem ngày ở số i; tháng ở bản j ; năm ở bản k byte


        //    DateTime check_date = DateTime.Now;
        //    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        //    char spl = '.';
        //    if (sysFormat.Contains("/"))
        //    {

        //        spl = '/';
        //    }
        //    else
        //    {
        //        if (sysFormat.Contains("-"))
        //        {
        //            spl = '-';

        //        }
        //        else
        //        {
        //            spl = '.';

        //        }

        //    }


        //    List<string> lst_get_sys = sysFormat.Split(spl).ToList();



        //    int dayid = 0;
        //    int monthid = 0;
        //    int yearid = 0;

        //    for (int i = 0; i <= lst_get_sys.Count - 1; i++)
        //    {
        //        if (lst_get_sys[i].Contains("d") || lst_get_sys[i].Contains("D"))
        //        {
        //            dayid = i;
        //        }

        //        if (lst_get_sys[i].Contains("m") || lst_get_sys[i].Contains("M"))
        //        {
        //            monthid = i;
        //        }
        //        if (lst_get_sys[i].Contains("y") || lst_get_sys[i].Contains("Y"))
        //        {
        //            yearid = i;
        //        }

        //    }


        //    #endregion
        //    //   MessageBox.Show(get_data);
        //    //lấy về format date của hệ thống

        //    //chặt nhỏ giá trị date time lấy được từ file excel theo format date của hệ thống



        //    //---
        //    if (get_data.Contains("/"))
        //    {

        //        spl = '/';
        //    }
        //    else
        //    {
        //        if (sysFormat.Contains("-"))
        //        {
        //            spl = '-';

        //        }
        //        else
        //        {
        //            spl = '.';

        //        }

        //    }
        //    List<string> lst_get_data = get_data.Split(spl).ToList();
        //    //--



        //    if (lst_get_data.Count == 3)

        //    {
        //        if (lst_get_data[dayid].Length == 1)
        //        {
        //            lst_get_data[dayid] = "0" + lst_get_data[dayid];


        //        }
        //        if (lst_get_data[monthid].Length == 1)
        //        {
        //            lst_get_data[monthid] = "0" + lst_get_data[monthid];


        //        }
        //        if (lst_get_data[yearid].Length == 2)
        //        {
        //            lst_get_data[yearid] = "20" + lst_get_data[yearid];


        //        }

        //        if (lst_get_data[yearid].Length > 4)
        //        {

        //            List<string> lst_get_year = lst_get_data[yearid].Split(' ').ToList();
        //            lst_get_data[yearid] = lst_get_year[0];

        //            if (lst_get_data[yearid].Length == 2)
        //            {
        //                lst_get_data[yearid] = "20" + lst_get_data[yearid];


        //            }


        //        }

        //        string sresultdate = lst_get_data[dayid] + "/" + lst_get_data[monthid] + "/" + lst_get_data[yearid];

        //        result_date = DateTime.ParseExact(sresultdate, "dd/MM/yyyy", provider);


        //        return result_date;


        //    }
        //    else
        //    {

        //        if (Utils.IsValidnumber(get_data))
        //        {
        //            result_date = DateTime.FromOADate(double.Parse(get_data));
        //            return result_date;
        //        }
        //        //else
        //        //{
        //        //    return null;
        //        //}
        //        ////     MessageBox.Show("Lỗi format ngày tháng !");

        //        result_date = DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", provider);

        //    }

        //    return result_date;

        //}






        public static bool IsHasWorkbookActive()
        {
            try
            {
                cExcel.Application isActive = (cExcel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                if (isActive != null)
                {
                    if (isActive.ActiveWorkbook != null)
                    //if (Constants.app.ActiveWorkbook != null)
                    {
                        isActive.Quit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.ToString());
                return false;
            }

        }

        //phương thức mở file excel của dự án 
        public static bool OpenFile_Excel(string filename)
        {
            try
            {
                object valueMissing = System.Reflection.Missing.Value;
                //check xem application đã được khởi tạo hay chưa
                if (Constants.app == null)
                {
                    //nếu chưa được khởi tạo thì khởi tạo mới
                    cExcel.Application app = new cExcel.Application();
                }
                else
                {
                    //nếu đã được khởi tạo thì ...
                    //check xem có dự án nào đang mở hay k, nếu có thì đóng lại trước khi mở dự án mới
                    if (Utils.IsHasWorkbookActive())
                    {
                        Constants.app.Quit();
                        //Constants.app = new cExcel.Application();
                    }
                }


                //     Constants.app.WorkbookOpen
                //mở file excel mới
                //   Constants.book = Constants.app.Workbooks.Open(Constants.URLtoFileStoreData, 0, false, 5, "", "DOC", true, cExcel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
                //      Constants.book = Constants.app.Workbooks.Open(filename, 0, false, 5, "", "DOC", true, cExcel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);

                Constants.book = Constants.app.Workbooks.Open(filename, 0, false, 5, "", "", true, cExcel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
                //   cExcel.Workbooks = new cExcel.Workbooks.

                //ok = Constants.app.WorkbookOpen;

                //      .app.Workbooks.Open(Constants.URLtoFileStoreData, 0, false, 5, "", "DOC", true, cExcel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
        //---
        public void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
             
                GC.WaitForPendingFinalizers();


            }
        }

        public static bool CreatFile_Excel(string filename)
        {

            cExcel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            #region // kiểm tra file excel đã inteal chưa
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return false;
            }

            #endregion

            #region // tạo 1 file excel
            cExcel.Workbook xlWorkBook;
            cExcel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (cExcel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            //   xlWorkSheet.Cells[1, 1] = "Sheet1";




            xlWorkBook.SaveAs(filename, cExcel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, cExcel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //  xlWorkBook.SaveAs(filename,cExcel.XlFileFormat.xlWorkbookDefault,)
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Utils ut = new Utils();

            ut.ReleaseObject(xlWorkSheet);
            ut.ReleaseObject(xlWorkBook);
            ut.ReleaseObject(xlApp);

            // MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xls");
            return true;

            #endregion tạo 1 file excel


        }




        //phương thức đóng file excel của dự án và mở sẵn 1 file excel mới
        public static bool Close_File_Excel()
        {
            try
            {
                Constants.app.Quit();
                //Constants.app = new cExcel.Application();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //phương thức chèn dữ liệu ban đầu cho list_Validate_Request_KTKC
        /*   public static void Set_Value_for_List_Validate_Request_KTKC()
           {
               Constants.lst_Validate_Request_KTKC = new List<Model.KiemTraKC.Validate_Request_KTKC_Ett>();

               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.TietDienAAGiuaDam_Name, List_Validate_Request_KTKC_Ett.Default_Value));
               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.TietDienBBDauDam_Name, List_Validate_Request_KTKC_Ett.Default_Value));
               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.KetCauBanCanhDuoi_Name, List_Validate_Request_KTKC_Ett.Default_Value));
               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.DieuKienDoCung_Name, List_Validate_Request_KTKC_Ett.Default_Value));
               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.DieuKienOnDinhCucBo_Name, List_Validate_Request_KTKC_Ett.Default_Value));
               Constants.lst_Validate_Request_KTKC.Add(new Validate_Request_KTKC_Ett(List_Validate_Request_KTKC_Ett.TietDienCCGiuaDam_Name, List_Validate_Request_KTKC_Ett.Default_Value));
           }
           */
        //reset all global param
        /*    public static void Reset_All_Global_Param()
            {
                Controlers.NhapSL.ThongSoChoTruoc_ctrl.resetValueForThongSoDauVao();
                Controlers.NhapSL.ThongSoHinhHoc.KichThuocVaTietDienDam_ctrl.resetValueForKichThuocVaTietDienDam();
                Controlers.NhapSL.ThongSoHinhHoc.ThongSoGanTangCung_ctrl.resetValueForTS_GanTangCung();
                Controlers.NhapSL.ThongSoVatLieu.ThongSoVatLieuCheTao_ctrl.resetValueForTS_VL_CheTao();
                Controlers.NhapSL.ThongSoVatLieu.ThongSoVatLieuLienKet_ctrl.resetValueTS_VL_LienKet();
                Utils.Set_Value_for_List_Validate_Request_KTKC();
            }
            */


        //set value for all global param
        /*   public static void Set_Value_4_All_Global_Param()
           {
               try
               {
                   if (Utils.OpenFile_Excel_of_Project())
                   {
                       if (Constants.book.Worksheets.Count >= 0)
                       {
                           bool hasSheetTTDA = false;
                           //bool hasSheetTS_Chotruoc = false;

                           //reset all value of application
                           Utils.Reset_All_Global_Param();

                           foreach (cExcel.Worksheet sheet in Constants.book.Worksheets)
                           {
                               //nếu tồn tại sheet thoogn tin dự án thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThongTinDuAn_MenuName))
                               {
                                   Controlers.NhapSL.ThongTinDuAn_ctrl.setValueForTTDA(sheet);
                                   hasSheetTTDA = true;
                               }

                               //nếu tồn tại sheet Thông số cho trước thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThongSoChoTruoc_MenuName))
                               {
                                   Controlers.NhapSL.ThongSoChoTruoc_ctrl.setValueForThongSoDauVao(sheet);
                               }

                               //nếu tồn tại sheet Kích thước và tiết diện dầm thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThoongSoHinhHoc_KichThuocVaTietDienDam_MenuName))
                               {
                                   Controlers.NhapSL.ThongSoHinhHoc.KichThuocVaTietDienDam_ctrl.setValueForKichThuocVaTietDienDam(sheet);
                               }

                               //nếu tồn tại sheet Thông số gân tăng cứng thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThoongSoHinhHoc_ThongSoGanTangCung_MenuName))
                               {
                                   Controlers.NhapSL.ThongSoHinhHoc.ThongSoGanTangCung_ctrl.setValueForTS_GanTangCung(sheet);
                               }

                               //nếu tồn tại sheet ThongSoVatLieuCheTao thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThoongSoVatLieu_ThongSoVatLieuCheTao_MenuName))
                               {
                                   Controlers.NhapSL.ThongSoVatLieu.ThongSoVatLieuCheTao_ctrl.setValueForTS_VL_CheTao(sheet);
                               }

                               //nếu tồn tại sheet ThongSoVatLieuLienKet thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.ThongSoVatLieu_ThongSoVatLieuLienKet_MenuName))
                               {
                                   Controlers.NhapSL.ThongSoVatLieu.ThongSoVatLieuLienKet_ctrl.setValueForTS_VL_LienKet(sheet);
                               }

                               //nếu tồn tại sheet KiemTraKC thì set value cho obj tương ứng
                               if (sheet.Name.Equals(Constants.KiemTraKC_MenuName))
                               {
                                   Controlers.KiemTraKC.KiemTraKC_ctrl.setValueFor_ListValidateRequest(sheet);
                               }
                           }

                           //show msg error
                           if (!hasSheetTTDA)
                           {
                               MessageBox.Show(Constants.NOT_Existent_Sheet_msg + Constants.ThongTinDuAn_MenuName, Constants.Err_Caption_msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                               Constants.ttda = new Model.NhapSL.ThongTinDuAn_Ett();
                           }
                       }

                       //đóng file excel sau khi sử dụng
                       if (!Utils.Close_File_Excel_of_Project())
                       {
                           if (MessageBox.Show(Constants.Error_Close_File_Excel_msg, Constants.Err_Caption_msg, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
                           {
                               Application.Exit();
                           }
                       }

                       //thôngTinDựÁnToolStripMenuItem_Click(sender, e);
                   }
                   else
                   {
                       MessageBox.Show(Constants.Error_Open_File_Excel_msg, Constants.Err_Caption_msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }
               catch (Exception ex)
               {
                   ShowErrorGeneralMsgBox(ex);
               }
           }

           public static double LamTron_SoChan(double input_param)
           {
               try
               {
                   double tg = Math.Round(input_param, 0);
                   //kiểm tra xem có phải số chẵn hay k
                   if (tg % 2 == 0)
                   {
                       //Nếu là số chẵn thì trả ra
                       return tg;
                   }
                   else
                   {
                       //Nếu không phải là số chẵn thì cộng 1 và trả ra
                       return tg + 1;
                   }
               }
               catch (Exception ex)
               {
                   return double.NaN;
               }
           }
           */

        // doc file excel va so sanh vơi cac fied của data và update vào sql



     
        // doc file excel va so sanh vơi cac fied của data và update vào sql
        public static bool CopyFolder(string sourcePath, string targetPath)
        {
            try
            {
                if (System.IO.Directory.GetDirectories(sourcePath).Count() > 0)
                {
                    foreach (string d in System.IO.Directory.GetDirectories(sourcePath))
                    {
                        //chặt string lấy tên folder cuối cùng cộng thêm vào tên folder đích
                        string[] lst_folder = d.Split('\\');
                        targetPath = targetPath + "\\" + lst_folder[lst_folder.Count() - 1];
                        System.IO.Directory.CreateDirectory(targetPath);
                        CopyFolder(d, targetPath);

                        //sau khi copy file -> trả lại đường dẫn đến folder đích
                        string[] target_fdn_lst = targetPath.Split('\\');
                        int start_Index = targetPath.IndexOf(target_fdn_lst[target_fdn_lst.Count() - 1]);
                        targetPath = targetPath.Remove(start_Index - 1);
                    }
                }

                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi copy file" + ex);
                return false;
            }

        }
    }


}


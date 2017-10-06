using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.Model
{
    class loaitaikhoanketoan
    {

        public static IQueryable danhsachloaitaikhoan(LinqtoSQLDataContext dc)
        {




            //// string connection_string = Utils.getConnectionstr();

            //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = dc;


            var rs = from loaitks in dc.tbl_loaitks
                     select new
                     {
                         Mã_loại_tài_khoản = loaitks.idloaitk,
                         Tên_mã_loại_tài_khoản = loaitks.name,
                         ID = loaitks.id
                     };

            //    grviewlisttk.DataSource = rs;







            return rs;





        }

        public static void themmoiloaitaikhoan()
        {

            View.Beeloaitaikhoan loaitkform = new View.Beeloaitaikhoan(1,-1); // 1 la nghiep vu them moi

            loaitkform.ShowDialog();


            bool chon = loaitkform.chon;
            string tenloaitk = loaitkform.tenloaitk;
            string maloaitk = loaitkform.maloaitk;
            if (chon)
            {
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                tbl_loaitk tk = new tbl_loaitk();

                tk.name = tenloaitk;
                tk.idloaitk = maloaitk;
              
                db.tbl_loaitks.InsertOnSubmit(tk);
                db.SubmitChanges();




            }






        }

        public static void sualoaitaikhoanketoan(int id)
        {


            //  string taikhoan = rs.matk;

            View.Beeloaitaikhoan createacc = new View.Beeloaitaikhoan(2, id); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
          
           createacc.ShowDialog();
        

        }
    }
}

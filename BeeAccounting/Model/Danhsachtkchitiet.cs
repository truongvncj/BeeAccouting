using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.Model
{
    class Danhsachtkchitiet
    {

        public static IQueryable danhsachtaikhoanchitiet(LinqtoSQLDataContext dc)
        {




            //// string connection_string = Utils.getConnectionstr();

            //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = dc;


            var rs = from dschitiet in dc.tbl_machitiettks
                      select new
                      {
                          Mã_tài_khoản = dschitiet.matk,
                          Tên_tài_khoản_chi_tiết = dschitiet.tenchitiet,
                          Mã_chi_tiết = dschitiet.machitiet,
                          Ghi_chú = dschitiet.ghichu,
                          Nợ_đầu_kỳ = dschitiet.nodk,
                          Có_đầu_kỳ = dschitiet.codk,
                          ID = dschitiet.id
                      };





            return rs;





        }

        public static void themmoichitiettaikhoan()
        {

          //  View.Beemosochitiettaikhoan loaitkform = new View.Beemosochitiettaikhoan(1, ""); // 1 la nghiep vu them moi


            View.Beemosochitiettaikhoan loaitkform = new View.Beemosochitiettaikhoan(1, "",0); // 1 la nghiep vu them moi
            loaitkform.ShowDialog();


            bool chon = loaitkform.chon;
         //   string tenloaitk = loaitkform.tenloaitk;
         //   int maloaitk = loaitkform.maloaitk;
            //if (chon)
            //{
            //    string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //    tbl_loaitk tk = new tbl_loaitk();

            //    tk.name = tenloaitk;
            //    tk.idloaitk = maloaitk;


            //    db.tbl_loaitks.InsertOnSubmit(tk);
            //    db.SubmitChanges();




            //}






        }

        //    
        public static void suachitiettaikhoan(int idchitiet)
        {

            //  View.Beemosochitiettaikhoan loaitkform = new View.Beemosochitiettaikhoan(1, ""); // 1 la nghiep vu them moi


            View.Beemosochitiettaikhoan loaitkform = new View.Beemosochitiettaikhoan(2, "", idchitiet); // 2 la nghiep vu sua
            loaitkform.ShowDialog();


            bool chon = loaitkform.chon;
            //   string tenloaitk = loaitkform.tenloaitk;
            //   int maloaitk = loaitkform.maloaitk;
            //if (chon)
            //{
            //    string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //    tbl_loaitk tk = new tbl_loaitk();

            //    tk.name = tenloaitk;
            //    tk.idloaitk = maloaitk;


            //    db.tbl_loaitks.InsertOnSubmit(tk);
            //    db.SubmitChanges();




            //}






        }

    }
}

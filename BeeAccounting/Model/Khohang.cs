using BEEACCOUNT.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.Model
{
    class Khohang
    {


        public static IQueryable Danhsachkho(LinqtoSQLDataContext dc)
        {


            LinqtoSQLDataContext db = dc;


            var rs = from p in dc.tbl_khohangs
                     select new
                     {

                         Mã_kho = p.makho,
                         Tên_kho = p.tenkho,
                         Địa_chỉ = p.diachikho,

                         ID = p.id
                     };





            return rs;





        }

        public static void themmoikhohang()
        {
            View.BeeDanhsachkho p = new BeeDanhsachkho(3, -1);  // 3 là thêm ới/ 4 là sửa xóa
                                                                //  View.BeeDanhsachkho p = new View.BeeDanhsachkho
            p.ShowDialog();






            // throw new NotImplementedException();
        }

        public static void suaxoadanhsachkho(int iddanhscahkho)
        {




            View.BeeDanhsachkho p = new BeeDanhsachkho(4, iddanhscahkho);  // 3 là thêm ới/ 4 là sửa xóa
                                                                           //  View.BeeDanhsachkho p = new View.BeeDanhsachkho
            p.ShowDialog();





            //  throw new NotImplementedException();
        }

        public static IQueryable danhsachnhomsanpham(LinqtoSQLDataContext dc)
        {



            LinqtoSQLDataContext db = dc;


            var rs = from p in dc.tbl_kho_nhomsanphams
                     select new
                     {

                         Mã_nhóm = p.manhomsanpham,
                         Tên_nhóm_sản_phẩm = p.tennhomsanpham,


                         ID = p.id
                     };





            return rs;










            //  throw new NotImplementedException();
        }

        public static void themmoinhomsanpham()
        {

            View.BeeDanhsachnhomsanpham p = new BeeDanhsachnhomsanpham(3, -1);  // 3 là thêm ới/ 4 là sửa xóa
                                                                                //  View.BeeDanhsachkho p = new View.BeeDanhsachkho
            p.ShowDialog();







            //throw new NotImplementedException();
        }

        public static void suanhomsanpham(int idtk)
        {


            View.BeeDanhsachnhomsanpham p = new BeeDanhsachnhomsanpham(4, idtk);  // 3 là thêm ới/ 4 là sửa xóa
                                                                                  //  View.BeeDanhsachkho p = new View.BeeDanhsachkho
            p.ShowDialog();



            //throw new NotImplementedException();
        }

        public static IQueryable danhsachsanpham(LinqtoSQLDataContext dc)
        {


            LinqtoSQLDataContext db = dc;


            var rs = from p in dc.tbl_kho_sanphams
                     select new
                     {

                         Mã_sản_phẩm = p.masp,
                         Tên_sản_phẩm = p.tensp,
                         Mã_vạch = p.mavach,
                         Đơn_vị = p.donvi,
                         KHối_lượng = p.khoiluong,
                         Trọng_lượng = p.trongluong,
                         Mã_nhóm_sản_phẩm = p.idmanhomsp,
                         Ghi_chú = p.ghichu,



                         ID = p.id
                     };





            return rs;






            //    throw new NotImplementedException();
        }

        public static void themmoisanpham()
        {

            View.BeeDanhsachsanpham p = new BeeDanhsachsanpham(3, -1);  // 3 là thêm ới/ 4 là sửa xóa
                                                                        //  View.BeeDanhsachkho p = new View.BeeDanhsachkho
            p.ShowDialog();





            //  throw new NotImplementedException();
        }





    }
}

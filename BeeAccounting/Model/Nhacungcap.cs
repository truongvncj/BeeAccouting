using BEEACCOUNT.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.Model
{
    class Nhacungcap
    {
        public IQueryable Danhsach { get; set; }

        public static IQueryable danhsachNhacungcap(LinqtoSQLDataContext dc)
        {




            //// string connection_string = Utils.getConnectionstr();

            //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = dc;
            var rs = from p in db.tbl_danhsachnhacungcaps
                     orderby p.maNcc
                     select new
                     {


                         Mã_nhà_cung_ứng = p.maNcc,
                         Tên_nhà_cung_ứng = p.tenNcc,
                         Mã_số_thuế = p.masothue,
                         Địa_chỉ = p.sonha.Trim() + " " + p.duongpho.Trim() + " " + p.huyenquan.Trim() + " " + p.thanhpho.Trim() + " " + p.quocgia.Trim(),
                         Điện_thoại = p.dienthoai,
                         Người_đại_diện = p.nguoidaidien,
                         Số_tài_khoán_ngân_hàng = p.sotaikhoannganhang,
                         Tên_ngân_hàng = p.tennganhang,
                         Ghi_chú = p.ghichunganhnghe,
                         Ngày_tạo = p.ngaytao,
                         Người_tạo = p.usertao,


                         ID = p.id,
                     };

            //    grviewlisttk.DataSource = rs;







            return rs;





        }




        internal static void themmoiNCC()
        {

            View.BeeNCCnewaccount p = new BeeNCCnewaccount(3, -1);  // 3 là thêm ới

            p.ShowDialog();


        }



        internal static void suathongtinNCC(int idtk)
        {

            View.BeeNCCnewaccount p = new BeeNCCnewaccount(4, idtk);  // 4 là vua sua vua xóa

            p.ShowDialog();



            //    throw new NotImplementedException();
        }

        public static IQueryable danhsachNVT(LinqtoSQLDataContext dc)
        {
            //throw new NotImplementedException();

            //   NPDanhsachnhavantai

            LinqtoSQLDataContext db = dc;
            var rs = from p in db.tbl_NP_Nhacungungvantais
                     orderby p.maNVT
                     select new
                     {


                         Mã_nhà_vận_tải = p.maNVT,
                         Tên_nhà_vận_tải = p.tenNVT,
                         Mã_số_thuế = p.masothueNVT,
                         Địa_chỉ = p.diachinganhangNVT,
                         Điện_thoại = p.dienthoaiNVT,

                         Tài_khoản_ngân_hàng_số = p.sotaikhoannganhangNVT,
                         Tại_ngân_hàng = p.diachinganhangNVT,

                         ID = p.id,
                     };

            //    grviewlisttk.DataSource = rs;







            return rs;




        }

        public static void themmoiNVT(int v1, int v2)
        {

            View.NPDanhsachnhavantai p = new NPDanhsachnhavantai(3, -1);  // 3 là thêm ới

            p.ShowDialog();

            //   throw new NotImplementedException();
        }

        public static void suathongtinNVT(int idtk)
        {


            View.NPDanhsachnhavantai p = new NPDanhsachnhavantai(4, idtk);  // 3 là thêm ới

            p.ShowDialog();



            //   throw new NotImplementedException();
        }

        public static IQueryable danhsachxe(LinqtoSQLDataContext dc)
        {
            // throw new NotImplementedException();


            LinqtoSQLDataContext db = dc;
            var rs = from p in db.tbl_NP_danhsachxes
                     orderby p.maNVT
                     select new
                     {


                         Mã_nhà_vận_tải = p.maNVT,
                         Biển_số = p.bienso,
                         Tên_lái_xe = p.tenlaixe,
                         Số_hứng_minh_thư = p.cmtlaixe,
                         Điện_thoại = p.dienthoailaixe,
                         Tải_trọng = p.sotantai,
                         Kích_thước_thùng = p.sokhoithungxe,

                         ID = p.id,
                     };

            //    grviewlisttk.DataSource = rs;







            return rs;



        }

        public static void themmoixetai(int manghiepvu, int id)
        {
            // throw new NotImplementedException();

            View.NPdanhsachxe p = new NPdanhsachxe(3, -1);  // 3 là thêm ới

            p.ShowDialog();


        }

        public static void suathongtinxe(int id)
        {
            View.NPdanhsachxe p = new NPdanhsachxe(4, id);  // 3 là thêm ới

            p.ShowDialog();
        }

        public static IQueryable danhsachkhachhangvantai(LinqtoSQLDataContext dc)
        {

            LinqtoSQLDataContext db = dc;
            var rs = from p in db.tbl_NP_khachhangvanchuyens
                     orderby p.maKH
                     select new
                     {


                         Mã_khách_hàng = p.maKH,
                         Tên_khách_hàng = p.tenKH,
                         Địa_chỉ_khách_hàng = p.diachiKH,
                         Mã_số_thuế = p.masothueKH,
                         Số_tài_khoản_ngân_hàng = p.sotaikhoannganhangKH,

                         Tại_ngân_hàng = p.diachinganhangKH,


                         ID = p.id,
                     };

            //    grviewlisttk.DataSource = rs;







            return rs;





            //   throw new NotImplementedException();
        }

        public static void themmoikhachhangvantai()
        {


            View.NPDanhsackhachhangvantai p = new NPDanhsackhachhangvantai(3, -1);  // 3 là thêm ới

            p.ShowDialog();




            // throw new NotImplementedException();
        }

      

        public static void suadanhsachkhachhangvantai(int idtk)
        {



            View.NPDanhsackhachhangvantai p = new NPDanhsackhachhangvantai(4, idtk);  // 4 là sua

            p.ShowDialog();






            // throw new NotImplementedException();
        }
    }
}

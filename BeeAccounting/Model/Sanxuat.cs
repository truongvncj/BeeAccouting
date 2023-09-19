using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.Model
{
    class Sanxuat
    {


        public static IQueryable Danhsachnhanmay(LinqtoSQLDataContext dc)
        {


            LinqtoSQLDataContext db = dc;


            var rs = from p in dc.tbl_sx_dsnhamays
                     select new
                     {
                         ID = p.id,
                         Mã_nhà_máy = p.maNhamay,
                         Tên_nhà_máy = p.tenNhamay,
                         Thông_tin = p.ghichu,
                        
                         
                     };





            return rs;





        }

        public static IQueryable Danhsachphanxuongsx(LinqtoSQLDataContext dc)
        {


            LinqtoSQLDataContext db = dc;


            var rs = from p in dc.tbl_sx_dsphanxuongs
                     select new
                     {
                         ID = p.id,
                         Mã_nhà_máy = p.manhamay,
                         Mã_nhà_phân_xưởng = p.maphanxuong,
                         Tên_phân_xưởng = p.tenphanxuong,
                         Thông_tin = p.ghichu,


                     };





            return rs;





        }

        public static IQueryable Danhsachsanphamsx(LinqtoSQLDataContext dc)
        {


            LinqtoSQLDataContext db = dc;


            var rs = from p in dc.tbl_sx_sanphams
                    
                     select new
                     {
                         ID = p.id,
                         Mã_sản_phẩm = p.masp,
                         Tên_sản_phẩm = p.tensp,
                         Đơn_vị_tính = p.donvi,
                         PP_tính_giá_SP_dở_dang_cuối_kỳ = p.PPspdodang,
                         PP_tính_giá_sản_phẩm = p.PPtinhgiasx,
                         Tại_nhà_máy=p.manhamay,
                         Tại_phân_xưởng = p.maphanxuong,
                      


                     };





            return rs;





        }





    }
}

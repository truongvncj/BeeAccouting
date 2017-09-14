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
                         Tên_ngân_hàng =p.tennganhang,
                         Ghi_chú= p.ghichunganhnghe,
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



    }
}

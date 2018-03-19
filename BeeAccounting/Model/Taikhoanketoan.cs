using BEEACCOUNT.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.Model
{
    class Taikhoanketoan
    {
        public IQueryable Danhsach { get; set; }
        
        public static IQueryable danhsachtaikhoan(LinqtoSQLDataContext dc)
        {




            //// string connection_string = Utils.getConnectionstr();

            //   LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext db = dc;
              var rs = from tbl_dstaikhoan in db.tbl_dstaikhoans
                     orderby tbl_dstaikhoan.matk, tbl_dstaikhoan.matktren
                     select new {


                         Mã_tài_khoản = tbl_dstaikhoan.matk,
                         Tên_tài_khoản= tbl_dstaikhoan.tentk,
                    //     Loại_tài_khoản = tbl_dstaikhoan.loaitkid,
                         Mã_tài_khoản_cấp_trên =  tbl_dstaikhoan.matktren,
                         Cấp_tài_khoản =  tbl_dstaikhoan.captk,
                         Theo_dõi_chi_tiết =  tbl_dstaikhoan.loaichitiet,
                         Dư_Nợ_đầu_kỳ = tbl_dstaikhoan.nodk,
                         Dư_Có_đầu_kỳ = tbl_dstaikhoan.codk,
                         ID = tbl_dstaikhoan.id,
                     };

        //    grviewlisttk.DataSource = rs;







            return rs;





        }

        public static void themmoitaikhoan()
        {

            View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(3, "");

            createacc.ShowDialog();
            bool chitiettheodoi = createacc.tkchitiet;
            bool chon = createacc.chon;
            string tentk = createacc.tentk;

            string matk = createacc.matk;
            int captk = createacc.captk;
            string tkcaptren = createacc.tkcaptren;
            string loaitk = createacc.loaitk;
            float nodk = createacc.nodauky;
            float codk = createacc.codauky;


            if (chon)
            {
                string connection_string = Utils.getConnectionstr();
                // string urs = Utils.getusername();
                //  var db = new LinqtoSQLDataContext(connection_string);
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                tbl_dstaikhoan tk = new tbl_dstaikhoan();

                tk.matk = matk;
                tk.tentk = tentk;
                tk.loaitkid = loaitk;
                tk.captk = captk;
                tk.matktren = tkcaptren;
                tk.loaichitiet = chitiettheodoi;
                tk.nodk = nodk;
                tk.codk = codk;

                db.tbl_dstaikhoans.InsertOnSubmit(tk);
                db.SubmitChanges();

                //    MeasureItemEventArgs.re
            //    var rs = Model.Taikhoanketoan.danhsachtaikhoan();
              //  dataGridView1.DataSource = rs;


            }




        }

        public static void suataikhoan(string matk)
        {

          //  string taikhoan = rs.matk;

            View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(4, matk); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa

            createacc.ShowDialog();


        }



        public static void ghisocaitk(tbl_Socai socai)
        {
            //  string username, string tkno, string tkco, float psno, float psco, string diengiai, string manghiepvu, int sochunngtu, DateTime ngaychungtu, DateTime ngayghiso

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            tbl_Socai socaips = new tbl_Socai();

            socaips.TkNo = socai.TkNo;
            socaips.MaCTietTKCo = socai.MaCTietTKCo;
            socaips.MaCTietTKNo = socai.MaCTietTKNo;
            socaips.tenchitietNo = socai.tenchitietNo;
            socaips.tenchitietCo = socai.tenchitietCo;

            socaips.TkCo = socai.TkCo;
            socaips.PsCo = socai.PsCo;
            socaips.PsNo = socai.PsNo;
            socaips.Diengiai = socai.Diengiai;
            socaips.manghiepvu = socai.manghiepvu;
            socaips.manghiepvu = socai.manghiepvu;
      
            socaips.Ngayghiso = socai.Ngayghiso;
            socaips.username = socai.username;
       

            socaips.Sohieuchungtu = socai.Sohieuchungtu;
            socaips.Ngayctu = socai.Ngayctu;
          //  socaips.Soctu = socai.Soctu;

            // socaips.Soctu = socai.Soctu;
            // socaips.Soctu = socai.Soctu;

            db.tbl_Socais.InsertOnSubmit(socaips);
            db.SubmitChanges();
        }
    }
}

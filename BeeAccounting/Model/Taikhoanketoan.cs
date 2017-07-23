﻿using BEEACCOUNT.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.Model
{
    class Taikhoanketoan
    {
        public IQueryable Danhsach { get; set; }
        
        public static IQueryable danhsachtaikhoan()
        {




            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);
            var rs = from tbl_dstaikhoan in db.tbl_dstaikhoans
                     orderby tbl_dstaikhoan.matk, tbl_dstaikhoan.matktren
                     select new {


                         Mã_tài_khoản = tbl_dstaikhoan.matk,
                         Tên_tài_khoản= tbl_dstaikhoan.tentk,
                         Loại_tài_khoản = tbl_dstaikhoan.loaitkid,
                         Mã_tài_khoản_cấp_trên =  tbl_dstaikhoan.matktren,
                         Cấp_tài_khoản =  tbl_dstaikhoan.captk,
                         Theo_dõi_chi_tiết =  tbl_dstaikhoan.loaichitiet,
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
            int loaitk = createacc.loaitk;



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

                db.tbl_dstaikhoans.InsertOnSubmit(tk);
                db.SubmitChanges();

                //    MeasureItemEventArgs.re
            //    var rs = Model.Taikhoanketoan.danhsachtaikhoan();
              //  dataGridView1.DataSource = rs;


            }




        }
    }
}
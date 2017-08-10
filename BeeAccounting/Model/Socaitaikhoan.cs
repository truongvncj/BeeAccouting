using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.Model
{
    class Socaitaikhoan
    {

        public static void xoa(string manghiepvu, int sochungtu) // vd phieu thu nghiep vu là phieu thu: PT,
        {
            if ( manghiepvu !="")
            {
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = from tbl_Socai in dc.tbl_Socais
                         where tbl_Socai.manghiepvu == manghiepvu
                         && tbl_Socai.nghiepvuso == sochungtu
                         select tbl_Socai;



                dc.tbl_Socais.DeleteAllOnSubmit(rs);
                dc.SubmitChanges();
            }
         


        }


        
          

        public static void ghibuttoan(string matk, string manghiepvu, string sochungtu) // vd phieu thu nghiep vu là phieu thu: PT,
        {




        }
     


    }
}

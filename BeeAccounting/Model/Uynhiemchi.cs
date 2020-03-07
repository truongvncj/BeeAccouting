using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.Model
{
    class Uynhiemchi
    {

        public static IQueryable reloadseachview(string loaiphieu, string nguoinop, string diachi, string noidung)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //      nguoinop, diachi, noidung

            var Listphieuthu = from listpt in dc.tbl_SoQuys
                               where listpt.Machungtu == loaiphieu    // mã 8 là tiền mặt
                                                                      //     ((int)tbl_KaCustomer.Customer).ToString().Contains(valueinput)
                      && listpt.Nguoinopnhantien.Contains(nguoinop)
                      && listpt.Diachinguoinhannop.Contains(diachi)
                      && listpt.Diengiai.Contains(noidung)
                               select new
                               {

                                   Ngày_chứng_từ = listpt.Ngayctu,
                                   Số_chứng_từ = listpt.Sophieu,
                                   Nợ_TK = listpt.TKtienmat,
                                   Có_TK = listpt.TKdoiung,
                                   Số_Tiền = listpt.PsNo,
                                   Diễn_Giải = listpt.Diengiai,
                                   Người_nộp_tiền = listpt.Nguoinopnhantien,
                                   Địa_chỉ_người_nộp_tiền = listpt.Diachinguoinhannop,
                                   User_name = listpt.Username,
                                   Ngày_nhập_liệu = listpt.Ngayghiso,
                                   ID = listpt.id

                               };

            return Listphieuthu;
        }




    }
}

using BEEACCOUNT.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BEEACCOUNT.Model
{



    class formatBCTC
    {






        public static IQueryable LisDanhSachLCTTformat()
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region load list danh sach format
            var listformatbctc = from p in dc.LCTTTT200formats
                                 select new
                                 {

                                     Mã_chỉ_tiêu = p.machitieu,
                                     Cách_tính = p.cachtinh
                                   
                                 };



                                 
                                 

                            
            return listformatbctc;
            //     dataGridViewListphieuthu.DataSource = Listphieuthu;
            #endregion
        }

        public static IQueryable LisDanhSachformat()
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region load list danh sach format
            var listformatbctc = from p in dc.CDKT200formats
                                 select new
                                 {

                                     Mã_chỉ_tiêu = p.machitieu,
                                     Cách_tính = p.cachtinh
                                   
                                 };



                                 
                                 

                            
            return listformatbctc;
            //     dataGridViewListphieuthu.DataSource = Listphieuthu;
            #endregion
        }


        public static IQueryable LisDanhSachKQKDformat()
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region load list danh sach format
            var listformatbctc = from p in dc.KQKD200formats
                                 select new
                                 {

                                     Mã_chỉ_tiêu = p.machitieu,
                                     Cách_tính = p.cachtinh

                                 };







            return listformatbctc;
            //     dataGridViewListphieuthu.DataSource = Listphieuthu;
            #endregion
        }




    }
}

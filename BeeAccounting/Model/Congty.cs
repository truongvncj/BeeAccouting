using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.Model
{
    class Congty
    {
        public static string getnamecongty(string macty)
        {
          //  string username = Utils.getusername();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = (from tbl_congty in dc.tbl_congties
                     where tbl_congty.macty == macty

                      select tbl_congty.tencongty).FirstOrDefault();
            if (rs == null)
            {
                return "";
            }
            else
            {

                return rs.ToString();
            }

        }
        public static string getmasothuecongty(string macty)
        {
          //  string username = Utils.getusername();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = (from tbl_congty in dc.tbl_congties
                          where tbl_congty.macty == macty

                      select tbl_congty.Masothue).FirstOrDefault();
            if (rs == null)
            {
                return "";
            }
            else
            {

                return rs.ToString();
            }

        }

        public static string getdiachicongty(string macty)
        {
            //  string username = Utils.getusername();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = (from tbl_congty in dc.tbl_congties
                         where  tbl_congty.macty == macty

                      select tbl_congty.diachicoty).FirstOrDefault();
            if (rs == null)
            {
                return "";
            }
            else
            {

                return rs.ToString();
            }

        }

        public static string gettengiamdoccongty(string macty)
        {
            //  string username = Utils.getusername();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = (from tbl_congty in dc.tbl_congties
                             where tbl_congty.macty == macty

                      select tbl_congty.tengiamdoc).FirstOrDefault();
            if (rs == null)
            {
                return "";
            }
            else
            {

                return rs.ToString();
            }

        }
        public static string gettenketoantruongcongty(string macty)
        {
            //  string username = Utils.getusername();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            var rs = (from tbl_congty in dc.tbl_congties
                          where tbl_congty.macty == macty

                      select tbl_congty.tenketoantruong).FirstOrDefault();
            if (rs == null)
            {
                return "";
            }
            else
            {

                return rs.ToString();
            }

        }



    }
}

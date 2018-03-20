using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEEACCOUNT.Model
{





    class Username
    {

        public string Name { get; set; }
        public Boolean right { get; set; }
        public int Version { get; set; }
        public bool phanquyen { get; set; }
        public Boolean inputcontractconfirm { get; set; }
        public Boolean paymentdisplay { get; set; }
        public Boolean paymentcreate { get; set; }
        public Boolean saleupdate { get; set; }
        public Boolean saleview { get; set; }
        public Boolean saledeleted { get; set; }
        public Boolean salechange { get; set; }
        public Boolean reports { get; set; }
        public Boolean masterdata { get; set; }
        public Boolean masterbegin { get; set; }

        public Boolean userssetup { get; set; }
        public Boolean pricingcheckview { get; set; }

        public Boolean pricingcheckupdate { get; set; }

        public Boolean inputcontractfinalcontrol { get; set; }

        public Boolean masterdatafuction { get; set; }

        public Boolean changeitem { get; set; }

        public Boolean btaddnewItem { get; set; }

        public Username()
        {

            string Name = Utils.getusername();




        }
        //  public int Version { get; set; }

        public static int getVersion()
        {

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            int rs = (int)(from tbl_Temp in dc.tbl_Temps
                             select tbl_Temp.Version).FirstOrDefault();





            return rs;



        }



        public static bool getphanquyen()
        {



            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rs = (from tbl_Temp in dc.tbl_Temps
                             select tbl_Temp.Phân_quyền).FirstOrDefault();




            if (rs != null)
            {
                return (bool)rs;
            }
            else
            {
                return false;
            }
        




        }



    }















}

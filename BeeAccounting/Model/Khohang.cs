using BEEACCOUNT.Control;
using BEEACCOUNT.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BEEACCOUNT.Model
{
    class Khohang
    {


        public static IQueryable Danhsachkho(LinqtoSQLDataContext dc)
        {


            LinqtoSQLDataContext db = dc;


            var rs = from p in dc.tbl_khohangs
                     select new
                     {

                         Mã_kho = p.makho,
                         Tên_kho = p.tenkho,
                         Địa_chỉ = p.diachikho,

                         ID = p.id
                     };





            return rs;





        }

        public static void themmoikhohang()
        {
            View.BeeDanhsachkho p = new BeeDanhsachkho(3, -1);  // 3 là thêm ới/ 4 là sửa xóa
                                                                //  View.BeeDanhsachkho p = new View.BeeDanhsachkho
            p.ShowDialog();






            // throw new NotImplementedException();
        }

        public static void suaxoadanhsachkho(int iddanhscahkho)
        {




            View.BeeDanhsachkho p = new BeeDanhsachkho(4, iddanhscahkho);  // 3 là thêm ới/ 4 là sửa xóa
                                                                           //  View.BeeDanhsachkho p = new View.BeeDanhsachkho
            p.ShowDialog();





            //  throw new NotImplementedException();
        }

        public static IQueryable danhsachnhomsanpham(LinqtoSQLDataContext dc)
        {



            LinqtoSQLDataContext db = dc;


            var rs = from p in dc.tbl_kho_nhomsanphams
                     select new
                     {

                         Mã_nhóm = p.manhomsanpham,
                         Tên_nhóm_sản_phẩm = p.tennhomsanpham,


                         ID = p.id
                     };





            return rs;










            //  throw new NotImplementedException();
        }

        public static void themmoinhomsanpham()
        {

            View.BeeDanhsachnhomsanpham p = new BeeDanhsachnhomsanpham(3, -1);  // 3 là thêm ới/ 4 là sửa xóa
                                                                                //  View.BeeDanhsachkho p = new View.BeeDanhsachkho
            p.ShowDialog();







            //throw new NotImplementedException();
        }

        public static void suanhomsanpham(int idtk)
        {


            View.BeeDanhsachnhomsanpham p = new BeeDanhsachnhomsanpham(4, idtk);  // 3 là thêm ới/ 4 là sửa xóa
                                                                                  //  View.BeeDanhsachkho p = new View.BeeDanhsachkho
            p.ShowDialog();



            //throw new NotImplementedException();
        }

        public static IQueryable danhsachsanpham(LinqtoSQLDataContext dc)
        {


            LinqtoSQLDataContext db = dc;


            var rs = from p in dc.tbl_kho_sanphams
                     select new
                     {

                         Mã_sản_phẩm = p.masp,
                         Tên_sản_phẩm = p.tensp,
                         Mã_vạch = p.mavach,
                         Đơn_vị = p.donvi,
                         KHối_lượng = p.khoiluong,
                         Trọng_lượng = p.trongluong,
                         Mã_nhóm_sản_phẩm = p.idmanhomsp,
                         Ghi_chú = p.ghichu,



                         ID = p.id
                     };





            return rs;






            //    throw new NotImplementedException();
        }

        public static void themmoisanpham()
        {

            View.BeeDanhsachsanpham p = new BeeDanhsachsanpham(3, -1);  // 3 là thêm ới/ 4 là sửa xóa
                                                                        //  View.BeeDanhsachkho p = new View.BeeDanhsachkho
            p.ShowDialog();





            //  throw new NotImplementedException();
        }

        public static void suasanpham(int idtk)
        {

            View.BeeDanhsachsanpham p = new BeeDanhsachsanpham(4, idtk);  // 3 là thêm ới/ 4 là sửa xóa
                                                                        //  View.BeeDanhsachkho p = new View.BeeDanhsachkho
            p.ShowDialog();

            //  throw new NotImplementedException();
        }

        public static IQueryable danhsachphieunhapkho(LinqtoSQLDataContext dc)
        {


            LinqtoSQLDataContext db = dc;


            var rs = from p in dc.tbl_kho_phieunhap_heads

                     select new
                     {

                         Ngày_phiếu_nhập = p.ngayphieunhap,
                         Mã_kho = p.makho,
                         Số_phiếu = p.sophieu,
                         Người_giao = p.nguoigiao,
                         Địa_chỉ = p.diachibophan,
                         Có_TK = p.cotk,
                         Nợ_TK = p.notk,
                         Tạo_bởi = p.createby,



                         ID = p.id
                     };





            return rs;


            // throw new NotImplementedException();
        }

        public static  DataGridView reloaddetailnewPNK(DataGridView dataGridViewdetailPNK)
        {



            dataGridViewdetailPNK.DataSource = null;
            #region datatable temp




            DataTable dt = new DataTable();



            //   dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DGV_DateTimePicker.DateTimePickerCell)));
            dt.Columns.Add(new DataColumn("Mã_sản_phẩm", typeof(string)));
            dt.Columns.Add(new DataColumn("Tên_sản_phẩm", typeof(string)));

            dt.Columns.Add(new DataColumn("Đơn_vị", typeof(string)));
            dt.Columns.Add(new DataColumn("Số_lượng_nhập", typeof(string)));

            //Threahold
            //      dt.Columns.Add(new DataColumn("Tk_Có", typeof(double)));
            dt.Columns.Add(new DataColumn("Đơn_giá", typeof(double)));
            dt.Columns.Add(new DataColumn("Thành_tiền", typeof(double)));
            dt.Columns.Add(new DataColumn("tkidhide", typeof(string))); //comnoxxon
          //  dt.Columns.Add(new DataColumn("Tk_Có", typeof(double)));
            //    dt.Columns.Add(new DataColumn("ngayctuhide", typeof(DateTime))); //adding column for combobox





            dataGridViewdetailPNK.DataSource = dt;


            //DGV_DateTimePicker.DateTimePickerColumn col = new DGV_DateTimePicker.DateTimePickerColumn();
            //col.HeaderText = "Ngày chứng từ";
            //col.Name = "Ngày_chứng_từ";
            //col.DataPropertyName = "ngayctuhide";
            //dataGridViewdetailPNK.Columns.Add(col);


            //    dataGridViewTkCo.Columns.Remove("Tk_Có");

            #region  //    bindDataToDataGridViewComboPrograme(); Tk_No
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();


            List<View.BeePhieuchi.ComboboxItem> CombomCollection = new List<View.BeePhieuchi.ComboboxItem>();

            //var rs = from tbl_dstaikhoan in dc.tbl_dstaikhoans
                    
            //         orderby tbl_dstaikhoan.matk
            //         select tbl_dstaikhoan;
            //foreach (var item in rs)
            //{
            //    View.BeePhieuchi.ComboboxItem cb = new View.BeePhieuchi.ComboboxItem();
            //    cb.Value = item.matk.Trim();
            //    cb.Text = item.matk.Trim() + ": " + item.tentk;
            //    CombomCollection.Add(cb);
            //}

            //cmbdgv.DataSource = CombomCollection;
            //cmbdgv.HeaderText = "Tk_Có";
            //cmbdgv.Name = "Tk_Có";
            //cmbdgv.ValueMember = "Value";
            //cmbdgv.DisplayMember = "Text";
            //cmbdgv.Width = 100;
            //cmbdgv.DropDownWidth = 300;
            //cmbdgv.DataPropertyName = "tkidhide"; //Bound value to the datasource


            dataGridViewdetailPNK.Columns.Add(cmbdgv);





            #endregion binddata


        //    dataGridViewdetailPNK.Columns["Tk_Có"].Visible = false;
           dataGridViewdetailPNK.Columns["tkidhide"].Visible = false;

       //     dataGridViewdetailPNK.Columns["Tk_Nợ"].DisplayIndex = 0;
        //    dataGridViewdetailPNK.Columns["Tk_Nợ"].Width = 100;
        //    dataGridViewdetailPNK.Columns["Tk_Nợ"].SortMode = DataGridViewColumnSortMode.NotSortable;

            //dataGridViewdetailPNK.Columns["Mã_chi_tiết"].DisplayIndex = 1;
            //dataGridViewdetailPNK.Columns["Mã_chi_tiết"].Width = 100;
            //dataGridViewdetailPNK.Columns["Mã_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridViewdetailPNK.Columns["Mã_chi_tiết"].ReadOnly = true;
            //dataGridViewdetailPNK.Columns["Mã_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;

            //dataGridViewdetailPNK.Columns["Tên_chi_tiết"].DisplayIndex = 2;
            //dataGridViewdetailPNK.Columns["Tên_chi_tiết"].Width = 200;
            //dataGridViewdetailPNK.Columns["Tên_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridViewdetailPNK.Columns["Tên_chi_tiết"].ReadOnly = true;
            //dataGridViewdetailPNK.Columns["Tên_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;


            //dataGridViewdetailPNK.Columns["Số_tiền"].DisplayIndex = 3;
            //dataGridViewdetailPNK.Columns["Số_tiền"].Width = 100;
            //dataGridViewdetailPNK.Columns["Số_tiền"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridViewdetailPNK.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";


            //dataGridViewdetailPNK.Columns["Diễn_giải"].DisplayIndex = 4;
            //dataGridViewdetailPNK.Columns["Diễn_giải"].Width = 300;
            //dataGridViewdetailPNK.Columns["Diễn_giải"].SortMode = DataGridViewColumnSortMode.NotSortable;


            //dataGridViewdetailPNK.Columns["Ký_hiêu"].DisplayIndex = 5;
            //dataGridViewdetailPNK.Columns["Ký_hiêu"].Width = 100;
            //dataGridViewdetailPNK.Columns["Ký_hiêu"].SortMode = DataGridViewColumnSortMode.NotSortable;


            //dataGridViewdetailPNK.Columns["Ngày_chứng_từ"].DisplayIndex = 6;
            //dataGridViewdetailPNK.Columns["Ngày_chứng_từ"].Width = 100;
            //dataGridViewdetailPNK.Columns["Ngày_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;


            //dataGridViewdetailPNK.Columns["Số_chứng_từ"].DisplayIndex = 7;
            //dataGridViewdetailPNK.Columns["Số_chứng_từ"].Width = 200;
            //dataGridViewdetailPNK.Columns["Số_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;






            #endregion datatable temp


            return dataGridViewdetailPNK;





            //  throw new NotImplementedException();
        }
    }
}

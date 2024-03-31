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



    class Phieuthuchi
    {





        public static IQueryable LisDanhSachphieuthu(String Loaiphieu, string thang, string nam)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region load list phieu thu
            var Listphieuthu = from listpt in dc.tbl_SoQuys
                               where listpt.Machungtu == Loaiphieu
                                    && listpt.Ngayctu.Month.ToString() == thang
                           && listpt.Ngayctu.Year.ToString() == nam


                               // mã 8 là tiền mặt loai"PT" là phiếu thu/ pc là phieu chi
                               select new
                               {

                                   Ngày_chứng_từ = listpt.Ngayctu,
                                   Số_chứng_từ = listpt.Sophieu,
                                   TK_Nợ = listpt.TKtienmat,
                                   TK_Có = listpt.TKdoiung,
                                   Số_Tiền = listpt.PsNo,
                                   Diễn_Giải = listpt.Diengiai,
                                   Người_nộp = listpt.Nguoinopnhantien,
                                   Địa_chỉ = listpt.Diachinguoinhannop,
                                   Username = listpt.Username,
                                   Ngày_nhập_liệu = listpt.Ngayghiso,
                                   ID = listpt.id

                               };
            return Listphieuthu;
            //     dataGridViewListphieuthu.DataSource = Listphieuthu;
            #endregion
        }

        public static int xoaPhieu(String Loaiphieu, string sophieu)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region load list phieu thu
            var Listphieuthu = from p in dc.tbl_SoQuys
                               where p.Machungtu == Loaiphieu
                                    && p.Sophieu == sophieu
                      

                           
                               select p;

            dc.tbl_SoQuys.DeleteAllOnSubmit(Listphieuthu);
            dc.SubmitChanges();
            
            return 1;
            //     dataGridViewListphieuthu.DataSource = Listphieuthu;
            #endregion
        }

        

        public static IQueryable LisDanhSachphieuchi(String Loaiphieu, string thang, string nam)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region load list phieu thu
            var Listphieuthu = from listpt in dc.tbl_SoQuys
                               where listpt.Machungtu == Loaiphieu
                           && listpt.Ngayctu.Month.ToString() == thang
                           && listpt.Ngayctu.Year.ToString() == nam
                               select new
                               {
                                   Ngày_chứng_từ = listpt.Ngayctu,
                                   Số_chứng_từ = listpt.Sophieu,
                                   Nợ_TK = listpt.TKtienmat,
                                   TK_Có = listpt.TKdoiung,
                                   Số_Tiền = listpt.PsNo,
                                   Diễn_Giải = listpt.Diengiai,
                                   Người_nộp = listpt.Nguoinopnhantien,
                                   Địa_chỉ = listpt.Diachinguoinhannop,
                                   Username = listpt.Username,
                                   Ngày_nhập_liệu = listpt.Ngayghiso,
                                   ID = listpt.id

                               };
            return Listphieuthu;
            //     dataGridViewListphieuthu.DataSource = Listphieuthu;
            #endregion


        }


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


        
        public static DataGridView reloadnewdetailphieuthu(DataGridView dataGridViewTkNo)
        {

            dataGridViewTkNo.DataSource = null;
            #region datatable temp




            DataTable dt = new DataTable();



            //   dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DGV_DateTimePicker.DateTimePickerCell)));
            dt.Columns.Add(new DataColumn("Mã_chi_tiết", typeof(string)));
            dt.Columns.Add(new DataColumn("Tên_chi_tiết", typeof(string)));

            dt.Columns.Add(new DataColumn("Số_tiền", typeof(double)));
            dt.Columns.Add(new DataColumn("Diễn_giải", typeof(string)));

            //Threahold
            dt.Columns.Add(new DataColumn("Có_TK", typeof(string)));
            //      dt.Columns.Add(new DataColumn("Ký_hiêu", typeof(string)));
            //    dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(int)));
            dt.Columns.Add(new DataColumn("tkCohide", typeof(string))); //comnoxxon

            //  dt.Columns.Add(new DataColumn("ngayctuhide", typeof(DateTime))); //adding column for combobox





            dataGridViewTkNo.DataSource = dt;




            dataGridViewTkNo.Columns["tkCohide"].Visible = false;
            //    dataGridViewTkNo.Columns["ngayctuhide"].Visible = false;

            dataGridViewTkNo.Columns["Có_TK"].DisplayIndex = 0;
            dataGridViewTkNo.Columns["Có_TK"].Width = 100;
            dataGridViewTkNo.Columns["Có_TK"].ReadOnly = true;
            dataGridViewTkNo.Columns["Có_TK"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkNo.Columns["Có_TK"].DefaultCellStyle.BackColor = Color.LightGray;

            dataGridViewTkNo.Columns["Mã_chi_tiết"].DisplayIndex = 1;
            dataGridViewTkNo.Columns["Mã_chi_tiết"].Width = 100;
            dataGridViewTkNo.Columns["Mã_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkNo.Columns["Mã_chi_tiết"].ReadOnly = true;
            dataGridViewTkNo.Columns["Mã_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;

            dataGridViewTkNo.Columns["Tên_chi_tiết"].DisplayIndex = 2;
            dataGridViewTkNo.Columns["Tên_chi_tiết"].Width = 200;
            dataGridViewTkNo.Columns["Tên_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkNo.Columns["Tên_chi_tiết"].ReadOnly = true;
            dataGridViewTkNo.Columns["Tên_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;


            dataGridViewTkNo.Columns["Số_tiền"].DisplayIndex = 3;
            dataGridViewTkNo.Columns["Số_tiền"].Width = 100;
            dataGridViewTkNo.Columns["Số_tiền"].ReadOnly = true;
            dataGridViewTkNo.Columns["Số_tiền"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkNo.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";
            dataGridViewTkNo.Columns["Số_tiền"].DefaultCellStyle.BackColor = Color.LightGray;


            dataGridViewTkNo.Columns["Diễn_giải"].DisplayIndex = 4;
            dataGridViewTkNo.Columns["Diễn_giải"].Width = 300;
            dataGridViewTkNo.Columns["Diễn_giải"].ReadOnly = true;
            dataGridViewTkNo.Columns["Diễn_giải"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkNo.Columns["Diễn_giải"].DefaultCellStyle.BackColor = Color.LightGray;


            //dataGridViewTkNo.Columns["Ký_hiêu"].DisplayIndex = 5;
            //dataGridViewTkNo.Columns["Ký_hiêu"].Width = 100;
            //dataGridViewTkNo.Columns["Ký_hiêu"].SortMode = DataGridViewColumnSortMode.NotSortable;


            //dataGridViewTkNo.Columns["Ngày_chứng_từ"].DisplayIndex = 6;
            //dataGridViewTkNo.Columns["Ngày_chứng_từ"].Width = 100;
            //dataGridViewTkNo.Columns["Ngày_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;


            //dataGridViewTkNo.Columns["Số_chứng_từ"].DisplayIndex = 7;
            //dataGridViewTkNo.Columns["Số_chứng_từ"].Width = 200;
            //dataGridViewTkNo.Columns["Số_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;






            #endregion datatable temp


            return dataGridViewTkNo;


        }

        public static DataGridView reloadnewdetailphieuchi(DataGridView dataGridViewTkNo)
        {

            dataGridViewTkNo.DataSource = null;
            #region datatable temp




            DataTable dt = new DataTable();



            //   dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DGV_DateTimePicker.DateTimePickerCell)));
            dt.Columns.Add(new DataColumn("Mã_chi_tiết", typeof(string)));
            dt.Columns.Add(new DataColumn("Tên_chi_tiết", typeof(string)));

            dt.Columns.Add(new DataColumn("Số_tiền", typeof(double)));
            dt.Columns.Add(new DataColumn("Diễn_giải", typeof(string)));

            //Threahold
            dt.Columns.Add(new DataColumn("Nợ_TK", typeof(string)));
            //      dt.Columns.Add(new DataColumn("Ký_hiêu", typeof(string)));
            //    dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(int)));
            dt.Columns.Add(new DataColumn("tkNohide", typeof(string))); //comnoxxon

            //  dt.Columns.Add(new DataColumn("ngayctuhide", typeof(DateTime))); //adding column for combobox





            dataGridViewTkNo.DataSource = dt;


            //DGV_DateTimePicker.DateTimePickerColumn col = new DGV_DateTimePicker.DateTimePickerColumn();
            //col.HeaderText = "Ngày chứng từ";
            //col.Name = "Ngày_chứng_từ";
            //col.DataPropertyName = "ngayctuhide";
            //dataGridViewTkNo.Columns.Add(col);


            //    dataGridViewTkCo.Columns.Remove("Tk_Có");

            //#region  //    bindDataToDataGridViewComboPrograme(); Tk_No
            //string connection_string = Utils.getConnectionstr();
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            //DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();


            //List<View.BeePhieuchi.ComboboxItem> CombomCollection = new List<View.BeePhieuchi.ComboboxItem>();

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
            //cmbdgv.HeaderText = "Tk_Nợ";
            //cmbdgv.Name = "Tk_Nợ";
            //cmbdgv.ValueMember = "Value";
            //cmbdgv.DisplayMember = "Text";
            //cmbdgv.Width = 100;
            //cmbdgv.DropDownWidth = 300;
            //cmbdgv.DataPropertyName = "tkNohide"; //Bound value to the datasource


            //dataGridViewTkNo.Columns.Add(cmbdgv);





            //#endregion binddata


            dataGridViewTkNo.Columns["tkNohide"].Visible = false;
            //    dataGridViewTkNo.Columns["ngayctuhide"].Visible = false;

            dataGridViewTkNo.Columns["Nợ_TK"].DisplayIndex = 0;
            dataGridViewTkNo.Columns["Nợ_TK"].Width = 100;
            dataGridViewTkNo.Columns["Nợ_TK"].ReadOnly = true;
            dataGridViewTkNo.Columns["Nợ_TK"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkNo.Columns["Nợ_TK"].DefaultCellStyle.BackColor = Color.LightGray;

            dataGridViewTkNo.Columns["Mã_chi_tiết"].DisplayIndex = 1;
            dataGridViewTkNo.Columns["Mã_chi_tiết"].Width = 100;
            dataGridViewTkNo.Columns["Mã_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkNo.Columns["Mã_chi_tiết"].ReadOnly = true;
            dataGridViewTkNo.Columns["Mã_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;

            dataGridViewTkNo.Columns["Tên_chi_tiết"].DisplayIndex = 2;
            dataGridViewTkNo.Columns["Tên_chi_tiết"].Width = 200;
            dataGridViewTkNo.Columns["Tên_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkNo.Columns["Tên_chi_tiết"].ReadOnly = true;
            dataGridViewTkNo.Columns["Tên_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;


            dataGridViewTkNo.Columns["Số_tiền"].DisplayIndex = 3;
            dataGridViewTkNo.Columns["Số_tiền"].Width = 100;
            dataGridViewTkNo.Columns["Số_tiền"].ReadOnly = true;
            dataGridViewTkNo.Columns["Số_tiền"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkNo.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";
            dataGridViewTkNo.Columns["Số_tiền"].DefaultCellStyle.BackColor = Color.LightGray;


            dataGridViewTkNo.Columns["Diễn_giải"].DisplayIndex = 4;
            dataGridViewTkNo.Columns["Diễn_giải"].Width = 300;
            dataGridViewTkNo.Columns["Diễn_giải"].ReadOnly = true;
            dataGridViewTkNo.Columns["Diễn_giải"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkNo.Columns["Diễn_giải"].DefaultCellStyle.BackColor = Color.LightGray;


            //dataGridViewTkNo.Columns["Ký_hiêu"].DisplayIndex = 5;
            //dataGridViewTkNo.Columns["Ký_hiêu"].Width = 100;
            //dataGridViewTkNo.Columns["Ký_hiêu"].SortMode = DataGridViewColumnSortMode.NotSortable;


            //dataGridViewTkNo.Columns["Ngày_chứng_từ"].DisplayIndex = 6;
            //dataGridViewTkNo.Columns["Ngày_chứng_từ"].Width = 100;
            //dataGridViewTkNo.Columns["Ngày_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;


            //dataGridViewTkNo.Columns["Số_chứng_từ"].DisplayIndex = 7;
            //dataGridViewTkNo.Columns["Số_chứng_từ"].Width = 200;
            //dataGridViewTkNo.Columns["Số_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;






            #endregion datatable temp


            return dataGridViewTkNo;


        }


        public static void reloaddetailtaikhoancophieuthu(DataGridView dataGridViewTkCo, View.BeePhieuThu phieuthu, string taikhoantienmatNo, string Phieuthuso)
        {




            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var socailist = from tbl_Socai in dc.tbl_Socais
                            where tbl_Socai.TkNo.Trim() == taikhoantienmatNo.Trim()
                     && tbl_Socai.manghiepvu == "PT"
                    && tbl_Socai.Sohieuchungtu.Trim() == Phieuthuso.Trim()
                            select tbl_Socai;

            if (socailist.Count() > 0)
            {
                foreach (tbl_Socai socai in socailist)
                {
                    //   MessageBox.Show(socai.Diengiai, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    phieuthu.add_detailGridviewTkCophieuthu(socai);



                }
            }




            //  return dataGridViewTkCo;


        }

        public static void reloaddetailtaikhoannophieuchi(DataGridView dataGridViewTkNo, View.BeePhieuchi phieuchi, string taikhoantienmatco, string Phieuchiso)
        {




            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var socailist = from tbl_Socai in dc.tbl_Socais
                            where tbl_Socai.TkCo.Trim() == taikhoantienmatco.Trim()
                     && tbl_Socai.manghiepvu == "PC"
                    && tbl_Socai.Sohieuchungtu == Phieuchiso
                            select tbl_Socai;


            if (socailist.Count() > 0)
            {
                foreach (tbl_Socai socai in socailist)
                {
                    //   MessageBox.Show(socai.Diengiai, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    phieuchi.add_detailGridviewTkNophieuchi(socai);



                }
            }


            //  return dataGridViewTkCo;


        }

        public static void reloaddetailuynhiemchi(DataGridView dataGridViewTkNo, View.Beeuynhiemchi sophieuuynhiemchi, string taikhoantienmatco, string Phieuchiso)
        {




            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var socailist = from tbl_Socai in dc.tbl_Socais
                            where tbl_Socai.TkCo.Trim() == taikhoantienmatco.Trim()
                     && tbl_Socai.manghiepvu == "UNC"
                    && tbl_Socai.Sohieuchungtu == Phieuchiso
                            select tbl_Socai;


            if (socailist.Count() > 0)
            {
                foreach (tbl_Socai socai in socailist)
                {
                    //   MessageBox.Show(socai.Diengiai, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sophieuuynhiemchi.add_detailGridviewTkNoUNC(socai);



                }
            }


            //  return dataGridViewTkCo;


        }






    }
}

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

        //public class ComboboxItem
        //{
        //    public string Text { get; set; }
        //    public object Value { get; set; }

        //    public override string ToString()
        //    {
        //        return Text;
        //    }
        //}

        public static IQueryable LisDanhSachphieuthuchi(String Loaiphieu)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            #region load list phieu thu
            var Listphieuthu = from listpt in dc.tbl_SoQuys
                               where listpt.Machungtu == Loaiphieu // mã 8 là tiền mặt loai"PT" là phiếu thu/ pc là phieu chi
                               select new
                               {

                                   Ngày_chứng_từ = listpt.Ngayctu,
                                   Số_chứng_từ = listpt.Sochungtu,
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
                                   Số_chứng_từ = listpt.Sochungtu,
                                   TK_Nợ = listpt.TKtienmat,
                                   TK_Có = listpt.TKdoiung,
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


        public static DataGridView reloadnewdetailtaikhoanco(DataGridView dataGridViewTkCo)
        {

            dataGridViewTkCo.DataSource = null;
            #region datatable temp




            DataTable dt = new DataTable();



            //   dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DGV_DateTimePicker.DateTimePickerCell)));
            dt.Columns.Add(new DataColumn("Mã_chi_tiết", typeof(string)));
            dt.Columns.Add(new DataColumn("Tên_chi_tiết", typeof(string)));

            dt.Columns.Add(new DataColumn("Số_tiền", typeof(double)));
            dt.Columns.Add(new DataColumn("Diễn_giải", typeof(string)));

            //Threahold
            //      dt.Columns.Add(new DataColumn("Tk_Có", typeof(double)));
            dt.Columns.Add(new DataColumn("Ký_hiêu", typeof(string)));
            dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(int)));
            dt.Columns.Add(new DataColumn("tkCohide", typeof(string))); //comnoxxon

            dt.Columns.Add(new DataColumn("ngayctuhide", typeof(DateTime))); //adding column for combobox





            dataGridViewTkCo.DataSource = dt;


            DGV_DateTimePicker.DateTimePickerColumn col = new DGV_DateTimePicker.DateTimePickerColumn();
            col.HeaderText = "Ngày chứng từ";
            col.Name = "Ngày_chứng_từ";
            col.DataPropertyName = "ngayctuhide";
            dataGridViewTkCo.Columns.Add(col);


            //    dataGridViewTkCo.Columns.Remove("Tk_Có");

            #region  //    bindDataToDataGridViewComboPrograme(); Tk_Có
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();


            List<View.BeePhieuThu.ComboboxItem> CombomCollection = new List<View.BeePhieuThu.ComboboxItem>();
            var rs = from tbl_dstaikhoan in dc.tbl_dstaikhoans
                     orderby tbl_dstaikhoan.matk
                     select tbl_dstaikhoan;
            foreach (var item in rs)
            {
                View.BeePhieuThu.ComboboxItem cb = new View.BeePhieuThu.ComboboxItem();
                cb.Value = item.matk.Trim();
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                CombomCollection.Add(cb);
            }

            cmbdgv.DataSource = CombomCollection;
            cmbdgv.HeaderText = "Tk_Có";
            cmbdgv.Name = "Tk_Có";
            cmbdgv.ValueMember = "Value";
            cmbdgv.DisplayMember = "Text";
            cmbdgv.Width = 100;
            cmbdgv.DropDownWidth = 300;
            cmbdgv.DataPropertyName = "tkCohide"; //Bound value to the datasource


            dataGridViewTkCo.Columns.Add(cmbdgv);





            #endregion binddata


               dataGridViewTkCo.Columns["tkCohide"].Visible = false;
             dataGridViewTkCo.Columns["ngayctuhide"].Visible = false;

            dataGridViewTkCo.Columns["Tk_Có"].DisplayIndex = 0;
            dataGridViewTkCo.Columns["Tk_Có"].Width = 100;
            dataGridViewTkCo.Columns["Tk_Có"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewTkCo.Columns["Mã_chi_tiết"].DisplayIndex = 1;
            dataGridViewTkCo.Columns["Mã_chi_tiết"].Width = 100;
            dataGridViewTkCo.Columns["Mã_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkCo.Columns["Mã_chi_tiết"].ReadOnly = true;
            dataGridViewTkCo.Columns["Mã_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;

            dataGridViewTkCo.Columns["Tên_chi_tiết"].DisplayIndex = 2;
            dataGridViewTkCo.Columns["Tên_chi_tiết"].Width = 200;
            dataGridViewTkCo.Columns["Tên_chi_tiết"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkCo.Columns["Tên_chi_tiết"].ReadOnly = true;
            dataGridViewTkCo.Columns["Tên_chi_tiết"].DefaultCellStyle.BackColor = Color.LightGray;


            dataGridViewTkCo.Columns["Số_tiền"].DisplayIndex = 3;
            dataGridViewTkCo.Columns["Số_tiền"].Width = 100;
            dataGridViewTkCo.Columns["Số_tiền"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkCo.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";


            dataGridViewTkCo.Columns["Diễn_giải"].DisplayIndex = 4;
            dataGridViewTkCo.Columns["Diễn_giải"].Width = 300;
            dataGridViewTkCo.Columns["Diễn_giải"].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridViewTkCo.Columns["Ký_hiêu"].DisplayIndex = 5;
            dataGridViewTkCo.Columns["Ký_hiêu"].Width = 100;
            dataGridViewTkCo.Columns["Ký_hiêu"].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridViewTkCo.Columns["Ngày_chứng_từ"].DisplayIndex = 6;
            dataGridViewTkCo.Columns["Ngày_chứng_từ"].Width = 100;
            dataGridViewTkCo.Columns["Ngày_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridViewTkCo.Columns["Số_chứng_từ"].DisplayIndex = 7;
            dataGridViewTkCo.Columns["Số_chứng_từ"].Width = 200;
            dataGridViewTkCo.Columns["Số_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;






            #endregion datatable temp


            return dataGridViewTkCo;


        }

        public static DataGridView reloadnewdetailtaikhoanNo(DataGridView dataGridViewTkNo)
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
            //      dt.Columns.Add(new DataColumn("Tk_Có", typeof(double)));
            dt.Columns.Add(new DataColumn("Ký_hiêu", typeof(string)));
            dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(int)));
            dt.Columns.Add(new DataColumn("tkNohide", typeof(string))); //comnoxxon

            dt.Columns.Add(new DataColumn("ngayctuhide", typeof(DateTime))); //adding column for combobox





            dataGridViewTkNo.DataSource = dt;


            DGV_DateTimePicker.DateTimePickerColumn col = new DGV_DateTimePicker.DateTimePickerColumn();
            col.HeaderText = "Ngày chứng từ";
            col.Name = "Ngày_chứng_từ";
            col.DataPropertyName = "ngayctuhide";
            dataGridViewTkNo.Columns.Add(col);


            //    dataGridViewTkCo.Columns.Remove("Tk_Có");

            #region  //    bindDataToDataGridViewComboPrograme(); Tk_No
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            DataGridViewComboBoxColumn cmbdgv = new DataGridViewComboBoxColumn();


            List<View.BeePhieuchi.ComboboxItem> CombomCollection = new List<View.BeePhieuchi.ComboboxItem>();

            var rs = from tbl_dstaikhoan in dc.tbl_dstaikhoans
                     orderby tbl_dstaikhoan.matk
                     select tbl_dstaikhoan;
            foreach (var item in rs)
            {
                View.BeePhieuchi.ComboboxItem cb = new View.BeePhieuchi.ComboboxItem();
                cb.Value = item.matk.Trim();
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                CombomCollection.Add(cb);
            }

            cmbdgv.DataSource = CombomCollection;
            cmbdgv.HeaderText = "Tk_Nợ";
            cmbdgv.Name = "Tk_Nợ";
            cmbdgv.ValueMember = "Value";
            cmbdgv.DisplayMember = "Text";
            cmbdgv.Width = 100;
            cmbdgv.DropDownWidth = 300;
            cmbdgv.DataPropertyName = "tkNohide"; //Bound value to the datasource


            dataGridViewTkNo.Columns.Add(cmbdgv);





            #endregion binddata


            dataGridViewTkNo.Columns["tkNohide"].Visible = false;
            dataGridViewTkNo.Columns["ngayctuhide"].Visible = false;

            dataGridViewTkNo.Columns["Tk_Nợ"].DisplayIndex = 0;
            dataGridViewTkNo.Columns["Tk_Nợ"].Width = 100;
            dataGridViewTkNo.Columns["Tk_Nợ"].SortMode = DataGridViewColumnSortMode.NotSortable;

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
            dataGridViewTkNo.Columns["Số_tiền"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTkNo.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";


            dataGridViewTkNo.Columns["Diễn_giải"].DisplayIndex = 4;
            dataGridViewTkNo.Columns["Diễn_giải"].Width = 300;
            dataGridViewTkNo.Columns["Diễn_giải"].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridViewTkNo.Columns["Ký_hiêu"].DisplayIndex = 5;
            dataGridViewTkNo.Columns["Ký_hiêu"].Width = 100;
            dataGridViewTkNo.Columns["Ký_hiêu"].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridViewTkNo.Columns["Ngày_chứng_từ"].DisplayIndex = 6;
            dataGridViewTkNo.Columns["Ngày_chứng_từ"].Width = 100;
            dataGridViewTkNo.Columns["Ngày_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridViewTkNo.Columns["Số_chứng_từ"].DisplayIndex = 7;
            dataGridViewTkNo.Columns["Số_chứng_từ"].Width = 200;
            dataGridViewTkNo.Columns["Số_chứng_từ"].SortMode = DataGridViewColumnSortMode.NotSortable;






            #endregion datatable temp


            return dataGridViewTkNo;


        }


        public static void reloaddetailtaikhoanco(DataGridView dataGridViewTkCo, View.BeePhieuThu phieuthu,string taikhoanno, int sophieuthu)
        {




               string connection_string = Utils.getConnectionstr();
              LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var socailist = from tbl_Socai in dc.tbl_Socais
                            where tbl_Socai.TkNo.Trim() == taikhoanno.Trim()
                     && tbl_Socai.manghiepvu == "PT"
                    && tbl_Socai.nghiepvuso == sophieuthu
                            select tbl_Socai;


            foreach (tbl_Socai socai in socailist)
            {
             //   MessageBox.Show(socai.Diengiai, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phieuthu.add_detailGridviewTkCo(socai);



            }



          //  return dataGridViewTkCo;


        }

        public static void reloaddetailtaikhoannophieuchi(DataGridView dataGridViewTkNo, View.BeePhieuchi phieuchi, string taikhoanNo, int sophieuchi)
        {




            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var socailist = from tbl_Socai in dc.tbl_Socais
                            where tbl_Socai.TkNo.Trim() == taikhoanNo.Trim()
                     && tbl_Socai.manghiepvu == "PC"
                    && tbl_Socai.nghiepvuso == sophieuchi
                            select tbl_Socai;


            foreach (tbl_Socai socai in socailist)
            {
                //   MessageBox.Show(socai.Diengiai, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phieuchi.add_detailGridviewTkNo(socai);



            }



            //  return dataGridViewTkCo;


        }


    }
}

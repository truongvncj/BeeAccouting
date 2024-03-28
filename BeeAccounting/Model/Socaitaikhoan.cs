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
    class hachtoantonghop
    {

        public static void xoa(string manghiepvu, string sohieuchungtu) // vd phieu thu nghiep vu là phieu thu: PT,
        {
            if (manghiepvu != "")
            {
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = from tbl_Socai in dc.tbl_Socais
                         where tbl_Socai.manghiepvu == manghiepvu
                         && tbl_Socai.Sohieuchungtu == sohieuchungtu
                         select tbl_Socai;



                dc.tbl_Socais.DeleteAllOnSubmit(rs);
                dc.SubmitChanges();
            }



        }

        public static DataGridView reloaddetailnewbuttoanexample(DataGridView dataGridViewTkTHop)
        {
            // throw new NotImplementedException();


            dataGridViewTkTHop.DataSource = null;

            #region datatable temp




            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DateTime))); //adding column for combobox
            dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(string)));
            dt.Columns.Add(new DataColumn("Diễn_giải", typeof(string)));

            dt.Columns.Add(new DataColumn("Nợ_TK", typeof(string)));
            dt.Columns.Add(new DataColumn("Có_TK", typeof(string)));

            dt.Columns.Add(new DataColumn("Số_tiền", typeof(double)));


            dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Nợ", typeof(int)));
            dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Nợ", typeof(string)));
            dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Có", typeof(int)));


            dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Có", typeof(string)));



            //        dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DGV_DateTimePicker.DateTimePickerCell)));
            //    dt.Columns.Add(new DataColumn("masanpham", typeof(string)));
            //     dt.Columns.Add(new DataColumn("Tên_sản_phẩm", typeof(string)));



            //       dt.Columns.Add(new DataColumn("Số_lượng_nhập", typeof(double)));
            //     dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DateTime))); //adding column for combobox






            //     dt.Columns.Add(new DataColumn("tkidhide", typeof(string))); //comnoxxon




            dataGridViewTkTHop.DataSource = dt;

            dataGridViewTkTHop.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";
            dataGridViewTkTHop.Columns["Số_tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // để hiện số có dấu phảy

            //DGV_DateTimePicker.DateTimePickerColumn col = new DGV_DateTimePicker.DateTimePickerColumn();
            //col.HeaderText = "Ngày chứng từ";
            //col.Name = "Ngày_chứng_từ";
            //col.DataPropertyName = "ngayctuhide";
            //dataGridViewTkTHop.Columns.Add(col);


            //    dataGridViewTkCo.Columns.Remove("Tk_Có");
            //string connection_string = Utils.getConnectionstr();
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //#region  //  tai khoan có

            //DataGridViewComboBoxColumn cmbdgvtkco = new DataGridViewComboBoxColumn();


            //List<View.BeeButtoantonghop.ComboboxItem> cbtaikhoanco = new List<View.BeeButtoantonghop.ComboboxItem>();

            //var listtk01 = from p in dc.tbl_dstaikhoans
            //       //  where p.makho == makho
            //         orderby p.matk
            //         select p;
            //foreach (var item in listtk01)
            //{
            //    View.BeeButtoantonghop.ComboboxItem cb = new View.BeeButtoantonghop.ComboboxItem();
            //    cb.Value = item.matk;
            //    cb.Text = item.matk.Trim() + ": " + item.tentk;
            //    cbtaikhoanco.Add(cb);
            //}

            //cmbdgvtkco.DataSource = cbtaikhoanco;
            //cmbdgvtkco.HeaderText = "Có_TK";
            //cmbdgvtkco.Name = "Có_TK";
            //cmbdgvtkco.ValueMember = "Value";
            //cmbdgvtkco.DisplayMember = "Text";
            //cmbdgvtkco.Width = 300;
            //cmbdgvtkco.DropDownWidth = 300;
            //cmbdgvtkco.DataPropertyName = "cotaikhoan"; //Bound value to the datasource


            //dataGridViewTkTHop.Columns.Add(cmbdgvtkco);





            //#endregion binddata


            //#region  //  tai khoan nợ

            //DataGridViewComboBoxColumn cmbdgvnotk = new DataGridViewComboBoxColumn();


            //List<View.BeeButtoantonghop.ComboboxItem> cbtaikhoanno = new List<View.BeeButtoantonghop.ComboboxItem>();

            //var listtk02 = from p in dc.tbl_dstaikhoans
            //                   //  where p.makho == makho
            //               orderby p.matk
            //               select p;
            //foreach (var item in listtk02)
            //{
            //    View.BeeButtoantonghop.ComboboxItem cb2 = new View.BeeButtoantonghop.ComboboxItem();
            //    cb2.Value = item.matk;
            //    cb2.Text = item.matk.Trim() + ": " + item.tentk;
            //    cbtaikhoanno.Add(cb2);
            //}

            //cmbdgvnotk.DataSource = cbtaikhoanno;
            //cmbdgvnotk.HeaderText = "Nợ_TK";
            //cmbdgvnotk.Name = "Nợ_TK";
            //cmbdgvnotk.ValueMember = "Value";
            //cmbdgvnotk.DisplayMember = "Text";
            //cmbdgvnotk.Width = 300;
            //cmbdgvnotk.DropDownWidth = 300;
            //cmbdgvnotk.DataPropertyName = "notaikhoan"; //Bound value to the datasource


            //dataGridViewTkTHop.Columns.Add(cmbdgvnotk);





            //#endregion binddata


            //      dataGridViewTkTHop.Columns["masanpham"].Visible = false;
            //dataGridViewTkTHop.Columns["Mã_sản_phẩm"].DisplayIndex = 0;

            //dataGridViewTkTHop.Columns["Tên_sản_phẩm"].ReadOnly = true;
            //dataGridViewTkTHop.Columns["Đơn_vị"].ReadOnly = true;

            //dataGridViewTkTHop.Columns["Tên_sản_phẩm"].DefaultCellStyle.BackColor = Color.LightGray;
            //dataGridViewTkTHop.Columns["Đơn_vị"].DefaultCellStyle.BackColor = Color.LightGray;

            //dataGridViewTkTHop.Columns["Số_lượng_nhập"].DefaultCellStyle.Format = "N0"; // để hiện số có dấu phảy
            //dataGridViewTkTHop.Columns["Đơn_giá"].DefaultCellStyle.Format = "N0";
            //dataGridViewTkTHop.Columns["Thành_tiền"].DefaultCellStyle.Format = "N0";


            //dataGridViewTkTHop.Columns["Số_lượng_nhập"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // để hiện số có dấu phảy
            //dataGridViewTkTHop.Columns["Đơn_giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewTkTHop.Columns["Thành_tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //    this.dataGridView1.Columns["CustomerCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            //this.dataGridView1.Columns["CustomerCode"].DefaultCellStyle.Format = "N0";
            //this.dataGridView1.Columns["CustomerCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //   dataGridViewdetailPNK.Columns["Đơn_giá"].DefaultCellStyle = datag  ;

            //    dataGridViewdetailPNK.Columns["Tk_Có"].Visible = false;
            // dataGridViewdetailPNK.Columns["masanpham"].Visible = false;

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


            return dataGridViewTkTHop;



        }

        public static DataGridView reloaddetailnewbuttoandetail(DataGridView dataGridViewTkTHop)
        {
            // throw new NotImplementedException();


            dataGridViewTkTHop.DataSource = null;

            #region datatable temp




            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DateTime))); //adding column for combobox
            dt.Columns.Add(new DataColumn("Số_chứng_từ", typeof(string)));
            dt.Columns.Add(new DataColumn("Diễn_giải", typeof(string)));

            dt.Columns.Add(new DataColumn("Nợ_TK", typeof(string)));
            dt.Columns.Add(new DataColumn("Có_TK", typeof(string)));

            dt.Columns.Add(new DataColumn("Số_tiền", typeof(double)));


            dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Nợ", typeof(int)));
            dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Nợ", typeof(string)));
            dt.Columns.Add(new DataColumn("Mã_chi_tiết_TK_Có", typeof(int)));


            dt.Columns.Add(new DataColumn("Tên_chi_tiết_TK_Có", typeof(string)));

            dt.Columns.Add(new DataColumn("ID_Sản_phẩm_TK_Nợ", typeof(int)));

            dt.Columns.Add(new DataColumn("ID_Sản_phẩm_TK_Có", typeof(int)));

            dt.Columns.Add(new DataColumn("Chi_phi_hợp_lê", typeof(bool)));

            

            //        dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DGV_DateTimePicker.DateTimePickerCell)));
            //    dt.Columns.Add(new DataColumn("masanpham", typeof(string)));
            //     dt.Columns.Add(new DataColumn("Tên_sản_phẩm", typeof(string)));



            //       dt.Columns.Add(new DataColumn("Số_lượng_nhập", typeof(double)));
            //     dt.Columns.Add(new DataColumn("Ngày_chứng_từ", typeof(DateTime))); //adding column for combobox






            //     dt.Columns.Add(new DataColumn("tkidhide", typeof(string))); //comnoxxon




            dataGridViewTkTHop.DataSource = dt;

            dataGridViewTkTHop.Columns["Số_tiền"].DefaultCellStyle.Format = "N0";
            dataGridViewTkTHop.Columns["Số_tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // để hiện số có dấu phảy

            //DGV_DateTimePicker.DateTimePickerColumn col = new DGV_DateTimePicker.DateTimePickerColumn();
            //col.HeaderText = "Ngày chứng từ";
            //col.Name = "Ngày_chứng_từ";
            //col.DataPropertyName = "ngayctuhide";
            //dataGridViewTkTHop.Columns.Add(col);


            //    dataGridViewTkCo.Columns.Remove("Tk_Có");
            //string connection_string = Utils.getConnectionstr();
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            //#region  //  tai khoan có

            //DataGridViewComboBoxColumn cmbdgvtkco = new DataGridViewComboBoxColumn();


            //List<View.BeeButtoantonghop.ComboboxItem> cbtaikhoanco = new List<View.BeeButtoantonghop.ComboboxItem>();

            //var listtk01 = from p in dc.tbl_dstaikhoans
            //       //  where p.makho == makho
            //         orderby p.matk
            //         select p;
            //foreach (var item in listtk01)
            //{
            //    View.BeeButtoantonghop.ComboboxItem cb = new View.BeeButtoantonghop.ComboboxItem();
            //    cb.Value = item.matk;
            //    cb.Text = item.matk.Trim() + ": " + item.tentk;
            //    cbtaikhoanco.Add(cb);
            //}

            //cmbdgvtkco.DataSource = cbtaikhoanco;
            //cmbdgvtkco.HeaderText = "Có_TK";
            //cmbdgvtkco.Name = "Có_TK";
            //cmbdgvtkco.ValueMember = "Value";
            //cmbdgvtkco.DisplayMember = "Text";
            //cmbdgvtkco.Width = 300;
            //cmbdgvtkco.DropDownWidth = 300;
            //cmbdgvtkco.DataPropertyName = "cotaikhoan"; //Bound value to the datasource


            //dataGridViewTkTHop.Columns.Add(cmbdgvtkco);





            //#endregion binddata


            //#region  //  tai khoan nợ

            //DataGridViewComboBoxColumn cmbdgvnotk = new DataGridViewComboBoxColumn();


            //List<View.BeeButtoantonghop.ComboboxItem> cbtaikhoanno = new List<View.BeeButtoantonghop.ComboboxItem>();

            //var listtk02 = from p in dc.tbl_dstaikhoans
            //                   //  where p.makho == makho
            //               orderby p.matk
            //               select p;
            //foreach (var item in listtk02)
            //{
            //    View.BeeButtoantonghop.ComboboxItem cb2 = new View.BeeButtoantonghop.ComboboxItem();
            //    cb2.Value = item.matk;
            //    cb2.Text = item.matk.Trim() + ": " + item.tentk;
            //    cbtaikhoanno.Add(cb2);
            //}

            //cmbdgvnotk.DataSource = cbtaikhoanno;
            //cmbdgvnotk.HeaderText = "Nợ_TK";
            //cmbdgvnotk.Name = "Nợ_TK";
            //cmbdgvnotk.ValueMember = "Value";
            //cmbdgvnotk.DisplayMember = "Text";
            //cmbdgvnotk.Width = 300;
            //cmbdgvnotk.DropDownWidth = 300;
            //cmbdgvnotk.DataPropertyName = "notaikhoan"; //Bound value to the datasource


            //dataGridViewTkTHop.Columns.Add(cmbdgvnotk);





            //#endregion binddata


            //      dataGridViewTkTHop.Columns["masanpham"].Visible = false;
            //dataGridViewTkTHop.Columns["Mã_sản_phẩm"].DisplayIndex = 0;

            //dataGridViewTkTHop.Columns["Tên_sản_phẩm"].ReadOnly = true;
            //dataGridViewTkTHop.Columns["Đơn_vị"].ReadOnly = true;

            //dataGridViewTkTHop.Columns["Tên_sản_phẩm"].DefaultCellStyle.BackColor = Color.LightGray;
            //dataGridViewTkTHop.Columns["Đơn_vị"].DefaultCellStyle.BackColor = Color.LightGray;

            //dataGridViewTkTHop.Columns["Số_lượng_nhập"].DefaultCellStyle.Format = "N0"; // để hiện số có dấu phảy
            //dataGridViewTkTHop.Columns["Đơn_giá"].DefaultCellStyle.Format = "N0";
            //dataGridViewTkTHop.Columns["Thành_tiền"].DefaultCellStyle.Format = "N0";


            //dataGridViewTkTHop.Columns["Số_lượng_nhập"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // để hiện số có dấu phảy
            //dataGridViewTkTHop.Columns["Đơn_giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridViewTkTHop.Columns["Thành_tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //    this.dataGridView1.Columns["CustomerCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            //this.dataGridView1.Columns["CustomerCode"].DefaultCellStyle.Format = "N0";
            //this.dataGridView1.Columns["CustomerCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;// = "N0";

            //   dataGridViewdetailPNK.Columns["Đơn_giá"].DefaultCellStyle = datag  ;

            //    dataGridViewdetailPNK.Columns["Tk_Có"].Visible = false;
            // dataGridViewdetailPNK.Columns["masanpham"].Visible = false;

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


            return dataGridViewTkTHop;



        }


        public static object danhsachbuttoantonghop(LinqtoSQLDataContext dc, String thang, String nam, string taikhoan)
        {


            LinqtoSQLDataContext db = dc;

            var rs = from p in dc.tbl_Socais
                     where p.manghiepvu == "TH"
                     && p.Ngayctu.Value.Month.ToString() == thang
                     && p.Ngayctu.Value.Year.ToString() == nam
                     && (p.TkNo.Contains(taikhoan) || p.TkCo.Contains(taikhoan))

                     select new
                     {

                         Ngày_chứng_từ = p.Ngayctu,
                         Số_chứng_từ = p.Sohieuchungtu,
                         Nợ_TK = p.TkNo,
                         Có_TK = p.TkCo,
                         Số_tiền = p.PsCo,
                         Diễn_giải = p.Diengiai.Trim(),
                         Mã_chi_tiết_TK_Có = p.MaCTietTKCo,
                         Mã_chi_tiết_TK_Nợ = p.MaCTietTKNo,

                         Tên_chi_tiết_TK_Có = p.tenchitietCo,
                         Tên_chi_tiết_TK_Nợ = p.tenchitietNo,




                         Tạo_bởi = p.username,



                         ID = p.id
                     };





            return rs;

        }


        public static object danhsachbuttoansocai(LinqtoSQLDataContext dc, int nam, string taikhoanno, string taikhoanco)
        {


          //  LinqtoSQLDataContext db = dc;
            IQueryable  rs = null;

      

            if (taikhoanno == "")
            {
                #region  tờ kê có
                rs = from p in dc.tbl_Socais
                     where
                         //-- p.manghiepvu == "TH"
             //            p.Ngayctu.Value.Month == thang
              p.Ngayctu.Value.Year == nam
                   &&                 p.TkCo == taikhoanco

                     select new
                     {

                         Ngày_chứng_từ = p.Ngayctu,
                         Số_chứng_từ = p.Sohieuchungtu,
                         Nợ_TK = p.TkNo,
                         Có_TK = p.TkCo,
                         Diễn_giải = p.Diengiai.Trim(),
                         Số_tiền = p.PsCo,
                       
                         Mã_chi_tiết_TK_Có = p.MaCTietTKCo,
                        

                         Tên_chi_tiết_TK_Có = p.tenchitietCo,
                         Mã_chi_tiết_TK_Nợ = p.MaCTietTKNo,
                         Tên_chi_tiết_TK_Nợ = p.tenchitietNo,




                         Tạo_bởi = p.username,



                         ID = p.id
                     };


                #endregion

            }
            else
            {
                #region  tờ kê nợ
                rs = from p in dc.tbl_Socais
                     where
                         //-- p.manghiepvu == "TH"
              //       p.Ngayctu.Value.Month == thang
                   p.Ngayctu.Value.Year == nam
                     && p.TkNo == taikhoanno
                  //   && p.TkCo == taikhoanco

                     select new
                     {


                         Ngày_chứng_từ = p.Ngayctu,
                         Số_chứng_từ = p.Sohieuchungtu,
                         Nợ_TK = p.TkNo,
                         Có_TK = p.TkCo,
                         Diễn_giải = p.Diengiai.Trim(),
                         Số_tiền = p.PsCo,

                         Mã_chi_tiết_TK_Có = p.MaCTietTKCo,


                         Tên_chi_tiết_TK_Có = p.tenchitietCo,
                         Mã_chi_tiết_TK_Nợ = p.MaCTietTKNo,
                         Tên_chi_tiết_TK_Nợ = p.tenchitietNo,


                         Tạo_bởi = p.username,



                         ID = p.id
                     };


                #endregion

            }

   
            return rs;

        }






    }
}

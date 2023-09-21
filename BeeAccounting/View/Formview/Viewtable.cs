using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEEACCOUNT.Control;
using BEEACCOUNT.shared;
using System.Globalization;
using System.Threading;
using BEEACCOUNT.Model;
using System.Data.SqlClient;

namespace BEEACCOUNT.View
{

    //   public static DataGridView dataGridView2;// = new DataGridView();

    public partial class Viewtable : Form
    {

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public string valuesave { get; set; }
        public int viewcode;
        public IQueryable rs;
        LinqtoSQLDataContext db;
        public DataGridView Dtgridview;


        public static string connection_string = Utils.getConnectionstr();

        LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


        //   public List<ComboboxItem> dataCollectionaccount;

        //  public List<ComboboxItem> dataCollectiongroup;//{ get; private set; }
        //1. Định nghĩa 1 delegate


        class datatoExport
        {
            //public DataGridView dataGrid1 { get; set; }
            public System.Data.DataTable datatble { get; set; } // = new System.Data.DataTable();
        }


        public void sumtitleGrid(object inptgridobjiec)
        {

            datatoExport dat = (datatoExport)inptgridobjiec;
            System.Data.DataTable datatble = dat.datatble;
            //    DataGridView dataGrid1 = new DataGridView();
            //   dataGrid1.DataSource = datatble;
            //      double k = dataGrid1.Rows.Count;
            int k = datatble.Rows.Count;
            double Billed_Qty = 0;
            double GSR = 0;
            double UC = 0;
            double PC = 0;
            double NSR = 0;

            try
            {

                for (int i = 0; i < k; i++)
                {
                    #region forr

                    //  datatble.Columns["Billed_Qty"].v


                    if (datatble.Rows[i]["PCs"] != null && Utils.IsValidnumber(datatble.Rows[i]["PCs"].ToString()))
                    {

                        Billed_Qty += double.Parse(datatble.Rows[i]["PCs"].ToString());
                    }

                    if (datatble.Rows[i]["NSR"] != null && Utils.IsValidnumber(datatble.Rows[i]["NSR"].ToString()))
                    {

                        NSR += double.Parse(datatble.Rows[i]["NSR"].ToString());
                    }
                    if (datatble.Rows[i]["UC"] != null && Utils.IsValidnumber(datatble.Rows[i]["UC"].ToString()))
                    {

                        UC += double.Parse(datatble.Rows[i]["UC"].ToString());
                    }
                    if (datatble.Rows[i]["EC"] != null && Utils.IsValidnumber(datatble.Rows[i]["EC"].ToString()))
                    {

                        PC += double.Parse(datatble.Rows[i]["EC"].ToString());
                    }
                    if (datatble.Rows[i]["GSR"] != null && Utils.IsValidnumber(datatble.Rows[i]["GSR"].ToString()))
                    {

                        GSR += double.Parse(datatble.Rows[i]["GSR"].ToString());
                    }

                    //======



                    #endregion forr
                }



                //     Billed_Qty = 100;
                this.lb_bilingqtt.Invoke(new UpdateTextCallback(this.UpdateText),
                                             new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });


                this.lb_netvalue.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });



                this.lb_countvalue.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });


                this.lb_pc.Invoke(new UpdateTextCallback(this.UpdateText),
                                            new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });


                this.lb_uc.Invoke(new UpdateTextCallback(this.UpdateText),
                                                 new object[] { Billed_Qty.ToString(), NSR.ToString(), UC.ToString(), PC.ToString(), GSR.ToString() });

                //   MyGetData( tongamount,  tongdeposit,  fullGoodamount,  sumempty);
            }
            catch (Exception)
            {
                Thread.CurrentThread.Abort();
                //       MessageBox.Show(ex.ToString());

                // MessageBox.Show(hh44.ToString());


            }




        }



        private void UpdateText(string Billed_Qty, string NSR, string UC, string PC, string GSR)
        {


            this.lb_bilingqtt.Text = double.Parse(Billed_Qty).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_netvalue.Text = double.Parse(GSR).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_countvalue.Text = double.Parse(NSR).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_pc.Text = double.Parse(PC).ToString("#,#", CultureInfo.InvariantCulture);
            this.lb_uc.Text = double.Parse(UC).ToString("#,#", CultureInfo.InvariantCulture);

            this.Status.Text = "DONE";
            //  this.dataGridView1.Refresh();
        }

        public delegate void UpdateTextCallback(string Billed_Qty, string NSR, string UC, string PC, string GSR);
        //    In your thread, you can call the Invoke method on m_TextBox, passing the delegate to call, as well as the parameters.



        //public void Reloadcustomer(String inutstring)

        //{
        //    string connection_string = Utils.getConnectionstr();
        //    //      UpdateDatagridview
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    //   LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
        //    var rsthisperiod = from tbl_KaCustomer in dc.tbl_PosCustomers
        //                       where ((int)tbl_KaCustomer.Customer).ToString().Contains(inutstring)
        //                       select tbl_KaCustomer;

        //    Utils ut = new Utils();
        //    dt = ut.ToDataTable(dc, rsthisperiod);

        //    this.dataGridView1.DataSource = dt;


        //}



        void Control_KeyPress(object sender, KeyEventArgs e)
        {
            // if (viewcode == 2)// nuew la bàng salsetemp update

            //if ((viewcode == 2) && e.KeyCode == Keys.F3)
            //{





            //    FormCollection fc = System.Windows.Forms.Application.OpenForms;

            //    bool kq = false;
            //    foreach (Form frm in fc)
            //    {
            //        if (frm.Text == "tblsales")


            //        {
            //            kq = true;
            //            frm.Focus();

            //        }
            //    }

            //    if (!kq)
            //    {
            //        Seachcode sheaching = new Seachcode(this, "tblsales");
            //        sheaching.Show();
            //    }




            //}


        }


        public BindingSource source2;
        public Viewtable(IQueryable rs, LinqtoSQLDataContext dc, string fornname, int viewcode, string valuesave)
        {
            //    this.dataGridView1.DataSource = rs;
            InitializeComponent();
            this.valuesave = valuesave;


            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);

            this.dataGridView1.DataSource = rs;
            this.Dtgridview = dataGridView1;

            this.db = dc;
            this.viewcode = viewcode;
            this.rs = rs;
            //  this.lb_seach.Text = "F3 TÌM KIẾM";
            //      this.bt_sendinggroup.Visible = false;
            //     this.lb_seach.Visible = false;
            this.Pl_endview.Visible = false;
            this.btketchuyen.Visible = false; 

            this.formlabel.Text = fornname;

            //     bt_addtomaster.Visible = false;
            //     this.bt_addtomaster.Visible = false;

            this.lb_totalrecord.Text = dataGridView1.RowCount.ToString("#,#", CultureInfo.InvariantCulture);// ;//String.Format("{0:0,0}", k33q); 
                                                                                                            //  this.lb_totalrecord.ForeColor = Color.Chocolate;
                                                                                                            //   this.Show();
            this.KeyPreview = true;

            #region  // viewcode ==12  la view bang tong hop phat sinh
            if (this.viewcode == 121) // view đơn hang netco
            {
                //lb_seach.Visible = false;

                btketchuyen.Visible = true;
                bt_themmoi.Visible = false;

                bt_sua.Visible = false;
            
            }


            if (this.valuesave == "1") // view đơn hang netco
            {
                //lb_seach.Visible = false;

                bt_themmoi.Visible = false;

                bt_sua.Visible = false;
            }


            if (this.viewcode == 12)
            {
                //lb_seach.Visible = false;

                bt_themmoi.Visible = false;

                bt_sua.Visible = false;
            }

            if (this.viewcode == 114) // dang ky tai khoan chi tiet thì cho edit
            {
                //lb_seach.Visible = false;

                dataGridView1.ReadOnly = false;
            }
            #endregion

        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            //   Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
            //  For Each c As DataGridViewColumn In dataGridViewListphieuthu.Columns

            foreach (var c in dataGridView1.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

            // Next


        }

        private void bt_exporttoex_Click(object sender, EventArgs e)
        {
            Control_ac ctrex = new Control_ac();


            ctrex.exportexceldatagridtofile(this.rs, this.db, this.Text);




        }

        private void bt_addtomaster_Click(object sender, EventArgs e)
        {

        }

        private void bt_themmoi_Click(object sender, EventArgs e)
        {


          

            #region  // viewcode ==0  la danh sách tài k khoản kê toán


            if (this.viewcode == 0)
            {

                Model.Taikhoanketoan.themmoitaikhoan();
                var rs = Model.Taikhoanketoan.danhsachtaikhoan(this.db);

                dataGridView1.DataSource = rs;



            }



            #endregion


            #region // viewcode ==1  lA DANH SACH  loại tai khoan ke toan
            if (this.viewcode == 1)
            {

                Model.loaitaikhoanketoan.themmoiloaitaikhoan();
                var rs = Model.loaitaikhoanketoan.danhsachloaitaikhoan(this.db);

                dataGridView1.DataSource = rs;



            }

            #endregion



            #region  // viewcode ==2  lA DANH SACH  chi tiết tài khoản
            if (this.viewcode == 2)
            {

                Model.Danhsachtkchitiet.themmoichitiettaikhoan();
                var rs = Model.Danhsachtkchitiet.danhsachtaikhoanchitiet(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion


            #region  // viewcode ==4  lA DANH SACH  kho hàng
            if (this.viewcode == 4)
            {

                Model.Khohang.themmoikhohang();



                var rs = Model.Khohang.Danhsachkho(this.db);

                dataGridView1.DataSource = rs;



            }

            #endregion



            #region // viewcode ==5  lA DANH SACH  nhà cung ứng
            if (this.viewcode == 5)
            {

                Model.Nhacungcap.themmoiNCC();
                var rs = Model.Nhacungcap.danhsachNhacungcap(this.db);

                dataGridView1.DataSource = rs;



            }

            #endregion



            #region // viewcode == 6  lA DANH SACH  nhom san pahm

            if (this.viewcode == 6)
            {

                Model.Khohang.themmoinhomsanpham();
                var rs = Model.Khohang.danhsachnhomsanpham(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion


            #region // viewcode == 7  lA DANH SACH   san pahm

            if (this.viewcode == 7)
            {

                Model.Khohang.themmoisanpham();
                var rs = Model.Khohang.danhsachsanpham(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion


            #region // viewcode == 8  lA DANH SACH  nha van tai

            if (this.viewcode == 8)
            {

                // Model.Khohang.themmoinhomsanpham();
                //   var rs = Model.Khohang.danhsachnhomsanpham(this.db);
                Model.Nhacungcap.themmoiNVT(3, 0);
                var rs = Model.Nhacungcap.danhsachNVT(dc);
                dataGridView1.DataSource = rs;



            }
            #endregion
            //NPdanhsachxe

            #region // viewcode == 9  lA DANH SACH  xe

            if (this.viewcode == 9)
            {

                // Model.Khohang.themmoinhomsanpham();
                //   var rs = Model.Khohang.danhsachnhomsanpham(this.db);
                Model.Nhacungcap.themmoixetai(3, 0);
                var rs = Model.Nhacungcap.danhsachxe(dc);
                dataGridView1.DataSource = rs;



            }
            #endregion

            #region  // viewcode ==11  la danh gia theo tuyen


            if (this.viewcode == 11)
            {


                string makh = valuesave;





                Model.Nhacungcap.themmoigiavantaitheotuyen(makh);
                var rs = Model.Nhacungcap.danhsachgiatheotuyenvamanhavantai(this.db, makh);

                dataGridView1.DataSource = rs;



            }



            #endregion



            #region  // viewcode ==10  la danh sách khách hàng kế toán


            if (this.viewcode == 10)
            {

                Model.Nhacungcap.themmoikhachhangvantai();
                var rs = Model.Nhacungcap.danhsachkhachhangvantai(this.db);

                dataGridView1.DataSource = rs;



            }



            #endregion



               #region  // viewcode ==14  la danh sách phân xưorng san xuat


            if (this.viewcode == 14)
            {

                View.fdanhsachphanxuongsx p = new fdanhsachphanxuongsx(3, -1);  // 3 là thêm ới

                p.ShowDialog();


                var rs = Model.Sanxuat.Danhsachphanxuongsx(this.db);

                dataGridView1.DataSource = rs;



            }



            #endregion


            #region  // viewcode ==15  la danh sản phâm  san xuat


            if (this.viewcode == 15)
            {

                View.fdanhsachsanphamsx p = new fdanhsachsanphamsx(3, -1);  // 3 là thêm ới

                p.ShowDialog();


                var rs = Model.Sanxuat.Danhsachsanphamsx(this.db);

                dataGridView1.DataSource = rs;



            }



            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {


            #region  viewcode = 11 à  list gia theo tuyến


            if (this.viewcode == 11)  // viewcode ==0  la danh sách tài k khoản kê toán
            {

                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một tuyến !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = (from p in dc.tbl_NP_giavantaitheotuyens
                          where p.id == idtk
                          select p).FirstOrDefault();
                if (rs == null)
                {
                    MessageBox.Show("Bạn chọn một tuyến !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (rs != null)
                {
                    string makh = valuesave;

                    //     string taikhoan = rs.matk;

                    ////View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(4, taikhoan); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa

                    ////createacc.ShowDialog();

                    Model.Nhacungcap.suadanhsachgiatheotuyencuakhachhang(idtk);

                    var rs3 = Model.Nhacungcap.danhsachgiatheotuyenvamanhavantai(dc, makh);

                    dataGridView1.DataSource = rs3;

                }
            }




            #endregion viewcode = 1 dnah muc tai khoan ke toan



            #region  viewcode = 10 à  khach hang van tai


            if (this.viewcode == 10)  // viewcode ==0  la danh sách tài k khoản kê toán
            {

                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một khách hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = (from p in dc.tbl_NP_khachhangvanchuyens
                          where p.id == idtk
                          select p).FirstOrDefault();
                if (rs == null)
                {
                    MessageBox.Show("Bạn chọn một tài khoản khác bên bảng danh sách tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (rs != null)
                {

                    //     string taikhoan = rs.matk;

                    ////View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(4, taikhoan); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa

                    ////createacc.ShowDialog();

                    Model.Nhacungcap.suadanhsachkhachhangvantai(idtk);

                    var rs3 = Model.Nhacungcap.danhsachkhachhangvantai(dc);

                    dataGridView1.DataSource = rs3;

                }
            }




            #endregion viewcode = 1 dnah muc tai khoan ke toan



            #region  viewcode = 0 à  tài khoản kế toán


            if (this.viewcode == 0)  // viewcode ==0  la danh sách tài k khoản kê toán
            {

                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn chọn một tài khoản bên bảng danh sách tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                          where tbl_dstaikhoan.id == idtk
                          select tbl_dstaikhoan).FirstOrDefault();
                if (rs == null)
                {
                    MessageBox.Show("Bạn chọn một tài khoản khác bên bảng danh sách tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (rs != null)
                {

                    string taikhoan = rs.matk;

                    ////View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(4, taikhoan); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa

                    ////createacc.ShowDialog();

                    Model.Taikhoanketoan.suataikhoan(taikhoan);

                    var rs3 = Model.Taikhoanketoan.danhsachtaikhoan(dc);

                    dataGridView1.DataSource = rs3;

                }
            }




            #endregion viewcode = 1 dnah muc tai khoan ke toan


            #region viewcode =1 loai tai khoan ke toan 
            if (this.viewcode == 1)
            {

                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn chọn một tài khoản bên bảng danh sách loại tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = (from tbloaitk in dc.tbl_loaitks
                          where tbloaitk.id == idtk
                          select tbloaitk).FirstOrDefault();
                if (rs == null)
                {
                    MessageBox.Show("Bạn chọn một tài khoản khác bên bảng danh sách loại tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (rs != null)
                {

                    int id = (int)rs.id;

                    ////View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(4, taikhoan); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa

                    ////createacc.ShowDialog();

                    Model.loaitaikhoanketoan.sualoaitaikhoanketoan(id);

                    var rs3 = Model.loaitaikhoanketoan.danhsachloaitaikhoan(dc);

                    dataGridView1.DataSource = rs3;





                }
            }
            #endregion loai tai khoan ke toan



            #region vói vidcode == 2  la danh shach chi tiêt stai khoan


            if (this.viewcode == 2)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một tài khoản 11 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Model.Danhsachtkchitiet.suachitiettaikhoan(idtk);
                var rs1 = Model.Danhsachtkchitiet.danhsachtaikhoanchitiet(this.db);

                dataGridView1.DataSource = rs1;
                // MessageBox.Show(id.ToString(), "Thông báo 111", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            #endregion

            #region viewdco = 4 la danh sahc kho


            if (this.viewcode == 4)  // viewcode ==4  lA DANH SACH  kho hàng
            {
                int iddskho = 0;
                try
                {
                    iddskho = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một kho !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Model.Khohang.suaxoadanhsachkho(iddskho);



                var rs = Model.Khohang.Danhsachkho(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion

            #region viewcode =5 danh sach nhà cung cấp
            if (this.viewcode == 5)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn mã nhà cung cấp !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Model.Nhacungcap.suathongtinNCC(idtk);
                var rs = Model.Nhacungcap.danhsachNhacungcap(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion


            #region viewcode =6 danh sach nhóm sản phẩm
            if (this.viewcode == 6)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn nhóm sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Model.Khohang.suanhomsanpham(idtk);
                var rs = Model.Khohang.danhsachnhomsanpham(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion



            #region viewcode =7 danh sach  sản phẩm
            if (this.viewcode == 7)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Model.Khohang.suasanpham(idtk);
                var rs = Model.Khohang.danhsachsanpham(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion


            #region viewcode =8 danh sach  NVT
            if (this.viewcode == 8)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một nhà vận tải !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Model.Khohang.suasanpham(idtk);
                Model.Nhacungcap.suathongtinNVT(idtk);
                var rs = Model.Nhacungcap.danhsachNVT(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion



            #region // viewcode == 9  lA DANH SACH  xe

            if (this.viewcode == 9)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một xe !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Model.Nhacungcap.suathongtinxe(idtk);
                var rs = Model.Nhacungcap.danhsachxe(dc);
                dataGridView1.DataSource = rs;

                //   Tải_trọng = p.sotantai,
                //      Kích_thước_thùng = p.sokhoithungxe,
                dataGridView1.Columns["Tải_trọng"].DefaultCellStyle.Format = "N0"; // để hiện số có dấu phảy
                dataGridView1.Columns["Kích_thước_thùng"].DefaultCellStyle.Format = "N0"; // để hiện số có dấu phảy

            }
            #endregion

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void Viewtable_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            #region  viewcode = 114 update thêm là edit và update vào hê thống code status


            if (this.viewcode == 114)  // viewcode ==0  la danh sách tài k khoản kê toán
            {



                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;
                }
                catch (Exception)
                {

                    //    MessageBox.Show("Bạn phải chọn một tuyến !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //  return;
                }

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = (from p in dc.tbl_dstaikhoans
                          where p.id == idtk
                          select p).FirstOrDefault();
                if (rs != null)
                {

                    rs.loaichitiet = !rs.loaichitiet;
                    if (rs.loaichitiet)
                    {
                        MessageBox.Show("Đăng ký sổ theo dõi chi tiết !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Bỏ theo dõi chi tiết !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                    // return;
                }
                dc.SubmitChanges();


                var rs1 = Model.Taikhoanketoan.danhsachtaikhoandangkychitiet(dc);
                dataGridView1.DataSource = rs1;

            }




            #endregion viewcode = 114 dnah muc tai khoan ke toan




            #region  viewcode = 11 danh sahch giá vân tải theo tuyến


            if (this.viewcode == 11)  // viewcode ==0  la danh sách tài k khoản kê toán
            {

                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một tuyến !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = (from p in dc.tbl_NP_giavantaitheotuyens
                          where p.id == idtk
                          select p).FirstOrDefault();
                if (rs == null)
                {
                    MessageBox.Show("Bạn chọn một tuyến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (rs != null)
                {

                    //     string taikhoan = rs.matk;

                    ////View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(4, taikhoan); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa

                    ////createacc.ShowDialog();
                    string makh = valuesave;
                    Model.Nhacungcap.suadanhsachgiatheotuyencuakhachhang(idtk);

                    var rs3 = Model.Nhacungcap.danhsachgiatheotuyenvamanhavantai(dc, makh);

                    dataGridView1.DataSource = rs3;

                }
            }




            #endregion viewcode = 1 dnah muc tai khoan ke toan



            #region  viewcode = 10 à  khach hang van tai


            if (this.viewcode == 10)  // viewcode ==0  la danh sách tài k khoản kê toán
            {

                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một khách hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = (from p in dc.tbl_NP_khachhangvanchuyens
                          where p.id == idtk
                          select p).FirstOrDefault();
                if (rs == null)
                {
                    MessageBox.Show("Bạn chọn một tài khoản khác bên bảng danh sách tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (rs != null)
                {

                    //     string taikhoan = rs.matk;

                    ////View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(4, taikhoan); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa

                    ////createacc.ShowDialog();

                    Model.Nhacungcap.suadanhsachkhachhangvantai(idtk);

                    var rs3 = Model.Nhacungcap.danhsachkhachhangvantai(dc);

                    dataGridView1.DataSource = rs3;

                }
            }




            #endregion viewcode = 1 dnah muc tai khoan ke toan




            #region  viewcode = 0 à  tài khoản kế toán


            if (this.viewcode == 0)  // viewcode ==0  la danh sách tài k khoản kê toán
            {

                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn chọn một tài khoản bên bảng danh sách tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                          where tbl_dstaikhoan.id == idtk
                          select tbl_dstaikhoan).FirstOrDefault();
                if (rs == null)
                {
                    MessageBox.Show("Bạn chọn một tài khoản khác bên bảng danh sách tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (rs != null)
                {

                    string taikhoan = rs.matk;

                    ////View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(4, taikhoan); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa

                    ////createacc.ShowDialog();

                    Model.Taikhoanketoan.suataikhoan(taikhoan);

                    var rs3 = Model.Taikhoanketoan.danhsachtaikhoan(dc);

                    dataGridView1.DataSource = rs3;

                }
            }




            #endregion viewcode = 1 dnah muc tai khoan ke toan


            #region viewcode =1 loai tai khoan ke toan 
            if (this.viewcode == 1)
            {

                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn chọn một tài khoản bên bảng danh sách loại tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connection_string = Utils.getConnectionstr();

                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = (from tbloaitk in dc.tbl_loaitks
                          where tbloaitk.id == idtk
                          select tbloaitk).FirstOrDefault();
                if (rs == null)
                {
                    MessageBox.Show("Bạn chọn một tài khoản khác bên bảng danh sách loại tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (rs != null)
                {

                    int id = (int)rs.id;

                    ////View.BeeCreatenewaccount createacc = new BeeCreatenewaccount(4, taikhoan); // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa

                    ////createacc.ShowDialog();

                    Model.loaitaikhoanketoan.sualoaitaikhoanketoan(id);

                    var rs3 = Model.loaitaikhoanketoan.danhsachloaitaikhoan(dc);

                    dataGridView1.DataSource = rs3;





                }
            }
            #endregion loai tai khoan ke toan



            #region vói vidcode == 2  la danh shach chi tiêt stai khoan


            if (this.viewcode == 2)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một tài khoản 11 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Model.Danhsachtkchitiet.suachitiettaikhoan(idtk);
                var rs1 = Model.Danhsachtkchitiet.danhsachtaikhoanchitiet(this.db);

                dataGridView1.DataSource = rs1;
                // MessageBox.Show(id.ToString(), "Thông báo 111", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            #endregion

            #region viewcode =5 danh sach nhà cung cấp
            if (this.viewcode == 5)
            {
                if (this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value != DBNull.Value)
                {


                    int idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;


                    View.BeeNCCnewaccount p = new BeeNCCnewaccount(4, idtk);  // 4 là vua sua vua xóa

                    p.ShowDialog();
                }


            }



            #endregion

            #region viewdco = 4 la danh sahc kho


            if (this.viewcode == 4)  // viewcode ==4  lA DANH SACH  kho hàng
            {
                int iddskho = 0;
                try
                {
                    iddskho = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một kho !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Model.Khohang.suaxoadanhsachkho(iddskho);



                var rs = Model.Khohang.Danhsachkho(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion


            #region viewcode =6 danh sach nhóm sản phẩm
            if (this.viewcode == 6)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn nhóm sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Model.Khohang.suanhomsanpham(idtk);
                var rs = Model.Khohang.danhsachnhomsanpham(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion



            #region viewcode =7 danh sach  sản phẩm
            if (this.viewcode == 7)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Model.Khohang.suasanpham(idtk);
                var rs = Model.Khohang.danhsachsanpham(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion


            #region viewcode =8 danh sach  NVT
            if (this.viewcode == 8)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một nhà vận tải !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Model.Khohang.suasanpham(idtk);
                Model.Nhacungcap.suathongtinNVT(idtk);
                var rs = Model.Nhacungcap.danhsachNVT(this.db);

                dataGridView1.DataSource = rs;



            }
            #endregion


            #region // viewcode == 9  lA DANH SACH  xe

            if (this.viewcode == 9)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn phải chọn một xe !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Model.Nhacungcap.suathongtinxe(idtk);
                var rs = Model.Nhacungcap.danhsachxe(dc);
                dataGridView1.DataSource = rs;



            }
            #endregion


            #region // viewcode == 13  lA DANH SACH nhà máy

            if (this.viewcode == 13)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Chọn một nhà máy để sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



            
                dataGridView1.DataSource = rs;



            }
            #endregion

            
            #region // viewcode == 14  lA DANH SACH phân xuwrorng sax

            if (this.viewcode == 14)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Chọn một phân xưởng để sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                View.fdanhsachphanxuongsx p = new fdanhsachphanxuongsx(4, idtk);  // 3 là thêm ới

                p.ShowDialog();
        
             
                var rs = Model.Sanxuat.Danhsachphanxuongsx(dc);
                dataGridView1.DataSource = rs;



            }
            #endregion



            #region // viewcode == 15  lA DANH SACHsan phẩm sax

            if (this.viewcode == 15)
            {
                int idtk = 0;
                try
                {
                    idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;



                }
                catch (Exception)
                {

                    MessageBox.Show("Chọn một sản phẩm để sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                View.fdanhsachsanphamsx p = new fdanhsachsanphamsx(4, idtk);  // 3 là thêm ới

                p.ShowDialog();


                var rs = Model.Sanxuat.Danhsachsanphamsx(dc);
                dataGridView1.DataSource = rs;



            }
            #endregion


            

        }

        private void btketchuyen_Click(object sender, EventArgs e)
        {


            #region caculation cdkt200 lien tuc
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("ketchuyenCDPS", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = Utils.getusername();
                cmd1.Parameters.Add("@yearchon", SqlDbType.Int).Value = int.Parse(valuesave);
                //   cmd1.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;




                rdr1 = cmd1.ExecuteReader();



            }
            finally
            {
                if (conn2 != null)
                {
                    conn2.Close();
                }
                if (rdr1 != null)
                {
                    rdr1.Close();
                }
            }
              MessageBox.Show("Kết chuyển phát sinh đã hoàn thành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion










        }
    }



}

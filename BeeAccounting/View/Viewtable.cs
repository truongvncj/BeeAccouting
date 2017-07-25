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
        public Viewtable(IQueryable rs, LinqtoSQLDataContext dc, string fornname, int viewcode)
        {
            //    this.dataGridView1.DataSource = rs;
            InitializeComponent();



            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);

            this.dataGridView1.DataSource = rs;
            this.Dtgridview = dataGridView1;

            this.db = dc;
            this.viewcode = viewcode;
            this.rs = rs;
            this.lb_seach.Text = "F3 TÌM KIẾM";
            //      this.bt_sendinggroup.Visible = false;
            //     this.lb_seach.Visible = false;
            this.Pl_endview.Visible = false;
            //   gboxUnpaid.Visible = false; // an nhom field upaid

            this.formlabel.Text = fornname;

            //     bt_addtomaster.Visible = false;
            //     this.bt_addtomaster.Visible = false;

            this.lb_totalrecord.Text = dataGridView1.RowCount.ToString("#,#", CultureInfo.InvariantCulture);// ;//String.Format("{0:0,0}", k33q); 
                                                                                                            //  this.lb_totalrecord.ForeColor = Color.Chocolate;
                                                                                                            //   this.Show();
            this.KeyPreview = true;





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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.viewcode == 0)  // viewcode ==0  la danh sách tài k khoản kê toán
            {

                Model.Taikhoanketoan.themmoitaikhoan();
                var rs = Model.Taikhoanketoan.danhsachtaikhoan(this.db);

                dataGridView1.DataSource = rs;



            }
            if (this.viewcode == 1)  // viewcode ==1  lA DANH SACH  loại tai khoan ke toan
            {

                Model.loaitaikhoanketoan.themmoiloaitaikhoan();
                var rs = Model.loaitaikhoanketoan.danhsachloaitaikhoan(this.db);

                dataGridView1.DataSource = rs;



            }

            if (this.viewcode == 2)  // viewcode ==2  lA DANH SACH  chi tiết tài khoản
            {

                Model.Danhsachtkchitiet.themmoichitiettaikhoan();
                var rs = Model.Danhsachtkchitiet.danhsachtaikhoanchitiet(this.db);

                dataGridView1.DataSource = rs;



            }





        }

        private void button2_Click(object sender, EventArgs e)
        {

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


            #region loai tai khoan ke toan voi viewcode ==0
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


            

        }
    }



}

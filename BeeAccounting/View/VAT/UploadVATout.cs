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

    public partial class UploadVATout : Form
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
        public View.Main main1;


        //   public List<ComboboxItem> dataCollectionaccount;

        //  public List<ComboboxItem> dataCollectiongroup;//{ get; private set; }
        //1. Định nghĩa 1 delegate


        class datatoExport
        {
            //public DataGridView dataGrid1 { get; set; }
            public System.Data.DataTable datatble { get; set; } // = new System.Data.DataTable();
        }


     

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
        public UploadVATout(View.Main Main)
        {
            //    this.dataGridView1.DataSource = rs;
            InitializeComponent();
            this.valuesave = valuesave;


            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);


            this.main1 = Main;
            this.db = dc;
            var username  = Utils.getusername().Truncate(50);
            this.rs = from p in dc.tbl_tempVAToutputuploads
                      where p.Username == username
                      select new
                      {
                          Ký_hiệu_hóa_đơn = p.kyhieuhoadon,
                          Số_hóa_đơn = p.sohoadon,
                          Ngày_lập = p.ngayhoadon,
                          MST_người_mua = p.masothuenguoimua,

                          Tên_người_mua = p.tenguoimua,
                          Tổng_tiền_chưa_thuế = p.tientruocvat,
                          Tổng_tiền_thuế = p.vatout,



                      };
                      

            this.dataGridView1.DataSource = rs;
            this.Dtgridview = dataGridView1;

         
           
            this.btketchuyen.Visible = false; 

        
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            main1.clearpannel();
            View.Beemainload main = new Beemainload(main1);

            main1.clearpannelload(main);
        }

        private void bt_themmoi_Click(object sender, EventArgs e)
        {

        }

        private void bt_sua_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Inputexcel ctrtemp = new Model.Inputexcel();

            ctrtemp.inputVatoutput();

            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();

          //  LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            this.rs = from p in dc.tbl_tempVAToutputuploads
                      where p.Username == username
                      select new
                      {
                          Ký_hiệu_hóa_đơn = p.kyhieuhoadon,
                          Số_hóa_đơn = p.sohoadon,
                          Ngày_lập = p.ngayhoadon,
                          MST_người_mua = p.masothuenguoimua,

                          Tên_người_mua = p.tenguoimua,
                          Tổng_tiền_chưa_thuế = p.tientruocvat,
                          Tổng_tiền_thuế = p.vatout,



                      };


            dataGridView1.DataSource = this.rs;
          
        }

        private void formlabel_Click(object sender, EventArgs e)
        {

        }
    }



}

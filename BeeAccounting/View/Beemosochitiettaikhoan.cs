using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEEACCOUNT.Control;

namespace BEEACCOUNT.View
{


    public partial class Beemosochitiettaikhoan : Form
    {
        // public View.CreatenewContract contractnew;
        public string matk { get; set; }
   
        public bool chon { get; set; }
 
        public int machitiet { get; set; }
        public string tenchitiet { get; set; }


        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }


            public override string ToString()
            {
                return Text;
            }
        }


        public Beemosochitiettaikhoan(int manghiepvu, string matk) // manghiepvu = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
        {
            InitializeComponent();
            this.matk = matk;
       
            chon = false;
       


            if (manghiepvu == 4) // xóa + xóa
            {
               
                this.txtcode.Text = matk;
                txtcode.Enabled = false;

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);




                


            }






            if (manghiepvu == 3) // tạo mới
            {
                this.btupdate.Visible = false;
                this.btxoa.Visible = false;





            }




        }

        private void txtCustcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_nametk.Focus();


            }



        }

        private void txt_vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txt_nametk.Focus();


            }

        }

        private void txt_represennt_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void txt_chananame_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    txt_houseno.Focus();


            //}
        }

        private void txt_houseno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    txt_district.Focus();


            //}
        }

        private void txt_district_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //    txt_provicen.Focus();


            }
        }

        private void txt_provicen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //         txt_description.Focus();


            }
        }

        private void txt_description_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                //    vatno.Focus();
                //txtcode.Focus();


            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)///groupced
        {
            //if (cbgroup.Checked == true)
            //{
            //    cbsfa.Checked = false;
            //    cbsapcode.Checked = false;
            //}

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)// safcdeo
        {


            //cbgroup.Checked = !cbsfa.Checked;
            //cbsapcode.Checked = !cbsfa.Checked;


        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)// scapcode
        {
            //if (cbsapcode.Checked == true)
            //{
            //    cbgroup.Checked = false;
            //    cbsfa.Checked = false;
            //}

        }

        private void vatno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{

            //   // vatno.Focus();
            // txtcode.Focus();


            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {

           



            matk = this.txtcode.Text;

            if (this.txtcode.Text == "")
            {
            

                MessageBox.Show("Bạn chưa có  mã tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                    string connection_string = Utils.getConnectionstr();
                    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                    var rs1 = (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                              where tbl_dstaikhoan.matk == matk
                              select tbl_dstaikhoan.matk).FirstOrDefault();

                //    captk = rs + 1;




                if (rs1 != null)
                {
                    MessageBox.Show("Mã tài khoản này đã tồn tại, bạn phải chọn mã tài khoản khác", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                else
                {
                    matk = this.txtcode.Text;

                }


            }


          
             


            if (matk != "")
            {
                chon = true;
                this.Close();
            }



        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

          



        }

        private void cbtkmother_KeyPress(object sender, KeyPressEventArgs e)
        {



        


        }

        private void btxoa_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            var rs1 = (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                       where tbl_dstaikhoan.matk == matk
                       select tbl_dstaikhoan).FirstOrDefault();

            if (rs1 != null)
            {
              var  rs5 = (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                       where tbl_dstaikhoan.matktren == matk
                       select tbl_dstaikhoan).FirstOrDefault();

                if (rs5 != null)
                {
                    MessageBox.Show("Tài khoản này có tài khoản con là TK : " + rs5.matk.Trim() + " , bạn phải xóa tài khoản con trước", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    dc.tbl_dstaikhoans.DeleteOnSubmit(rs1);
                    dc.SubmitChanges();
                    this.Close();
                }

            
            }




        }

        private void btupdate_Click(object sender, EventArgs e)
        {
          

            

            if (matk != "")
            {
                chon = true;
                string connection_string = Utils.getConnectionstr();
                // string urs = Utils.getusername();
                //  var db = new LinqtoSQLDataContext(connection_string);
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                tbl_dstaikhoan tk = new tbl_dstaikhoan();


                //    MeasureItemEventArgs.re
                var rs = (from tbl_dstaikhoan in db.tbl_dstaikhoans
                       where tbl_dstaikhoan.matk == matk
                         //  orderby tbl_dstaikhoan.matk
                         select tbl_dstaikhoan).FirstOrDefault();


                if (rs != null)
                {
                    rs.matk = matk;
             
                
               
             

                    db.SubmitChanges();
                    this.Close();
                }
                //tk.matk = matk;
                //tk.tentk = tentk;
                //tk.loaitkid = loaitk;
                //tk.captk = captk;
                //tk.matktren = tkcaptren;


                //db.tbl_dstaikhoans.InsertOnSubmit(tk);
                //var rs3 = from tbl_dstaikhoan in db.tbl_dstaikhoans
                //          orderby tbl_dstaikhoan.matk

                //          select tbl_dstaikhoan;

                //grviewlisttk.DataSource = rs3;

                //this.grviewlisttk.Columns["matk"].HeaderText = "Mã tài khoản";
                //this.grviewlisttk.Columns["tentk"].HeaderText = "Tên tài khoản";
                //this.grviewlisttk.Columns["loaitkid"].HeaderText = "Loại tài khoản";
                //this.grviewlisttk.Columns["matktren"].HeaderText = "Mã tài khoản cấp trên";



                //grviewlisttk.DataSource = rs;


            }









        }



    }


}

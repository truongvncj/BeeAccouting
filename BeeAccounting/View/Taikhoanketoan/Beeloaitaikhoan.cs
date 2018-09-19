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


    public partial class Beeloaitaikhoan : Form
    {
        // public View.CreatenewContract contractnew;


        public bool chon { get; set; }
        public int id { get; set; }
        public string maloaitk { get; set; }
        public string tenloaitk { get; set; }


        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }


            public override string ToString()
            {
                return Text;
            }
        }


        public Beeloaitaikhoan(int manghiepvu, int id) // manghiepvu = 1 moi; int = 2 sửa ; int = 3 display; int = 4 xoa
        {
            InitializeComponent();
            //    this.matk = matk;

            chon = false;

            if (manghiepvu == 1) // tao moi
            {
                btupdate.Visible = false;
                btxoa.Visible = false;




            }



            if (manghiepvu == 2) //  sửa
            {

                //   btxoa.Visible = false;
                bttaomoi.Visible = false;
                // view showw
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



                var rs1 = (from loaitkketoan in dc.tbl_loaitks
                           where loaitkketoan.id == id
                           select loaitkketoan).FirstOrDefault();




                txttenloaitk.Text = rs1.name;

                foreach (var item in cbmaloaitk.Items)
                {
                    if (item.ToString().Trim() == rs1.idloaitk.Trim())
                    {
                        cbmaloaitk.SelectedItem = item;
                    }
                }
           //     cbmaloaitk.Text = rs1.idloaitk.ToString();
                    this.id = rs1.id;



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


                //     txt_nametk.Focus();


            }



        }

        private void txt_vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                //    txt_nametk.Focus();


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






            //if (matk != "")
            //{
            //    chon = true;
            //    this.Close();
            //}



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



            var rs1 = (from tbl_loaitk in dc.tbl_loaitks
                       where tbl_loaitk.id == this.id
                       select tbl_loaitk).FirstOrDefault();


            dc.tbl_loaitks.DeleteOnSubmit(rs1);
            dc.SubmitChanges();
            this.Close();



        }

        private void btupdate_Click(object sender, EventArgs e)
        {


            chon = true;
            string connection_string = Utils.getConnectionstr();

            var dc = new LinqtoSQLDataContext(connection_string);

            var rs1 = (from loaitkketoan in dc.tbl_loaitks
                       where loaitkketoan.id == id
                       select loaitkketoan).FirstOrDefault();

            if (rs1 != null)
            {
                //      txttenloaitk.Text = rs1.name;
            //    cbmaloaitk.Text = rs1.idloaitk.ToString();

                if (cbmaloaitk.Text.ToString()!= "")
                {
                    rs1.idloaitk = cbmaloaitk.Text.ToString();

                }
                else
                {
                    chon = false;
                    MessageBox.Show("Phải chọn loại tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (txttenloaitk.Text != null && txttenloaitk.Text != "")
                {
                    if (txttenloaitk.Text.ToString().Length > 225)
                    {
                        rs1.name = txttenloaitk.Text.ToString().Substring(225);
                    }
                    else
                    {
                        rs1.name = txttenloaitk.Text.ToString();
                    }

                    chon = true;
                    dc.SubmitChanges();
                    this.Close();



                }
                else
                {
                    chon = false;
                    MessageBox.Show("Tên loại tài khoản chưa được gõ ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }




            }
            else
            {
                chon = false;
                MessageBox.Show("Bạn phải chọn một loại tk để sửa ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //chon = true;
            //string connection_string = Utils.getConnectionstr();
            //// string urs = Utils.getusername();
            ////  var db = new LinqtoSQLDataContext(connection_string);
            //LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            //tbl_loaitk tk = new tbl_loaitk();


            ////    MeasureItemEventArgs.re
            //var rs = (from tbl_loaitk in db.tbl_loaitks
            //          where tbl_loaitk.id == this.idloaitk
            //          //  orderby tbl_dstaikhoan.matk
            //          select tbl_loaitk).FirstOrDefault();


            //if (rs != null)
            //{
            //    rs.idloaitk = this.idloaitk;
            //rs.




            //    db.SubmitChanges();
            //    this.Close();
            //}











        }

        private void bttaomoi_Click(object sender, EventArgs e)
        {

            if (this.cbmaloaitk.Text.ToString() !="")
            {


                //   string urs = Utils.getusername();
                string connection_string = Utils.getConnectionstr();
                //    var db = new LinqtoSQLDataContext(connection_string);
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                var rs1 = (from tbl_loaitkds in db.tbl_loaitks
                           where tbl_loaitkds.idloaitk == cbmaloaitk.Text.ToString()
                           select tbl_loaitkds.idloaitk).FirstOrDefault();
                if (rs1 != null)
                {
                    chon = false;
                    MessageBox.Show("Mã loại tài khoản bị lặp ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbmaloaitk.Focus();
                    return;
                }


                if (this.txttenloaitk.Text.ToString() != "" && this.txttenloaitk.Text.ToString() != null)
                {
                    chon = true;
                    this.maloaitk = cbmaloaitk.Text.ToString();

                    if (txttenloaitk.Text.ToString().Length > 225)
                    {
                        this.tenloaitk = txttenloaitk.Text.ToString().Substring(225);


                    }
                    else
                    {

                        this.tenloaitk = txttenloaitk.Text.ToString().Trim();


                    }

                    this.Close();

                }
                else
                {
                    chon = false;
                    MessageBox.Show("Bạn chưa gõ tên loại tài khoản ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }




            }
            else
            {
                chon = false;
                MessageBox.Show("Phải chọn mã tài khoản ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



        }
    }


}

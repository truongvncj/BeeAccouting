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


    public partial class BeeCreatenewaccount : Form
    {
        // public View.CreatenewContract contractnew;
        public string matk { get; set; }
        public string tentk { get; set; }
        public bool chon { get; set; }
        public bool tkchitiet { get; set; }
        public string loaitk { get; set; }

        public int captk { get; set; }
        public string tkcaptren { get; set; }

        public float nodauky { get; set; }
        public float codauky { get; set; }


        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }


            public override string ToString()
            {
                return Text;
            }
        }


        public BeeCreatenewaccount(int loai, string matk) // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
        {
            InitializeComponent();
            this.matk = matk;
            this.tentk = this.txt_nametk.Text;
            chon = false;
            this.captk = 1;


            #region load loại tk

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);




            var rs2 = from tbl_loaitk in dc.tbl_loaitks

                      select tbl_loaitk;


            //this.cb_customerka.se = cb_customerka.Items.Count+1;
            foreach (var item in rs2)
            {

                ComboboxItem cb1 = new ComboboxItem();
                cb1.Value = item.idloaitk;
                cb1.Text =  item.name; //item.idloaitk.Trim() + ": " +
                this.cbloaitk.Items.Add(cb1); // CombomCollection.Add(cb);
                                              //this.cb_customerka.se = cb_customerka.Items.Count+1;




            }
            this.cbloaitk.SelectedIndex = -1;


            #endregion


            #region load  tk

            //        string connection_string = Utils.getConnectionstr();
            //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);




            var rs = from tbl_dstaikhoan in dc.tbl_dstaikhoans

                     select tbl_dstaikhoan;

            // string drowdownshow = "";

            // string drowdownshow = "";
            ComboboxItem cb = new ComboboxItem();
            cb.Value = "";
            cb.Text = "0   " + ": Không có tài khoản cấp trên";
            this.cbtkmother.Items.Add(cb); // CombomCollection.Add(cb);

            foreach (var item in rs)
            {

                ComboboxItem cb1 = new ComboboxItem();
                cb1.Value = item.matk;
                cb1.Text = item.matk.Trim() + ": " + item.tentk;   //
                this.cbtkmother.Items.Add(cb1); // CombomCollection.Add(cb);
                                                //this.cb_customerka.se = cb_customerka.Items.Count+1;




            }
            this.cbtkmother.SelectedIndex = 0;


            #endregion



            if (loai == 4) // xóa + xóa
            {
                this.btnew.Visible = false;
                this.txtcode.Text = matk;
                txtcode.Enabled = false;

                #region load  tk

                //       string connection_string = Utils.getConnectionstr();
                //     LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);




                var rs1 = (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                           where tbl_dstaikhoan.matk == matk
                           select tbl_dstaikhoan).FirstOrDefault();

                if (rs1 != null)
                {
                    this.txt_nametk.Text = rs1.tentk;

                    if (rs1.loaitkid != null)
                    {
                        foreach (var item in cbloaitk.Items)
                        {
                            if ((string)(item as ComboboxItem).Value == rs1.loaitkid)
                            {
                                this.cbloaitk.SelectedItem = item;
                            }

                        }





                   
                    }
                    
                    this.txtcaptaikhoan.Text = rs1.captk.ToString();

                    this.cbtkmother.Text = rs1.matktren;
                    this.checkbookchitiet.Checked = rs1.loaichitiet;
                    txtCodauky.Text = rs1.codk.ToString();
                    txtNodauky.Text = rs1.nodk.ToString();


                }







                #endregion


                #region select tài khoản cấp trên

                //       string connection_string = Utils.getConnectionstr();
                //     LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);




                var rs3 = (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                           where tbl_dstaikhoan.matk == matk
                           select tbl_dstaikhoan.matktren).FirstOrDefault();

                if (rs3 != null)
                {

                    foreach (var iten in cbtkmother.Items)
                    {
                        if ((string)(iten as ComboboxItem).Value == rs3)
                        {
                            //      loaitk = (int)(cbloaitk.SelectedItem as ComboboxItem).Value;
                            //     cmbEmployeeStatus.SelectedValue = cmbEmployeeStatus.Items.FindByText("text").Value;
                            cbtkmother.SelectedItem = iten;

                            //      cbtkmother.(iten);

                        }
                    }


                    //this.txt_nametk.Text = rs1.tentk;

                    //if (rs1.loaitkid != null)
                    //{
                    //    this.cbtkmother.SelectedIndex = (int)rs1.loaitkid - 1;
                    //}

                    //this.txtcaptaikhoan.Text = rs1.captk.ToString();

                    //this.cbtkmother.Text = rs1.matktren;


                }







                #endregion




            }






            if (loai == 3) // tạo mới
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
            if (e.KeyChar == (char)Keys.Enter)
            {


                cbloaitk.Focus();


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            // nếu không duplicate thì tiết hành add new contract
            if (this.cbloaitk.SelectedItem != null)
            {
                //  newcontract.Channel = this.cb_channel.SelectedItem.ToString();

                loaitk = (string)(cbloaitk.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            }
            else
            {
                MessageBox.Show("Bạn chưa chọn loại tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (Utils.IsValidnumber(txtNodauky.Text))
            {
                nodauky = float.Parse(txtNodauky.Text);
            }
            else
            {
                MessageBox.Show("Bạn kiểm tra lại số dư nợ đầu kỳ ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            if (Utils.IsValidnumber(txtCodauky.Text))
            {
                codauky = float.Parse(txtCodauky.Text);
            }
            else
            {
                MessageBox.Show("Bạn kiểm tra lại số dư có đầu kỳ ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }



            if (this.cbtkmother.SelectedItem != null && this.cbtkmother.SelectedItem.ToString().Trim() != "0")
            {
                //  newcontract.Channel = this.cb_channel.SelectedItem.ToString();

                tkcaptren = (cbtkmother.SelectedItem as ComboboxItem).Value.ToString().Trim();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                          where tbl_dstaikhoan.matk.Trim() == tkcaptren
                          select tbl_dstaikhoan.captk).FirstOrDefault();

                captk = rs + 1;


            }
            else
            {
                tkcaptren = "";
                captk = 1;

                //MessageBox.Show("Bạn chưa chọn tài khoản cấp trên", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            }


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


            tentk = this.txt_nametk.Text;
            if (tentk == "")
            {
                MessageBox.Show("Bạn chưa có tên tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkbookchitiet.Checked == true)
            {
                tkchitiet = true;
            }
            else
            {
                tkchitiet = false;
            }

             


            if (matk != "" && tentk != "" && loaitk !="")
            {
                chon = true;
                this.Close();
            }



        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                cbtkmother.Focus();


            }




        }

        private void cbtkmother_KeyPress(object sender, KeyPressEventArgs e)
        {



            if (e.KeyChar == (char)Keys.Enter)
            {


                btnew.Focus();


            }



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
            //
            // nếu không duplicate thì tiết hành add new contract
            if (this.cbloaitk.SelectedItem != null)
            {
                //  newcontract.Channel = this.cb_channel.SelectedItem.ToString();

                loaitk = (String)(cbloaitk.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            }
            else
            {
                MessageBox.Show("Bạn chưa chọn loại tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Utils.IsValidnumber(txtNodauky.Text))
            {
                nodauky = float.Parse(txtNodauky.Text);
            }
            else
            {
                MessageBox.Show("Bạn kiểm tra lại số dư nợ đầu kỳ ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            if (Utils.IsValidnumber(txtCodauky.Text))
            {
                codauky = float.Parse(txtCodauky.Text);
            }
            else
            {
                MessageBox.Show("Bạn kiểm tra lại số dư có đầu kỳ ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }


            if (this.cbtkmother.SelectedItem != null && this.cbtkmother.SelectedItem.ToString().Trim() != "0")
            {
                //  newcontract.Channel = this.cb_channel.SelectedItem.ToString();

                tkcaptren = (cbtkmother.SelectedItem as ComboboxItem).Value.ToString().Trim();// (cbm.SelectedItem as ComboboxItem).Value.ToString();

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var rs = (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                          where tbl_dstaikhoan.matk.Trim() == tkcaptren
                          select tbl_dstaikhoan.captk).FirstOrDefault();

                captk = rs + 1;


            }
            else
            {
                tkcaptren = "";
                captk = 1;

                //MessageBox.Show("Bạn chưa chọn tài khoản cấp trên", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            }


            matk = this.txtcode.Text;

          


            tentk = this.txt_nametk.Text;
            if (tentk == "")
            {
                MessageBox.Show("Bạn chưa có tên tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (matk != "" && tentk != "" && loaitk !="")
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
                    rs.tentk = tentk;
                    rs.loaitkid = loaitk;
                    rs.captk = captk;
                    rs.matktren = tkcaptren;
                    rs.nodk = nodauky;
                    rs.codk = codauky;
               
                    if (checkbookchitiet.Checked == true)
                    {
                        rs.loaichitiet = true;
                    }
                    else
                    {
                        rs.loaichitiet = false;
                    }

                    db.SubmitChanges();
                    this.Close();
                }
            


            }









        }
    }


}

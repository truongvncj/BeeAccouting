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

namespace BEEACCOUNT.View
{




    public partial class Beemosochitiettaikhoan : Form
    {
        // public View.CreatenewContract contractnew;
        public string matk { get; set; }

        public bool chon { get; set; }
        public int id { get; set; }
        public int machitiet { get; set; }
        public string tenchitiet { get; set; }

        public static IQueryable viewgridloca(string taikhoan)
        {
            // string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            var rs = from dschitiet in dc.tbl_machitiettks
                     where dschitiet.matk == taikhoan
                     select new
                     {
                         Mã_tài_khoản = dschitiet.matk,
                         Tên_tài_khoản_chi_tiết = dschitiet.tenchitiet,
                         Mã_chi_tiết = dschitiet.machitiet,
                         Ghi_chú = dschitiet.ghichu,
                         Nợ_đầu_kỳ = dschitiet.nodk,
                         Có_đầu_kỳ = dschitiet.codk,
                         ID = dschitiet.id
                     };
            // this.dataGridView1.DataSource = rs;
            return rs;

        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }


            public override string ToString()
            {
                return Text;
            }
        }


        public Beemosochitiettaikhoan(int manghiepvu, string matk, int id) // manghiepvu = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
        {
            InitializeComponent();
            this.matk = matk;
            this.id = id;
            chon = false;

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            #region  load tai khoan




            var rs1 = from tk in dc.tbl_dstaikhoans
                      where tk.loaichitiet == true
                      select tk;

            //      string drowdownshow = "";

            foreach (var item in rs1)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.matk.Trim();
                cb.Text = item.matk.Trim() + ": " + item.tentk;
                this.cbtkno.Items.Add(cb); // CombomCollection.Add(cb);

            }




            #endregion load tai khoan



            if (matk != "")  // select mataikhoan
            {


                ComboboxItem value = new ComboboxItem();
                //  cbtkno.SelectedValue = matk.Trim();
                value = null;
                foreach (var item in cbtkno.Items)
                {
                    if (matk == (item as ComboboxItem).Value.ToString())
                    {
                        value = (ComboboxItem)item;
                    }
                }

                if (value != null)
                {
                    cbtkno.SelectedIndex = cbtkno.Items.IndexOf(value);
                }




            }


            #region ma nghiep vu 1


            if (manghiepvu == 1) // tạo mới
            {
                this.btupdate.Visible = false;
                this.btxoa.Visible = false;





            }

            #endregion ma nghiep vu 1



            #region ma nghiep vu 2 sửa xóa





            if (manghiepvu == 2) // xóa + xóa
            {

                this.bt_taomoi.Visible = false;



                var machitiet = (from tkctiet in dc.tbl_machitiettks
                                 where tkctiet.id == this.id
                                 select tkctiet).FirstOrDefault();


                if (machitiet != null)
                {
                    #region  select lại

                    ////   if (matk != "")  // select mataikhoan
                    //  {


                    ComboboxItem value = new ComboboxItem();
                    //  cbtkno.SelectedValue = matk.Trim();
                    value = null;
                    foreach (var item in cbtkno.Items)
                    {
                        if (machitiet.matk == (item as ComboboxItem).Value.ToString())
                        {
                            value = (ComboboxItem)item;
                        }
                    }

                    if (value != null)
                    {
                        cbtkno.SelectedIndex = cbtkno.Items.IndexOf(value);
                    }





                    //// }




                    #endregion


                    txtmachitiet.Text = machitiet.machitiet.ToString();

                    if (machitiet.tenchitiet != null)
                    {
                        txttenchitettaikhoan.Text = machitiet.tenchitiet.ToString();

                    }


                    if (machitiet.ghichu != null)
                    {
                        txtghichu.Text = machitiet.ghichu.ToString();
                    }

                    txtNodauky.Text = machitiet.nodk.ToString();

                    txtCodauky.Text = machitiet.codk.ToString();






                }
                else
                {
                    MessageBox.Show("Bạn phải chọn một chi tiết tài khoản để sửa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }





            }

            #endregion ma nghiep vu 2 



            #region load detail detail of code

            if (cbtkno.SelectedItem != null)
            {
                string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
                this.matk = taikhoan;
                var rs = viewgridloca(taikhoan);

                dataGridView1.DataSource = rs;


            }



            //        newcontract.Customer = double.Parse(txtfindsacode.Text.Trim());// (cbm.SelectedItem as ComboboxItem).Value.ToString();
            //        newcontract.CustomerType = "SFA";



            #endregion








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


            var machitiet = (from c in dc.tbl_machitiettks
                             where c.id == this.id
                             select c).FirstOrDefault();

            if (machitiet != null)
            {
                this.matk = machitiet.matk;
                dc.tbl_machitiettks.DeleteOnSubmit(machitiet);
                dc.SubmitChanges();
                var rs = viewgridloca(this.matk);

                dataGridView1.DataSource = rs;

                try
                {
                    if (this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value != null)
                    {
                        this.id = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;

                        #region view lại de tail ben tren

                        var chitietma = (from tkctiet in dc.tbl_machitiettks
                                         where tkctiet.id == this.id
                                         select tkctiet).FirstOrDefault();


                        if (chitietma != null)
                        {


                            txtmachitiet.Text = chitietma.machitiet.ToString();

                            if (chitietma.tenchitiet != null)
                            {
                                txttenchitettaikhoan.Text = chitietma.tenchitiet.ToString();

                            }


                            if (chitietma.ghichu != null)
                            {
                                txtghichu.Text = chitietma.ghichu.ToString();
                            }


                            if (chitietma.codk != null)
                            {
                                txtCodauky.Text = chitietma.codk.ToString();
                            }
                            if (chitietma.nodk != null)
                            {
                                txtNodauky.Text = chitietma.nodk.ToString();
                            }




                        }






                        #endregion


                    }
                }
                catch (Exception)
                {

                    // throw;
                }


            }






        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            var tkchitiet = (from matkchitiet in db.tbl_machitiettks
                             where matkchitiet.id == this.id
                             select matkchitiet).FirstOrDefault();

            if (tkchitiet != null)
            {




                #region  ten chi tiet 
                if (txttenchitettaikhoan.Text != null && txttenchitettaikhoan.Text != "")
                {

                    tkchitiet.tenchitiet = txttenchitettaikhoan.Text;

                    //  taikhoanchon = txttenchitettaikhoan.Text;
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản chi tiết ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttenchitettaikhoan.Focus();
                    return;
                }

                #endregion ten chi tiet ma chi tiet



                #region  ten tai khoan chi tiet
                if ((cbtkno.SelectedItem as ComboboxItem).Value != null)
                {
                    tkchitiet.matk = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
                    tkchitiet.ghichu = txtghichu.Text;
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn tài khoản theo dõi chi tiết", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbtkno.Focus();
                    return;
                }




                #endregion




                if (Utils.IsValidnumber(txtNodauky.Text))
                {
                    tkchitiet.nodk = float.Parse(txtNodauky.Text);
                }
                else
                {
                    MessageBox.Show("Bạn kiểm tra lại số dư nợ đầu kỳ ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (Utils.IsValidnumber(txtCodauky.Text))
                {
                    tkchitiet.codk = float.Parse(txtCodauky.Text);
                }
                else
                {
                    MessageBox.Show("Bạn kiểm tra lại số dư nợ đầu kỳ ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                db.SubmitChanges();

                var rs3 = viewgridloca(this.matk);
                dataGridView1.DataSource = rs3;


            }

            //View.Beemosochitiettaikhoan loaitkform = new View.Beemosochitiettaikhoan(2, "", 0); // 1 la nghiep vu them moi
            //loaitkform.ShowDialog();


            //bool chon = loaitkform.chon;





        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

            foreach (var c in dataGridView1.Columns)
            {
                DataGridViewColumn clm = (DataGridViewColumn)c;
                clm.HeaderText = clm.HeaderText.Replace("_", " ");
            }

        }

        private void cbtkno_SelectionChangeCommitted(object sender, EventArgs e)
        {

            #region load detail detail of code
            string taikhoan = (cbtkno.SelectedItem as ComboboxItem).Value.ToString();
            this.matk = taikhoan;


            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            tbl_dstaikhoan tk = new tbl_dstaikhoan();

            //var rs = from dschitiet in db.tbl_machitiettks
            //         where dschitiet.matk == taikhoan
            //         select new
            //         {
            //             Mã_tài_khoản = dschitiet.matk,
            //             Tên_tài_khoản_chi_tiết = dschitiet.tenchitiet,
            //             Mã_chi_tiết = dschitiet.machitiet,
            //             Ghi_chú = dschitiet.ghichu,
            //             ID = dschitiet.id
            //         };

            var rs = viewgridloca(taikhoan);
            dataGridView1.DataSource = rs;


            try
            {
                this.id = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;


                #region view lại de tail ben tren

                var chitietma = (from tkctiet in db.tbl_machitiettks
                                 where tkctiet.id == this.id
                                 select tkctiet).FirstOrDefault();


                if (chitietma != null)
                {


                    txtmachitiet.Text = chitietma.machitiet.ToString();

                    if (chitietma.tenchitiet != null)
                    {
                        txttenchitettaikhoan.Text = chitietma.tenchitiet.ToString();

                    }


                    if (chitietma.ghichu != null)
                    {
                        txtghichu.Text = chitietma.ghichu.ToString();
                    }






                }






                #endregion



            }
            catch (Exception)
            {
                this.id = -1;
                txtmachitiet.Text = "";

                txttenchitettaikhoan.Text = "";


                txtghichu.Text = "";

            }



            #endregion


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string taikhoanchon = "";
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            tbl_machitiettk tkchitiet = new tbl_machitiettk();


            if (Utils.IsValidnumber(txtmachitiet.Text))
            {




                #region ma chi tiet tai khoa



                var rs = (from dschitiet in db.tbl_machitiettks
                          where dschitiet.machitiet == int.Parse(txtmachitiet.Text) &&
                                 dschitiet.matk.Trim() == (cbtkno.SelectedItem as ComboboxItem).Value.ToString().Trim()
                          select dschitiet).FirstOrDefault();
                //   MessageBox.Show(rs.machitiet.ToString());
                if (rs == null)
                {


                    tkchitiet.machitiet = int.Parse(txtmachitiet.Text.ToString());


                }
                else
                {
                    MessageBox.Show("Mã chi tiết bị lặp cần xem lại ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtmachitiet.Focus();
                    return;
                }


            }
            else
            {
                MessageBox.Show("Mã tài chi tiết tài khoản phải là số ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmachitiet.Focus();
                return;
            }




            #endregion ma chi tiet tai khoan

            #region  ten chi tiet 
            if (txttenchitettaikhoan.Text != null && txttenchitettaikhoan.Text != "")
            {

                tkchitiet.tenchitiet = txttenchitettaikhoan.Text.Truncate(50);

                taikhoanchon = txttenchitettaikhoan.Text;
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản chi tiết ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenchitettaikhoan.Focus();
                return;
            }

            #endregion ten chi tiet ma chi tiet



            #region  ten tai khoan chi tiet
            if ((cbtkno.SelectedItem as ComboboxItem).Value != null)
            {
                tkchitiet.matk = (cbtkno.SelectedItem as ComboboxItem).Value.ToString().Truncate(50);
                tkchitiet.ghichu = txtghichu.Text.Truncate(225);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài khoản theo dõi chi tiết", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbtkno.Focus();
                return;
            }




            #endregion

            if (Utils.IsValidnumber(txtNodauky.Text))
            {
                tkchitiet.nodk = float.Parse(txtNodauky.Text);
            }
            else
            {
                MessageBox.Show("Bạn kiểm tra lại số dư nợ đầu kỳ ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            if (Utils.IsValidnumber(txtCodauky.Text))
            {
                tkchitiet.codk = float.Parse(txtCodauky.Text);
            }
            else
            {
                MessageBox.Show("Bạn kiểm tra lại số dư nợ đầu kỳ ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            #region  insernew

            db.tbl_machitiettks.InsertOnSubmit(tkchitiet);
            db.SubmitChanges();

            txttenchitettaikhoan.Text = "";
            txtmachitiet.Text = "";
            txtghichu.Text = "";

            //var rs1 = from dschitiet in db.tbl_machitiettks
            //          where dschitiet.matk.Trim() == (cbtkno.SelectedItem as ComboboxItem).Value.ToString()
            //          select new
            //          {
            //              Mã_tài_khoản = dschitiet.matk,
            //              Tên_tài_khoản_chi_tiết = dschitiet.tenchitiet,
            //              Mã_chi_tiết = dschitiet.machitiet,
            //              Ghi_chú = dschitiet.ghichu,
            //              ID = dschitiet.id
            //          };

            var rs1 = viewgridloca((cbtkno.SelectedItem as ComboboxItem).Value.ToString());

            dataGridView1.DataSource = rs1;

            #endregion insernew









        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            if (this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value != null)
            {
                this.id = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;

                #region view lại de tail ben tren

                var machitiet = (from tkctiet in db.tbl_machitiettks
                                 where tkctiet.id == this.id
                                 select tkctiet).FirstOrDefault();


                if (machitiet != null)
                {


                    txtmachitiet.Text = machitiet.machitiet.ToString();

                    if (machitiet.tenchitiet != null)
                    {
                        txttenchitettaikhoan.Text = machitiet.tenchitiet.ToString();

                    }


                    if (machitiet.ghichu != null)
                    {
                        txtghichu.Text = machitiet.ghichu.ToString();
                    }



                    if (machitiet.codk != null)
                    {
                        txtCodauky.Text = machitiet.codk.ToString();
                    }
                    else
                    {
                        txtCodauky.Text = "0";
                    }

                    if (machitiet.nodk != null)
                    {
                        txtNodauky.Text = machitiet.nodk.ToString();
                    }
                    else
                    {
                        txtNodauky.Text = "0";
                    }





                }






                #endregion


            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtmachitiet_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txttenchitettaikhoan.Focus();


            }

        }

        private void txttenchitettaikhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtghichu.Focus();


            }

        }

        private void txtghichu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtNodauky.Focus();


            }
        }

        private void txtNodauky_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtCodauky.Focus();


            }
        }

        private void txtCodauky_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmachitiet.Focus();


            }
        }
    }


}

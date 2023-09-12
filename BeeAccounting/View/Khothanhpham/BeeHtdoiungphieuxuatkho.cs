using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BEEACCOUNT.View
{
    public partial class BeeHtdoiungphieuxuatkho : Form
    {
        //    View.BeePhieuThu phieuchi;
        View.BeeKhophieuxuat phieuxuatkho;
        //  public int tkcochitiet { get; set; }
        public float giasanphamxuat { get; set; }

        public string masanpham { get; set; }
        public bool click { get; set; }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        //   public double pssotienno { get; set; }
        public double sotien { get; set; }

        public BeeHtdoiungphieuxuatkho(View.BeeKhophieuxuat phieuxuatkho, string labe1, string labe2, string labe3)
        {




            InitializeComponent();
            this.masanpham = "";

            this.sotien = phieuxuatkho.sotien;

            //   txtChenlech.Text = (this.pssotienno - this.pssotienco).ToString("#,#", CultureInfo.InvariantCulture);

            #region clearr to new

            cbmasanpham.SelectedIndex = -1;
            //tbmachitiet.Text = "";
            //lbtenchitiet.Text = "";
            //txtsotien.Text = "";
            //txtdiachi.Text = "";
            //      txtkyhieuctu.Text = "";
            //     txtsochungtu.Text = "";

            #endregion




            this.click = false;
            this.phieuxuatkho = phieuxuatkho;



            #region load tk nợ

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            tbl_loaitk tkkt = new tbl_loaitk();

            var rs1 = from p in dc.tbl_kho_sanphams
                      //   where tk.loaitkid == "nguonvon" || tk.loaitkid == "phaitra" || tk.loaitkid == "tamung"  // 5.nguon von;  7 phai tra; 9. tam ung
                      select p;

            //      string drowdownshow = "";

            //            tien
            //kho
            //taisan
            //nguonvon
            //doanhthu
            //chiphi
            //xacdinhkqkd
            //loinhuan
            //phaithu
            //phaichi
            //tamung

            foreach (var item in rs1)
            {
                ComboboxItem cb = new ComboboxItem();
                cb.Value = item.masp;
                cb.Text = item.masp.Trim() + ":" + item.tensp;
                this.cbmasanpham.Items.Add(cb); // CombomCollection.Add(cb);

            }

            #endregion load tk nợ





        }




        private void Seachcode_Deactivate(object sender, EventArgs e)
        {
            //   this.Close();
        }


        public void sendingtext_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void sendingcontract_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //    txt03.Focus();

            //    //if (tablename == "KASeachcontract")
            //    //{
            //    //   // Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    //}



            //}
        }

        private void sendingname_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtvat_KeyPress(object sender, KeyPressEventArgs e)
        {
            //   if (e.KeyChar == (char)Keys.Enter)
            //   {


            //       this.text01.Focus();

            ////       if (tablename == "KASeachcontract")
            ////       {
            //////           Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            ////       }



            //   }
        }


        private void bt_timkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{


            //       this.text01.Focus();
            //   // this.bt_timkiem.Focus();

            //    //if (tablename == "KASeachcontract")
            //    //{
            //    //  //  Fromviewable.ReloadKASeachcontract(this.sendingcode.Text, this.sendingcontract.Text, this.sendingname.Text, this.txtvat.Text);
            //    //}



            //}
        }

        private void BeeHtoansocaidoiungphieuthu_Load(object sender, EventArgs e)
        {

        }

        private void cbtkco_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //   lbtenchitiet.Visible = true;

            string masanpham = (cbmasanpham.SelectedItem as ComboboxItem).Value.ToString();
            //     this.matk = taikhoan;


            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);


            var sp = (from c in db.tbl_kho_sanphams
                      where c.masp.Trim() == masanpham.Trim()
                      select c).FirstOrDefault();


            if (sp != null)
            {

                txttensanpham.Text = sp.tensp;
                txtdonvi.Text = sp.donvi;




            }







        }

        //private void txtsotien_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        //  cbsophieu.
        //        e.Handled = true;
        //        txtdiachi.Focus();

        //        //    string valueinput = cb_customerka.Text;

        //        //    string connection_string = Utils.getConnectionstr();
        //        //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

        //        //    string username = Utils.getusername();


        //    }
        //}

        private void txtdiachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                //    datepickngayphieu.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void datepickngayphieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                //       txtkyhieuctu.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txtkyhieuctu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                //       txtsochungtu.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txtsochungtu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                bt_themvao.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txtsotien_TextChanged(object sender, EventArgs e)
        {
            //if (!Utils.IsValidnumber(txtsotien.Text.ToString()))
            //{
            //    txtsotien.Text = "";
            //}

        }

        private void bt_themvao_Click(object sender, EventArgs e)
        {
            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            tbl_kho_phieunhapxuat_detail sanpham = new tbl_kho_phieunhapxuat_detail();

            //if (this.cb_channel.SelectedItem != null)
            if (cbmasanpham.SelectedItem != null)
            {
                sanpham.mahang = (cbmasanpham.SelectedItem as ComboboxItem).Value.ToString();

            }
            else
            {
                MessageBox.Show("Bạn chưa chọn mã sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbmasanpham.Focus();
                return;
            }

            if (Utils.IsValidnumber(txtsoluong.Text))
            {
                sanpham.donvi = txtdonvi.Text;
                sanpham.tenhang = txttensanpham.Text;
                sanpham.soluong = double.Parse(txtsoluong.Text.Trim());
            }
            else
            {
                MessageBox.Show("Số lượng phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsoluong.Focus();
                return;
            }


            sanpham.mahang = this.masanpham;




            this.phieuxuatkho.add_detailGridviewPXkho(sanpham);

            //       txtTongco.Text = phieunhapkho.pssotienco.ToString("#,#", CultureInfo.InvariantCulture);
            //  this.pssotienco = phieunhapkho.pssotienco;
            //        this.pssotienno = phieunhapkho.pssotienno;

            //      txtChenlech.Text = (this.pssotienno - this.pssotienco).ToString("#,#", CultureInfo.InvariantCulture);

            #region clearr to new

            cbmasanpham.SelectedIndex = -1;
            this.masanpham = "";
            txtmasanpham.Text = "";
            txtmasanpham.Focus();
           

            #endregion






        }

        private void BeeHtoansocaidoiungphieuthu_Deactivate(object sender, EventArgs e)
        {
            // this.Close();
        }

        private void bt_themvao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                e.Handled = true;
                bt_themvao.Focus();




            }



        }

        private void cbmasanpham_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                txtsoluong.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {







        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {





        }

        private void txtdongia_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                //  cbsophieu.
                e.Handled = true;
                txtsoluong.Focus();

                //    string valueinput = cb_customerka.Text;

                //    string connection_string = Utils.getConnectionstr();
                //    LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

                //    string username = Utils.getusername();


            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtmasanpham_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                string seaching = txtmasanpham.Text.Trim();
                var sanpham = from c in db.tbl_kho_sanphams
                              where c.masp == seaching
                              && c.makho == phieuxuatkho.makho
                              select c;
                if (sanpham.Count() == 1) // neu có mã san pham do thi khong tim nưa
                {

                }
                else
                {
                   

                    var dssanpham = from c in db.tbl_kho_sanphams
                                    where c.masp.Contains(seaching)
                                     && c.makho == phieuxuatkho.makho
                                    select new {
                                        c.id,
                                       
                                    Mã_sản_phẩm = c.masp,
                                    Tên_sản_phẩm =c.tensp,

                                    };

                    if (dssanpham.Count() > 0)
                    {
                        Beeviewandchoose dsanphamchon = new Beeviewandchoose("CHỌN SẢN PHẨM", dssanpham, db);
                        dsanphamchon.ShowDialog();
                        int idsanpham = dsanphamchon.value;
                        bool kq = dsanphamchon.kq;


                        if (kq)
                        {
                            var sanphamchon = (from c in db.tbl_kho_sanphams
                                               where c.id == idsanpham
                                               select c).FirstOrDefault();


                            txtmasanpham.Text = sanphamchon.masp;
                            txttensanpham.Text = sanphamchon.tensp;
                            txtdonvi.Text = sanphamchon.donvi;
                            this.masanpham = sanphamchon.masp;

                            var pptinhgiaxuat = from c in db.tbl_khohangs
                                                where c.PPtinhgiaxuat == "dichdanh"
                                 && c.makho == phieuxuatkho.makho
                                                select c;



                            if (pptinhgiaxuat != null) // là la tính giá theo ppp đich danh
                            {
                                //     this.giasanphamxuat
                                var dshangton = (from c in db.tbl_kho_sanphams
                                                 where c.id == idsanpham
                                                 select c);

                                Beeviewandchoose danhmuchangton = new Beeviewandchoose("CHỌN MẶT HÀNG XUẤT", dshangton, db);
                                danhmuchangton.ShowDialog();
                                int idhangton = dsanphamchon.value;
                                bool kq2 = dsanphamchon.kq;


                                if (kq2)
                                {

                                    // doan nay updaet giá và chọn giá
                                }



                            }

                            txtsoluong.Focus();
                        }//chon san p
                        else
                        {
                            txtmasanpham.Text = "";
                            txttensanpham.Text = "";
                            txtdonvi.Text = "";
                            this.masanpham = "";
                            txtmasanpham.Focus();


                           
                        }


                    }


                }
            }
        }//end 



        // /------------------
    }
}

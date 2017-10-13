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
    public partial class BeeHtdoiungphieunhapkho : Form
    {
    //    View.BeePhieuThu phieuchi;
        View.BeeKhophieunhap phieunhapkho;
        public int tkcochitiet { get; set; }
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

        public double pssotienno { get; set; }
        public double pssotienco { get; set; }

        public BeeHtdoiungphieunhapkho(View.BeeKhophieunhap phieunhapkho, string labe1, string labe2, string labe3)
        {




            InitializeComponent();
            //if (phieuthu.pssotienno =="")
            //{
            //    phieuthu.pssotienno = "0";
            //}
            //if (phieuthu.pssotienco == "")
            //{
            //    phieuthu.pssotienco = "0";
            //}
            //txtTongno.Text = phieunhapkho.pssotienno.ToString("#,#", CultureInfo.InvariantCulture);
            //txtTongco.Text = phieunhapkho.pssotienco.ToString("#,#", CultureInfo.InvariantCulture);
            this.pssotienco = phieunhapkho.pssotienco;
            this.pssotienno = phieunhapkho.pssotienno;

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
         this.phieunhapkho = phieunhapkho;



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


            tbl_Socai socaitemp = new tbl_Socai();

            //if (this.cb_channel.SelectedItem != null)
            if (cbmasanpham.SelectedItem != null)
            {
                socaitemp.TkCo = (cbmasanpham.SelectedItem as ComboboxItem).Value.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài khoản", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbmasanpham.Focus();
                return;
            }

            //if (Utils.IsValidnumber(txtsotien.Text))
            //{
            //    socaitemp.PsCo = double.Parse(txtsotien.Text.Trim());
            //}
            //else
            //{
            //    MessageBox.Show("Số tiền gõ vào phải là số !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtsotien.Focus();
            //    return;
            //}



            // txtdiachi

            //if (txtdiachi.Text != "")
            //{
            //    socaitemp.Diengiai = txtdiachi.Text;
            //}
            //else
            //{
            //    MessageBox.Show("Bạn chưa gõ diễn giải", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtdiachi.Focus();
            //    return;
            //}
            //datepickngayphieu

       //     socaitemp.Ngayctu = datepickngayphieu.Value;

            //     txtkyhieuctu
      //      if (txtkyhieuctu.Text != "")
      //      {
      //          socaitemp.Kyhieuctu = txtkyhieuctu.Text;
     //       }
            //else
            //{
            //    MessageBox.Show("Bạn chưa gõ Tên chi tiét", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtkyhieuctu.Focus();
            //    return;
            //}

            ////lbtenchitiet
            //if (lbtenchitiet.Text != "")
            //{
            //    socaitemp.tenchitietCo = lbtenchitiet.Text;
            //}
            ////else
            ////{
            //    MessageBox.Show("Bạn chưa gõ mã chi tiết", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtkyhieuctu.Focus();
            //    return;
            //}


            // tbmachitiet

            //if (tbmachitiet.Text != "")
            //{
            //    socaitemp.MaCTietTKCo = int.Parse(tbmachitiet.Text.ToString());
            //}



            //   txtsochungtu


       //     if (Utils.IsValidnumber(txtsochungtu.Text))
      //      {
      //          socaitemp.Soctu = int.Parse(txtsochungtu.Text.Trim());
      //      }
            //else
            //{
            //    MessageBox.Show("Kiểm tra lại số chứng từ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtsochungtu.Focus();
            //    return;
            //}




            this.phieunhapkho.add_detailGridviewPNkho(socaitemp);

     //       txtTongco.Text = phieunhapkho.pssotienco.ToString("#,#", CultureInfo.InvariantCulture);
            this.pssotienco = phieunhapkho.pssotienco;
            this.pssotienno = phieunhapkho.pssotienno;

      //      txtChenlech.Text = (this.pssotienno - this.pssotienco).ToString("#,#", CultureInfo.InvariantCulture);

            #region clearr to new

            cbmasanpham.SelectedIndex = -1;
       //     tbmachitiet.Text = "";
      //      lbtenchitiet.Text = "";
        //    txtsotien.Text = "";
        //    txtdiachi.Text = "";
       //     txtkyhieuctu.Text = "";
        //    txtsochungtu.Text = "";

            #endregion






        }

        private void BeeHtoansocaidoiungphieuthu_Deactivate(object sender, EventArgs e)
        {
           // this.Close();
        }
    }
}

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


    public partial class fdanhsachsanphamsx : Form
    {
        // public View.CreatenewContract contractnew;
       
       
        public int id { get; set; }
        public string masp { get; set; }
        public string tensp { get; set; }
        public string donvi { get; set; }
        public string PPtinhgiasx { get; set; }
        public string PPspdodang { get; set; }

        public string maphanxuong { get; set; }
        
        public string manhamay { get; set; }
       
      
        public bool chon { get; set; }


        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }


            public override string ToString()
            {
                return Text;
            }
        }


        public fdanhsachsanphamsx(int loai, int idsanpham) // int = 1 xóa; int = 2 sửa ; int = 3 tao mới; int = 4 vừa sửa+ xóa
        {
            InitializeComponent();

            chon = false;


            #region load cb pp tính gia tri hang ton kho


            ComboboxItem cb1 = new ComboboxItem();
            cb1.Value = "nvlc/nvlTT";
            cb1.Text = "Đánh giá sp dở dang theo NVL chính/ NVL trực tiếp";
            this.txtcbpptinhDD.Items.Add(cb1);
            ComboboxItem cb2 = new ComboboxItem();
            cb2.Value = "giatriHTtuongduong";
            cb2.Text = "Đánh giá theo sản lượng hoàn thành tương đương";
            this.txtcbpptinhDD.Items.Add(cb2);

            ComboboxItem cb3 = new ComboboxItem();
            cb3.Value = "CFsxdinhmuc";
            cb3.Text = "Đánh giá sản phẩm dở dang theo chi phí sản xuất định mức";
            this.txtcbpptinhDD.Items.Add(cb3);


            #endregion load tk nợ


            #region load cb pp tính gia thanhsanpham


            ComboboxItem cb4 = new ComboboxItem();
            cb4.Value = "PPgiandon";
            cb4.Text = "Phương pháp tính giá giản đơn";
            this.txtcbpptinnhTP.Items.Add(cb4);
            ComboboxItem cb5 = new ComboboxItem();
            cb5.Value = "PPheso";
            cb5.Text = "Phương pháp tính giá theo phương pháp hệ số";
            this.txtcbpptinnhTP.Items.Add(cb5);

            ComboboxItem cb6 = new ComboboxItem();
            cb6.Value = "PPtyle";
            cb6.Text = "Phương pháp tính giá thành theo tỷ lệ";
            this.txtcbpptinnhTP.Items.Add(cb6);


            ComboboxItem cb7 = new ComboboxItem();
            cb7.Value = "ppphanbuoctuantu50";
            cb7.Text = "Tính giá theo PP phân bước kết chuyển tuần tự 50% thành phẩm";
            this.txtcbpptinnhTP.Items.Add(cb7);

            ComboboxItem cb8 = new ComboboxItem();
            cb8.Value = "ppphanbuocsongsong";
            cb8.Text = "Tính giá theo PP phân bước kết chuyển song song";
            this.txtcbpptinnhTP.Items.Add(cb8);


            #endregion load tk nợ




            this.id = idsanpham;

            if (loai == 4) // xóa + sua
            {
                this.btnew.Visible = false;
                //  this.txtmaNCC.Text = makhachhang;
                txtmasanpham.Text = idsanpham.ToString();
                txtmasanpham.Enabled = false;

                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


                var item = (from p in dc.tbl_sx_sanphams
                            where p.id == idsanpham
                            select p).FirstOrDefault();

                if (item != null)
                {
                   

                    txtmasanpham.Text = item.masp;
                    txttensanpham.Text = item.tensp;
                    txtdonvi.Text = item.donvi;


                    #region ma phan xuong

                    foreach (var sp in txtcbphanxuong.Items)
                    {

                        if ((string)(sp as ComboboxItem).Value == item.maphanxuong)
                        {
                            //      loaitk = (int)(cbloaitk.SelectedItem as ComboboxItem).Value;
                            //     cmbEmployeeStatus.SelectedValue = cmbEmployeeStatus.Items.FindByText("text").Value;

                            txtcbphanxuong.SelectedItem = sp;
                            //      cbtkmother.(iten);

                        }



                    }
                    #endregion

                    #region ma phan pp tinh dd
                    foreach (var sp in txtcbpptinhDD.Items)
                     {

                         if ((string)(sp as ComboboxItem).Value == item.PPspdodang)
                         {
                             //      loaitk = (int)(cbloaitk.SelectedItem as ComboboxItem).Value;
                             //     cmbEmployeeStatus.SelectedValue = cmbEmployeeStatus.Items.FindByText("text").Value;

                             txtcbpptinhDD.SelectedItem = sp;
                             //      cbtkmother.(iten);

                         }



                     }

                    #endregion

                    #region ma phan pp tinh gia sx
                    foreach (var sp1 in txtcbpptinnhTP.Items)
                     {

                         if ((string)(sp1 as ComboboxItem).Value == item.PPtinhgiasx)
                         {
                             //      loaitk = (int)(cbloaitk.SelectedItem as ComboboxItem).Value;
                             //     cmbEmployeeStatus.SelectedValue = cmbEmployeeStatus.Items.FindByText("text").Value;

                             txtcbpptinnhTP.SelectedItem = sp1;
                             //      cbtkmother.(iten);

                         }



                     }
                    #endregion





                }


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


                txttensanpham.Focus();


            }



        }






        private void btxoa_Click(object sender, EventArgs e)
        {

            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);



            var rs1 = (from p in dc.tbl_sx_dsphanxuongs
                       where p.id == this.id
                       select p).FirstOrDefault();

            if (rs1 != null)
            {

                dc.tbl_sx_dsphanxuongs.DeleteOnSubmit(rs1);
                dc.SubmitChanges();
                this.Close();


            }




        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            //




            this.masp = this.txtmasanpham.Text;
            this.tensp = this.txttensanpham.Text;
            donvi = txtdonvi.Text;


          

            


          //  this.ghichu = txtghichu.Text;


        



            if (masp == "")
            {
                MessageBox.Show("Bạn chưa có mã sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (donvi == "")
            {
                MessageBox.Show("Bạn chưa có đơn vị ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


           

            if (txtcbphanxuong.SelectedItem != null)
            {
                this.maphanxuong = (string)(txtcbphanxuong.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            }
            else
            {
                MessageBox.Show("Kiểm tra lựa chọn phân xưởng !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtcbpptinhDD.SelectedItem != null)
            {
                this.PPspdodang = (string)(txtcbpptinhDD.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            }
            else
            {
                MessageBox.Show("Kiểm tra lựa chọn phương pháp tính giá hàng dở dang !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtcbpptinnhTP.SelectedItem != null)
            {
                this.PPtinhgiasx = (string)(txtcbpptinnhTP.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            }
            else
            {
                MessageBox.Show("Kiểm tra lựa chọn phương pháp tính giá thành sản phẩm !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (masp != "")
            {
                chon = true;
                string connection_string = Utils.getConnectionstr();
                LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

                //   tbl_dstaikhoan tk = new tbl_dstaikhoan();


                //    MeasureItemEventArgs.re
                var rs = (from p in db.tbl_sx_sanphams
                          where p.masp == masp
                          //  orderby tbl_dstaikhoan.matk
                          select p).FirstOrDefault();


                if (rs != null)
                {

                    rs.masp = this.masp;// = this.txtmaNCC.Text;
                    rs.tensp = this.tensp;// this.txttenNCC.Text;
                    rs.maphanxuong = this.maphanxuong;// this.txttenNCC.Text;
                
                    rs.donvi = this.donvi;
                    rs.PPspdodang = PPspdodang;
                    rs.PPtinhgiasx = PPtinhgiasx;


                

                    db.SubmitChanges();
                    this.Close();
                }



            }









        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnew_Click(object sender, EventArgs e)
        {
            if (txtmasanpham.Text == "")
            {
                MessageBox.Show("Bạn kiểm tra mã sản phẩm", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          


            if (txtcbphanxuong.SelectedItem != null)
            {
                this.maphanxuong = (string)(txtcbphanxuong.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            }
            else
            {
                MessageBox.Show("Kiểm tra lựa chọn phân xưởng !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtcbpptinhDD.SelectedItem != null)
            {
                this.PPspdodang = (string)(txtcbpptinhDD.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            }
            else
            {
                MessageBox.Show("Kiểm tra lựa chọn phương pháp tính giá hàng dở dang !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtcbpptinnhTP.SelectedItem != null)
            {
                this.PPtinhgiasx = (string)(txtcbpptinnhTP.SelectedItem as ComboboxItem).Value;// (cbm.SelectedItem as ComboboxItem).Value.ToString();

            }
            else
            {
                MessageBox.Show("Kiểm tra lựa chọn phương pháp tính giá thành sản phẩm !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

       
            this.masp = this.txtmasanpham.Text;
            this.tensp = this.txttensanpham.Text;

            
        




            chon = true;
            string connection_string = Utils.getConnectionstr();
            LinqtoSQLDataContext db = new LinqtoSQLDataContext(connection_string);

            tbl_sx_sanpham p = new tbl_sx_sanpham();


            p.masp = this.masp;// = this.txtmaNCC.Text;
            p.tensp = this.tensp;
            p.donvi = this.donvi;// this.txttenNCC.Text;
           

            p.maphanxuong = this.maphanxuong;
            p.PPtinhgiasx = this.PPtinhgiasx;
            p.PPspdodang = this.PPspdodang;



            db.tbl_sx_sanphams.InsertOnSubmit(p);
            db.SubmitChanges();
            this.Close();






        }








        private void txtQuocgia_TextChanged(object sender, EventArgs e)
        {

        }








        private void txttennganhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmasanpham.Focus();


            }
        }

        private void txtmakho_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtghichu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmasanpham.Focus();


            }
        }

       
        private void txtkhoiluong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


             

            }

        }

      

        private void txtghichu_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {


                txtmasanpham.Focus();


            }

        }

       

        private void tabPagettsanpham_Click(object sender, EventArgs e)
        {

        }
    }


}

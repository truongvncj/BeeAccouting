﻿using Microsoft.Office.Interop.Excel;
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

    public partial class VATinphaitra : Form
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
        public VATinphaitra(View.Main Main)
        {
            //    this.dataGridView1.DataSource = rs;
            InitializeComponent();
            this.valuesave = valuesave;


            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);


            this.main1 = Main;
            this.db = dc;
            var username = Utils.getusername().Truncate(50);
            this.rs = from p in dc.tbl_VATinputInvoices
                      where p.dinhkhoan == false
                      //  && p.NHpsCo>0

                      select // p;

                      new
                      {
                          ID = p.id,
                          Ký_hiệu_hóa_đơn = p.kyhieuhoadon,
                          Số_hóa_đơn = p.sohoadon,
                          Người_bán = p.tenguoiban,
                          Tiền_trước_thuế_VAT = p.tientruocvat,

                          Tiền_thuế_VAT = p.vatin,
                          Mã_số_thuế = p.masothuenguoiban,
                          Ngày_hóa_đơn = p.ngaylaphoadon,

                          // Tổng_tiền_thuế = p.mabuttoanNH,



                      };


            this.dataGridView1.DataSource = rs;
            this.Dtgridview = dataGridView1;



            //   this.btketchuyen.Visible = false; 


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


            //if (this.viewcode == 114)  // viewcode ==0  la danh sách tài k khoản kê toán
            //{



            int idtk = 0;
            try
            {
                idtk = (int)this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value;
            }
            catch (Exception)
            {

                //    MessageBox.Show("Bạn phải chọn một tuyến !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ChonNCChoacNV chonloaitt = new View.ChonNCChoacNV();
            chonloaitt.ShowDialog();

            bool chonloai = chonloaitt.chon;
            bool chonNCC = chonloaitt.chonNCC;

            string connection_string = Utils.getConnectionstr();

            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);

            if (chonloai && chonNCC)  // chon tt cho nha cung cấp
            {


                ChonHanghoahayDv chonhanghoa = new View.ChonHanghoahayDv();
                chonhanghoa.ShowDialog();

                bool chonhang = chonhanghoa.chon;
                bool loaihang = chonhanghoa.chonHanghoanhapkho;

                if (chonhang && loaihang==true ) // chon hàng hóa nhâp kho
                {

                    #region  chon nha cc hang hoa list phiêu nhâp ra và chọn phiếu để matching


                    var vatin = (from p in dc.tbl_VATinputInvoices
                                 where p.id == idtk
                                 select p).FirstOrDefault();


                      var dschitiet = from p in dc.tbl_machitiettks
                                    where
                                    p.maso.Trim() == vatin.masothuenguoiban.Trim()
                                       &&
                                    p.matk == "331"
                                    select new
                                    {
                                        Tên_khách_hàng = p.tenchitiet,
                                        Mã_số_thuế = p.maso,
                                        Ghi_chú = p.ghichu,



                                        ID = p.id



                                    };



                    //   Chonchitietphaithu phaithu = new Chonchitietphaithu("CHỌN PHẢI THU KHÁCH HÀNG", dschitiet, dc);




                    Chonchitietphaitra phaitra = new Chonchitietphaitra("CHỌN CHI TIẾT PHẢI TRẢ", dschitiet, dc);



                    phaitra.ShowDialog();

                    bool kqphaitra = phaitra.kq;

                    //   idtk  la id trong danh sach tk bank de update lai stau la đa hach toan
                    // update ma but toan, id but toan tong hop





                    if (kqphaitra) // newu tru tức là có chọn ta mở mục tài khoản định khoản tổng hợp chi tiết cho doanh thu
                    {


                        //xxxxxx
                        var dschitiet2 = from p in dc.tbl_kho_phieunhap_heads
                                         where
                                       p.matchinginvoice == false
                                         //  p.maso.Trim() == vatin.masothuenguoiban.Trim()
                                         //    &&
                                         //  p.matk == "331"
                                         select new
                                         {
                                             Kho_hàng = p.tenkho,
                                             Phiếu_nhâp_số = p.phieuso,
                                             Số_tiền_hàng = p.sotien,
                                             Nội_dung = p.diengiai,
                                             Ngày_nhâp =p.ngayphieunhap,
                                             
                                             Đơn_hàng = p.theodonhang,

                                            
                                             //   Nội_dung = p.notk,

                                             ID = p.id



                                         };



                        //   Chonchitietphaithu phaithu = new Chonchitietphaithu("CHỌN PHẢI THU KHÁCH HÀNG", dschitiet, dc);




                        Chonchitietphaitra Phieunhap = new Chonchitietphaitra("CHỌN PHIẾU NHẬP KHO", dschitiet2, dc);



                        Phieunhap.ShowDialog();

                        bool kq2 = Phieunhap.kq;
                        int idphieunhap = Phieunhap.value;

                        //   idtk  la id trong danh sach tk bank de update lai stau la đa hach toan
                        // update ma but toan, id but toan tong hop



                        if (kq2) // newu tru tức là có chọn ta mở mục tài khoản định khoản tổng hợp chi tiết cho doanh thu
                        {

                            var Phaitract = (from p in dc.tbl_machitiettks
                                             where
                                             p.id == phaitra.value
                                                &&
                                             p.matk == "331"
                                             select p).FirstOrDefault();



                            Dinhkhoanphaitra dinhkhoan = new Dinhkhoanphaitra("Hóa đơn " + vatin.kyhieuhoadon.Trim() + "Số " + vatin.sohoadon.ToString().Trim(), Phaitract.matk, Phaitract.tenchitiet);



                            dinhkhoan.ShowDialog();


                            if (dinhkhoan.chon == true)
                            {



                                List<tbl_Socai> detailbt = new List<tbl_Socai>();



                                //  tbl_Socai buttoan = new tbl_Socai();



                                //tbl_Socai chiphi = new tbl_Socai();


                                //chiphi.Diengiai = dinhkhoan.noidung;// "Doanh thu hóa đơn " + vatin.kyhieuhoadon + " " + vatin.sohoadon;

                                //chiphi.Sohieuchungtu = vatin.kyhieuhoadon + " " + vatin.sohoadon;
                                //chiphi.manghiepvu = "TH";
                                //chiphi.Ngayctu = vatin.ngaylaphoadon;
                                //chiphi.Ngayghiso = vatin.ngaylaphoadon;

                                //chiphi.PsNo = vatin.tientruocvat;
                                //chiphi.PsCo = vatin.tientruocvat;

                                //chiphi.TkCo = "331";

                                //chiphi.MaCTietTKCo = Phaitract.machitiet;
                                //chiphi.tenchitietCo = Phaitract.tenchitiet;

                                //chiphi.TkNo = dinhkhoan.mataikhoan;
                                //chiphi.MaCTietTKNo = dinhkhoan.machitiettaikhoan;
                                //chiphi.tenchitietNo = dinhkhoan.tentaikhoanchitiet;
                                //chiphi.idsanphamno = dinhkhoan.idsanpham;

                                //chiphi.username = Utils.getname();


                                tbl_Socai dkthue = new tbl_Socai();

                                //c 131



                                dkthue.Sohieuchungtu = vatin.kyhieuhoadon + " " + vatin.sohoadon;
                                dkthue.manghiepvu = "TH";
                                dkthue.Ngayctu = vatin.ngaylaphoadon;
                                dkthue.Ngayghiso = vatin.ngaylaphoadon;


                                dkthue.PsCo = vatin.vatin;
                                dkthue.PsNo = vatin.vatin;


                                if (dinhkhoan.hoadonkhongkevat == true)
                                {
                                    //   dkthue.TkNo =
                                    dkthue.TkNo = dinhkhoan.mataikhoan;
                                    dkthue.MaCTietTKNo = dinhkhoan.machitiettaikhoan;
                                    dkthue.tenchitietNo = dinhkhoan.tentaikhoanchitiet;
                                    dkthue.Diengiai = "Thuế hóa đơn không khấu trừ " + vatin.kyhieuhoadon + " " + vatin.sohoadon;
                                }
                                else
                                {
                                    dkthue.Diengiai = "Thuế hóa đơn " + vatin.kyhieuhoadon + " " + vatin.sohoadon;
                                    dkthue.TkNo = "1331";
                                }


                                //chiphi.TkNo = dinhkhoan.mataikhoan;
                                //chiphi.MaCTietTKNo = dinhkhoan.machitiettaikhoan;
                                //chiphi.tenchitietNo = dinhkhoan.tentaikhoanchitiet;

                                //  
                                dkthue.TkCo = "331";
                                dkthue.MaCTietTKCo = Phaitract.machitiet;
                                dkthue.tenchitietCo = Phaitract.tenchitiet;
                                dkthue.username = Utils.getname();

                                //  detailbt.Add(chiphi);
                                detailbt.Add(dkthue);



                                Buttoanphaitra Buttoanphaitra = new Buttoanphaitra(detailbt, idtk);

                                Buttoanphaitra.ShowDialog();

                            }





                    }





                  


                    }




                    #endregion chon nh cung cap
                }

             if (chonhang && loaihang ==false) // chon hàng hóa dich vụ
               
                {

                    #region  chon nha cc


                    var vatin = (from p in dc.tbl_VATinputInvoices
                                 where p.id == idtk
                                 select p).FirstOrDefault();


                    var dschitiet = from p in dc.tbl_machitiettks
                                    where
                                    p.maso.Trim() == vatin.masothuenguoiban.Trim()
                                       &&
                                    p.matk == "331"
                                    select new
                                    {
                                        Tên_khách_hàng = p.tenchitiet,
                                        Mã_số_thuế = p.maso,
                                        Ghi_chú = p.ghichu,



                                        ID = p.id



                                    };



                    //   Chonchitietphaithu phaithu = new Chonchitietphaithu("CHỌN PHẢI THU KHÁCH HÀNG", dschitiet, dc);




                    Chonchitietphaitra phaitra = new Chonchitietphaitra("CHỌN CHI TIẾT PHẢI TRẢ", dschitiet, dc);



                    phaitra.ShowDialog();

                    bool kq = phaitra.kq;

                    //   idtk  la id trong danh sach tk bank de update lai stau la đa hach toan
                    // update ma but toan, id but toan tong hop





                    if (kq) // newu tru tức là có chọn ta mở mục tài khoản định khoản tổng hợp chi tiết cho doanh thu
                    {

                        var Phaitract = (from p in dc.tbl_machitiettks
                                         where
                                         p.id == phaitra.value
                                            &&
                                         p.matk == "331"
                                         select p).FirstOrDefault();



                        Dinhkhoanphaitra dinhkhoan = new Dinhkhoanphaitra("Hóa đơn " + vatin.kyhieuhoadon.Trim() + "Số " + vatin.sohoadon.ToString().Trim(), Phaitract.matk, Phaitract.tenchitiet);



                        dinhkhoan.ShowDialog();


                        if (dinhkhoan.chon == true)
                        {



                            List<tbl_Socai> detailbt = new List<tbl_Socai>();



                            tbl_Socai buttoan = new tbl_Socai();



                            tbl_Socai chiphi = new tbl_Socai();
                            // ndktk
                            // ndkchitiet

                            // C331 -- chi tiet phaitra
                            //   nguoimua
                            //       tkchitiet
                            chiphi.Diengiai = dinhkhoan.noidung;// "Doanh thu hóa đơn " + vatin.kyhieuhoadon + " " + vatin.sohoadon;

                            chiphi.Sohieuchungtu = vatin.kyhieuhoadon + " " + vatin.sohoadon;
                            chiphi.manghiepvu = "TH";
                            chiphi.Ngayctu = vatin.ngaylaphoadon;
                            chiphi.Ngayghiso = vatin.ngaylaphoadon;

                            chiphi.PsNo = vatin.tientruocvat;
                            chiphi.PsCo = vatin.tientruocvat;

                            chiphi.TkCo = "331";

                            chiphi.MaCTietTKCo = Phaitract.machitiet;
                            chiphi.tenchitietCo = Phaitract.tenchitiet;

                            chiphi.TkNo = dinhkhoan.mataikhoan;
                            chiphi.MaCTietTKNo = dinhkhoan.machitiettaikhoan;
                            chiphi.tenchitietNo = dinhkhoan.tentaikhoanchitiet;
                            chiphi.idsanphamno = dinhkhoan.idsanpham;

                            chiphi.username = Utils.getname();


                            tbl_Socai dkthue = new tbl_Socai();

                            //c 131



                            dkthue.Sohieuchungtu = vatin.kyhieuhoadon + " " + vatin.sohoadon;
                            dkthue.manghiepvu = "TH";
                            dkthue.Ngayctu = vatin.ngaylaphoadon;
                            dkthue.Ngayghiso = vatin.ngaylaphoadon;


                            dkthue.PsCo = vatin.vatin;
                            dkthue.PsNo = vatin.vatin;


                            if (dinhkhoan.hoadonkhongkevat == true)
                            {
                                //   dkthue.TkNo =
                                dkthue.TkNo = dinhkhoan.mataikhoan;
                                dkthue.MaCTietTKNo = dinhkhoan.machitiettaikhoan;
                                dkthue.tenchitietNo = dinhkhoan.tentaikhoanchitiet;
                                dkthue.Diengiai = "Thuế hóa đơn không khấu trừ " + vatin.kyhieuhoadon + " " + vatin.sohoadon;
                            }
                            else
                            {
                                dkthue.Diengiai = "Thuế hóa đơn " + vatin.kyhieuhoadon + " " + vatin.sohoadon;
                                dkthue.TkNo = "1331";
                            }


                            //chiphi.TkNo = dinhkhoan.mataikhoan;
                            //chiphi.MaCTietTKNo = dinhkhoan.machitiettaikhoan;
                            //chiphi.tenchitietNo = dinhkhoan.tentaikhoanchitiet;

                            //  
                            dkthue.TkCo = "331";
                            dkthue.MaCTietTKCo = Phaitract.machitiet;
                            dkthue.tenchitietCo = Phaitract.tenchitiet;
                            dkthue.username = Utils.getname();

                            detailbt.Add(chiphi);
                            detailbt.Add(dkthue);



                            Buttoanphaitra Buttoanphaitra = new Buttoanphaitra(detailbt, idtk);

                            Buttoanphaitra.ShowDialog();

                        }


                    }




                    #endregion chon nh cung cap
                }


            }

            if (chonloai && chonNCC ==false) // chon tt tam ứng

            {


                #region  chon thanh toan tam ung


                var vatin = (from p in dc.tbl_VATinputInvoices
                             where p.id == idtk
                             select p).FirstOrDefault();


                var dschitiet = from p in dc.tbl_machitiettks
                                where
                           //     p.maso.Trim() == vatin.masothuenguoiban.Trim()
                             //      &&
                                p.matk == "141"
                                select new
                                {
                                    Mã_chi_tiết = p.machitiet,
                                    Tên_nhân_viên = p.tenchitiet,
                                    Mã_số_thuế = p.maso,
                                    Ghi_chú = p.ghichu,



                                    ID = p.id



                                };



                //   Chonchitietphaithu phaithu = new Chonchitietphaithu("CHỌN PHẢI THU KHÁCH HÀNG", dschitiet, dc);




                Chonchitietphaitra phaitra = new Chonchitietphaitra("CHỌN NHÂN VIÊN THANH TOÁN TẠM ỨNG ", dschitiet, dc);



                phaitra.ShowDialog();

                bool kq = phaitra.kq;

                //   idtk  la id trong danh sach tk bank de update lai stau la đa hach toan
                // update ma but toan, id but toan tong hop





                if (kq) // newu tru tức là có chọn ta mở mục tài khoản định khoản tổng hợp chi tiết cho doanh thu
                {

                    var Phaitract = (from p in dc.tbl_machitiettks
                                     where
                                     p.id == phaitra.value
                                        &&
                                     p.matk == "141"
                                     select p).FirstOrDefault();



                    Dinhkhoanphaitra dinhkhoan = new Dinhkhoanphaitra("Hóa đơn " + vatin.kyhieuhoadon.Trim() + "Số " + vatin.sohoadon.ToString().Trim(), Phaitract.matk, Phaitract.tenchitiet);



                    dinhkhoan.ShowDialog();


                    if (dinhkhoan.chon == true)
                    {



                        List<tbl_Socai> detailbt = new List<tbl_Socai>();



                        tbl_Socai buttoan = new tbl_Socai();



                        tbl_Socai tttamung = new tbl_Socai();
                        // ndktk
                        // ndkchitiet

                        // C331 -- chi tiet phaitra
                        //   nguoimua
                        //       tkchitiet
                        tttamung.Diengiai = dinhkhoan.noidung;// "Doanh thu hóa đơn " + vatin.kyhieuhoadon + " " + vatin.sohoadon;

                        tttamung.Sohieuchungtu = vatin.kyhieuhoadon + " " + vatin.sohoadon;
                        tttamung.manghiepvu = "TH";
                        tttamung.Ngayctu = vatin.ngaylaphoadon;
                        tttamung.Ngayghiso = vatin.ngaylaphoadon;

                        tttamung.PsNo = vatin.tientruocvat;
                        tttamung.PsCo = vatin.tientruocvat;

                        tttamung.TkCo = "141";

                        tttamung.MaCTietTKCo = Phaitract.machitiet;
                        tttamung.tenchitietCo = Phaitract.tenchitiet;

                        tttamung.TkNo = dinhkhoan.mataikhoan;
                        tttamung.MaCTietTKNo = dinhkhoan.machitiettaikhoan;
                        tttamung.tenchitietNo = dinhkhoan.tentaikhoanchitiet;
                        tttamung.idsanphamno = dinhkhoan.idsanpham;

                        tttamung.username = Utils.getname();


                        tbl_Socai dkthue = new tbl_Socai();

                        //c 131



                        dkthue.Sohieuchungtu = vatin.kyhieuhoadon + " " + vatin.sohoadon;
                        dkthue.manghiepvu = "TH";
                        dkthue.Ngayctu = vatin.ngaylaphoadon;
                        dkthue.Ngayghiso = vatin.ngaylaphoadon;


                        dkthue.PsCo = vatin.vatin;
                        dkthue.PsNo = vatin.vatin;


                        if (dinhkhoan.hoadonkhongkevat == true)
                        {
                            //   dkthue.TkNo =
                            dkthue.TkNo = dinhkhoan.mataikhoan;
                            dkthue.MaCTietTKNo = dinhkhoan.machitiettaikhoan;
                            dkthue.tenchitietNo = dinhkhoan.tentaikhoanchitiet;
                            dkthue.Diengiai = "Thuế hóa đơn không khấu trừ " + vatin.kyhieuhoadon + " " + vatin.sohoadon;
                        }
                        else
                        {
                            dkthue.Diengiai = "Thuế hóa đơn " + vatin.kyhieuhoadon + " " + vatin.sohoadon;
                            dkthue.TkNo = "1331";
                        }


                        //chiphi.TkNo = dinhkhoan.mataikhoan;
                        //chiphi.MaCTietTKNo = dinhkhoan.machitiettaikhoan;
                        //chiphi.tenchitietNo = dinhkhoan.tentaikhoanchitiet;

                        //  
                        dkthue.TkCo = "141";
                        dkthue.MaCTietTKCo = Phaitract.machitiet;
                        dkthue.tenchitietCo = Phaitract.tenchitiet;
                        dkthue.username = Utils.getname();

                        detailbt.Add(tttamung);
                        detailbt.Add(dkthue);



                        Buttoanphaitra Buttoanphaitra = new Buttoanphaitra(detailbt, idtk);

                        Buttoanphaitra.ShowDialog();

                    }


                }




                #endregion chon nh cung cap
            }



            #endregion viewcode = 114 dnah muc tai khoan ke toan


            var username = Utils.getusername().Truncate(50);
            this.rs = from p in dc.tbl_VATinputInvoices
                      where p.dinhkhoan == false
                      //  && p.NHpsCo>0

                      select // p;

                      new
                      {
                          ID = p.id,
                          Ngày_hóa_đơn = p.ngaylaphoadon,
                          Ký_hiệu_hóa_đơn = p.kyhieuhoadon,
                          Số_hóa_đơn = p.sohoadon,
                          Mã_số_thuế = p.masothuenguoiban,
                          Người_bán = p.tenguoiban,
                          Tiền_trước_thuế_VAT = p.tientruocvat,

                          Tiền_thuế_VAT = p.vatin,
                         



                      };


            this.dataGridView1.DataSource = rs;
            this.Dtgridview = dataGridView1;



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


        private void formlabel_Click(object sender, EventArgs e)
        {

        }
    }



}

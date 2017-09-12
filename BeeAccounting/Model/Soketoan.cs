using BEEACCOUNT.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BEEACCOUNT.Model
{
    class Soketoan
    {
        public static void sonhatkychung()
        {
            //  Beeyearsellect
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            string yearchon;
            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Chọn năm")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {



                View.Beeyearsellect Beeyearsellect = new View.Beeyearsellect();
                Beeyearsellect.ShowDialog();

                yearchon = Beeyearsellect.year;
                chon = Beeyearsellect.chon;


                if (chon)
                {



                    #region showreport
                    // xoa data cũ
                    string username = Utils.getusername();

                    var detailrptNKc = from P in dc.RptdetaiNKCs
                                       where P.username == username
                                       select P;

                    dc.RptdetaiNKCs.DeleteAllOnSubmit(detailrptNKc);
                    dc.SubmitChanges();


                    var headrptnkc = from p in dc.RPtheadNKCs
                                     where p.username == username
                                     select p;

                    dc.RPtheadNKCs.DeleteAllOnSubmit(headrptnkc);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadNKC HeadHKC = new RPtheadNKC();


                    HeadHKC.nam = yearchon;
                    HeadHKC.tencongty = Model.Congty.getnamecongty();
                    HeadHKC.username = username;
                    HeadHKC.diachicongty = Model.Congty.getdiachicongty();
                    HeadHKC.masothue = Model.Congty.getmasothuecongty();
                    //      pt.tencongty = Model.Congty.getnamecongty();
                    //    pt.diachicongty = Model.Congty.getdiachicongty();
                    //  pt.masothue = Model.Congty.getmasothuecongty();
                    HeadHKC.giamdoc = Model.Congty.gettengiamdoccongty();
                    HeadHKC.ketoantruong = Model.Congty.gettenketoantruongcongty();
                    HeadHKC.nguoighiso = Utils.getname();





                    dc.RPtheadNKCs.InsertOnSubmit(HeadHKC);
                    dc.SubmitChanges();



                    var headNKC = from p in dc.RPtheadNKCs
                                  where p.username == username
                                  select p;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, headNKC);

                    //-----------------------




                    var detairpt = from tbl_Socai in dc.tbl_Socais
                                   where tbl_Socai.Ngayctu.Value.Year.ToString().Trim() == yearchon.Trim()
                                   orderby tbl_Socai.Ngayctu
                                   select tbl_Socai;

                    foreach (var item in detairpt)
                    {
                        RptdetaiNKC q = new RptdetaiNKC();
                        if (item.Diengiai != "")
                        {
                            q.diengiai = item.Diengiai.Trim();
                        }

                        q.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;


                        q.taikhoandoiung = item.TkNo.Trim();
                        q.psno = item.PsNo;
                        q.psco = 0;


                        //       q.ton = daukysave + item.PSNo - item.PSCo;
                        //        daukysave = daukysave + (double)item.PSNo - (double)item.PSCo;

                        dc.RptdetaiNKCs.InsertOnSubmit(q);
                        dc.SubmitChanges();

                        RptdetaiNKC q2 = new RptdetaiNKC();


                        //         RptdetaiNKC q = new RptdetaiNKC();
                        if (item.Diengiai != "")
                        {
                            q2.diengiai = item.Diengiai.Trim();
                        }

                        q2.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q2.username = username;
                        q2.Ngaychungtu = item.Ngayctu;


                        q2.taikhoandoiung = item.TkCo.Trim();
                        q2.psno = 0;
                        q2.psco = item.PsCo;


                        dc.RptdetaiNKCs.InsertOnSubmit(q2);
                        dc.SubmitChanges();





                    }






                    var rptdetail = from p in dc.RptdetaiNKCs
                                    where p.username == username
                                    orderby p.Ngaychungtu

                                    select p;



                    var dataset2 = ut.ToDataTable(dc, rptdetail);



                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Sonhatkychung.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports








                }





            }


        }
        public static void socaitaikhoan()
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            #region  chọn sổ cái


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            bool kq = false;
            foreach (Form frm in fc)
            {
                ///  KAcontractlisting
                ///    if (frm.Text == "CreatenewContract")
                if (frm.Text == "Chọn tài khoản")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {



                View.BeeselecSocai BeeselecSocai = new View.BeeselecSocai("socai");
                BeeselecSocai.ShowDialog();

                chon = BeeselecSocai.chon;
                DateTime fromdate = BeeselecSocai.fromdate;
                DateTime todate = BeeselecSocai.todate;

                string mataikhoan = BeeselecSocai.mataikhoan;
                string tentaikhoan = BeeselecSocai.tentaikhoan;
                //   int machitiettaikhoan = Beeselecttk.machitiettaikhoan;
                //    string tentaikhoanchitiet = Beeselecttk.tentaikhoanchitiet;


                if (chon)
                {

                    #region showreport
                    // xoa data cũ
                    string username = Utils.getusername();

                    var listRptdetailSocai = from RptdetailSocai in dc.RptdetailSoCais
                                             where RptdetailSocai.username == username
                                             select RptdetailSocai;

                    dc.RptdetailSoCais.DeleteAllOnSubmit(listRptdetailSocai);
                    dc.SubmitChanges();


                    var listRPtsocai = from RPtsocai in dc.RPtheadSocais
                                       where RPtsocai.username == username
                                       select RPtsocai;

                    dc.RPtheadSocais.DeleteAllOnSubmit(listRPtsocai);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadSocai headSocai = new RPtheadSocai();


                    headSocai.taikhoan = tentaikhoan.Trim(); //mataikhoan.Trim() + "-" + 
                    headSocai.tencongty = Model.Congty.getnamecongty();
                    headSocai.username = username;
                    headSocai.diachicongty = Model.Congty.getdiachicongty();
                    headSocai.masothue = Model.Congty.getmasothuecongty();
                    headSocai.tungay = fromdate;
                    headSocai.denngay = todate;



                    headSocai.codauky = (from tbl_Socai in dc.tbl_Socais
                                         where tbl_Socai.Ngayctu < fromdate
                                         && tbl_Socai.TkCo.Trim() == mataikhoan
                                         select tbl_Socai.PsCo).Sum().GetValueOrDefault(0) + (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                                                                                              where tbl_dstaikhoan.matk == mataikhoan
                                                                                              select tbl_dstaikhoan.codk).FirstOrDefault();

                    headSocai.nodauky = (from tbl_Socai in dc.tbl_Socais
                                         where tbl_Socai.Ngayctu < fromdate
                                              && tbl_Socai.TkNo.Trim() == mataikhoan
                                         //  && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                         select tbl_Socai.PsNo).Sum().GetValueOrDefault(0) + (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                                                                                              where tbl_dstaikhoan.matk == mataikhoan
                                                                                              select tbl_dstaikhoan.nodk).FirstOrDefault();







                    headSocai.psco = (from tbl_Socai in dc.tbl_Socais
                                      where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkCo.Trim() == mataikhoan
                                      //   && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                      select tbl_Socai.PsCo).Sum().GetValueOrDefault(0);

                    headSocai.psno = (from tbl_Socai in dc.tbl_Socais
                                      where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkNo.Trim() == mataikhoan
                                      //    && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                      select tbl_Socai.PsNo).Sum().GetValueOrDefault(0);


                    headSocai.nocuoiky = headSocai.nodauky + headSocai.psno;

                    headSocai.cocuoiky = headSocai.codauky + headSocai.psco;


                    double daukysave = (double)headSocai.nodauky - (double)headSocai.codauky;



                    dc.RPtheadSocais.InsertOnSubmit(headSocai);
                    dc.SubmitChanges();



                    var headerquy = from tbl_Socai in dc.RPtheadSocais
                                    where tbl_Socai.username == username
                                    select tbl_Socai;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, headerquy);

                    //-----------------------



                    //  RptdetailSoQuy
                    //        RptdetailSoQuy q = new RptdetailSoQuy();
                    //   machitiettaikhoan

                    //       MessageBox.Show(machitiettaikhoan.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    var detairpt = from tbl_Socai in dc.tbl_Socais
                                   where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                        && tbl_Socai.TkCo.Trim() == mataikhoan
                                   orderby tbl_Socai.Ngayctu
                                   select tbl_Socai;

                    foreach (var item in detairpt)
                    {
                        RptdetailSoCai q = new RptdetailSoCai();
                        if (item.Diengiai != "")
                        {
                            q.diengiai = item.Diengiai.Trim();
                        }

                        q.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;


                        q.taikhoandoiung = item.TkNo.Trim();
                        q.psno = 0;
                        q.psco = item.PsCo;


                        //       q.ton = daukysave + item.PSNo - item.PSCo;
                        //        daukysave = daukysave + (double)item.PSNo - (double)item.PSCo;

                        dc.RptdetailSoCais.InsertOnSubmit(q);
                        dc.SubmitChanges();


                    }

                    var detairptno = from tbl_Socai in dc.tbl_Socais
                                     where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                          && tbl_Socai.TkNo.Trim() == mataikhoan
                                     orderby tbl_Socai.Ngayctu
                                     select tbl_Socai;

                    foreach (var item in detairptno)
                    {
                        RptdetailSoCai q = new RptdetailSoCai();
                        if (item.Diengiai != "")
                        {
                            q.diengiai = item.Diengiai.Trim();
                        }

                        q.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;


                        q.taikhoandoiung = item.TkCo.Trim();
                        q.psno = item.PsNo;
                        q.psco = 0;


                        //       q.ton = daukysave + item.PSNo - item.PSCo;
                        //        daukysave = daukysave + (double)item.PSNo - (double)item.PSCo;

                        dc.RptdetailSoCais.InsertOnSubmit(q);
                        dc.SubmitChanges();


                    }






                    var rptdetail = from RptdetailSocai in dc.RptdetailSoCais
                                    where RptdetailSocai.username == username
                                    orderby RptdetailSocai.Ngaychungtu

                                    select RptdetailSocai;


                    foreach (var item in rptdetail)
                    {

                        item.ton = daukysave + item.psno - item.psco;
                        daukysave = daukysave + (double)item.psno - (double)item.psco;

                    }

                    var dataset2 = ut.ToDataTable(dc, rptdetail);







                    Reportsview rpt = new Reportsview(dataset1, dataset2, "SoCai.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports

                }


            }





            #endregion





        }

        public static void soQuy()
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            #region  chọn sổ quỹ chi tiết


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Chọn tài khoản")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {



                View.Beeselecttk Beeselecttk = new View.Beeselecttk("tienmat");
                Beeselecttk.ShowDialog();

                chon = Beeselecttk.chon;
                DateTime fromdate = Beeselecttk.fromdate;
                DateTime todate = Beeselecttk.todate;

                string mataikhoan = Beeselecttk.mataikhoan;
                string tentaikhoan = Beeselecttk.tentaikhoan;
                int machitiettaikhoan = Beeselecttk.machitiettaikhoan;
                string tentaikhoanchitiet = Beeselecttk.tentaikhoanchitiet;


                if (chon)
                {

                    #region showreport
                    // xoa data cũ
                    string username = Utils.getusername();

                    var listRptdetailSoQuy = from RptdetailSoQuy in dc.RptdetailSoQuys
                                             where RptdetailSoQuy.username == username
                                             select RptdetailSoQuy;

                    dc.RptdetailSoQuys.DeleteAllOnSubmit(listRptdetailSoQuy);
                    dc.SubmitChanges();


                    var listRPtsoQuy = from RPtsoQuy in dc.RPtsoQuys
                                       where RPtsoQuy.username == username
                                       select RPtsoQuy;

                    dc.RPtsoQuys.DeleteAllOnSubmit(listRPtsoQuy);
                    dc.SubmitChanges();

                    RptdetailSoQuy detailSoquy = new RptdetailSoQuy();
                    // update data mới   RPtsoQuy


                    RPtsoQuy headSoquy = new RPtsoQuy();


                    headSoquy.taikhoan = tentaikhoan.Trim(); //mataikhoan.Trim() + "-" + 
                    headSoquy.loaiquy = tentaikhoanchitiet;
                    headSoquy.tencongty = Model.Congty.getnamecongty();
                    headSoquy.username = username;
                    headSoquy.diachicongty = Model.Congty.getdiachicongty();
                    headSoquy.masothue = Model.Congty.getmasothuecongty();
                    headSoquy.tungay = fromdate;
                    headSoquy.denngay = todate;

                    if (machitiettaikhoan != 0)
                    {

                        headSoquy.codauky = (from tbl_SoQuy in dc.tbl_SoQuys
                                             where tbl_SoQuy.Ngayctu < fromdate
                                             && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                             && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                             select tbl_SoQuy.PsCo).Sum().GetValueOrDefault(0) + (from tbl_machitiettk in dc.tbl_machitiettks
                                                                                                  where tbl_machitiettk.machitiet == machitiettaikhoan
                                                                                                  && tbl_machitiettk.matk == mataikhoan
                                                                                                  select tbl_machitiettk.codk).FirstOrDefault();

                        headSoquy.nodauky = (from tbl_SoQuy in dc.tbl_SoQuys
                                             where tbl_SoQuy.Ngayctu < fromdate
                                                  && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                      && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                             select tbl_SoQuy.PsNo).Sum().GetValueOrDefault(0) + (from tbl_machitiettk in dc.tbl_machitiettks
                                                                                                  where tbl_machitiettk.machitiet == machitiettaikhoan
                                                                                                  && tbl_machitiettk.matk == mataikhoan
                                                                                                  select tbl_machitiettk.nodk).FirstOrDefault();

                    }
                    else
                    {

                        headSoquy.codauky = (from tbl_SoQuy in dc.tbl_SoQuys
                                             where tbl_SoQuy.Ngayctu < fromdate
                                             && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                             && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                             select tbl_SoQuy.PsCo).Sum().GetValueOrDefault(0) + (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                                                                                                  where tbl_dstaikhoan.matk == mataikhoan
                                                                                                  select tbl_dstaikhoan.codk).FirstOrDefault();

                        headSoquy.nodauky = (from tbl_SoQuy in dc.tbl_SoQuys
                                             where tbl_SoQuy.Ngayctu < fromdate
                                                  && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                      && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                             select tbl_SoQuy.PsNo).Sum().GetValueOrDefault(0) + (from tbl_dstaikhoan in dc.tbl_dstaikhoans
                                                                                                  where tbl_dstaikhoan.matk == mataikhoan
                                                                                                  select tbl_dstaikhoan.nodk).FirstOrDefault();



                    }






                    headSoquy.psco = (from tbl_SoQuy in dc.tbl_SoQuys
                                      where tbl_SoQuy.Ngayctu >= fromdate && tbl_SoQuy.Ngayctu <= todate
                                           && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                         && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                      select tbl_SoQuy.PsCo).Sum().GetValueOrDefault(0);

                    headSoquy.psno = (from tbl_SoQuy in dc.tbl_SoQuys
                                      where tbl_SoQuy.Ngayctu >= fromdate && tbl_SoQuy.Ngayctu <= todate
                                           && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                         && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                      select tbl_SoQuy.PsNo).Sum().GetValueOrDefault(0);


                    headSoquy.nocuoiky = headSoquy.nodauky + headSoquy.psno;

                    headSoquy.cocuoiky = headSoquy.codauky + headSoquy.psco;


                    double daukysave = (double)headSoquy.nodauky - (double)headSoquy.codauky;



                    dc.RPtsoQuys.InsertOnSubmit(headSoquy);
                    dc.SubmitChanges();



                    var headerquy = from RPtsoQuy in dc.RPtsoQuys
                                    where RPtsoQuy.username == username
                                    select RPtsoQuy;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, headerquy);

                    //-----------------------



                    //  RptdetailSoQuy
                    //        RptdetailSoQuy q = new RptdetailSoQuy();
                    //   machitiettaikhoan

                    //       MessageBox.Show(machitiettaikhoan.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    var detairpt = from tbl_SoQuy in dc.tbl_SoQuys
                                   where tbl_SoQuy.Ngayctu >= fromdate && tbl_SoQuy.Ngayctu <= todate
                                        && tbl_SoQuy.TKtienmat.Trim() == mataikhoan
                                         && tbl_SoQuy.ChitietTM == machitiettaikhoan
                                   orderby tbl_SoQuy.Ngayctu
                                   select tbl_SoQuy;

                    foreach (var item in detairpt)
                    {
                        RptdetailSoQuy q = new RptdetailSoQuy();
                        q.diengiai = item.Diengiai;

                        if (item.Machungtu == "PC")
                        {
                            q.machungtuchi = item.Machungtu + " " + item.Sochungtu.ToString().Trim();
                            q.machungtuthu = "";
                        }
                        else
                        {
                            q.machungtuthu = item.Machungtu + " " + item.Sochungtu.ToString().Trim();
                            q.machungtuchi = "";
                        }

                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;
                        q.psco = item.PsCo;
                        q.psno = item.PsNo;
                        q.taikhoandoiung = item.TKdoiung;
                        q.ton = daukysave + item.PsNo - item.PsCo;
                        daukysave = daukysave + (double)item.PsNo - (double)item.PsCo;

                        dc.RptdetailSoQuys.InsertOnSubmit(q);
                        dc.SubmitChanges();


                    }
                    //   let ton1 = daukysave + tbl_SoQuy.PsNo - tbl_SoQuy.PsCo
                    //   where tbl_SoQuy.Ngayctu >= fromdate && tbl_SoQuy.Ngayctu <= todate
                    //select new
                    //{
                    // diengiai = tbl_SoQuy,

                    //username = urs,


                    //machungtuchi = tbl_SoQuy.Machungtu == "PC"
                    //? tbl_SoQuy.Machungtu + " " + tbl_SoQuy.Sochungtu.ToString().Trim()
                    //: "",

                    //machungtuthu = tbl_SoQuy.Machungtu == "PT"
                    //? tbl_SoQuy.Machungtu + " " + tbl_SoQuy.Sochungtu.ToString().Trim()
                    //: "",



                    //machungtuchi = tbl_SoQuy.Machungtu + " " + tbl_SoQuy.Sochungtu.ToString().Trim(),
                    //machungtuthu = tbl_SoQuy.Machungtu + " " + tbl_SoQuy.Sochungtu.ToString().Trim(),




                    //    Ngaychungtu = tbl_SoQuy.Ngayctu,
                    //   psco = tbl_SoQuy.PsCo,
                    //  psno = tbl_SoQuy.PsNo,

                    ////  daukysave = daukysave + tbl_SoQuy.PsNo - tbl_SoQuy.PsCo,

                    //  taikhoandoiung = tbl_SoQuy.TKdoiung,






                    //           };

                    //   daukysave
                    //foreach (var item in detairpt)
                    //{

                    //    daukysave = daukysave + (double)item.ton;
                    //    item.ton = daukysave;

                    //}
                    //var rsphieuchi = from RptdetailSoQuy in dc.RptdetailSoQuys
                    //                 where RptdetailSoQuy.username == urs
                    //                 select RptdetailSoQuy;

                    var rptdetail = from RptdetailSoQuy in dc.RptdetailSoQuys
                                    where RptdetailSoQuy.username == username
                                    orderby RptdetailSoQuy.Ngaychungtu

                                    select RptdetailSoQuy;

                    var dataset2 = ut.ToDataTable(dc, rptdetail);







                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Soquy.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports

                }


            }





            #endregion




        }

        public static void sochitiettaikhoan()
        {
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            #region  chọn sổ quỹ chi tiết


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Chọn tài khoản")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {



                View.Beeselecttk Beeselecttk = new View.Beeselecttk("chitiet");
                Beeselecttk.ShowDialog();

                chon = Beeselecttk.chon;
                DateTime fromdate = Beeselecttk.fromdate;
                DateTime todate = Beeselecttk.todate;

                string mataikhoan = Beeselecttk.mataikhoan;
                string tentaikhoan = Beeselecttk.tentaikhoan;
                int machitiettaikhoan = Beeselecttk.machitiettaikhoan;
                string tentaikhoanchitiet = Beeselecttk.tentaikhoanchitiet;


                if (chon)
                {
                    #region showreport
                    // xoa data cũ
                    string username = Utils.getusername();

                    var listRptdetailSocaichitiet = from p in dc.RptdetailSocaichitiets
                                                    where p.username == username
                                                    select p;

                    dc.RptdetailSocaichitiets.DeleteAllOnSubmit(listRptdetailSocaichitiet);
                    dc.SubmitChanges();


                    var listRPtheadsocaichitiet = from p in dc.RPtheadSocaichitiets
                                                  where p.username == username
                                                  select p;

                    dc.RPtheadSocaichitiets.DeleteAllOnSubmit(listRPtheadsocaichitiet);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadSocaichitiet headSocai = new RPtheadSocaichitiet();


                    headSocai.taikhoan = tentaikhoan.Trim(); //mataikhoan.Trim() + "-" + 
                    headSocai.tencongty = Model.Congty.getnamecongty();
                    headSocai.username = username;
                    headSocai.diachicongty = Model.Congty.getdiachicongty();
                    headSocai.masothue = Model.Congty.getmasothuecongty();
                    headSocai.tungay = fromdate;
                    headSocai.denngay = todate;
                    headSocai.tenchitiettk = tentaikhoanchitiet;


                    headSocai.codauky = (from tbl_Socai in dc.tbl_Socais
                                         where tbl_Socai.Ngayctu < fromdate
                                         && tbl_Socai.TkCo.Trim() == mataikhoan
                                         && tbl_Socai.MaCTietTKCo == machitiettaikhoan
                                         select tbl_Socai.PsCo).Sum().GetValueOrDefault(0) + (from p in dc.tbl_machitiettks
                                                                                              where p.matk == mataikhoan
                                                                                              && p.machitiet == machitiettaikhoan
                                                                                              select p.codk).FirstOrDefault().GetValueOrDefault(0);

                    headSocai.nodauky = (from tbl_Socai in dc.tbl_Socais
                                         where tbl_Socai.Ngayctu < fromdate
                                              && tbl_Socai.TkNo.Trim() == mataikhoan
                                          && tbl_Socai.MaCTietTKNo == machitiettaikhoan
                                         select tbl_Socai.PsNo).Sum().GetValueOrDefault(0) + (from p in dc.tbl_machitiettks
                                                                                              where p.matk == mataikhoan
                                                                                              && p.machitiet == machitiettaikhoan
                                                                                              select p.nodk).FirstOrDefault().GetValueOrDefault(0);






                    headSocai.psco = (from tbl_Socai in dc.tbl_Socais
                                      where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkCo.Trim() == mataikhoan
                                          && tbl_Socai.MaCTietTKCo == machitiettaikhoan
                                      select tbl_Socai.PsCo).Sum().GetValueOrDefault(0);

                    headSocai.psno = (from tbl_Socai in dc.tbl_Socais
                                      where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkNo.Trim() == mataikhoan
                                       && tbl_Socai.MaCTietTKNo == machitiettaikhoan
                                      select tbl_Socai.PsNo).Sum().GetValueOrDefault(0);


                    headSocai.nocuoiky = headSocai.nodauky.GetValueOrDefault(0) + headSocai.psno;

                    headSocai.cocuoiky = headSocai.codauky.GetValueOrDefault(0) + headSocai.psco;


                    double daukysave = (double)headSocai.nodauky - (double)headSocai.codauky;



                    dc.RPtheadSocaichitiets.InsertOnSubmit(headSocai);
                    dc.SubmitChanges();



                    var header = from tbl_Socai in dc.RPtheadSocaichitiets
                                 where tbl_Socai.username == username
                                 select tbl_Socai;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, header);



                    var detairpt = from tbl_Socai in dc.tbl_Socais
                                   where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                        && tbl_Socai.TkCo.Trim() == mataikhoan
                                                && tbl_Socai.MaCTietTKCo == machitiettaikhoan
                                   orderby tbl_Socai.Ngayctu
                                   select tbl_Socai;

                    foreach (var item in detairpt)
                    {
                        RptdetailSocaichitiet q = new RptdetailSocaichitiet();
                        if (item.Diengiai != "")
                        {
                            q.diengiai = item.Diengiai.Trim();
                        }

                        q.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;


                        q.taikhoandoiung = item.TkNo.Trim();
                        q.psno = 0;
                        q.psco = item.PsCo;


                        //       q.ton = daukysave + item.PSNo - item.PSCo;
                        //        daukysave = daukysave + (double)item.PSNo - (double)item.PSCo;

                        dc.RptdetailSocaichitiets.InsertOnSubmit(q);
                        dc.SubmitChanges();


                    }

                    var detairptno = from tbl_Socai in dc.tbl_Socais
                                     where tbl_Socai.Ngayctu >= fromdate && tbl_Socai.Ngayctu <= todate
                                          && tbl_Socai.TkNo.Trim() == mataikhoan
                                                  && tbl_Socai.MaCTietTKNo == machitiettaikhoan
                                     orderby tbl_Socai.Ngayctu
                                     select tbl_Socai;

                    foreach (var item in detairptno)
                    {
                        RptdetailSocaichitiet q = new RptdetailSocaichitiet();
                        if (item.Diengiai != "")
                        {
                            q.diengiai = item.Diengiai.Trim();
                        }

                        q.machungtu = item.manghiepvu + " " + item.nghiepvuso;


                        q.username = username;
                        q.Ngaychungtu = item.Ngayctu;


                        q.taikhoandoiung = item.TkCo.Trim();
                        q.psno = item.PsNo;
                        q.psco = 0;


                        //       q.ton = daukysave + item.PSNo - item.PSCo;
                        //        daukysave = daukysave + (double)item.PSNo - (double)item.PSCo;

                        dc.RptdetailSocaichitiets.InsertOnSubmit(q);
                        dc.SubmitChanges();


                    }






                    var rptdetail = from p in dc.RptdetailSocaichitiets
                                    where p.username == username
                                    orderby p.Ngaychungtu

                                    select p;


                    foreach (var item in rptdetail)
                    {

                        item.ton = daukysave + item.psno - item.psco;
                        daukysave = daukysave + (double)item.psno - (double)item.psco;

                    }

                    var dataset2 = ut.ToDataTable(dc, rptdetail);







                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Sochitetsocai.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports




                }


            }





            #endregion


        }
        public static void sotonghoptaikhoanchitiet()
        {
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            #region  chọn sổ quỹ chi tiết


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Chọn tài khoản")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {


                View.BeeselecSocai BeeselecSocai = new View.BeeselecSocai("chitiet");
                BeeselecSocai.ShowDialog();

                chon = BeeselecSocai.chon;
                DateTime fromdate = BeeselecSocai.fromdate;
                DateTime todate = BeeselecSocai.todate;

                string mataikhoan = BeeselecSocai.mataikhoan;
                string tentaikhoan = BeeselecSocai.tentaikhoan;



                if (chon)
                {
                    #region showreport
                    // xoa data cũ
                    //    string username = Utils.getusername();

                    var listRptthchitiet = from p in dc.RptdetaiTHchitiets
                                           where p.username == username
                                           select p;

                    dc.RptdetaiTHchitiets.DeleteAllOnSubmit(listRptthchitiet);
                    dc.SubmitChanges();


                    var listrptheadchitiet = from p in dc.RPtheadTHchitiets
                                             where p.username == username
                                             select p;

                    dc.RPtheadTHchitiets.DeleteAllOnSubmit(listrptheadchitiet);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadTHchitiet headTHchitiet = new RPtheadTHchitiet();


                    headTHchitiet.taikhoan = tentaikhoan.Trim(); //mataikhoan.Trim() + "-" + 
                    headTHchitiet.tencongty = Model.Congty.getnamecongty();
                    headTHchitiet.username = username;
                    headTHchitiet.diachicongty = Model.Congty.getdiachicongty();
                    headTHchitiet.masothue = Model.Congty.getmasothuecongty();
                    headTHchitiet.tungay = fromdate;
                    headTHchitiet.denngay = todate;



                    dc.RPtheadTHchitiets.InsertOnSubmit(headTHchitiet);
                    dc.SubmitChanges();



                    var header = from p in dc.RPtheadTHchitiets
                                 where p.username == username
                                 select p;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, header);

                    var chitiet = from p in dc.tbl_machitiettks
                                  where p.matk == mataikhoan
                                  select p;

                    if (chitiet.Count() > 0)
                    {
                        int stt = 0;
                        foreach (var item in chitiet)
                        {
                            stt = stt + 1;

                            RptdetaiTHchitiet detail = new RptdetaiTHchitiet();


                            detail.machitiet = item.machitiet;
                            detail.tenchitiet = item.tenchitiet;

                            detail.stt = stt;
                            detail.Codk = (from tbl_Socai in dc.tbl_Socais
                                           where tbl_Socai.Ngayctu < fromdate
                                           && tbl_Socai.TkCo.Trim() == mataikhoan
                                           && tbl_Socai.MaCTietTKCo == item.machitiet
                                           select tbl_Socai.PsCo).Sum().GetValueOrDefault(0) + (from p in dc.tbl_machitiettks
                                                                                                where p.matk == mataikhoan
                                                                                                && p.machitiet == item.machitiet
                                                                                                select p.codk).FirstOrDefault();

                            detail.Nodk = (from tbl_Socai in dc.tbl_Socais
                                           where tbl_Socai.Ngayctu < fromdate
                                           && tbl_Socai.TkNo.Trim() == mataikhoan
                                           && tbl_Socai.MaCTietTKNo == item.machitiet
                                           select tbl_Socai.PsNo).Sum().GetValueOrDefault(0) + (from p in dc.tbl_machitiettks
                                                                                                where p.matk == mataikhoan
                                                                                                && p.machitiet == item.machitiet
                                                                                                select p.nodk).FirstOrDefault().GetValueOrDefault(0);

                            detail.Psco = (from tbl_Socai in dc.tbl_Socais
                                           where tbl_Socai.Ngayctu >= fromdate
                                           && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkCo.Trim() == mataikhoan
                                           && tbl_Socai.MaCTietTKCo == item.machitiet
                                           select tbl_Socai.PsCo).Sum().GetValueOrDefault(0);

                            detail.Psno = (from tbl_Socai in dc.tbl_Socais
                                           where tbl_Socai.Ngayctu >= fromdate
                                           && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkNo.Trim() == mataikhoan
                                           && tbl_Socai.MaCTietTKNo == item.machitiet
                                           select tbl_Socai.PsNo).Sum().GetValueOrDefault(0);


                            detail.Cock = detail.Codk + detail.Psco;

                            detail.Nock = detail.Nodk + detail.Psno;

                            detail.username = username;


                            dc.RptdetaiTHchitiets.InsertOnSubmit(detail);
                            dc.SubmitChanges();








                        }


                    }




                    var rptdetail = from p in dc.RptdetaiTHchitiets
                                    where p.username == username
                                    orderby p.stt

                                    select p;



                    var dataset2 = ut.ToDataTable(dc, rptdetail);



                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Sotonghopchitiet.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports




                }


            }





            #endregion


        }

        public static void bangcandoiphatsinhtaikhoan()
        {

            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            string yearchon;
            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Chọn năm")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {



                View.Beeyearsellect Beeyearsellect = new View.Beeyearsellect();
                Beeyearsellect.ShowDialog();

                yearchon = Beeyearsellect.year;
                chon = Beeyearsellect.chon;


                if (chon)
                {
                    
                    #region showreport
                    // xoa data cũ
                    //    string username = Utils.getusername();

                    var listRptthchitiet = from p in dc.RptdetaiCDPs
                                           where p.username == username
                                           select p;

                    dc.RptdetaiCDPs.DeleteAllOnSubmit(listRptthchitiet);
                    dc.SubmitChanges();


                    var listrptheadchitiet = from p in dc.RPtheadCDPs
                                             where p.username == username
                                             select p;

                    dc.RPtheadCDPs.DeleteAllOnSubmit(listrptheadchitiet);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadCDP headCDPS = new RPtheadCDP();

                    DateTime fromdate = Utils.chageExceldatetoData("01/01/" + yearchon);
                    DateTime todate = Utils.chageExceldatetoData("12/31/" + yearchon);

                    headCDPS.tencongty = Model.Congty.getnamecongty();
                    headCDPS.username = username;
                    headCDPS.diachicongty = Model.Congty.getdiachicongty();
                    headCDPS.masothue = Model.Congty.getmasothuecongty();
                    headCDPS.tungay = fromdate;
                    headCDPS.denngay = todate;
                    headCDPS.giamdoc = Model.Congty.gettengiamdoccongty();
                    headCDPS.ketoantruong = Model.Congty.gettenketoantruongcongty();
                    headCDPS.nguoighiso = Utils.getname();

                    dc.RPtheadCDPs.InsertOnSubmit(headCDPS);
                    dc.SubmitChanges();



                    var header = from p in dc.RPtheadCDPs
                                 where p.username == username
                                 select p;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, header);

                    var dstaikhoan = from p in dc.tbl_dstaikhoans
                                         //    where p.matk == mataikhoan
                                     select p;

                    if (dstaikhoan.Count() > 0)
                    {
                        //   int stt = 0;
                        foreach (var item in dstaikhoan)
                        {
                            //   stt = stt + 1;

                            RptdetaiCDP detail = new RptdetaiCDP();


                            detail.matk = item.matk;
                            detail.tentk = item.tentk;

                            detail.Codk = (from tbl_Socai in dc.tbl_Socais
                                           where tbl_Socai.Ngayctu < fromdate
                                           && tbl_Socai.TkCo.Trim() == item.matk.Trim()

                                           select tbl_Socai.PsCo).Sum().GetValueOrDefault(0) + item.codk.GetValueOrDefault(0);

                            detail.Nodk = (from tbl_Socai in dc.tbl_Socais
                                           where tbl_Socai.Ngayctu < fromdate
                                           && tbl_Socai.TkNo.Trim() == item.matk.Trim()

                                           select tbl_Socai.PsNo).Sum().GetValueOrDefault(0) + item.nodk.GetValueOrDefault(0);

                            detail.Psco = (from tbl_Socai in dc.tbl_Socais
                                           where tbl_Socai.Ngayctu >= fromdate
                                           && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkCo.Trim() == item.matk

                                           select tbl_Socai.PsCo).Sum().GetValueOrDefault(0);

                            detail.Psno = (from tbl_Socai in dc.tbl_Socais
                                           where tbl_Socai.Ngayctu >= fromdate
                                           && tbl_Socai.Ngayctu <= todate
                                           && tbl_Socai.TkNo.Trim() == item.matk

                                           select tbl_Socai.PsNo).Sum().GetValueOrDefault(0);


                            detail.Cock = detail.Codk + detail.Psco;

                            detail.Nock = detail.Nodk + detail.Psno;

                            detail.username = username;


                            dc.RptdetaiCDPs.InsertOnSubmit(detail);
                            dc.SubmitChanges();








                        }


                    }




                    var rptdetail = from p in dc.RptdetaiCDPs
                                    where p.username == username
                                    orderby p.matk

                                    select p;



                    var dataset2 = ut.ToDataTable(dc, rptdetail);



                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Socandoitkphatsinh.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports

                    
                }


            }
        }




    }
}

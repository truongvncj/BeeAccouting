using BEEACCOUNT.View;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Windows.Forms;


namespace BEEACCOUNT.Model
{
    class Soketoan
    {
        //  public static object CommandType { get; private set; }

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

                        q.machungtu = item.manghiepvu + " " + item.Sohieuchungtu;


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

                        q2.machungtu = item.manghiepvu + " " + item.Sohieuchungtu;


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

        public static void caculationServerDKKD200(string yearchon)
        {

            #region caculation kqkd
            SqlConnection conn2 = null;
            SqlDataReader rdr1 = null;

            string destConnString = Utils.getConnectionstr();
            try
            {

                conn2 = new SqlConnection(destConnString);
                conn2.Open();
                SqlCommand cmd1 = new SqlCommand("calulationKQKD200", conn2);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandTimeout = 0;
                cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = Utils.getusername();
                cmd1.Parameters.Add("@yearchon", SqlDbType.Int).Value = int.Parse(yearchon);
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
            //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion



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

                        q.machungtu = item.manghiepvu + " " + item.Sohieuchungtu;


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

                        q.machungtu = item.manghiepvu + " " + item.Sohieuchungtu;


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

                if (frm.Text == "Tài khoản")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {



                View.Beeselecttk Beeselecttk = new View.Beeselecttk("tien");
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
                            q.machungtuchi = item.Machungtu + " " + item.Sophieu.Trim();
                            q.machungtuthu = "";
                        }
                        else
                        {
                            q.machungtuthu = item.Machungtu + " " + item.Sophieu.Trim();
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

                        q.machungtu = item.manghiepvu + " " + item.Sohieuchungtu;


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

                        q.machungtu = item.manghiepvu + " " + item.Sohieuchungtu;


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

        public static void nhapsodudaukylctt()
        {

            //  Beeyearsellect
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            int yearchon;
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

                yearchon = int.Parse(Beeyearsellect.year);
                chon = Beeyearsellect.chon;

                if (chon)
                {

                    View.BeeLCTT200dauky BeeLCTT200dauky = new BeeLCTT200dauky(yearchon);
                    BeeLCTT200dauky.ShowDialog();
                }





            }




            //  throw new NotImplementedException();
        }

        public static void xemvaupdauCDKT200()
        {
            //  Beeyearsellect
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            int yearchon;
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

                yearchon = int.Parse(Beeyearsellect.year);
                chon = Beeyearsellect.chon;

                if (chon)
                {

                    View.BeeCDKT200nhapsocho xemsuacdkt = new BeeCDKT200nhapsocho(yearchon);
                    xemsuacdkt.ShowDialog();
                }





            }


            //   throw new NotImplementedException();
        }

        public static void baocaoluuchuyentiente()
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

                    var detailrpt = from P in dc.RPtdetaillchuyenttttieps
                                    where P.username == username
                                    select P;

                    dc.RPtdetaillchuyenttttieps.DeleteAllOnSubmit(detailrpt);
                    dc.SubmitChanges();


                    var headrptnkc = from p in dc.RPtheadLCTTTtieps
                                     where p.username == username
                                     select p;

                    dc.RPtheadLCTTTtieps.DeleteAllOnSubmit(headrptnkc);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadLCTTTtiep headrpt = new RPtheadLCTTTtiep();


                    headrpt.nam = yearchon;
                    headrpt.tencongty = Model.Congty.getnamecongty();
                    headrpt.username = username;
                    headrpt.diachicongty = Model.Congty.getdiachicongty();
                    headrpt.masothue = Model.Congty.getmasothuecongty();
                    //      pt.tencongty = Model.Congty.getnamecongty();
                    //    pt.diachicongty = Model.Congty.getdiachicongty();
                    //  pt.masothue = Model.Congty.getmasothuecongty();
                    headrpt.giamdoc = Model.Congty.gettengiamdoccongty();
                    headrpt.ketoantruong = Model.Congty.gettenketoantruongcongty();
                    headrpt.nguoighiso = Utils.getname();





                    dc.RPtheadLCTTTtieps.InsertOnSubmit(headrpt);
                    dc.SubmitChanges();



                    var headNKC = from p in dc.RPtheadLCTTTtieps
                                  where p.username == username
                                  select p;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, headNKC);

                    //-----------------------

                    //  ádfdsaf
                    //     caculationServerCD200(yearchon);


                    #region luu chuye ttt truc tiep 
                    SqlConnection conn2 = null;
                    SqlDataReader rdr1 = null;

                    string destConnString = Utils.getConnectionstr();
                    try
                    {

                        conn2 = new SqlConnection(destConnString);
                        conn2.Open();
                        SqlCommand cmd1 = new SqlCommand("calulationluuchuyentiente200", conn2);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandTimeout = 0;
                        cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = Utils.getusername();
                        cmd1.Parameters.Add("@yearchon", SqlDbType.Int).Value = int.Parse(yearchon);
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
                    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #endregion


                    ///===============

                    var rptdetail = from p in dc.RPtdetaillchuyenttttieps
                                    where p.username == username


                                    select p;



                    var dataset2 = ut.ToDataTable(dc, rptdetail);



                    Reportsview rpt = new Reportsview(dataset1, dataset2, "BaocaoLuuchuyenttett.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports


                }

                //   }
            }








            // throw new NotImplementedException();
        }

        public static void Bangcandoiphatsinhketoantt200lientuc()
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




                    #region caculation cdphat sinh lien tuc
                    SqlConnection conn2 = null;
                    SqlDataReader rdr1 = null;

                    string destConnString = Utils.getConnectionstr();
                    try
                    {

                        conn2 = new SqlConnection(destConnString);
                        conn2.Open();
                        SqlCommand cmd1 = new SqlCommand("calulationCDphatsinh200", conn2);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandTimeout = 0;
                        cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = Utils.getusername();
                        cmd1.Parameters.Add("@yearchon", SqlDbType.Int).Value = int.Parse(yearchon);
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
                    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #endregion


                    //     Loại_ngắn_hạn = p.loainganhan,

                    var rs1 = from p in dc.RptPhatsinhcdkt200s
                              where p.username == Utils.getusername()
                              select new
                              {
                                  Mã_tài_khoản = p.matk,
                                  Tên_tài_khoản = p.tentk.Trim(),
                                  Mã_chi_tiết = p.machitiet == -1
                                                  ? ""
                                                 : p.machitiet.ToString(),



                                  Tên_chi_tiết = p.tenchitiet,
                                  Phát_sinh_có = p.tPSCo,
                                  Phát_sinh_nợ = p.tPSNo,
                              //    Số_dư_phát_sinh = p.tPsNotruPSco,




                              };



                    Viewtable viewtbl = new Viewtable(rs1, dc, "BẢNG TỔNG HỢP PHÁT SINH NĂM " + yearchon.ToUpper(), 12, "0");// mã 12 là danh sach BẢNG CÂN ĐỐI PHÁT SINH
                    viewtbl.Show();



                }

            }

            // throw new NotImplementedException();
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

        public static void baocaocandoiketoantt200lientuc()
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

                    var detailrpt = from P in dc.RPtdetailCDKT200lientucs
                                    where P.username == username
                                    select P;

                    dc.RPtdetailCDKT200lientucs.DeleteAllOnSubmit(detailrpt);
                    dc.SubmitChanges();


                    var headrptnkc = from p in dc.RPtheadCDKT200mau01s
                                     where p.username == username
                                     select p;

                    dc.RPtheadCDKT200mau01s.DeleteAllOnSubmit(headrptnkc);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadCDKT200mau01 headrpt = new RPtheadCDKT200mau01();


                    headrpt.nam = yearchon;
                    headrpt.tencongty = Model.Congty.getnamecongty();
                    headrpt.username = username;
                    headrpt.diachicongty = Model.Congty.getdiachicongty();
                    headrpt.masothue = Model.Congty.getmasothuecongty();
                    //      pt.tencongty = Model.Congty.getnamecongty();
                    //    pt.diachicongty = Model.Congty.getdiachicongty();
                    //  pt.masothue = Model.Congty.getmasothuecongty();
                    headrpt.giamdoc = Model.Congty.gettengiamdoccongty();
                    headrpt.ketoantruong = Model.Congty.gettenketoantruongcongty();
                    headrpt.nguoighiso = Utils.getname();





                    dc.RPtheadCDKT200mau01s.InsertOnSubmit(headrpt);
                    dc.SubmitChanges();



                    var headNKC = from p in dc.RPtheadCDKT200mau01s
                                  where p.username == username
                                  select p;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, headNKC);

                    //-----------------------

                    //  ádfdsaf
                    //     caculationServerCD200(yearchon);


                    #region caculation cdkt200 lien tuc
                    SqlConnection conn2 = null;
                    SqlDataReader rdr1 = null;

                    string destConnString = Utils.getConnectionstr();
                    try
                    {

                        conn2 = new SqlConnection(destConnString);
                        conn2.Open();
                        SqlCommand cmd1 = new SqlCommand("calulationCDKT200loai1", conn2);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandTimeout = 0;
                        cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = Utils.getusername();
                        cmd1.Parameters.Add("@yearchon", SqlDbType.Int).Value = int.Parse(yearchon);
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
                    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #endregion


                    ///===============

                    var rptdetail = from p in dc.RPtdetailCDKT200lientucs
                                    where p.username == username


                                    select p;



                    var dataset2 = ut.ToDataTable(dc, rptdetail);



                    Reportsview rpt = new Reportsview(dataset1, dataset2, "BangCDKToant200lt.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports


                }

                //   }
            }






            //  throw new NotImplementedException();
        }

        public static void xemvaupdatekqkd200()
        {
            //  Beeyearsellect
            string connection_string = Utils.getConnectionstr();
            string urs = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            int yearchon;
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

                yearchon = int.Parse(Beeyearsellect.year);
                chon = Beeyearsellect.chon;

                if (chon)
                {

                    View.BeeBCKQKD200updatechotso xemsuakqkd = new BeeBCKQKD200updatechotso(yearchon);
                    xemsuakqkd.Show();
                }





            }

            // throw new NotImplementedException();
        }

        public static void baocaokqkd()
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

                    var detailrpt = from P in dc.RPtdetailKQKD200s
                                    where P.username == username
                                    select P;

                    dc.RPtdetailKQKD200s.DeleteAllOnSubmit(detailrpt);
                    dc.SubmitChanges();


                    var headrptnkc = from p in dc.RPtheadKQKD200s
                                     where p.username == username
                                     select p;

                    dc.RPtheadKQKD200s.DeleteAllOnSubmit(headrptnkc);
                    dc.SubmitChanges();


                    // update data mới   RPtsoQuy


                    RPtheadKQKD200 headrpt = new RPtheadKQKD200();


                    headrpt.nam = yearchon;
                    headrpt.tencongty = Model.Congty.getnamecongty();
                    headrpt.username = username;
                    headrpt.diachicongty = Model.Congty.getdiachicongty();
                    headrpt.masothue = Model.Congty.getmasothuecongty();
                    //      pt.tencongty = Model.Congty.getnamecongty();
                    //    pt.diachicongty = Model.Congty.getdiachicongty();
                    //  pt.masothue = Model.Congty.getmasothuecongty();
                    headrpt.giamdoc = Model.Congty.gettengiamdoccongty();
                    headrpt.ketoantruong = Model.Congty.gettenketoantruongcongty();
                    headrpt.nguoighiso = Utils.getname();





                    dc.RPtheadKQKD200s.InsertOnSubmit(headrpt);
                    dc.SubmitChanges();



                    var headNKC = from p in dc.RPtheadKQKD200s
                                  where p.username == username
                                  select p;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, headNKC);

                    //-----------------------

                    //  ádfdsaf
                    caculationServerDKKD200(yearchon);

                    ///===============

                    var rptdetail = from p in dc.RPtdetailKQKD200s
                                    where p.username == username


                                    select p;



                    var dataset2 = ut.ToDataTable(dc, rptdetail);



                    Reportsview rpt = new Reportsview(dataset1, dataset2, "BaocaoKQKD.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports


                }

                //   }
            }





            //   throw new NotImplementedException();
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
                    DateTime todate = Utils.chageExceldatetoData("31/12/" + yearchon);

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




                    #region caculation cdkt200 lien tuc
                    SqlConnection conn2 = null;
                    SqlDataReader rdr1 = null;

                    string destConnString = Utils.getConnectionstr();
                    try
                    {

                        conn2 = new SqlConnection(destConnString);
                        conn2.Open();
                        SqlCommand cmd1 = new SqlCommand("calulationCDPStoRptdetaiCDP", conn2);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandTimeout = 0;
                        cmd1.Parameters.Add("@username", SqlDbType.VarChar).Value = Utils.getusername();
                        cmd1.Parameters.Add("@yearchon", SqlDbType.Int).Value = int.Parse(yearchon);
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
                    //     MessageBox.Show("ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #endregion





                    var rptdetail = from p in dc.RptdetaiCDPs
                                    where p.username == username
                                    orderby p.matk

                                    select new {
                                            p.Codk,
                                            p.Nodk,
                                            p.matk,
                                        tentk =     p.tentk.Trim(),
                                        Psco =        p.Psco.GetValueOrDefault(0),
                                        Psno =      p.Psno.GetValueOrDefault(0),
                                        Nock =     p.Nock.GetValueOrDefault(0),
                                        Cock =   p.Cock.GetValueOrDefault(0),



                                    } ;



                    var dataset2 = ut.ToDataTable(dc, rptdetail);



                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Socandoitkphatsinh.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports


                }


            }
        }


        public static void sotonghopbaocaonhapxuatton()
        {
            string connection_string = Utils.getConnectionstr();
            string username = Utils.getusername();
            //  var db = new LinqtoSQLDataContext(connection_string);
            LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);


            #region  chọn sổ kho


            FormCollection fc = System.Windows.Forms.Application.OpenForms;
            bool chon;
            bool kq = false;
            foreach (Form frm in fc)
            {

                if (frm.Text == "Chọn kho")
                {
                    kq = true;
                    frm.Focus();

                }
            }

            if (!kq)
            {


                View.Beeseleckhobcxnt Beeseleckhohang = new View.Beeseleckhobcxnt();
                Beeseleckhohang.ShowDialog();

                chon = Beeseleckhohang.chon;
                DateTime fromdate = Beeseleckhohang.fromdate;
                DateTime todate = Beeseleckhohang.todate;

                string makho = Beeseleckhohang.makho;
                string tenkho = Beeseleckhohang.tenkho;



                if (chon)
                {
                    #region showreport

                    #region     // xoa data cũ

                    //    string username = Utils.getusername();

                    var listRptthchitiet = from p in dc.RptdetaiTHxuatnhaptons
                                           where p.username == username
                                           select p;

                    dc.RptdetaiTHxuatnhaptons.DeleteAllOnSubmit(listRptthchitiet);
                    dc.SubmitChanges();


                    var listrptheadchitiet = from p in dc.RPtheadTHxuatnhaptons
                                             where p.username == username
                                             select p;

                    dc.RPtheadTHxuatnhaptons.DeleteAllOnSubmit(listrptheadchitiet);
                    dc.SubmitChanges();
                    #endregion          // xoa data cũ



                    #region  // update head mới  


                    RPtheadTHxuatnhapton headTHxnhapton = new RPtheadTHxuatnhapton();


                    headTHxnhapton.kho = tenkho.Trim(); //mataikhoan.Trim() + "-" + 
                    headTHxnhapton.tencongty = Model.Congty.getnamecongty();
                    headTHxnhapton.username = username;
                    headTHxnhapton.diachicongty = Model.Congty.getdiachicongty();
                    headTHxnhapton.masothue = Model.Congty.getmasothuecongty();
                    headTHxnhapton.tungay = fromdate;
                    headTHxnhapton.denngay = todate;

                    dc.RPtheadTHxuatnhaptons.InsertOnSubmit(headTHxnhapton);
                    dc.SubmitChanges();




                    var header = from p in dc.RPtheadTHxuatnhaptons
                                 where p.username == username
                                 select p;


                    Utils ut = new Utils();
                    var dataset1 = ut.ToDataTable(dc, header);

                    #endregion  // update head mới  

                    #region  update data detail mới

                    var sanpham = from p in dc.tbl_kho_sanphams
                                  where p.makho == makho
                                  select p;

                    if (sanpham.Count() > 0)
                    {
                        int stt = 0;
                        foreach (var item in sanpham)
                        {
                            stt = stt + 1;
                            RptdetaiTHxuatnhapton detail = new RptdetaiTHxuatnhapton();

                            detail.stt = stt;


                            detail.mahanghoa = item.masp;
                            detail.tenhanghoa = item.tensp;
                            detail.donvi = item.donvi;


                            detail.tondaukysoluong = (from p in dc.tbl_kho_phieunhap_details
                                                      where p.ngayphieunhap < fromdate
                                           && p.makho == item.makho
                                           && p.mahang == item.masp
                                                      select p.soluongnhap).Sum().GetValueOrDefault(0)
                                                      + (from p in dc.tbl_kho_sanphams
                                                         where p.masp == item.masp
                                                        && p.makho == item.makho
                                                         select p.tondksoluong).FirstOrDefault()
                                      - (from p in dc.tbl_kho_phieuxuat_details
                                         where p.ngayphieuxuat < fromdate
                                              && p.makho == item.makho
                                          && p.mahang == item.masp
                                         select p.soluongxuat).Sum().GetValueOrDefault(0);

                            detail.tondaukythanhtien = (from p in dc.tbl_kho_phieunhap_details
                                                        where p.ngayphieunhap < fromdate
                                             && p.makho == item.makho
                                             && p.mahang == item.masp
                                                        select p.thanhtien).Sum().GetValueOrDefault(0)
                                                        + (from p in dc.tbl_kho_sanphams
                                                           where p.masp == item.masp
                                                            && p.makho == item.makho
                                                           select p.tondkthanhtien).FirstOrDefault()
                                                        - (from p in dc.tbl_kho_phieuxuat_details
                                                           where p.ngayphieuxuat < fromdate
                                                               && p.makho == item.makho
                                                               && p.mahang == item.masp
                                                           select p.thanhtien).Sum().GetValueOrDefault(0);


                            detail.nhaptrongkysoluong = (from p in dc.tbl_kho_phieunhap_details
                                                         where p.ngayphieunhap >= fromdate
                                                         && p.ngayphieunhap <= todate
                                              && p.makho == item.makho
                                              && p.mahang == item.masp
                                                         select p.soluongnhap).Sum().GetValueOrDefault(0);

                            detail.nhaptrongkythanhtien = (from p in dc.tbl_kho_phieunhap_details
                                                           where p.ngayphieunhap >= fromdate
                                                           && p.ngayphieunhap <= todate
                                                && p.makho == item.makho
                                                && p.mahang == item.masp
                                                           select p.thanhtien).Sum().GetValueOrDefault(0);


                            detail.xuattrongkysoluong = (from p in dc.tbl_kho_phieuxuat_details
                                                         where p.ngayphieuxuat >= fromdate
                                                         && p.ngayphieuxuat <= todate
                                              && p.makho == item.makho
                                              && p.mahang == item.masp
                                                         select p.soluongxuat).Sum().GetValueOrDefault(0);

                            detail.xuattrongkythanhtien = (from p in dc.tbl_kho_phieuxuat_details
                                                           where p.ngayphieuxuat >= fromdate
                                                           && p.ngayphieuxuat <= todate
                                                && p.makho == item.makho
                                                && p.mahang == item.masp
                                                           select p.thanhtien).Sum().GetValueOrDefault(0);


                            detail.toncuoikysoluong = detail.tondaukysoluong
                                + detail.nhaptrongkysoluong
                                - detail.xuattrongkysoluong;


                            detail.toncuoikythanhtien = detail.tondaukythanhtien
                                + detail.nhaptrongkythanhtien
                                - detail.xuattrongkythanhtien;

                            if (detail.toncuoikysoluong != 0)
                            {
                                detail.dongiaton = detail.toncuoikythanhtien / detail.toncuoikysoluong;

                            }
                            else
                            {
                                detail.dongiaton = 0;
                            }

                            detail.username = username;


                            dc.RptdetaiTHxuatnhaptons.InsertOnSubmit(detail);
                            dc.SubmitChanges();








                        }


                    }


                    #endregion update data detail region

                    var rptdetail = from p in dc.RptdetaiTHxuatnhaptons
                                    where p.username == username
                                    orderby p.stt

                                    select p;



                    var dataset2 = ut.ToDataTable(dc, rptdetail);



                    Reportsview rpt = new Reportsview(dataset1, dataset2, "Sotonghopxuatnhapton.rdlc");



                    rpt.ShowDialog();


                    #endregion showreports




                }


            }





            #endregion



        }

    }
}

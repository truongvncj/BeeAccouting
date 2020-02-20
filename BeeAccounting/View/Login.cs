using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;



namespace BEEACCOUNT.View
{
    public partial class Login : Form
    {



        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            String current = System.IO.Directory.GetCurrentDirectory();

            string fileName = current + "\\String.txt";
            string connection_string = "";
            string st1 = "";
            string st2 = "";
            string st3 = "";
            string st4 = "";
        //    string st5 = "";

  

            //        string st4 = "";
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)

                {
                    string[] parts = line.Split(';');

                    st1 = parts[0].Trim();
                    st2 = parts[1].Trim();
                    st3 = parts[2].Trim();
                    st4 = parts[3].Trim();
                 //   st5 = parts[4].Trim();
                   // }
                  


                    //   if (st4 =="cn") tam thoi thay server  = chua8923_BEE  còn mặc định là BEE
                    //   {
                    connection_string = ("Data Source =" + st1 + "; Initial Catalog =" + st4 + "; User Id =" + st2 + "; Password =" + st3).Trim();
                    //    }
                    // /
                    //       connection_string = "Data Source = DESKTOP-8D4F853\\SQLEXPRESS; Initial Catalog = BEEACCOUNT; User Id = SA; Password = 123123";

                    //        HAN - L - 3PFF7H2; SA; Tienmat102$; BEE; tr1


                }
            }

            if (textBox1.Text != "" & textBox2.Text != "")
            {
                string queryText = @"SELECT Count(*) FROM tbl_Temp 
                             WHERE username = @Username AND password = @Password";
                using (SqlConnection cn = new SqlConnection(connection_string))
                using (SqlCommand cmd = new SqlCommand(queryText, cn))
                {
                    try
                    {
                        cn.Open();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Lỗi đường truyền dữ liệu !"  , "Connection !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    int result = (int)cmd.ExecuteScalar();
                    if (result > 0)
                    {

                        #region ghi vao data pass, user, connectstring
                        //connection_string = ("Data Source =" + st1 + "; Initial Catalog =" + st4 + "; User Id =" + st2 + "; Password =" + st3).Trim();
                        ////    }
                        //// /
                        ////       connection_string = "Data Source = DESKTOP-8D4F853\\SQLEXPRESS; Initial Catalog = BEEACCOUNT; User Id = SA; Password = 123123";

                        ////        HAN - L - 3PFF7H2; SA; Tienmat102$; BEE; tr1


                        string s1 = st1 + ";" + st2 + ";" + st3 + ";" +st4+";"+ textBox1.Text;

                        using (StreamWriter sw = new StreamWriter(fileName))
                        {

                            try
                            {
                                sw.WriteLine(s1);
                            }
                            catch (Exception)
                            {

                                //  MessageBox.Show("Không ghi được, file server lost !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                        #endregion



                        Model.Username user = new Model.Username();
                        int Ver = Model.Username.getVersion();
                        if (Ver == 55)
                        {

                            this.Hide();
                            View.Main main = new Main(); //
                            main.Closed += (s, args) => this.Close();
                            main.Show();
                        }
                        else
                        {

                            MessageBox.Show("You are using old version \n please use the new BEE ACCOUTING : " + Ver.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.Close();


                        }




                    

                    }
                    else
                        MessageBox.Show("Wrong Username and Password !", "Connection !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }







        }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{

        //}

        private void textBox1_Enter(object sender, EventArgs e)
        {
            //   textBox2.
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            //    button1.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.textBox2.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

            View.BeeServersetup stup = new BeeServersetup();
            stup.Show();


        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BEEACCOUNT.shared;

namespace BEEACCOUNT.View
{
    public partial class Beemonthandyearsellect : Form
    {

        public string year { get; set; }
        public string month { get; set; }
        public bool chon { get; set; }
        public Beemonthandyearsellect()
        {
            InitializeComponent();
            this.year = "";
            this.month = "";
            //cb_year.Items.Clear();
            //int yearnow = DateTime.Today.Year-5;
            //year = yearnow.ToString();

            //chon = false;
            //for (int i = 0; i < 10; i++)
            //{
            //    yearnow = yearnow + 1;
            //    cb_year.Items.Add(yearnow);

            //}
            //cb_year.SelectedIndex = 4;
           

        }

        private void cb_year_SelectedValueChanged(object sender, EventArgs e)
        {
         ////   bl_priod.Text = StringExtensions.Right(cb_year.Text,2) + cb_month.Text ;
        }

        private void cb_month_SelectedValueChanged(object sender, EventArgs e)
        {
         //   bl_priod.Text = StringExtensions.Right(cb_year.Text, 2) + cb_month.Text;
        }

        private void bl_priod_Click(object sender, EventArgs e)
        {



        }

        private void pkfromdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Beeyearsellect_Load(object sender, EventArgs e)
        {

        }

        private void bt_thuchien_Click(object sender, EventArgs e)
        {
            chon = true;

            year = cb_year.Text.ToString().Trim();
            month = cbmonthchon.Text.ToString().Trim();
            this.Close();
        }
    }
}

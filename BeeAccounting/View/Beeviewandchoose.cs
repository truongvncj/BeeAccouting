using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BEEACCOUNT.View
{
    public partial class Beeviewandchoose : Form
    {

        public int value;
        public bool kq;
        //  public string value;
        //public class ComboboxItem
        //{
        //    public string Text { get; set; }
        //    public object Value { get; set; }

        //    public override string ToString()
        //    {
        //        return Text;
        //    }
        //}



        public Beeviewandchoose(string headcolumname, IQueryable rs, LinqtoSQLDataContext dc)
        {
            InitializeComponent();

            this.label1.Text = headcolumname;


            dataGridView1.DataSource = rs;
            // cbselect.DataSource = CombomCollection;
            this.kq = false;
            //    this.value = 

        }

        private void valueinput_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

          


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyEventArgs e)
        {
          


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.CurrentCell.RowIndex >= 0)
            {
                this.value = int.Parse(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString());

                kq = true;

                this.Close();
            }
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}

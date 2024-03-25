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


    public partial class Chonchitietphaitra : Form
    {

        public int value;
        public bool kq;

        void Control_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                if (this.dataGridView1.CurrentCell != null)
                {

                    if (this.dataGridView1.CurrentCell.RowIndex >= 0)
                    {


                        this.value = int.Parse(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString());

                        kq = true;
                    }

                }

                this.Close();
            }

            if (e.KeyData == Keys.Escape)
            {
                this.Close();

            }


        }




        public Chonchitietphaitra(string headcolumname, IQueryable rs, LinqtoSQLDataContext dc)
        {
            InitializeComponent();

            this.label1.Text = headcolumname;

            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(Control_KeyPress);

            dataGridView1.DataSource = rs;

            dataGridView1.Columns["id"].Visible = false;

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

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (this.dataGridView1.CurrentCell.RowIndex >= 0)
                {
                    this.value = int.Parse(this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString());

                    kq = true;

                    this.Close();
                }

            }
        }

        private void tbsochitiet_Click(object sender, EventArgs e)
        {

            Beemosochitiettaikhoan mochitiet = new Beemosochitiettaikhoan(5, "331", 0);
            mochitiet.Show();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

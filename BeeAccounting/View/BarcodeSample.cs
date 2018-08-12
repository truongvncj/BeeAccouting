using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Drawing.Imaging;

namespace BEEACCOUNT.View
{
    public partial class BarcodeSample : Form
    {
        public BarcodeSample()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string barcode = textBox1.Text;

            Font afont = new System.Drawing.Font("",20);
            Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);
            PointF point = new PointF(2f, 2f);



        }
    }
}

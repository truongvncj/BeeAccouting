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

    // public static 
    public partial class kaconfirmPayment : Form
    {

        public View.CreatenewContract Contractview { get; set; }

        public string ContractNo { get; set; }
        public string Description { get; set; }
        //  string Description
        // PaymentDoc
        public string PaymentDoc { get; set; }
        public int Batchno { get; set; }

        public string Programe { get; set; } //= programe
        public int PayID { get; set; } //= int.Parse(this.lb_uncofirm.Text.ToString());
        public int SubID { get; set; }// = int.Parse(this.txconfimr.Text.ToString()); //deposiamount + deposiamount

        public double PaidRequestAmt { get; set; } //= int.Parse(this.lb_uncofirm.Text.ToString());
   //     public string header { get; set; }




     //   public string header { get; set; }
        public kaconfirmPayment(View.CreatenewContract Contract, string ContractNo,  int Batchno, string Programe, int PayID, int SubID, double PaidRequestAmt, string Description, string PaymentDoc)
        {

        

            #region khowri taoj



            InitializeComponent();
            //     this.header = header;
            this.Contractview = Contract;
            this.ContractNo = ContractNo;
            this.Description = Description;
            this.PaymentDoc = PaymentDoc;
            this.Batchno = Batchno;
            this.Programe = Programe;
            this.PayID = PayID;
            this.SubID = SubID;
            this.PaidRequestAmt = PaidRequestAmt;

            //string connection_string = Utils.getConnectionstr();
            //LinqtoSQLDataContext dc = new LinqtoSQLDataContext(connection_string);
            txtPaydoc.Text = PaymentDoc.Trim();
            lbcontractno.Text = ContractNo.Trim();
            txtpaidnote.Text = Description.Trim();
            lbBactchdoc.Text = Batchno.ToString();
            lb_programe.Text = Programe.ToString();
            lbpayid.Text = PayID.ToString();
            lbsubid.Text = SubID.ToString();
            lbpaymentamt.Text = PaidRequestAmt.ToString();

            pickdatedoneon.Value = DateTime.Today;
            #endregion




        }

        private void label4_Click(object sender, EventArgs e)
        {


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {





        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                txtPaydoc.Focus();




            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void kaconfirmPayment_Load(object sender, EventArgs e)
        {

        }

        private void txtpaidnote_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void pickdatedoneon_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtpaidnote2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                button1.Focus();




            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mydatabase
{
    public partial class Formpay : Form
    {
        
        public Formpay()
        {
            InitializeComponent();
        }

        // public string 
        public string getText()
        {
            return numericamount.Text;
        }




        private void buttonpay_Click(object sender, EventArgs e)
        {
            // pag nag enter ka nag amount at at sobra

            int checkamount = Convert.ToInt32(numericamount.Value);
            if (MessageBox.Show("You Have Entered Exactly: " + numericamount.Text + " PHP", "Confirm Payment?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (checkamount > StudentInfo.checkfees)
                {
                    MessageBox.Show("Entered Values Exceeds The Limit Fees!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    button1.PerformClick();
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1.DialogResult = DialogResult.OK;
           
           
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericamount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }
    }
}

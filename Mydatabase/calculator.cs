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
    public partial class StudCal : Form
    {
        public StudCal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Studname.Text))
            {
                MessageBox.Show("Enter Your Name");
                return;
            }
            if (string.IsNullOrEmpty(Block.Text))
            {
                MessageBox.Show("Enter Your Block");
                return;
            }
            if (string.IsNullOrEmpty(sub1.Text))
            {
                MessageBox.Show("Enter Your  Grade  of Subject IT105");
                return;
            }
            if (string.IsNullOrEmpty(sub2.Text))
            {
                MessageBox.Show("Enter Your  Grade  of Subject IT104");
                return;
            }
            if (string.IsNullOrEmpty(sub3.Text))
            {
                MessageBox.Show("Enter Your  Grade  of Subject IT103");
                return;
            }
            if (string.IsNullOrEmpty(sub4.Text))
            {
                MessageBox.Show("Enter Your  Grade  of Subject IT102");
                return;
            }
            if (string.IsNullOrEmpty(sub5.Text))
            {
                MessageBox.Show("Enter Your  Grade  of Subject IT101");
                return;
            }
            if (string.IsNullOrEmpty(sub6.Text))
            {
                MessageBox.Show("Enter Your  Grade  of Subject UTS");
                return;
            }
            if (string.IsNullOrEmpty(sub7.Text))
            {
                MessageBox.Show("Enter Your  Grade  of Subject MANFIL");
                return;
            }
            if (string.IsNullOrEmpty(sub8.Text))
            {
                MessageBox.Show("Enter Your  Grade  of Subject PEH");
                return;
            }


            double IT105, IT104, IT103, IT102, IT101, UTS, MANFIL, PEH;

            IT105 = Convert.ToDouble(sub1.Text);
            IT104 = Convert.ToDouble(sub2.Text);
            IT103 = Convert.ToDouble(sub3.Text);
            IT102 = Convert.ToDouble(sub4.Text);
            IT101 = Convert.ToDouble(sub5.Text);
            UTS = Convert.ToDouble(sub6.Text);
            MANFIL = Convert.ToDouble(sub7.Text);
            PEH = Convert.ToDouble(sub8.Text);
            double sum = IT105 + IT104 + IT103 + IT102 + IT101 + UTS + MANFIL + PEH;
            double average = sum / 8;
            avgbox.Text = average.ToString("0.00");


            string equivalentnumber = GetequivalentNumber(average);
            string equivalentletter = GetequivalentLetter(average);
            eqlBox.Text = equivalentletter;
            eqnBox.Text = equivalentnumber;


            listBox1.Items.Clear();
            listBox1.Items.Add("Name: " + Studname.Text);
            listBox1.Items.Add("Year / Block: " + Block.Text);
            listBox1.Items.Add("IT105: " + sub1.Text);
            listBox1.Items.Add("IT104: " + sub2.Text);
            listBox1.Items.Add("IT103: " + sub3.Text);
            listBox1.Items.Add("IT102: " + sub4.Text);
            listBox1.Items.Add("IT101: " + sub5.Text);
            listBox1.Items.Add("UTS: " + sub6.Text);
            listBox1.Items.Add("MANFIL: " + sub7.Text);
            listBox1.Items.Add("PEH: " + sub8.Text);
            listBox1.Items.Add("Average: " + avgbox.Text);
            listBox1.Items.Add("Equivalent Letter: " + eqlBox.Text);
            listBox1.Items.Add("Equivalent Number: " + eqnBox.Text);
            MessageBox.Show("Succesfully");
            return;


        }

        private string GetequivalentNumber(double average)
        {
            if (average >= 100)
                return "1.00";
            else if (average >= 90)
                return "1.50";
            else if (average >= 89)
                return "1.75";
            else if (average >= 85)
                return " 2.00";
            else if (average >= 80)
                return "2.50";
            else if (average >= 79)
                return "2.75";
            else if (average >= 75)
                return "3.00";
            else
                return "5.00";

        }

        private string GetequivalentLetter(double average)
        {
            if (average >= 100)
                return "A+";
            else if (average >= 90)
                return "A";
            else if (average >= 89)
                return "B+";
            else if (average >= 85)
                return " B";
            else if (average >= 80)
                return "C+";
            else if (average >= 79)
                return "C";
            else if (average >= 75)
                return "D";
            else
                return "F";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clear All");
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form items = new firstpage();
            items.Show();
            this.Hide();
            MessageBox.Show("Thank you");
            return;
        }
    }
}


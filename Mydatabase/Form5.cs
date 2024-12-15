using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Mydatabase
{


    public partial class Form5 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        Formpay frm3;
   
     
            int BSITamount = StudentInfo.BSIT;

        public Form5()
        {
            InitializeComponent();

           


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string a = CnTxt.Text;
            string v = fname.Text;
            string z = Mname.Text;
            string n = Lname.Text;
            string s = Add.Text;
            string q = bd.Text;
            string r = comboBox1.Text;
            string f = bp.Text;
            string h = ngTxt.Text;

            if (string.IsNullOrEmpty(CnTxt.Text))
            {
                MessageBox.Show("Enter Your ContactNumber Please", "Error");
                return;
            }
            else if (string.IsNullOrEmpty(fname.Text))
            {
                MessageBox.Show("Enter Your FirstName Please", "Error");
                return;
            }
            else if (string.IsNullOrEmpty(Mname.Text))
            {
                MessageBox.Show("Enter Your MiddleName Please", "Error");
                return;
            }
            else if (string.IsNullOrEmpty(Lname.Text))
            {
                MessageBox.Show("Enter Your LastName Please", "Error");
                return;
            }
            else if (string.IsNullOrEmpty(Add.Text))
            {
                MessageBox.Show("Enter Your Address Please", "Error");
                return;
            }
            else if (string.IsNullOrEmpty(ngTxt.Text))
            {
                MessageBox.Show("Enter Your GuardianName Please", "Error");
                return;
            }

            else if (string.IsNullOrEmpty(bd.Text))
            {
                MessageBox.Show("Enter Your BirthDay Please", "Error");
                return;
            }
            else if (string.IsNullOrEmpty(bp.Text))
            {
                MessageBox.Show("Enter Your  BirthPlace Please", "Error");
                return;
            }
            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Choose Your Gender Please", "Error");
                return;
            }
            else if (string.IsNullOrEmpty(paymentbutton.Text))
            {
                MessageBox.Show("Choose Your Gender Please", "Error");
                return;
            }

            else
            {
                MessageBox.Show("SuccesFully Register", "Thank You");

            }


            CnTxt.ReadOnly = true;
            fname.ReadOnly = true;
            Mname.ReadOnly = true;
            Lname.ReadOnly = true;
            Add.ReadOnly = true;
            bd.Enabled = false;
            bp.ReadOnly = true;
            comboBox1.Enabled = false;
            bsit.Enabled = false;
            paymentbutton.Enabled = false;
            comboBox1.Enabled = false;
            listBox1.Items.Add("Current Date: " + DateTime.Now.ToString());
            listBox1.Items.Add("Name Of Enrollee: " + fname.Text + " " + Mname.Text + " " + Lname.Text);
            StudentInfo.checkname = Lname.Text + " " + fname.Text + " " + Mname.Text;
            listBox1.Items.Add("Address: " + Add.Text);
            listBox1.Items.Add("Birth Place: " + bp.Text);
            listBox1.Items.Add("Birth Date: " + bd.Text);
            listBox1.Items.Add("Name Of Guardian: " + ngTxt.Text);


            if (paymentbutton.Text == "Cash")
            {
                int payment = BSITamount;
                int change = 0;
                MessageBox.Show("Payment Successful");
                listBox1.Items.Add("Mode Of Payment: Cash");
                listBox1.Items.Add("Amount Paid: " + payment + " PHP");
                listBox1.Items.Add("Remaining Fees: " + change + " PHP");
               

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO  chrislogin.studinfo ( Course, Fname, Mname, Lname, Birthday,Address, Birthplace, NGuardian, Sex, ContactNumber, TotalFee, Totalpaid, ReamingFee) VALUES ( @Course, @Fname, @Mname, @Lname, @Birthday,@Address,@Birthplace, @NGuardian, @Sex, @ContactNumber, @TotalFee, @Totalpaid, @ReamingFee)";
                command.Parameters.AddWithValue("@Fname", fname.Text);
                command.Parameters.AddWithValue("@Mname", Mname.Text);
                command.Parameters.AddWithValue("@Lname", Lname.Text);
                command.Parameters.AddWithValue("@Birthday", bd.Text);
                command.Parameters.AddWithValue("@Address", Add.Text);
                command.Parameters.AddWithValue("@Birthplace", bp.Text);
                command.Parameters.AddWithValue("@NGuardian", ngTxt.Text);
                command.Parameters.AddWithValue("@Sex", comboBox1.Text);
                command.Parameters.AddWithValue("@ContactNumber", CnTxt.Text);
                command.Parameters.AddWithValue("@Course", bsit.Text);
                command.Parameters.AddWithValue("@TotalFee", StudentInfo.BSIT);
                command.Parameters.AddWithValue("@Totalpaid", StudentInfo.BSIT);
                command.Parameters.AddWithValue("@ReamingFee", StudentInfo.BSIT);
                command.Parameters.AddWithValue("@DateEnrollment", DateTime.Now.ToShortDateString());
                command.ExecuteNonQuery();
                connection.Close();
                return;
            }

           

            else if (bsit.Checked)
            {
                listBox1.Items.Add("Course: BSIT");
                listBox1.Items.Add("Total Fees: " + StudentInfo.BSIT + " PHP");
                StudentInfo.checkcourse = "BSIT";
                StudentInfo.checkfees = 31500;
                int BSITamount = StudentInfo.BSIT;

             

                frm3 = new Formpay();
                DialogResult dr = frm3.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    StudentInfo.checkcourse = String.Empty;
                    StudentInfo.checkfees = 0;
                    StudentInfo.checkname = String.Empty;
                    frm3.Close();
                    Add.ReadOnly = false;
                    Add.Clear();
                    Lname.ReadOnly = false;
                    Lname.Clear();
                    fname.ReadOnly = false;
                    fname.Clear();
                    Mname.ReadOnly = false;
                    Mname.Clear();
                    ngTxt.ReadOnly = false;
                    ngTxt.Clear();
                    CnTxt.ReadOnly = false;
                    CnTxt.Clear();
                    bp.ReadOnly = false;
                    bp.Clear();
                    bd.ReadOnly = false;
                    bd.Clear();
                    comboBox1.Enabled = false;
                    paymentbutton.Enabled = true;
                    paymentbutton.Items.Clear();
                    paymentbutton.Items.Add("Cash");
                    paymentbutton.Items.Add("Installment");
                    listBox1.Items.Clear();
                }

                else if (dr == DialogResult.OK)
                {
                    if (Convert.ToInt32(frm3.getText()) > BSITamount)
                    {
                        MessageBox.Show("Amount Limit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    else
                    {
                        int payment = Convert.ToInt32(frm3.getText());
                        int change = BSITamount - payment;
                        MessageBox.Show("Payment Succesful");
                        listBox1.Items.Add("Mode Of Payment: " + paymentbutton.Text);
                        paymentbutton.Enabled = false;
                        listBox1.Items.Add("Amount Payed: " + frm3.getText() + " PHP");
                        listBox1.Items.Add("Remaining Fees: " + change + " PHP");
                        frm3.Close();
                    }
                }
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO  chrislogin.studinfo ( Course, Fname, Mname, Lname, Birthday,Address, Birthplace, NGuardian, Sex, ContactNumber, TotalFee, Totalpaid, ReamingFee) VALUES ( @Course, @Fname, @Mname, @Lname, @Birthday,@Address,@Birthplace, @NGuardian, @Sex, @ContactNumber, @TotalFee, @Totalpaid, @ReamingFee)";
                command.Parameters.AddWithValue("@Fname", fname.Text);
                command.Parameters.AddWithValue("@Mname", Mname.Text);
                command.Parameters.AddWithValue("@Lname", Lname.Text);
                command.Parameters.AddWithValue("@Birthday", bd.Text);
                command.Parameters.AddWithValue("@Address", Add.Text);
                command.Parameters.AddWithValue("@Birthplace", bp.Text);
                command.Parameters.AddWithValue("@NGuardian", ngTxt.Text);
                command.Parameters.AddWithValue("@Sex", comboBox1.Text);
                command.Parameters.AddWithValue("@ContactNumber", CnTxt.Text);
                if (bsit.Checked)
                {
                    command.Parameters.AddWithValue("@Course", bsit.Text);
                    command.Parameters.AddWithValue("@TotalFee", StudentInfo.BSIT);
                    command.Parameters.AddWithValue("@Totalpaid", Convert.ToInt32(frm3.getText()));
                    command.Parameters.AddWithValue("@ReamingFee", StudentInfo.BSIT - Convert.ToInt32(frm3.getText()));
                    command.Parameters.AddWithValue("@DateEnrollment", DateTime.Now.ToShortDateString());
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                if (listBox1.Items.Count > 1)
                {
                    listBox1.Items.Add("Confirmation Successful!");
                }

            }

        }

 
    


        private void button4_Click(object sender, EventArgs e)
        {
            //select clear button

            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }

            else
            {
                MessageBox.Show("Please select an item");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // all clear

            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            Form items = new firstpage();
            items.Show();
            this.Hide();
            MessageBox.Show("Thank You");
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            paymentbutton.Items.Add("Cash");
            paymentbutton.Items.Add("Installment");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void CnTxt_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void CnTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

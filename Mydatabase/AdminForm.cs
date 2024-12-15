using MySql.Data.MySqlClient;
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
    public partial class Formadd : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;

        public Formadd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM chrislogin.studinfo ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

           



            string connection = "datasource=localhost;port=3306;username=root;password=";
            string query = "DELETE FROM chrislogin.studinfo WHERE Number='" + this.Num.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            if (string.IsNullOrEmpty(Num.Text))
            {
                MessageBox.Show(" Enter the Student Number To Delete");
                return;
            }
            else
            {
                MessageBox.Show("Data has been succesfully deleted!!");
                conn.Close();
            }



        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            
        }

        private void Num_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connection = "datasource=localhost;port=3306;username=root;password=";
            string query = "UPDATE chrislogin.studinfo SET Fname='" + this.fname.Text + "',Mname='" + this.mname.Text + "',Lname='" + this.lname.Text + "',Sex='" + this.sex.Text + "',Address='" + "',Course='" + this.course.Text + "',Birthday='" + this.bd.Text + "',BirthPlace='" + this.bp.Text + "',NGuardian='" + this.ng.Text + "',ContactNumber='" + this.Cnumber.Text + "' WHERE Number='" + this.Num.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            if (string.IsNullOrEmpty(fname.Text))
            {
                MessageBox.Show(" Enter The FirstName");
                return;
            }
             else if (string.IsNullOrEmpty(mname.Text))
            {
                MessageBox.Show("Enter The Middle Name");
                return;
            }
               else if( string.IsNullOrEmpty(lname.Text))
            {
                MessageBox.Show("Enter The Last Name");
                return;
            }
                else if (string.IsNullOrEmpty(sex.Text))
            {
                MessageBox.Show("Enter The Gender");
                return;
            }
             else if(string.IsNullOrEmpty(course.Text))
            {
                MessageBox.Show("Enter The Course");
                return;
            } 
            
            
           else if(string.IsNullOrEmpty(bd.Text))
            {
                MessageBox.Show("Enter The Birthday");
                return;
            }
             else if(string.IsNullOrEmpty(bp.Text))
            {
                MessageBox.Show("Enter The BirthPlace");
                return;
            }  
            else if(string.IsNullOrEmpty(Cnumber.Text))
            {
                MessageBox.Show("Enter The ContactNumber");
                return;
            } 
            else if(string.IsNullOrEmpty(ng.Text))
            {
                MessageBox.Show("Enter The Student Number And More..");
                return;
            }
            else
            {
                MessageBox.Show("Record has been updated successfully");
                conn.Close();
            }


            fname.Text = "";
            mname.Text = "";
            lname.Text = "";
            sex.Text = "";
            bp.Text = "";
            bd.Text = "";
            add.Text = "";
            Cnumber.Text = "";
            course.Text = "";
            ng.Text = "";
            Num.Text = "";
            fname.Focus();














        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void degree_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cnumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form items = new StudCal();
            items.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form items = new Form5();
            items.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}

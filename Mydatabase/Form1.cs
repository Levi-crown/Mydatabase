using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// pinaka una sa connection para gumana ang syntax ng mysql
using MySql.Data.MySqlClient;

namespace Mydatabase
{
    public partial class Form1 : Form
    {
        // connection mysql and for maxattempts
        
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        private const int Maxxattempts = 3;
        private int LoginAttempts = Maxxattempts;
       
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            // if wlng laman ang txtbox ng user at pass with limit by chrisdev

            if (string.IsNullOrEmpty(userbox.Text) || string.IsNullOrEmpty(passbox.Text))
            {
                for (int v = 0; v < Maxxattempts; v++)
                {
                    LoginAttempts--;

                    if (LoginAttempts == 2)
                    {
                        MessageBox.Show("Your Attempts Reaming is 3");
                        return;

                    }

                    else if (LoginAttempts == 1)
                    {
                        MessageBox.Show("Your Attempts Reaming is 2");
                        return;
                    }

                    else if (LoginAttempts == 0)
                    {
                        MessageBox.Show("Your Attempts Reaming is 1");
                        return;

                    }

                    else
                    {
                        MessageBox.Show("Error Bye:");
                        Application.Exit();
                    }

                }
                return;
            }

            else
            {
                // connection database with limit

                for (int i = 0; i < Maxxattempts; i++)
                {

                    connection.Open();
                    string selectQuery = "SELECT * FROM chrislogin.userdata WHERE Username = '" + userbox.Text + "' AND Password = '" + passbox.Text + "';";
                    command = new MySqlCommand(selectQuery, connection);
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";
                        string Query = "update chrislogin.userdata set LastLogin='" + "' where Username='" + this.userbox.Text + "';";
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        MyConn2.Close();

                        MessageBox.Show("Login Successful!");
                        Form items = new firstpage();
                        items.Show();
                        this.Hide();
                        return;
                    }
                    connection.Close();

                    // code for if mali

                    LoginAttempts--;
                    if (LoginAttempts == 2)
                    {
                        MessageBox.Show("Incorrect Username And Password","Reaming Attempts 3");
                        return;
                    }
                    else if (LoginAttempts == 1)
                    {
                        MessageBox.Show("Incorrect Username And Password", "Reaming Attempts 2");
                        return;
                    }
                    else if (LoginAttempts == 0)
                    {
                        MessageBox.Show("Incorrect Username And Password", "Reaming Attempts 1");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sorry You Have Maxximun Attempts Trg Again later!","Error");
                        Application.Exit();

                    }

                }
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // show and hide pass

            if (passbox.UseSystemPasswordChar)
            {
                passbox.UseSystemPasswordChar = false;
            }
            else
            {
                passbox.UseSystemPasswordChar = true;
            }

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // exit form

            Application.Exit();

        }
        private void label6_Click(object sender, EventArgs e)
        {
            // next form signup

            Form items = new Form2();
            items.Show();
            this.Hide();
        }

        private void userbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label2_Click_2(object sender, EventArgs e)
        {
            // form for reset

            Form items = new resetForm();
            items.Show();
            this.Hide();
            return;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form items = new Admincs();
            items.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void passbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}

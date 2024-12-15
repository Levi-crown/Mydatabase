using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mydatabase
{
    public partial class Admincs : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        private const int Maxx = 3;
        private int dmaxx = Maxx;
        int b = 3;
        public Admincs()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userbox.Text) || string.IsNullOrEmpty(passbox.Text))
            {
                b = b - 1;
                if (b == 2)
                {
                    MessageBox.Show("Your Are NOt Admin", "Attempts Reaming 3");
                    return;
                }
                if (b == 1)
                {
                    MessageBox.Show("Your Are NOt Admin", "Attempts Reaming 3");
                    return;
                }
                if (b == 0)
                {
                    MessageBox.Show("Your Are NOt Admin", "Attempts Reaming 3");
                    return;
                }
                else
                {
                    MessageBox.Show("Sorry you are not admin");

                }
            }

            else
            {
                for (int i = 0; i < Maxx; i++)
                {

                    connection.Open();
                    string selectQuery = "SELECT * FROM chrislogin.userdata WHERE Admin = '" + userbox.Text + "' AND Adminpass = '" + passbox.Text + "';";
                    command = new MySqlCommand(selectQuery, connection);
                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";
                        string Query = "update chrislogin.userdata set LastLogin='" + "' where Admin='" + this.userbox.Text + "';";
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
                        Form items = new Formadd();
                        items.Show();
                        this.Hide();
                        return;
                    }
                    connection.Close();

                    dmaxx--;
                    if (dmaxx == 2)
                    {
                        MessageBox.Show("3");
                        return;
                    }
                    else if (dmaxx == 1)
                    {
                        MessageBox.Show("2");
                        return;
                    }
                    else if (dmaxx == 0)
                    {
                        MessageBox.Show("1");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("end");
                        Application.Exit();

                    }

                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (passbox.UseSystemPasswordChar)
            {
                passbox.UseSystemPasswordChar = false;
            }
            else
            {
                passbox.UseSystemPasswordChar = true;
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form items = new Form1();
            items.Show();
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}


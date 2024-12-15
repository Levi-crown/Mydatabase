using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mydatabase
{
    public partial class resetForm : Form
    {   // connection para gumana at ang databse at program
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;

        public resetForm()
        {
            InitializeComponent();
        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            // if wlng laman ang textbox

            if (string.IsNullOrEmpty(userbox.Text))
            {
                MessageBox.Show("Please enter your username to reset your password", "Forgot Password");
                return;
            }

            if (string.IsNullOrEmpty(conpassbox.Text))
            {
                MessageBox.Show("Please enter a new password to reset your password", "Forgot Password");
                return;
            }

            string newPassword = conpassbox.Text;

            // connection to mysql to update password

            connection.Open();
            string updateQuery = "UPDATE chrislogin.userdata SET Password = '" + newPassword + "' WHERE Username = '" + userbox.Text + "'";
            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
            int rowsAffected = updateCommand.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                // if ok na maglogin na sa main form
                MessageBox.Show("Your password has been successfully reset.", "Forgot Password");
                Form items = new firstpage();
                items.Show();
                this.Hide();
                return;
            }
            else
            {
                // else invalid ang iyong username

                MessageBox.Show("User not found or invalid username", "Forgot Password");
            }

            connection.Close(); // close connection to mysql
        }

    


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // to show password

            if (conpassbox.UseSystemPasswordChar)
            {
                conpassbox.UseSystemPasswordChar = false;
            }
            else
            {
                conpassbox.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // to exit

            MessageBox.Show("Thank you");
            Application.Exit();

           // end dev by chris benedict
        }

        private void conpassbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form items = new Form1();
            items.Show();
            this.Hide();
        }
    }
}

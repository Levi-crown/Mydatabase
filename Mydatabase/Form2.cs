using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Windows.Forms;
namespace Mydatabase
{
    public partial class Form2 : Form
    {
        // connection
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");


        public Form2()
        {
            InitializeComponent();
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            // if wlng laman no limit to

            if (string.IsNullOrEmpty(Fname.Text))
            {
                MessageBox.Show("Please fill out the  First Name!", "Error");
                return;
                
            }
            else if (string.IsNullOrEmpty(gender.Text))
            {
                MessageBox.Show("Please fill out the  Gender!", "Error");
                return;
                
            }
            else if (string.IsNullOrEmpty(lname.Text))
            {
                MessageBox.Show("Please fill out the  LastName!", "Error");
                return;

            }
            else if (string.IsNullOrEmpty(bdaybox.Text))
            {
                MessageBox.Show("Please fill out the  Birthday!", "Error");
                return;
                
            }
            else if (string.IsNullOrEmpty(emailbox.Text))
            {
                MessageBox.Show("Please fill out the  Email!", "Error");
                return;
                
            }
           else if (string.IsNullOrEmpty(userbox.Text))
            {
                MessageBox.Show("Please fill out the  Username!", "Error");
                return;
                
            }
           else if (string.IsNullOrEmpty(passbox.Text))
            {
                MessageBox.Show("Please fill out the  Password!", "Error");
                return;
                
            }
            else if (string.IsNullOrEmpty(conpassbox.Text))
            {
                MessageBox.Show("Please fill out the  Confirm password!", "Error");
                return;
                
            }

            else if (!this.emailbox.Text.Contains('@') || !this.emailbox.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           else  if (passbox.Text != conpassbox.Text)
            {
                MessageBox.Show("Password doesn't match!", "Error");
                return;
            }

            
            // open connection
            else
            {

                connection.Open();

                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM chrislogin.userdata WHERE Username = @Username", connection),
                cmd2 = new MySqlCommand("SELECT * FROM chrislogin.userdata WHERE Email = @UserEmail", connection);


                cmd1.Parameters.AddWithValue("@Username", userbox.Text);
                cmd2.Parameters.AddWithValue("@UserEmail", emailbox.Text);

                bool userExists = false, mailExists = false;

                using (var dr1 = cmd1.ExecuteReader())
                    if (userExists = dr1.HasRows) MessageBox.Show("Username not available!");

                using (var dr2 = cmd2.ExecuteReader())
                    if (mailExists = dr2.HasRows) MessageBox.Show("Email not available!");
                

                if (!(userExists || mailExists))
                {

                    string iquery = "INSERT INTO chrislogin.userdata(`ID`,`FirstName`,`LastName`,`Gender`,`Birthday`,`Email`,`Username`, `Password`) VALUES (NULL, '" + Fname.Text + "', '" + lname.Text + "', '" + gender.Text + "', '" + bdaybox.Value.Date + "', '" + emailbox.Text + "', '" + userbox.Text + "', '" + passbox.Text + "')";
                    MySqlCommand commandDatabase = new MySqlCommand(iquery, connection);
                    commandDatabase.CommandTimeout = 60;

                    try
                    {
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                    // if tama lahat  mapunta sa next form
                    MessageBox.Show("Account Successfully Created!","Welcome");
                    Form items = new firstpage();
                    items.Show();
                    this.Hide();

                }

                connection.Close();
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

            if (conpassbox.UseSystemPasswordChar)
            {
                conpassbox.UseSystemPasswordChar = false;
            }
            else
            {
                conpassbox.UseSystemPasswordChar = true;
            }
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            gender.Items.Add("Female");
            gender.Items.Add("Male");

        }

        private void button1_Click(object sender, EventArgs e)
        {


            Fname.Text = "";
            lname.Text = "";
            gender.Text = "";
            bdaybox.Text = "";
            emailbox.Text = "";
            userbox.Text = "";
            passbox.Text = "";
            conpassbox.Text = "";
            Fname.Focus();
            MessageBox.Show("Successfully Clear", "Heyey");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form items = new Form1();
            items.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void emailbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

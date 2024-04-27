using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asgard_Hospital
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }

        private void loginform_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string myusername = this.myusername.Text;
            string mypassword = this.textpassword.Text;

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnString = "server=127.0.0.1;user=root;password=hazel;database=medical_record;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnString);
                conn.Open();


                // Update all users to "Inactive" initially
                string updateAllUsersSql = "UPDATE users SET Status = 'Inactive'";
                MySqlCommand updateAllUsersCommand = new MySqlCommand(updateAllUsersSql, conn);
                updateAllUsersCommand.ExecuteNonQuery();

                //Check the login credentials
                string sql = "SELECT COUNT(*) FROM users WHERE Username = @myusername AND Password = @mypassword";

                MySqlCommand command = new MySqlCommand(sql, conn);
                {
                    command.Parameters.AddWithValue("@myusername", myusername);
                    command.Parameters.AddWithValue("@mypassword", mypassword);

                    int result = Convert.ToInt32(command.ExecuteScalar());
                    if (result > 0)
                    {
                        // Update the status of the logged-in user to "Active"
                        string updateLoggedInUserSql = "UPDATE users SET Status = 'Active' WHERE Username = @myusername";
                        MySqlCommand updateLoggedInUserCommand = new MySqlCommand(updateLoggedInUserSql, conn);
                        updateLoggedInUserCommand.Parameters.AddWithValue("@myusername", myusername);
                        updateLoggedInUserCommand.ExecuteNonQuery();

                        MessageBox.Show("Login Successful!");
                        this.Hide();
                        Dashboard dashboardForm = new Dashboard();
                        dashboardForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password. Please try again", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasswordRecov recovform = new PasswordRecov();  
            recovform.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn signInform = new SignIn();
            signInform.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        
        }
    }
}

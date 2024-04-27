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

namespace Asgard_Hospital
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            string textUserName = this.textUserName.Text;
            string textPass = this.textPass.Text;
            string textName = this.textName.Text;
            string textEmail = this.textEmail.Text;

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnString = "server=127.0.0.1;user=root;password=hazel;database=medical_record;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnString);
                conn.Open();

                string sql = "INSERT INTO users (UserName, Password, Name, Email) VALUES (@username, @password, @name, @email)";

                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@username", textUserName);
                command.Parameters.AddWithValue("@password", textPass);
                command.Parameters.AddWithValue("@Name", textName);
                command.Parameters.AddWithValue("@email", textEmail);

                int rowsAffected = command.ExecuteNonQuery(); // Execute the insert query
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Sign Up Successful!");
                    loginform loginForm = new loginform();
                    loginForm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Please try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
    
}

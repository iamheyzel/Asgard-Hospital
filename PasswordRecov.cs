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
    public partial class PasswordRecov : Form
    {
        public PasswordRecov()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginform login = new loginform();
            login.Show();
            this.Hide();
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            string email = this.email.Text;

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnString = "server=127.0.0.1;user=root;password=hazel;database=medical_record;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnString);
                conn.Open();

                string sql = "SELECT COUNT(*) FROM users WHERE Email = @email";

                MySqlCommand command = new MySqlCommand(sql, conn);
                {
                    command.Parameters.AddWithValue("@email", email);

                    int result = Convert.ToInt32(command.ExecuteScalar());
                    if (result > 0)
                    {
                        this.Hide();
                        Resetpass resetForm = new Resetpass();
                        resetForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email. Please try again", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void PasswordRecov_Load(object sender, EventArgs e)
        {

        }
    }
}
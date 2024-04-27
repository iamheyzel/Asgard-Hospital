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
    public partial class Resetpass : Form
    {
        public Resetpass()
        {
            InitializeComponent();
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            string oldpass = this.oldpass.Text;
            string newpass = this.newpass.Text;

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnString = "server=127.0.0.1;user=root;password=hazel;database=medical_record;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnString);
                conn.Open();

                string sql = "UPDATE users SET Password = @newpass WHERE Password = @oldpass";

                MySqlCommand command = new MySqlCommand(sql, conn);
                {
                    command.Parameters.AddWithValue("@oldpass", oldpass);
                    command.Parameters.AddWithValue("@newpass", newpass);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password Changed Successfully");
                        this.Hide();
                        loginform loginForm = new loginform();
                        loginForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Password change failed. Please ensure your old password is correct.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void newpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Resetpass_Load(object sender, EventArgs e)
        {

        }
    }
}

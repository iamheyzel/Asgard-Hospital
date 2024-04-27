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
using System.Xml.Linq;

namespace Asgard_Hospital
{
    // UpdateForm.cs

    public partial class Update : Form
    {

        public Update(string ID, string name, string username, string email)
        {
            InitializeComponent();

            txtIDno.Text = ID;
            txtName.Text = name;
            txtusername.Text = username;
            txtEmail.Text = email;

        }

        // Add update functionality


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the updated data from textboxes
            string updateID = txtIDno.Text;
            string updatedName = txtName.Text;
            string updatedUsername = txtusername.Text;
            string updatedEmail = txtEmail.Text;

            string myConnString = "server=127.0.0.1;user=root;password=hazel;database=medical_record;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(myConnString))
                {
                    conn.Open();
                    // SQL query to update the data
                    string query = "UPDATE users SET Name = @Name, Username = @Username, Email = @Email WHERE UserID = @UserID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to the command
                        cmd.Parameters.AddWithValue("@UserID", updateID);
                        cmd.Parameters.AddWithValue("@Name", updatedName);
                        cmd.Parameters.AddWithValue("@Username", updatedUsername);
                        cmd.Parameters.AddWithValue("@Email", updatedEmail);

                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Patient information updated successfully.");
                            var form = new Patient();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update patient information.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
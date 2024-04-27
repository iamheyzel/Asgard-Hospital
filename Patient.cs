using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Asgard_Hospital
{
    public partial class Patient : Form
    {
        private MySqlConnection conn;
        private MySqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private string myConnString = "server=127.0.0.1;user=root;password=hazel;database=medical_record;";
        private int selectedPatientID = -1;

        public Patient()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if any row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected patient's ID (assuming it's stored in the first column)
                int patientID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PatientID"].Value);

                // Store the selected patient's ID in a variable accessible to the "Update" button click event handler
                selectedPatientID = patientID;
            }
        }


        private void Patient_Load(object sender, EventArgs e)
        {
            string myConnString = "server=127.0.0.1;user=root;password=hazel;database=medical_record;";
            conn = new MySqlConnection(myConnString);

            // Initialize data adapter and DataTable
            dataAdapter = new MySqlDataAdapter("SELECT * FROM users", conn);
            dataTable = new DataTable();

            // Fill the DataTable with data from the database
            dataAdapter.Fill(dataTable);

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private void UpdateUserInformation(int userID, string name, string username, string email, string password, string status)
        {
            using (MySqlConnection connection = new MySqlConnection(myConnString))
            {
                string updateQuery = "UPDATE Users SET Name = @Name, Username = @Username, Email = @Email, Password = @Password, Status = @Status WHERE UserID = @UserID";
                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Status", status);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // PatientForm.cs

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string UserID = row.Cells["UserID"].Value.ToString();
                string Name = row.Cells["Name"].Value.ToString();
                string Username = row.Cells["Username"].Value.ToString();
                string Email = row.Cells["Email"].Value.ToString();

                Update updateForm = new Update(UserID, Name, Username, Email);
                updateForm.ShowDialog();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Retrieve the search text from the textbox
            string searchText = textBox1.Text.Trim();

            // Call the LoadUsers method to fetch and display the search results
            LoadUsers(searchText);
        }
        // Method to load users based on the provided search text
        private void LoadUsers(string searchText)
        {
            try
            {
                // Open the database connection
                conn.Open();

                // Query to fetch data from the users table
                string query = "SELECT * FROM users";

                // If search text is provided, add a WHERE clause to filter the results
                if (!string.IsNullOrEmpty(searchText))
                {
                    query += " WHERE username LIKE @searchText OR email LIKE @searchText";
                }

                // Create a MySqlCommand object
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // If search text is provided, set the parameter value
                if (!string.IsNullOrEmpty(searchText))
                {
                    cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                }

                // Create a DataTable to hold the data
                DataTable dataTable = new DataTable();

                // Load data from the query into the DataTable
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }

                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public void SetData(List<string> rowData)
        {
            for (int i = 0; i < rowData.Count; i++)
            {
                // Assuming you have TextBoxes named textBox1, textBox2, etc.
                TextBox textBox = this.Controls.Find("textBox" + (i + 1), true).FirstOrDefault() as TextBox;
                if (textBox != null)
                {
                    textBox.Text = rowData[i];
                }
            }
        }


        // Method to initialize the form and load users initially
        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            // Initialize MySqlConnection
            conn = new MySqlConnection(myConnString);

            // Load all users initially
            LoadUsers("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string UserID = selectedRow.Cells["UserID"].Value.ToString();
                string Name = selectedRow.Cells["Name"].Value.ToString();
                string Username = selectedRow.Cells["Username"].Value.ToString();
                string Email = selectedRow.Cells["Email"].Value.ToString();

                Update updateForm = new Update(UserID, Name, Username, Email);
                updateForm.Show();
       
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close the current form
                this.Hide(); // Hide the current form

                // Show the new form
                loginform newForm = new loginform();
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Logout canceled.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.Show();
            this.Hide();
        }
    }
}

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
using MySql.Data.MySqlClient;

namespace Asgard_Hospital
{
    public partial class Appointment : Form
    {
        private const string ConnectionString = "server=127.0.0.1;port=3306;user=root;password=hazel;database=medical_record;";

        public Appointment()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Treatment treatment = new Treatment();
            treatment.Show();
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

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out and Don't save changes?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close the current form
                this.Hide(); // Hide the current form

                // Show the new form
                loginform newForm = new loginform();
                newForm.Show();
                this.Hide();
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

        private void label3_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            this.Hide();
        }

        private void txtboxDoctorID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxPatientID_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtboxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxAppointmentID.Text) ||
        string.IsNullOrEmpty(txtboxPatientID.Text) ||
        string.IsNullOrEmpty(txtboxDoctorID.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtboxAppointmentID.Text, out int appointmentID) ||
                !int.TryParse(txtboxPatientID.Text, out int patientID) ||
                !int.TryParse(txtboxDoctorID.Text, out int doctorID))
            {
                MessageBox.Show("Please enter valid integer values for Appointment ID, Patient ID, and Doctor ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime appointmentDateTime = dateTimePicker.Value;
            string result = txtboxResult.Text;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Prepare SQL statement
                    string sql = "INSERT INTO Appointments (AppointmentID, PatientID, DoctorID, AppointmentDate, Result) " +
                                 "VALUES (@AppointmentID, @PatientID, @DoctorID, @AppointmentDate, @Result)";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                        command.Parameters.AddWithValue("@PatientID", patientID);
                        command.Parameters.AddWithValue("@DoctorID", doctorID);
                        command.Parameters.AddWithValue("@AppointmentDate", appointmentDateTime);
                        command.Parameters.AddWithValue("@Result", result);

                        // Execute the command
                        command.ExecuteNonQuery();

                        MessageBox.Show("Appointment created successfully.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error creating appointment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

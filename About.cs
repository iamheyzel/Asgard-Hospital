using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//activity
namespace Asgard_Hospital
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
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

        private void label6_Click(object sender, EventArgs e)
        {
            Treatment treatment = new Treatment();
            treatment.Show();
            this.Hide();
        }

        private void txtbackAbout_Click(object sender, EventArgs e)
        {
           
        }
    }
}

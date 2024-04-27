using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Asgard_Hospital
{
    public partial class Report : Form
    {
       
        public Report()
        {
            InitializeComponent();
            comboBoxReportType.SelectedIndexChanged += comboBoxReportType_SelectedIndexChanged;
            btnExport.Click += btnExport_Click;
            // Set the LicenseContext to suppress the license exception
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        private void comboBoxReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedReportType = comboBoxReportType.SelectedItem.ToString();

            switch (selectedReportType)
            {
                case "Patients":
                    DisplayPatientsData();
                    break;
                case "Appointments":
                    DisplayAppointmentsData();
                    break;
                case "Billing":
                    DisplayBillingData();
                    break;
                default:
                    MessageBox.Show("Invalid report type selected.");
                    break;
            }
        }

        private void DisplayPatientsData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;user=root;password=hazel;database=medical_record;"))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM patients", conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        reportList.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying Patients data: " + ex.Message);
            }
        }

        private void DisplayAppointmentsData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;user=root;password=hazel;database=medical_record;"))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM appointments", conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        reportList.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching Appointment data: " + ex.Message);
            }
        }

        private void DisplayBillingData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;user=root;password=hazel;database=medical_record;"))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM billing", conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        reportList.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching Billing data: " + ex.Message);
            }
        }

        private void txtbackreports_Click(object sender, EventArgs e)
        {
            About about = new About();  
            about.Show();
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

        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (.xlsx)|.xlsx|All files (.)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        // Sheet 1: Data
                        ExcelWorksheet ws1 = excelPackage.Workbook.Worksheets.Add("Sheet1");

                        // Save the logo image to a temporary file with a valid image extension
                        string tempLogoPath = System.IO.Path.GetTempFileName();
                        tempLogoPath = System.IO.Path.ChangeExtension(tempLogoPath, ".png");
                        logo.Image.Save(tempLogoPath, System.Drawing.Imaging.ImageFormat.Png);

                        // Add the logo image to cell A3 with size 50px
                        ExcelPicture logoPicture = ws1.Drawings.AddPicture("Logo", new System.IO.FileInfo(tempLogoPath));
                        logoPicture.SetPosition(1, 0, 0, 0); // Position at cell A4 with size 50px
                        logoPicture.SetSize(70, 70);

                        // Get the brand names from Labels
                        string brandName1 = systemName.Text;
                        string brandName2 = systemName2.Text;

                        // Concatenate the brand names into a single string
                        string combinedBrandName = brandName1 + " " + brandName2;

                        // Insert the combined brand name into cell B3 and set font
                        ws1.Cells["B3"].Value = combinedBrandName;
                        ws1.Cells["B3"].Style.Font.Name = "Palatino Linotype";
                        ws1.Cells["B3"].Style.Font.Size = 20.8f;
                        ws1.Cells["B3"].Style.Font.Bold = true;

                        // Export DataGridView data to Excel starting from cell A7
                        ws1.Cells["A7"].LoadFromDataTable((DataTable)reportList.DataSource, true);

                        // Calculate the position of the last row
                        int lastRow = ws1.Dimension.End.Row;

                        // Add signature placeholder and line below the last row
                        ws1.Cells[lastRow + 2, 1].Value = "Signature:";
                        ws1.Cells[lastRow + 2, 1].Style.Font.Bold = true;
                        ws1.Cells[lastRow + 2, 2].Value = "______________________";
                        ws1.Cells[lastRow + 2, 2].Style.Font.Bold = true;

                        // Sheet 2: Graph
                        ExcelWorksheet ws2 = excelPackage.Workbook.Worksheets.Add("Sheet2");

                        if (comboBoxReportType.SelectedItem.ToString() == "Appointments")
                        {
                            DataTable appointmentsData = GetAppointmentsData();
                            ws2.Cells["A1"].LoadFromDataTable(appointmentsData, true);
                            if (appointmentsData.Rows.Count > 0)
                            {
                                CreateBarChart(ws2, "Appointments by Doctor", "A", "B", appointmentsData.Rows.Count);
                            }
                        }
                        else if (comboBoxReportType.SelectedItem.ToString() == "Patients")
                        {
                            DataTable patientsData = GetPatientsData();
                            ws2.Cells["A1"].LoadFromDataTable(patientsData, true);
                            if (patientsData.Rows.Count > 0)
                            {
                                CreateBarChart(ws2, "Patients Handled by Doctor", "A", "B", patientsData.Rows.Count);
                            }
                        }
                        else if (comboBoxReportType.SelectedItem.ToString() == "Billing")
                        {
                            DataTable billingData = GetBillingData();
                            ws2.Cells["A1"].LoadFromDataTable(billingData, true);
                            if (billingData.Rows.Count > 0)
                            {
                                CreateBarChart(ws2, "Billing Status", "A", "B", billingData.Rows.Count);
                            }
                        }

                        // Save Excel file
                        excelPackage.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                        MessageBox.Show("Data exported successfully!");

                        // Dispose the SaveFileDialog
                        saveFileDialog.Dispose();

                        // Delete the temporary logo file
                        System.IO.File.Delete(tempLogoPath);
                    }
                }
            }
            catch (LicenseException)
            {
                MessageBox.Show("EPPlus license is invalid. Please make sure you are using a valid license.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message);
            }
        }
        private void CreateBarChart(ExcelWorksheet ws, string title, string columnLabel, string dataColumn, int rowCount)
        {
            var chart = ws.Drawings.AddChart(title, OfficeOpenXml.Drawing.Chart.eChartType.BarClustered);
            chart.SetPosition(1, 0, 3, 0);
            chart.SetSize(600, 400);

            var dataRange = ws.Cells[$"{columnLabel}1:{columnLabel}{rowCount}"];
            var series = chart.Series.Add(dataRange.Offset(0, 1), dataRange.Offset(0, 0));
            series.HeaderAddress = ws.Cells[$"{columnLabel}1"];
            chart.Title.Text = title;
            chart.XAxis.Title.Text = "Doctor";
            chart.YAxis.Title.Text = "Patients";
        }

        private DataTable GetAppointmentsData()
        {
            DataTable dt = new DataTable();
            string connectionString = "server=127.0.0.1;user=root;password=hazel;database=medical_record;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT DoctorID, COUNT(*) as Appointments FROM appointments GROUP BY DoctorID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        private DataTable GetPatientsData()
        {
            DataTable dt = new DataTable();
            string connectionString = "server=127.0.0.1;user=root;password=hazel;database=medical_record;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT DoctorID, COUNT(DISTINCT PatientID) as Patients FROM appointments GROUP BY DoctorID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        private DataTable GetBillingData()
        {
            DataTable dt = new DataTable();
            string connectionString = "server=127.0.0.1;user=root;password=hazel;database=medical_record;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT PaymentStatus as Status, COUNT(*) as Count FROM billing GROUP BY PaymentStatus";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Treatment treatment = new Treatment();
            treatment.Show();
            this.Hide();
        }
    }
}

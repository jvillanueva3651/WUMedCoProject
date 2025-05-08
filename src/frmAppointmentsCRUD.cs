using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WUMedCoProject.src;

namespace WUMedCoProject
{
    public partial class frmAppointmentsCRUD : Form
    {
        public frmAppointmentsCRUD()
        {
            InitializeComponent();
            LoadAppointments();
        }

        /**********************************************************************
         * Method to load appointments into the DataGridView
         *********************************************************************/
        private void LoadAppointments()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"
                    SELECT 
                        a.AppointmentID, 
                        a.DateTime,
                        a.Purpose,
                        CONCAT(p.LastName, ', ', p.FirstName) AS PatientName,
                        CONCAT(e.LastName, ', ', e.FirstName) AS Physician,
                        r.RoomType
                    FROM Appointment a
                    LEFT JOIN Patient p ON a.PatientID = p.PatientID
                    LEFT JOIN Employee e ON a.PhysicianID = e.EmployeeID
                    LEFT JOIN Room r ON a.RoomID = r.RoomID";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dgvAppointments.DataSource = dt;
            }
        }

        /**********************************************************************
         * Method to handle the click event of the "Schedule an Appointment" Button
         *********************************************************************/
        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            frmAppointment appointmentForm = new frmAppointment(frmAppointment.FormMode.Add);
            appointmentForm.Show();
        }

        /**********************************************************************
         * Method to handle the click event of the "Return to Home" Button
         *********************************************************************/
        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**********************************************************************
         * Method to handle the edit, view, delete buttons in the DataGridView
         *********************************************************************/
        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var dataTable = (DataTable)dgvAppointments.DataSource;

            var appointmentId = Convert.ToInt32(dataTable.Rows[e.RowIndex]["AppointmentID"]);

            //For Debugging
            //MessageBox.Show($"BuildingID: {buildingId}");

            if (dgvAppointments.Columns[e.ColumnIndex] == BtnView)
            {
                OpenAppointmentForm(frmAppointment.FormMode.View, appointmentId);
            }
            else if (dgvAppointments.Columns[e.ColumnIndex] == BtnEdit)
            {
                OpenAppointmentForm(frmAppointment.FormMode.Edit, appointmentId);
            }
            else if (dgvAppointments.Columns[e.ColumnIndex] == BtnDelete)
            {
                DeleteAppointment(appointmentId);
            }
        }

        /**********************************************************************
         * Method to open the appointment form
         *********************************************************************/
        private void OpenAppointmentForm(frmAppointment.FormMode mode, int appointmentId)
        {
            using (var appointmentForm = new frmAppointment(mode, appointmentId))
            {
                if (appointmentForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAppointments(); //Refreshes the DGV
                }
            }
        }

        /**********************************************************************
         * Method to delete an appointment
         *********************************************************************/
        private void DeleteAppointment(int appointmentId)
        {

        }
    }
}

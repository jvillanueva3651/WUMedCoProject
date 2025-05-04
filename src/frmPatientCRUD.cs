using Microsoft.Data.SqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WUMedCoProject.src
{
    public partial class frmPatientCRUD : Form
    {
        public frmPatientCRUD()
        {
            InitializeComponent();
            LoadPatients();
        }

        /**********************************************************************
         * Method to handle the click event of the "Add a Patient" button. 
         *********************************************************************/
        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            frmPatient Patients = new frmPatient(frmPatient.FormMode.Add);
            Patients.Show();
        }

        /**********************************************************************
         * Method to load patients into the DataGridView
         *********************************************************************/
        private void LoadPatients()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT PatientID, LastName + ', ' + FirstName AS FullName, CONVERT(varchar, DateOfBirth, 101) AS DoB, Sex, '***-**-' + RIGHT(SSN, 4) AS SSN, PhoneNumber, Email
                            FROM Patient";

                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);

                dgvPatients.DataSource = dt;
                dgvPatients.Columns["PatientID"].Visible = false; //Hidden ID
            }
        }

        /**********************************************************************
         * Method to handle the edit, view, delete buttons in the DataGridView
         *********************************************************************/
        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var dataTable = (DataTable)dgvPatients.DataSource;

            var patientId = Convert.ToInt32(dataTable.Rows[e.RowIndex]["PatientID"]);

            //For Debugging
            //MessageBox.Show($"PatientID: {patientId}");

            if (dgvPatients.Columns[e.ColumnIndex] == dgvBtnView)
            {
                OpenPatientForm(frmPatient.FormMode.View, patientId);
            }
            else if (dgvPatients.Columns[e.ColumnIndex] == dgvBtnEdit)
            {
                OpenPatientForm(frmPatient.FormMode.Edit, patientId);
            }
            else if (dgvPatients.Columns[e.ColumnIndex] == dgvBtnDelete)
            {
                DeletePatient(patientId);
            }
        }

        /**********************************************************************
         * Method to open the patient form
         *********************************************************************/
        private void OpenPatientForm(frmPatient.FormMode mode, int? patientId = null)
        {
            using (var patientForm = new frmPatient(mode, patientId))
            {
                if(patientForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPatients(); //Refreshes the DGV
                }
            }
        }

        /**********************************************************************
         * Method to delete a patient(Deletes JUST the patient table record)
         *********************************************************************/
        private void DeletePatient(int patientId)
        {
            //TODO: Implement delete logic
        }
    }
}

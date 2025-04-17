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
    public partial class frmAdminHome : Form
    {
        public frmAdminHome()
        {
            InitializeComponent();
        }

        /***********************************************************************
         * Method to handle the click event of the Patients button.
         **********************************************************************/
        private void btnPatients_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmPatientCRUD patientsCRUD = new frmPatientCRUD();
            patientsCRUD.FormClosed += (s, args) => this.Show();
            patientsCRUD.Show();
        }

        /***********************************************************************
         * Method to handle the click event of the Appointments button.
         **********************************************************************/
        private void btnAppointments_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmAppointmentsCRUD appointmentsCRUD = new frmAppointmentsCRUD();
            appointmentsCRUD.FormClosed += (s, args) => this.Show();
            appointmentsCRUD.Show();
        }

        /***********************************************************************
         * Method to handle the click event of the Medical Records button.
         **********************************************************************/
        private void btnMedRecords_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmMedicalRecordsCRUD medicalRecordsCRUD = new frmMedicalRecordsCRUD();
            medicalRecordsCRUD.FormClosed += (s, args) => this.Show();
            medicalRecordsCRUD.Show();
        }

        /***********************************************************************
         * Method to handle the click event of the Employees button.
         **********************************************************************/
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmEmployeeCRUD employeesCRUD = new frmEmployeeCRUD();
            employeesCRUD.FormClosed += (s, args) => this.Show();
            employeesCRUD.Show();
        }

        /***********************************************************************
         * Method to handle the click event of the Buildings button.
         **********************************************************************/
        private void btnBuildings_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmBuildingsCRUD buildingsCRUD = new frmBuildingsCRUD();
            buildingsCRUD.FormClosed += (s, args) => this.Show();
            buildingsCRUD.Show();
        }

        /***********************************************************************
         * Method to handle the click event of the Departments button.
         **********************************************************************/
        private void btnDepartments_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmDepartmentsCRUD departmentsCRUD = new frmDepartmentsCRUD();
            departmentsCRUD.FormClosed += (s, args) => this.Show();
            departmentsCRUD.Show();
        }

        /***********************************************************************
         * Method to handle the click event of the Equipment button.
         **********************************************************************/
        private void btnEquipment_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmEquipmentCRUD equipmentCRUD = new frmEquipmentCRUD();
            equipmentCRUD.FormClosed += (s, args) => this.Show();
            equipmentCRUD.Show();
        }
    }
}

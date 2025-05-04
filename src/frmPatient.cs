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
    public partial class frmPatient : Form
    {
        public enum FormMode { View, Edit, Add }
        private readonly int? _patientId;
        private readonly FormMode _mode;

        public frmPatient(FormMode mode, int? patientId = null)
        {
            InitializeComponent();
            _mode = mode;
            _patientId = patientId;

            InitializeFormBasedOnMode();
            LoadPatientData();
        }

        /**********************************************************************
         * Method to initialize the form based on the mode (View, Edit, Add). 
         *********************************************************************/
        private void InitializeFormBasedOnMode()
        {
            switch (_mode)
            {
                case FormMode.View:
                    SetControlsReadOnly(true);
                    btnSave.Visible = false;
                    break;
                case FormMode.Edit:
                    SetControlsReadOnly(false);
                    break;
                case FormMode.Add:
                    SetControlsReadOnly(false);
                    break;
            }
        }

        /**********************************************************************
         * Method to set controls to read only based on boolean parameter. 
         *********************************************************************/
        private void SetControlsReadOnly(bool readOnly)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt) txt.ReadOnly = readOnly;
                if (ctrl is ComboBox cmb) cmb.Enabled = !readOnly;
                if (ctrl is DateTimePicker dtp) dtp.Enabled = !readOnly;
            }
        }

        /**********************************************************************
         * Method to load patient data
         *********************************************************************/
        private void LoadPatientData()
        {
            if (_mode == FormMode.Add) return;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT p.*, a.*, ec.*, i.*
                                FROM Patient p
                                JOIN Address a ON p.AddressID = a.AddressID
                                JOIN EmergencyContact ec ON p.EmergencyContactID = ec.EmergencyContactID
                                LEFT JOIN Insurance i ON p.InsuranceID = i.InsuranceID
                                WHERE p.PatientID = @PatientID";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", _patientId);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Patient Details
                            txtFirstname.Text = reader["FirstName"].ToString();
                            txtLastname.Text = reader["LastName"].ToString();
                            txtSex.Text = reader["Sex"].ToString();
                            //TODO Date of Birth DateTimePicker
                            txtSSN.Text = reader["SSN"].ToString();
                            txtPhone.Text = reader["PhoneNumber"].ToString();
                            txtEmail.Text = reader["Email"].ToString();

                            //Address Details
                            txtStreet.Text = reader["StreetAddress"].ToString();
                            txtApt.Text = reader["ApartmentSuiteNum"].ToString();
                            txtCity.Text = reader["City"].ToString();
                            //TODO State ComboBox
                            txtZip.Text = reader["ZipCode"].ToString();

                            //Emergency Contact Details
                            txtECFirstname.Text = reader["FirstName"].ToString();
                            txtECLastname.Text = reader["LastName"].ToString();
                            txtECPhoneNum.Text = reader["PhoneNumber"].ToString();

                            //Insurance Details
                            txtInsuranceID.Text = reader["InsuranceID"].ToString();
                            txtInsuranceProvider.Text = reader["ProviderName"].ToString();
                            txtInsuranceType.Text = reader["TypeName"].ToString();
                            //TODO Insurance Effective Date DateTimePicker
                            //TODO Insurance Termination Date DateTimePicker
                            txtCost.Text = reader["Cost"].ToString();
                            txtCopay.Text = reader["Copay"].ToString();
                            txtCoverageDetails.Text = reader["CoverageDetails"].ToString();
                        }
                    }
                }
            }
        }

        /**********************************************************************
         * Method to save patient data on button click
         *********************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateInput() == "")
            {
                try
                {
                    if(_mode == FormMode.Add)
                    {
                        CreateNewPatient();
                    }
                    else
                    {
                        UpdateExistingPatient();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch(SqlException ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error");
                }
            }
        }

        /**********************************************************************
         * Method to exit form on button click
         *********************************************************************/
        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        /**********************************************************************
         * Method to cancel form on button click
         *********************************************************************/
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        /**********************************************************************
         * Method to create a new patient
         *********************************************************************/
        private void CreateNewPatient()
        {
            //TODO: Implement insert logic for Patient + other related tables
        }

        /**********************************************************************
         * Method to update an existing patient
         *********************************************************************/
        private void UpdateExistingPatient()
        {
            //TODO: Implement update logic for Patient + other related tables
        }

        /**********************************************************************
         * Method to validate input of all fields before saving
         *********************************************************************/
        private string ValidateInput()
        {
            //TODO: Implement validation logic for all controls
            return "";
        }
    }
}

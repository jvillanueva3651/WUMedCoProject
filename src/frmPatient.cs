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
            PopulateStateComboBox();

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
         * Methods to set controls to read only based on boolean parameter. 
         *********************************************************************/
        private void SetControlsReadOnly(bool readOnly)
        {
            SetControlsReadOnlyRecursive(this, readOnly);
        }
        private void SetControlsReadOnlyRecursive(Control parentControl, bool readOnly)
        {
            foreach (Control ctrl in parentControl.Controls)
            {
                // Handle TextBoxes
                if (ctrl is TextBox txt)
                {
                    txt.ReadOnly = readOnly;
                }
                // Handle ComboBoxes
                else if (ctrl is ComboBox cmb)
                {
                    cmb.Enabled = !readOnly;
                }
                // Handle DateTimePickers
                else if (ctrl is DateTimePicker dtp)
                {
                    dtp.Enabled = !readOnly;
                }
                // Handle CheckBoxes
                else if (ctrl is CheckBox chk)
                {
                    chk.Enabled = !readOnly;
                }

                // Recurse into child controls
                if (ctrl.HasChildren)
                {
                    SetControlsReadOnlyRecursive(ctrl, readOnly);
                }
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
                try
                {
                    var query = @"SELECT 
                                    p.PatientID, p.FirstName, p.LastName, p.DateOfBirth, p.Sex, p.SSN, 
                                    p.PhoneNumber, p.Email,
                                    a.StreetAddress, a.ApartmentSuiteNum, a.City, a.State, a.ZipCode,
                                    ec.FirstName AS ECFirstName, ec.LastName AS ECLastName, ec.PhoneNumber AS ECPhone,
                                    i.InsuranceID, i.ProviderName, i.EffectiveDate, i.TerminationDate,
                                    pt.TypeName, pt.Cost, pt.Copay, pt.CoverageDetails
                                FROM Patient p
                                JOIN Address a ON p.AddressID = a.AddressID
                                JOIN EmergencyContact ec ON p.EmergencyContactID = ec.EmergencyContactID
                                LEFT JOIN Insurance i ON p.InsuranceID = i.InsuranceID
                                LEFT JOIN PolicyType pt ON i.PolicyTypeID = pt.PolicyTypeID
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
                                dtpDateOfBirth.Value = reader.GetDateTime(reader.GetOrdinal("DateOfBirth"));
                                txtSSN.Text = reader["SSN"].ToString();
                                txtPhone.Text = reader["PhoneNumber"].ToString();
                                txtEmail.Text = reader["Email"].ToString();

                                //Address Details
                                txtStreet.Text = reader["StreetAddress"].ToString();
                                txtApt.Text = reader["ApartmentSuiteNum"].ToString();
                                txtCity.Text = reader["City"].ToString();
                                cboxState.SelectedValue = reader["State"].ToString();
                                txtZip.Text = reader["ZipCode"].ToString();

                                //Emergency Contact Details
                                txtECFirstname.Text = reader["ECFirstName"].ToString();
                                txtECLastname.Text = reader["ECLastName"].ToString();
                                txtECPhoneNum.Text = reader["ECPhone"].ToString();

                                //Insurance Details
                                if (reader["InsuranceID"] is DBNull)
                                {
                                    chkbxNoInsurance.Checked = true;
                                    chkbxNoInsurance_CheckedChanged(null, null);
                                }
                                else
                                {
                                    txtInsuranceID.Text = reader["InsuranceID"] is DBNull ? "" : reader["InsuranceID"].ToString();
                                    txtInsuranceProvider.Text = reader["ProviderName"].ToString();
                                    txtInsuranceType.Text = reader["TypeName"].ToString();
                                    if (reader["EffectiveDate"] != DBNull.Value)
                                        dtpEffectiveDate.Value = reader.GetDateTime(reader.GetOrdinal("EffectiveDate"));
                                    else
                                        dtpEffectiveDate.Value = DateTime.Today;
                                    if (reader["TerminationDate"] != DBNull.Value)
                                        dtpTerminationDate.Value = reader.GetDateTime(reader.GetOrdinal("TerminationDate"));
                                    else
                                        dtpTerminationDate.Value = DateTime.Today;
                                    txtCost.Text = reader["Cost"].ToString();
                                    txtCopay.Text = reader["Copay"].ToString();
                                    txtCoverageDetails.Text = reader["CoverageDetails"].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No data found for the patient: " + _patientId, "Error");
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /**********************************************************************
         * Method to save patient data on button click
         *********************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == "")
            {
                try
                {
                    if (_mode == FormMode.Add)
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
                catch (SqlException ex)
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

        /**********************************************************************
         * Method to populate the state combo box
         *********************************************************************/
        private void PopulateStateComboBox()
        {
            cboxState.Items.AddRange(new String[] { "AL", "AK", "AZ", "AR", "CA"
                , "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN"
                , "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS"
                , "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND"
                , "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT"
                , "VT", "VA", "WA", "WV", "WI", "WY" });
            cboxState.SelectedIndex = -1; // Set to no selection
        }

        /**********************************************************************
        * Method to handle the "No Insurance" checkbox
        *********************************************************************/
        private void chkbxNoInsurance_CheckedChanged(object sender, EventArgs e)
        {
            txtInsuranceID.Enabled = !chkbxNoInsurance.Checked;
            txtInsuranceProvider.Enabled = !chkbxNoInsurance.Checked;
            txtInsuranceType.Enabled = !chkbxNoInsurance.Checked;
            dtpEffectiveDate.Enabled = !chkbxNoInsurance.Checked;
            dtpTerminationDate.Enabled = !chkbxNoInsurance.Checked;
            txtCost.Enabled = !chkbxNoInsurance.Checked;
            txtCopay.Enabled = !chkbxNoInsurance.Checked;
            txtCoverageDetails.Enabled = !chkbxNoInsurance.Checked;
            chkbxNoTerminationDate.Enabled = !chkbxNoInsurance.Checked;
            if (chkbxNoInsurance.Checked)
            {
                txtInsuranceID.Text = "";
                txtInsuranceProvider.Text = "";
                txtInsuranceType.Text = "";
                dtpEffectiveDate.CustomFormat = " ";
                dtpTerminationDate.CustomFormat = " ";
                txtCost.Text = "";
                txtCopay.Text = "";
                txtCoverageDetails.Text = "";
            }
            else
            {
                dtpEffectiveDate.CustomFormat = "MM/dd/yyyy";
                dtpTerminationDate.CustomFormat = "MM/dd/yyyy";
            }
        }

        /**********************************************************************
        * Method to handle the "No Termination Date" checkbox
        *********************************************************************/
        private void chkbxNoTerminationDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpTerminationDate.Enabled = !chkbxNoTerminationDate.Checked;
            if (chkbxNoTerminationDate.Checked)
            {
                dtpTerminationDate.CustomFormat = " ";
            }
            else
            {
                dtpTerminationDate.CustomFormat = "MM/dd/yyyy";
            }
        }

        /**********************************************************************
        * Method to uncheck the "No Termination Date" checkbox when the date is changed
        *********************************************************************/
        private void dtpTerminationDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTerminationDate.Enabled)
            {
                chkbxNoTerminationDate.Checked = false;
            }
        }
    }
}

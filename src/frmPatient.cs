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
        private bool _hasUnsavedChanges = false;

        public frmPatient(FormMode mode, int? patientId = null)
        {
            InitializeComponent();
            _mode = mode;
            _patientId = patientId;
            PopulateStateComboBox();

            if (_mode == FormMode.Add)
                _hasUnsavedChanges = false;

            InitializeFormBasedOnMode();
            LoadPatientData();

            WireUpChangeEvents(this);
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

                                _hasUnsavedChanges = false; //Reset unsaved changes flag
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
                finally
                {
                    _hasUnsavedChanges = false;
                }
            }
        }

        /**********************************************************************
         * Method to exit form on button click
         *********************************************************************/
        private void btnExit_Click(object sender, EventArgs e) { this.Close(); }

        /**********************************************************************
         * Method to cancel form on button click
         *********************************************************************/
        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }

        /**********************************************************************
         * Method to check for unsaved changes before closing the form
         *********************************************************************/
        private void CheckForUnsavedChangesAndClose()
        {
            if (_hasUnsavedChanges)
            {
                var result = MessageBox.Show(
                    "You have unsaved changes. Are you sure you want to exit?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                    return; // Cancel closing
            }

            this.Close();
        }

        /**********************************************************************
         * Override method to check for unsaved changes before closing the form
         *********************************************************************/
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_hasUnsavedChanges && this.DialogResult != DialogResult.OK)
            {
                var result = MessageBox.Show(
                    "You have unsaved changes. Are you sure you want to exit?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                    e.Cancel = true; // Prevent closing
            }

            base.OnFormClosing(e);
        }

        /**********************************************************************
         * Method to create a new patient
         *********************************************************************/
        private void CreateNewPatient()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMEDCo"].ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    //Address
                    int addressId;
                    using(var cmd = new SqlCommand(
                        @"INSERT INTO Address (StreetAddress, ApartmentSuiteNum, City, State, ZipCode)
                          VALUES (@Street, @Apt, @City, @State, @Zip);
                          SELECT SCOPE_IDENTITY();", 
                          conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Street", txtStreet.Text);
                        cmd.Parameters.AddWithValue("@Apt", txtApt.Text);
                        cmd.Parameters.AddWithValue("@City", txtCity.Text);
                        cmd.Parameters.AddWithValue("@State", cboxState.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Zip", txtZip.Text);
                        addressId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    //Emergency Contact
                    int emergencyContactId;
                    using (var cmd = new SqlCommand(
                        @"INSERT INTO EmergencyContact (FirstName, LastName, PhoneNumber)
                          VALUES (@ECFirst, @ECLast, @ECPhone);
                          SELECT SCOPE_IDENTITY();", 
                          conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ECFirst", txtECFirstname.Text);
                        cmd.Parameters.AddWithValue("@ECLast", txtECLastname.Text);
                        cmd.Parameters.AddWithValue("@ECPhone", txtECPhoneNum.Text);
                        emergencyContactId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    //Insurance
                    int? insuranceId = null;
                    if (!chkbxNoInsurance.Checked)
                    {
                        // Insert PolicyType first
                        int policyTypeId;
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO PolicyType (TypeName, Cost, Copay, CoverageDetails)
                              VALUES (@Type, @Cost, @Copay, @Details);
                              SELECT SCOPE_IDENTITY();", 
                              conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Type", txtInsuranceType.Text);
                            cmd.Parameters.AddWithValue("@Cost", decimal.Parse(txtCost.Text));
                            cmd.Parameters.AddWithValue("@Copay", decimal.Parse(txtCopay.Text));
                            cmd.Parameters.AddWithValue("@Details", txtCoverageDetails.Text);
                            policyTypeId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Insert Insurance
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO Insurance (ProviderName, EffectiveDate, TerminationDate, PolicyTypeID)
                              VALUES (@Provider, @EffDate, @TermDate, @PolicyTypeID);
                              SELECT SCOPE_IDENTITY();", 
                              conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Provider", txtInsuranceProvider.Text);
                            cmd.Parameters.AddWithValue("@EffDate", dtpEffectiveDate.Value);
                            cmd.Parameters.AddWithValue("@TermDate", chkbxNoTerminationDate.Checked
                                ? (object)DBNull.Value
                                : dtpTerminationDate.Value);
                            cmd.Parameters.AddWithValue("@PolicyTypeID", policyTypeId);
                            insuranceId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }

                    //Patient
                    using (var cmd = new SqlCommand(
                        @"INSERT INTO Patient (FirstName, LastName, DateOfBirth, Sex, SSN, 
                                PhoneNumber, Email, AddressID, EmergencyContactID, InsuranceID)
                              VALUES (@First, @Last, @DOB, @Sex, @SSN, @Phone, @Email, 
                                @AddressID, @ECID, @InsuranceID)",
                          conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@First", txtFirstname.Text);
                        cmd.Parameters.AddWithValue("@Last", txtLastname.Text);
                        cmd.Parameters.AddWithValue("@DOB", dtpDateOfBirth.Value);
                        cmd.Parameters.AddWithValue("@Sex", txtSex.Text);
                        cmd.Parameters.AddWithValue("@SSN", txtSSN.Text); // Should be encrypted in real scenarios
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@AddressID", addressId);
                        cmd.Parameters.AddWithValue("@ECID", emergencyContactId);
                        cmd.Parameters.AddWithValue("@InsuranceID", insuranceId ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Patient created successfully!", "Success");
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error creating patient: {ex.Message}\nAll changes have been rolled back.", "Error");
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
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
        **********************************************************************/
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
        **********************************************************************/
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
        **********************************************************************/
        private void dtpTerminationDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTerminationDate.Enabled)
            {
                chkbxNoTerminationDate.Checked = false;
            }
        }

        /**********************************************************************
        * Method to wire up change events for controls
        **********************************************************************/
        private void WireUpChangeEvents(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).TextChanged += OnControlChanged;
                else if (ctrl is ComboBox)
                    ((ComboBox)ctrl).SelectedIndexChanged += OnControlChanged;
                else if (ctrl is DateTimePicker)
                    ((DateTimePicker)ctrl).ValueChanged += OnControlChanged;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).CheckedChanged += OnControlChanged;

                // Recurse into nested controls (e.g., GroupBoxes)
                if (ctrl.HasChildren)
                    WireUpChangeEvents(ctrl);
            }
        }

        /**********************************************************************
        * Method to set hasUnsavedChanges to true when any control changes
        **********************************************************************/
        private void OnControlChanged(object sender, EventArgs e)
        {
            _hasUnsavedChanges = true;
        }
    }
}

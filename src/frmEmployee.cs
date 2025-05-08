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
using System.Text.RegularExpressions;

namespace WUMedCoProject.src
{
    public partial class frmEmployee : Form
    {
        public enum FormMode { View, Edit, Add }
        private readonly int? _employeeId;
        private readonly FormMode _mode;
        private bool _hasUnsavedChanges = false;
        private int _addressId;
        private int _selectedDepartmentID = -1;
        private int _selectedBuildingID = -1;
        private bool _isLoading = false;

        public frmEmployee(FormMode mode, int? employeeId = null)
        {
            InitializeComponent();
            _mode = mode;
            _employeeId = employeeId;
            PopulateStateComboBox();
            FormatDepartmentDGV();
            FormatBuildingDGV();
            PopulateDepartmentDGV();
            PopulateBuildingDGV();

            InitializeFormBasedOnMode();
            txtEmployeeID.ReadOnly = true;

            this.Load += frmEmployee_Load;

            WireUpChangeEvents(this);
            dgvDepartment.DataBindingComplete += dgvDepartment_DataBindingComplete;
            dgvBuilding.DataBindingComplete += dgvBuilding_DataBindingComplete;
            _hasUnsavedChanges = false;
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            _isLoading = true; // Start loading
            LoadEmployeeData();
            _isLoading = false; // End loading
        }

        private void dgvDepartment_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_mode != FormMode.Add && _selectedDepartmentID != -1)
            {
                SelectDepartmentRow(_selectedDepartmentID);
            }
        }

        private void dgvBuilding_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_mode != FormMode.Add && _selectedBuildingID != -1)
            {
                SelectBuildingRow(_selectedBuildingID);
            }
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
         * Method to load employee data
         *********************************************************************/
        private void LoadEmployeeData()
        {
            if (_mode == FormMode.Add) return;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT e.*, a.StreetAddress, a.ApartmentSuiteNum, a.City, a.State, a.ZipCode 
                    FROM Employee e
                    INNER JOIN Address a ON e.AddressID = a.AddressID
                    WHERE e.EmployeeID = @EmployeeID";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", _employeeId);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Basic Employee Info
                            txtEmployeeID.Text = reader["EmployeeID"].ToString();
                            txtFirstname.Text = reader["FirstName"].ToString();
                            txtLastname.Text = reader["LastName"].ToString();
                            dtpDateOfBirth.Value = (DateTime)reader["DateOfBirth"];
                            txtSSN.Text = reader["SSN"].ToString();
                            txtPosition.Text = reader["Position"].ToString();
                            txtPayRate.Text = Convert.ToDecimal(reader["PayRate"]).ToString("C");
                            txtOfficeNumber.Text = reader["OfficeNumber"].ToString();
                            txtExt.Text = reader["Extension"].ToString();
                            dtpStartDate.Value = (DateTime)reader["StartDate"];

                            // Employment Status
                            if (reader["EndDate"] == DBNull.Value)
                            {
                                chkbxEmployed.Checked = true;
                                dtpEndDate.Enabled = false;
                            }
                            else
                            {
                                dtpEndDate.Value = (DateTime)reader["EndDate"];
                            }

                            // Address Information
                            txtStreet.Text = reader["StreetAddress"].ToString();
                            txtApt.Text = reader["ApartmentSuiteNum"].ToString();
                            txtCity.Text = reader["City"].ToString();
                            var stateValue = reader["State"].ToString();
                            cboxState.SelectedItem = stateValue;
                            txtZip.Text = reader["ZipCode"].ToString();

                            // Department/Building Selection
                            _selectedDepartmentID = (int)reader["DepartmentID"];
                            _selectedBuildingID = (int)reader["BuildingID"];

                            // For Debugging
                            //MessageBox.Show("DepartmentID: " + _selectedDepartmentID.ToString() + "\nBuildingID: " + _selectedBuildingID.ToString(), "Debug Info");

                            // Select rows in DataGridViews after data loads
                            SelectDepartmentRow(_selectedDepartmentID);
                            SelectBuildingRow(_selectedBuildingID);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error loading employee data: {ex.Message}", "Database Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /**********************************************************************
         * Method to select department in DGV
         *********************************************************************/
        private void SelectDepartmentRow(int departmentID)
        {
            foreach (DataGridViewRow row in dgvDepartment.Rows)
            {
                if (Convert.ToInt32(row.Cells["dgvDepartmentID"].Value) == departmentID)
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        /**********************************************************************
         * Method to select building in DGV
         *********************************************************************/
        private void SelectBuildingRow(int buildingID)
        {
            foreach (DataGridViewRow row in dgvBuilding.Rows)
            {
                if (Convert.ToInt32(row.Cells["dgvBuildingID"].Value) == buildingID)
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        /**********************************************************************
         * Method to get the selected department ID from the DataGridView
         *********************************************************************/
        private int GetSelectedDepartmentID()
        {
            if (dgvDepartment.SelectedRows.Count == 0)
                throw new Exception("Please select a department");

            return Convert.ToInt32(dgvDepartment.SelectedRows[0].Cells["DepartmentID"].Value);
        }

        /**********************************************************************
         * Method to get the selected building ID from the DataGridView
         *********************************************************************/
        private int GetSelectedBuildingID()
        {
            if (dgvBuilding.SelectedRows.Count == 0)
                throw new Exception("Please select a building");

            return Convert.ToInt32(dgvBuilding.SelectedRows[0].Cells["BuildingID"].Value);
        }

        /**********************************************************************
         * Method to create an address in the database
         *********************************************************************/
        private int CreateAddress(SqlConnection conn, SqlTransaction transaction)
        {
            var query = @"INSERT INTO Address (
                    StreetAddress, ApartmentSuiteNum, City, State, ZipCode
                  ) VALUES (
                    @Street, @Apt, @City, @State, @Zip
                  ); SELECT SCOPE_IDENTITY();";

            using (var cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Street", txtStreet.Text.Trim());
                cmd.Parameters.AddWithValue("@Apt", string.IsNullOrWhiteSpace(txtApt.Text) ? DBNull.Value : (object)txtApt.Text.Trim());
                cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                cmd.Parameters.AddWithValue("@State", cboxState.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Zip", txtZip.Text.Trim());

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /**********************************************************************
         * Method to update an address in the database
         *********************************************************************/
        private void UpdateAddress(SqlConnection conn, SqlTransaction transaction)
        {
            var query = @"UPDATE Address SET
                    StreetAddress = @Street,
                    ApartmentSuiteNum = @Apt,
                    City = @City,
                    State = @State,
                    ZipCode = @Zip
                  WHERE AddressID = @AddressID";

            using (var cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Street", txtStreet.Text.Trim());
                cmd.Parameters.AddWithValue("@Apt", string.IsNullOrWhiteSpace(txtApt.Text) ? DBNull.Value : (object)txtApt.Text.Trim());
                cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                cmd.Parameters.AddWithValue("@State", cboxState.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Zip", txtZip.Text.Trim());
                cmd.Parameters.AddWithValue("@AddressID", _addressId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                    throw new Exception("No address record was updated");
            }
        }

        /**********************************************************************
         * Method to exit form on button click
         *********************************************************************/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**********************************************************************
         * Method to save form data on button click
         *********************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            string validationMessage = ValidateInput();
            if (string.IsNullOrEmpty(validationMessage))
            {
                try
                {
                    if (_mode == FormMode.Add)
                    {
                        CreateNewEmployee();
                    }
                    else
                    {
                        UpdateExistingEmployee();
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
         * Method to populate the state combo box
         *********************************************************************/
        private void PopulateStateComboBox()
        {
            var states = new[] { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC",
                        "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY",
                        "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT",
                        "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH",
                        "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT",
                        "VT", "VA", "WA", "WV", "WI", "WY" };

            cboxState.Items.AddRange(states);
            cboxState.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboxState.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        /**********************************************************************
         * Method to populate Department DataGridView
         *********************************************************************/
        private void PopulateDepartmentDGV()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT DepartmentID, DepartmentName 
                    FROM Department 
                    ORDER BY DepartmentName";

                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();

                try
                {
                    adapter.Fill(dt);
                    dgvDepartment.DataSource = dt;
                    dgvDepartment.Update();
                    //FormatDepartmentDGV();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error loading departments: {ex.Message}", "Database Error");
                }
            }
        }

        /**********************************************************************
         * Method to populate Building DataGridView
         *********************************************************************/
        private void PopulateBuildingDGV()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT BuildingID, Name 
                    FROM Building 
                    ORDER BY Name";

                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();

                try
                {
                    adapter.Fill(dt);
                    dgvBuilding.DataSource = dt;
                    dgvBuilding.Update();
                    //FormatBuildingDGV();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error loading buildings: {ex.Message}", "Database Error");
                }
            }
        }

        /**********************************************************************
         * Method to format the Department DataGridView
         *********************************************************************/
        private void FormatDepartmentDGV()
        {
            dgvDepartment.AutoGenerateColumns = false;
            dgvDepartment.Columns.Clear();

            // ID Column
            dgvDepartment.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "dgvDepartmentID", // Actual column name
                DataPropertyName = "DepartmentID", // Maps to SQL column
                HeaderText = "ID",
                Visible = false
            });

            // Name Column
            dgvDepartment.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "dgvDepartmentName", // Actual column name
                DataPropertyName = "DepartmentName", // Maps to SQL column
                HeaderText = "Department",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        /**********************************************************************
         * Method to format the Building DataGridView
         *********************************************************************/
        private void FormatBuildingDGV()
        {
            dgvBuilding.AutoGenerateColumns = false;
            dgvBuilding.Columns.Clear();

            // ID Column
            dgvBuilding.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "dgvBuildingID", // Actual column name
                DataPropertyName = "BuildingID", // Maps to SQL column
                HeaderText = "ID",
                Visible = false
            });

            // Name Column
            dgvBuilding.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "dgvBuildingName", // Actual column name
                DataPropertyName = "Name", // Maps to SQL column
                HeaderText = "Building",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        /**********************************************************************
         * Method to create a new employee
         *********************************************************************/
        private void CreateNewEmployee()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // First create the address
                    var addressId = CreateAddress(conn, transaction);

                    // Get selected department and building
                    var departmentId = GetSelectedDepartmentID();
                    var buildingId = GetSelectedBuildingID();

                    // Create employee command
                    var query = @"INSERT INTO Employee (
                            FirstName, LastName, DateOfBirth, SSN, Position, 
                            PayRate, StartDate, EndDate, OfficeNumber, Extension, 
                            AddressID, DepartmentID, BuildingID
                          ) VALUES (
                            @FirstName, @LastName, @DateOfBirth, @SSN, @Position, 
                            @PayRate, @StartDate, @EndDate, @OfficeNumber, @Extension, 
                            @AddressID, @DepartmentID, @BuildingID
                          )";

                    using (var cmd = new SqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", txtLastname.Text.Trim());
                        cmd.Parameters.AddWithValue("@DateOfBirth", dtpDateOfBirth.Value);
                        cmd.Parameters.AddWithValue("@SSN", txtSSN.Text.Replace("-", ""));
                        cmd.Parameters.AddWithValue("@Position", txtPosition.Text.Trim());
                        cmd.Parameters.AddWithValue("@PayRate", decimal.Parse(txtPayRate.Text.Trim('$', ' ')));
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", chkbxEmployed.Checked ? DBNull.Value : (object)dtpEndDate.Value);
                        cmd.Parameters.AddWithValue("@OfficeNumber", txtOfficeNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@Extension", txtExt.Text.Trim());
                        cmd.Parameters.AddWithValue("@AddressID", addressId);
                        cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                        cmd.Parameters.AddWithValue("@BuildingID", buildingId);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Employee created successfully!", "Success");
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error creating employee: {ex.Message}", "Database Error");
                }
                catch (FormatException)
                {
                    transaction.Rollback();
                    MessageBox.Show("Invalid format in numeric fields (Pay Rate)", "Input Error");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error: {ex.Message}", "Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /**********************************************************************
         * Method to update an existing employee
         *********************************************************************/
        private void UpdateExistingEmployee()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Update address first
                    UpdateAddress(conn, transaction);

                    // Update employee record
                    var query = @"UPDATE Employee SET
                            FirstName = @FirstName,
                            LastName = @LastName,
                            DateOfBirth = @DateOfBirth,
                            Position = @Position,
                            PayRate = @PayRate,
                            StartDate = @StartDate,
                            EndDate = @EndDate,
                            OfficeNumber = @OfficeNumber,
                            Extension = @Extension,
                            DepartmentID = @DepartmentID,
                            BuildingID = @BuildingID
                          WHERE EmployeeID = @EmployeeID";

                    using (var cmd = new SqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", txtLastname.Text.Trim());
                        cmd.Parameters.AddWithValue("@DateOfBirth", dtpDateOfBirth.Value);
                        cmd.Parameters.AddWithValue("@Position", txtPosition.Text.Trim());
                        cmd.Parameters.AddWithValue("@PayRate", decimal.Parse(txtPayRate.Text.Trim('$', ' ')));
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", chkbxEmployed.Checked ? DBNull.Value : (object)dtpEndDate.Value);
                        cmd.Parameters.AddWithValue("@OfficeNumber", txtOfficeNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@Extension", txtExt.Text.Trim());
                        cmd.Parameters.AddWithValue("@DepartmentID", GetSelectedDepartmentID());
                        cmd.Parameters.AddWithValue("@BuildingID", GetSelectedBuildingID());
                        cmd.Parameters.AddWithValue("@EmployeeID", _employeeId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            throw new Exception("No employee record was updated");
                    }

                    transaction.Commit();
                    MessageBox.Show("Employee updated successfully!", "Success");
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error updating employee: {ex.Message}", "Database Error");
                }
                catch (FormatException)
                {
                    transaction.Rollback();
                    MessageBox.Show("Invalid format in numeric fields (Pay Rate)", "Input Error");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error: {ex.Message}", "Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /**********************************************************************
         * Method to validate input of all fields before saving
         *********************************************************************/
        private string ValidateInput()
        {
            var msg = new StringBuilder();

            // Employee Basic Info Validation
            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
                msg.AppendLine("- First Name is required");
            if (string.IsNullOrWhiteSpace(txtLastname.Text))
                msg.AppendLine("- Last Name is required");
            if (string.IsNullOrWhiteSpace(txtSSN.Text) || !Regex.IsMatch(txtSSN.Text, @"^\d{3}-?\d{2}-?\d{4}$"))
                msg.AppendLine("- Valid SSN (9 digits) is required");
            if (string.IsNullOrWhiteSpace(txtPosition.Text))
                msg.AppendLine("- Position is required");
            if (string.IsNullOrWhiteSpace(txtOfficeNumber.Text))
                msg.AppendLine("- Office Number is required");
            if (string.IsNullOrWhiteSpace(txtExt.Text))
                msg.AppendLine("- Extension is required");

            // Pay Rate Validation
            if (!decimal.TryParse(txtPayRate.Text.Trim('$', ' '), out decimal payRate) || payRate <= 0)
                msg.AppendLine("- Valid Pay Rate is required");

            // Date Validation
            if (dtpStartDate.Value > DateTime.Today)
                msg.AppendLine("- Start Date cannot be in the future");

            if (!chkbxEmployed.Checked)
            {
                if (dtpEndDate.Value < dtpStartDate.Value)
                    msg.AppendLine("- End Date must be after Start Date");
            }

            // Address Validation
            if (string.IsNullOrWhiteSpace(txtStreet.Text))
                msg.AppendLine("- Street Address is required");
            if (string.IsNullOrWhiteSpace(txtCity.Text))
                msg.AppendLine("- City is required");
            if (cboxState.SelectedIndex == -1)
                msg.AppendLine("- State selection is required");
            if (!Regex.IsMatch(txtZip.Text, @"^\d{5}(-\d{4})?$"))
                msg.AppendLine("- Valid ZIP Code is required");

            // Department/Building Selection
            if (dgvDepartment.SelectedRows.Count == 0)
                msg.AppendLine("- Department selection is required");
            if (dgvBuilding.SelectedRows.Count == 0)
                msg.AppendLine("- Building selection is required");

            // SSN Format Cleanup Check
            var cleanSSN = new string(txtSSN.Text.Where(char.IsDigit).ToArray());
            if (cleanSSN.Length != 9)
                msg.AppendLine("- SSN must contain exactly 9 digits");

            // Employment Dates Logic
            if (chkbxEmployed.Checked && dtpEndDate.Enabled)
                msg.AppendLine("- Employment status conflict: End Date should be disabled when marked as employed");

            return msg.Length > 0
                ? "Please fix the following errors:\n\n" + msg.ToString()
                : "";
        }

        /**********************************************************************
        * Method to handle the "Currently Employed" checkbox
        **********************************************************************/
        private void chkbxEmployed_CheckedChanged(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = !chkbxEmployed.Checked;
            if (chkbxEmployed.Checked)
            {
                dtpEndDate.CustomFormat = " ";
                dtpEndDate.Enabled = false; // Disable the end date if currently employed
            }
            else
            {
                dtpEndDate.Enabled = true;
                dtpEndDate.CustomFormat = "MM/dd/yyyy";
            }
        }

        /**********************************************************************
        * Method to wire up change events for controls
        **********************************************************************/
        private void WireUpChangeEvents(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is DataGridView dgv)
                {
                    ((DataGridView)ctrl).SelectionChanged += OnControlChanged;
                    continue;
                }
                else if (ctrl is TextBox)
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
            if (!_isLoading)
            {
                _hasUnsavedChanges = true;
            }
        }

        /**********************************************************************
        * Method to help load filtered data into a DataGridView
        **********************************************************************/
        private void LoadFilteredData(string searchTerm, DataGridView dgv, string tableName, string columnName)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = $@"SELECT * 
                     FROM {tableName} 
                     WHERE {columnName} LIKE @SearchTerm
                     ORDER BY {columnName}";

                var adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                var dt = new DataTable();

                try
                {
                    adapter.Fill(dt);
                    dgv.DataSource = dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Database Error");
                }
            }
        }

        /**********************************************************************
        * Method to handle the search button for department
        **********************************************************************/
        private void btnDeptSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDeptSearch.Text))
            {
                LoadFilteredData(txtDeptSearch.Text, dgvDepartment, "Department", "DepartmentName");
            }
        }

        /**********************************************************************
        * Method to handle the clear button for the department search
        **********************************************************************/
        private void btnClearDeptSearch_Click(object sender, EventArgs e)
        {
            txtDeptSearch.Clear();
            LoadFilteredData("", dgvDepartment, "Department", "DepartmentName");
        }

        /**********************************************************************
        * Method to handle the search button for building
        **********************************************************************/
        private void btnBuildingSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuildingSearch.Text))
            {
                LoadFilteredData(txtBuildingSearch.Text, dgvBuilding, "Building", "Name");
            }
        }

        /**********************************************************************
        * Method to handle the clear button for the building search
        **********************************************************************/
        private void btnClearBuildingSearch_Click(object sender, EventArgs e)
        {
            txtBuildingSearch.Clear();
            LoadFilteredData("", dgvBuilding, "Building", "Name");
        }

        
    }
}
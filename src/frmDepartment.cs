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
using static WUMedCoProject.src.frmPatient;
using System.Xml.Linq;

namespace WUMedCoProject.src
{
    public partial class frmDepartment : Form
    {
        public enum FormMode { View, Edit, Add }
        private readonly FormMode _mode;
        private readonly int? _departmentId;
        private int _selectedEmployeeId = -1;
        private bool _hasUnsavedChanges = false;

        public frmDepartment(FormMode mode, int? departmentId = null)
        {
            InitializeComponent();
            _mode = mode;
            _departmentId = departmentId;
            PopulateEmployeesDataGridView();

            if (_mode == FormMode.Add)
                _hasUnsavedChanges = false;

            InitializeFormBasedOnMode();
            LoadDepartmentData(_departmentId);

            WireUpChangeEvents(this);

            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.MultiSelect = false;
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
         * Method to populate Employees DataGridView
         *********************************************************************/
        private void PopulateEmployeesDataGridView()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT EmployeeID, FirstName, LastName 
                      FROM Employee 
                      ORDER BY LastName, FirstName";

                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();

                try
                {
                    adapter.Fill(dt);
                    dgvEmployees.DataSource = dt;
                    dgvEmployees.ClearSelection();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error loading employees: {ex.Message}", "Database Error");
                }
            }
        }

        /**********************************************************************
         * Method to load department data for adding or editing
         *********************************************************************/
        private void LoadDepartmentData(int? departmentId)
        {
            if (_mode == FormMode.Add) return;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT d.*
                    FROM Department d
                    WHERE d.DepartmentID = @DepartmentID";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DepartmentID", _departmentId);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // For Debugging
                            //MessageBox.Show("Reader is indeed reading" + _departmentId);

                            // Populate Building fields
                            txtDepartmentName.Text = reader["DepartmentName"].ToString();

                            //TODO: Populate Employees DataGridView
                            if (reader["HeadOfDepartmentID"] != DBNull.Value)
                            {
                                _selectedEmployeeId = Convert.ToInt32(reader["HeadOfDepartmentID"]);
                                SelectHeadOfDepartmentRow(_selectedEmployeeId);
                            }

                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error loading department data: {ex.Message}", "Database Error");
                }
                finally
                {
                    conn.Close();
                    _hasUnsavedChanges = false;
                }
            }
        }

        /**********************************************************************
         * Method to handle exit button click
         *********************************************************************/
        private void btnExit_Click(object sender, EventArgs e)
        {
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
         * Method to handle save button click
         *********************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    if (_mode == FormMode.Add)
                    {
                        CreateNewDepartment();
                    }
                    else
                    {
                        UpdateExistingDepartment();
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
         * Method to create a new department
         *********************************************************************/
        private void CreateNewDepartment()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    //Get Head of Department if selected
                    int? headId = dgvEmployees.SelectedRows.Count > 0
                        ? Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value)
                        : (int?)null;

                    //Create department record
                    var query = @"INSERT INTO Department (
                            DepartmentName, HeadOfDepartmentID
                          ) VALUES (
                            @DepartmentName, @HeadOfDepartmentID
                          )";

                    using (var cmd = new SqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text.Trim());
                        cmd.Parameters.AddWithValue("@HeadOfDepartmentID", headId ?? (object)DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Department created successfully!", "Success");
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error creating department: {ex.Message}", "Database Error");
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
         * Method to update an existing department
         *********************************************************************/
        private void UpdateExistingDepartment()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    //Get Head of Department if selected
                    int? headId = dgvEmployees.SelectedRows.Count > 0
                        ? Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value)
                        : (int?)null;

                    //Update department record
                    var query = @"UPDATE Department 
                          SET DepartmentName = @DepartmentName, HeadOfDepartmentID = @HeadOfDepartmentID
                          WHERE DepartmentID = @DepartmentID";

                    using (var cmd = new SqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text.Trim());
                        cmd.Parameters.AddWithValue("@HeadOfDepartmentID", headId ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DepartmentID", _departmentId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Department updated successfully!", "Success");
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error updating department: {ex.Message}", "Database Error");
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
         * Method to handle search button click
         *********************************************************************/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadFilteredEmployees(txtSearch.Text.Trim());
            }
        }

        /**********************************************************************
         * Method to handle clear search button click
         *********************************************************************/
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            PopulateEmployeesDataGridView();
        }

        /**********************************************************************
         * Method to load filtered employee data
         *********************************************************************/
        private void LoadFilteredEmployees(string searchTerm)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT EmployeeID, FirstName, LastName 
                      FROM Employee 
                      WHERE FirstName LIKE @SearchTerm OR LastName LIKE @SearchTerm
                      ORDER BY LastName, FirstName";

                var adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                var dt = new DataTable();

                try
                {
                    adapter.Fill(dt);
                    dgvEmployees.DataSource = dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error searching employees: {ex.Message}", "Database Error");
                }
            }
        }

        /**********************************************************************
         * Method to select current director in DGV
         *********************************************************************/
        private void SelectHeadOfDepartmentRow(int employeeID)
        {
            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                if (Convert.ToInt32(row.Cells["EmployeeID"].Value) == employeeID)
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        /**********************************************************************
         * Method to handle clear selection button click
         *********************************************************************/
        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            dgvEmployees.ClearSelection();
            _selectedEmployeeId = -1;
        }

        /**********************************************************************
         * Method to validate input
         *********************************************************************/
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtDepartmentName.Text))
            {
                MessageBox.Show("Department name is required!");
                return false;
            }
            return true;
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

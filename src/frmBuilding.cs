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
    public partial class frmBuilding : Form
    {
        public enum FormMode { View, Edit, Add }
        private readonly int? _buildingId;
        private readonly FormMode _mode;
        private bool _hasUnsavedChanges = false;
        private int _addressId = -1;
        private int _selectedDirectorID = -1;

        public frmBuilding(FormMode mode, int? buildingId = null)
        {
            InitializeComponent();
            _mode = mode;
            _buildingId = buildingId;
            PopulateStateComboBox();
            PopulateEmployeesDataGridView();

            if (_mode == FormMode.Add)
                _hasUnsavedChanges = false;

            InitializeFormBasedOnMode();
            LoadBuildingData();

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
         * Method to load building data
         *********************************************************************/
        private void LoadBuildingData()
        {
            if (_mode == FormMode.Add) return;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT b.*, a.StreetAddress, a.ApartmentSuiteNum, a.City, a.State, a.ZipCode 
                    FROM Building b
                    INNER JOIN Address a ON b.AddressID = a.AddressID
                    WHERE b.BuildingID = @BuildingID";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BuildingID", _buildingId);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // For Debugging
                            //MessageBox.Show("Reader is indeed reading");

                            // Populate Building fields
                            txtName.Text = reader["Name"].ToString();
                            dtpDateOpened.Value = Convert.ToDateTime(reader["DateOpened"]);
                            txtAssignedFunction.Text = reader["AssignedFunction"].ToString();

                            // Populate Address fields
                            _addressId = Convert.ToInt32(reader["AddressID"]);
                            txtStreet.Text = reader["StreetAddress"].ToString();
                            txtApt.Text = reader["ApartmentSuiteNum"] == DBNull.Value ? string.Empty : reader["ApartmentSuiteNum"].ToString();
                            txtCity.Text = reader["City"].ToString();
                            var stateValue = reader["State"].ToString();
                            cboxState.SelectedItem = stateValue;
                            txtZip.Text = reader["ZipCode"].ToString();

                            //TODO: Populate Employees DataGridView
                            if (reader["DirectorID"] != DBNull.Value)
                            {
                                _selectedDirectorID = Convert.ToInt32(reader["DirectorID"]);
                                SelectDirectorRow(_selectedDirectorID);
                            }

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
                    _hasUnsavedChanges = false;
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
         * Method to handle the click event of the "Save" button
         *********************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == "")
            {
                try
                {
                    if (_mode == FormMode.Add)
                    {
                        CreateNewBuilding();
                    }
                    else
                    {
                        UpdateExistingBuilding();
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
         * Method to validate input fields
         *********************************************************************/
        private string ValidateInput()
        {
            //TODO: Implement validation logic for all controls
            return "";
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
         * Method to handle the click event of the "Exit" button. 
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
         * Method to create a new building
         *********************************************************************/
        private void CreateNewBuilding()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Create new address
                    int addressId = CreateAddress(conn, transaction);

                    // 2. Get director (if selected)
                    int? directorId = dgvEmployees.SelectedRows.Count > 0
                        ? Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["dgvEmployeeID"].Value)
                        : (int?)null;

                    // 3. Create building record
                    var query = @"INSERT INTO Building (
                            Name, DateOpened, AssignedFunction, 
                            AddressID, DirectorID
                          ) VALUES (
                            @Name, @DateOpened, @AssignedFunction,
                            @AddressID, @DirectorID
                          )";

                    using (var cmd = new SqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@DateOpened", dtpDateOpened.Value.Date);
                        cmd.Parameters.AddWithValue("@AssignedFunction", txtAssignedFunction.Text.Trim());
                        cmd.Parameters.AddWithValue("@AddressID", addressId);
                        cmd.Parameters.AddWithValue("@DirectorID", directorId ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Building created successfully!", "Success");
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error creating building: {ex.Message}", "Database Error");
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
         * Method to update an existing building
         *********************************************************************/
        private void UpdateExistingBuilding()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Update existing address
                    UpdateAddress(conn, transaction);

                    // 2. Get director (if selected)
                    int? directorId = dgvEmployees.SelectedRows.Count > 0
                        ? Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["dgvEmployeeID"].Value)
                        : (int?)null;

                    // 3. Update building record
                    var query = @"UPDATE Building SET
                            Name = @Name,
                            DateOpened = @DateOpened,
                            AssignedFunction = @AssignedFunction,
                            DirectorID = @DirectorID
                          WHERE BuildingID = @BuildingID";

                    using (var cmd = new SqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@DateOpened", dtpDateOpened.Value.Date);
                        cmd.Parameters.AddWithValue("@AssignedFunction", txtAssignedFunction.Text.Trim());
                        cmd.Parameters.AddWithValue("@DirectorID", directorId ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@BuildingID", _buildingId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            throw new Exception("No building record was updated");
                    }

                    transaction.Commit();
                    MessageBox.Show("Building updated successfully!", "Success");
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error updating building: {ex.Message}", "Database Error");
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
         * Method to handle the click event of the "Clear Selection" button 
         *********************************************************************/
        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            dgvEmployees.ClearSelection();
            _selectedDirectorID = -1;
        }

        /**********************************************************************
         * Method to handle the click event of the "Search" button
         *********************************************************************/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadFilteredEmployees(txtSearch.Text.Trim());
            }
        }

        /**********************************************************************
         * Method to handle the click event of the "Clear Search" button
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
        private void SelectDirectorRow(int employeeID)
        {
            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                if (Convert.ToInt32(row.Cells["dgvEmployeeID"].Value) == employeeID)
                {
                    row.Selected = true;
                    break;
                }
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

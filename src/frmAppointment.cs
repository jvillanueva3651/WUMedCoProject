using System;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WUMedCoProject.src
{
    public partial class frmAppointment : Form
    {
        public enum FormMode { Add, View, Edit }
        private readonly int? _appointmentId;
        private readonly FormMode _mode;
        private bool _hasUnsavedChanges = false;

        public frmAppointment(FormMode mode, int? appointmentId = null)
        {
            InitializeComponent();
            _mode = mode;
            _appointmentId = appointmentId;

            if (_mode == FormMode.Add)
                _hasUnsavedChanges = false;

            InitializeFormBasedOnMode();
            LoadAppointmentData();
            LoadPatients();
            LoadPhysicians();
            LoadRooms();

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

        /**********************************************************************
        * Method to load appointment data from the database
        **********************************************************************/
        private void LoadAppointmentData()
        {
            if (_mode == FormMode.Add) return;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"
            SELECT 
                a.DateTime, a.Purpose, a.PatientID, a.PhysicianID, a.RoomID,
                p.FirstName AS PatientFirstName, p.LastName AS PatientLastName,
                e.FirstName AS PhysicianFirstName, e.LastName AS PhysicianLastName,
                b.Name AS BuildingName, r.RoomType
            FROM Appointment a
            INNER JOIN Patient p ON a.PatientID = p.PatientID
            INNER JOIN Employee e ON a.PhysicianID = e.EmployeeID
            INNER JOIN Room r ON a.RoomID = r.RoomID
            INNER JOIN Building b ON r.BuildingID = b.BuildingID
            WHERE a.AppointmentID = @AppointmentID";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AppointmentID", _appointmentId.Value);

                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        //For debugging
                        MessageBox.Show($"AppointmentID: {_appointmentId}");

                        // Populate basic fields
                        dtpScheduled.Value = (DateTime)reader["DateTime"];
                        txtPurpose.Text = reader["Purpose"].ToString();

                        // Select Patient in DGV
                        SelectRowInDGV(dgvPatient, "PatientID", reader["PatientID"]);
                        // Select Physician in DGV
                        SelectRowInDGV(dgvEmployees, "EmployeeID", reader["PhysicianID"]);
                        // Select Room in DGV
                        SelectRowInDGV(dgvRoom, "RoomID", reader["RoomID"]);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error");
                }
            }
        }

        /**********************************************************************
         * Method to select a row in a DataGridView based on a specific column value
         *********************************************************************/
        private void SelectRowInDGV(DataGridView dgv, string idColumnName, object idValue)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[idColumnName].Value.ToString() == idValue.ToString())
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        /**********************************************************************
         * Method to handle the click event of the "Save" button
         *********************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                conn.Open();
                var query = _mode == FormMode.Add ?
                    @"INSERT INTO Appointment (DateTime, Purpose, PatientID, PhysicianID, RoomID)
              VALUES (@DateTime, @Purpose, @PatientID, @PhysicianID, @RoomID)" :
                    @"UPDATE Appointment SET
                DateTime = @DateTime,
                Purpose = @Purpose,
                PatientID = @PatientID,
                PhysicianID = @PhysicianID,
                RoomID = @RoomID
              WHERE AppointmentID = @AppointmentID";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DateTime", dtpScheduled.Value);
                cmd.Parameters.AddWithValue("@Purpose", txtPurpose.Text.Trim());
                cmd.Parameters.AddWithValue("@PatientID", GetSelectedPatientID());
                cmd.Parameters.AddWithValue("@PhysicianID", GetSelectedPhysicianID());
                cmd.Parameters.AddWithValue("@RoomID", GetSelectedRoomID());

                if (_mode == FormMode.Edit)
                    cmd.Parameters.AddWithValue("@AppointmentID", _appointmentId);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Appointment saved successfully!", "Success");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error saving appointment: {ex.Message}", "Database Error");
                }
            }
        }

        /**********************************************************************
         * Method to validate user input before saving
         *********************************************************************/
        private bool ValidateInput()
        {
            var errors = new StringBuilder();

            if (dtpScheduled.Value < DateTime.Now)
                errors.AppendLine("- Appointment date/time must be in the future");
            if (string.IsNullOrWhiteSpace(txtPurpose.Text))
                errors.AppendLine("- Purpose is required");
            if (dgvPatient.SelectedRows.Count == 0)
                errors.AppendLine("- Patient must be selected");
            if (dgvEmployees.SelectedRows.Count == 0)
                errors.AppendLine("- Physician must be selected");
            if (dgvRoom.SelectedRows.Count == 0)
                errors.AppendLine("- Room must be selected");

            if (errors.Length > 0)
            {
                MessageBox.Show($"Please fix the following errors:\n\n{errors}", "Validation Error");
                return false;
            }
            return true;
        }

        /**********************************************************************
         * Methods to get selected IDs from DataGridViews
         *********************************************************************/
        private int GetSelectedPatientID()
        {
            return Convert.ToInt32(dgvPatient.SelectedRows[0].Cells["PatientID"].Value);
        }
        private int GetSelectedPhysicianID()
        {
            return Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
        }
        private int GetSelectedRoomID()
        {
            return Convert.ToInt32(dgvRoom.SelectedRows[0].Cells["RoomID"].Value);
        }

        /**********************************************************************
         * Method to handle the click event of the "Cancel" button
         *********************************************************************/
        private void btnCancel_Click(object sender, EventArgs e)
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
         * Method to load patients into the DataGridView
         *********************************************************************/
        private void LoadPatients()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = "SELECT PatientID, FirstName, LastName FROM Patient";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dgvPatient.DataSource = dt;
            }
        }

        /**********************************************************************
         * Method to load physicians into the DataGridView
         *********************************************************************/
        private void LoadPhysicians()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = "SELECT EmployeeID, FirstName, LastName FROM Employee";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dgvEmployees.DataSource = dt;
            }
        }

        /**********************************************************************
         * Method to load rooms into the DataGridView
         *********************************************************************/
        private void LoadRooms()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"
            SELECT r.RoomID, b.Name AS Building, r.RoomType 
            FROM Room r
            INNER JOIN Building b ON r.BuildingID = b.BuildingID";
                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dgvRoom.DataSource = dt;
            }
        }

        /**********************************************************************
         * Method to search the appropriate DataGridView based on a search term
         *********************************************************************/
        private void SearchDGV(DataGridView dgv, string table, string searchTerm, params string[] columns)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var whereClause = string.Join(" OR ", columns.Select(c => $"{c} LIKE @SearchTerm"));
                var query = $"SELECT * FROM {table} WHERE {whereClause}";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                dgv.DataSource = dt;
            }
        }

        /**********************************************************************
         * Method to handle the click event of the "Search Patient" button
         *********************************************************************/
        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            SearchDGV(dgvPatient, "Patient", txtSearchPatient.Text, "FirstName", "LastName");
        }

        /**********************************************************************
         * Method to handle the click event of the "Clear Patient Search" button
         *********************************************************************/
        private void btnClearPatientSearch_Click(object sender, EventArgs e)
        {
            txtSearchPatient.Clear();
            LoadPatients();
        }

        /**********************************************************************
         * Method to handle the click event of the "Search Employee" button
         *********************************************************************/
        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            SearchDGV(dgvEmployees, "Employee", txtSearchEmployee.Text, "FirstName", "LastName");
        }

        /**********************************************************************
         * Method to handle the click event of the "Clear Employee Search" button
         *********************************************************************/
        private void btnClearEmployeeSearch_Click(object sender, EventArgs e)
        {
            txtSearchEmployee.Clear();
            LoadPhysicians();
        }
    }
}

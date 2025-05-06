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

namespace WUMedCoProject.src
{
    public partial class frmDepartment : Form
    {
        private readonly FormMode _mode;
        private readonly int? _departmentId;
        private int? _selectedEmployeeId = null;

        public frmDepartment(FormMode mode, int? departmentId = null)
        {
            InitializeComponent();
            _mode = mode;
            _departmentId = departmentId;
            InitializeForm();
        }

        /**********************************************************************
         * Method to initialize the form based on the mode (Add/Edit)
         *********************************************************************/
        private void InitializeForm()
        {
            if(_mode == FormMode.Add)
            {
                LoadDepartmentData(null);
            }
            else
            {
                LoadDepartmentData(_departmentId);
            }
        }

        /**********************************************************************
         * Method to load department data for adding or editing
         *********************************************************************/
        private void LoadDepartmentData(int? departmentId)
        {

        }

        /**********************************************************************
         * Method to handle exit button click
         *********************************************************************/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**********************************************************************
         * Method to handle save button click
         *********************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
                {
                    conn.Open();
                    var query = _mode == FormMode.Add
                        ? @"INSERT INTO Department (DepartmentName, HeadOfDepartmentID)
                   VALUES (@Name, @HeadID)"
                        : @"UPDATE Department 
                   SET DepartmentName = @Name, 
                       HeadEmployeeID = @HeadID
                   WHERE DepartmentID = @ID";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtDepartmentName.Text);
                        cmd.Parameters.AddWithValue("@HeadID", _selectedEmployeeId ?? (object)DBNull.Value);

                        if (_mode == FormMode.Edit)
                            cmd.Parameters.AddWithValue("@ID", _departmentId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Department saved successfully!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        /**********************************************************************
         * Method to handle search button click
         *********************************************************************/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadEmployees(txtSearch.Text);
        }

        /**********************************************************************
         * Method to handle clear search button click
         *********************************************************************/
        private void btnClearSearch_Click(object sender, EventArgs e)
        {

        }

        /**********************************************************************
         * Method to handle selection of employee in DataGridView
         *********************************************************************/
        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                _selectedEmployeeId = Convert.ToInt32(
                    dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value
                );
            }
        }

        /**********************************************************************
         * Method to handle clear selection button click
         *********************************************************************/
        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            _selectedEmployeeId = null;
            dgvEmployees.ClearSelection();
        }

        /**********************************************************************
         * Method to load employees into DataGridView OR load search results
         *********************************************************************/
        private void LoadEmployees(string searchTerm = "")
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT EmployeeID, LastName, FirstName
                              FROM Employee
                              WHERE (@SearchTerm = '' OR
                                LastName LIKE '%' + @SearchTerm + '%' OR
                                FirstName LIKE '%' + @SearchTerm + '%' OR
                                EmployeeID LIKE '%' + @SearchTerm + '%')";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);

                var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                dgvEmployees.DataSource = dt;
            }
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
    }
}

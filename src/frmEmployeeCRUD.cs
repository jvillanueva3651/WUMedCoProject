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
    public partial class frmEmployeeCRUD : Form
    {
        public frmEmployeeCRUD()
        {
            InitializeComponent();
            LoadEmployees(); // Load data on form initialization
        }

        /**********************************************************************
         * Load employees into the DataGridView
         *********************************************************************/
        private void LoadEmployees()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT 
                                EmployeeID, 
                                LastName, 
                                FirstName, 
                                CONVERT(varchar, DateOfBirth, 101) AS DateOfBirth, 
                                Position, 
                                OfficeNumber, 
                                Extension 
                             FROM Employee";

                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);

                dgvEmployee.DataSource = dt;
            }
        }

        /**********************************************************************
         * Handle button clicks in the DataGridView (View/Edit/Delete)
         *********************************************************************/
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var dataTable = (DataTable)dgvEmployee.DataSource;
            var employeeId = Convert.ToInt32(dataTable.Rows[e.RowIndex]["EmployeeID"]);

            // Determine which button was clicked
            if (dgvEmployee.Columns[e.ColumnIndex] == dgvView)
            {
                OpenEmployeeForm(frmEmployee.FormMode.View, employeeId);
            }
            else if (dgvEmployee.Columns[e.ColumnIndex] == dgvEdit)
            {
                OpenEmployeeForm(frmEmployee.FormMode.Edit, employeeId);
            }
            else if (dgvEmployee.Columns[e.ColumnIndex] == dgvDelete)
            {
                DeleteEmployee(employeeId);
            }
        }

        /**********************************************************************
         * Open the Employee form in Add/Edit/View mode
         *********************************************************************/
        private void OpenEmployeeForm(frmEmployee.FormMode mode, int? employeeId = null)
        {
            using (var employeeForm = new frmEmployee(mode, employeeId))
            {
                if (employeeForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployees(); // Refresh the DataGridView
                }
            }
        }

        /**********************************************************************
         * Delete an employee record
         *********************************************************************/
        private void DeleteEmployee(int employeeId)
        {
            var result = MessageBox.Show("Are you sure you want to delete this employee?",
                "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                try
                {
                    var query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error deleting employee: {ex.Message}", "Database Error");
                }
                finally
                {
                    conn.Close();
                    LoadEmployees(); // Refresh the DataGridView
                }
            }
        }

        /**********************************************************************
         * Add New Employee button click
         *********************************************************************/
        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            OpenEmployeeForm(frmEmployee.FormMode.Add);
        }

        /**********************************************************************
         * Return to Home button click
         *********************************************************************/
        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

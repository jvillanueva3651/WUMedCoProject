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
using WUMedCoProject.src;

namespace WUMedCoProject
{
    public partial class frmDepartmentsCRUD : Form
    {
        public frmDepartmentsCRUD()
        {
            InitializeComponent();
            LoadDepartments();
        }

        /**********************************************************************
         * Method to load departments into the DataGridView
         *********************************************************************/
        private void LoadDepartments()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"
                    SELECT 
                        d.DepartmentID, 
                        d.DepartmentName,
                        CASE 
                            WHEN d.HeadOfDepartmentID IS NULL THEN '[No Head Assigned]'
                            ELSE e.LastName + ', ' + e.FirstName 
                        END AS HeadOfDepartment
                    FROM Department d
                    LEFT JOIN Employee e ON d.HeadOfDepartmentID = e.EmployeeID";

                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);

                dgvDepartments.DataSource = dt;
                dgvDepartments.Columns["DepartmentID"].Visible = false; // Hide ID column
            }
        }

        /**********************************************************************
         * Method to handle return home button click 
         *********************************************************************/
        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**********************************************************************
         * Method to handle add new department button click 
         *********************************************************************/
        private void btnAddNewDepartment_Click(object sender, EventArgs e)
        {
            OpenDepartmentForm(frmDepartment.FormMode.Add);
        }

        /**********************************************************************
         * Method to handle the edit and delete DGV button clicks 
         *********************************************************************/
        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var dataTable = (DataTable)dgvDepartments.DataSource;

            var departmentId = Convert.ToInt32(dataTable.Rows[e.RowIndex]["DepartmentID"]);

            //For Debugging
            //MessageBox.Show($"DepartmentID: {departmentId}");

            if (dgvDepartments.Columns[e.ColumnIndex] == BtnEdit)
            {
                OpenDepartmentForm(frmDepartment.FormMode.Edit, departmentId);
            }
            else if (dgvDepartments.Columns[e.ColumnIndex] == BtnView)
            {
                OpenDepartmentForm(frmDepartment.FormMode.View, departmentId);
            }
        }

        /**********************************************************************
         * Method to open the department form
         *********************************************************************/
        private void OpenDepartmentForm(frmDepartment.FormMode mode, int? departmentId = null)
        {
            using (var departmentForm = new frmDepartment(mode, departmentId))
            {
                if (departmentForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDepartments(); // Refresh DataGridView
                }
            }
        }
    }
}

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
            OpenDepartmentForm();
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

            if (dgvDepartments.Columns[e.ColumnIndex] == dgvBtnEdit)
            {
                OpenDepartmentForm();
            }
            else if (dgvDepartments.Columns[e.ColumnIndex] == dgvBtnDelete)
            {
                DeleteDepartment(departmentId);
            }
        }

        /**********************************************************************
         * Method to delete a department from the database
         *********************************************************************/
        private void DeleteDepartment(int departmentId)
        {
            //TODO: Add deletion logic
        }

        /**********************************************************************
         * Method to open the department form
         *********************************************************************/
        private void OpenDepartmentForm()
        {
            //TODO: Add logic to open form
        }
    }
}

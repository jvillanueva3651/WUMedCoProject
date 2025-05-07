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
using WUMedCoProject.src;

namespace WUMedCoProject
{
    public partial class frmBuildingsCRUD : Form
    {
        public frmBuildingsCRUD()
        {
            InitializeComponent();
            LoadBuildings();
        }

        /**********************************************************************
         * Method to handle the click event of the "Add new Building" button. 
         *********************************************************************/
        private void btnAddNewBuilding_Click(object sender, EventArgs e)
        {
            frmBuilding buildingForm = new frmBuilding(frmBuilding.FormMode.Add);
            buildingForm.Show();
        }

        /**********************************************************************
         * Method to handle the click event of the "Return to Home" button. 
         *********************************************************************/
        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**********************************************************************
         * Method to load buildings into the DataGridView
         *********************************************************************/
        private void LoadBuildings()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"
                    SELECT 
                        b.BuildingID, 
                        b.Name,
                        CASE 
                            WHEN b.DirectorID IS NULL THEN '[No Director Assigned]'
                            ELSE e.LastName + ', ' + e.FirstName 
                        END AS Director
                    FROM Building b
                    LEFT JOIN Employee e ON b.DirectorID = e.EmployeeID";

                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);

                dgvBuildings.DataSource = dt;
                dgvBuildings.Columns["dgvBuildingID"].Visible = false; //Hidden ID
            }
        }

        /**********************************************************************
         * Method to handle the edit, view, delete buttons in the DataGridView
         *********************************************************************/
        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var dataTable = (DataTable)dgvBuildings.DataSource;

            var buildingId = Convert.ToInt32(dataTable.Rows[e.RowIndex]["dgvBuildingID"]);

            //For Debugging
            //MessageBox.Show($"BuildingID: {buildingId}");

            if (dgvBuildings.Columns[e.ColumnIndex] == dgvBtnView)
            {
                OpenBuildingForm(frmBuilding.FormMode.View, buildingId);
            }
            else if (dgvBuildings.Columns[e.ColumnIndex] == dgvBtnEdit)
            {
                OpenBuildingForm(frmBuilding.FormMode.Edit, buildingId);
            }
        }

        /**********************************************************************
         * Method to open the building form in the specified mode
         *********************************************************************/
        private void OpenBuildingForm(frmBuilding.FormMode mode, int? buildingId = null)
        {
            using (var buildingForm = new frmBuilding(mode, buildingId))
            {
                if (buildingForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBuildings(); //Refreshes the DGV
                }
            }
        }
    }
}

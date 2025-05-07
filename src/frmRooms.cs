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

namespace WUMedCoProject.src
{
    public partial class frmRooms : Form
    {
        private int buildingId;

        public frmRooms(int buildingId)
        {
            InitializeComponent();
            this.buildingId = buildingId;

            dgvRooms.CellEndEdit += dgvRooms_CellEndEdit;

            SetupDataGridView();
            LoadBuildingName();
            LoadRoomsData();
        }

        /**************************************************************************
         * Method to load the building name into the label at the top of the form.
         *************************************************************************/
        private void LoadBuildingName()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Name FROM Building WHERE BuildingID = @BuildingID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BuildingID", buildingId);
                    string buildingName = cmd.ExecuteScalar()?.ToString();
                    lblRoomInfo.Text = $"Rooms Information for {buildingName}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading building name: {ex.Message}");
            }
        }

        /**************************************************************************
         * Method to set up the DataGridView for displaying room information.
         *************************************************************************/
        private void SetupDataGridView()
        {
            dgvRooms.AutoGenerateColumns = false;
            RoomID.DataPropertyName = "RoomID";
            RoomType.DataPropertyName = "RoomType";
            Capacity.DataPropertyName = "Capacity";
            dgvRooms.Columns["RoomID"].Visible = false;
            dgvRooms.ReadOnly = true;
            btnView.Visible = false;
            btnEdit.Visible = true;
        }

        /**************************************************************************
         * Method to load the rooms data into the DataGridView.
         *************************************************************************/
        private void LoadRoomsData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT RoomID, RoomType, Capacity FROM Room WHERE BuildingID = @BuildingID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BuildingID", buildingId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvRooms.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms data: {ex.Message}");
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
         * Method to handle the click event of the "Edit" button.
         *********************************************************************/
        private void btnEdit_Click(object sender, EventArgs e)
        {
            dgvRooms.ReadOnly = false;
            btnEdit.Visible = false;
            btnView.Visible = true;
        }

        /**********************************************************************
         * Method to handle the click event of the "View" button.
         *********************************************************************/
        private void btnView_Click(object sender, EventArgs e)
        {
            dgvRooms.ReadOnly = true;
            btnView.Visible = false;
            btnEdit.Visible = true;
            LoadRoomsData();
        }

        /**********************************************************************
         * Method to handle the editing of the DataGridView cells.
         *********************************************************************/
        private void dgvRooms_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRooms.ReadOnly) return;

            DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
            int roomId = Convert.ToInt32(row.Cells["RoomID"].Value);
            string roomType = row.Cells["RoomType"].Value?.ToString();
            object capacityObj = row.Cells["Capacity"].Value;

            if (string.IsNullOrEmpty(roomType) || capacityObj == null)
            {
                MessageBox.Show("Room Type and Capacity cannot be empty.");
                dgvRooms.CancelEdit();
                LoadRoomsData();
                return;
            }

            if (!int.TryParse(capacityObj.ToString(), out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Capacity must be a positive integer.");
                dgvRooms.CancelEdit();
                LoadRoomsData();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Room SET RoomType = @RoomType, Capacity = @Capacity WHERE RoomID = @RoomID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RoomType", roomType);
                    cmd.Parameters.AddWithValue("@Capacity", capacity);
                    cmd.Parameters.AddWithValue("@RoomID", roomId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        MessageBox.Show("No changes were saved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}");
                LoadRoomsData(); // Refresh to reflect actual database state
            }
        }
    }
}

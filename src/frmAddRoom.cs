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
    public partial class frmAddRoom : Form
    {
        int buildingId;
        bool _hasUnsavedChanges = false;

        public frmAddRoom(int buildingId)
        {
            InitializeComponent();
            this.buildingId = buildingId;
            LoadBuildingName();
        }

        /**************************************************************
         * Method to load the building name into the label.
         *************************************************************/
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
                    lblBuilding.Text = $"Add a room to {buildingName}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading building name: {ex.Message}");
            }
        }

        /**************************************************************
         * Method to handle save button click
         *************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            string roomType = txtRoomType.Text.Trim();
            string capacityText = txtCapacity.Text.Trim();

            if (string.IsNullOrEmpty(roomType))
            {
                MessageBox.Show("Room Type cannot be empty!");
                txtRoomType.Focus();
                return;
            }

            if (!int.TryParse(capacityText, out int capacity) || capacity < 1)
            {
                MessageBox.Show("Capacity must be a positive integer!");
                txtCapacity.SelectAll();
                txtCapacity.Focus();
                return;
            }

            // Insert new room
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Room (RoomType, Capacity, BuildingID)
                        VALUES (@RoomType, @Capacity, @BuildingID)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RoomType", roomType);
                    cmd.Parameters.AddWithValue("@Capacity", capacity);
                    cmd.Parameters.AddWithValue("@BuildingID", buildingId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving room: {ex.Message}");
            }
        }
        /**************************************************************
         * Method to handle cancel button click
         *************************************************************/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

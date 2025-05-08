using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace WUMedCoProject.src
{
    public partial class frmEquipmentCRUD : Form
    {
        public frmEquipmentCRUD()
        {
            InitializeComponent();
            LoadEquipment();
        }

        private void LoadEquipment()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = @"SELECT EquipmentID, Brand, Model, SerialNumber, Type, Cost, AcquisitionDate, Status, LastMaintenanceDate, RoomID
                             FROM Equipment";

                var adapter = new SqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);

                dgvEquipment.DataSource = dt;
                dgvEquipment.Columns["EquipmentID"].Visible = false;
            }
        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            using (var frm = new frmEquipment(frmEquipment.FormMode.Add))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadEquipment();
            }
        }

        private void dgvEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var equipmentId = Convert.ToInt32(dgvEquipment.Rows[e.RowIndex].Cells["EquipmentID"].Value);

            if (dgvEquipment.Columns[e.ColumnIndex] == dgvBtnView)
            {
                OpenEquipmentForm(frmEquipment.FormMode.View, equipmentId);
            }
            else if (dgvEquipment.Columns[e.ColumnIndex] == dgvBtnEdit)
            {
                OpenEquipmentForm(frmEquipment.FormMode.Edit, equipmentId);
            }
            else if (dgvEquipment.Columns[e.ColumnIndex] == dgvBtnDelete)
            {
                DeleteEquipment(equipmentId);
            }
        }

        private void OpenEquipmentForm(frmEquipment.FormMode mode, int? equipmentId = null)
        {
            using (var frm = new frmEquipment(mode, equipmentId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadEquipment();
            }
        }

        private void DeleteEquipment(int equipmentId)
        {
            var result = MessageBox.Show("Delete this equipment record?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        var cmd = new SqlCommand("DELETE FROM Equipment WHERE EquipmentID = @ID", conn);
                        cmd.Parameters.AddWithValue("@ID", equipmentId);
                        cmd.ExecuteNonQuery();
                        LoadEquipment();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Delete failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnReturnHome_Click(object sender, EventArgs e) => this.Close();

        private void dgvEquipment_CellContentClick() => this.Close();
    }
}
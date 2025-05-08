using Microsoft.Data.SqlClient;
using System.Configuration;
using System;
using System.Windows.Forms;

namespace WUMedCoProject.src
{
    public partial class frmEquipment : Form
    {
        public enum FormMode { View, Edit, Add }
        private readonly FormMode _mode;
        private readonly int? _equipmentId;
        private bool _hasUnsavedChanges;

        public frmEquipment(FormMode mode, int? equipmentId = null)
        {
            InitializeComponent();
            _mode = mode;
            _equipmentId = equipmentId;
            InitializeFormBasedOnMode();
            LoadRoomOptions();
            LoadStatusOptions();
            if (mode != FormMode.Add) LoadEquipmentData();
            WireUpChangeEvents(this);
        }

        private void InitializeFormBasedOnMode()
        {
            SetControlsReadOnly(_mode == FormMode.View);
            btnSave.Visible = _mode != FormMode.View;
        }

        private void SetControlsReadOnly(bool readOnly)
        {
            foreach (Control ctrl in gbEquipmentDetails.Controls)
            {
                if (ctrl is TextBox txt) txt.ReadOnly = readOnly;
                else if (ctrl is ComboBox cmb) cmb.Enabled = !readOnly;
                else if (ctrl is DateTimePicker dtp) dtp.Enabled = !readOnly;
            }
        }

        private void LoadRoomOptions()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = "SELECT RoomID, RoomType + ' (Bldg ' + CAST(BuildingID AS varchar) + ')' AS Display FROM Room";
                var cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    cboRoom.Items.Add(new ComboboxItem(reader["Display"].ToString(), reader.GetInt32(0)));
            }
        }

        private void LoadStatusOptions() => cboStatus.Items.AddRange(new[] { "Operational", "Maintenance", "Retired" });

        private void LoadEquipmentData()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
            {
                var query = "SELECT * FROM Equipment WHERE EquipmentID = @ID";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", _equipmentId);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtType.Text = reader["Type"].ToString();
                    txtBrand.Text = reader["Brand"].ToString();
                    txtModel.Text = reader["Model"].ToString();
                    txtSerial.Text = reader["SerialNumber"].ToString();
                    txtCost.Text = reader["Cost"].ToString();
                    dtpAcquisition.Value = Convert.ToDateTime(reader["AcquisitionDate"]);
                    dtpLastMaintenance.Value = reader["LastMaintenanceDate"] is DBNull ?
                        DateTime.Today : Convert.ToDateTime(reader["LastMaintenanceDate"]);
                    cboStatus.SelectedItem = reader["Status"].ToString();
                    SelectComboItem(cboRoom, Convert.ToInt32(reader["RoomID"]));
                }
            }
        }

        private void SelectComboItem(ComboBox combo, int value)
        {
            foreach (ComboboxItem item in combo.Items)
                if (item.Value == value) combo.SelectedItem = item;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            if (_mode == FormMode.Add)
                                CreateEquipment(conn, transaction);
                            else
                                UpdateEquipment(conn, transaction);

                            transaction.Commit();
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Save failed: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void CreateEquipment(SqlConnection conn, SqlTransaction transaction)
        {
            var query = @"INSERT INTO Equipment (Brand, Model, SerialNumber, Type, Cost, 
                          AcquisitionDate, LastMaintenanceDate, Status, RoomID)
                          VALUES (@Brand, @Model, @Serial, @Type, @Cost, @Acquire, @Maintain, @Status, @RoomID)";

            ExecuteEquipmentCommand(query, conn, transaction);
            MessageBox.Show("Equipment added successfully!", "Success");
        }

        private void UpdateEquipment(SqlConnection conn, SqlTransaction transaction)
        {
            var query = @"UPDATE Equipment SET 
                         Brand = @Brand, Model = @Model, SerialNumber = @Serial,
                         Type = @Type, Cost = @Cost, AcquisitionDate = @Acquire, LastMaintenanceDate = @Maintain,
                         Status = @Status, RoomID = @RoomID
                         WHERE EquipmentID = @ID";

            ExecuteEquipmentCommand(query, conn, transaction);
            MessageBox.Show("Equipment updated successfully!", "Success");
        }

        private void ExecuteEquipmentCommand(string query, SqlConnection conn, SqlTransaction transaction)
        {
            using (var cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Type", txtType.Text);
                cmd.Parameters.AddWithValue("@Brand", txtBrand.Text);
                cmd.Parameters.AddWithValue("@Model", txtModel.Text);
                cmd.Parameters.AddWithValue("@Serial", txtSerial.Text);
                cmd.Parameters.AddWithValue("@Cost", decimal.Parse(txtCost.Text));
                cmd.Parameters.AddWithValue("@Acquire", dtpAcquisition.Value);
                cmd.Parameters.AddWithValue("@Maintain", dtpLastMaintenance.Value);
                cmd.Parameters.AddWithValue("@Status", cboStatus.SelectedItem);
                cmd.Parameters.AddWithValue("@RoomID", ((ComboboxItem)cboRoom.SelectedItem).Value);
                if (_mode == FormMode.Edit)
                    cmd.Parameters.AddWithValue("@ID", _equipmentId);
                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtType.Text) ||
                string.IsNullOrWhiteSpace(txtSerial.Text) ||
                cboRoom.SelectedItem == null)
            {
                MessageBox.Show("Please fill required fields: Type, Serial Number, and Room", "Validation Error");
                return false;
            }
            if (!decimal.TryParse(txtCost.Text, out _))
            {
                MessageBox.Show("Please enter valid cost value", "Validation Error");
                return false;
            }
            return true;
        }

        private void WireUpChangeEvents(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox) ((TextBox)ctrl).TextChanged += OnControlChanged;
                else if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedIndexChanged += OnControlChanged;
                else if (ctrl is DateTimePicker) ((DateTimePicker)ctrl).ValueChanged += OnControlChanged;
                if (ctrl.HasChildren) WireUpChangeEvents(ctrl);
            }
        }

        private void OnControlChanged(object sender, EventArgs e) => _hasUnsavedChanges = true;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_hasUnsavedChanges && DialogResult != DialogResult.OK)
            {
                var result = MessageBox.Show("Discard unsaved changes?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                e.Cancel = result == DialogResult.No;
            }
            base.OnFormClosing(e);
        }

        private class ComboboxItem
        {
            public string Text { get; }
            public int Value { get; }
            public ComboboxItem(string text, int value) { Text = text; Value = value; }
            public override string ToString() => Text;
        }

        private void CancelButton_Click(Object sender, EventArgs e) => this.Close();

        private void gbEquipmentDetails_Enter(object sender, EventArgs e)
        {

        }
    }
}
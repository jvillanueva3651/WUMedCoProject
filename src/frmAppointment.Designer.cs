using System.Windows.Forms;

namespace WUMedCoProject.src
{
    partial class frmAppointment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDateTime = new Label();
            lblPurpose = new Label();
            lblPatient = new Label();
            lblPhysician = new Label();
            lblRoom = new Label();
            txtPurpose = new TextBox();
            dtpScheduled = new DateTimePicker();
            dgvPatient = new DataGridView();
            PatientID = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            dgvRoom = new DataGridView();
            RoomID = new DataGridViewTextBoxColumn();
            Building = new DataGridViewTextBoxColumn();
            RoomType = new DataGridViewTextBoxColumn();
            btnClearEmployeeSearch = new Button();
            btnSearchEmployee = new Button();
            txtSearchEmployee = new TextBox();
            dgvEmployees = new DataGridView();
            dgvEmployeeID = new DataGridViewTextBoxColumn();
            dgvFirstName = new DataGridViewTextBoxColumn();
            dgvLastName = new DataGridViewTextBoxColumn();
            btnClearPatientSearch = new Button();
            btnSearchPatient = new Button();
            txtSearchPatient = new TextBox();
            flpButtons = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatient).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            flpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Location = new Point(12, 172);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(62, 15);
            lblDateTime.TabIndex = 0;
            lblDateTime.Text = "Date/Time";
            // 
            // lblPurpose
            // 
            lblPurpose.AutoSize = true;
            lblPurpose.Location = new Point(12, 9);
            lblPurpose.Name = "lblPurpose";
            lblPurpose.Size = new Size(50, 15);
            lblPurpose.TabIndex = 1;
            lblPurpose.Text = "Purpose";
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Location = new Point(12, 243);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(44, 15);
            lblPatient.TabIndex = 2;
            lblPatient.Text = "Patient";
            // 
            // lblPhysician
            // 
            lblPhysician.AutoSize = true;
            lblPhysician.Location = new Point(265, 243);
            lblPhysician.Name = "lblPhysician";
            lblPhysician.Size = new Size(57, 15);
            lblPhysician.TabIndex = 3;
            lblPhysician.Text = "Physician";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Location = new Point(332, 9);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(39, 15);
            lblRoom.TabIndex = 4;
            lblRoom.Text = "Room";
            // 
            // txtPurpose
            // 
            txtPurpose.Location = new Point(12, 27);
            txtPurpose.Multiline = true;
            txtPurpose.Name = "txtPurpose";
            txtPurpose.Size = new Size(307, 132);
            txtPurpose.TabIndex = 5;
            // 
            // dtpScheduled
            // 
            dtpScheduled.Location = new Point(12, 190);
            dtpScheduled.Name = "dtpScheduled";
            dtpScheduled.Size = new Size(207, 23);
            dtpScheduled.TabIndex = 6;
            // 
            // dgvPatient
            // 
            dgvPatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatient.Columns.AddRange(new DataGridViewColumn[] { PatientID, FirstName, LastName });
            dgvPatient.Location = new Point(12, 261);
            dgvPatient.Name = "dgvPatient";
            dgvPatient.Size = new Size(247, 150);
            dgvPatient.TabIndex = 7;
            // 
            // PatientID
            // 
            PatientID.DataPropertyName = "PatientID";
            PatientID.HeaderText = "PatientID";
            PatientID.Name = "PatientID";
            PatientID.ReadOnly = true;
            PatientID.Visible = false;
            // 
            // FirstName
            // 
            FirstName.HeaderText = "First Name";
            FirstName.Name = "FirstName";
            FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            LastName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LastName.HeaderText = "Last Name";
            LastName.Name = "LastName";
            LastName.ReadOnly = true;
            // 
            // dgvRoom
            // 
            dgvRoom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoom.Columns.AddRange(new DataGridViewColumn[] { RoomID, Building, RoomType });
            dgvRoom.Location = new Point(332, 27);
            dgvRoom.Name = "dgvRoom";
            dgvRoom.Size = new Size(209, 186);
            dgvRoom.TabIndex = 8;
            // 
            // RoomID
            // 
            RoomID.DataPropertyName = "RoomID";
            RoomID.HeaderText = "RoomID";
            RoomID.Name = "RoomID";
            RoomID.ReadOnly = true;
            RoomID.Visible = false;
            // 
            // Building
            // 
            Building.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Building.DataPropertyName = "Building";
            Building.HeaderText = "Building";
            Building.Name = "Building";
            Building.ReadOnly = true;
            // 
            // RoomType
            // 
            RoomType.HeaderText = "Room";
            RoomType.Name = "RoomType";
            RoomType.Width = 65;
            // 
            // btnClearEmployeeSearch
            // 
            btnClearEmployeeSearch.Location = new Point(490, 236);
            btnClearEmployeeSearch.Name = "btnClearEmployeeSearch";
            btnClearEmployeeSearch.Size = new Size(51, 23);
            btnClearEmployeeSearch.TabIndex = 40;
            btnClearEmployeeSearch.Text = "Clear";
            btnClearEmployeeSearch.UseVisualStyleBackColor = true;
            btnClearEmployeeSearch.Click += btnClearEmployeeSearch_Click;
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Location = new Point(428, 236);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(56, 23);
            btnSearchEmployee.TabIndex = 39;
            btnSearchEmployee.Text = "Search";
            btnSearchEmployee.UseVisualStyleBackColor = true;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // txtSearchEmployee
            // 
            txtSearchEmployee.Location = new Point(328, 236);
            txtSearchEmployee.Name = "txtSearchEmployee";
            txtSearchEmployee.PlaceholderText = "Search...";
            txtSearchEmployee.Size = new Size(94, 23);
            txtSearchEmployee.TabIndex = 38;
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { dgvEmployeeID, dgvFirstName, dgvLastName });
            dgvEmployees.Location = new Point(265, 261);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.Size = new Size(276, 150);
            dgvEmployees.TabIndex = 37;
            // 
            // dgvEmployeeID
            // 
            dgvEmployeeID.DataPropertyName = "EmployeeID";
            dgvEmployeeID.HeaderText = "Employee ID";
            dgvEmployeeID.Name = "dgvEmployeeID";
            dgvEmployeeID.Visible = false;
            dgvEmployeeID.Width = 80;
            // 
            // dgvFirstName
            // 
            dgvFirstName.DataPropertyName = "FirstName";
            dgvFirstName.HeaderText = "First Name";
            dgvFirstName.Name = "dgvFirstName";
            dgvFirstName.Width = 125;
            // 
            // dgvLastName
            // 
            dgvLastName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLastName.DataPropertyName = "LastName";
            dgvLastName.HeaderText = "Last Name";
            dgvLastName.Name = "dgvLastName";
            // 
            // btnClearPatientSearch
            // 
            btnClearPatientSearch.Location = new Point(204, 235);
            btnClearPatientSearch.Name = "btnClearPatientSearch";
            btnClearPatientSearch.Size = new Size(51, 23);
            btnClearPatientSearch.TabIndex = 43;
            btnClearPatientSearch.Text = "Clear";
            btnClearPatientSearch.UseVisualStyleBackColor = true;
            btnClearPatientSearch.Click += btnClearPatientSearch_Click;
            // 
            // btnSearchPatient
            // 
            btnSearchPatient.Location = new Point(142, 236);
            btnSearchPatient.Name = "btnSearchPatient";
            btnSearchPatient.Size = new Size(56, 23);
            btnSearchPatient.TabIndex = 42;
            btnSearchPatient.Text = "Search";
            btnSearchPatient.UseVisualStyleBackColor = true;
            btnSearchPatient.Click += btnSearchPatient_Click;
            // 
            // txtSearchPatient
            // 
            txtSearchPatient.Location = new Point(62, 237);
            txtSearchPatient.Name = "txtSearchPatient";
            txtSearchPatient.PlaceholderText = "Search...";
            txtSearchPatient.Size = new Size(74, 23);
            txtSearchPatient.TabIndex = 41;
            // 
            // flpButtons
            // 
            flpButtons.Controls.Add(btnSave);
            flpButtons.Controls.Add(btnCancel);
            flpButtons.FlowDirection = FlowDirection.RightToLeft;
            flpButtons.Location = new Point(12, 417);
            flpButtons.Name = "flpButtons";
            flpButtons.Size = new Size(529, 27);
            flpButtons.TabIndex = 44;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(451, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(370, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmAppointment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 452);
            Controls.Add(flpButtons);
            Controls.Add(btnClearPatientSearch);
            Controls.Add(btnSearchPatient);
            Controls.Add(txtSearchPatient);
            Controls.Add(btnClearEmployeeSearch);
            Controls.Add(btnSearchEmployee);
            Controls.Add(txtSearchEmployee);
            Controls.Add(dgvEmployees);
            Controls.Add(dgvRoom);
            Controls.Add(dgvPatient);
            Controls.Add(dtpScheduled);
            Controls.Add(txtPurpose);
            Controls.Add(lblRoom);
            Controls.Add(lblPhysician);
            Controls.Add(lblPatient);
            Controls.Add(lblPurpose);
            Controls.Add(lblDateTime);
            Name = "frmAppointment";
            Text = "Appointment Information";
            ((System.ComponentModel.ISupportInitialize)dgvPatient).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            flpButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDateTime;
        private Label lblPurpose;
        private Label lblPatient;
        private Label lblPhysician;
        private Label lblRoom;
        private TextBox txtPurpose;
        private DateTimePicker dtpScheduled;
        private DataGridView dgvPatient;
        private DataGridView dgvRoom;
        private Button btnClearEmployeeSearch;
        private Button btnSearchEmployee;
        private TextBox txtSearchEmployee;
        private DataGridView dgvEmployees;
        private DataGridViewTextBoxColumn dgvEmployeeID;
        private DataGridViewTextBoxColumn dgvFirstName;
        private DataGridViewTextBoxColumn dgvLastName;
        private DataGridViewTextBoxColumn PatientID;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private Button btnClearPatientSearch;
        private Button btnSearchPatient;
        private TextBox txtSearchPatient;
        private FlowLayoutPanel flpButtons;
        private Button btnSave;
        private Button btnCancel;
        private DataGridViewTextBoxColumn RoomID;
        private DataGridViewTextBoxColumn Building;
        private DataGridViewTextBoxColumn RoomType;
    }
}
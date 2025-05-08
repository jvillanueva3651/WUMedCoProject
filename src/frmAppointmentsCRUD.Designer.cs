
namespace WUMedCoProject
{
    partial class frmAppointmentsCRUD
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
            dgvAppointments = new DataGridView();
            btnReturnHome = new Button();
            btnAddNewAppointment = new Button();
            AppointmentID = new DataGridViewTextBoxColumn();
            DateTime = new DataGridViewTextBoxColumn();
            Purpose = new DataGridViewTextBoxColumn();
            PatientName = new DataGridViewTextBoxColumn();
            Physician = new DataGridViewTextBoxColumn();
            RoomType = new DataGridViewTextBoxColumn();
            BtnView = new DataGridViewButtonColumn();
            BtnEdit = new DataGridViewButtonColumn();
            BtnDelete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            SuspendLayout();
            // 
            // dgvAppointments
            // 
            dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointments.Columns.AddRange(new DataGridViewColumn[] { AppointmentID, DateTime, Purpose, PatientName, Physician, RoomType, BtnView, BtnEdit, BtnDelete });
            dgvAppointments.Location = new Point(12, 12);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.Size = new Size(1058, 519);
            dgvAppointments.TabIndex = 0;
            dgvAppointments.CellClick += dgvAppointments_CellClick;
            // 
            // btnReturnHome
            // 
            btnReturnHome.Location = new Point(12, 537);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(160, 27);
            btnReturnHome.TabIndex = 6;
            btnReturnHome.Text = "Return to Home";
            btnReturnHome.UseVisualStyleBackColor = true;
            btnReturnHome.Click += btnReturnHome_Click;
            // 
            // btnAddNewAppointment
            // 
            btnAddNewAppointment.Location = new Point(910, 537);
            btnAddNewAppointment.Name = "btnAddNewAppointment";
            btnAddNewAppointment.Size = new Size(160, 27);
            btnAddNewAppointment.TabIndex = 7;
            btnAddNewAppointment.Text = "Schedule an Appointment";
            btnAddNewAppointment.UseVisualStyleBackColor = true;
            btnAddNewAppointment.Click += btnAddNewAppointment_Click;
            // 
            // AppointmentID
            // 
            AppointmentID.DataPropertyName = "AppointmentID";
            AppointmentID.HeaderText = "AppointmentID";
            AppointmentID.Name = "AppointmentID";
            AppointmentID.ReadOnly = true;
            AppointmentID.Visible = false;
            // 
            // DateTime
            // 
            DateTime.DataPropertyName = "DateTime";
            DateTime.HeaderText = "Scheduled For";
            DateTime.Name = "DateTime";
            DateTime.ReadOnly = true;
            DateTime.Width = 125;
            // 
            // Purpose
            // 
            Purpose.DataPropertyName = "Purpose";
            Purpose.HeaderText = "Purpose";
            Purpose.Name = "Purpose";
            Purpose.ReadOnly = true;
            Purpose.Width = 200;
            // 
            // PatientName
            // 
            PatientName.DataPropertyName = "PatientName";
            PatientName.HeaderText = "Patient";
            PatientName.Name = "PatientName";
            PatientName.ReadOnly = true;
            PatientName.Width = 150;
            // 
            // Physician
            // 
            Physician.DataPropertyName = "Physician";
            Physician.HeaderText = "Physician";
            Physician.Name = "Physician";
            Physician.ReadOnly = true;
            Physician.Width = 150;
            // 
            // RoomType
            // 
            RoomType.DataPropertyName = "RoomType";
            RoomType.HeaderText = "Room";
            RoomType.Name = "RoomType";
            RoomType.ReadOnly = true;
            RoomType.Width = 150;
            // 
            // BtnView
            // 
            BtnView.DataPropertyName = "BtnView";
            BtnView.HeaderText = "";
            BtnView.Name = "BtnView";
            BtnView.ReadOnly = true;
            BtnView.Text = "View";
            BtnView.UseColumnTextForButtonValue = true;
            BtnView.Width = 80;
            // 
            // BtnEdit
            // 
            BtnEdit.DataPropertyName = "BtnEdit";
            BtnEdit.HeaderText = "";
            BtnEdit.Name = "BtnEdit";
            BtnEdit.ReadOnly = true;
            BtnEdit.Text = "Edit";
            BtnEdit.UseColumnTextForButtonValue = true;
            BtnEdit.Width = 80;
            // 
            // BtnDelete
            // 
            BtnDelete.DataPropertyName = "BtnDelete";
            BtnDelete.HeaderText = "";
            BtnDelete.Name = "BtnDelete";
            BtnDelete.ReadOnly = true;
            BtnDelete.Text = "Delete";
            BtnDelete.UseColumnTextForButtonValue = true;
            BtnDelete.Width = 80;
            // 
            // frmAppointmentsCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 569);
            Controls.Add(btnAddNewAppointment);
            Controls.Add(btnReturnHome);
            Controls.Add(dgvAppointments);
            Name = "frmAppointmentsCRUD";
            Text = "frmAppointmentsCRUD";
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAppointments;
        private Button btnReturnHome;
        private Button btnAddNewAppointment;
        private DataGridViewTextBoxColumn AppointmentID;
        private DataGridViewTextBoxColumn DateTime;
        private DataGridViewTextBoxColumn Purpose;
        private DataGridViewTextBoxColumn PatientName;
        private DataGridViewTextBoxColumn Physician;
        private DataGridViewTextBoxColumn RoomType;
        private DataGridViewButtonColumn BtnView;
        private DataGridViewButtonColumn BtnEdit;
        private DataGridViewButtonColumn BtnDelete;
    }
}
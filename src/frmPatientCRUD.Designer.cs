namespace WUMedCoProject.src
{
    partial class frmPatientCRUD
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
            dgvPatients = new DataGridView();
            btnAddPatient = new Button();
            PatientID = new DataGridViewTextBoxColumn();
            dgvPatientName = new DataGridViewTextBoxColumn();
            dgvDoB = new DataGridViewTextBoxColumn();
            dgvSex = new DataGridViewTextBoxColumn();
            dgvSSN = new DataGridViewTextBoxColumn();
            dgvPhone = new DataGridViewTextBoxColumn();
            dgvEmail = new DataGridViewTextBoxColumn();
            dgvBtnView = new DataGridViewButtonColumn();
            dgvBtnEdit = new DataGridViewButtonColumn();
            dgvBtnDelete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Columns.AddRange(new DataGridViewColumn[] { PatientID, dgvPatientName, dgvDoB, dgvSex, dgvSSN, dgvPhone, dgvEmail, dgvBtnView, dgvBtnEdit, dgvBtnDelete });
            dgvPatients.Location = new Point(37, 23);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.Size = new Size(1143, 550);
            dgvPatients.TabIndex = 0;
            dgvPatients.CellClick += dgvPatients_CellClick;
            // 
            // btnAddPatient
            // 
            btnAddPatient.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddPatient.Location = new Point(518, 606);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Size = new Size(182, 41);
            btnAddPatient.TabIndex = 1;
            btnAddPatient.Text = "Add a patient";
            btnAddPatient.UseVisualStyleBackColor = true;
            btnAddPatient.Click += btnAddPatient_Click;
            // 
            // PatientID
            // 
            PatientID.HeaderText = "PatientID";
            PatientID.Name = "PatientID";
            PatientID.ReadOnly = true;
            // 
            // dgvPatientName
            // 
            dgvPatientName.DataPropertyName = "FullName";
            dgvPatientName.HeaderText = "Name";
            dgvPatientName.Name = "dgvPatientName";
            dgvPatientName.Width = 250;
            // 
            // dgvDoB
            // 
            dgvDoB.DataPropertyName = "DoB";
            dgvDoB.HeaderText = "Date of Birth";
            dgvDoB.Name = "dgvDoB";
            // 
            // dgvSex
            // 
            dgvSex.DataPropertyName = "Sex";
            dgvSex.HeaderText = "Sex";
            dgvSex.Name = "dgvSex";
            dgvSex.Width = 50;
            // 
            // dgvSSN
            // 
            dgvSSN.DataPropertyName = "SSN";
            dgvSSN.HeaderText = "SSN";
            dgvSSN.Name = "dgvSSN";
            // 
            // dgvPhone
            // 
            dgvPhone.DataPropertyName = "PhoneNumber";
            dgvPhone.HeaderText = "Phone #";
            dgvPhone.Name = "dgvPhone";
            // 
            // dgvEmail
            // 
            dgvEmail.DataPropertyName = "Email";
            dgvEmail.HeaderText = "Email";
            dgvEmail.Name = "dgvEmail";
            dgvEmail.Width = 200;
            // 
            // dgvBtnView
            // 
            dgvBtnView.HeaderText = "";
            dgvBtnView.Name = "dgvBtnView";
            dgvBtnView.Text = "View";
            dgvBtnView.UseColumnTextForButtonValue = true;
            // 
            // dgvBtnEdit
            // 
            dgvBtnEdit.HeaderText = "";
            dgvBtnEdit.Name = "dgvBtnEdit";
            dgvBtnEdit.Text = "Edit";
            dgvBtnEdit.UseColumnTextForButtonValue = true;
            // 
            // dgvBtnDelete
            // 
            dgvBtnDelete.HeaderText = "";
            dgvBtnDelete.Name = "dgvBtnDelete";
            dgvBtnDelete.Text = "Delete";
            dgvBtnDelete.UseColumnTextForButtonValue = true;
            // 
            // frmPatientCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1218, 686);
            Controls.Add(btnAddPatient);
            Controls.Add(dgvPatients);
            Name = "frmPatientCRUD";
            Text = "frmPatientCRUD";
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPatients;
        private Button btnAddPatient;
        private DataGridViewTextBoxColumn PatientID;
        private DataGridViewTextBoxColumn dgvPatientName;
        private DataGridViewTextBoxColumn dgvDoB;
        private DataGridViewTextBoxColumn dgvSex;
        private DataGridViewTextBoxColumn dgvSSN;
        private DataGridViewTextBoxColumn dgvPhone;
        private DataGridViewTextBoxColumn dgvEmail;
        private DataGridViewButtonColumn dgvBtnView;
        private DataGridViewButtonColumn dgvBtnEdit;
        private DataGridViewButtonColumn dgvBtnDelete;
    }
}
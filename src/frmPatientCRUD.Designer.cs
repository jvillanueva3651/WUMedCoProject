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
            dgvPatientName = new DataGridViewTextBoxColumn();
            dgvDoB = new DataGridViewTextBoxColumn();
            dgvSex = new DataGridViewTextBoxColumn();
            dgvSSN = new DataGridViewTextBoxColumn();
            dgvPhone = new DataGridViewTextBoxColumn();
            dgvEmail = new DataGridViewTextBoxColumn();
            dgvBtnView = new DataGridViewButtonColumn();
            dgvBtnEdit = new DataGridViewButtonColumn();
            dgvBtnDelete = new DataGridViewButtonColumn();
            btnAddPatient = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Columns.AddRange(new DataGridViewColumn[] { dgvPatientName, dgvDoB, dgvSex, dgvSSN, dgvPhone, dgvEmail, dgvBtnView, dgvBtnEdit, dgvBtnDelete });
            dgvPatients.Location = new Point(37, 23);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.Size = new Size(1143, 550);
            dgvPatients.TabIndex = 0;
            // 
            // dgvPatientName
            // 
            dgvPatientName.HeaderText = "Name";
            dgvPatientName.Name = "dgvPatientName";
            dgvPatientName.Width = 250;
            // 
            // dgvDoB
            // 
            dgvDoB.HeaderText = "Date of Birth";
            dgvDoB.Name = "dgvDoB";
            // 
            // dgvSex
            // 
            dgvSex.HeaderText = "Sex";
            dgvSex.Name = "dgvSex";
            dgvSex.Width = 50;
            // 
            // dgvSSN
            // 
            dgvSSN.HeaderText = "SSN";
            dgvSSN.Name = "dgvSSN";
            // 
            // dgvPhone
            // 
            dgvPhone.HeaderText = "Phone #";
            dgvPhone.Name = "dgvPhone";
            // 
            // dgvEmail
            // 
            dgvEmail.HeaderText = "Email";
            dgvEmail.Name = "dgvEmail";
            dgvEmail.Width = 200;
            // 
            // dgvBtnView
            // 
            dgvBtnView.HeaderText = "";
            dgvBtnView.Name = "dgvBtnView";
            dgvBtnView.Text = "View";
            // 
            // dgvBtnEdit
            // 
            dgvBtnEdit.HeaderText = "";
            dgvBtnEdit.Name = "dgvBtnEdit";
            dgvBtnEdit.Text = "Edit";
            // 
            // dgvBtnDelete
            // 
            dgvBtnDelete.HeaderText = "";
            dgvBtnDelete.Name = "dgvBtnDelete";
            dgvBtnDelete.Text = "Delete";
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
        private DataGridViewTextBoxColumn dgvPatientName;
        private DataGridViewTextBoxColumn dgvDoB;
        private DataGridViewTextBoxColumn dgvSex;
        private DataGridViewTextBoxColumn dgvSSN;
        private DataGridViewTextBoxColumn dgvPhone;
        private DataGridViewTextBoxColumn dgvEmail;
        private DataGridViewButtonColumn dgvBtnView;
        private DataGridViewButtonColumn dgvBtnEdit;
        private DataGridViewButtonColumn dgvBtnDelete;
        private Button btnAddPatient;
    }
}
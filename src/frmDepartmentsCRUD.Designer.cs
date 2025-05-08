namespace WUMedCoProject
{
    partial class frmDepartmentsCRUD
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
            dgvDepartments = new DataGridView();
            btnAddNewDepartment = new Button();
            btnReturnHome = new Button();
            dgvDepartmentID = new DataGridViewTextBoxColumn();
            dgvDepartmentName = new DataGridViewTextBoxColumn();
            dgvHeadOfDepartment = new DataGridViewTextBoxColumn();
            BtnView = new DataGridViewButtonColumn();
            BtnEdit = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvDepartments).BeginInit();
            SuspendLayout();
            // 
            // dgvDepartments
            // 
            dgvDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDepartments.Columns.AddRange(new DataGridViewColumn[] { dgvDepartmentID, dgvDepartmentName, dgvHeadOfDepartment, BtnView, BtnEdit });
            dgvDepartments.Location = new Point(12, 12);
            dgvDepartments.Name = "dgvDepartments";
            dgvDepartments.Size = new Size(707, 393);
            dgvDepartments.TabIndex = 0;
            dgvDepartments.CellClick += dgvDepartments_CellClick;
            // 
            // btnAddNewDepartment
            // 
            btnAddNewDepartment.Location = new Point(559, 411);
            btnAddNewDepartment.Name = "btnAddNewDepartment";
            btnAddNewDepartment.Size = new Size(160, 27);
            btnAddNewDepartment.TabIndex = 1;
            btnAddNewDepartment.Text = "Add New Department";
            btnAddNewDepartment.UseVisualStyleBackColor = true;
            btnAddNewDepartment.Click += btnAddNewDepartment_Click;
            // 
            // btnReturnHome
            // 
            btnReturnHome.Location = new Point(12, 411);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(160, 27);
            btnReturnHome.TabIndex = 2;
            btnReturnHome.Text = "Return to Home";
            btnReturnHome.UseVisualStyleBackColor = true;
            btnReturnHome.Click += btnReturnHome_Click;
            // 
            // dgvDepartmentID
            // 
            dgvDepartmentID.DataPropertyName = "DepartmentID";
            dgvDepartmentID.HeaderText = "DepartmentID";
            dgvDepartmentID.Name = "DepartmentID";
            dgvDepartmentID.ReadOnly = true;
            dgvDepartmentID.Visible = false;
            // 
            // dgvDepartmentName
            // 
            dgvDepartmentName.DataPropertyName = "DepartmentName";
            dgvDepartmentName.HeaderText = "Department";
            dgvDepartmentName.Name = "DepartmentName";
            dgvDepartmentName.ReadOnly = true;
            dgvDepartmentName.Width = 254;
            // 
            // dgvHeadOfDepartment
            // 
            dgvHeadOfDepartment.DataPropertyName = "HeadOfDepartment";
            dgvHeadOfDepartment.HeaderText = "Department Head";
            dgvHeadOfDepartment.Name = "HeadOfDepartment";
            dgvHeadOfDepartment.ReadOnly = true;
            dgvHeadOfDepartment.Width = 250;
            // 
            // BtnView
            // 
            BtnView.DataPropertyName = "BtnView";
            BtnView.HeaderText = "";
            BtnView.Name = "BtnView";
            BtnView.Text = "View";
            BtnView.UseColumnTextForButtonValue = true;
            BtnView.Width = 80;
            // 
            // BtnEdit
            // 
            BtnEdit.DataPropertyName = "BtnEdit";
            BtnEdit.HeaderText = "";
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Text = "Edit";
            BtnEdit.UseColumnTextForButtonValue = true;
            BtnEdit.Width = 80;
            // 
            // frmDepartmentsCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 450);
            Controls.Add(btnReturnHome);
            Controls.Add(btnAddNewDepartment);
            Controls.Add(dgvDepartments);
            Name = "frmDepartmentsCRUD";
            Text = "frmDepartmentsCRUD";
            ((System.ComponentModel.ISupportInitialize)dgvDepartments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDepartments;
        private Button btnAddNewDepartment;
        private Button btnReturnHome;
        private DataGridViewTextBoxColumn dgvDepartmentID;
        private DataGridViewTextBoxColumn dgvDepartmentName;
        private DataGridViewTextBoxColumn dgvHeadOfDepartment;
        private DataGridViewButtonColumn BtnView;
        private DataGridViewButtonColumn BtnEdit;
    }
}
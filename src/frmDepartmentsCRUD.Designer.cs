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
            dgvDepartmentID = new DataGridViewTextBoxColumn();
            dgvDepartmentName = new DataGridViewTextBoxColumn();
            dgvHeadOfDepartment = new DataGridViewTextBoxColumn();
            dgvBtnEdit = new DataGridViewButtonColumn();
            dgvBtnDelete = new DataGridViewButtonColumn();
            btnAddNewDepartment = new Button();
            btnReturnHome = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDepartments).BeginInit();
            SuspendLayout();
            // 
            // dgvDepartments
            // 
            dgvDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDepartments.Columns.AddRange(new DataGridViewColumn[] { dgvDepartmentID, dgvDepartmentName, dgvHeadOfDepartment, dgvBtnEdit, dgvBtnDelete });
            dgvDepartments.Location = new Point(12, 12);
            dgvDepartments.Name = "dgvDepartments";
            dgvDepartments.Size = new Size(776, 393);
            dgvDepartments.TabIndex = 0;
            dgvDepartments.CellClick += dgvDepartments_CellClick;
            // 
            // dgvDepartmentID
            // 
            dgvDepartmentID.DataPropertyName = "dgvDepartmentID";
            dgvDepartmentID.HeaderText = "DepartmentID";
            dgvDepartmentID.Name = "dgvDepartmentID";
            dgvDepartmentID.ReadOnly = true;
            // 
            // dgvDepartmentName
            // 
            dgvDepartmentName.DataPropertyName = "dgvDepartmentName";
            dgvDepartmentName.HeaderText = "Department";
            dgvDepartmentName.Name = "dgvDepartmentName";
            dgvDepartmentName.ReadOnly = true;
            dgvDepartmentName.Width = 254;
            // 
            // dgvHeadOfDepartment
            // 
            dgvHeadOfDepartment.DataPropertyName = "dgvHeadOfDepartment";
            dgvHeadOfDepartment.HeaderText = "Department Head";
            dgvHeadOfDepartment.Name = "dgvHeadOfDepartment";
            dgvHeadOfDepartment.ReadOnly = true;
            dgvHeadOfDepartment.Width = 250;
            // 
            // dgvBtnEdit
            // 
            dgvBtnEdit.DataPropertyName = "dgvBtnEdit";
            dgvBtnEdit.HeaderText = "";
            dgvBtnEdit.Name = "dgvBtnEdit";
            dgvBtnEdit.UseColumnTextForButtonValue = true;
            dgvBtnEdit.Width = 65;
            // 
            // dgvBtnDelete
            // 
            dgvBtnDelete.DataPropertyName = "dgvButtonDelete";
            dgvBtnDelete.HeaderText = "";
            dgvBtnDelete.Name = "dgvBtnDelete";
            dgvBtnDelete.UseColumnTextForButtonValue = true;
            dgvBtnDelete.Width = 65;
            // 
            // btnAddNewDepartment
            // 
            btnAddNewDepartment.Location = new Point(628, 411);
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
            // frmDepartmentsCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
        private DataGridViewButtonColumn dgvBtnEdit;
        private DataGridViewButtonColumn dgvBtnDelete;
    }
}

namespace WUMedCoProject.src
{
    partial class frmDepartment
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
            btnExit = new Button();
            btnSave = new Button();
            lblDepartmentName = new Label();
            lblHeadOfDepartment = new Label();
            txtDepartmentName = new TextBox();
            txtSearch = new TextBox();
            dgvEmployees = new DataGridView();
            dgvEmployeeID = new DataGridViewTextBoxColumn();
            dgvFirstName = new DataGridViewTextBoxColumn();
            dgvLastName = new DataGridViewTextBoxColumn();
            btnSearch = new Button();
            btnClearSearch = new Button();
            btnClearSelection = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(12, 407);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(83, 31);
            btnExit.TabIndex = 0;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(252, 407);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(83, 31);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblDepartmentName
            // 
            lblDepartmentName.AutoSize = true;
            lblDepartmentName.Location = new Point(12, 9);
            lblDepartmentName.Name = "lblDepartmentName";
            lblDepartmentName.Size = new Size(105, 15);
            lblDepartmentName.TabIndex = 2;
            lblDepartmentName.Text = "Department Name";
            // 
            // lblHeadOfDepartment
            // 
            lblHeadOfDepartment.AutoSize = true;
            lblHeadOfDepartment.Location = new Point(12, 84);
            lblHeadOfDepartment.Name = "lblHeadOfDepartment";
            lblHeadOfDepartment.Size = new Size(115, 15);
            lblHeadOfDepartment.TabIndex = 3;
            lblHeadOfDepartment.Text = "Head of Department";
            // 
            // txtDepartmentName
            // 
            txtDepartmentName.Location = new Point(12, 27);
            txtDepartmentName.Name = "txtDepartmentName";
            txtDepartmentName.Size = new Size(276, 23);
            txtDepartmentName.TabIndex = 4;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 123);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search...";
            txtSearch.Size = new Size(155, 23);
            txtSearch.TabIndex = 5;
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { dgvEmployeeID, dgvFirstName, dgvLastName });
            dgvEmployees.Location = new Point(12, 150);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.Size = new Size(323, 249);
            dgvEmployees.TabIndex = 6;
            // 
            // dgvEmployeeID
            // 
            dgvEmployeeID.DataPropertyName = "EmployeeID";
            dgvEmployeeID.HeaderText = "Employee ID";
            dgvEmployeeID.Name = "dgvEmployeeID";
            dgvEmployeeID.Width = 80;
            // 
            // dgvFirstName
            // 
            dgvFirstName.DataPropertyName = "FirstName";
            dgvFirstName.HeaderText = "First Name";
            dgvFirstName.Name = "dgvFirstName";
            // 
            // dgvLastName
            // 
            dgvLastName.DataPropertyName = "LastName";
            dgvLastName.HeaderText = "Last Name";
            dgvLastName.Name = "dgvLastName";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(173, 123);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 21);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Location = new Point(229, 123);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(50, 21);
            btnClearSearch.TabIndex = 8;
            btnClearSearch.Text = "Clear";
            btnClearSearch.UseVisualStyleBackColor = true;
            btnClearSearch.Click += btnClearSearch_Click;
            // 
            // btnClearSelection
            // 
            btnClearSelection.Location = new Point(133, 80);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(155, 23);
            btnClearSelection.TabIndex = 9;
            btnClearSelection.Text = "Clear Department Head";
            btnClearSelection.UseVisualStyleBackColor = true;
            btnClearSelection.Click += btnClearSelection_Click;
            // 
            // frmDepartment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 450);
            Controls.Add(btnClearSelection);
            Controls.Add(btnClearSearch);
            Controls.Add(btnSearch);
            Controls.Add(dgvEmployees);
            Controls.Add(txtSearch);
            Controls.Add(txtDepartmentName);
            Controls.Add(lblHeadOfDepartment);
            Controls.Add(lblDepartmentName);
            Controls.Add(btnSave);
            Controls.Add(btnExit);
            Name = "frmDepartment";
            Text = "Department";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private Button btnSave;
        private Label lblDepartmentName;
        private Label lblHeadOfDepartment;
        private TextBox txtDepartmentName;
        private TextBox txtSearch;
        private DataGridView dgvEmployees;
        private Button btnSearch;
        private Button btnClearSearch;
        private Button btnClearSelection;
        private DataGridViewTextBoxColumn dgvEmployeeID;
        private DataGridViewTextBoxColumn dgvFirstName;
        private DataGridViewTextBoxColumn dgvLastName;
    }
}
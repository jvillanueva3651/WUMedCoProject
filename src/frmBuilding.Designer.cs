namespace WUMedCoProject.src
{
    partial class frmBuilding
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
            txtZip = new TextBox();
            lblZip = new Label();
            cboxState = new ComboBox();
            lblState = new Label();
            txtCity = new TextBox();
            lblCity = new Label();
            txtApt = new TextBox();
            lblApt = new Label();
            txtStreet = new TextBox();
            lblStreet = new Label();
            btnSave = new Button();
            btnExit = new Button();
            btnClearSelection = new Button();
            btnClearSearch = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dgvEmployees = new DataGridView();
            dgvEmployeeID = new DataGridViewTextBoxColumn();
            dgvFirstName = new DataGridViewTextBoxColumn();
            dgvLastName = new DataGridViewTextBoxColumn();
            txtName = new TextBox();
            dtpDateOpened = new DateTimePicker();
            txtAssignedFunction = new TextBox();
            lblName = new Label();
            lblDirector = new Label();
            lblAssignedFunction = new Label();
            lblDateOpened = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // txtZip
            // 
            txtZip.Location = new Point(218, 486);
            txtZip.Name = "txtZip";
            txtZip.Size = new Size(119, 23);
            txtZip.TabIndex = 49;
            // 
            // lblZip
            // 
            lblZip.AutoSize = true;
            lblZip.Location = new Point(218, 468);
            lblZip.Name = "lblZip";
            lblZip.Size = new Size(92, 15);
            lblZip.TabIndex = 48;
            lblZip.Text = "Zip/Postal Code";
            // 
            // cboxState
            // 
            cboxState.FormattingEnabled = true;
            cboxState.Location = new Point(143, 486);
            cboxState.Name = "cboxState";
            cboxState.Size = new Size(69, 23);
            cboxState.TabIndex = 47;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Location = new Point(143, 468);
            lblState.Name = "lblState";
            lblState.Size = new Size(33, 15);
            lblState.TabIndex = 46;
            lblState.Text = "State";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(12, 486);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(125, 23);
            txtCity.TabIndex = 45;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(12, 468);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(28, 15);
            lblCity.TabIndex = 44;
            lblCity.Text = "City";
            // 
            // txtApt
            // 
            txtApt.Location = new Point(343, 432);
            txtApt.Name = "txtApt";
            txtApt.Size = new Size(105, 23);
            txtApt.TabIndex = 43;
            // 
            // lblApt
            // 
            lblApt.AutoSize = true;
            lblApt.Location = new Point(343, 414);
            lblApt.Name = "lblApt";
            lblApt.Size = new Size(105, 15);
            lblApt.TabIndex = 42;
            lblApt.Text = "Apartment/Suite #";
            // 
            // txtStreet
            // 
            txtStreet.Location = new Point(12, 432);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(325, 23);
            txtStreet.TabIndex = 41;
            // 
            // lblStreet
            // 
            lblStreet.AutoSize = true;
            lblStreet.Location = new Point(12, 414);
            lblStreet.Name = "lblStreet";
            lblStreet.Size = new Size(82, 15);
            lblStreet.TabIndex = 40;
            lblStreet.Text = "Street Address";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(384, 530);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(83, 31);
            btnSave.TabIndex = 39;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(12, 530);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(83, 31);
            btnExit.TabIndex = 38;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnClearSelection
            // 
            btnClearSelection.Location = new Point(294, 77);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(155, 23);
            btnClearSelection.TabIndex = 37;
            btnClearSelection.Text = "Clear Building Director";
            btnClearSelection.UseVisualStyleBackColor = true;
            btnClearSelection.Click += btnClearSelection_Click;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Location = new Point(284, 106);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(50, 21);
            btnClearSearch.TabIndex = 36;
            btnClearSearch.Text = "Clear";
            btnClearSearch.UseVisualStyleBackColor = true;
            btnClearSearch.Click += btnClearSearch_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(228, 106);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 21);
            btnSearch.TabIndex = 35;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(67, 106);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search...";
            txtSearch.Size = new Size(155, 23);
            txtSearch.TabIndex = 34;
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { dgvEmployeeID, dgvFirstName, dgvLastName });
            dgvEmployees.Location = new Point(12, 131);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.Size = new Size(453, 249);
            dgvEmployees.TabIndex = 33;
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
            dgvFirstName.Width = 165;
            // 
            // dgvLastName
            // 
            dgvLastName.DataPropertyName = "LastName";
            dgvLastName.HeaderText = "Last Name";
            dgvLastName.Name = "dgvLastName";
            dgvLastName.Width = 165;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 28);
            txtName.Name = "txtName";
            txtName.Size = new Size(243, 23);
            txtName.TabIndex = 32;
            // 
            // dtpDateOpened
            // 
            dtpDateOpened.Location = new Point(278, 28);
            dtpDateOpened.Name = "dtpDateOpened";
            dtpDateOpened.Size = new Size(189, 23);
            dtpDateOpened.TabIndex = 31;
            // 
            // txtAssignedFunction
            // 
            txtAssignedFunction.Location = new Point(12, 77);
            txtAssignedFunction.Name = "txtAssignedFunction";
            txtAssignedFunction.Size = new Size(243, 23);
            txtAssignedFunction.TabIndex = 30;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 10);
            lblName.Name = "lblName";
            lblName.Size = new Size(86, 15);
            lblName.TabIndex = 29;
            lblName.Text = "Building Name";
            // 
            // lblDirector
            // 
            lblDirector.AutoSize = true;
            lblDirector.Location = new Point(12, 112);
            lblDirector.Name = "lblDirector";
            lblDirector.Size = new Size(49, 15);
            lblDirector.TabIndex = 28;
            lblDirector.Text = "Director";
            // 
            // lblAssignedFunction
            // 
            lblAssignedFunction.AutoSize = true;
            lblAssignedFunction.Location = new Point(12, 59);
            lblAssignedFunction.Name = "lblAssignedFunction";
            lblAssignedFunction.Size = new Size(105, 15);
            lblAssignedFunction.TabIndex = 27;
            lblAssignedFunction.Text = "Assigned Function";
            // 
            // lblDateOpened
            // 
            lblDateOpened.AutoSize = true;
            lblDateOpened.Location = new Point(278, 10);
            lblDateOpened.Name = "lblDateOpened";
            lblDateOpened.Size = new Size(76, 15);
            lblDateOpened.TabIndex = 26;
            lblDateOpened.Text = "Date Opened";
            // 
            // frmBuilding
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 575);
            Controls.Add(txtZip);
            Controls.Add(lblZip);
            Controls.Add(cboxState);
            Controls.Add(lblState);
            Controls.Add(txtCity);
            Controls.Add(lblCity);
            Controls.Add(txtApt);
            Controls.Add(lblApt);
            Controls.Add(txtStreet);
            Controls.Add(lblStreet);
            Controls.Add(btnSave);
            Controls.Add(btnExit);
            Controls.Add(btnClearSelection);
            Controls.Add(btnClearSearch);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvEmployees);
            Controls.Add(txtName);
            Controls.Add(dtpDateOpened);
            Controls.Add(txtAssignedFunction);
            Controls.Add(lblName);
            Controls.Add(lblDirector);
            Controls.Add(lblAssignedFunction);
            Controls.Add(lblDateOpened);
            Name = "frmBuilding";
            Text = "frmBuilding";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtZip;
        private Label lblZip;
        private ComboBox cboxState;
        private Label lblState;
        private TextBox txtCity;
        private Label lblCity;
        private TextBox txtApt;
        private Label lblApt;
        private TextBox txtStreet;
        private Label lblStreet;
        private Button btnSave;
        private Button btnExit;
        private Button btnClearSelection;
        private Button btnClearSearch;
        private Button btnSearch;
        private TextBox txtSearch;
        private DataGridView dgvEmployees;
        private TextBox txtName;
        private DateTimePicker dtpDateOpened;
        private TextBox txtAssignedFunction;
        private Label lblName;
        private Label lblDirector;
        private Label lblAssignedFunction;
        private Label lblDateOpened;
        private DataGridViewTextBoxColumn dgvEmployeeID;
        private DataGridViewTextBoxColumn dgvFirstName;
        private DataGridViewTextBoxColumn dgvLastName;
    }
}
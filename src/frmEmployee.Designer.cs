namespace WUMedCoProject.src
{
    partial class frmEmployee
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
            tlpMainLayout = new TableLayoutPanel();
            gbEmployeeDetails = new GroupBox();
            chkbxEmployed = new CheckBox();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            txtOfficeNumber = new TextBox();
            txtPayRate = new TextBox();
            lblOfficeNumber = new Label();
            lblEndDate = new Label();
            lblStartDate = new Label();
            lblPayRate = new Label();
            imgEmployeeProfilePic = new PictureBox();
            txtPosition = new TextBox();
            lblPosition = new Label();
            txtExt = new TextBox();
            lblExtension = new Label();
            txtSSN = new TextBox();
            lblSSN = new Label();
            txtEmployeeID = new TextBox();
            lblEmployeeID = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblDOB = new Label();
            txtLastname = new TextBox();
            lblLastName = new Label();
            txtFirstname = new TextBox();
            lblFirstname = new Label();
            gbAddress = new GroupBox();
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
            gbDepartment = new GroupBox();
            btnClearDeptSearch = new Button();
            btnDeptSearch = new Button();
            txtDeptSearch = new TextBox();
            lblDeptSearch = new Label();
            dgvDepartment = new DataGridView();
            gbBuilding = new GroupBox();
            btnClearBuildingSearch = new Button();
            btnBuildingSearch = new Button();
            txtBuildingSearch = new TextBox();
            lblBuildingSearch = new Label();
            dgvBuilding = new DataGridView();
            flpButtons = new FlowLayoutPanel();
            btnSave = new Button();
            btnExit = new Button();
            tlpMainLayout.SuspendLayout();
            gbEmployeeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgEmployeeProfilePic).BeginInit();
            gbAddress.SuspendLayout();
            gbDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDepartment).BeginInit();
            gbBuilding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBuilding).BeginInit();
            flpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMainLayout
            // 
            tlpMainLayout.ColumnCount = 1;
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMainLayout.Controls.Add(gbEmployeeDetails, 0, 0);
            tlpMainLayout.Controls.Add(gbAddress, 0, 1);
            tlpMainLayout.Controls.Add(gbDepartment, 0, 2);
            tlpMainLayout.Controls.Add(gbBuilding, 0, 3);
            tlpMainLayout.Controls.Add(flpButtons, 0, 4);
            tlpMainLayout.Dock = DockStyle.Fill;
            tlpMainLayout.Location = new Point(0, 0);
            tlpMainLayout.Name = "tlpMainLayout";
            tlpMainLayout.RowCount = 5;
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpMainLayout.Size = new Size(701, 968);
            tlpMainLayout.TabIndex = 0;
            // 
            // gbEmployeeDetails
            // 
            gbEmployeeDetails.Controls.Add(chkbxEmployed);
            gbEmployeeDetails.Controls.Add(dtpEndDate);
            gbEmployeeDetails.Controls.Add(dtpStartDate);
            gbEmployeeDetails.Controls.Add(txtOfficeNumber);
            gbEmployeeDetails.Controls.Add(txtPayRate);
            gbEmployeeDetails.Controls.Add(lblOfficeNumber);
            gbEmployeeDetails.Controls.Add(lblEndDate);
            gbEmployeeDetails.Controls.Add(lblStartDate);
            gbEmployeeDetails.Controls.Add(lblPayRate);
            gbEmployeeDetails.Controls.Add(imgEmployeeProfilePic);
            gbEmployeeDetails.Controls.Add(txtPosition);
            gbEmployeeDetails.Controls.Add(lblPosition);
            gbEmployeeDetails.Controls.Add(txtExt);
            gbEmployeeDetails.Controls.Add(lblExtension);
            gbEmployeeDetails.Controls.Add(txtSSN);
            gbEmployeeDetails.Controls.Add(lblSSN);
            gbEmployeeDetails.Controls.Add(txtEmployeeID);
            gbEmployeeDetails.Controls.Add(lblEmployeeID);
            gbEmployeeDetails.Controls.Add(dtpDateOfBirth);
            gbEmployeeDetails.Controls.Add(lblDOB);
            gbEmployeeDetails.Controls.Add(txtLastname);
            gbEmployeeDetails.Controls.Add(lblLastName);
            gbEmployeeDetails.Controls.Add(txtFirstname);
            gbEmployeeDetails.Controls.Add(lblFirstname);
            gbEmployeeDetails.Dock = DockStyle.Fill;
            gbEmployeeDetails.Location = new Point(3, 3);
            gbEmployeeDetails.Name = "gbEmployeeDetails";
            gbEmployeeDetails.Size = new Size(695, 351);
            gbEmployeeDetails.TabIndex = 0;
            gbEmployeeDetails.TabStop = false;
            gbEmployeeDetails.Text = "Employee Details";
            // 
            // chkbxEmployed
            // 
            chkbxEmployed.AutoSize = true;
            chkbxEmployed.Location = new Point(249, 312);
            chkbxEmployed.Name = "chkbxEmployed";
            chkbxEmployed.Size = new Size(131, 19);
            chkbxEmployed.TabIndex = 38;
            chkbxEmployed.Text = "Currently Employed";
            chkbxEmployed.UseVisualStyleBackColor = true;
            chkbxEmployed.CheckedChanged += chkbxEmployed_CheckedChanged;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(6, 312);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 37;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(212, 247);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 36;
            // 
            // txtOfficeNumber
            // 
            txtOfficeNumber.Location = new Point(94, 247);
            txtOfficeNumber.Name = "txtOfficeNumber";
            txtOfficeNumber.Size = new Size(100, 23);
            txtOfficeNumber.TabIndex = 35;
            // 
            // txtPayRate
            // 
            txtPayRate.Location = new Point(280, 183);
            txtPayRate.Name = "txtPayRate";
            txtPayRate.Size = new Size(100, 23);
            txtPayRate.TabIndex = 34;
            // 
            // lblOfficeNumber
            // 
            lblOfficeNumber.AutoSize = true;
            lblOfficeNumber.Location = new Point(94, 229);
            lblOfficeNumber.Name = "lblOfficeNumber";
            lblOfficeNumber.Size = new Size(86, 15);
            lblOfficeNumber.TabIndex = 33;
            lblOfficeNumber.Text = "Office Number";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(6, 294);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(54, 15);
            lblEndDate.TabIndex = 32;
            lblEndDate.Text = "End Date";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(212, 229);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(58, 15);
            lblStartDate.TabIndex = 31;
            lblStartDate.Text = "Start Date";
            // 
            // lblPayRate
            // 
            lblPayRate.AutoSize = true;
            lblPayRate.Location = new Point(279, 165);
            lblPayRate.Name = "lblPayRate";
            lblPayRate.Size = new Size(52, 15);
            lblPayRate.TabIndex = 30;
            lblPayRate.Text = "Pay Rate";
            // 
            // imgEmployeeProfilePic
            // 
            imgEmployeeProfilePic.BorderStyle = BorderStyle.Fixed3D;
            imgEmployeeProfilePic.Location = new Point(465, 152);
            imgEmployeeProfilePic.Name = "imgEmployeeProfilePic";
            imgEmployeeProfilePic.Size = new Size(181, 157);
            imgEmployeeProfilePic.TabIndex = 29;
            imgEmployeeProfilePic.TabStop = false;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(6, 183);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(268, 23);
            txtPosition.TabIndex = 28;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(6, 165);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(50, 15);
            lblPosition.TabIndex = 27;
            lblPosition.Text = "Position";
            // 
            // txtExt
            // 
            txtExt.Location = new Point(6, 247);
            txtExt.Name = "txtExt";
            txtExt.Size = new Size(82, 23);
            txtExt.TabIndex = 26;
            // 
            // lblExtension
            // 
            lblExtension.AutoSize = true;
            lblExtension.Location = new Point(6, 229);
            lblExtension.Name = "lblExtension";
            lblExtension.Size = new Size(58, 15);
            lblExtension.TabIndex = 25;
            lblExtension.Text = "Extension";
            // 
            // txtSSN
            // 
            txtSSN.Location = new Point(212, 114);
            txtSSN.Name = "txtSSN";
            txtSSN.Size = new Size(119, 23);
            txtSSN.TabIndex = 24;
            // 
            // lblSSN
            // 
            lblSSN.AutoSize = true;
            lblSSN.Location = new Point(212, 96);
            lblSSN.Name = "lblSSN";
            lblSSN.Size = new Size(28, 15);
            lblSSN.TabIndex = 23;
            lblSSN.Text = "SSN";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(484, 48);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.ReadOnly = true;
            txtEmployeeID.Size = new Size(101, 23);
            txtEmployeeID.TabIndex = 22;
            // 
            // lblEmployeeID
            // 
            lblEmployeeID.AutoSize = true;
            lblEmployeeID.Location = new Point(484, 30);
            lblEmployeeID.Name = "lblEmployeeID";
            lblEmployeeID.Size = new Size(70, 15);
            lblEmployeeID.TabIndex = 21;
            lblEmployeeID.Text = "EmployeeID";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new Point(6, 114);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(200, 23);
            dtpDateOfBirth.TabIndex = 20;
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(6, 96);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(73, 15);
            lblDOB.TabIndex = 19;
            lblDOB.Text = "Date of Birth";
            // 
            // txtLastname
            // 
            txtLastname.Location = new Point(233, 48);
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new Size(245, 23);
            txtLastname.TabIndex = 18;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(233, 30);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(63, 15);
            lblLastName.TabIndex = 17;
            lblLastName.Text = "Last Name";
            // 
            // txtFirstname
            // 
            txtFirstname.Location = new Point(6, 48);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(221, 23);
            txtFirstname.TabIndex = 16;
            // 
            // lblFirstname
            // 
            lblFirstname.AutoSize = true;
            lblFirstname.Location = new Point(6, 30);
            lblFirstname.Name = "lblFirstname";
            lblFirstname.Size = new Size(64, 15);
            lblFirstname.TabIndex = 15;
            lblFirstname.Text = "First Name";
            // 
            // gbAddress
            // 
            gbAddress.Controls.Add(txtZip);
            gbAddress.Controls.Add(lblZip);
            gbAddress.Controls.Add(cboxState);
            gbAddress.Controls.Add(lblState);
            gbAddress.Controls.Add(txtCity);
            gbAddress.Controls.Add(lblCity);
            gbAddress.Controls.Add(txtApt);
            gbAddress.Controls.Add(lblApt);
            gbAddress.Controls.Add(txtStreet);
            gbAddress.Controls.Add(lblStreet);
            gbAddress.Dock = DockStyle.Fill;
            gbAddress.Location = new Point(3, 360);
            gbAddress.Name = "gbAddress";
            gbAddress.Size = new Size(695, 147);
            gbAddress.TabIndex = 1;
            gbAddress.TabStop = false;
            gbAddress.Text = "Address";
            // 
            // txtZip
            // 
            txtZip.Location = new Point(212, 100);
            txtZip.Name = "txtZip";
            txtZip.Size = new Size(119, 23);
            txtZip.TabIndex = 19;
            // 
            // lblZip
            // 
            lblZip.AutoSize = true;
            lblZip.Location = new Point(212, 82);
            lblZip.Name = "lblZip";
            lblZip.Size = new Size(92, 15);
            lblZip.TabIndex = 18;
            lblZip.Text = "Zip/Postal Code";
            // 
            // cboxState
            // 
            cboxState.FormattingEnabled = true;
            cboxState.Location = new Point(137, 100);
            cboxState.Name = "cboxState";
            cboxState.Size = new Size(69, 23);
            cboxState.TabIndex = 17;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Location = new Point(137, 82);
            lblState.Name = "lblState";
            lblState.Size = new Size(33, 15);
            lblState.TabIndex = 16;
            lblState.Text = "State";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(6, 100);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(125, 23);
            txtCity.TabIndex = 15;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(6, 82);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(28, 15);
            lblCity.TabIndex = 14;
            lblCity.Text = "City";
            // 
            // txtApt
            // 
            txtApt.Location = new Point(337, 46);
            txtApt.Name = "txtApt";
            txtApt.Size = new Size(105, 23);
            txtApt.TabIndex = 13;
            // 
            // lblApt
            // 
            lblApt.AutoSize = true;
            lblApt.Location = new Point(337, 28);
            lblApt.Name = "lblApt";
            lblApt.Size = new Size(105, 15);
            lblApt.TabIndex = 12;
            lblApt.Text = "Apartment/Suite #";
            // 
            // txtStreet
            // 
            txtStreet.Location = new Point(6, 46);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(325, 23);
            txtStreet.TabIndex = 11;
            // 
            // lblStreet
            // 
            lblStreet.AutoSize = true;
            lblStreet.Location = new Point(6, 28);
            lblStreet.Name = "lblStreet";
            lblStreet.Size = new Size(82, 15);
            lblStreet.TabIndex = 10;
            lblStreet.Text = "Street Address";
            // 
            // gbDepartment
            // 
            gbDepartment.Controls.Add(btnClearDeptSearch);
            gbDepartment.Controls.Add(btnDeptSearch);
            gbDepartment.Controls.Add(txtDeptSearch);
            gbDepartment.Controls.Add(lblDeptSearch);
            gbDepartment.Controls.Add(dgvDepartment);
            gbDepartment.Dock = DockStyle.Fill;
            gbDepartment.Location = new Point(3, 513);
            gbDepartment.Name = "gbDepartment";
            gbDepartment.Size = new Size(695, 198);
            gbDepartment.TabIndex = 2;
            gbDepartment.TabStop = false;
            gbDepartment.Text = "Department Assignment";
            // 
            // btnClearDeptSearch
            // 
            btnClearDeptSearch.Location = new Point(535, 69);
            btnClearDeptSearch.Name = "btnClearDeptSearch";
            btnClearDeptSearch.Size = new Size(75, 23);
            btnClearDeptSearch.TabIndex = 4;
            btnClearDeptSearch.Text = "Clear";
            btnClearDeptSearch.UseVisualStyleBackColor = true;
            btnClearDeptSearch.Click += btnClearDeptSearch_Click;
            // 
            // btnDeptSearch
            // 
            btnDeptSearch.Location = new Point(454, 69);
            btnDeptSearch.Name = "btnDeptSearch";
            btnDeptSearch.Size = new Size(75, 23);
            btnDeptSearch.TabIndex = 3;
            btnDeptSearch.Text = "Search";
            btnDeptSearch.UseVisualStyleBackColor = true;
            btnDeptSearch.Click += btnDeptSearch_Click;
            // 
            // txtDeptSearch
            // 
            txtDeptSearch.Location = new Point(454, 40);
            txtDeptSearch.Name = "txtDeptSearch";
            txtDeptSearch.PlaceholderText = "Search...";
            txtDeptSearch.Size = new Size(228, 23);
            txtDeptSearch.TabIndex = 2;
            // 
            // lblDeptSearch
            // 
            lblDeptSearch.AutoSize = true;
            lblDeptSearch.Location = new Point(509, 22);
            lblDeptSearch.Name = "lblDeptSearch";
            lblDeptSearch.Size = new Size(126, 15);
            lblDeptSearch.TabIndex = 1;
            lblDeptSearch.Text = "Search for Department";
            // 
            // dgvDepartment
            // 
            dgvDepartment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDepartment.Location = new Point(9, 22);
            dgvDepartment.Name = "dgvDepartment";
            dgvDepartment.Size = new Size(433, 160);
            dgvDepartment.TabIndex = 0;
            dgvDepartment.DataBindingComplete += dgvDepartment_DataBindingComplete;
            // 
            // gbBuilding
            // 
            gbBuilding.Controls.Add(btnClearBuildingSearch);
            gbBuilding.Controls.Add(btnBuildingSearch);
            gbBuilding.Controls.Add(txtBuildingSearch);
            gbBuilding.Controls.Add(lblBuildingSearch);
            gbBuilding.Controls.Add(dgvBuilding);
            gbBuilding.Dock = DockStyle.Fill;
            gbBuilding.Location = new Point(3, 717);
            gbBuilding.Name = "gbBuilding";
            gbBuilding.Size = new Size(695, 198);
            gbBuilding.TabIndex = 3;
            gbBuilding.TabStop = false;
            gbBuilding.Text = "Building Assignment";
            // 
            // btnClearBuildingSearch
            // 
            btnClearBuildingSearch.Location = new Point(535, 69);
            btnClearBuildingSearch.Name = "btnClearBuildingSearch";
            btnClearBuildingSearch.Size = new Size(75, 23);
            btnClearBuildingSearch.TabIndex = 5;
            btnClearBuildingSearch.Text = "Clear";
            btnClearBuildingSearch.UseVisualStyleBackColor = true;
            btnClearBuildingSearch.Click += btnClearBuildingSearch_Click;
            // 
            // btnBuildingSearch
            // 
            btnBuildingSearch.Location = new Point(454, 69);
            btnBuildingSearch.Name = "btnBuildingSearch";
            btnBuildingSearch.Size = new Size(75, 23);
            btnBuildingSearch.TabIndex = 4;
            btnBuildingSearch.Text = "Search";
            btnBuildingSearch.UseVisualStyleBackColor = true;
            btnBuildingSearch.Click += btnBuildingSearch_Click;
            // 
            // txtBuildingSearch
            // 
            txtBuildingSearch.Location = new Point(454, 40);
            txtBuildingSearch.Name = "txtBuildingSearch";
            txtBuildingSearch.PlaceholderText = "Search...";
            txtBuildingSearch.Size = new Size(228, 23);
            txtBuildingSearch.TabIndex = 3;
            // 
            // lblBuildingSearch
            // 
            lblBuildingSearch.AutoSize = true;
            lblBuildingSearch.Location = new Point(509, 22);
            lblBuildingSearch.Name = "lblBuildingSearch";
            lblBuildingSearch.Size = new Size(107, 15);
            lblBuildingSearch.TabIndex = 2;
            lblBuildingSearch.Text = "Search for Building";
            // 
            // dgvBuilding
            // 
            dgvBuilding.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBuilding.Location = new Point(9, 22);
            dgvBuilding.Name = "dgvBuilding";
            dgvBuilding.Size = new Size(433, 159);
            dgvBuilding.TabIndex = 0;
            dgvBuilding.DataBindingComplete += dgvBuilding_DataBindingComplete;
            // 
            // flpButtons
            // 
            flpButtons.Controls.Add(btnSave);
            flpButtons.Controls.Add(btnExit);
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.FlowDirection = FlowDirection.RightToLeft;
            flpButtons.Location = new Point(3, 921);
            flpButtons.Name = "flpButtons";
            flpButtons.Padding = new Padding(5);
            flpButtons.Size = new Size(695, 44);
            flpButtons.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(607, 8);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(526, 8);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // frmEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 968);
            Controls.Add(tlpMainLayout);
            Name = "frmEmployee";
            Text = "frmEmployee";
            tlpMainLayout.ResumeLayout(false);
            gbEmployeeDetails.ResumeLayout(false);
            gbEmployeeDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgEmployeeProfilePic).EndInit();
            gbAddress.ResumeLayout(false);
            gbAddress.PerformLayout();
            gbDepartment.ResumeLayout(false);
            gbDepartment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDepartment).EndInit();
            gbBuilding.ResumeLayout(false);
            gbBuilding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBuilding).EndInit();
            flpButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMainLayout;
        private GroupBox gbEmployeeDetails;
        private GroupBox gbAddress;
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
        private GroupBox gbDepartment;
        private GroupBox gbBuilding;
        private FlowLayoutPanel flpButtons;
        private PictureBox imgEmployeeProfilePic;
        private TextBox txtPosition;
        private Label lblPosition;
        private TextBox txtExt;
        private Label lblExtension;
        private TextBox txtSSN;
        private Label lblSSN;
        private TextBox txtEmployeeID;
        private Label lblEmployeeID;
        private DateTimePicker dtpDateOfBirth;
        private Label lblDOB;
        private TextBox txtLastname;
        private Label lblLastName;
        private TextBox txtFirstname;
        private Label lblFirstname;
        private Label lblOfficeNumber;
        private Label lblEndDate;
        private Label lblStartDate;
        private Label lblPayRate;
        private TextBox txtOfficeNumber;
        private TextBox txtPayRate;
        private CheckBox chkbxEmployed;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private DataGridView dgvDepartment;
        private DataGridView dgvBuilding;
        private Button btnSave;
        private Button btnExit;
        private TextBox txtDeptSearch;
        private Label lblDeptSearch;
        private TextBox txtBuildingSearch;
        private Label lblBuildingSearch;
        private Button btnClearDeptSearch;
        private Button btnDeptSearch;
        private Button btnClearBuildingSearch;
        private Button btnBuildingSearch;
    }
}
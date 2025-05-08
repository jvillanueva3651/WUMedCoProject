namespace WUMedCoProject.src
{
    partial class frmPatient
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
            gbPatientDetails = new GroupBox();
            imgPatientProfilePic = new PictureBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhone = new TextBox();
            lblPhoneNum = new Label();
            txtSSN = new TextBox();
            lblSSN = new Label();
            txtSex = new TextBox();
            lblSex = new Label();
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
            gbEmergencyContact = new GroupBox();
            txtECPhoneNum = new TextBox();
            lblECPhone = new Label();
            txtECLastname = new TextBox();
            lblECLastname = new Label();
            txtECFirstname = new TextBox();
            lblECFirstname = new Label();
            gbInsurance = new GroupBox();
            chkbxNoInsurance = new CheckBox();
            chkbxNoTerminationDate = new CheckBox();
            txtCoverageDetails = new TextBox();
            txtCopay = new TextBox();
            txtCost = new TextBox();
            dtpTerminationDate = new DateTimePicker();
            dtpEffectiveDate = new DateTimePicker();
            lblCoverageDetails = new Label();
            lblCopay = new Label();
            lblCost = new Label();
            lblTerminationDate = new Label();
            lblEffectiveDate = new Label();
            txtInsuranceType = new TextBox();
            lblInsuranceType = new Label();
            txtInsuranceProvider = new TextBox();
            lblInsuranceProvider = new Label();
            txtInsuranceID = new TextBox();
            lblInsuranceID = new Label();
            flpButtons = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            btnExit = new Button();
            tlpMainLayout.SuspendLayout();
            gbPatientDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgPatientProfilePic).BeginInit();
            gbAddress.SuspendLayout();
            gbEmergencyContact.SuspendLayout();
            gbInsurance.SuspendLayout();
            flpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMainLayout
            // 
            tlpMainLayout.ColumnCount = 1;
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMainLayout.Controls.Add(gbPatientDetails, 0, 0);
            tlpMainLayout.Controls.Add(gbAddress, 0, 1);
            tlpMainLayout.Controls.Add(gbEmergencyContact, 0, 2);
            tlpMainLayout.Controls.Add(gbInsurance, 0, 3);
            tlpMainLayout.Controls.Add(flpButtons, 0, 4);
            tlpMainLayout.Dock = DockStyle.Fill;
            tlpMainLayout.Location = new Point(0, 0);
            tlpMainLayout.Name = "tlpMainLayout";
            tlpMainLayout.RowCount = 5;
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpMainLayout.Size = new Size(717, 1007);
            tlpMainLayout.TabIndex = 0;
            // 
            // gbPatientDetails
            // 
            gbPatientDetails.Controls.Add(imgPatientProfilePic);
            gbPatientDetails.Controls.Add(txtEmail);
            gbPatientDetails.Controls.Add(lblEmail);
            gbPatientDetails.Controls.Add(txtPhone);
            gbPatientDetails.Controls.Add(lblPhoneNum);
            gbPatientDetails.Controls.Add(txtSSN);
            gbPatientDetails.Controls.Add(lblSSN);
            gbPatientDetails.Controls.Add(txtSex);
            gbPatientDetails.Controls.Add(lblSex);
            gbPatientDetails.Controls.Add(dtpDateOfBirth);
            gbPatientDetails.Controls.Add(lblDOB);
            gbPatientDetails.Controls.Add(txtLastname);
            gbPatientDetails.Controls.Add(lblLastName);
            gbPatientDetails.Controls.Add(txtFirstname);
            gbPatientDetails.Controls.Add(lblFirstname);
            gbPatientDetails.Dock = DockStyle.Fill;
            gbPatientDetails.Location = new Point(3, 3);
            gbPatientDetails.Name = "gbPatientDetails";
            gbPatientDetails.Size = new Size(711, 281);
            gbPatientDetails.TabIndex = 0;
            gbPatientDetails.TabStop = false;
            gbPatientDetails.Text = "Patient Details";
            // 
            // imgPatientProfilePic
            // 
            imgPatientProfilePic.Location = new Point(487, 95);
            imgPatientProfilePic.Name = "imgPatientProfilePic";
            imgPatientProfilePic.Size = new Size(181, 157);
            imgPatientProfilePic.TabIndex = 14;
            imgPatientProfilePic.TabStop = false;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(140, 189);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(268, 23);
            txtEmail.TabIndex = 13;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(140, 171);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 12;
            lblEmail.Text = "Email";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(9, 189);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 23);
            txtPhone.TabIndex = 11;
            // 
            // lblPhoneNum
            // 
            lblPhoneNum.AutoSize = true;
            lblPhoneNum.Location = new Point(9, 171);
            lblPhoneNum.Name = "lblPhoneNum";
            lblPhoneNum.Size = new Size(88, 15);
            lblPhoneNum.TabIndex = 10;
            lblPhoneNum.Text = "Phone Number";
            // 
            // txtSSN
            // 
            txtSSN.Location = new Point(215, 113);
            txtSSN.Name = "txtSSN";
            txtSSN.Size = new Size(119, 23);
            txtSSN.TabIndex = 9;
            // 
            // lblSSN
            // 
            lblSSN.AutoSize = true;
            lblSSN.Location = new Point(215, 95);
            lblSSN.Name = "lblSSN";
            lblSSN.Size = new Size(28, 15);
            lblSSN.TabIndex = 8;
            lblSSN.Text = "SSN";
            // 
            // txtSex
            // 
            txtSex.Location = new Point(487, 47);
            txtSex.Name = "txtSex";
            txtSex.Size = new Size(68, 23);
            txtSex.TabIndex = 7;
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Location = new Point(487, 29);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(25, 15);
            lblSex.TabIndex = 6;
            lblSex.Text = "Sex";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new Point(9, 113);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(200, 23);
            dtpDateOfBirth.TabIndex = 5;
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(9, 95);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(73, 15);
            lblDOB.TabIndex = 4;
            lblDOB.Text = "Date of Birth";
            // 
            // txtLastname
            // 
            txtLastname.Location = new Point(236, 47);
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new Size(245, 23);
            txtLastname.TabIndex = 3;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(236, 29);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(63, 15);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name";
            // 
            // txtFirstname
            // 
            txtFirstname.Location = new Point(9, 47);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(221, 23);
            txtFirstname.TabIndex = 1;
            // 
            // lblFirstname
            // 
            lblFirstname.AutoSize = true;
            lblFirstname.Location = new Point(9, 29);
            lblFirstname.Name = "lblFirstname";
            lblFirstname.Size = new Size(64, 15);
            lblFirstname.TabIndex = 0;
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
            gbAddress.Location = new Point(3, 290);
            gbAddress.Name = "gbAddress";
            gbAddress.Size = new Size(711, 137);
            gbAddress.TabIndex = 1;
            gbAddress.TabStop = false;
            gbAddress.Text = "Patient Address";
            // 
            // txtZip
            // 
            txtZip.Location = new Point(215, 100);
            txtZip.Name = "txtZip";
            txtZip.Size = new Size(119, 23);
            txtZip.TabIndex = 9;
            // 
            // lblZip
            // 
            lblZip.AutoSize = true;
            lblZip.Location = new Point(215, 82);
            lblZip.Name = "lblZip";
            lblZip.Size = new Size(92, 15);
            lblZip.TabIndex = 8;
            lblZip.Text = "Zip/Postal Code";
            // 
            // cboxState
            // 
            cboxState.FormattingEnabled = true;
            cboxState.Location = new Point(140, 100);
            cboxState.Name = "cboxState";
            cboxState.Size = new Size(69, 23);
            cboxState.TabIndex = 7;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Location = new Point(140, 82);
            lblState.Name = "lblState";
            lblState.Size = new Size(33, 15);
            lblState.TabIndex = 6;
            lblState.Text = "State";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(9, 100);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(125, 23);
            txtCity.TabIndex = 5;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(9, 82);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(28, 15);
            lblCity.TabIndex = 4;
            lblCity.Text = "City";
            // 
            // txtApt
            // 
            txtApt.Location = new Point(340, 46);
            txtApt.Name = "txtApt";
            txtApt.Size = new Size(105, 23);
            txtApt.TabIndex = 3;
            // 
            // lblApt
            // 
            lblApt.AutoSize = true;
            lblApt.Location = new Point(340, 28);
            lblApt.Name = "lblApt";
            lblApt.Size = new Size(105, 15);
            lblApt.TabIndex = 2;
            lblApt.Text = "Apartment/Suite #";
            // 
            // txtStreet
            // 
            txtStreet.Location = new Point(9, 46);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(325, 23);
            txtStreet.TabIndex = 1;
            // 
            // lblStreet
            // 
            lblStreet.AutoSize = true;
            lblStreet.Location = new Point(9, 28);
            lblStreet.Name = "lblStreet";
            lblStreet.Size = new Size(82, 15);
            lblStreet.TabIndex = 0;
            lblStreet.Text = "Street Address";
            // 
            // gbEmergencyContact
            // 
            gbEmergencyContact.Controls.Add(txtECPhoneNum);
            gbEmergencyContact.Controls.Add(lblECPhone);
            gbEmergencyContact.Controls.Add(txtECLastname);
            gbEmergencyContact.Controls.Add(lblECLastname);
            gbEmergencyContact.Controls.Add(txtECFirstname);
            gbEmergencyContact.Controls.Add(lblECFirstname);
            gbEmergencyContact.Dock = DockStyle.Fill;
            gbEmergencyContact.Location = new Point(3, 433);
            gbEmergencyContact.Name = "gbEmergencyContact";
            gbEmergencyContact.Size = new Size(711, 89);
            gbEmergencyContact.TabIndex = 2;
            gbEmergencyContact.TabStop = false;
            gbEmergencyContact.Text = "Emergency Contact";
            // 
            // txtECPhoneNum
            // 
            txtECPhoneNum.Location = new Point(487, 46);
            txtECPhoneNum.Name = "txtECPhoneNum";
            txtECPhoneNum.Size = new Size(125, 23);
            txtECPhoneNum.TabIndex = 5;
            // 
            // lblECPhone
            // 
            lblECPhone.AutoSize = true;
            lblECPhone.Location = new Point(487, 28);
            lblECPhone.Name = "lblECPhone";
            lblECPhone.Size = new Size(88, 15);
            lblECPhone.TabIndex = 4;
            lblECPhone.Text = "Phone Number";
            // 
            // txtECLastname
            // 
            txtECLastname.Location = new Point(236, 46);
            txtECLastname.Name = "txtECLastname";
            txtECLastname.Size = new Size(245, 23);
            txtECLastname.TabIndex = 3;
            // 
            // lblECLastname
            // 
            lblECLastname.AutoSize = true;
            lblECLastname.Location = new Point(236, 28);
            lblECLastname.Name = "lblECLastname";
            lblECLastname.Size = new Size(63, 15);
            lblECLastname.TabIndex = 2;
            lblECLastname.Text = "Last Name";
            // 
            // txtECFirstname
            // 
            txtECFirstname.Location = new Point(9, 46);
            txtECFirstname.Name = "txtECFirstname";
            txtECFirstname.Size = new Size(221, 23);
            txtECFirstname.TabIndex = 1;
            // 
            // lblECFirstname
            // 
            lblECFirstname.AutoSize = true;
            lblECFirstname.Location = new Point(9, 28);
            lblECFirstname.Name = "lblECFirstname";
            lblECFirstname.Size = new Size(64, 15);
            lblECFirstname.TabIndex = 0;
            lblECFirstname.Text = "First Name";
            // 
            // gbInsurance
            // 
            gbInsurance.Controls.Add(chkbxNoInsurance);
            gbInsurance.Controls.Add(chkbxNoTerminationDate);
            gbInsurance.Controls.Add(txtCoverageDetails);
            gbInsurance.Controls.Add(txtCopay);
            gbInsurance.Controls.Add(txtCost);
            gbInsurance.Controls.Add(dtpTerminationDate);
            gbInsurance.Controls.Add(dtpEffectiveDate);
            gbInsurance.Controls.Add(lblCoverageDetails);
            gbInsurance.Controls.Add(lblCopay);
            gbInsurance.Controls.Add(lblCost);
            gbInsurance.Controls.Add(lblTerminationDate);
            gbInsurance.Controls.Add(lblEffectiveDate);
            gbInsurance.Controls.Add(txtInsuranceType);
            gbInsurance.Controls.Add(lblInsuranceType);
            gbInsurance.Controls.Add(txtInsuranceProvider);
            gbInsurance.Controls.Add(lblInsuranceProvider);
            gbInsurance.Controls.Add(txtInsuranceID);
            gbInsurance.Controls.Add(lblInsuranceID);
            gbInsurance.Dock = DockStyle.Fill;
            gbInsurance.Location = new Point(3, 528);
            gbInsurance.Name = "gbInsurance";
            gbInsurance.Size = new Size(711, 424);
            gbInsurance.TabIndex = 3;
            gbInsurance.TabStop = false;
            gbInsurance.Text = "Insurance Info";
            // 
            // chkbxNoInsurance
            // 
            chkbxNoInsurance.AutoSize = true;
            chkbxNoInsurance.Location = new Point(9, 78);
            chkbxNoInsurance.Name = "chkbxNoInsurance";
            chkbxNoInsurance.Size = new Size(96, 19);
            chkbxNoInsurance.TabIndex = 17;
            chkbxNoInsurance.Text = "No Insurance";
            chkbxNoInsurance.UseVisualStyleBackColor = true;
            chkbxNoInsurance.CheckedChanged += chkbxNoInsurance_CheckedChanged;
            // 
            // chkbxNoTerminationDate
            // 
            chkbxNoTerminationDate.AutoSize = true;
            chkbxNoTerminationDate.Location = new Point(262, 164);
            chkbxNoTerminationDate.Name = "chkbxNoTerminationDate";
            chkbxNoTerminationDate.Size = new Size(135, 19);
            chkbxNoTerminationDate.TabIndex = 16;
            chkbxNoTerminationDate.Text = "No Termination Date";
            chkbxNoTerminationDate.UseVisualStyleBackColor = true;
            chkbxNoTerminationDate.CheckedChanged += chkbxNoTerminationDate_CheckedChanged;
            // 
            // txtCoverageDetails
            // 
            txtCoverageDetails.Location = new Point(9, 227);
            txtCoverageDetails.Multiline = true;
            txtCoverageDetails.Name = "txtCoverageDetails";
            txtCoverageDetails.Size = new Size(684, 183);
            txtCoverageDetails.TabIndex = 15;
            // 
            // txtCopay
            // 
            txtCopay.Location = new Point(593, 135);
            txtCopay.Name = "txtCopay";
            txtCopay.Size = new Size(100, 23);
            txtCopay.TabIndex = 14;
            // 
            // txtCost
            // 
            txtCost.Location = new Point(487, 135);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(100, 23);
            txtCost.TabIndex = 13;
            // 
            // dtpTerminationDate
            // 
            dtpTerminationDate.Location = new Point(262, 135);
            dtpTerminationDate.Name = "dtpTerminationDate";
            dtpTerminationDate.Size = new Size(200, 23);
            dtpTerminationDate.TabIndex = 12;
            dtpTerminationDate.ValueChanged += dtpTerminationDate_ValueChanged;
            // 
            // dtpEffectiveDate
            // 
            dtpEffectiveDate.Location = new Point(9, 135);
            dtpEffectiveDate.Name = "dtpEffectiveDate";
            dtpEffectiveDate.Size = new Size(200, 23);
            dtpEffectiveDate.TabIndex = 11;
            // 
            // lblCoverageDetails
            // 
            lblCoverageDetails.AutoSize = true;
            lblCoverageDetails.Location = new Point(9, 209);
            lblCoverageDetails.Name = "lblCoverageDetails";
            lblCoverageDetails.Size = new Size(95, 15);
            lblCoverageDetails.TabIndex = 10;
            lblCoverageDetails.Text = "Coverage Details";
            // 
            // lblCopay
            // 
            lblCopay.AutoSize = true;
            lblCopay.Location = new Point(593, 117);
            lblCopay.Name = "lblCopay";
            lblCopay.Size = new Size(41, 15);
            lblCopay.TabIndex = 9;
            lblCopay.Text = "Copay";
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.Location = new Point(487, 117);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(31, 15);
            lblCost.TabIndex = 8;
            lblCost.Text = "Cost";
            // 
            // lblTerminationDate
            // 
            lblTerminationDate.AutoSize = true;
            lblTerminationDate.Location = new Point(262, 117);
            lblTerminationDate.Name = "lblTerminationDate";
            lblTerminationDate.Size = new Size(97, 15);
            lblTerminationDate.TabIndex = 7;
            lblTerminationDate.Text = "Termination Date";
            // 
            // lblEffectiveDate
            // 
            lblEffectiveDate.AutoSize = true;
            lblEffectiveDate.Location = new Point(9, 117);
            lblEffectiveDate.Name = "lblEffectiveDate";
            lblEffectiveDate.Size = new Size(79, 15);
            lblEffectiveDate.TabIndex = 6;
            lblEffectiveDate.Text = "Effective Date";
            // 
            // txtInsuranceType
            // 
            txtInsuranceType.Location = new Point(447, 49);
            txtInsuranceType.Name = "txtInsuranceType";
            txtInsuranceType.Size = new Size(198, 23);
            txtInsuranceType.TabIndex = 5;
            // 
            // lblInsuranceType
            // 
            lblInsuranceType.AutoSize = true;
            lblInsuranceType.Location = new Point(447, 31);
            lblInsuranceType.Name = "lblInsuranceType";
            lblInsuranceType.Size = new Size(85, 15);
            lblInsuranceType.TabIndex = 4;
            lblInsuranceType.Text = "Insurance Type";
            // 
            // txtInsuranceProvider
            // 
            txtInsuranceProvider.Location = new Point(215, 49);
            txtInsuranceProvider.Name = "txtInsuranceProvider";
            txtInsuranceProvider.Size = new Size(226, 23);
            txtInsuranceProvider.TabIndex = 3;
            // 
            // lblInsuranceProvider
            // 
            lblInsuranceProvider.AutoSize = true;
            lblInsuranceProvider.Location = new Point(215, 31);
            lblInsuranceProvider.Name = "lblInsuranceProvider";
            lblInsuranceProvider.Size = new Size(105, 15);
            lblInsuranceProvider.TabIndex = 2;
            lblInsuranceProvider.Text = "Insurance Provider";
            // 
            // txtInsuranceID
            // 
            txtInsuranceID.Location = new Point(9, 49);
            txtInsuranceID.Name = "txtInsuranceID";
            txtInsuranceID.Size = new Size(167, 23);
            txtInsuranceID.TabIndex = 1;
            // 
            // lblInsuranceID
            // 
            lblInsuranceID.AutoSize = true;
            lblInsuranceID.Location = new Point(9, 31);
            lblInsuranceID.Name = "lblInsuranceID";
            lblInsuranceID.Size = new Size(189, 15);
            lblInsuranceID.TabIndex = 0;
            lblInsuranceID.Text = "InsuranceID(Leave blank if adding)";
            // 
            // flpButtons
            // 
            flpButtons.Controls.Add(btnSave);
            flpButtons.Controls.Add(btnCancel);
            flpButtons.Controls.Add(btnExit);
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.FlowDirection = FlowDirection.RightToLeft;
            flpButtons.Location = new Point(3, 958);
            flpButtons.Name = "flpButtons";
            flpButtons.Padding = new Padding(5);
            flpButtons.Size = new Size(711, 46);
            flpButtons.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(608, 8);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(512, 8);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(416, 8);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(90, 30);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // frmPatient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 1007);
            Controls.Add(tlpMainLayout);
            Name = "frmPatient";
            Text = "frmPatient";
            tlpMainLayout.ResumeLayout(false);
            gbPatientDetails.ResumeLayout(false);
            gbPatientDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgPatientProfilePic).EndInit();
            gbAddress.ResumeLayout(false);
            gbAddress.PerformLayout();
            gbEmergencyContact.ResumeLayout(false);
            gbEmergencyContact.PerformLayout();
            gbInsurance.ResumeLayout(false);
            gbInsurance.PerformLayout();
            flpButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMainLayout;
        private GroupBox gbPatientDetails;
        private GroupBox gbAddress;
        private GroupBox gbEmergencyContact;
        private GroupBox gbInsurance;
        private FlowLayoutPanel flpButtons;
        private Button btnSave;
        private Button btnCancel;
        private Button btnExit;
        private Label lblFirstname;
        private Label lblLastName;
        private TextBox txtFirstname;
        private TextBox txtLastname;
        private DateTimePicker dtpDateOfBirth;
        private Label lblDOB;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtPhone;
        private Label lblPhoneNum;
        private TextBox txtSSN;
        private Label lblSSN;
        private TextBox txtSex;
        private Label lblSex;
        private TextBox textBox5;
        private Label lblState;
        private TextBox txtCity;
        private Label lblCity;
        private TextBox txtApt;
        private Label lblApt;
        private TextBox txtStreet;
        private Label lblStreet;
        private TextBox txtZip;
        private Label lblZip;
        private ComboBox cboxState;
        private Label lblECLastname;
        private TextBox txtECFirstname;
        private Label lblECFirstname;
        private TextBox txtECPhoneNum;
        private Label lblECPhone;
        private TextBox txtECLastname;
        private Label lblInsuranceID;
        private TextBox txtInsuranceProvider;
        private Label lblInsuranceProvider;
        private TextBox txtInsuranceID;
        private Label lblCoverageDetails;
        private Label lblCopay;
        private Label lblCost;
        private Label lblTerminationDate;
        private Label lblEffectiveDate;
        private TextBox txtInsuranceType;
        private Label lblInsuranceType;
        private DateTimePicker dtpTerminationDate;
        private DateTimePicker dtpEffectiveDate;
        private TextBox txtCoverageDetails;
        private TextBox txtCopay;
        private TextBox txtCost;
        private PictureBox imgPatientProfilePic;
        private CheckBox chkbxNoInsurance;
        private CheckBox chkbxNoTerminationDate;
    }
}
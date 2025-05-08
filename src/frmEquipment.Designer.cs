namespace WUMedCoProject.src
{
    partial class frmEquipment
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
            tlpMain = new TableLayoutPanel();
            gbEquipmentDetails = new GroupBox();
            lblRoom = new Label();
            cboRoom = new ComboBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            lblLastMaintenance = new Label();
            dtpLastMaintenance = new DateTimePicker();
            lblAcquisition = new Label();
            dtpAcquisition = new DateTimePicker();
            lblCost = new Label();
            txtCost = new TextBox();
            lblSerial = new Label();
            txtSerial = new TextBox();
            lblModel = new Label();
            txtModel = new TextBox();
            lblBrand = new Label();
            txtBrand = new TextBox();
            lblType = new Label();
            txtType = new TextBox();
            flpButtons = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            tlpMain.SuspendLayout();
            gbEquipmentDetails.SuspendLayout();
            flpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(gbEquipmentDetails, 0, 0);
            tlpMain.Controls.Add(flpButtons, 0, 1);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Margin = new Padding(4, 5, 4, 5);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 2;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
            tlpMain.Size = new Size(1024, 1000);
            tlpMain.TabIndex = 0;
            // 
            // gbEquipmentDetails
            // 
            gbEquipmentDetails.Controls.Add(lblRoom);
            gbEquipmentDetails.Controls.Add(cboRoom);
            gbEquipmentDetails.Controls.Add(lblStatus);
            gbEquipmentDetails.Controls.Add(cboStatus);
            gbEquipmentDetails.Controls.Add(lblLastMaintenance);
            gbEquipmentDetails.Controls.Add(dtpLastMaintenance);
            gbEquipmentDetails.Controls.Add(lblAcquisition);
            gbEquipmentDetails.Controls.Add(dtpAcquisition);
            gbEquipmentDetails.Controls.Add(lblCost);
            gbEquipmentDetails.Controls.Add(txtCost);
            gbEquipmentDetails.Controls.Add(lblSerial);
            gbEquipmentDetails.Controls.Add(txtSerial);
            gbEquipmentDetails.Controls.Add(lblModel);
            gbEquipmentDetails.Controls.Add(txtModel);
            gbEquipmentDetails.Controls.Add(lblBrand);
            gbEquipmentDetails.Controls.Add(txtBrand);
            gbEquipmentDetails.Controls.Add(lblType);
            gbEquipmentDetails.Controls.Add(txtType);
            gbEquipmentDetails.Dock = DockStyle.Fill;
            gbEquipmentDetails.Location = new Point(4, 5);
            gbEquipmentDetails.Margin = new Padding(4, 5, 4, 5);
            gbEquipmentDetails.Name = "gbEquipmentDetails";
            gbEquipmentDetails.Padding = new Padding(4, 5, 4, 5);
            gbEquipmentDetails.Size = new Size(1016, 907);
            gbEquipmentDetails.TabIndex = 0;
            gbEquipmentDetails.TabStop = false;
            gbEquipmentDetails.Text = "Equipment Details";
            gbEquipmentDetails.Enter += gbEquipmentDetails_Enter;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Location = new Point(13, 667);
            lblRoom.Margin = new Padding(4, 0, 4, 0);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(132, 25);
            lblRoom.TabIndex = 17;
            lblRoom.Text = "Room Location";
            // 
            // cboRoom
            // 
            cboRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoom.FormattingEnabled = true;
            cboRoom.Location = new Point(13, 697);
            cboRoom.Margin = new Padding(4, 5, 4, 5);
            cboRoom.Name = "cboRoom";
            cboRoom.Size = new Size(427, 33);
            cboRoom.TabIndex = 16;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(13, 583);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 25);
            lblStatus.TabIndex = 15;
            lblStatus.Text = "Status";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(13, 613);
            cboStatus.Margin = new Padding(4, 5, 4, 5);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(284, 33);
            cboStatus.TabIndex = 14;
            // 
            // lblLastMaintenance
            // 
            lblLastMaintenance.AutoSize = true;
            lblLastMaintenance.Location = new Point(307, 417);
            lblLastMaintenance.Margin = new Padding(4, 0, 4, 0);
            lblLastMaintenance.Name = "lblLastMaintenance";
            lblLastMaintenance.Size = new Size(190, 25);
            lblLastMaintenance.TabIndex = 13;
            lblLastMaintenance.Text = "Last Maintenance Date";
            // 
            // dtpLastMaintenance
            // 
            dtpLastMaintenance.Location = new Point(307, 447);
            dtpLastMaintenance.Margin = new Padding(4, 5, 4, 5);
            dtpLastMaintenance.Name = "dtpLastMaintenance";
            dtpLastMaintenance.Size = new Size(284, 31);
            dtpLastMaintenance.TabIndex = 12;
            // 
            // lblAcquisition
            // 
            lblAcquisition.AutoSize = true;
            lblAcquisition.Location = new Point(13, 417);
            lblAcquisition.Margin = new Padding(4, 0, 4, 0);
            lblAcquisition.Name = "lblAcquisition";
            lblAcquisition.Size = new Size(142, 25);
            lblAcquisition.TabIndex = 11;
            lblAcquisition.Text = "Acquisition Date";
            // 
            // dtpAcquisition
            // 
            dtpAcquisition.Location = new Point(13, 447);
            dtpAcquisition.Margin = new Padding(4, 5, 4, 5);
            dtpAcquisition.Name = "dtpAcquisition";
            dtpAcquisition.Size = new Size(284, 31);
            dtpAcquisition.TabIndex = 10;
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.Location = new Point(13, 333);
            lblCost.Margin = new Padding(4, 0, 4, 0);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(48, 25);
            lblCost.TabIndex = 9;
            lblCost.Text = "Cost";
            // 
            // txtCost
            // 
            txtCost.Location = new Point(13, 363);
            txtCost.Margin = new Padding(4, 5, 4, 5);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(213, 31);
            txtCost.TabIndex = 8;
            // 
            // lblSerial
            // 
            lblSerial.AutoSize = true;
            lblSerial.Location = new Point(13, 250);
            lblSerial.Margin = new Padding(4, 0, 4, 0);
            lblSerial.Name = "lblSerial";
            lblSerial.Size = new Size(124, 25);
            lblSerial.TabIndex = 7;
            lblSerial.Text = "Serial Number";
            // 
            // txtSerial
            // 
            txtSerial.Location = new Point(13, 280);
            txtSerial.Margin = new Padding(4, 5, 4, 5);
            txtSerial.Name = "txtSerial";
            txtSerial.Size = new Size(355, 31);
            txtSerial.TabIndex = 6;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Location = new Point(13, 167);
            lblModel.Margin = new Padding(4, 0, 4, 0);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(63, 25);
            lblModel.TabIndex = 5;
            lblModel.Text = "Model";
            // 
            // txtModel
            // 
            txtModel.Location = new Point(13, 197);
            txtModel.Margin = new Padding(4, 5, 4, 5);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(355, 31);
            txtModel.TabIndex = 4;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Location = new Point(13, 99);
            lblBrand.Margin = new Padding(4, 0, 4, 0);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(58, 25);
            lblBrand.TabIndex = 3;
            lblBrand.Text = "Brand";
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(13, 131);
            txtBrand.Margin = new Padding(4, 5, 4, 5);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(355, 31);
            txtBrand.TabIndex = 2;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(13, 33);
            lblType.Margin = new Padding(4, 0, 4, 0);
            lblType.Name = "lblType";
            lblType.Size = new Size(49, 25);
            lblType.TabIndex = 1;
            lblType.Text = "Type";
            // 
            // txtType
            // 
            txtType.Location = new Point(13, 63);
            txtType.Margin = new Padding(4, 5, 4, 5);
            txtType.Name = "txtType";
            txtType.Size = new Size(355, 31);
            txtType.TabIndex = 0;
            // 
            // flpButtons
            // 
            flpButtons.Controls.Add(btnSave);
            flpButtons.Controls.Add(btnCancel);
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.FlowDirection = FlowDirection.RightToLeft;
            flpButtons.Location = new Point(4, 922);
            flpButtons.Margin = new Padding(4, 5, 4, 5);
            flpButtons.Name = "flpButtons";
            flpButtons.Padding = new Padding(7, 8, 7, 8);
            flpButtons.Size = new Size(1016, 73);
            flpButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(869, 13);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 50);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(732, 13);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(129, 50);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += CancelButton_Click;
            // 
            // frmEquipment
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 1000);
            Controls.Add(tlpMain);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmEquipment";
            Text = "Equipment Management";
            tlpMain.ResumeLayout(false);
            gbEquipmentDetails.ResumeLayout(false);
            gbEquipmentDetails.PerformLayout();
            flpButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private GroupBox gbEquipmentDetails;
        private FlowLayoutPanel flpButtons;
        private Button btnSave;
        private Button btnCancel;
        //private Button btnExit;
        private Label lblType;
        private TextBox txtType;
        private Label lblBrand;
        private TextBox txtBrand;
        private Label lblModel;
        private TextBox txtModel;
        private Label lblSerial;
        private TextBox txtSerial;
        private Label lblCost;
        private TextBox txtCost;
        private Label lblAcquisition;
        private DateTimePicker dtpAcquisition;
        private Label lblLastMaintenance;
        private DateTimePicker dtpLastMaintenance;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Label lblRoom;
        private ComboBox cboRoom;
    }
}
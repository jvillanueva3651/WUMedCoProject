namespace WUMedCoProject
{
    partial class frmEquipmentCRUD
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
            dgvEquipment = new DataGridView();
            btnReturnHome = new Button();
            btnAddNewEquipment = new Button();
            dgvEquipmentID = new DataGridViewTextBoxColumn();
            dgvBrand = new DataGridViewTextBoxColumn();
            dgvModel = new DataGridViewTextBoxColumn();
            dgvSerialNumber = new DataGridViewTextBoxColumn();
            dgvLastMaintenanceDate = new DataGridViewTextBoxColumn();
            dgvView = new DataGridViewButtonColumn();
            dgvEdit = new DataGridViewButtonColumn();
            dgvDelete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).BeginInit();
            SuspendLayout();
            // 
            // dgvEquipment
            // 
            dgvEquipment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipment.Columns.AddRange(new DataGridViewColumn[] { dgvEquipmentID, dgvBrand, dgvModel, dgvSerialNumber, dgvLastMaintenanceDate, dgvView, dgvEdit, dgvDelete });
            dgvEquipment.Location = new Point(12, 12);
            dgvEquipment.Name = "dgvEquipment";
            dgvEquipment.Size = new Size(843, 388);
            dgvEquipment.TabIndex = 0;
            // 
            // btnReturnHome
            // 
            btnReturnHome.Location = new Point(12, 411);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(160, 27);
            btnReturnHome.TabIndex = 7;
            btnReturnHome.Text = "Return to Home";
            btnReturnHome.UseVisualStyleBackColor = true;
            // 
            // btnAddNewEquipment
            // 
            btnAddNewEquipment.Location = new Point(697, 411);
            btnAddNewEquipment.Name = "btnAddNewEquipment";
            btnAddNewEquipment.Size = new Size(160, 27);
            btnAddNewEquipment.TabIndex = 6;
            btnAddNewEquipment.Text = "Add New Equipment";
            btnAddNewEquipment.UseVisualStyleBackColor = true;
            // 
            // dgvEquipmentID
            // 
            dgvEquipmentID.DataPropertyName = "EquipmentID";
            dgvEquipmentID.HeaderText = "EquipmentID";
            dgvEquipmentID.Name = "dgvEquipmentID";
            dgvEquipmentID.ReadOnly = true;
            // 
            // dgvBrand
            // 
            dgvBrand.DataPropertyName = "Brand";
            dgvBrand.HeaderText = "Brand";
            dgvBrand.Name = "dgvBrand";
            dgvBrand.ReadOnly = true;
            dgvBrand.Width = 125;
            // 
            // dgvModel
            // 
            dgvModel.DataPropertyName = "Model";
            dgvModel.HeaderText = "Model";
            dgvModel.Name = "dgvModel";
            dgvModel.ReadOnly = true;
            dgvModel.Width = 125;
            // 
            // dgvSerialNumber
            // 
            dgvSerialNumber.DataPropertyName = "SerialNumber";
            dgvSerialNumber.HeaderText = "Serial Number";
            dgvSerialNumber.Name = "dgvSerialNumber";
            dgvSerialNumber.ReadOnly = true;
            // 
            // dgvLastMaintenanceDate
            // 
            dgvLastMaintenanceDate.DataPropertyName = "LastMaintenanceDate";
            dgvLastMaintenanceDate.HeaderText = "Last Maintenance";
            dgvLastMaintenanceDate.Name = "dgvLastMaintenanceDate";
            dgvLastMaintenanceDate.ReadOnly = true;
            dgvLastMaintenanceDate.Width = 125;
            // 
            // dgvView
            // 
            dgvView.DataPropertyName = "View";
            dgvView.HeaderText = "";
            dgvView.Name = "dgvView";
            dgvView.UseColumnTextForButtonValue = true;
            dgvView.Width = 75;
            // 
            // dgvEdit
            // 
            dgvEdit.DataPropertyName = "Edit";
            dgvEdit.HeaderText = "";
            dgvEdit.Name = "dgvEdit";
            dgvEdit.UseColumnTextForButtonValue = true;
            dgvEdit.Width = 75;
            // 
            // dgvDelete
            // 
            dgvDelete.DataPropertyName = "Delete";
            dgvDelete.HeaderText = "";
            dgvDelete.Name = "dgvDelete";
            dgvDelete.UseColumnTextForButtonValue = true;
            dgvDelete.Width = 75;
            // 
            // frmEquipmentCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 450);
            Controls.Add(btnReturnHome);
            Controls.Add(btnAddNewEquipment);
            Controls.Add(dgvEquipment);
            Name = "frmEquipmentCRUD";
            Text = "frmEquipmentCRUD";
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEquipment;
        private Button btnReturnHome;
        private Button btnAddNewEquipment;
        private DataGridViewTextBoxColumn dgvEquipmentID;
        private DataGridViewTextBoxColumn dgvBrand;
        private DataGridViewTextBoxColumn dgvModel;
        private DataGridViewTextBoxColumn dgvSerialNumber;
        private DataGridViewTextBoxColumn dgvLastMaintenanceDate;
        private DataGridViewButtonColumn dgvView;
        private DataGridViewButtonColumn dgvEdit;
        private DataGridViewButtonColumn dgvDelete;
    }
}
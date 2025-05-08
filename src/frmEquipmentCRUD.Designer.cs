namespace WUMedCoProject.src
{
    partial class frmEquipmentCRUD
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvEquipment;
        /*
        private DataGridViewTextBoxColumn EquipmentID;
        private DataGridViewTextBoxColumn dgvType;
        private DataGridViewTextBoxColumn dgvBrand;
        private DataGridViewTextBoxColumn dgvModel;
        private DataGridViewTextBoxColumn dgvSerial;
        private DataGridViewTextBoxColumn dgvCost;
        private DataGridViewTextBoxColumn dgvAcquisitionDate;
        private DataGridViewTextBoxColumn dgvLastMaintenance;
        private DataGridViewTextBoxColumn dgvStatus;
        private DataGridViewTextBoxColumn dgvRoom;
        */
        private DataGridViewButtonColumn dgvBtnView;
        private DataGridViewButtonColumn dgvBtnEdit;
        private DataGridViewButtonColumn dgvBtnDelete;
        private Button btnAddEquipment;
        private Button btnReturnHome;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvEquipment = new DataGridView();
            /*
            EquipmentID = new DataGridViewTextBoxColumn();
            dgvType = new DataGridViewTextBoxColumn();
            dgvBrand = new DataGridViewTextBoxColumn();
            dgvModel = new DataGridViewTextBoxColumn();
            dgvSerial = new DataGridViewTextBoxColumn();
            dgvCost = new DataGridViewTextBoxColumn();
            dgvAcquisitionDate = new DataGridViewTextBoxColumn();
            dgvLastMaintenance = new DataGridViewTextBoxColumn();
            dgvStatus = new DataGridViewTextBoxColumn();
            dgvRoom = new DataGridViewTextBoxColumn();
            */
            dgvBtnView = new DataGridViewButtonColumn();
            dgvBtnEdit = new DataGridViewButtonColumn();
            dgvBtnDelete = new DataGridViewButtonColumn();
            btnAddEquipment = new Button();
            btnReturnHome = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).BeginInit();
            SuspendLayout();
            // 
            // dgvEquipment
            // 
            
            dgvEquipment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipment.Columns.AddRange(new DataGridViewColumn[] {dgvBtnView, dgvBtnEdit, dgvBtnDelete });
            dgvEquipment.Location = new Point(12, 12);
            dgvEquipment.Name = "dgvEquipment";
            dgvEquipment.RowHeadersWidth = 62;
            dgvEquipment.Size = new Size(1143, 550);
            dgvEquipment.TabIndex = 0;
            dgvEquipment.CellClick += dgvEquipment_CellClick;
            
            //dgvEquipment.CellContentClick += this.dgvEquipment_CellContentClick;
            // 
            // EquipmentID
            // 
            /*
            EquipmentID.HeaderText = "EquipmentID";
            EquipmentID.MinimumWidth = 8;
            EquipmentID.Name = "EquipmentID";
            EquipmentID.Visible = false;
            EquipmentID.Width = 150;
            // 
            // dgvType
            // 
            dgvType.HeaderText = "Type";
            dgvType.MinimumWidth = 8;
            dgvType.Name = "dgvType";
            dgvType.Width = 150;
            // 
            // dgvBrand
            // 
            dgvBrand.HeaderText = "Brand";
            dgvBrand.MinimumWidth = 8;
            dgvBrand.Name = "dgvBrand";
            dgvBrand.Width = 150;
            // 
            // dgvModel
            // 
            dgvModel.HeaderText = "Model";
            dgvModel.MinimumWidth = 8;
            dgvModel.Name = "dgvModel";
            dgvModel.Width = 150;
            // 
            // dgvSerial
            // 
            dgvSerial.HeaderText = "Serial #";
            dgvSerial.MinimumWidth = 8;
            dgvSerial.Name = "dgvSerial";
            dgvSerial.Width = 150;
            // 
            // dgvCost
            // 
            dgvCost.HeaderText = "Cost";
            dgvCost.MinimumWidth = 8;
            dgvCost.Name = "dgvCost";
            dgvCost.Width = 150;
            // 
            // dgvAcquisitionDate
            // 
            dgvAcquisitionDate.HeaderText = "Acquired";
            dgvAcquisitionDate.MinimumWidth = 8;
            dgvAcquisitionDate.Name = "dgvAcquisitionDate";
            dgvAcquisitionDate.Width = 150;
            // 
            // dgvLastMaintenance
            // 
            dgvLastMaintenance.HeaderText = "Last Maintenance";
            dgvLastMaintenance.MinimumWidth = 8;
            dgvLastMaintenance.Name = "dgvLastMaintenance";
            dgvLastMaintenance.Width = 150;
            // 
            // dgvStatus
            // 
            dgvStatus.HeaderText = "Status";
            dgvStatus.MinimumWidth = 8;
            dgvStatus.Name = "dgvStatus";
            dgvStatus.Width = 150;
            // 
            // dgvRoom
            // 
            dgvRoom.HeaderText = "Location";
            dgvRoom.MinimumWidth = 8;
            dgvRoom.Name = "dgvRoom";
            dgvRoom.Width = 150;
            */
            // 
            // dgvBtnView
            // 
            dgvBtnView.HeaderText = "";
            dgvBtnView.MinimumWidth = 8;
            dgvBtnView.Name = "dgvBtnView";
            dgvBtnView.Text = "View";
            dgvBtnView.UseColumnTextForButtonValue = true;
            dgvBtnView.Width = 150;
            // 
            // dgvBtnEdit
            // 
            dgvBtnEdit.HeaderText = "";
            dgvBtnEdit.MinimumWidth = 8;
            dgvBtnEdit.Name = "dgvBtnEdit";
            dgvBtnEdit.Text = "Edit";
            dgvBtnEdit.UseColumnTextForButtonValue = true;
            dgvBtnEdit.Width = 150;
            // 
            // dgvBtnDelete
            // 
            dgvBtnDelete.HeaderText = "";
            dgvBtnDelete.MinimumWidth = 8;
            dgvBtnDelete.Name = "dgvBtnDelete";
            dgvBtnDelete.Text = "Delete";
            dgvBtnDelete.UseColumnTextForButtonValue = true;
            dgvBtnDelete.Width = 150;
            // 
            // btnAddEquipment
            // 
            btnAddEquipment.Location = new Point(1034, 571);
            btnAddEquipment.Name = "btnAddEquipment";
            btnAddEquipment.Size = new Size(75, 34);
            btnAddEquipment.TabIndex = 1;
            btnAddEquipment.Text = "Add Equipment";
            btnAddEquipment.Click += btnAddEquipment_Click;
            // 
            // btnReturnHome
            // 
            btnReturnHome.Location = new Point(12, 568);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(75, 34);
            btnReturnHome.TabIndex = 2;
            btnReturnHome.Text = "Return Home";
            btnReturnHome.Click += btnReturnHome_Click;
            // 
            // frmEquipmentCRUD
            // 
            ClientSize = new Size(1171, 617);
            Controls.Add(dgvEquipment);
            Controls.Add(btnAddEquipment);
            Controls.Add(btnReturnHome);
            Name = "frmEquipmentCRUD";
            Text = "Equipment Management";
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).EndInit();
            ResumeLayout(false);
        }
    }
}
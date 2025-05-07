namespace WUMedCoProject
{
    partial class frmBuildingsCRUD
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
            btnReturnHome = new Button();
            btnAddNewBuilding = new Button();
            dgvBuildings = new DataGridView();
            dgvBuildingID = new DataGridViewTextBoxColumn();
            dgvBuildingName = new DataGridViewTextBoxColumn();
            dgvDirector = new DataGridViewTextBoxColumn();
            dgvViewRoomsBtn = new DataGridViewButtonColumn();
            dgvAddRoomBtn = new DataGridViewButtonColumn();
            dgvBtnView = new DataGridViewButtonColumn();
            dgvBtnEdit = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvBuildings).BeginInit();
            SuspendLayout();
            // 
            // btnReturnHome
            // 
            btnReturnHome.Location = new Point(12, 411);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(160, 27);
            btnReturnHome.TabIndex = 5;
            btnReturnHome.Text = "Return to Home";
            btnReturnHome.UseVisualStyleBackColor = true;
            btnReturnHome.Click += btnReturnHome_Click;
            // 
            // btnAddNewBuilding
            // 
            btnAddNewBuilding.Location = new Point(747, 412);
            btnAddNewBuilding.Name = "btnAddNewBuilding";
            btnAddNewBuilding.Size = new Size(160, 27);
            btnAddNewBuilding.TabIndex = 4;
            btnAddNewBuilding.Text = "Add New Building";
            btnAddNewBuilding.UseVisualStyleBackColor = true;
            btnAddNewBuilding.Click += btnAddNewBuilding_Click;
            // 
            // dgvBuildings
            // 
            dgvBuildings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBuildings.Columns.AddRange(new DataGridViewColumn[] { dgvBuildingID, dgvBuildingName, dgvDirector, dgvViewRoomsBtn, dgvAddRoomBtn, dgvBtnView, dgvBtnEdit });
            dgvBuildings.Location = new Point(12, 13);
            dgvBuildings.Name = "dgvBuildings";
            dgvBuildings.Size = new Size(895, 393);
            dgvBuildings.TabIndex = 3;
            // 
            // dgvBuildingID
            // 
            dgvBuildingID.DataPropertyName = "BuildingID";
            dgvBuildingID.HeaderText = "BuildingID";
            dgvBuildingID.Name = "dgvBuildingID";
            dgvBuildingID.ReadOnly = true;
            // 
            // dgvBuildingName
            // 
            dgvBuildingName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBuildingName.DataPropertyName = "Name";
            dgvBuildingName.HeaderText = "Building";
            dgvBuildingName.Name = "dgvBuildingName";
            // 
            // dgvDirector
            // 
            dgvDirector.DataPropertyName = "Director";
            dgvDirector.HeaderText = "Director";
            dgvDirector.Name = "dgvDirector";
            dgvDirector.Width = 250;
            // 
            // dgvViewRoomsBtn
            // 
            dgvViewRoomsBtn.HeaderText = "";
            dgvViewRoomsBtn.Name = "dgvViewRoomsBtn";
            dgvViewRoomsBtn.Text = "View Rooms";
            dgvViewRoomsBtn.UseColumnTextForButtonValue = true;
            // 
            // dgvAddRoomBtn
            // 
            dgvAddRoomBtn.HeaderText = "";
            dgvAddRoomBtn.Name = "dgvAddRoomBtn";
            dgvAddRoomBtn.Text = "Add Room";
            dgvAddRoomBtn.UseColumnTextForButtonValue = true;
            // 
            // dgvBtnView
            // 
            dgvBtnView.HeaderText = "";
            dgvBtnView.Name = "dgvBtnView";
            dgvBtnView.Text = "View";
            dgvBtnView.UseColumnTextForButtonValue = true;
            dgvBtnView.Width = 65;
            // 
            // dgvBtnEdit
            // 
            dgvBtnEdit.HeaderText = "";
            dgvBtnEdit.Name = "dgvBtnEdit";
            dgvBtnEdit.Text = "Edit";
            dgvBtnEdit.UseColumnTextForButtonValue = true;
            dgvBtnEdit.Width = 65;
            // 
            // frmBuildingsCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 451);
            Controls.Add(btnReturnHome);
            Controls.Add(btnAddNewBuilding);
            Controls.Add(dgvBuildings);
            Name = "frmBuildingsCRUD";
            Text = "frmBuildingsCRUD";
            ((System.ComponentModel.ISupportInitialize)dgvBuildings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnReturnHome;
        private Button btnAddNewBuilding;
        private DataGridView dgvBuildings;
        private Label label4;
        private DataGridViewTextBoxColumn dgvBuildingID;
        private DataGridViewTextBoxColumn dgvBuildingName;
        private DataGridViewTextBoxColumn dgvDirector;
        private DataGridViewButtonColumn dgvViewRoomsBtn;
        private DataGridViewButtonColumn dgvAddRoomBtn;
        private DataGridViewButtonColumn dgvBtnView;
        private DataGridViewButtonColumn dgvBtnEdit;
    }
}
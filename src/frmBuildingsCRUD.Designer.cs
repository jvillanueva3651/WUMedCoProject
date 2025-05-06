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
            dgvBtnEdit = new DataGridViewButtonColumn();
            dgvBtnDelete = new DataGridViewButtonColumn();
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
            // 
            // btnAddNewBuilding
            // 
            btnAddNewBuilding.Location = new Point(629, 412);
            btnAddNewBuilding.Name = "btnAddNewBuilding";
            btnAddNewBuilding.Size = new Size(160, 27);
            btnAddNewBuilding.TabIndex = 4;
            btnAddNewBuilding.Text = "Add New Building";
            btnAddNewBuilding.UseVisualStyleBackColor = true;
            // 
            // dgvBuildings
            // 
            dgvBuildings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBuildings.Columns.AddRange(new DataGridViewColumn[] { dgvBuildingID, dgvBuildingName, dgvDirector, dgvBtnEdit, dgvBtnDelete });
            dgvBuildings.Location = new Point(12, 12);
            dgvBuildings.Name = "dgvBuildings";
            dgvBuildings.Size = new Size(776, 393);
            dgvBuildings.TabIndex = 3;
            // 
            // dgvBuildingID
            // 
            dgvBuildingID.DataPropertyName = "dgvBuildingID";
            dgvBuildingID.HeaderText = "BuildingID";
            dgvBuildingID.Name = "dgvBuildingID";
            dgvBuildingID.ReadOnly = true;
            // 
            // dgvBuildingName
            // 
            dgvBuildingName.DataPropertyName = "dgvBuildingName";
            dgvBuildingName.HeaderText = "Building";
            dgvBuildingName.Name = "dgvBuildingName";
            dgvBuildingName.ReadOnly = true;
            dgvBuildingName.Width = 254;
            // 
            // dgvDirector
            // 
            dgvDirector.DataPropertyName = "dgvDirector";
            dgvDirector.HeaderText = "Director";
            dgvDirector.Name = "dgvDirector";
            dgvDirector.ReadOnly = true;
            dgvDirector.Width = 250;
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
            // frmBuildingsCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 451);
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
        private DataGridViewTextBoxColumn dgvBuildingID;
        private DataGridViewTextBoxColumn dgvBuildingName;
        private DataGridViewTextBoxColumn dgvDirector;
        private DataGridViewButtonColumn dgvBtnEdit;
        private DataGridViewButtonColumn dgvBtnDelete;
        private Label label4;
    }
}
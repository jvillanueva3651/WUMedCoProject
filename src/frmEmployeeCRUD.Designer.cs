namespace WUMedCoProject
{
    partial class frmEmployeeCRUD
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
            dataGridView1 = new DataGridView();
            dgvEmployeeID = new DataGridViewTextBoxColumn();
            dgvLastName = new DataGridViewTextBoxColumn();
            dgvFirstName = new DataGridViewTextBoxColumn();
            dgvDoB = new DataGridViewTextBoxColumn();
            dgvPosition = new DataGridViewTextBoxColumn();
            dgvExtension = new DataGridViewTextBoxColumn();
            dgvView = new DataGridViewButtonColumn();
            dgvEdit = new DataGridViewButtonColumn();
            dgvDelete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dgvEmployeeID, dgvLastName, dgvFirstName, dgvDoB, dgvPosition, dgvExtension, dgvView, dgvEdit, dgvDelete });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1000, 533);
            dataGridView1.TabIndex = 0;
            // 
            // dgvEmployeeID
            // 
            dgvEmployeeID.HeaderText = "EmployeeID";
            dgvEmployeeID.Name = "dgvEmployeeID";
            dgvEmployeeID.ReadOnly = true;
            // 
            // dgvLastName
            // 
            dgvLastName.HeaderText = "Last Name";
            dgvLastName.Name = "dgvLastName";
            dgvLastName.ReadOnly = true;
            // 
            // dgvFirstName
            // 
            dgvFirstName.HeaderText = "First Name";
            dgvFirstName.Name = "dgvFirstName";
            dgvFirstName.ReadOnly = true;
            // 
            // dgvDoB
            // 
            dgvDoB.HeaderText = "Date of Birth";
            dgvDoB.Name = "dgvDoB";
            dgvDoB.ReadOnly = true;
            // 
            // dgvPosition
            // 
            dgvPosition.HeaderText = "Position";
            dgvPosition.Name = "dgvPosition";
            dgvPosition.ReadOnly = true;
            // 
            // dgvExtension
            // 
            dgvExtension.HeaderText = "Extension";
            dgvExtension.Name = "dgvExtension";
            dgvExtension.ReadOnly = true;
            // 
            // dgvView
            // 
            dgvView.HeaderText = "";
            dgvView.Name = "dgvView";
            // 
            // dgvEdit
            // 
            dgvEdit.HeaderText = "";
            dgvEdit.Name = "dgvEdit";
            // 
            // dgvDelete
            // 
            dgvDelete.HeaderText = "";
            dgvDelete.Name = "dgvDelete";
            // 
            // frmEmployeeCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 641);
            Controls.Add(dataGridView1);
            Name = "frmEmployeeCRUD";
            Text = "frmEmployeeCRUD";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn dgvEmployeeID;
        private DataGridViewTextBoxColumn dgvLastName;
        private DataGridViewTextBoxColumn dgvFirstName;
        private DataGridViewTextBoxColumn dgvDoB;
        private DataGridViewTextBoxColumn dgvPosition;
        private DataGridViewTextBoxColumn dgvExtension;
        private DataGridViewButtonColumn dgvView;
        private DataGridViewButtonColumn dgvEdit;
        private DataGridViewButtonColumn dgvDelete;
    }
}
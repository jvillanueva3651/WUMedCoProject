using System.Windows.Forms;

namespace WUMedCoProject.src
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
            dgvEmployee = new DataGridView();
            dgvEmployeeID = new DataGridViewTextBoxColumn();
            dgvLastName = new DataGridViewTextBoxColumn();
            dgvFirstName = new DataGridViewTextBoxColumn();
            dgvDoB = new DataGridViewTextBoxColumn();
            dgvPosition = new DataGridViewTextBoxColumn();
            dgvOfficeNumber = new DataGridViewTextBoxColumn();
            dgvExtension = new DataGridViewTextBoxColumn();
            dgvView = new DataGridViewButtonColumn();
            dgvEdit = new DataGridViewButtonColumn();
            dgvDelete = new DataGridViewButtonColumn();
            btnReturnHome = new Button();
            btnAddNewEmployee = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployee
            // 
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Columns.AddRange(new DataGridViewColumn[] { dgvEmployeeID, dgvLastName, dgvFirstName, dgvDoB, dgvPosition, dgvOfficeNumber, dgvExtension, dgvView, dgvEdit, dgvDelete });
            dgvEmployee.Location = new Point(12, 12);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.Size = new Size(1043, 533);
            dgvEmployee.TabIndex = 0;
            dgvEmployee.CellClick += new DataGridViewCellEventHandler(dgvEmployee_CellClick);
            // 
            // dgvEmployeeID
            // 
            dgvEmployeeID.DataPropertyName = "EmployeeID";
            dgvEmployeeID.HeaderText = "EmployeeID";
            dgvEmployeeID.Name = "dgvEmployeeID";
            dgvEmployeeID.ReadOnly = true;
            // 
            // dgvLastName
            // 
            dgvLastName.DataPropertyName = "LastName";
            dgvLastName.HeaderText = "Last Name";
            dgvLastName.Name = "dgvLastName";
            dgvLastName.ReadOnly = true;
            dgvLastName.Width = 150;
            // 
            // dgvFirstName
            // 
            dgvFirstName.DataPropertyName = "FirstName";
            dgvFirstName.HeaderText = "First Name";
            dgvFirstName.Name = "dgvFirstName";
            dgvFirstName.ReadOnly = true;
            dgvFirstName.Width = 150;
            // 
            // dgvDoB
            // 
            dgvDoB.DataPropertyName = "DateOfBirth";
            dgvDoB.HeaderText = "Date of Birth";
            dgvDoB.Name = "dgvDoB";
            dgvDoB.ReadOnly = true;
            // 
            // dgvPosition
            // 
            dgvPosition.DataPropertyName = "Position";
            dgvPosition.HeaderText = "Position";
            dgvPosition.Name = "dgvPosition";
            dgvPosition.ReadOnly = true;
            dgvPosition.Width = 125;
            // 
            // dgvOfficeNumber
            // 
            dgvOfficeNumber.DataPropertyName = "OfficeNumber";
            dgvOfficeNumber.HeaderText = "Office #";
            dgvOfficeNumber.Name = "dgvOfficeNumber";
            dgvOfficeNumber.Width = 75;
            // 
            // dgvExtension
            // 
            dgvExtension.DataPropertyName = "Extension";
            dgvExtension.HeaderText = "Extension";
            dgvExtension.Name = "dgvExtension";
            dgvExtension.ReadOnly = true;
            dgvExtension.Width = 75;
            // 
            // dgvView
            // 
            dgvView.DataPropertyName = "View";
            dgvView.HeaderText = "";
            dgvView.Text = "View";
            dgvView.Name = "dgvView";
            dgvView.Width = 75;
            dgvView.UseColumnTextForButtonValue = true;
            // 
            // dgvEdit
            // 
            dgvEdit.DataPropertyName = "Edit";
            dgvEdit.HeaderText = "";
            dgvEdit.Text = "Edit";
            dgvEdit.Name = "dgvEdit";
            dgvEdit.Width = 75;
            dgvEdit.UseColumnTextForButtonValue = true;
            // 
            // dgvDelete
            // 
            dgvDelete.DataPropertyName = "Delete";
            dgvDelete.HeaderText = "";
            dgvDelete.Text = "Delete";
            dgvDelete.Name = "dgvDelete";
            dgvDelete.Width = 75;
            dgvDelete.UseColumnTextForButtonValue = true;
            // 
            // btnReturnHome
            // 
            btnReturnHome.Location = new Point(12, 551);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(160, 27);
            btnReturnHome.TabIndex = 4;
            btnReturnHome.Text = "Return to Home";
            btnReturnHome.UseVisualStyleBackColor = true;
            btnReturnHome.Click += new EventHandler(btnReturnHome_Click);
            // 
            // btnAddNewEmployee
            // 
            btnAddNewEmployee.Location = new Point(898, 551);
            btnAddNewEmployee.Name = "btnAddNewEmployee";
            btnAddNewEmployee.Size = new Size(160, 27);
            btnAddNewEmployee.TabIndex = 3;
            btnAddNewEmployee.Text = "Add New Employee";
            btnAddNewEmployee.UseVisualStyleBackColor = true;
            btnAddNewEmployee.Click += new EventHandler(btnAddNewEmployee_Click);
            // 
            // frmEmployeeCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 589);
            Controls.Add(btnReturnHome);
            Controls.Add(btnAddNewEmployee);
            Controls.Add(dgvEmployee);
            Name = "frmEmployeeCRUD";
            Text = "frmEmployeeCRUD";
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEmployee;
        private DataGridViewTextBoxColumn dgvEmployeeID;
        private DataGridViewTextBoxColumn dgvLastName;
        private DataGridViewTextBoxColumn dgvFirstName;
        private DataGridViewTextBoxColumn dgvDoB;
        private DataGridViewTextBoxColumn dgvPosition;
        private DataGridViewTextBoxColumn dgvOfficeNumber;
        private DataGridViewTextBoxColumn dgvExtension;
        private DataGridViewButtonColumn dgvView;
        private DataGridViewButtonColumn dgvEdit;
        private DataGridViewButtonColumn dgvDelete;
        private Button btnReturnHome;
        private Button btnAddNewEmployee;
    }
}
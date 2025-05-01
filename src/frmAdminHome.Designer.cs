namespace WUMedCoProject.src
{
    partial class frmAdminHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminHome));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnPatients = new Button();
            btnAppointments = new Button();
            btnMedRecords = new Button();
            btnEmployees = new Button();
            btnDepartments = new Button();
            btnBuildings = new Button();
            btnEquipment = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Verdana", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(226, 23);
            label1.Name = "label1";
            label1.Size = new Size(475, 44);
            label1.TabIndex = 0;
            label1.Text = "Welcome to WUMedCo!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(343, 135);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(222, 222);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnPatients
            // 
            btnPatients.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPatients.Location = new Point(98, 135);
            btnPatients.Name = "btnPatients";
            btnPatients.Size = new Size(124, 48);
            btnPatients.TabIndex = 2;
            btnPatients.Text = "Patients";
            btnPatients.UseVisualStyleBackColor = true;
            btnPatients.Click += btnPatients_Click;
            // 
            // btnAppointments
            // 
            btnAppointments.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAppointments.Location = new Point(82, 214);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Size = new Size(156, 48);
            btnAppointments.TabIndex = 3;
            btnAppointments.Text = "Appointments";
            btnAppointments.UseVisualStyleBackColor = true;
            btnAppointments.Click += btnAppointments_Click;
            // 
            // btnMedRecords
            // 
            btnMedRecords.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMedRecords.Location = new Point(98, 294);
            btnMedRecords.Name = "btnMedRecords";
            btnMedRecords.Size = new Size(124, 63);
            btnMedRecords.TabIndex = 4;
            btnMedRecords.Text = "Medical Records";
            btnMedRecords.UseVisualStyleBackColor = true;
            btnMedRecords.Click += btnMedRecords_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEmployees.Location = new Point(609, 135);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(124, 48);
            btnEmployees.TabIndex = 5;
            btnEmployees.Text = "Employees";
            btnEmployees.UseVisualStyleBackColor = true;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnDepartments
            // 
            btnDepartments.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDepartments.Location = new Point(670, 214);
            btnDepartments.Name = "btnDepartments";
            btnDepartments.Size = new Size(153, 48);
            btnDepartments.TabIndex = 6;
            btnDepartments.Text = "Departments";
            btnDepartments.UseVisualStyleBackColor = true;
            btnDepartments.Click += btnDepartments_Click;
            // 
            // btnBuildings
            // 
            btnBuildings.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuildings.Location = new Point(750, 135);
            btnBuildings.Name = "btnBuildings";
            btnBuildings.Size = new Size(124, 48);
            btnBuildings.TabIndex = 7;
            btnBuildings.Text = "Buildings";
            btnBuildings.UseVisualStyleBackColor = true;
            btnBuildings.Click += btnBuildings_Click;
            // 
            // btnEquipment
            // 
            btnEquipment.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEquipment.Location = new Point(670, 294);
            btnEquipment.Name = "btnEquipment";
            btnEquipment.Size = new Size(153, 48);
            btnEquipment.TabIndex = 8;
            btnEquipment.Text = "Equipment";
            btnEquipment.UseVisualStyleBackColor = true;
            btnEquipment.Click += btnEquipment_Click;
            // 
            // frmAdminHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 426);
            Controls.Add(btnEquipment);
            Controls.Add(btnBuildings);
            Controls.Add(btnDepartments);
            Controls.Add(btnEmployees);
            Controls.Add(btnMedRecords);
            Controls.Add(btnAppointments);
            Controls.Add(btnPatients);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "frmAdminHome";
            Text = "frmAdminHome";
            FormClosed += frmAdminHome_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Button btnPatients;
        private Button btnAppointments;
        private Button btnMedRecords;
        private Button btnEmployees;
        private Button btnDepartments;
        private Button btnBuildings;
        private Button btnEquipment;
    }
}
namespace WUMedCoProject.src
{
    partial class frmAddRoom
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
            lblBuilding = new Label();
            lblRoomType = new Label();
            lblCapacity = new Label();
            txtRoomType = new TextBox();
            txtCapacity = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblBuilding
            // 
            lblBuilding.AutoSize = true;
            lblBuilding.Location = new Point(12, 9);
            lblBuilding.Name = "lblBuilding";
            lblBuilding.Size = new Size(87, 15);
            lblBuilding.TabIndex = 0;
            lblBuilding.Text = "Add a room to ";
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Location = new Point(12, 48);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(66, 15);
            lblRoomType.TabIndex = 1;
            lblRoomType.Text = "Room Type";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Location = new Point(215, 48);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(53, 15);
            lblCapacity.TabIndex = 2;
            lblCapacity.Text = "Capacity";
            // 
            // txtRoomType
            // 
            txtRoomType.Location = new Point(12, 66);
            txtRoomType.Name = "txtRoomType";
            txtRoomType.Size = new Size(197, 23);
            txtRoomType.TabIndex = 3;
            // 
            // txtCapacity
            // 
            txtCapacity.Location = new Point(215, 66);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(73, 23);
            txtCapacity.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 120);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(213, 120);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // frmAddRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 156);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(txtCapacity);
            Controls.Add(txtRoomType);
            Controls.Add(lblCapacity);
            Controls.Add(lblRoomType);
            Controls.Add(lblBuilding);
            Name = "frmAddRoom";
            Text = "frmAddRoom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuilding;
        private Label lblRoomType;
        private Label lblCapacity;
        private TextBox txtRoomType;
        private TextBox txtCapacity;
        private Button btnCancel;
        private Button btnSave;
    }
}
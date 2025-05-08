namespace WUMedCoProject.src
{
    partial class frmRooms
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
            lblRoomInfo = new Label();
            dgvRooms = new DataGridView();
            RoomID = new DataGridViewTextBoxColumn();
            RoomType = new DataGridViewTextBoxColumn();
            Capacity = new DataGridViewTextBoxColumn();
            flpButtons = new FlowLayoutPanel();
            btnExit = new Button();
            btnEdit = new Button();
            btnView = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            flpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblRoomInfo
            // 
            lblRoomInfo.AutoSize = true;
            lblRoomInfo.Location = new Point(12, 9);
            lblRoomInfo.Name = "lblRoomInfo";
            lblRoomInfo.Size = new Size(128, 15);
            lblRoomInfo.TabIndex = 0;
            lblRoomInfo.Text = "Rooms Information for";
            lblRoomInfo.TextAlign = ContentAlignment.TopCenter;
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Columns.AddRange(new DataGridViewColumn[] { RoomID, RoomType, Capacity });
            dgvRooms.Location = new Point(12, 27);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.Size = new Size(326, 311);
            dgvRooms.TabIndex = 1;
            dgvRooms.CellEndEdit += dgvRooms_CellEndEdit;
            // 
            // RoomID
            // 
            RoomID.HeaderText = "RoomID";
            RoomID.Name = "RoomID";
            RoomID.ReadOnly = true;
            // 
            // RoomType
            // 
            RoomType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RoomType.HeaderText = "Room Type";
            RoomType.Name = "RoomType";
            // 
            // Capacity
            // 
            Capacity.HeaderText = "Capacity";
            Capacity.Name = "Capacity";
            Capacity.Width = 75;
            // 
            // flpButtons
            // 
            flpButtons.Controls.Add(btnExit);
            flpButtons.Controls.Add(btnEdit);
            flpButtons.Controls.Add(btnView);
            flpButtons.FlowDirection = FlowDirection.RightToLeft;
            flpButtons.Location = new Point(12, 344);
            flpButtons.Name = "flpButtons";
            flpButtons.Size = new Size(326, 36);
            flpButtons.TabIndex = 2;
            // 
            // btnExit
            // 
            btnExit.DialogResult = DialogResult.OK;
            btnExit.Location = new Point(248, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 0;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(136, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(106, 23);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Enter Edit Mode";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnView
            // 
            btnView.Location = new Point(21, 3);
            btnView.Name = "btnView";
            btnView.Size = new Size(109, 23);
            btnView.TabIndex = 2;
            btnView.Text = "Enter View Mode";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // frmRooms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 392);
            Controls.Add(flpButtons);
            Controls.Add(dgvRooms);
            Controls.Add(lblRoomInfo);
            Name = "frmRooms";
            Text = "frmRooms";
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            flpButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRoomInfo;
        private DataGridView dgvRooms;
        private DataGridViewTextBoxColumn RoomID;
        private DataGridViewTextBoxColumn RoomType;
        private DataGridViewTextBoxColumn Capacity;
        private FlowLayoutPanel flpButtons;
        private Button btnExit;
        private Button btnEdit;
        private Button btnView;
    }
}
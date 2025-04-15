namespace WUMedCoProject
{
    partial class frmAdminLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminLogin));
            ichabodBackground = new PictureBox();
            lblNewAdmin = new LinkLabel();
            btnLogin = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            chkbxShowHidePW = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)ichabodBackground).BeginInit();
            SuspendLayout();
            // 
            // ichabodBackground
            // 
            ichabodBackground.Image = (Image)resources.GetObject("ichabodBackground.Image");
            ichabodBackground.InitialImage = null;
            ichabodBackground.Location = new Point(12, 57);
            ichabodBackground.Name = "ichabodBackground";
            ichabodBackground.Size = new Size(222, 222);
            ichabodBackground.TabIndex = 0;
            ichabodBackground.TabStop = false;
            // 
            // lblNewAdmin
            // 
            lblNewAdmin.AutoSize = true;
            lblNewAdmin.Location = new Point(421, 314);
            lblNewAdmin.Name = "lblNewAdmin";
            lblNewAdmin.Size = new Size(75, 15);
            lblNewAdmin.TabIndex = 1;
            lblNewAdmin.TabStop = true;
            lblNewAdmin.Text = "New Admin?";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ButtonHighlight;
            btnLogin.Location = new Point(271, 229);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(197, 50);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(271, 100);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "user name";
            txtUsername.Size = new Size(197, 31);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(271, 160);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "password";
            txtPassword.Size = new Size(197, 31);
            txtPassword.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(290, 36);
            label1.Name = "label1";
            label1.Size = new Size(158, 31);
            label1.TabIndex = 5;
            label1.Text = "WU MedCo";
            // 
            // chkbxShowHidePW
            // 
            chkbxShowHidePW.AutoSize = true;
            chkbxShowHidePW.Location = new Point(271, 197);
            chkbxShowHidePW.Name = "chkbxShowHidePW";
            chkbxShowHidePW.Size = new Size(138, 19);
            chkbxShowHidePW.TabIndex = 6;
            chkbxShowHidePW.Text = "Show/Hide Password";
            chkbxShowHidePW.UseVisualStyleBackColor = true;
            // 
            // frmAdminLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(508, 338);
            Controls.Add(chkbxShowHidePW);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(btnLogin);
            Controls.Add(lblNewAdmin);
            Controls.Add(ichabodBackground);
            MaximizeBox = false;
            Name = "frmAdminLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrator Login";
            Load += this.frmAdminLogin_Load;
            ((System.ComponentModel.ISupportInitialize)ichabodBackground).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ichabodBackground;
        private LinkLabel lblNewAdmin;
        private Button btnLogin;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label1;
        private CheckBox chkbxShowHidePW;
    }
}

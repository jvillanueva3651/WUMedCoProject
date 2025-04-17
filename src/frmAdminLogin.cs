using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WUMedCoProject
{
    public partial class frmAdminLogin : Form
    {
        private string ConnectionString => ConfigurationManager.ConnectionStrings["WUMedCo"].ConnectionString;
        public frmAdminLogin()
        {
            InitializeComponent();
        }

        /***********************************************************************
         * Method to handle new admin link click event
         **********************************************************************/
        private void lblNewAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNewAdmin formNewAdmin = new frmNewAdmin();
            formNewAdmin.Show();
        }

        /***********************************************************************
         * Method to handle login button click event
         **********************************************************************/
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be blank.", "Error");
                return;
            }

            try
            {
                bool isValid = ValidateAdmin(username, password);
                if (isValid)
                {
                    UpdateLastLogin(username);
                    MessageBox.Show("Login successful!", "Success");
                    src.frmAdminHome adminHomeForm = new src.frmAdminHome();
                    adminHomeForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error");
            }
        }

        /***********************************************************************
         * Method to show or hide password
         **********************************************************************/
        private void chkbxShowHidePW_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxShowHidePW.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        /***********************************************************************
         * Method to validate admin login
         **********************************************************************/
        private bool ValidateAdmin(string username, string password)
        {
            string storedHashedPassword = null;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT Password FROM AdminLogin WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    storedHashedPassword = result?.ToString();
                }
            }

            if (string.IsNullOrEmpty(storedHashedPassword)) return false;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] inputHashBytes = sha256.ComputeHash(inputBytes);
                string inputHash = Convert.ToBase64String(inputHashBytes);
                return storedHashedPassword == inputHash;
            }
        }

        /***********************************************************************
         * Method to update last login time
         **********************************************************************/
        private void UpdateLastLogin(string username)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "UPDATE AdminLogin SET LastLogin = @LastLogin WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LastLogin", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WUMedCoProject
{
    public partial class frmAdminLogin : Form
    {
        static SqlConnection conn = null!;
        static SqlCommand cmd = null!;
        static SqlDataReader reader = null!;
        public frmAdminLogin()
        {
            InitializeComponent();
            Database_Connection();
        }

        /***********************************************************************
         * Method to connect to database
         **********************************************************************/
        private void Database_Connection()
        {
            // Static connection string to connect to the database
            string url = WUMedCoPath._connectionString;

            conn = new SqlConnection(url);
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
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be blank.", "Error");
            }
            else
            {
                try
                {
                    bool isValid = ValidateAdmin(username, password);
                    if (isValid)
                    {
                        // Update the last login time in the database
                        using (SqlConnection connection = new SqlConnection(WUMedCoPath._connectionString))
                        {
                            string query = "UPDATE AdminLogin SET LastLogin = @LastLogin WHERE Username = @Username";
                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@LastLogin", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Username", username);

                                connection.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }

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
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected error: {ex.Message}", "Error");
                }
                finally
                {
                    conn.Close();
                }
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

            using (conn)
            {
                string query = "SELECT Password FROM AdminLogin WHERE Username = @Username";

                // Retrieve the hashed password from the database
                using (cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        storedHashedPassword = result?.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Database error: {ex.Message}", "Error");
                        return false;
                    }
                }

                // If the username does NOT exist, return false
                if (string.IsNullOrEmpty(storedHashedPassword)) { return false; }

                // Hash the input password and compare
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                    byte[] inputHashBytes = sha256.ComputeHash(inputBytes);
                    string inputHash = Convert.ToBase64String(inputHashBytes);

                    return CryptographicOperations.FixedTimeEquals(
                        Encoding.UTF8.GetBytes(storedHashedPassword),
                        Encoding.UTF8.GetBytes(inputHash)
                    );
                }
            }
        }
    }
}

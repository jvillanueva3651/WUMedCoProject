using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WUMedCoProject
{
    public partial class frmNewAdmin : Form
    {
        static SqlConnection conn = null!;
        static SqlCommand cmd = null!;
        static SqlDataReader reader = null!;
        public frmNewAdmin()
        {
            InitializeComponent();
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
         * Method to save new admin on button click
         **********************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if(ValidateInput(username, password))
            {
                SaveNewAdmin(username, password);
                this.Close();
            }
        }

        /***********************************************************************
         * Method to cancel out of new admin form on button click
         **********************************************************************/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /***********************************************************************
         * Method to validate text fields and password constraints
         **********************************************************************/
        private bool ValidateInput(string username, string password)
        {
            string msg = "";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                if (string.IsNullOrEmpty(username))
                {
                    msg += "Username cannot be blank.\n\n";
                }
                else
                {
                    msg += "Password cannot be blank.\n\n";
                }
            }
            else //I organized it this way so that password constraints are only checked if the user enters something. Otherwise if either is blank, it will show ALL error messages
            {
                if (password.Length < 8)
                {
                    msg += "Password must be at least 8 characters long.\n\n";
                }
                if (!password.Any(char.IsUpper))
                {
                    msg += "Password must contain at least one uppercase letter.\n\n";
                }
                if (!password.Any(char.IsLower))
                {
                    msg += "Password must contain at least one lowercase letter.\n\n";
                }
                if (!password.Any(char.IsDigit))
                {
                    msg += "Password must contain at least one digit.\n\n";
                }
                if (!password.Any(ch => "!@#$%^&*()_+[]{}|;:,.<>?".Contains(ch)))
                {
                    msg += "Password must contain at least one special character.\n\n";
                }
            }

            if(msg != "")
            {
                MessageBox.Show(msg, "Error");
                return false;
            }
            else { return true; }

        }

        /***********************************************************************
         * Method to save new admin to database
         **********************************************************************/
        private void SaveNewAdmin(string username, string password)
        {
            // Hash the password
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] inputHashBytes = sha256.ComputeHash(inputBytes);
                string hashedPassword = Convert.ToBase64String(inputHashBytes);

                // Connect and insert into database
                using (SqlConnection connection = new SqlConnection(WUMedCoPath._connectionString))
                {
                    string query = @"INSERT INTO AdminLogin (Username, Password) VALUES (@Username, @Password)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        try
                        {
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("New admin created successfully.", "Success");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show($"Database error: {ex.Message}", "Error");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }
    }
}

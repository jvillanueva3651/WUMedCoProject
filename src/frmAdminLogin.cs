namespace WUMedCoProject
{
    public partial class frmAdminLogin : Form
    {
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
            //TODO Add functionality to login
        }

        /***********************************************************************
         * Method to show or hide password
         **********************************************************************/
        private void chkbxShowHidePW_CheckedChanged(object sender, EventArgs e)
        {
            //TODO Add functinality to show/hide password
        }
    }
}

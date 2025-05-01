using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WUMedCoProject.src
{
    public partial class frmPatientCRUD : Form
    {
        public frmPatientCRUD()
        {
            InitializeComponent();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {


            frmPatient Patients = new frmPatient();
            Patients.Show();
        }
    }
}

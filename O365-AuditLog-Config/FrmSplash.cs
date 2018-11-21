using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O365_AuditLog_Extract
{
    public partial class FrmSplash : Form
    {
        private readonly string currentDirectory = Environment.CurrentDirectory;
        private readonly string configFileName = "settings.xml";

        public FrmSplash()
        {
            InitializeComponent();

            if (!File.Exists(currentDirectory + "//" + configFileName))
            {
                BtnProfile.Text = "Create New Profile";
            }
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            if (BtnProfile.Text == "Create New Profile")
            {
                this.Hide();
                FrmNewProfile frmNewProfile = new FrmNewProfile();
                frmNewProfile.Show();
            }
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {

        }
    }
}

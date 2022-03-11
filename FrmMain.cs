using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accountInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmProfile frmProfile = new FrmProfile();
            frmProfile.ShowDialog();
        }

        private void shopManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin frmAdmin = new frmAdmin();
            frmAdmin.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}

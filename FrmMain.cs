using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopManagement.Models;

namespace CoffeeShopManagement
{
    public partial class FrmMain : Form
    {
        static string abc="";
        public FrmMain(string text)
        {
            abc = text;
            InitializeComponent();
            
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accountInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmProfile frmProfile = new FrmProfile(abc);
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

        private void FrmMain_Load(object sender, EventArgs e)
        {
            using(var context = new CoffeeShopManagementContext())
            {
                Account acc = context.Accounts.Where(x => x.UserName == abc).FirstOrDefault();
                if(acc.Type ==0)
                {
                    adminToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

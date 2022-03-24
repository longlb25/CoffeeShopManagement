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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex==2)
            {
                loadDataCategory();
            }    
            else if(tabControl1.SelectedIndex==3)
            {
                loadDataAccount();
            }    
        }
        public void loadDataCategory()
        {
            dgvCategory.Rows.Clear();
            using (var context = new CoffeeShopManagementContext())
            {
                List<FoodCategory> list = context.FoodCategories.ToList();
                foreach (FoodCategory item in list)
                {
                    dgvCategory.Rows.Add(item.CategoryId, item.CategoryName);
                }
            }
        }
        public void loadDataAccount()
        {
            dgvAccount.Rows.Clear();
            using (var context = new CoffeeShopManagementContext())
            {
                List<Account> list = context.Accounts.ToList();
                foreach (Account item in list)
                {
                    dgvAccount.Rows.Add(item.UserName, item.FullName,item.DateOfBirth,item.Gender,item.PhoneNumber,item.Address);
                }
            }
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbCategoryId.Text = dgvCategory.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            tbCategoryName.Text = dgvCategory.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {          
            tbAccount.Text = dgvAccount.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            tbUsername.Text = dgvAccount.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            tbDob.Text = dgvAccount.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            bool gender = bool.Parse(dgvAccount.Rows[e.RowIndex].Cells["Column6"].Value.ToString());
            if (gender == true)
            {
                tbGender.Text ="male";
            }
            else
            {
                tbGender.Text = "female";
            }
            tbPhone.Text = dgvAccount.Rows[e.RowIndex].Cells["Column7"].Value.ToString();
            tbAddress.Text = dgvAccount.Rows[e.RowIndex].Cells["Column8"].Value.ToString();

        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string nameCate = tbCategoryName.Text;
            using (var context = new CoffeeShopManagementContext())
            {
                FoodCategory category = new FoodCategory();
                category.CategoryName = nameCate;
                context.FoodCategories.Add(category);
                context.SaveChanges();
            }
            loadDataCategory();

        }
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            using (var context = new CoffeeShopManagementContext())
            {
                Account account = context.Accounts.Where(x => x.UserName == tbAccount.Text).FirstOrDefault();
                context.Accounts.Remove(account);
                context.SaveChanges();
            }
            loadDataAccount();
        }

        private void tbCategoryId_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbCategoryId_MouseClick(object sender, MouseEventArgs e)
        {
            //tbCategoryId.Enabled = false;
        }

        private void tbCategoryId_Click(object sender, EventArgs e)
        {
            tbCategoryId.Enabled = false;
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string idCate = tbCategoryId.Text;
            string nameCate = tbCategoryName.Text;
            using (var context = new CoffeeShopManagementContext())
            {
                FoodCategory category = context.FoodCategories.Where(x => x.CategoryId == int.Parse(tbCategoryId.Text)).FirstOrDefault();
                category.CategoryName = nameCate;
                context.SaveChanges();
            }
            loadDataCategory();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}

using CoffeeShopManagement.Models;
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
    public partial class frmAdmin : Form
    {
        CoffeeShopManagementContext db ;
        public frmAdmin()
        {
            InitializeComponent();
            db= new CoffeeShopManagementContext();
            loadcbCategory();
            load(null);
        }
        void load(string key)
        {
            if (key == null)
            {
                dgvListFoods.DataSource = (from f in db.Foods
                                           join fc in db.FoodCategories on f.IdCategory equals fc.CategoryId
                                           select new { f.FoodId, f.FoodName, fc.CategoryName, f.Price }).ToList();
            }
            else
            {
                dgvListFoods.DataSource = (from f in db.Foods
                                           join fc in db.FoodCategories on f.IdCategory equals fc.CategoryId
                                           where f.FoodName.Contains(key)
                                           select new { f.FoodId, f.FoodName, fc.CategoryName, f.Price }).ToList();
            }
            dgvListFoods.ClearSelection();
            
        }
        private void dgvListFoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selected = dgvListFoods.Rows[e.RowIndex];

                tbId.Text = selected.Cells[0].Value.ToString();
                tbName.Text = selected.Cells[1].Value.ToString();
                nbPrice.Value = Convert.ToDecimal(selected.Cells[3].Value.ToString());
                cbCategory.SelectedIndex = cbCategory.FindString(selected.Cells[2].Value.ToString());
            }
            catch (Exception ex)
            {

            }


        }
        void loadcbCategory()
        {
            cbCategory.Items.Clear();
            cbCategory.DataSource = db.FoodCategories.ToList();
            cbCategory.DisplayMember = "categoryName";
            cbCategory.ValueMember = "categoryId";
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            //where b.IdBillNavigation.DateCheckIn >= dtpFromDate.Value && b.IdBillNavigation.DateCheckOut<=dtpToDate.Value select new {b.IdFoodNavigation.}
            dgvSales.DataSource = (from bi in db.BillInfos
                                   join b in db.Bills on bi.IdBill equals b.BillId
                                   join tf in db.TableFoods on b.IdTable equals tf.TableId
                                   join f in db.Foods on bi.IdFood equals f.FoodId
                                   where b.DateCheckIn >= dtpFromDate.Value && b.DateCheckOut <= dtpToDate.Value
                                   select new {tf.TableName, b.DateCheckIn,b.DateCheckOut,Total = f.Price*bi.Quantity}
                                   ).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            load(tbSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Food food = new Food();
            food.IdCategory = (int)cbCategory.SelectedValue;
            food.FoodName = tbName.Text;
            food.Price = (double)nbPrice.Value;
            db.Add(food);
            db.SaveChanges();
            MessageBox.Show("add food succesffully !");
            load(tbSearch.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Food food = db.Foods.Find(Convert.ToInt32(tbId.Text));
            food.IdCategory = (int)cbCategory.SelectedValue;
            food.FoodName = tbName.Text;
            food.Price = (double)nbPrice.Value;
            db.Update(food);
            db.SaveChanges();
            MessageBox.Show("update food succesffully !");
            load(tbSearch.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Do you want to remove {tbName.Text}?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                
                try
                {
                    db.Foods.Remove(db.Foods.Find(Convert.ToInt32(tbId.Text)));
                    db.SaveChanges();
                    load(tbSearch.Text);
                }
                catch
                {
                    MessageBox.Show("Cannot remove this food !");
                }
                
            }
            
          
        }
    }
}

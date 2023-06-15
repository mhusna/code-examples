using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListCategories();
            ListProducts();
        }

        private void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource = context.Products.ToList();
            }
        }

        private void ListProductsByCategory(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource = context.Products.Where(x=>x.CategoryId == categoryId).ToList();
            }
        }

        private void ListProductsByProductName(string productName)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgvProducts.DataSource = context.Products.Where(x => x.ProductName.Contains(productName)).ToList();
            }
        }

        private void ListCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                cmbCategory.DataSource = context.Categories.ToList();
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryId";
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListProductsByCategory(Convert.ToInt32(cmbCategory.SelectedValue));
            }
            catch {
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = tbxProductName.Text;

            if (string.IsNullOrEmpty(key))
                ListProducts();
            else
                ListProductsByProductName(key);
        }
    }
}

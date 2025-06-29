using NorthwindBusiness.Abstract;
using NorthwindBusiness.Concrete;
using NorthwindDataAccess.Concrete.EntityFramework;
using NorthwindDataAccess.NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWebFromsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }
        private IProductService _productService;
        private ICategoryService _categoryService;

        private void Form1_Load(object sender, EventArgs e)
        {

            LoadProducts();
            LoadCategories();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbxCategory_Enter(object sender, EventArgs e)
        {

        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }


        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(
                Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {
            }

        }

        private void tbxProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxProductName.Text))
            {
                dgwProduct.DataSource = _productService.GetProductsByName(tbxProductName.Text);
            }
            else
            {
                LoadProducts();
            }

        }
    }
}

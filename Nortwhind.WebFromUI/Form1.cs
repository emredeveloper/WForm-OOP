using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.Concrete.EntityFramework;
using Northwind.Business.DependencyResolvers.Ninject;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.NhHibernate;
using NorthWind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nortwhind.WebFromUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }
        private IProductService _productService;
        private ICategoryService _categoryService;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            comboBox1.DataSource= _categoryService.GetAll();
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryId";

            comboBox2.DataSource = _categoryService.GetAll();
            comboBox2.DisplayMember = "CategoryName";
            comboBox2.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dataGridView1.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var sectigimdeger = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
                dataGridView1.DataSource = sectigimdeger;
                //dataGridView1.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
                // MessageBox.Show(sectigimdeger.ToString());
            }
            catch 
            {

                
            }
        }

        private void tbxproductname_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxproductname.Text))
            {
                dataGridView1.DataSource = _productService.GetProductsByProductName(tbxproductname.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    CategoryId = Convert.ToInt32(comboBox1.SelectedValue),
                    ProductName = textBox1.Text,
                    QuantityPerUnit = textBox5.Text,
                    UnitPrice = Convert.ToDecimal(textBox3.Text),
                    UnitsInStock = Convert.ToInt16(textBox4.Text)
                });
                MessageBox.Show("Ürün kaydedildi");
                LoadProducts();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId= Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                ProductName = textBox8.Text,
                CategoryId = Convert.ToInt32(comboBox2.SelectedValue),
                UnitsInStock = Convert.ToInt16(textBox6.Text),
                QuantityPerUnit = textBox2.Text,
                UnitPrice = Convert.ToDecimal(textBox7.Text)
            });
            MessageBox.Show("Ürün güncelendi");
            LoadProducts();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();   
            textBox7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)
                    });
                    MessageBox.Show("Ürün silindi");
                    LoadProducts();
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message);
                }
                
            }
            
            
        }
    }
}

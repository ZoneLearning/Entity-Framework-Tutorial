using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Introduction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            NorthWindDataContext context = new NorthWindDataContext();

            dataGridView1.DataSource = context.Products;
            cmbCategory.DataSource = context.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
            cmbSupplier.DataSource = context.Suppliers;
            cmbSupplier.DisplayMember = "CompanyName";
            cmbSupplier.ValueMember = "SupplierID";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NorthWindDataContext context = new NorthWindDataContext();
            Product product = new Product();
            product.ProductName = txtProductName.Text;
            product.UnitPrice = nudPrice.Value;
            product.UnitsInStock = (short)nudStock.Value;
            product.CategoryID = (int)cmbCategory.SelectedValue;
            product.SupplierID = (int)cmbSupplier.SelectedValue;

            context.Products.InsertOnSubmit(product);
            /*Linq to sql data contexti yapılan değişiklikleri(insert,update,delete) doğrudan SQL koduna dönüştürmez. 
                Bunu yapmak için bir komut bekler.Şuana kadar yaptığın işlemleri database'e aktar demek için SubmitChanges() demek gerekir.
            Bunu diyene kadar DB değişmez.*/
            context.SubmitChanges();

            dataGridView1.DataSource = context.Products;
        }
    }
}

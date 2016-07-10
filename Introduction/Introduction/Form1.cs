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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int productId = (int)dataGridView1.CurrentRow.Cells["ProductID"].Value;
            NorthWindDataContext context = new NorthWindDataContext();
            //Lambda ya da Linq Expression.
            //Single--> tekil elaman seçmek için kullanılan metod. Sorguya gider, sadece ilk elemanı getirir.
            //Eger Single metodu birden fazla eleman secerse hata verir. Ayrıca istenilen elemanı bulamazsa hata verir. Bunun için SingleOrDefault metodu yazılmış.
            //Deger bulabilirse degeri getirir, bulamazsa null getirir.
            // => öyle ki demek
            //prd diyebir şey tanımlamadığım halde SingleOrDefault metodunu Products'a uyguladığım için prd'nin Product oldugunu anlıyor. (Lambda Expression)
            Product product = context.Products.SingleOrDefault(prd => prd.ProductID == productId);
            context.Products.DeleteOnSubmit(product);
            context.SubmitChanges();
            dataGridView1.DataSource = context.Products;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            txtProductName.Text = row.Cells["ProductName"].Value.ToString();
            //güncelleme sırasında id lazım olacagı içi onu cepe yani Tag'e atıyoruz.
            txtProductName.Tag = row.Cells["ProductID"].Value;
            cmbCategory.SelectedValue = row.Cells["CategoryID"].Value;
            cmbSupplier.SelectedValue = row.Cells["SupplierID"].Value;
            nudPrice.Value = (decimal)row.Cells["UnitPrice"].Value;
            nudStock.Value = (short)row.Cells["UnitsInStock"].Value;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int productId = (int)txtProductName.Tag;
            NorthWindDataContext context = new NorthWindDataContext();
            Product product = new Product();
            context.Products.SingleOrDefault(prd => prd.ProductID == productId);
            product.ProductName = txtProductName.Text;
            product.UnitPrice = nudPrice.Value;
            product.UnitsInStock = (short)nudStock.Value;
            product.CategoryID = (int)cmbCategory.SelectedValue;
            product.SupplierID = (int)cmbSupplier.SelectedValue;

            //update işlemini direk olarak algılıyor.
            //o yüzden direk submit yapıyoruz.
            context.SubmitChanges();

            dataGridView1.DataSource = context.Products;

        }
    }
}

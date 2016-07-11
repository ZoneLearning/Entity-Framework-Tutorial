using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqExpressions
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        NorthWindDataContext context = new NorthWindDataContext();

        private void button1_Click(object sender, EventArgs e)
        {

            var result = from product in context.Products
                         orderby product.UnitPrice
                         select product;
            dataGridView1.DataSource = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = from product in context.Products
                         orderby product.ProductName descending  // Z'den A'ya dogru
                         select product;
            // dataGridView1.DataSource = result;

            var result2 = from order in context.Orders
                          orderby order.OrderDate
                          descending
                          select order;
            dataGridView1.DataSource = result2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime tarih = Convert.ToDateTime(maskedTextBox1.Text);
            var result = from order in context.Orders
                         where order.OrderDate == tarih
                         select order;
            dataGridView1.DataSource = result;
        }
    }
}

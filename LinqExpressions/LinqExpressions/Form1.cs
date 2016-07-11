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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NorthWindDataContext context = new NorthWindDataContext();
            dataGridView1.DataSource = from p in context.Products
                                       join c in context.Categories on p.CategoryID equals c.CategoryID
                                       select new
                                       {
                                           p.ProductName,
                                           c.CategoryName,
                                           p.UnitPrice,
                                           p.UnitsInStock
                                       };
        }
    }
}

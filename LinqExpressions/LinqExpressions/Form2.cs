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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            NorthWindDataContext context = new NorthWindDataContext();
            dataGridView1.DataSource = from od in context.Order_Details
                                       join p in context.Products
                                       on od.ProductID equals p.ProductID
                                       select new
                                       {
                                           p.ProductName,
                                           p.UnitPrice,
                                           OrderPrice = od.UnitPrice,
                                           od.Quantity,
                                           od.Discount

                                       };

        }
    }
}

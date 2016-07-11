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
            //Order Detail tablosu ve Product tablosunu join yapıp ürün adı, satış fiyatı, adeti ve indirimi gridview'e yazan linq expression.
            /* NorthWindDataContext context = new NorthWindDataContext();
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

                                        };  */

            /* ürün adı, ürün fiyatı,tedarikci adı, kategori adı, satış fiyatı, satış mikatı, indirim, Müşteri Adı, personel adı-soyadı yazdırma.
             */

            NorthWindDataContext context = new NorthWindDataContext();
            dataGridView1.DataSource = from orderdetails in context.Order_Details
                                       join product in context.Products
                                       on orderdetails.ProductID equals product.ProductID
                                       join order in context.Orders on orderdetails.OrderID equals order.OrderID
                                       join customer in context.Customers on order.CustomerID equals customer.CustomerID
                                       join employee in context.Employees on order.EmployeeID equals employee.EmployeeID
                                       join supplier in context.Suppliers on product.SupplierID equals supplier.SupplierID
                                       join category in context.Categories on product.CategoryID equals category.CategoryID
                                       select new
                                       {
                                           product.ProductName,
                                           product.UnitPrice,
                                           Tedarikci = supplier.CompanyName,
                                           category.CategoryName,
                                           OrderPrice = orderdetails.UnitPrice,
                                           orderdetails.Quantity,
                                           orderdetails.Discount,
                                           customer.CompanyName,
                                           Personel = employee.FirstName + " " + employee.LastName
                                       };

        }
    }
}

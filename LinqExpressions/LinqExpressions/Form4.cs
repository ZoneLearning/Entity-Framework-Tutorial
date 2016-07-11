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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //Hangi personel kaç tane satış yapmıştır.

            NorthWindDataContext context = new NorthWindDataContext();
            var result = from order in context.Orders
                         join employee in context.Employees on order.EmployeeID equals employee.EmployeeID
                         group order by employee.FirstName into myGroup
                         select new
                         {
                             FirstName = myGroup.Key,
                             TotalOrder = myGroup.Count()

                         };

            dataGridView1.DataSource = result;


        }
    }
}

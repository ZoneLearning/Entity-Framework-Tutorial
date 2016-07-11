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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            NorthWindDataContext context = new NorthWindDataContext();

            //gelecek olan veri tipini bilinmiyorsa var ile tanımlayabiliriz. var ile tanımlamak icin, tanımlanır tanımlnamaz = ile deger atamamız gerekli.

            var result = from product in context.Products
                         join orderdetail in context.Order_Details
                         on product.ProductID equals orderdetail.ProductID
                         group orderdetail by product.ProductName into myGroup // gruplandıktan sonra yei bir eleman ortaya cıkıyor. myGroup.
                         select new
                         {
                             ProductName = myGroup.Key,
                             TotalOrder = myGroup.Sum(x => x.UnitPrice * x.Quantity)  // Bu yüzden product ve order detai ile sutunlara ulaşamam. myGroup ile ulaşılacak.
                         };


            var result2 = from product in context.Products
                          select new
                          {
                              product.ProductName,
                              // her tablonun baglı oldugu tablo il ilgili bilgisi vardır.Linq bunu property olarak belirlemiştir. product'ın Order_Details property'is örneği gibi.
                              TotalOrder = product.Order_Details.Any()?product.Order_Details.Sum(x=>x.UnitPrice*x.Quantity):0  // Any() var mı diye kontrol etmek icindir.

                          };

            dataGridView1.DataSource = result2;
        }
    }
}

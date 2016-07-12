using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DTO.Product
{
    // Sadece ürün için bir sürü DTO olabilir. DTO içine Product isimili klasör açıyoruz. Her DTO için klasör açılabilir.

    public class ListProductDTO
    {
        // Kolaylık olsun diye ORM'den Product ile ilgili property'leri alıyorum.

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DTO.Product
{
    public class AddProductDTO
    {
        //UI bana bu bilgileri gönderse eklerim diyorum.
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public short UnitsInStock { get; set; }
    }
}

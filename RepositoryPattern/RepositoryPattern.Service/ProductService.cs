using RepositoryPattern.DTO.Product;
using RepositoryPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Service
{
    public class ProductService
    {
        //Arayüzden nelere ihtiyaç duyuluyorsa
        //DTO'nun geldiği ve repository'e iletilmesi gereken istekler
        //listeleme, ekleme, silme, güncelleme istegi gelebilir.

        //ürün listelenirken hangi alanların gideceğini belirlemek lazım. Ve servis sınfında nasıl olacagını DTO'da belirlemek lazım.

        ProductRepository repository = new ProductRepository();
        public IList<ListProductDTO> getList() // DTO nesnesine dönüştürerek gönderdik.
        {
            return repository.getList().Select(   // repositor'den normal nesneyi edip
                x => new ListProductDTO
                {
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock,
                    ProductID = x.ProductID,
                    ReorderLevel = x.ReorderLevel,
                    QuantityPerUnit = x.QuantityPerUnit,
                    CategoryID=x.CategoryID,
                    SupplierID = x.SupplierID,
                    Discontinued=x.Discontinued,
                    UnitsOnOrder = x.UnitsOnOrder
                }
                ).ToList();
        }

    }
}

using RepositoryPattern.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Repository
{
    public class ProductRepository : RepositoryBase<Product>
    {
        //insert,select,update,delete işlemleri base class'da var. Burayı Product ile ilgili extra sorgular için kullanıyoruz.
        public void Barter(Product gotton, Product given) // takas metodu
        {

        }
    }
}

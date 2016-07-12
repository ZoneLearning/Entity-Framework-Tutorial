using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.ORM.Models;

namespace RepositoryPattern.Repository
{
    public class RepositoryBase<T> where T : class
    {
        private static NORTHWNDContext context; // tekil elaman = static

        //singleton pattern : projede içerisnde kullanılacak bir nesnenin instance'nın bir tane instance'ı alınarak birden fazla yerde aynısını kullanmak için.
        public NORTHWNDContext Context
        {
            get
            {
                if (context == null)
                    context = new NORTHWNDContext();

                return context;
            }
            set { context = value; }
        }

        public IList<T> getList()
        {
            return Context.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
            //ekleme işleminden sonra context'i yenilemek lazım.
            Context = new NORTHWNDContext();
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
            Context = new NORTHWNDContext();
        }
        //güncelle metodu parametre almıyor
        public void Update()
        {
            Context.SaveChanges();
        }
    }
}

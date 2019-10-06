using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Training.DomainModel;

namespace Training.Dal.Repositories
{
    public interface IProductRepository
    {
        void Add(Product p);
        IQueryable<Product> List(params Expression<Func<Product,object>>[] include); //read
        Product Get(int productId); //read
        void Update(Product p); 
        // void Update<T> (int productId, T p);
        // void Delete(Product p);
        void Delete(int productId);
    }
}

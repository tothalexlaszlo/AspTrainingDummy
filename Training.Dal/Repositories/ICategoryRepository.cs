using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DomainModel;

namespace Training.Dal.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category p);
        IQueryable<Category> List(); //read
        Category Get(int categoryId); //read
        void Update(Category p); 
        // void Update<T> (int productId, T p);
        // void Delete(Category p);
        void Delete(int categoryId);
    }
}

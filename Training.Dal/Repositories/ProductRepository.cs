using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Training.DomainModel;

namespace Training.Dal.Repositories
{
    public class EntityFrameworkProductRepository : IProductRepository
    {
        private readonly TrainingModel trainingModel;

        public EntityFrameworkProductRepository(TrainingModel trainingModel)
        {
            this.trainingModel = trainingModel;
        }

        public void Add(Product p)
        {
            trainingModel.Products.Add(p);
        }

        public void Delete(int productId)
        {
            var obj = trainingModel.Products.Find(productId);
            trainingModel.Products.Remove(obj);
        }

        public Product Get(int productId)
        {
            return trainingModel.Products.Find(productId);
        }

        public IQueryable<Product> List(params Expression<Func<Product,object>>[] includes)
        {
            IQueryable<Product> products = trainingModel.Products;
            foreach (var include in includes)
            {
                products = products.Include(include);
            }
            return products;
        }

        public void Update(Product p)
        {
            var entry = trainingModel.Entry(p);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                trainingModel.Products.Attach(p);
                trainingModel.Entry(p).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                trainingModel.Entry(p).CurrentValues.SetValues(p);
            }
        }
    }
}

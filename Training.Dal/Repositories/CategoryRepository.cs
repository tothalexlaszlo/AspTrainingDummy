using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DomainModel;

namespace Training.Dal.Repositories
{
    public class EntityFrameworkCategorytRepository : ICategoryRepository
    {
        private readonly TrainingModel trainingModel;

        public EntityFrameworkCategorytRepository(TrainingModel trainingModel)
        {
            this.trainingModel = trainingModel;
        }

        public void Add(Category c)
        {
            trainingModel.Categories.Add(c);
        }

        public void Delete(int categoryId)
        {
            var obj = trainingModel.Categories.Find(categoryId);
            trainingModel.Categories.Remove(obj);
        }

        public Category Get(int categoryId)
        {
            return trainingModel.Categories.Find(categoryId);
        }

        public IQueryable<Category> List()
        {
            return trainingModel.Categories;
        }

        public void Update(Category c)
        {
            var entry = trainingModel.Entry(c);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                trainingModel.Categories.Attach(c);
                trainingModel.Entry(c).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                trainingModel.Entry(c).CurrentValues.SetValues(c);
            }
        }
    }
}

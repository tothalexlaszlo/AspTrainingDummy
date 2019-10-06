using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Dal.Repositories;

namespace Training.Dal
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        private readonly TrainingModel trainingModel;

        public EntityFrameworkUnitOfWork(ICategoryRepository categoryRepository,
                                         IProductRepository productRepository,
                                         TrainingModel trainingModel)
        {
            this.CategoryRepository = categoryRepository;
            this.ProductRepository = productRepository;
            this.trainingModel = trainingModel;
        }
        public void Commit()
        {
            trainingModel.SaveChanges();
        }
    }
}

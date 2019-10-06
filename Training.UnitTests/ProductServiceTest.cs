using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Training.Bll;
using Training.Dal;
using Training.Dal.Repositories;
using Training.DomainModel;

namespace Training.UnitTests
{
    // Moq keretrendszer false adatok generálásához
    public class TestUnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public TestUnitOfWork(IProductRepository productRepository)
        {
            this.ProductRepository = productRepository;
        }
    }

    public class TestProductRepository : IProductRepository
    {
        private readonly List<Product> fakeDataSource;

        public TestProductRepository(List<Product> products)
        {
            this.fakeDataSource = products;
        }

        public void Add(Product p)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public Product Get(int productId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> List(params Expression<Func<Product, object>>[] include)
        {
            return fakeDataSource.AsQueryable();
        }

        public void Update(Product p)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class ProductServiceTest
    {
        [Test]
        public void TestGetAvaibleProducts()
        {
            var input = new List<Product>
            {
                new Product { ProductID=1, Discontinued=true },
                new Product { ProductID=2, Discontinued=false }
            };

            var m = new ProductService(
                        new TestUnitOfWork(
                            new TestProductRepository(input)));

            var output = m.GetAvaibleProducts();

            Assert.That(output.Count == 1);
            Assert.That(output.Single().ProductID == 2);
        }
         
    }
}

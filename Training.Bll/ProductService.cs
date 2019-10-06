using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Dal;
using Training.DomainModel;
using System.Data.Entity;

namespace Training.Bll
{
    public class ProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IReadOnlyList<Product> GetAvaibleProducts()
        {
           
            return
                    unitOfWork.ProductRepository.List(p=>p.Category) // A List hívja meg az Include-t paraméterként, ez így helyes hogy átkerült a ProductRepository-ba DAL-ba.
                                                /*.Include(p => p.Category)  explicit kényszerítjük hogy töltse be a Category táblát is az Include-al
                                                 Ez Entity Framework-s ezért innen ki kell írtani BLL ne tartalmazzon EF-t*/
                                                .Where(p => !p.Discontinued)
                                                .ToList();
        }

        public IReadOnlyList<Product> GetUnavailableProducts()
        {
            return
                unitOfWork.ProductRepository.List(p => p.Category)
                                            .Where(p => p.Discontinued)
                                            .ToList();
        }

        public IReadOnlyList<Product> GetAvailableProducts(int categoryId)
        {
            return
                unitOfWork.ProductRepository.List(p => p.Category)
                          .Where(p=>!p.Discontinued && p.CategoryID==categoryId)
                          .ToList();
        }

        public void CreateProduct(Product newProduct)
        {
            newProduct.Discontinued = false;
            newProduct.ReorderLevel = 0;
            newProduct.UnitsInStock = 0;
            newProduct.UnitsOnOrder = 0;

            unitOfWork.ProductRepository.Add(newProduct);
            unitOfWork.Commit();
        }

        public void UpdateProduct(Product product)
        {
            unitOfWork.ProductRepository.Update(product);
            unitOfWork.Commit();
        }

        public void DeleteProduct(int productId)
        {
            unitOfWork.ProductRepository.Delete(productId);
            unitOfWork.Commit();
        }

        public Product GetProduct(int productId)
        {
            return unitOfWork.ProductRepository.Get(productId);

        }

        public IReadOnlyList<Product> GetAvailableProducts(decimal? minPrice, decimal? maxPrice)
        {
            var query = unitOfWork.ProductRepository.List(p => p.Category).Where(p => !p.Discontinued);
            if (minPrice.HasValue)
            {
                query = query.Where(p => p.UnitPrice >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.UnitPrice <= maxPrice.Value);
            }

            return query.ToList();
        }
    }
}

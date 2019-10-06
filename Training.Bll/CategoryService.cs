using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Dal;
using Training.DomainModel;

namespace Training.Bll
{
    public class CategoryService
    {
        private readonly IUnitOfWork unitOfwork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfwork = unitOfWork;
        }

        public IReadOnlyList<Category> GetCategories()
        {
            return this.unitOfwork.CategoryRepository.List().ToList();
        }

        //Web Api-s
        public Category CreateCategory(Category newCategory)
        {
            this.unitOfwork.CategoryRepository.Add(newCategory);
            this.unitOfwork.Commit();
            return newCategory;
        }

        //MVC-s
        //public void CreateCategory(Category newCategory)
        //{
        //    this.unitOfwork.CategoryRepository.Add(newCategory);
        //    this.unitOfwork.Commit();
        //}

        public Category GetACategory(int categoryId)
        {
            return
                this.unitOfwork.CategoryRepository.Get(categoryId);
        }

        public void UpdateCategory(Category modified)
        {
            this.unitOfwork.CategoryRepository.Update(modified);
            this.unitOfwork.Commit();
        }

        public void DeleteCategory(int id)
        {
            this.unitOfwork.CategoryRepository.Delete(id);
            this.unitOfwork.Commit();
        }
    }
}

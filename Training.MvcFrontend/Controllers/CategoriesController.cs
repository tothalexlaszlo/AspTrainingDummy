using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training.Bll;
using Training.DomainModel;
using Training.MvcFrontend.Models;

namespace Training.MvcFrontend.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoriesController : Controller
    {
        private readonly CategoryService categoryService;
        public CategoriesController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: Categories
        public ActionResult List()
        {
            var categories = categoryService.GetCategories();
            return View(Mapper.Map<List<ListCategoryViewModel>>(categories));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel input)
        {
            //HttpContext.User.Identity. a bejelentkezett felhasználót innen érjük el ha ha van [Authorize] 

            // Ha vannak saját attributumok kézzel ellenőrizni kell a ModelState-t
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            categoryService.CreateCategory(Mapper.Map<Category>(input)); // model- viewmodel mappelése
            return RedirectToAction(nameof(List)); // A megadott nevű Actionre átirányít a végén
        }

        public ActionResult Edit(int id)
        {
            var category = categoryService.GetACategory(id);

            return
                View(Mapper.Map<EditCategoryViewModel>(category));
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel editCategoryViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(editCategoryViewModel);
            }

            categoryService.UpdateCategory(Mapper.Map<Category>(editCategoryViewModel));
            return RedirectToAction(nameof(List));
        }

        public ActionResult Delete(int id)
        {
            categoryService.DeleteCategory(id);
            return RedirectToAction(nameof(List));
        }

    }
}
using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training.Bll;
using Training.Dal;
using Training.Dal.Repositories;
using Training.DomainModel;
using Training.MvcFrontend.Models;

namespace Training.MvcFrontend.Controllers
{
    [Authorize] // Garantálja hogy a controller osszes muvelete csak bejelenkezes utan erheto el, rá lehet rakni csak egyes actionokre is
    public class ProductsController : Controller
    {
        private readonly ProductService productService;
        private readonly CategoryService categoryService;

        public ProductsController(ProductService productService, CategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        // GET: Products
        public ActionResult List()
        {
            // objektum gráf létrehozása
            //using (var trainingModel = new TrainingModel())
            //{
            //    ProductService productService =
            //            new ProductService(
            //                new EntityFrameworkUnitOfWork(
            //                    new EntityFrameworkCategorytRepository(trainingModel),
            //                    new EntityFrameworkProductRepository(trainingModel),
            //                    trainingModel
            //            ));

         var available = productService.GetAvaibleProducts();

            //ViewModel létrehozása
            //var productVms = avaibleProducts.Select(
            //    p => new ListProductsViewModel
            //    {
            //        CategoryName = p.Category.CategoryName,
            //        ProductName = p.ProductName,
            //        QuantityPerUnit = p.QuantityPerUnit,
            //        UnitPrice = p.UnitPrice.Value,
            //        UnitsInStock = p.UnitsInStock.Value
            //    }).ToList();
         var productVms = Mapper.Map<List<ListProductsViewModel>>(available);

         return View(productVms); // itt adom át a View-nak a Model-t amivel dolgoznia kell! ez a View-ban = Model

        }

        public ActionResult ListUnavailable()
        {
            var unavailableProducts = productService.GetUnavailableProducts();
            return View("List", Mapper.Map<List<ListProductsViewModel>>(unavailableProducts));
        }

        public ActionResult ListForCategory(int categoryId) // meghívása   ..../Products/ListForCategory?categoryId=1
        {
            var products = productService.GetAvailableProducts(categoryId);
            return View("List", Mapper.Map<List<ListProductsViewModel>>(products));
        }

        public ActionResult Delete(int id)
        {
            productService.DeleteProduct(id);
            return RedirectToAction(nameof(List));
        }

        public ActionResult Create()
        {
            ViewBag.Categories = categoryService.GetCategories();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateProductViewModel createProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createProductViewModel);
            }
            productService.CreateProduct(Mapper.Map<Product>(createProductViewModel));
            return RedirectToAction(nameof(List));
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Categories = categoryService.GetCategories();
            return View(Mapper.Map<EditProductViewModel>(productService.GetProduct(id)));
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel editProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editProductViewModel);
            }

            productService.UpdateProduct(Mapper.Map<Product>(editProductViewModel));
            return RedirectToAction(nameof(List));
        }

        public ActionResult GetAllProducts()
        {
            var available = productService.GetAvaibleProducts();
            return View(Mapper.Map<List<ListProductsViewModel>>(available));
        }

        //[HttpPost]
        //public ActionResult GetFilteredProducts(decimal? minPrice, decimal? maxPrice)
        //{
        //    var availableProducts = productService.GetAvailableProducts(minPrice,maxPrice);
        //    return View(Mapper.Map<List<ListProductsViewModel>>(availableProducts));

        //}

        public ActionResult GetFilteredProducts(decimal? minPrice, decimal? maxPrice)
        {
            var availableProducts = productService.GetAvailableProducts(minPrice, maxPrice);
            return Json(
                Mapper.Map<List<ListProductsViewModel>>(availableProducts),
                JsonRequestBehavior.AllowGet);
        }
    }
}
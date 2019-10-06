using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Training.Bll;
using Training.DomainModel;
using Training.RestInterface.Models;

namespace Training.RestInterface.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesApiController : ApiController
    {
        private readonly CategoryService categoryService;
        public CategoriesApiController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetCategories()
        {
            var categories = categoryService.GetCategories(); // BLL végrehajtása
            var dtos = Mapper.Map<List<ListCategoryDto>>(categories); // model átalakítás
            return Ok(dtos); // válaszkód ( body )  http 200
        }
        
        [HttpPost, Route("")]
        public IHttpActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Http 400
            }
            var newCategory = categoryService.CreateCategory(Mapper.Map<Category>(createCategoryDto));
            return CreatedAtRoute("GetACategory", new { id = newCategory.CategoryID }, Mapper.Map<ListCategoryDto>(newCategory));
        }

        [HttpGet, Route("{id}", Name = "GetACategory")]
        public IHttpActionResult GetCategory(int id)
        {
            var category = categoryService.GetACategory(id);
            if (category==null)
            {
                return NotFound(); // http 404
            }
            return Ok(Mapper.Map<ListCategoryDto>(category));
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return Conflict(); // http 409
            }

            categoryService.DeleteCategory(id);
            return Ok(); // NoContent();
        }

        //    [HttpPut, Route("{id}")]
        //    public IHttpActionResult UpdateCategory(int id)
        //    {
        //    }

    }
}
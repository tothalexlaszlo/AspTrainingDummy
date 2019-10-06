using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Training.DomainModel;
using Training.MvcFrontend.Models;

namespace Training.MvcFrontend.App_Start
{
    static public class AutoMapperConfig
    {
        public static void Configure()
        {
            // Azt kell megmondani mit miből szeretnél csinálni
            // Productból hogyan leszt majd ListProductViewModel

            //Megnézi őket milyen propertik vannak bennük és az azonosakat átmásolja
           Mapper.Initialize(cfg =>
           {
               cfg.CreateMap<Product, ListProductsViewModel>()
                  .ForMember(vm => vm.CategoryName,
                             config => config.MapFrom(p => p.Category.CategoryName)
                            );
               cfg.CreateMap<Category, ListCategoryViewModel>()
                  .ForMember(vm => vm.Image,
                             config => config.MapFrom( c => Convert.ToBase64String(c.Picture.Skip(78).ToArray()))
                             );
               cfg.CreateMap<CreateCategoryViewModel, Category>();
               cfg.CreateMap<Category, EditCategoryViewModel>().ReverseMap(); // oda vissza megcsinálja
               cfg.CreateMap<CreateProductViewModel, Product>();
               cfg.CreateMap<EditProductViewModel, Product>().ReverseMap();
               
           });

        }
    }
}
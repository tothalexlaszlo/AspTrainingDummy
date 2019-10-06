using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Training.DomainModel;
using Training.RestInterface.Models;

namespace Training.RestInterface.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, ListCategoryDto>();
                cfg.CreateMap<CreateCategoryDto, Category>();
            });
        }
    }
}
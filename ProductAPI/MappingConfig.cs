using AutoMapper;
using OnlineApp.Services.ProductAPI.Models;
using OnlineApp.Services.ProductAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineApp.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
             {
                 config.CreateMap<ProductDto, Product>();
                 config.CreateMap<Product, ProductDto>();
             });

            return mappingConfig;
        }
    }
}

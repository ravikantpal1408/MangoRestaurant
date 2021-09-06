using System;
using AutoMapper;
using Mango.Services.ProductAPI.DbContexts.Dtos;
using Mango.Services.ProductAPI.DbContexts.Models;

namespace Mango.Services.ProductAPI
{
    public class MappingConfig
    {
        public MappingConfig()
        {
        }
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}

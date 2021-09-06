﻿using System;
using System.Threading.Tasks;
using Mango.Web.Models;

namespace Mango.Web.Services.IService
{
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto product);
        Task<T> UpdateProductAsync<T>(ProductDto product);
        Task<T> DeleteProductAsync<T>(int id);
    }
}

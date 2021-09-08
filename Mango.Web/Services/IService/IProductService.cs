using System;
using System.Threading.Tasks;
using Mango.Web.Models;

namespace Mango.Web.Services.IService
{
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(int id, string token);
        Task<T> CreateProductAsync<T>(ProductDto product, string token);
        Task<T> UpdateProductAsync<T>(ProductDto product, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}

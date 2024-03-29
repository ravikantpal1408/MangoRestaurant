﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Mango.Web.Models;
using Mango.Web.Services.IService;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {

        private readonly IHttpClientFactory client;

        public ProductService(IHttpClientFactory client): base (client)
        {
            this.client = client;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto product, string token)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
                            {
                                ApiType = SD.ApiType.POST,
                                Data = product,
                                Url = SD.ProductAPIBase + "/api/products/",
                                AccessToken = token
            });

            return result;
        }

        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/products/"+id,
                AccessToken = token
            });

            return result;
        }

        public async Task<T> GetAllProductAsync<T>(string token)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = token
            });

            return result;
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products/" + id,
                AccessToken = token
            });

            return result;
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto product, string token)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = product,
                Url = SD.ProductAPIBase + "/api/products/",
                AccessToken = token
            });

            return result;
        }
    }
}

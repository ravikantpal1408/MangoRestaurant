using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.DbContexts.Dtos;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Authorize]
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto response;

        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this.response = new ResponseDto();
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<object> Get()
        {
            try
            {
                var result = await _productRepository.GetProducts();
                response.IsSuccess = true;
                response.Result = result;
               
            }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>()
                {
                    e.ToString()
                };
            }

            return response;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var result = await _productRepository.GetProductById(id);
                response.IsSuccess = true;
                response.Result = result;

            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>()
                {
                    e.ToString()
                };
            }

            return response;
        }


        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto product)
        {
            try
            {
                var result = await _productRepository.CreateUpdateProduct(product);
                response.IsSuccess = true;
                response.Result = result;

            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>()
                {
                    e.ToString()
                };
            }

            return response;
        }


        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto product)
        {
            try
            {
                var result = await _productRepository.CreateUpdateProduct(product);
                response.IsSuccess = true;
                response.Result = result;

            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>()
                {
                    e.ToString()
                };
            }

            return response;
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var result = await _productRepository.DeleteProduct(id);
                response.IsSuccess = true;
                response.Result = result;

            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>()
                {
                    e.ToString()
                };
            }

            return response;
        }


    }
}

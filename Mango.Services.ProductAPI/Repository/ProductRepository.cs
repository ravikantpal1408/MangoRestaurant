using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.DbContexts.Dtos;
using Mango.Services.ProductAPI.DbContexts.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDBContext _context;
        private IMapper _mapper;

        public ProductRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);
            if(product.ProductId > 0)
            {
                _context.Products.Update(product);
            }
            else
            {
                _context.Products.Add(product);
            }
            await _context.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var result = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

                if(result == null)
                {
                    return false;
                }

                _context.Products.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var result = await _context.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            var mapped_result = _mapper.Map<ProductDto>(result);
            return mapped_result;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var result = await _context.Products.ToListAsync();
            var map_result = _mapper.Map<List<ProductDto>>(result);
            return map_result;
        }
    }
}

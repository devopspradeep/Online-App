using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineApp.Services.ProductAPI.DBContexts;
using OnlineApp.Services.ProductAPI.IRepository;
using OnlineApp.Services.ProductAPI.Models;
using OnlineApp.Services.ProductAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineApp.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;
        private IMapper mapper;
        public ProductRepository(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            this.dbContext = _dbContext;
            this.mapper = _mapper;
        }
        public async Task<ProductDto> CreateUpdateproduct(ProductDto productDto)
        {
            Product product = mapper.Map<ProductDto, Product>(productDto);
            if(product.ProductId>0)
            {
                dbContext.Products.Update(product);
            }
            else
            {
                dbContext.Products.Add(product);
            }
            await dbContext.SaveChangesAsync();
            return mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await dbContext.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
                if (product == null)
                {
                    return false;
                }
                else
                {
                    dbContext.Remove(product);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await dbContext.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return mapper.Map<ProductDto>(product);
            
         }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            IEnumerable<Product> products = await dbContext.Products.ToListAsync();
            return mapper.Map<List<ProductDto>>(products);
        }
    }
}

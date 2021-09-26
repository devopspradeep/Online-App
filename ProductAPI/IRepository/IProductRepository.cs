using OnlineApp.Services.ProductAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineApp.Services.ProductAPI.IRepository
{
   public interface IProductRepository
    {
       Task<IEnumerable<ProductDto>> GetProducts();
       Task<ProductDto> GetProductById(int productId);
       Task<ProductDto> CreateUpdateproduct(ProductDto productDto);
       Task<bool> DeleteProduct(int productId);
    }
}

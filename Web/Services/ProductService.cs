using OnlineApp.Web.UI.IServices;
using OnlineApp.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineApp.Web.UI.Services
{
    public class ProductService : BaseService, IProductService
    {
        IHttpClientFactory httpClientFactory;
        public ProductService(IHttpClientFactory _httpClientFactory):base(_httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
        }
        public Task<T> CreateProductAsync<T>(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteProductAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllProductsAsync<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllProductsByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateProductAsync<T>(ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}

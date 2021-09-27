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
        public async Task<T> CreateProductAsync<T>(ProductDto product)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType=StaticConfiguration.ApiType.POST,
                Data=product,
                Url=StaticConfiguration.ProductAPIBase+"/api/products",
                AccessToken=""
            });

        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticConfiguration.ApiType.DELETE,
                Url = StaticConfiguration.ProductAPIBase + "/api/products/"+id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticConfiguration.ApiType.GET,
                Url = StaticConfiguration.ProductAPIBase + "/api/products/",
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticConfiguration.ApiType.GET,
                Url = StaticConfiguration.ProductAPIBase + "/api/products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto product)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticConfiguration.ApiType.PUT,
                Data = product,
                Url = StaticConfiguration.ProductAPIBase + "/api/products/",
                AccessToken = ""
            });
        }
    }
}

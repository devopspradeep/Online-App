using Microsoft.AspNetCore.Mvc;
using OnlineApp.Services.ProductAPI.IRepository;
using OnlineApp.Services.ProductAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineApp.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto response;
        private IProductRepository repository;
        public ProductAPIController(IProductRepository _productRepository)
        {
            repository = _productRepository;
            this.response = new ResponseDto();
        }
        [HttpGet]
        public async Task<Object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await repository.GetProducts();
                response.Result = productDtos;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = new List<string>()
                {
                    ex.ToString()
                };
            }
            return response;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<Object> Get(int id)
        {
            try
            {
                ProductDto productDto = await repository.GetProductById(id);
                response.Result = productDto;

            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.ErrorMessage = new List<string>()
                {
                    ex.ToString()
                };
            }
            return response;
        }

        [HttpPost]
        public async Task<Object> Post([FromBody] ProductDto product)
        {
            try
            {
                ProductDto model = await repository.CreateUpdateproduct(product);
                response.Result = model;

            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.ErrorMessage = new List<string>()
                {
                    ex.ToString()
                };
            }
            return response;
        }

        [HttpPut]
        public async Task<Object> Put([FromBody] ProductDto product)
        {
            try
            {
                ProductDto model = await repository.CreateUpdateproduct(product);
                response.Result = model;

            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.ErrorMessage = new List<string>()
                {
                    ex.ToString()
                };
            }
            return response;
        }

        [HttpDelete]
        public async Task<Object> Delete(int id)
        {
            try
            {
                bool isSuccess = await repository.DeleteProduct(id);
                response.Result = isSuccess;

            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.ErrorMessage = new List<string>()
                {
                    ex.ToString()
                };
            }
            return response;
        }
    }

}

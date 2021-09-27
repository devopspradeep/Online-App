using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineApp.Web.UI.IServices;
using OnlineApp.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineApp.Web.UI.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("Index")]
        public  async Task<IActionResult> Index()
        {
            List<ProductDto> list = new ();
            var response = await _productService.GetAllProductsAsync<ResponseDto>();
            if(response !=null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }    
            return View(list);
        }
    }
}

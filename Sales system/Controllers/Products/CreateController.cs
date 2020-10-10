using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Product;
using Sales_system.Models.Request.Product;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Products
{
    [ApiController]
    [Route("products/[controller]")]
    [Authorize]
    public class CreateController : ControllerBase
    {
        private readonly IProductService _productService;

        public CreateController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Post(ProductCreateRequest request)
        {
            var response = new Response();
            try
            {
                _productService.PublishNew(request);
                response.Message = "Se ha creado el producto correctamente";
                response.Success = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                response.Message = exception.Message;
            }

            return Ok(response);
        }
    }
}
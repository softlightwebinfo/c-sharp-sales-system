using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Product;
using Sales_system.Models.Request.Product;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Products
{
    [ApiController]
    [Route("products/{id}/[controller]")]
    [Authorize]
    public class UpdateController : ControllerBase
    {
        private readonly IProductUpdateService _productUpdateService;

        public UpdateController(IProductUpdateService productUpdateService)
        {
            _productUpdateService = productUpdateService;
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductUpdateRequest updateRequest)
        {
            var response = new Response();
            try
            {
                _productUpdateService.Update(updateRequest);
                response.Success = true;
                response.Message = "Se ha modificado correctamente";
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
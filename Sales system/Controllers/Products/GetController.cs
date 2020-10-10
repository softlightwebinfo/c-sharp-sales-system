using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Product;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Products
{
    [ApiController]
    [Route("products/{id}/[controller]")]
    [Authorize]
    public class GetController : ControllerBase
    {
        private readonly IProductGetService _getService;

        public GetController(IProductGetService getService)
        {
            _getService = getService;
        }

        [HttpGet]
        public IActionResult Get(long id)
        {
            var response = new Response();
            try
            {
                response.Data = _getService.Get(id);
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
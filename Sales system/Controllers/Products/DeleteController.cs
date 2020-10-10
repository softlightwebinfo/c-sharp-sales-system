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
    public class DeleteController : ControllerBase
    {
        private readonly IProductDeleteService _suppliersDeleteService;

        public DeleteController(IProductDeleteService suppliersDeleteService)
        {
            _suppliersDeleteService = suppliersDeleteService;
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var response = new Response();
            try
            {
                _suppliersDeleteService.Delete(id);
                response.Success = true;
                response.Message = "Se ha eliminado correctamente";
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
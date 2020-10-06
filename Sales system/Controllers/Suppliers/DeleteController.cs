using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Suppliers;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Suppliers
{
    [ApiController]
    [Route("suppliers/{id}/[controller]")]
    [Authorize]
    public class DeleteController : ControllerBase
    {
        private readonly ISuppliersDeleteService _suppliersDeleteService;

        public DeleteController(ISuppliersDeleteService suppliersDeleteService)
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
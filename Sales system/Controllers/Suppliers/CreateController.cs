using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Suppliers;
using Sales_system.Models.Request.Suppliers;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Suppliers
{
    [ApiController]
    [Route("suppliers/[controller]")]
    [Authorize]
    public class CreateController : ControllerBase
    {
        private readonly ISuppliersService _suppliersService;

        public CreateController(ISuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
        }

        [HttpPost]
        public IActionResult Post(SuppliersCreateRequest request)
        {
            var response = new Response();
            try
            {
                _suppliersService.PublishNew(request);
                response.Message = "Se ha creado el proveedor correctamente";
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
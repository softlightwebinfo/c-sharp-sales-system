using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Suppliers;
using Sales_system.Models.Request.Suppliers;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Suppliers
{
    [ApiController]
    [Route("suppliers/{id}/[controller]")]
    [Authorize]
    public class UpdateController : ControllerBase
    {
        private readonly ISuppliersUpdateService _suppliersUpdateService;

        public UpdateController(ISuppliersUpdateService suppliersUpdateService)
        {
            _suppliersUpdateService = suppliersUpdateService;
        }

        [HttpPut]
        public IActionResult Put([FromBody] SuppliersUpdateRequest suppliersUpdateRequest)
        {
            var response = new Response();
            try
            {
                _suppliersUpdateService.Update(suppliersUpdateRequest);
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
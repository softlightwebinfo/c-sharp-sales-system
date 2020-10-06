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
    public class GetController : ControllerBase
    {
        private readonly ISuppliersGetService _getService;

        public GetController(ISuppliersGetService getService)
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
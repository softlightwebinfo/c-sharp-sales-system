using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Client;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Client
{
    [ApiController]
    [Route("clients/{id}/[controller]")]
    [Authorize]
    public class GetController : ControllerBase
    {
        private readonly IClientGetService _getService;

        public GetController(IClientGetService getService)
        {
            _getService = getService;
        }

        [HttpGet]
        public IActionResult Get(long id)
        {
            Response response = new Response();
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
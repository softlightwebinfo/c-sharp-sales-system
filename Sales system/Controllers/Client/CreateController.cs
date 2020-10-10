using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Client;
using Sales_system.Models.Response;
using Sales_system.Models.Request.Client;

namespace Sales_system.Controllers.Client
{
    [ApiController]
    [Route("clients/[controller]")]
    [Authorize]
    public class CreateController : ControllerBase
    {
        private readonly IClientService _publishService;

        public CreateController(IClientService publishService)
        {
            _publishService = publishService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] ClientCreateRequest client)
        {
            Response response = new Response();

            try
            {
                _publishService.PublishNew(client);
                response.Success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok(response);
        }
    }
}
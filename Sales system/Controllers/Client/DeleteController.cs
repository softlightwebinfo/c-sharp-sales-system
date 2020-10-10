using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Client;
using Sales_system.Models;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Client
{
    [ApiController]
    [Route("clients/{clientId}/[controller]")]
    [Authorize]
    public class DeleteController : ControllerBase
    {
        private readonly IClientDeleteService _deleteService;

        public DeleteController(IClientDeleteService deleteService)
        {
            _deleteService = deleteService;
        }

        [HttpDelete]
        public IActionResult Delete(long clientId)
        {
            Response response = new Response();

            try
            {
                _deleteService.Delete(clientId);
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
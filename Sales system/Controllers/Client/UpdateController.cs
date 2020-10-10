using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Client;
using Sales_system.Models.Response;
using Sales_system.Models.Request.Client;

namespace Sales_system.Controllers.Client
{
    [ApiController]
    [Route("clients/{id}/[controller]")]
    [Authorize]
    public class UpdateController : ControllerBase
    {
        private readonly IClientUpdateService _updateService;

        public UpdateController(IClientUpdateService updateService)
        {
            _updateService = updateService;
        }

        [HttpPut]
        public IActionResult Edit(ClientUpdateRequest client, long id)
        {
            Response response = new Response();

            try
            {
                if (id != client.Id)
                {
                    throw new Exception("El id del cliente no es el mismo");
                }

                _updateService.Update(client);
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
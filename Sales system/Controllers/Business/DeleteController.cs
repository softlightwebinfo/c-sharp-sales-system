using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Business;
using Sales_system.Models.Request.Business;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Business
{
    [ApiController]
    [Route("business/{id}/[controller]")]
    [Authorize]
    public class DeleteController : ControllerBase
    {
        private readonly IBusinessDeleteService _businessService;

        public DeleteController(IBusinessDeleteService businessService)
        {
            _businessService = businessService;
        }

        [HttpPut]
        public IActionResult Delete(int id)
        {
            var response = new Response();
            try
            {
                _businessService.Delete(id);
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
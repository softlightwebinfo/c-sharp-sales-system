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
    public class UpdateController : ControllerBase
    {
        private readonly IBusinessUpdateService _businessService;

        public UpdateController(IBusinessUpdateService businessService)
        {
            _businessService = businessService;
        }

        [HttpPut]
        public IActionResult Put([FromBody] BusinessUpdateRequest businessUpdateRequest)
        {
            var response = new Response();
            try
            {
                _businessService.Update(businessUpdateRequest);
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
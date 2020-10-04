using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces;
using Sales_system.Models.Request.Business;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Business
{
    [ApiController]
    [Route("business/[controller]")]
    [Authorize]
    public class PublishController : ControllerBase
    {
        private readonly IBusinessService _businessService;

        public PublishController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] BusinessCreateRequest businessCreateRequest)
        {
            var response = new Response();
            try
            {
                _businessService.PublishNew(businessCreateRequest);
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
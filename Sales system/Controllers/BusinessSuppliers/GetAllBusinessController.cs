using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Exceptions.Business;
using Sales_system.Interfaces.Services.Business;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.BusinessSuppliers
{
    [ApiController]
    [Route("business/{business}/suppliers")]
    [Authorize]
    public class GetAllBusinessController : ControllerBase
    {
        private readonly IBusinessSuppliersService _suppliersService;

        public GetAllBusinessController(IBusinessSuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
        }

        [HttpGet]
        public IActionResult Get(int business)
        {
            var response = new Response();
            try
            {
                response.Data = _suppliersService.GetAll(business);
                response.Success = true;
            }
            catch (BusinessExection exception)
            {
                Console.WriteLine(exception);
                response.Message = exception.Message;
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
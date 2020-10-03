using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Models;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.BusinessSuppliers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class GetAllController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var response = new Response();
            try
            {
                using var db = new salesSystemContext();
                var lst = db.BusinessSuppliers.ToList();
                response.Data = lst;
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
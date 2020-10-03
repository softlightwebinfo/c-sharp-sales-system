using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Models;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Client
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class GetClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response();
            try
            {
                using var db = new salesSystemContext();
                var lst = db.Clients.ToList();
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
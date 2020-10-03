using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Exceptions.Business;
using Sales_system.Models;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Business
{
    [ApiController]
    [Route("business/[controller]")]
    [Authorize]
    public class GetAllUser : ControllerBase
    {
        [HttpGet]
        [Route("{user}")]
        public IActionResult Get(int user)
        {
            var response = new Response();
            try
            {
                using var db = new salesSystemContext();
                var lst = db.Businesses.Where(e => e.FkUserId == user).ToList();
                if (lst.Count == 0) throw new BusinessExection("No se ha encontrado ninguna empresa asociada a este usuario");
                response.Data = lst;
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
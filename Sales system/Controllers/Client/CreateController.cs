using System;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Models;
using Sales_system.Models.Response;
using Sales_system.Models.Request;

namespace Sales_system.Controllers.Client
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(ClientRequest client)
        {
            Response response = new Response();

            try
            {
                using var db = new salesSystemContext();
                var vClient = new Models.Client {ClientName = client.Name};

                db.Clients.Add(vClient);
                db.SaveChanges();
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
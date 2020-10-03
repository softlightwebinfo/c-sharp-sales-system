using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Models;
using Sales_system.Models.Response;
using Sales_system.Models.Request;

namespace Sales_system.Controllers.Client
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EditClientController : ControllerBase
    {
        [HttpPut]
        public IActionResult Edit(ClientRequest client)
        {
            Response response = new Response();

            try
            {
                using var db = new salesSystemContext();
                var vClient = db.Clients.Find(client.Id);
                vClient.ClientName = client.Name;
                db.Entry(vClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
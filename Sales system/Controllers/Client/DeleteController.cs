using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Models;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Client
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DeleteClientController : ControllerBase
    {
        [HttpDelete("{clientId}")]
        public IActionResult Delete(int clientId)
        {
            Response response = new Response();

            try
            {
                using salesSystemContext db = new salesSystemContext();
                Models.Client vClient = db.Clients.Find(clientId);
                db.Remove(vClient);
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
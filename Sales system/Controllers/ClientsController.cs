using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Models;
using Sales_system.Models.Response;
using Sales_system.Models.Request;

namespace Sales_system.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response();
            try
            {
                using (salesSystemContext db = new salesSystemContext())
                {
                    var lst = db.Clients.ToList();
                    response.Data = lst;
                    response.Success = true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                response.Message = exception.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Add(ClientRequest client)
        {
            Response response = new Response();

            try
            {
                using (salesSystemContext db = new salesSystemContext())
                {
                    Client vClient = new Client()
                    {
                        ClientName = client.Name
                    };

                    db.Clients.Add(vClient);
                    db.SaveChanges();
                    response.Success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(ClientRequest client)
        {
            Response response = new Response();

            try
            {
                using (salesSystemContext db = new salesSystemContext())
                {
                    Client vClient = db.Clients.Find(client.Id);
                    vClient.ClientName = client.Name;
                    db.Entry(vClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    response.Success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok(response);
        }
        
        [HttpDelete("{clientId}")]
        public IActionResult Delete(int clientId)
        {
            Response response = new Response();

            try
            {
                using (salesSystemContext db = new salesSystemContext())
                {
                    Client vClient = db.Clients.Find(clientId);
                    db.Remove(vClient);
                    db.SaveChanges();
                    response.Success = true;
                }
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
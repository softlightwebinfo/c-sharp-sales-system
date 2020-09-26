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
    public class SaleController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(SaleRequest model)
        {
            Response response = new Response();

            try
            {
                using (salesSystemContext db = new salesSystemContext())
                {
                    var sale = new Sale();
                    sale.Total = model.Total;
                    sale.CreatedAt = DateTime.Now;
                    sale.FkClientId = model.IdClient;
                    db.Sales.Add(sale);
                    db.SaveChanges();

                    foreach (var rowConcept in model.Concepts)
                    {
                        Concept concept = new Concept();
                        concept.FkProductId = rowConcept.IdProduct;
                        concept.PriceUnit = rowConcept.PriceUnit;
                        concept.Amount = rowConcept.Amount;
                        concept.FkSaleId = sale.Id;
                        Console.WriteLine(concept);
                        db.Concepts.Add(concept);
                        db.SaveChanges();
                    }

                    response.Success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.Message = e.Message;
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
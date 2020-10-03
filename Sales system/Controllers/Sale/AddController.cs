using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Models;
using Sales_system.Models.Response;
using Sales_system.Models.Request;

namespace Sales_system.Controllers.Sale
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SaleController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(SaleRequest model)
        {
            var response = new Response();

            try
            {
                using var db = new salesSystemContext();
                using var transaction = db.Database.BeginTransaction();
                try
                {
                    var sale = new Models.Sale
                    {
                        Total = model.Concepts.Sum(d => d.Amount * d.PriceUnit),
                        CreatedAt = DateTime.Now,
                        FkClientId = model.IdClient
                    };
                    db.Sales.Add(sale);
                    db.SaveChanges();

                    foreach (var concept in model.Concepts.Select(rowConcept => new Concept
                    {
                        FkProductId = rowConcept.IdProduct,
                        PriceUnit = rowConcept.PriceUnit,
                        Amount = rowConcept.Amount,
                        Total = rowConcept.Total,
                        FkSaleId = sale.Id
                    }))
                    {
                        db.Concepts.Add(concept);
                        db.SaveChanges();
                    }

                    response.Success = true;
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    transaction.Rollback();
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
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
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var sale = new Sale();
                            sale.Total = model.Concepts.Sum(d => d.Amount * d.PriceUnit);
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
                                concept.Total = rowConcept.Total;
                                concept.FkSaleId = sale.Id;
                                db.Concepts.Add(concept);
                                db.SaveChanges();
                            }

                            response.Success = true;
                            transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                        }
                    }
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
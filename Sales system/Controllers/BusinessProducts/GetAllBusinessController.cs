﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Exceptions.Business;
using Sales_system.Models;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.BusinessProducts
{
    [ApiController]
    [Route("business/{business}/products")]
    [Authorize]
    public class GetAllBusinessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int business)
        {
            var response = new Response();
            try
            {
                using var db = new salesSystemContext();
                var lst = db.BusinessProducts.Where(e => e.FkBusinessId == business).ToList();
                if (lst.Count == 0) throw new BusinessExection("No se ha encontrado ningun producto asociada a esta empresa");
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
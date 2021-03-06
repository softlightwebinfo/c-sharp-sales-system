﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Suppliers;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Suppliers
{
    [ApiController]
    [Route("suppliers/[controller]")]
    [Authorize]
    public class GetAllController : ControllerBase
    {
        private readonly ISuppliersGetAllService _getAllService;

        public GetAllController(ISuppliersGetAllService getAllService)
        {
            _getAllService = getAllService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();
            try
            {
                response.Data = _getAllService.GetAll();
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
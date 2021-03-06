﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces.Services.Product;
using Sales_system.Models.Response;

namespace Sales_system.Controllers.Products
{
    [ApiController]
    [Route("products/[controller]")]
    [Authorize]
    public class GetAllController : ControllerBase
    {
        private readonly IProductGetAllService _getAllService;

        public GetAllController(IProductGetAllService allService)
        {
            _getAllService = allService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();
            try
            {
                response.Data = _getAllService.GetAll();
                response.Success = true;
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
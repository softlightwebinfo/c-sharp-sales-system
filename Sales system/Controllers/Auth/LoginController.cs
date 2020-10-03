using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sales_system.Interfaces;
using Sales_system.Models.Response;
using Sales_system.Models.Request;

namespace Sales_system.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequest model)
        {
            Response response = new Response();
            var userResponse = _authService.Auth(model);

            if (userResponse == null)
            {
                response.Message = "User o password incorrect";
                return BadRequest(response);
            }
            response.Success = true;
            response.Data = userResponse;
            return Ok(response);
        }
    }
}
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sales_system.Interfaces;
using Sales_system.Models;
using Sales_system.Models.Common;
using Sales_system.Models.Request;
using Sales_system.Models.Response;
using Sales_system.Tools;

namespace Sales_system.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppSetting _appSetting;

        public AuthService(IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
        }

        public UserResponse? Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse();
            using var db = new salesSystemContext();
            string vpassword = Encrypt.GetSha256(model.Password);
            User user = db.Users.FirstOrDefault(d => d.Email == model.Email && d.UserPassword == vpassword);

            if (user == null) return null;
            userResponse.Email = user.Email;
            userResponse.Token = GetToken(user);

            return userResponse;
        }

        private string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
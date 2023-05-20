using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using crypto_restapi.Models;
using System.Linq;

namespace crypto_restapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
		private readonly crypto_restapi.Models.cryptocurrency_integrationContext _context;

        public TokenController(IConfiguration config, cryptocurrency_integrationContext context)
        {
            _configuration = config;
            _context = context;
        }

       
        public string Post(Users user)
        {

            if (user != null)
            {
                //create claims details based on the user information
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("username", user.Username),
                    new Claim("phoneNumber", user.PhoneNumber),
                    new Claim("password", user.Password),
                    new Claim("email", user.Email) 
                };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(15), signingCredentials: signIn);

                    var t = new JwtSecurityTokenHandler().WriteToken(token).ToString();
                    return new JwtSecurityTokenHandler().WriteToken(token).ToString();

            } else
			{
                return null;
			}
        }
    }
}
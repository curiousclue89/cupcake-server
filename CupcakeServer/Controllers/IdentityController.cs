using CupcakeServer.Models;
using CupcakeServer.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CupcakeServer.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    [AllowAnonymous]
    public class IdentityController: ControllerBase
    {
        private ApplicationDBContext context;
        public IdentityController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] Login login) 
        {
           var user = context.Users.Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();
           if (user == null)
           {
                return Unauthorized();
           }
           else 
           {
                var issuer = "Issuer";
                var audience = "Audience";
                var key = Encoding.ASCII.GetBytes("eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTY5ODU0MDAwMSwiaWF0IjoxNjk4NTQwMDAxfQ.Ndu9O66L1x8inde8vg5rfCdDYY8VLurTUPX3Vld5p6Q");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, login.Email),
                        new Claim(JwtRegisteredClaimNames.Email, login.Email),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return Ok(stringToken);
            }
        }
    }
}

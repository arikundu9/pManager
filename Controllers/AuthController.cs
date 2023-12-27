using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace pMan.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public AuthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet("Login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            string jwtStr="eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJhcHBsaWNhdGlvbiI6IntcIklkXCI6NixcIk5hbWVcIjpcIkUtQmlsbGluZ1wiLFwiTGV2ZWxzXCI6W3tcIklkXCI6OSxcIk5hbWVcIjpcIkRET1wiLFwiU2NvcGVcIjpbXCJCQUFBRUUwMDFcIl19XSxcIlJvbGVzXCI6W3tcIklkXCI6MjUsXCJOYW1lXCI6XCJhcHByb3ZlclwifV19IiwibmFtZWlkIjoiMjkiLCJuYW1lIjoiQXJpaml0IiwibmJmIjoxNzAzNjU4NjY5LCJleHAiOjE3MDM3NDUwNjksImlhdCI6MTcwMzY1ODY2OX0.PcvWrt_c7YtHqdRjPhfxy8BlljSAIQcdlL9Fhoyq4AoCQa41x5JCgammhoobYoMmuCMuKcCFynVEo-nqAvqnOQ";
            return Ok(jwtStr);
        }

        [HttpGet("Validate")]
        [AllowAnonymous]
        public IActionResult Validate()
        {
            try
            {
                // var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJhcHBsaWNhdGlvbiI6IntcIklkXCI6NixcIk5hbWVcIjpcIkUtQmlsbGluZ1wiLFwiTGV2ZWxzXCI6W3tcIklkXCI6OSxcIk5hbWVcIjpcIkRET1wiLFwiU2NvcGVcIjpbXCJCQUFBRUUwMDFcIl19XSxcIlJvbGVzXCI6W3tcIklkXCI6MjUsXCJOYW1lXCI6XCJhcHByb3ZlclwifV19IiwibmFtZWlkIjoiMjkiLCJuYW1lIjoiQXJpaml0IiwibmJmIjoxNzAzNjU4NjY5LCJleHAiOjE3MDM3NDUwNjksImlhdCI6MTcwMzY1ODY2OX0.PcvWrt_c7YtHqdRjPhfxy8BlljSAIQcdlL9Fhoyq4AoCQa41x5JCgammhoobYoMmuCMuKcCFynVEo-nqAvqnOQ";
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);

                tokenHandler.ValidateToken(token, GetValidationParameters(), out SecurityToken validatedToken);
                Console.WriteLine("Token validation succeeded.");
                //JwtSecurityTokenHandler tokenHandler  = handler.ReadJwtToken(token.ToString());
                return Ok(new
                {
                    status = "ValidToken"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, msg = ex.Message.ToString() });
            }
        }

        private TokenValidationParameters GetValidationParameters()
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                // ValidIssuer = "myIssuer", // replace with your own issuer
                ValidateAudience = false,
                //ValidAudience = "myAudience", // replace with your own audience
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:JWTKey").Value))
            };
            return validationParameters;
        }
    }
}

using JWTBasedAPI.Helpers;
using JWTBasedAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTBasedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Perform authentication logic (validate credentials, etc.)
            // If authentication succeeds, generate and return a JWT

            var token = JwtTokenGenerator.GenerateToken(model.Username); 

            return Ok(new { token });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpenseSplitterApi.Helpers;

namespace ExpenseSplitterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Dummy login validation
            if (model.Username == "admin" && model.Password == "pass123")
            {
                var token = _jwtService.GenerateToken(1); // User ID = 1
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

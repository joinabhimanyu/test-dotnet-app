using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_dotnet_app.DTO;
using test_dotnet_app.Services.Authentication;

namespace test_dotnet_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAuthenticationService _authentication;

        public AuthenticationController(ILogger logger, IAuthenticationService authentication)
        {
            _logger = logger;
            _authentication = authentication;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var result = await _authentication.ValidateUserAsync(loginDto);
            if (result)
            {
                var token = await _authentication.GenerateJwtTokenAsync(loginDto);
                return Ok(new { token });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto registerDto)
        {
            var result = await _authentication.RegisterUserAsync(registerDto);
            if (result.Succeeded)
            {
                return Ok(new { message = "User created successfully" });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
        }
    }
}

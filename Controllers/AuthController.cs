using Microsoft.AspNetCore.Mvc;
using PaymentManagementAPI.DTOs.Auth;
using PaymentManagementAPI.Interfaces;

namespace PaymentManagementAPI.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var result = _authService.Register(dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var result = _authService.Login(dto);
            if (result == null)
            {
                return Unauthorized("Invalid Password or Email");
            }

            return Ok(result);
        }
    }
}

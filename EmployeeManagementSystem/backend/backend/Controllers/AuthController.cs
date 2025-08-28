using backend.Services;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var (token, user) = await _authService.Authenticate(request.Username, request.Password);

            if (string.IsNullOrEmpty(token) || user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(new
            {
                Token = token,
                Role = user.Role,
                EmpId = user.EmpId
            });
        }


    }
}


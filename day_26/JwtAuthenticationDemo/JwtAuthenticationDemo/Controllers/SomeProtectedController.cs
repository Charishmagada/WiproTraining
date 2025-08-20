using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeProtectedController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProtectedData()
        {
            return Ok(new { message = "This is a protected data" });
        }
    }
}

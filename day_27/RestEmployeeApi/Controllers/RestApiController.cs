using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestEmployeeApi.Models;
using RestEmployeeApi.Services;

namespace RestEmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestApiController : ControllerBase
    {
        private readonly IApiService _employService;

        public RestApiController(IApiService employService)
        {
            _employService = employService;
        }

        [HttpGet]
        public async Task<IActionResult> ShowEmployAll()
        {
            var result = await _employService.ShowEmployAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> SearchEmployAsync(int id)
        {
            var result = await _employService.SearchByEmpnoAsync(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddEmploy(Employee employ)
        {
            var result = await _employService.AddEmployAsync(employ);
            return Ok(result);
        }
    }
}

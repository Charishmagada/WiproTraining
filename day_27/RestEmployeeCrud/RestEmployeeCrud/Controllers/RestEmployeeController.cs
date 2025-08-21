using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestEmployeeCrud.Services;
using RestEmployeeCrud.Models;

namespace RestEmployeeCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestEmployeeController : ControllerBase
    {
        private readonly IApiService _apiService;

        public RestEmployeeController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> ShowEmployAll()
        {
            var result = await _apiService.GetEmployAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SearchEmploy(int id)
        {
            var result = await _apiService.GetEmployByIdAsync(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmploy(Employee employ)
        {
            var result = await _apiService.CreateEmployAsync(employ);
            return Ok(result);
        }
    }
}

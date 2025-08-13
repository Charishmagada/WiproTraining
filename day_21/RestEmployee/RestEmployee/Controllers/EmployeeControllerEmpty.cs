//here instead of using controller with strins and action we took empty controller
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestEmployee.Models;

namespace RestEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControllerEmpty : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeeControllerEmpty(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetResult(int id)
        {
            var employ = await _context.Employees.Where(x => x.Empno == id).SingleOrDefaultAsync();
            if (employ == null)
            {
                return NotFound();
            }
            return employ;
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddEmploy(Employee employ)
        {
            _context.Employees.Add(employ);
            await _context.SaveChangesAsync();
            return "Employee Record Inserted";
        }
    }
}


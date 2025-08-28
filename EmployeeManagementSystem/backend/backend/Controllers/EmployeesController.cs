using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class EmployeesController : ControllerBase
    {
        private readonly EmsDbContext _context;

        public EmployeesController(EmsDbContext context)
        {
            _context = context;
        }

        // GET: api/employees (HR & Manager can view all employees)
        [HttpGet]
        [Authorize(Roles = "HR,Manager")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/employees/{id} (HR, Manager, or the Employee can view)
        [HttpGet("{id}")]
        [Authorize(Roles = "HR,Manager,Employee")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound(new { message = "Employee not found" });

            return employee;
        }

        // PUT: api/employees/{id} (HR & Manager can update employee details)
        [HttpPut("{id}")]
        [Authorize(Roles = "HR,Manager")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.EmpId)
                return BadRequest(new { message = "ID mismatch" });

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                    return NotFound(new { message = "Employee not found" });
                else
                    throw;
            }

            return Ok(new { message = "Employee updated successfully" });
        }

        // POST: api/employees (Only HR can add new employees)
        [HttpPost]
        [Authorize(Roles = "HR")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmpId }, employee);
        }

        // DELETE: api/employees/{id} (Only HR can delete employees)
        [HttpDelete("{id}")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound(new { message = "Employee not found" });

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Employee deleted successfully" });
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmpId == id);
        }
    }
}

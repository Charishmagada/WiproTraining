using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class LeaveHistoriesController : ControllerBase
    {
        private readonly EmsDbContext _context;

        public LeaveHistoriesController(EmsDbContext context)
        {
            _context = context;
        }

        // GET: api/leavehistories (HR & Manager can view all leave history)
        [HttpGet]
        [Authorize(Roles = "HR,Manager")]
        public async Task<ActionResult<IEnumerable<LeaveHistory>>> GetLeaveHistories()
        {
            return await _context.LeaveHistories.ToListAsync();
        }

        // GET: api/leavehistories/employee/{empId} (Employee can view their own leave history)
        [HttpGet("employee/{empId}")]
        [Authorize(Roles = "HR,Manager,Employee")]
        public async Task<ActionResult<IEnumerable<LeaveHistory>>> GetLeaveHistoriesByEmployee(int empId)
        {
            return await _context.LeaveHistories.Where(x => x.EmpId == empId).ToListAsync();
        }

        // GET: api/leavehistories/{id} (HR, Manager can view specific leave)
        [HttpGet("{id}")]
        [Authorize(Roles = "HR,Manager")]
        public async Task<ActionResult<LeaveHistory>> GetLeaveHistory(int id)
        {
            var leaveHistory = await _context.LeaveHistories.FindAsync(id);

            if (leaveHistory == null)
                return NotFound(new { message = "Leave record not found" });

            return leaveHistory;
        }

        // PUT: api/leavehistories/{id} (HR & Manager can approve/reject leave)
        [HttpPut("{id}")]
        [Authorize(Roles = "HR,Manager")]
        public async Task<IActionResult> UpdateLeaveHistory(int id, LeaveHistory leaveHistory)
        {
            if (id != leaveHistory.LeaveId)
                return BadRequest(new { message = "ID mismatch" });

            _context.Entry(leaveHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveHistoryExists(id))
                    return NotFound(new { message = "Leave record not found" });
                else
                    throw;
            }

            return Ok(new { message = "Leave updated successfully" });
        }

        // POST: api/leavehistories/apply (Only Employee can apply leave)
        [HttpPost("apply")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult<string>> ApplyLeave(LeaveHistory leaveHistory)
        {
            DateTime today = DateTime.Now;

            // Validate dates
            if (leaveHistory.LeaveStartDate.Date < today.Date)
                return BadRequest("Leave Start Date cannot be in the past!");

            if (leaveHistory.LeaveEndDate < leaveHistory.LeaveStartDate)
                return BadRequest("Leave End Date cannot be before Start Date!");

            // Calculate number of days
            int days = (int)(leaveHistory.LeaveEndDate - leaveHistory.LeaveStartDate).TotalDays + 1;

            // Check leave balance
            var employee = await _context.Employees.FindAsync(leaveHistory.EmpId);
            if (employee == null)
                return NotFound("Employee not found!");

            if (employee.LeaveAvail < days)
                return BadRequest("Insufficient Leave Balance!");

            // Deduct leave balance and save
            employee.LeaveAvail -= days;
            leaveHistory.NoOfDays = days;
            leaveHistory.LeaveStatus = "PENDING";

            _context.LeaveHistories.Add(leaveHistory);
            await _context.SaveChangesAsync();

            return Ok("Leave Applied Successfully!");
        }

        // DELETE: api/leavehistories/{id} (Only HR can delete leave record)
        [HttpDelete("{id}")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> DeleteLeaveHistory(int id)
        {
            var leaveHistory = await _context.LeaveHistories.FindAsync(id);
            if (leaveHistory == null)
                return NotFound();

            _context.LeaveHistories.Remove(leaveHistory);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Leave deleted successfully" });
        }

        private bool LeaveHistoryExists(int id)
        {
            return _context.LeaveHistories.Any(e => e.LeaveId == id);
        }
    }
}

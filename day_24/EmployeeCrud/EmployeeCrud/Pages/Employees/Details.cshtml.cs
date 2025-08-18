using EmployeeCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly EFCoreDbContext _dbContext;

        public DetailsModel(EFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _dbContext.Employees.Where(x => x.Empno == id).FirstOrDefaultAsync();

            //var employ = await _dbContext.Employees.FirstOrDefaultAsync(m => m.Empno == id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                Employee = employee;
            }
            return Page();
        }

    }
}


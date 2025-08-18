using EmployeeCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace EmployeeCrud.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EFCoreDbContext _context;

        public IndexModel(EFCoreDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.ToListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeCrudNew.Models;

namespace EmployeeCrudNew.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeCrudNew.Models.EFCoreDbContext _context;

        public IndexModel(EmployeeCrudNew.Models.EFCoreDbContext context)
        {
            _context = context;
        }

        public IList<EmployeeCrudNew.Models.Employee> Employee { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees.ToListAsync();
        }
    }
}
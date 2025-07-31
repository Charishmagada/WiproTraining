using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreDemo.Pages
{
    public class EmployeeShowModel : PageModel
    {
       
            public List<Employee>? Employees { get; set; }
            public void OnGet()
            {
                Employees = new List<Employee>
                {
                    new Employee { Empno = 1, Name = "Padma", Basic = 99877 },
                    new Employee { Empno = 2, Name = "siri", Basic = 99778 },
                    new Employee { Empno = 3, Name = "nireesha", Basic = 99666 },

                };
            }
    }
}


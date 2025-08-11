using System.ComponentModel.DataAnnotations;

namespace EmployeeCrud.Controllers.Models
{
    public class Employee
    {
        [Key]
        public int Empno { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Dept { get; set; }

        public string? Desgn { get; set; }

        public decimal Basic { get; set; }
    }
}

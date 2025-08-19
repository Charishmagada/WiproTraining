using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MVCEmployeeCrud.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "Employ Number")]
        public int Empno { get; set; }
        [Display(Name = "Employ Name")]
        public string? Name { get; set; }
        [Display(Name = "Gender")]
        public string? Gender { get; set; }
        [Display(Name = "Department")]
        public string? Dept { get; set; }
        [Display(Name = "Designation")]
        public string? Desgn { get; set; }
        [Display(Name = "Salary")]
        [Column("Basic")]
        public decimal Basic { get; set; }
    }
}



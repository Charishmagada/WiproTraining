using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace backend.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public int? DepartmentId { get; set; }
        public int? MgrId { get; set; }
        public int LeaveAvail { get; set; }
    }

}

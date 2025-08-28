using System.ComponentModel.DataAnnotations;
namespace backend.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}

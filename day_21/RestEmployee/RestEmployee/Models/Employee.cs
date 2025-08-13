using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestEmployee.Models
{
    public class Employee
    {
        [Key]
        [Column("empno")]
        public int Empno { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("gender")]
        public string? Gender { get; set; }
        [Column("dept")]
        public string? Dept { get; set; }
        [Column("desgn")]
        public string? Desgn { get; set; }
        [Column("basic")]
        public decimal Basic { get; set; }
    }
}

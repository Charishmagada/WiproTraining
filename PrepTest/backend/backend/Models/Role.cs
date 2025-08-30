using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Role
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}

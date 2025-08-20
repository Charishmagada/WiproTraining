using Microsoft.EntityFrameworkCore;

namespace JwtAuthenticationDemo.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Users> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace backend.Models
{
    public class EmsDbContext : DbContext
    {
        public EmsDbContext() { }

        public EmsDbContext(DbContextOptions<EmsDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // You can remove this if you provide the connection string via appsettings.json
                optionsBuilder.UseSqlServer("Server=YOUR_SERVER_NAME;Database=ems;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explicitly map to table names (optional since names match)
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<LeaveHistory>().ToTable("LeaveHistory");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Department>().ToTable("Departments");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveHistory> LeaveHistories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}

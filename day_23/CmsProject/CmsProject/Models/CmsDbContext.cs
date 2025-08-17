using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CmsProject.Models
{
    public class CmsDbContext : DbContext
    {
        public CmsDbContext() { }

        public CmsDbContext(DbContextOptions<CmsDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Uncomment and add your connection string if not using Program.cs:
            // optionsBuilder.UseSqlServer("Your_Connection_String_Here");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}

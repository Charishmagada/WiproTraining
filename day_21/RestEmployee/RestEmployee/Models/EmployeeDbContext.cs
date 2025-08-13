using Microsoft.EntityFrameworkCore;
namespace RestEmployee.Models;
public class EmployeeDbContext:DbContext
{
    //Constructor calling the Base DbContext Class Constructor
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
    }
    //OnConfiguring() method is used to select and configure the data source
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("Employee");
    }

    public DbSet<Employee> Employees { get; set; }
}



using MappingDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MappingDemo.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions)
        {
                
        }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<EmployeeAddress> EmployeesAddress { get; set;}
        public DbSet<EmployeeDetails> EmployeesDetails { get; set;}
    }
}

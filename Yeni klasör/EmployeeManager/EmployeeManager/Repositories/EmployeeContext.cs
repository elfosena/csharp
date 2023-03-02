using EmployeeManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace EmployeeManager.Repositories
{
    public class EmployeeContext :  DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EmployeeDb;integrated security=true");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}

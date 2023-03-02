using JSONDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace JSONDemo.Repositories
{
    public class JsonContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=JsonDb;integrated security=true");
        }
        public DbSet<Post> Posts { get; set; }
    }
}

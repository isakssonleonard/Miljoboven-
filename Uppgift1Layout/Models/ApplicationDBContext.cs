using Microsoft.EntityFrameworkCore;
using Uppgift1Layout.Models.POCO;

namespace Uppgift1Layout.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<Status> Status { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        
    }
}

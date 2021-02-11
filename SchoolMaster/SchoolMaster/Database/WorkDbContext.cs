using Microsoft.EntityFrameworkCore;
using SchoolMaster.Models;

namespace SchoolMaster.Database
{
    public class WorkDbContext : DbContext
    {
        public WorkDbContext(DbContextOptions<WorkDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Work> UserWorks { get; set; }
    }
}
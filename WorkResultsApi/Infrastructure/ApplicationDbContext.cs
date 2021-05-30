using Microsoft.EntityFrameworkCore;
using WorkResultsApi.Models;

namespace WorkResultsApi.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<StudentWorkItem> StudentWorkItems { get; set; }
    }
}
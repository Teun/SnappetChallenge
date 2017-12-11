using Microsoft.EntityFrameworkCore;
using Snappet2.Models;
using Snappet2.ViewModel;

namespace Snappet2.Data
{
    public class SnappetContext : DbContext
    {
        public SnappetContext(DbContextOptions<SnappetContext> options) : base(options)
        {
        }

        public DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubmittedAnswer>().ToTable("SubmittedAnswer");
        }
    }
}

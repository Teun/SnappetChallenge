using Microsoft.EntityFrameworkCore;
using Snappet.Assignment.Data.Configurations;
using Snappet.Assignment.Entities.DomainObjects;

namespace Snappet.Assignment.Data.Context
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Exercise> Exercises { get; set; }


        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("School");

            builder.ApplyConfiguration(new WorkConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new ExerciseConfiguration());


        }
    }
}

using Library.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using Snappet.Entities.Entities;
using System;

namespace Snappet.Entities
{
    /// <summary>
    /// Db context
    /// </summary>
    public class SnappetDBContext : DbContext
    {
        public SnappetDBContext(DbContextOptions<SnappetDBContext> options) : base(options)
        {
        }

        public DbSet<Summary> Summary { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          // modelBuilder.ApplyConfiguration(new SummaryConfiguration()); // To:do Data seeding is not working at the moment
        }
    }
}

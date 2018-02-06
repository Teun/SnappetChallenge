using Microsoft.EntityFrameworkCore;
using Snappet.Assignment.Entities.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Assignment.Data.Context
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }
    }
}

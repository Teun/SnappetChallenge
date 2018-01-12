using Snappet.WebAPI.Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Snappet.WebAPI.Persistence
{
    public class SnappetContext : DbContext
    {
        public SnappetContext()
            : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Models.Work> Works { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new WorkConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
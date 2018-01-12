using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Snappet.WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snappet.WebAPI.Persistence.EntityConfigurations
{
    public class WorkConfiguration : EntityTypeConfiguration<Work>
    {
        public WorkConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
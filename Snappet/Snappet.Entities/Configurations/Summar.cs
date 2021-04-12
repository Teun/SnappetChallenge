using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snappet.Entities;
using Snappet.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Entities.Configurations
{
    public class SummaryConfiguration : IEntityTypeConfiguration<Summary>
    {
        public void Configure(EntityTypeBuilder<Summary> builder)
        {
            builder.ToTable("Summary");
            IEnumerable<Summary> summaries = GenericHelper.LoadSummaryFromFile();
            builder.HasData(summaries.Take(20000));
            builder.HasData(summaries.Skip(20000));
        }
    }
}

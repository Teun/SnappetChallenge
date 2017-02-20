using System.Data.Entity.ModelConfiguration;
using Snappet.Test.TopStudents.Core.Model;

namespace Snappet.Test.TopStudents.Data.Mappings
{
    internal class DaySummaryMap : EntityTypeConfiguration<DaySummary>
    {
        public DaySummaryMap()
        {
            Ignore(r => r.Id);
            HasKey(r => new {r.RecordDate, r.Subject});

            Property(c => c.Subject)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.StudentIdsCsv)
                .IsRequired()
                .HasMaxLength(null);

            Property(r => r.RowVersion).IsRowVersion();
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using Snappet.Test.TopStudents.Core.Model;

namespace Snappet.Test.TopStudents.Data.Mappings
{
    internal class TopStudentsRecordMap : EntityTypeConfiguration<TopStudentsRecord>
    {
        public TopStudentsRecordMap()
        {
            Ignore(r => r.Id);
            HasKey(r => new {r.RecordDate, r.Subject, r.Type});

            Property(c => c.Subject)
                .IsRequired()
                .HasMaxLength(200);

            Property(r => r.RowVersion).IsRowVersion();
        }
    }
}

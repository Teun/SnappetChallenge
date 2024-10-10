using ClassMonitor.Core.WorkAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassMonitor.Infrastructure.Data.Config
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ExerciseId, x.SubmitDateTime });
        }
    }
}

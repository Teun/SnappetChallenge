using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snappet.Assignment.Entities.DomainObjects;

namespace Snappet.Assignment.Data.Configurations
{
    internal class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        void IEntityTypeConfiguration<Exercise>.Configure(EntityTypeBuilder<Exercise> entity)
        {
            entity.HasKey(k => k.Id);

            entity.Property(p => p.Id).ValueGeneratedNever();

            entity.Property(p => p.Name).
                HasMaxLength(50).
                HasColumnType("nvarchar(50)").
                IsRequired();            

        }
    }
}

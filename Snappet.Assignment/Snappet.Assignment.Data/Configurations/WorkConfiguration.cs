using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snappet.Assignment.Entities.DomainObjects;

namespace Snappet.Assignment.Data.Configurations
{
    internal class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        void IEntityTypeConfiguration<Work>.Configure(EntityTypeBuilder<Work> entity)
        {


            entity.HasKey(k => k.SubmittedAnswerId);

            entity.Property(p => p.SubmittedAnswerId).ValueGeneratedNever();

            entity.Property(p => p.UserId).
              HasColumnType("int").
              IsRequired();

            entity.Property(p => p.ExerciseId).
              HasColumnType("int").
              IsRequired();

            entity.Property(p => p.SubmitDateTime).
              HasColumnType("dateTime").
              IsRequired();

            entity.Property(p => p.Correct).
            HasColumnType("bit").
            IsRequired();

            entity.Property(p => p.Progress).
              HasColumnType("smallint").
              IsRequired();

            entity.Property(p => p.Difficulty).
            HasColumnType("float").
            IsRequired(false);

            entity.Property(p => p.Subject).
                    HasColumnType("nvarchar(50)").
                    HasMaxLength(50).
                    IsRequired();

            entity.Property(p => p.Domain).
                HasColumnType("nvarchar(50)").
                HasMaxLength(50).
                IsRequired(false);

            entity.Property(p => p.LearningObjective).
                HasColumnType("nvarchar(300)").
                HasMaxLength(300).
                IsRequired();


        }
    }
}

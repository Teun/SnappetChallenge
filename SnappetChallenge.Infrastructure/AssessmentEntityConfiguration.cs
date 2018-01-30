using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnappetChallenge.Core.Entities;

namespace SnappetChallenge.Infrastructure
{
    public class AssessmentEntityConfiguration : EntityTypeConfiguration<Assessment>
    {
        public AssessmentEntityConfiguration()
        {
            ToTable("Assessment");
            HasKey(s => s.SubmittedAnswerId);
            Property(p => p.SubmittedAnswerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.SubmittedAnswerId).HasColumnOrder(1);
            Property(p => p.SubmitDateTime).HasColumnType("datetime2");
            Property(p => p.SubmitDateTime).HasColumnOrder(2);
            Property(p => p.Correct).HasColumnOrder(3);
            Property(p => p.Progress).HasColumnOrder(4);
            Property(p => p.UserId);
            Property(p => p.UserId).HasColumnOrder(5);
            Property(p => p.ExerciseId);
            Property(p => p.ExerciseId).HasColumnOrder(6);
            Property(p => p.Difficulty).HasMaxLength(50);
            Property(p => p.Difficulty).HasColumnOrder(7);
            Property(p => p.Subject).HasMaxLength(50);
            Property(p => p.Subject).HasColumnOrder(8);
            Property(p => p.Domain).HasMaxLength(50);
            Property(p => p.Domain).HasColumnOrder(9);
            Property(p => p.LearningObjective).HasMaxLength(500);
            Property(p => p.LearningObjective).HasColumnOrder(10);
        }
    }
}

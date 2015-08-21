
namespace SnappetChallenge.DAL.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    
    internal sealed class AnswerConfiguration : EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            this.ToTable("Answer");
            this.HasKey<long>(s => s.Id);
            this.HasRequired(answer => answer.Student);
            this.HasRequired(answer => answer.Exercise)
                .WithMany(exercise => exercise.Answers)
                .HasForeignKey(answer => answer.ExerciseId);
        }
    }
}

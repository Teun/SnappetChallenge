namespace SnappetChallenge.DAL.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    
    internal sealed class ExerciseConfiguration : EntityTypeConfiguration<Exercise>
    {
        public ExerciseConfiguration()
        {
            this.ToTable("Exercise");
            this.HasKey<long>(s => s.Id);
            this.HasRequired(exercise => exercise.Domain).WithMany(e=>e.Exercises).HasForeignKey(e=>e.DomainId);
            this.HasRequired(exercise => exercise.Subject).WithMany(e=>e.Exercises).HasForeignKey(e=>e.SubjectId);
            this.HasRequired(exercise => exercise.Objective).WithMany(e => e.Exercises).HasForeignKey(e => e.ObjectiveId);
        }
    }
}

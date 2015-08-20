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

        }
    }
}

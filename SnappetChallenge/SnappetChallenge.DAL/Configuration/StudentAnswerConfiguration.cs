namespace SnappetChallenge.DAL.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    
    /// <summary>
    /// This is a stub for a possible complex/ compound mapping to the database
    /// Right now we only have "flat" data. Nice to have to build the implied data structure.
    /// </summary>
    internal sealed class StudentAnswerConfiguration : EntityTypeConfiguration<StudentAnswer>
    {
        public StudentAnswerConfiguration()
        {
            // yes, this is lame and identical to the default mapping of EF
            // however I've added this for demonstration purposes
            this.ToTable("StudentAnswer");

            // the primary key
            this.HasKey<long>(s => s.Id);
        }
    }
}

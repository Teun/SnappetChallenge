namespace SnappetChallenge.DAL
{
    using System.Data.Entity;
    using Configuration;
    using Entities;

    public class SnappetChallengeContext : DbContext, ISnappetChallengeContext
    {
        public SnappetChallengeContext()
            : base("name=SnappetChallengeConnectionString") // todo not really happy about the hardcodedness of the conn string
        {
#if DEBUG
            Database.SetInitializer(new SnappetChallengeDbInitializer());
#else
            Database.SetInitializer(null);
#endif
        }

        public DbSet<StudentAnswer> StudentAnswers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // tell EF how to map the data to the database
            modelBuilder.Configurations.Add(new StudentAnswerConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new AnswerConfiguration());
            modelBuilder.Configurations.Add(new DomainConfiguration());
            modelBuilder.Configurations.Add(new ExerciseConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
        }
    }
}

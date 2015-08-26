
namespace SnappetChallenge.DAL
{
    using System.Data.Entity;

    using Entities;

    public interface ISnappetChallengeContext: IDbContext
    {
        DbSet<StudentAnswer> StudentAnswers { get; set; }

        DbSet<Student> Students { get; set; }

        DbSet<Subject> Subjects { get; set; }

        DbSet<Domain> Domains { get; set; }

        DbSet<Exercise> Exercises { get; set; }

        DbSet<Answer> Answers { get; set; }

        DbSet<Objective> Objectives { get; set; }
    }
}

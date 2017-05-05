namespace SnappetChallenge.DAL.Repository
{
    using System;
    using Entities;
    
    public interface IUnitOfWork : IDisposable
    {
        SnappetChallengeRepository<Answer> AnswerRepository { get; }
        SnappetChallengeRepository<Domain> DomainRepository { get; }
        SnappetChallengeRepository<Exercise> ExerciseRepository { get; }
        SnappetChallengeRepository<Objective> ObjectiveRepository { get; }
        SnappetChallengeRepository<Student> StudentRepository { get; }
        SnappetChallengeRepository<StudentAnswer> StudentAnswerRepository { get; }
        SnappetChallengeRepository<Subject> SubjectRepository { get; }

        void Save();
    }
}

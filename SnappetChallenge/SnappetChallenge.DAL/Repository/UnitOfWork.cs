namespace SnappetChallenge.DAL.Repository
{
    using System;
    using Entities;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SnappetChallengeContext _context;
        private SnappetChallengeRepository<Answer> _answerRepository;
        private SnappetChallengeRepository<Domain> _domainRepository;
        private SnappetChallengeRepository<Exercise> _exerciseRepository;
        private SnappetChallengeRepository<Objective> _objectiveRepository;
        private SnappetChallengeRepository<Student> _studentRepository;
        private SnappetChallengeRepository<StudentAnswer> _studentAnswerRepository;
        private SnappetChallengeRepository<Subject> _subjectRepository;

        private bool _disposed = false;

        public UnitOfWork(SnappetChallengeContext context)
        {
            this._context = context;
        }

        public SnappetChallengeRepository<Answer> AnswerRepository
        {
            get
            {
                if (this._answerRepository == null)
                {
                    this._answerRepository = new SnappetChallengeRepository<Answer>(_context);
                }
                return _answerRepository;
            }
        }
        public SnappetChallengeRepository<Domain> DomainRepository
        {
            get
            {
                if (this._domainRepository == null)
                {
                    this._domainRepository = new SnappetChallengeRepository<Domain>(_context);
                }
                return _domainRepository;
            }
        }
        public SnappetChallengeRepository<Exercise> ExerciseRepository
        {
            get
            {
                if (this._exerciseRepository == null)
                {
                    this._exerciseRepository = new SnappetChallengeRepository<Exercise>(_context);
                }
                return _exerciseRepository;
            }
        }
        public SnappetChallengeRepository<Objective> ObjectiveRepository
        {
            get
            {
                if (this._objectiveRepository == null)
                {
                    this._objectiveRepository = new SnappetChallengeRepository<Objective>(_context);
                }
                return _objectiveRepository;
            }
        }
        public SnappetChallengeRepository<Student> StudentRepository
        {
            get
            {
                if (this._studentRepository == null)
                {
                    this._studentRepository = new SnappetChallengeRepository<Student>(_context);
                }
                return _studentRepository;
            }
        }
        public SnappetChallengeRepository<StudentAnswer> StudentAnswerRepository
        {
            get
            {
                if (this._studentAnswerRepository == null)
                {
                    this._studentAnswerRepository = new SnappetChallengeRepository<StudentAnswer>(_context);
                }
                return _studentAnswerRepository;
            }
        }
        public SnappetChallengeRepository<Subject> SubjectRepository
        {
            get
            {
                if (this._subjectRepository == null)
                {
                    this._subjectRepository = new SnappetChallengeRepository<Subject>(_context);
                }
                return _subjectRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        // make sure IDisposable:Dispose gets called only once
        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

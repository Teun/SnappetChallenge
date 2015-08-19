namespace SnappetChallenge.DAL.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Entities;

    public class StudentAnswerRepository : IRepository<StudentAnswer>, IDisposable
    {
        private SnappetChallengeContext _context = new SnappetChallengeContext();

        /// <summary>
        /// Yes I am returning IQueryable, please shoot me, but not before I explain why.
        /// 
        /// Basically this "repository" is just a thin wrapper around de DbSets. 
        /// This repository is only being consumed by the service layer. This service layer will take care of limiting results for paging etc.
        /// 
        /// In case of large datasets it's way more efficient to use IQueryable then IEnumerable, because this limits the actual data returned
        /// from the database (by generated SQL), instead of loading all data in memory and filtering/ limiting there.
        /// 
        /// Also, this way we are not cluthering the repository layer with a gazillion different methods for filtering etc but that's a matter of taste.
        /// </summary>
        /// <param name="predicate">The predicate to select data</param>
        /// <returns></returns>
        public IQueryable<StudentAnswer> GetAll(Expression<Func<StudentAnswer, bool>> predicate = null)
        {
            return predicate != null ? _context.StudentAnswers.Where(predicate) : _context.StudentAnswers;
        }

        public StudentAnswer Get(Expression<Func<StudentAnswer, bool>> predicate)
        {
            return _context.StudentAnswers.FirstOrDefault(predicate);
        }

        public void Add(StudentAnswer entity)
        {
            _context.StudentAnswers.Add(entity);
        }

        public void Delete(StudentAnswer entity)
        {
            _context.StudentAnswers.Remove(entity);
        }

        internal void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context = null;
        }
    }
}

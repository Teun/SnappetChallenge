namespace SnappetChallenge.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using DAL.Entities;
    using DAL.Repository;
    using Interfaces;

    public class StudentAnswerService : IStudentAnswerService
    {
        private readonly IRepository<StudentAnswer> _studentAnswerRepository;

        public StudentAnswerService(IRepository<StudentAnswer> studentAnswerRepository)
        {
            _studentAnswerRepository = studentAnswerRepository;
        }

        public List<StudentAnswer> Get(Expression<Func<StudentAnswer, bool>> whereClause, int startIndex, int pageSize)
        {
            return
                _studentAnswerRepository
                    .GetAll(whereClause)
                    .OrderBy(s => s.SubmitDateTime) // default order by date asc
                    .ThenBy(s => s.Domain) // this might speed things up a bit for client side grouping
                    .Skip(startIndex) // offset for paging
                    .Take(pageSize) // limit num or records for paging
                    .ToList(); 
        }
    }
}
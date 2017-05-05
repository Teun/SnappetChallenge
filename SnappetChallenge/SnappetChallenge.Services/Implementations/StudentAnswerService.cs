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
        private readonly IUnitOfWork unitOfWork;

        public StudentAnswerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<StudentAnswer> Get(Expression<Func<StudentAnswer, bool>> whereClause, int startIndex, int pageSize)
        {
            return
                unitOfWork.StudentAnswerRepository
                    .Get(whereClause, answers => answers.OrderBy(a => a.SubmitDateTime).ThenBy(a => a.Domain))
                        .Skip(startIndex) // offset for paging
                        .Take(pageSize) // limit num or records for paging
                        .ToList();
        }
    }
}
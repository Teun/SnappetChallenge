namespace SnappetChallenge.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using DAL.Entities;
    using DAL.Repository;
    using Interfaces;

    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<Student> Get(Expression<Func<Student, bool>> whereClause)
        {
            return unitOfWork.StudentRepository.Get(whereClause).ToList();
        }
    }
}

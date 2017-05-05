
namespace SnappetChallenge.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using DAL.Entities;

    public interface IStudentService
    {
        List<Student> Get(Expression<Func<Student, bool>> whereClause);
    }
}

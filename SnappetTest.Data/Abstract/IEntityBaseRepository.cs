using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SnappetTest.Data.Abstract
{
    public interface IEntityBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetSingle(Expression<Func<T, bool>> predicate);
    }
}

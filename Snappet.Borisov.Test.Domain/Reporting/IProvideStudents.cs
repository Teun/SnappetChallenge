using System.Collections.Generic;

namespace Snappet.Borisov.Test.Domain.Reporting
{
    public interface IProvideStudents
    {
        IEnumerable<Student> GetAll();
    }
}
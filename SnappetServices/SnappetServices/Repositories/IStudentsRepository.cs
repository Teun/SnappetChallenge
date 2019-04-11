using System.Collections.Generic;
using SnappetServices.Models;

namespace SnappetServices.Repositories
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetAll();
    }
}
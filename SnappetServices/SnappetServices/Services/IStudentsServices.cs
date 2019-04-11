using System.Collections.Generic;
using SnappetServices.DTOs;

namespace SnappetServices.Services
{
    public interface IStudentsServices
    {
        IEnumerable<StudentV1Dto> GetAll();
    }
}
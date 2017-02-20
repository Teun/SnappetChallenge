using System;
using System.Threading.Tasks;
using Snappet.Test.TopStudents.Interface.Dtos;

namespace Snappet.Test.TopStudents.Interface.Interfaces
{
    public interface ITopStudentsQuery
    {
        Task<TopStudentsDto> GetAsync(string subject, TopStudentsRecordTypes type, DateTime date);
    }
}
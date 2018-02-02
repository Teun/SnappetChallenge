using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Models.Interfaces
{
    public interface IDataRepository
    {
        List<ClassAssignment> GetClassAssignments();

        List<ClassAssignment> GetClassAssignmentsByDate(DateTime dateTime);
    }
}

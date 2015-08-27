using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SnappetChallenge.DAL.Entities;

namespace SnappetChallenge.Services.Interfaces
{
    public interface IExerciseService
    {
        IEnumerable<Exercise> GetExercisesByObjectiveInRange(long objectiveId, DateTime? start, DateTime end);
    }
}

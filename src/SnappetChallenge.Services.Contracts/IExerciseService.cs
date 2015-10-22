using SnappetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Services.Contracts
{
    public interface IExerciseService
    {
        IEnumerable<Exercise> GetAllExercises();
        int GetExerciseCount();
    }
}

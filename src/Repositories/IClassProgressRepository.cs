using SnappetChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Repositories
{
    public interface IClassProgressRepository
    {
        Task<IList<LearningObjective>> GetDailyLearningObjectiveProgressAsync(DateTime dateTime);
        Task<IList<Student>> GetDailyStudentsProgressAsync(DateTime dateTime, string learningObjective);
    }
}

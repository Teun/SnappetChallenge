using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TutorBoard.Dal.Models;

namespace TutorBoard.Dal.Repositories
{
    public interface IWorkResultRepository
    {
        /// <summary>
        /// Returns the number of excercises edited on specified date
        /// </summary>
        /// <param name="date">date for calculation</param>
        /// <returns>Number of edited excercises on specifed date</returns>
        Task<int> CountExercisesAsync(DateTime date);

        /// <summary>
        /// Returns the number of excercises edited on specified date for given subject
        /// </summary>
        /// <param name="date">date for calculation</param>
        /// <param name="subject">subject to count</param>
        /// <returns>Number of edited excercises on specifed date for given subject</returns>
        Task<int> CountExercisesForSubjectAsync(DateTime date, string subject);

        /// <summary>
        /// Get progress of the users on given date
        /// </summary>
        /// <param name="date">date for calculation</param>
        /// <returns>UserProgress of given date</returns>
        Task<IEnumerable<UserProgress>> GetUserProgressAsync(DateTime date);
    }
}

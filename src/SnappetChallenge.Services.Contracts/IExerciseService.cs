using SnappetChallenge.Domain.Entities;
using System.Collections.Generic;

namespace SnappetChallenge.Services.Contracts
{
    /// <summary>
    /// Provides functionality for performing business logic related to exercises
    /// </summary>
    public interface IExerciseService
    {
        /// <summary>
        /// Get a complete list of all exercises
        /// </summary>
        /// <returns>The list of exercises</returns>
        IEnumerable<Exercise> GetAllExercises();
        
        /// <summary>
        /// Get the total number of exercises
        /// </summary>
        /// <returns>The total number of exercises</returns>
        int GetExerciseCount();
    }
}

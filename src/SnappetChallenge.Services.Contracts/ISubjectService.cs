using SnappetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SnappetChallenge.Services.Contracts
{
    /// <summary>
    /// Provides functionality for performing business logic related to subjects
    /// </summary>
    public interface ISubjectService
    {
        /// <summary>
        /// Get time spent on answers in percentage divided between all subjects
        /// </summary>
        /// <param name="from">The start of the range in which the answers of a subject should fall</param>
        /// <param name="until">The end of the range in which the answers of a subject should fall</param>
        /// <returns>A dictionary containing each subject and the percentage of time spent on that subject</returns>
        Dictionary<Subject, float> GetTimeSpentInPercentagesBySubject(DateTime from, DateTime until);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

using DataRepositories.Data;

namespace DataRepositories.Interfaces
{
    /// <summary>
    /// Defines the interface to the in-memory answer database
    /// </summary>
    public interface IAnswerDB
    {
        /// <summary>
        /// Retrieves an IQueryable that can be used to query the answers
        /// </summary>
        /// <returns>An IQueryable that can be used to query the answers</returns>
        IQueryable<Answer> GetAnswerQueryable();
    }
}

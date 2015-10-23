using SnappetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SnappetChallenge.Services.Contracts
{
    /// <summary>
    /// Provides functionality for performing business logic related to users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get a complete list of all users
        /// </summary>
        /// <returns>The list of users</returns>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Get the total number of users
        /// </summary>
        /// <returns>The total number of users</returns>
        int GetUserCount();

        Dictionary<User, int> GetProgressByUser(DateTime from, DateTime until);
    }
}

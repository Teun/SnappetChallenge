using System.Collections.Generic;
using System.Threading.Tasks;
using TutorBoard.Dal.Models;

namespace TutorBoard.Dal.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Returns a single user by id
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>User if fond, null otherwise</returns>
        Task<User> GetOneAsync(int userId);
        
        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns>List of users</returns>
        Task<IEnumerable<User>> GetAsync();
    }
}

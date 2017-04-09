using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorBoard.Dal.Data;
using TutorBoard.Dal.Models;

namespace TutorBoard.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _dataContext;

        public UserRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <inheritdoc />
        public Task<IEnumerable<User>> GetAsync()
        {
            return Task.FromResult<IEnumerable<User>>(
                _dataContext.GetWorkData()
                .AsParallel()
                .Select(wd => wd.UserId)
                .Distinct()
                .Select(uid => new User { UserId = uid, Name = string.Format("Leerling {0}", uid) })
                .ToList());
        }

        /// <inheritdoc />
        public Task<User> GetOneAsync(int userId)
        {
            if (!_dataContext.GetWorkData().Any(wd => wd.UserId == userId)) return Task.FromResult<User>(null);

            return Task.FromResult(new User { UserId = userId, Name = string.Format("Leerling {0}", userId) });
        }
    }
}

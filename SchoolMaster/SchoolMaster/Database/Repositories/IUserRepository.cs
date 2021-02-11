using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolMaster.Models;

namespace SchoolMaster.Database.Repositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    }
}
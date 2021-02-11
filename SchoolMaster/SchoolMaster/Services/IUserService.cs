using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolMaster.Models.DataTransferObjects;

namespace SchoolMaster.Services
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    }
}
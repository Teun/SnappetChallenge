using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolMaster.Models;

namespace SchoolMaster.Database.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(WorkDbContext workDbContext) : base(workDbContext)
        {
        }

        public async Task<ICollection<User>> GetAllUsersAsync(CancellationToken token = default)
        {
            return await DbContext.Users
                .OrderBy(u => u.Firstname)
                .ThenBy(u => u.LastName)
                .ToListAsync(token);
        }
    }
}
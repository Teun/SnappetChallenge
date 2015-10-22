using SnappetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Services.Contracts
{
    public interface IUserService
    {
        int GetUserCount();
        IEnumerable<User> GetAllUsers();
    }
}

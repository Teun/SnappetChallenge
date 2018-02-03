using System.Linq;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Data
{
    public interface IUsersRepository
    {
        IQueryable<UserDb> Query();
    }
}
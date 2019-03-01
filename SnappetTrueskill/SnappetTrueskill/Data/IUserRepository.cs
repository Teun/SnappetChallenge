using Moserware.Skills;
using SnappetTrueskill.Domain;
using System.Collections.Generic;

namespace SnappetTrueskill.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        void Insert(User user);
        bool Contains(int id);
        void UpdateRating(int id, Rating newRating);
    }
}

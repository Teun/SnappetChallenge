﻿using Moserware.Skills;
using SnappetTrueskill.Domain;
using System.Collections.Generic;

namespace SnappetTrueskill.Data
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly Dictionary<int, User> _users = new Dictionary<int, User>();

        public bool Contains(int id)
        {
            return _users.ContainsKey(id);
        }

        public User Get(int id)
        {
            return _users[id];
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }

        public void Insert(User user)
        {
            _users.Add(user.Id, user);
        }

        public void UpdateRating(int id, string subject, Rating newRating)
        {
            if (!_users[id].Ratings.ContainsKey(subject))
                _users[id].Ratings.Add(subject, newRating);
            else
                _users[id].Ratings[subject] = newRating;
        }
    }
}

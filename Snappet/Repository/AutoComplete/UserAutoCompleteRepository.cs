using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snappet.Entity;

namespace Snappet.Repository.AutoComplete
{
    public class UserAutoCompleteRepository : IAutoCompleteRepository
    {
        private IEnumerable<User> _users;

        public Task<ICollection<AutoCompleteItem>> AutoComplete(string input, int count)
        {
            return Task.FromResult<ICollection<AutoCompleteItem>>(_users
                .Where(x => x.Id.ToString().Contains(input, StringComparison.InvariantCultureIgnoreCase)).Take(count)
                .Select(x =>
                    new AutoCompleteItem
                    {
                        Identifier = x.Id.ToString(),
                        Type = AutoCompleteType.User
                    }).ToList());
        }

        public Task SetData(IEnumerable<User> data)
        {
            _users = data;
            return Task.CompletedTask;
        }
    }
}
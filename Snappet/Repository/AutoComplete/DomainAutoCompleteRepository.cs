using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snappet.Entity;

namespace Snappet.Repository.AutoComplete
{
    public class DomainAutoCompleteRepository : IAutoCompleteRepository
    {
        private IEnumerable<Domain> _domains;

        public Task<ICollection<AutoCompleteItem>> AutoComplete(string input, int count)
        {
            return Task.FromResult<ICollection<AutoCompleteItem>>(_domains
                .Where(x => x.Name.Contains(input, StringComparison.InvariantCultureIgnoreCase)).Take(count).Select(x =>
                    new AutoCompleteItem
                    {
                        Identifier = x.Name,
                        Type = AutoCompleteType.Domain
                    }).ToList());
        }

        public Task SetData(IEnumerable<Domain> data)
        {
            _domains = data;
            return Task.CompletedTask;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snappet.Entity;

namespace Snappet.Repository.AutoComplete
{
    public class SubjectAutoCompleteRepository : IAutoCompleteRepository
    {
        private IEnumerable<Subject> _subjects;

        public Task<ICollection<AutoCompleteItem>> AutoComplete(string input, int count)
        {
            return Task.FromResult<ICollection<AutoCompleteItem>>(_subjects
                .Where(x => x.Name.Contains(input, StringComparison.InvariantCultureIgnoreCase)).Take(count).Select(x =>
                    new AutoCompleteItem
                    {
                        Identifier = x.Name,
                        Type = AutoCompleteType.Subject
                    }).ToList());
        }

        public Task SetData(IEnumerable<Subject> data)
        {
            _subjects = data;
            return Task.CompletedTask;
        }
    }
}
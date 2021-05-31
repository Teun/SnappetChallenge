using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snappet.Entity;

namespace Snappet.Repository.AutoComplete
{
    public class ExerciseAutoCompleteRepository : IAutoCompleteRepository
    {
        private IEnumerable<Exercise> _exercises;

        public Task<ICollection<AutoCompleteItem>> AutoComplete(string input, int count)
        {
            return Task.FromResult<ICollection<AutoCompleteItem>>(_exercises
                .Where(x => x.Id.ToString().Contains(input, StringComparison.InvariantCultureIgnoreCase)).Take(count)
                .Select(x => new AutoCompleteItem
                {
                    Identifier = x.Id.ToString(),
                    Type = AutoCompleteType.Exercise
                }).ToList());
        }

        public Task SetData(IEnumerable<Exercise> data)
        {
            _exercises = data;
            return Task.CompletedTask;
        }
    }
}
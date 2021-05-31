using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snappet.Entity;

namespace Snappet.Repository.AutoComplete
{
    public class LearningObjectiveAutoCompleteRepository : IAutoCompleteRepository
    {
        private IEnumerable<LearningObjective> _learningObjectives;

        public Task<ICollection<AutoCompleteItem>> AutoComplete(string input, int count)
        {
            return Task.FromResult<ICollection<AutoCompleteItem>>(_learningObjectives
                .Where(x => x.Name.Contains(input, StringComparison.InvariantCultureIgnoreCase)).Take(count).Select(x =>
                    new AutoCompleteItem
                    {
                        Identifier = x.Name,
                        Type = AutoCompleteType.LearningObjective
                    }).ToList());
        }

        public Task SetData(IEnumerable<LearningObjective> data)
        {
            _learningObjectives = data;
            return Task.CompletedTask;
        }
    }
}
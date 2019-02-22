using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using StudentsAPI.WebApi.Models;

namespace StudentsAPI.WebApi.Context
{
    public interface IWorkItemRepository
    {
        Task<IEnumerable<WorkItem>> GetWorkItemsAsync(FilterDefinition<WorkItem> filter, int page);
        Task<IEnumerable<ProgressItem>> GetProgressAsync(FilterDefinition<WorkItem> filter);
    }

    public class WorkItemRepository : IWorkItemRepository
    {
        private IWorkItemContext _workContext;
        private readonly int pageSize = 100;

        public WorkItemRepository(IWorkItemContext showContext)
        {
            _workContext = showContext;
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItemsAsync(FilterDefinition<WorkItem> filter, int page)
        {
            var skip = pageSize * page;

            var result = await _workContext.WorkItems.WithReadPreference(ReadPreference.Secondary)
                .Find(filter)
                .Skip(skip)
                .Limit(pageSize)
                .SortByDescending(i => i.SubmitDateTime)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<ProgressItem>> GetProgressAsync(FilterDefinition<WorkItem> filter)
        {
            var result = await _workContext.WorkItems.WithReadPreference(ReadPreference.Secondary)
                .Find(filter)
                .SortBy(i => i.SubmitDateTime)
                .ToListAsync();

            var dictByDate = new Dictionary<DateTime, ProgressItem>();

            foreach (var r in result)
            {
                if (r.SubmitDateTime.HasValue && float.TryParse(r.Progress, out float progressVal))
                {
                    if (!dictByDate.ContainsKey(r.SubmitDateTime.Value.Date))
                        dictByDate.Add(r.SubmitDateTime.Value.Date, new ProgressItem() { Date = r.SubmitDateTime.Value.Date });

                    dictByDate[r.SubmitDateTime.Value.Date].TotalProgress += progressVal;
                }

            }
            return dictByDate.Values.ToList();
        }
    }
}

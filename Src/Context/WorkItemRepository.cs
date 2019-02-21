using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using StudentsAPI.WebApi.Models;

namespace StudentsAPI.WebApi.Context
{
    public interface IWorkItemRepository
    {
        Task<IEnumerable<WorkItem>> GetWorkItemsAsync(FilterDefinition<WorkItem> filter, int page);
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

        public async Task SaveBatchAsync(IEnumerable<WorkItem> items)
        {
            var bulk = new List<WriteModel<WorkItem>>();
            foreach (var wi in items)
            {
                var upsertOne = new ReplaceOneModel<WorkItem>(Builders<WorkItem>.Filter.Where(x => x.Id == wi.Id), wi)
                {
                    IsUpsert = true
                };

                bulk.Add(upsertOne);
            }
            await _workContext.WorkItems.BulkWriteAsync(bulk);
        }
    }
}

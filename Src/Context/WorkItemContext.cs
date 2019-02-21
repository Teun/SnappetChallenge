using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentsAPI.WebApi.Configuration;
using StudentsAPI.WebApi.Models;

namespace StudentsAPI.WebApi.Context
{
    public interface IWorkItemContext
    {
        IMongoCollection<WorkItem> WorkItems { get; }
    }

    public class WorkItemContext : IWorkItemContext
    {
        private readonly IMongoDatabase _db;
        public WorkItemContext(IOptions<MongoDbConfiguration> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.DatabaseName);
        }
        public IMongoCollection<WorkItem> WorkItems => _db.GetCollection<WorkItem>("Work");

    }
}

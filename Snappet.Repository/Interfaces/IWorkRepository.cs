using System.Data;
using Snappet.Core.Dtos;
using Snappet.Repository.Helpers;

namespace Snappet.Repository.Interfaces
{
    public interface IWorkRepository
    {
        void Save(WorkItem workItem);
        void BulkInsert(DataTable workItem);
        WorkItem Find(long submittedAnswerId);
        QueryResult<WorkItem> FindAll(int pageIndex = 1, int pageSize = 10);
        QueryResult<WorkItem> FindByUser(long userId, int pageIndex = 1, int pageSize = 10);
        QueryResult<WorkItem> FindBySubject(string subject, int pageIndex = 1, int pageSize = 10);
        void DeleteWorkItem(long logId = 0);
    }
}

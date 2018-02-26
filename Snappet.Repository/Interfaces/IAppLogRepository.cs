using System;
using Snappet.Core.Dtos;
using Snappet.Repository.Helpers;

namespace Snappet.Repository.Interfaces
{

    public interface IAppLogRepository
    {
        void Log(string message, string stackTrace);
        void Log(Exception exception);
        QueryResult<AppLog> FindAll(int pageIndex = 1, int pageSize = 20);
        void DeleteErrorLogs(long logId = 0);
    }
}

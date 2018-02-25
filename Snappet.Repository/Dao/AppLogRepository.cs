using System;
using System.Data;
using System.Linq;
using Dapper;
using Snappet.Core.Dtos;
using Snappet.Repository.Helpers;
using Snappet.Repository.Interfaces;

namespace Snappet.Repository.Dao
{

    public class AppLogRepository : IAppLogRepository
    {

        static AppLogRepository _appLogRepository;

        public static AppLogRepository GetInstance()
        {
            return _appLogRepository ?? (_appLogRepository = new AppLogRepository());
        }

        public void Log(string message, string stackTrace)
        {
            try
            {
                using (var conn = SqldaoFactory.GetConnection())
                {
                    conn.ExecuteAsync(@"application_logs_insert",
                        new
                        {
                            logdate = DateHelper.GetCurrentDate(),
                            message,
                            stackTrace
                        });
                }
            }
            catch (Exception)
            {
                //Do nothing
            }
        }

        public void Log(Exception exception)
        {
            try
            {
                using (var conn = SqldaoFactory.GetConnection())
                {
                    conn.ExecuteAsync(@"INSERT INTO application_logs(logmessage, stacktrace, logdate)
                    VALUES(@message, @stacktrace, @logdate)", new
                                                            {
                                                                logdate = DateHelper.GetCurrentDate(),
                                                                message = exception.Message,
                                                                stacktrace = exception.StackTrace
                                                            });
                }
            }
            catch (Exception)
            {
                //Do nothing
            }
        }

        public QueryResult<AppLog> FindAll(int pageIndex = 0, int pageSize = 20)
        {
            using (var conn = SqldaoFactory.GetConnection())
            {
                var pagingInfo = QueryHelper.GetPagingRowNumber(pageIndex, pageSize);
                var result = conn.QueryMultiple("application_logs_findall",
                    new
                    {
                        rowStart = pagingInfo.RowStart,
                        rowEnd = pagingInfo.RowEnd
                    },
                    commandType: CommandType.StoredProcedure);

                var appLog = result.Read<AppLog>();


                return new QueryResult<AppLog>(appLog, result.Read<int>().First());
            }
        }

        public void DeleteErrorLogs(long logId = 0)
        {
            using (var conn = SqldaoFactory.GetConnection())
            {
                var command = logId == 0 ? @"TRUNCATE TABLE application_logs" : @"DELETE application_logs WHERE Id =" + logId;
                conn.ExecuteAsync(command);

            }
        }
    }
}

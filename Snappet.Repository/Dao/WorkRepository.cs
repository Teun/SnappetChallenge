using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Snappet.Core.Dtos;
using Snappet.Core.Utils;
using Snappet.Repository.Helpers;
using Snappet.Repository.Interfaces;

namespace Snappet.Repository.Dao
{

    public class WorkRepository : IWorkRepository
    {

        readonly AppLogRepository _appLogRepository = AppLogRepository.GetInstance();

        public void Save(WorkItem workItem)
        {
            try
            {
                using (var conn = SqldaoFactory.GetConnection())
                {
                    conn.ExecuteAsync("", new
                                              {
                                                  workItem.Correct,
                                                  workItem.Difficulty,
                                                  workItem.ExerciseId,
                                                  workItem.SubmittedAnswerId,
                                                  workItem.UserId,
                                                  workItem.LearningObjective,
                                                  workItem.Progress,
                                                  workItem.SubmitDateTime,
                                                  workItem.Subject,
                                                  workItem.Domain
                                              });
                }
            }
            catch (Exception exception)
            {
                _appLogRepository.Log(exception);
            }
        }

        public void BulkInsert(DataTable workItem)
        {
            using (var connection = SqldaoFactory.GetConnection())
            {
                var startTime = DateTime.Now;
                connection.Open();

                var transaction = connection.BeginTransaction();
                try
                {
                    _appLogRepository.Log("About to start Upload", ".....Upload in progress");

                    using (var sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                    {
                        sqlBulkCopy.BulkCopyTimeout = 0;
                        sqlBulkCopy.BatchSize = 10000;
                        sqlBulkCopy.DestinationTableName = ApplicationConstants.WorkItem;
                        sqlBulkCopy.WriteToServer(workItem);
                    }
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    _appLogRepository.Log(exception);
                    transaction.Rollback();
                }
                finally
                {
                    transaction.Dispose();
                    connection.Close();
                    var stoppageTime = DateTime.Now;
                    _appLogRepository.Log("Total Time taken", string.Format("Time In Seconds {0}", (stoppageTime - startTime).TotalSeconds));
                }
            }

        }

        public void Log(Exception exception)
        {
            throw new NotImplementedException();
        }

        public WorkItem Find(long id)
        {
            throw new NotImplementedException();
        }

        public QueryResult<WorkItem> FindAll(int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public QueryResult<WorkItem> FindByUser(long userId, int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public QueryResult<WorkItem> FindBySubject(long subjectId, int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkItem(long logId = 0)
        {
            throw new NotImplementedException();
        }
    }
}

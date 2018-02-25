using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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


        public WorkItem Find(long submittedAnswerId)
        {

            using (var conn = SqldaoFactory.GetConnection())
            {
                var payments = conn.Query<WorkItem>("work_item_findbysubmitted_answerId",
                    new { submittedAnswerId }, commandType: CommandType.StoredProcedure);

                return payments.SingleOrDefault();
            }
        }

        public QueryResult<WorkItem> FindAll(int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                using (var conn = SqldaoFactory.GetConnection())
                {
                    var pagingInfo = QueryHelper.GetPagingRowNumber(pageIndex, pageSize);
                    var result = conn.QueryMultiple("work_item_findall",
                        new
                        {
                            pagingInfo.RowStart,
                            pagingInfo.RowEnd
                        },
                        commandType: CommandType.StoredProcedure);

                    var workItems = result.Read<WorkItem>();


                    return new QueryResult<WorkItem>(workItems, result.Read<int>().First());
                }
            }
            catch (Exception exception)
            {
                _appLogRepository.Log(exception);
            }
            return null;
        }

        public QueryResult<WorkItem> FindByUser(long userId, int pageIndex = 1, int pageSize = 10)
        {

            using (var conn = SqldaoFactory.GetConnection())
            {
                var pagingInfo = QueryHelper.GetPagingRowNumber(pageIndex, pageSize);
                var result = conn.QueryMultiple("work_item_findbyuser",
                    new
                    {
                        pagingInfo.RowStart,
                        pagingInfo.RowEnd,
                        userId
                    },
                    commandType: CommandType.StoredProcedure);

                var workItems = result.Read<WorkItem>();


                return new QueryResult<WorkItem>(workItems, result.Read<int>().First());
            }
        }

        public QueryResult<WorkItem> FindBySubject(string subject, int pageIndex = 1, int pageSize = 10)
        {
            using (var conn = SqldaoFactory.GetConnection())
            {
                var pagingInfo = QueryHelper.GetPagingRowNumber(pageIndex, pageSize);
                var result = conn.QueryMultiple("work_item_findbysubject",
                    new
                    {
                        pagingInfo.RowStart,
                        pagingInfo.RowEnd,
                        subject

                    },
                    commandType: CommandType.StoredProcedure);

                var workItems = result.Read<WorkItem>();


                return new QueryResult<WorkItem>(workItems, result.Read<int>().First());
            }
        }

        public void DeleteWorkItem(long logId = 0)
        {
            throw new NotImplementedException();
        }
    }
}

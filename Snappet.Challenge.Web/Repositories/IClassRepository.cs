using System;
using System.Collections.Generic;
using Snappet.Challenge.Web.Core.Models;

namespace Snappet.Challenge.Web.Repositories
{
    public interface IClassRepository
    {
        IEnumerable<Work> GetWorkByDate(DateTime? date);
        IEnumerable<Work> GetWorkByUser(int? userId);
        IEnumerable<Work> GetWorkByUser(int userId, int pageSize, int pageIndex);
        IEnumerable<Summary> GetUserWorkSummarizedByDate(DateTime date);
        Summary GetAllWorkSummirazedByDate(DateTime date);
        IEnumerable<Summary> GetUserWorkHistoryByObjective(int userId);
    }
}
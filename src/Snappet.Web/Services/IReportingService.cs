using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Snappet.Web.Controllers;
using Snappet.Web.Helpers;
using Snappet.Web.Persistence;
using Snappet.Web.Persistence.Models;

namespace Snappet.Web.Services
{
    public interface IReportingService
    {
        Task<ExecuteReportResult> ExecuteReport(Report report, List<KeyValuePair<string, object>> parameters);
    }

    public class ReportingService : IReportingService
    {
        private readonly SnappetDbContext context;

        public ReportingService(SnappetDbContext context)
        {
            this.context = context;
        }

        public async Task<ExecuteReportResult> ExecuteReport(Report report, List<KeyValuePair<string, object>> parameters)
        {
            if (report is null)
            {
                throw new ArgumentNullException(nameof(report));
            }

            var storageProcedure = new StorageProcedure()
            {
                Name = report.StorageProcedure,
                Parameters = parameters
            };

            var storageProcedureResult = await StorageProcedureHelper.ExecuteReport(context, storageProcedure);

            var result = new ExecuteReportResult
            {
                Id = report.Id,
                DisplayName = report.DisplayName,
                Columns = storageProcedureResult.Columns,
                Rows = storageProcedureResult.Rows
            };

            return result;
        }
    }

    public class ExecuteReportResult
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public List<string> Columns { get; set; } = new List<string>();
        public List<List<object>> Rows { get; set; } = new List<List<object>>();
    }


}

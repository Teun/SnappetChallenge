using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Snappet.Web.Helpers;
using Snappet.Web.Persistence;
using Snappet.Web.Persistence.Models;
using Snappet.Web.Persistence.Repositories;

namespace Snappet.Web.Services
{
    public class ReportingService : IReportingService
    {
        private readonly SnappetDbContext context;
        private IReportRepository reportRepository;

        public ReportingService(SnappetDbContext context)
        {
            this.context = context;
        }

        public async Task<ExecuteReportResult> ExecuteReportAsync(Report report, Dictionary<string, object> parameters)
        {
            if (report is null)
            {
                throw new ArgumentNullException(nameof(report));
            }

            if (string.IsNullOrEmpty(report.StorageProcedure))
            {
                throw new ArgumentNullException(nameof(report.StorageProcedure) + " cannot be empty!");
            }


            var storageProcedureParameters = new List<StorageProcedureParameter>();

            foreach (var reportConfigurationParameter in report.ReportConfiguration.Parameters)
            {
                if (!parameters.ContainsKey(reportConfigurationParameter.Name))
                {
                    throw new ArgumentException($"Report parameter {reportConfigurationParameter.Name} not specified.");
                }

                var storageProcedureParameter = new StorageProcedureParameter
                {
                    Name = reportConfigurationParameter.Name,
                    Type = reportConfigurationParameter.Type,
                    Value = parameters[reportConfigurationParameter.Name]
                };

                storageProcedureParameters.Add(storageProcedureParameter);
            }


            var storageProcedure = new StorageProcedure()
            {
                Name = report.StorageProcedure,
                Parameters = storageProcedureParameters
            };

            var storageProcedureResult = await SqlHelper.ExecuteStorageProcedureAsync(context, storageProcedure);

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
}
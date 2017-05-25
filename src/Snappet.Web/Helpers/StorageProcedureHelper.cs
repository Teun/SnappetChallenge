using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Snappet.Web.Persistence;
using Snappet.Web.Services;

namespace Snappet.Web.Helpers
{
    public static class StorageProcedureHelper
    {
        public static async Task<StorageProcedureResult> ExecuteReport(SnappetDbContext context, StorageProcedure storageProcedure)
        {
            var reportResult = new StorageProcedureResult();

            DbCommand command = context.Database.GetDbConnection().CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storageProcedure.Name;

            foreach (var storageProcedureParameter in storageProcedure.Parameters)
            {
                // lets assume that all parameters are datetime. for now :)
                command.Parameters.Add(
                    new SqlParameter(
                        storageProcedureParameter.Key,
                        DateTime.Parse(storageProcedureParameter.Value.ToString())));
            }

            context.Database.OpenConnection();

            var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                if (!reportResult.Columns.Any())
                {
                    var columns = new List<string>();

                    for (int colIndex = 0; colIndex < reader.FieldCount; colIndex++)
                    {
                        columns.Add(reader.GetName(colIndex));
                    }

                    reportResult.Columns = columns;
                }


                var reportRow = new List<object>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    reportRow.Add(reader[i]);
                }

                reportResult.Rows.Add(reportRow);
            }

            return reportResult;
        }
    }

    public class StorageProcedure
    {
        public string Name { get; set; }
        public IEnumerable<KeyValuePair<string, object>> Parameters { get; set; } = new List<KeyValuePair<string, object>>();
    }

    public class StorageProcedureResult
    {
        public List<string> Columns { get; set; } = new List<string>();
        public List<List<object>> Rows { get; set; } = new List<List<object>>();
    }
}

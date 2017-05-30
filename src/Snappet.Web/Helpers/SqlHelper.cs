using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Snappet.Web.Helpers
{
    public static class SqlHelper
    {
        public static async Task<StorageProcedureResult> ExecuteStorageProcedure(DbContext context,
            StorageProcedure storageProcedure)
        {
            var reportResult = new StorageProcedureResult();

            DbCommand command = context.Database.GetDbConnection().CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storageProcedure.Name;

            foreach (var storageProcedureParameter in storageProcedure.Parameters)
            {
                var parameter = StorageProcedureParameterFactory.CreateSqlParameter(
                    storageProcedureParameter.Type,
                    storageProcedureParameter.Name,
                    storageProcedureParameter.Value);

                command.Parameters.Add(parameter);
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



        public static Task<int> ExecuteRawSql(DbContext context, string sql)
        {
            DbCommand command = context.Database.GetDbConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection.Open();


            return command.ExecuteNonQueryAsync();
        }
    }
}

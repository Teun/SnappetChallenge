using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using WorkOverviewAPI.Domain;
using WorkOverviewAPI.Repositories.Interfaces;

namespace WorkOverviewAPI.Repositories
{
    public class DayOverviewRepository : IDayOverviewRepository
    {
        private IDbConnection _dbConnection;
        public DayOverviewRepository(IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("LocalConnection");
            _dbConnection = new SqlConnection(connString);
        }

        public DayOverview getByDate(DateTime tillDateTime)
        {
            return _dbConnection.QuerySingleOrDefault<DayOverview>
            (
                "GetDayoverviewByDate",
                commandType: CommandType.StoredProcedure,
                param: new {
                        tillDateTime
                    }
                );
        }

        public DayOverview getById(int id)
        {
            String sql = "select * from [DayOverview] where Id = @Id";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            return _dbConnection.QuerySingleOrDefault<DayOverview>
            (
                sql,
                dynamicParameters                
                );

        }

        public Task<IEnumerable<DayOverview>> getByMonth(int year, int month)
        {
            throw new NotImplementedException();
        }

        public DayOverview getBySubjectByDate(DateTime tillDT)
        {
            throw new NotImplementedException();
        }
    }
}

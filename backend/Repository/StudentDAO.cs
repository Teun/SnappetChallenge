using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

namespace backend.Repository
{
    public class StudentDAO
    {
        private IConfiguration _config;

        public StudentDAO(IConfiguration config)
        {
            this._config = config;
        }

         public IEnumerable<Student> GetRoomReport(System.DateTime filterDate, string subject, string classDomain, int range)
        {
            using (MySqlConnection conn = new MySqlConnection(
                _config.GetConnectionString("SnappetDB")))
            {
                return conn.Query<Student>(
                    "spStudentsReport",
                    new { 
                        filterDate = filterDate,
                        filterSubject = subject,
                        filterDomain = classDomain,
                        filterRange = range
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
        
    }
}
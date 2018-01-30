using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using SnappetChallenge.Core.Interfaces;

namespace SnappetChallenge.Infrastructure
{
    public class Commands<T> : ICommands<T> where T : class
    {
        private readonly DbContext _context;
        public Commands(DbContext context)
        {
            _context = context;
        }

        public void BulkAdd(List<T> entitiesList)
        {
            _context.BulkInsert(entitiesList);
        }

       public void ExecuteSqlCommand(string command)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssessmentContext"].ToString());
            var cmd = new SqlCommand(command, con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           cmd.CommandTimeout = int.MaxValue;
            // execute the query and return number of rows affected, should be one
           cmd.ExecuteNonQuery();

            // close connection when done
            con.Close();
        }

    }
}

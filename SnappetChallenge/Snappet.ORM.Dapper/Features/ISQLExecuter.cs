using System.Collections.Generic;
using System.Data;

namespace Snappet.ORM.Dapper.Features
{
    /// <summary>
    /// This is an interface for implementing how connect and execute SQL queries.
    /// </summary>
    public interface ISQLExecuter
    {
        /// <summary>
        /// Execute SQL query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL query command</param>
        /// <param name="param">Parameters for sending to the dabase</param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        IEnumerable<T> Query<T>(string sql, object param = null, CommandType? commandType = null);
    }
}

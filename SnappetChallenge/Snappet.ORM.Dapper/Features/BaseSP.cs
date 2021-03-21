using Dapper;
using Snappet.Models.Database;
using System.Linq;

namespace Snappet.ORM.Dapper.Features
{
    public class BaseSP
    {
        /// <summary>
        /// The stored-Procedure name
        /// </summary>
        private readonly string _sp;

        /// <summary>
        /// SQL query executer
        /// </summary>
        private readonly ISQLExecuter _executer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp">The Stored-Procedure full name</param>
        /// <param name="executer"></param>
        public BaseSP(string sp, ISQLExecuter executer)
        {
            _sp = sp;
            _executer = executer;
        }

        /// <summary>
        /// Execute SQL queries that the result should be one record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public DBResult ExecuteSingleRecord<T>(DynamicParameters data)
        {
            var dbResult = _executer.Query<T>(_sp, data, System.Data.CommandType.StoredProcedure).FirstOrDefault();

            var rst = Common.GetResult(data, dbResult);

            return rst;
        }

        /// <summary>
        /// Execute SQL queries that the result should be a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public DBResult ExecuteQuery<T>(DynamicParameters data)
        {
            var dbResult = _executer.Query<T>(_sp, data, System.Data.CommandType.StoredProcedure);

            var rst = Common.GetResult(data, dbResult);

            return rst;
        }
    }
}

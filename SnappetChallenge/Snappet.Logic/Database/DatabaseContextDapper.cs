using Snappet.Models.Database;
using Snappet.Models.Database.StoredProcedures.dbo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Logic.Database
{
    public class DatabaseContextDapper : IDatabaseContext
    {
        private readonly ORM.Dapper.StoredProcedures.dbo.SP_Teacher_Login _sp_Teacher_Login;

        /// <summary>
        /// Initial and Create database objects
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sqlExecuter"></param>
        public DatabaseContextDapper(string connectionString, ORM.Dapper.Features.ISQLExecuter sqlExecuter = null)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString could not be empty.");

            if (sqlExecuter == null)
                sqlExecuter = new ORM.Dapper.Features.SQLExecuter(connectionString);

            _sp_Teacher_Login = new ORM.Dapper.StoredProcedures.dbo.SP_Teacher_Login(sqlExecuter);
        }

        /// <summary>
        /// Implement calling the SP_Teacher_Login by Dapper ORM
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public DBResult SP_Teacher_Login(SP_Teacher_Login.Inputs inputs)
        {
            var rst = _sp_Teacher_Login.Call(inputs);
            return rst;
        }
    }
}

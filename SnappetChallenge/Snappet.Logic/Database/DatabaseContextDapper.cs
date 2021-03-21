using Snappet.Models.Database;
using Snappet.Models.Database.StoredProcedures.dbo;
using Snappet.Models.Database.StoredProcedures.Rep;
using System;

namespace Snappet.Logic.Database
{
    public class DatabaseContextDapper : IDatabaseContext
    {
        private readonly ORM.Dapper.StoredProcedures.dbo.SP_Teacher_Login _sp_Teacher_Login;
        private readonly ORM.Dapper.StoredProcedures.Rep.SP_Class_Progress _sp_Class_Progress;


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
            _sp_Class_Progress = new ORM.Dapper.StoredProcedures.Rep.SP_Class_Progress(sqlExecuter);
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


        /// <summary>
        /// What has my class been working on today?
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public DBResult SP_Class_Progress(SP_Class_Progress.Inputs inputs)
        {
            var rst = _sp_Class_Progress.Call(inputs);
            return rst;
        }
    }
}

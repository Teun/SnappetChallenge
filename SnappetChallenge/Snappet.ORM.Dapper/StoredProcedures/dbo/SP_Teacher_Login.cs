using Snappet.Models.Database;
using Snappet.ORM.Dapper.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.ORM.Dapper.StoredProcedures.dbo
{
    public class SP_Teacher_Login : BaseSP
    {
        public SP_Teacher_Login(ISQLExecuter executer) : base("dbo.SP_Teacher_Login", executer)
        {
        }

        /// <summary>
        /// Call SP_Teacher_Login using Dapper
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DBResult Call(Models.Database.StoredProcedures.dbo.SP_Teacher_Login.Inputs data)
        {
            if (data == null)
                throw new ArgumentNullException("SP_Teacher_Login can not be call without passing username and password.");

            var p = Common.GetStatusCodeAndErrorMessageParams();
            p.Add("@Email", data.Email);
            p.Add("@Password", data.Password);

            return ExecuteSingleRecord<Models.Database.StoredProcedures.dbo.SP_Teacher_Login.Outputs>(p);
        }
    }
}

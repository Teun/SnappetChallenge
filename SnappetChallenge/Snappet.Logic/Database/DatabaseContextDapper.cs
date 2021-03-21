using Snappet.Models.Database;
using Snappet.Models.Database.StoredProcedures.dbo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Logic.Database
{
    public class DatabaseContextDapper : IDatabaseContext
    {
        public DBResult SP_Teacher_Login(SP_Teacher_Login.Inputs inputs)
        {
            var dp = new ORM.Dapper.StoredProcedures.dbo.SP_Teacher_Login();
            var rst = dp.Call(inputs);
            return rst;
        }
    }
}

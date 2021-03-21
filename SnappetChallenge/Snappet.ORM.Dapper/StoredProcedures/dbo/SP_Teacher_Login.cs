using Snappet.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.ORM.Dapper.StoredProcedures.dbo
{
    public class SP_Teacher_Login
    {
        /// <summary>
        /// Call SP_Teacher_Login using Dapper
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DBResult Call(Models.Database.StoredProcedures.dbo.SP_Teacher_Login.Inputs data)
        {
            var rst = new DBResult()
            {
                StatusCode = 200,
                ErrorMessage = "",
                Data = new Snappet.Models.Database.StoredProcedures.dbo.SP_Teacher_Login.Outputs()
                {
                    Email = "test",
                    Firstname = "fname",
                    Lastname = "lname",
                    TeacherId = 1
                }
            };

            return rst;
        }
    }
}

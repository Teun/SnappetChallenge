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
            var rst = new DBResult()
            {
                StatusCode = 200,
                ErrorMessage = "",
                Data = new SP_Teacher_Login.Outputs()
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

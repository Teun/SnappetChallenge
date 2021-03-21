using Snappet.Models.Database;
using Snappet.ORM.Dapper.Features;
using System;

namespace Snappet.ORM.Dapper.StoredProcedures.Rep
{
    /// <summary>
    /// Execute SP_Class_Progress at the database using Dapper.
    /// </summary>
    public class SP_Class_Progress : BaseSP
    {
        public SP_Class_Progress(ISQLExecuter executer)
            : base("Rep.SP_Class_Progress", executer)
        {
        }

        /// <summary>
        /// Call SP_SubmittedAnswers_CarelessStudents using Dapper
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DBResult Call(Models.Database.StoredProcedures.Rep.SP_Class_Progress.Inputs data)
        {
            if (data == null)
                throw new ArgumentNullException("SP_Class_Progress can not be call without passing username and password");

            var p = Common.GetStatusCodeAndErrorMessageParams();
            p.Add("@FromDate", data.FromDate);
            p.Add("@ToDate", data.ToDate);

            return ExecuteQuery<Models.Database.StoredProcedures.Rep.SP_Class_Progress.Outputs>(p);
        }
    }
}

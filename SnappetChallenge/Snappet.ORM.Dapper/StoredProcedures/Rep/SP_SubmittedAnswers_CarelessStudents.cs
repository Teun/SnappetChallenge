using Snappet.Models.Database;
using Snappet.ORM.Dapper.Features;
using System;


namespace Snappet.ORM.Dapper.StoredProcedures.Rep
{
    /// <summary>
    /// Implement SP_SubmittedAnswers_CarelessStudents
    /// </summary>
    public class SP_SubmittedAnswers_CarelessStudents : BaseSP
    {
        public SP_SubmittedAnswers_CarelessStudents(ISQLExecuter executer)
            : base("Rep.SP_SubmittedAnswers_CarelessStudents", executer)
        {
        }

        /// <summary>
        /// Call SP_SubmittedAnswers_CarelessStudents using Dapper
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DBResult Call(Models.Database.StoredProcedures.Rep.SP_SubmittedAnswers_CarelessStudents.Inputs data)
        {
            if (data == null)
                throw new ArgumentNullException("SP_SubmittedAnswers_CarelessStudents can not be call without passing username and password");

            var p = Common.GetStatusCodeAndErrorMessageParams();
            p.Add("@FromDate", data.FromDate);
            p.Add("@ToDate", data.ToDate);

            return ExecuteQuery<Models.Database.StoredProcedures.Rep.SP_SubmittedAnswers_CarelessStudents.Outputs>(p);
        }
    }
}

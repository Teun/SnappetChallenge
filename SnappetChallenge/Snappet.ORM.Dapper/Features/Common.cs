using Dapper;
using System;

namespace Snappet.ORM.Dapper.Features
{
    public class Common
    {
        public static DynamicParameters GetEmptyParams()
        {
            var p = new DynamicParameters();
            return p;
        }

        /// <summary>
        /// Get standard parameters contains StatusCode and ErrorMessage
        /// </summary>
        /// <returns></returns>
        public static DynamicParameters GetStatusCodeAndErrorMessageParams()
        {
            var p = GetEmptyParams();
            int statusCode = 0;
            string errorMessage = "";
            p.Add("@StatusCode", statusCode, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
            p.Add("@ErrorMessage", errorMessage, System.Data.DbType.String, System.Data.ParameterDirection.Output);

            return p;
        }

        /// <summary>
        /// Convert database query result to DBResult type
        /// </summary>
        /// <param name="outputParams"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Models.Database.DBResult GetResult(DynamicParameters outputParams, object data)
        {
            if (outputParams == null)
                throw new ArgumentNullException("Invalid outputParams");

            var rst = new Models.Database.DBResult()
            {
                StatusCode = outputParams.Get<int>("StatusCode"),
                ErrorMessage = outputParams.Get<string>("ErrorMessage"),

                Data = data
            };

            try
            {
                //if database query for searching, try to catch ActualSize output param for pagination
                rst.ActualSize = outputParams.Get<int>("ActualSize");
            }
            catch (Exception)
            {
                rst.ActualSize = 0;
            }

            return rst;
        }
    }
}

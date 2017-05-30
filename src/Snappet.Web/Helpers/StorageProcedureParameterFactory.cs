using System;
using System.Data;
using System.Data.SqlClient;

namespace Snappet.Web.Helpers
{
    public static class StorageProcedureParameterFactory
    {
        public static SqlParameter CreateSqlParameter(string type, string name, object value)
        {
            SqlParameter result = null;

            switch (type.ToLower())
            {
                case "string":
                    result = new SqlParameter(name,SqlDbType.NVarChar);
                    break;

                case "datetime":
                    result = new SqlParameter(name, SqlDbType.DateTime);
                    break;

                case "int":
                    result = new SqlParameter(name, SqlDbType.Int);
                    break;

                default:
                    throw new NotSupportedException();
            }

            result.Value = value;

            return result;
        }
    }
}
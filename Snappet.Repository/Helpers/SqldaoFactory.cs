using System.Data.SqlClient;

namespace Snappet.Repository.Helpers
{

    public class SqldaoFactory
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(Config.ConnectionString);
        }

    }
}

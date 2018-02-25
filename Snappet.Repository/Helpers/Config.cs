using System.Configuration;

namespace Snappet.Repository.Helpers
{

    public class Config
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

    }
}

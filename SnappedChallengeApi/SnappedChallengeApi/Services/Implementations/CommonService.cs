using SnappedChallengeApi.Services.Interfaces;

namespace SnappedChallengeApi.Services.Implementations
{
    /// <summary>
    /// Common simple service for code test purpose mostly bu tif common features need this controller can be used like versioning, critical real health check etc.
    /// </summary>
    public class CommonService : ICommonService
    {
        /// <summary>
        /// Health Check Ping Method
        /// </summary>
        /// <returns></returns>
        public bool Ping()
        {
            return true;
        }
    }
}

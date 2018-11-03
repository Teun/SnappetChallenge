using SnappedChallengeApi.Services.Interfaces;

namespace SnappedChallengeApi.Services.Implementations
{
    public class CommonService : ICommonService
    {
        public bool Ping()
        {
            return true;
        }
    }
}

using SnappetTest.Model.Abstract;

namespace SnappetTest.Service.Infrastructure.Abstract
{
   public interface IFetchProgressProvider
    {
        int FetchProgress(ITimeStamp timestamp);
    }

}

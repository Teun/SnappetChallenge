
using SnappetTest.Model.Abstract;

namespace SnappetTest.Service.Infrastructure.Abstract
{
    public interface IFetchAnswerCountProvider
    {
        int FetchAnswerCount(ITimeStamp timeStamp);
    }
}

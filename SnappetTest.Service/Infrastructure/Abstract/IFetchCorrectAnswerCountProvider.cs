using SnappetTest.Model.Abstract;
namespace SnappetTest.Service.Infrastructure.Abstract
{
    public interface IFetchCorrectAnswerCountProvider
    {
        int FetchCorrectAnswerCount(ITimeStamp timestamp);
    }
}

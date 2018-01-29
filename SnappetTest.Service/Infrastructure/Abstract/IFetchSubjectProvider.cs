using SnappetTest.Model.Abstract;


namespace SnappetTest.Service.Infrastructure.Abstract
{
    public interface IFetchSubjectProvider
    {
        string FetchSubject( ITimeStamp timestamp);
    }
}

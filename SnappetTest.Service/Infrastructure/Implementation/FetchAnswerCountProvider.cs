using System.Linq;
using SnappetTest.Service.Infrastructure.Abstract;
using SnappetTest.Model.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace SnappetTest.Service.Infrastructure.Implementation
{
    public class FetchAnswerCountProvider : IFetchAnswerCountProvider
    {
        private readonly GetResultOnTimeStamp _timeStampResult;

        public FetchAnswerCountProvider(GetResultOnTimeStamp timestampResult)
        {
            _timeStampResult = timestampResult;
        }
        public int FetchAnswerCount(ITimeStamp timestamp)
        {
            return _timeStampResult.GetResult(timestamp).Count();
        }
    }
}

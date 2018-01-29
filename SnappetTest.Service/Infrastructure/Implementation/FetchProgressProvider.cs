using SnappetTest.Model.Abstract;
using SnappetTest.Data.Abstract;
using Microsoft.Extensions.DependencyInjection;
using SnappetTest.Model.Entities;
using System.Linq;
using SnappetTest.Service.Infrastructure.Abstract;
namespace SnappetTest.Service.Infrastructure.Implementation
{
    public class FetchProgressProvider : IFetchProgressProvider
    {
        private readonly GetResultOnTimeStamp _timeStampResult;

        public FetchProgressProvider(GetResultOnTimeStamp timestampResult)
        {
            _timeStampResult = timestampResult;
        }
        public int FetchProgress(ITimeStamp timestamp)
        {

            return _timeStampResult.GetResult(timestamp).Sum(b => b.Progress);
        }
    }
}

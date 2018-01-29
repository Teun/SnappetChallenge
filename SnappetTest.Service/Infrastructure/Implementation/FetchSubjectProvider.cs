using System;
using SnappetTest.Data.Abstract;
using System.Linq;
using SnappetTest.Service.Infrastructure.Abstract;
using SnappetTest.Model.Abstract;

namespace SnappetTest.Service.Infrastructure.Implementation
{
    public class FetchSubjectProvider : IFetchSubjectProvider
    {
        private readonly GetResultOnTimeStamp _resultStamp;

        public FetchSubjectProvider(GetResultOnTimeStamp resultStamp)
        {
            _resultStamp = resultStamp;
        }
        public string FetchSubject(ITimeStamp timestamp)
        {
            return _resultStamp.GetResult(timestamp).FirstOrDefault().Subject;
        }
    }
}

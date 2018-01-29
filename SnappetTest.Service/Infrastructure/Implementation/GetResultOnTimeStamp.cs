using SnappetTest.Data.Abstract;
using SnappetTest.Model.Entities;
using System.Collections.Generic;
using SnappetTest.Model.Abstract;
using MongoDB.Bson;

namespace SnappetTest.Service.Infrastructure.Implementation
{
    public class GetResultOnTimeStamp
    {
        private readonly ISnappetTestRepository _repository;

        public GetResultOnTimeStamp(ISnappetTestRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ReceivedAnswers> GetResult(ITimeStamp timestamp)
        {
            var startTime = new BsonDateTime(timestamp.StartTime);
            var endTime = new BsonDateTime(timestamp.EndTime);
            return _repository.GetSingle(a => a.SubmitDateTime > startTime && a.SubmitDateTime < endTime);
        }
    }
}

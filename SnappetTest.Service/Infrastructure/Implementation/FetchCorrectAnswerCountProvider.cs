using SnappetTest.Service.Infrastructure.Abstract;
using SnappetTest.Model.Abstract;
using SnappetTest.Data.Abstract;
using MongoDB.Bson;
using System;
using System.Linq;

namespace SnappetTest.Service.Infrastructure.Implementation
{
    public class FetchCorrectAnswerCountProvider : IFetchCorrectAnswerCountProvider
    {
        private readonly ISnappetTestRepository _repository;

        public FetchCorrectAnswerCountProvider(ISnappetTestRepository repository)
        {
            _repository = repository;
        }
        public int FetchCorrectAnswerCount(ITimeStamp timestamp)
        {
            var startTime = new BsonDateTime(timestamp.StartTime);
            var endTime = new BsonDateTime(timestamp.EndTime);
            var correctAnswer = _repository.GetSingle(a => a.Correct == 1 && a.SubmitDateTime > startTime && a.SubmitDateTime < endTime);
            return correctAnswer.Count();
        }
    }
}

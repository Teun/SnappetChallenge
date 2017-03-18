using System.IO;
using System.Net;

namespace Snappet.Borisov.Test.Infrastructure
{
    public class SubmittedAnswerReader : IReadSubmittedAnswers
    {
        private readonly ISubmittedAnswerConfiguration _configuration;

        public SubmittedAnswerReader(ISubmittedAnswerConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Stream Read()
        {
            return WebRequest.Create(_configuration.Url).GetResponse().GetResponseStream();
        }
    }
}
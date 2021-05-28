using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Snappet.Common;
using Snappet.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Data
{
    public class AnswersDataProvider : IAnswersDataProvider
    {
        private readonly IConfiguration _configuration;

        public AnswersDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public  Task<IEnumerable<AnswerEntity>> GetSubmittedAnswers()
        {
            string filePath = _configuration["FilePath"];

            string answersJson = File.ReadAllText(filePath);
            var answers = JsonConvert.DeserializeObject<IEnumerable<AnswerEntity>>(answersJson);
          
            return Task.FromResult(answers);

        }
    }
}

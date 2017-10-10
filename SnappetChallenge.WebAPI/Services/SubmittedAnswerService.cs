using CsvHelper;
using SnappetChallenge.Data;
using SnappetChallenge.Data.IO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace SnappetChallenge.WebAPI.Services
{
    public class SubmittedAnswerService
    {
        private const string DataKey = "DataFile";

        public IEnumerable<SubmittedAnswer> GetSubmittedAnswers(DateTime from, DateTime to)
        {
            var file = ConfigurationManager.AppSettings[DataKey];
            var csv = new CsvReader(File.OpenText(file));
            csv.Configuration.RegisterClassMap(new SubmittedAnswerParser());
            csv.Configuration.IgnoreReadingExceptions = true;
            csv.Configuration.ReadingExceptionCallback = (exception, row) =>
            {
                // TODO Handle error lines here
                Console.WriteLine("Error parsing line " + row);
            };

            return csv.GetRecords<SubmittedAnswer>().Where(x => x.SubmittedDateTime >= from && x.SubmittedDateTime < to);
        }
    }
}
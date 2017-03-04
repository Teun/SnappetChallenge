using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Snappet.Reporting.Application.Json;
using System.Diagnostics;

namespace Snappet.Reporting.Storage.Sql
{
    /// <summary>
    /// Feeds answers in database with data from the FileImporter
    /// </summary>
    public static class DbInitializer
    {
        public static void Initialize(ReportingDbContext dbContext, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger(nameof(DbInitializer));
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var answers = FileImporter.GetAnswers(loggerFactory);
            var today = new DateTime(2015, 3, 24, 11, 30, 0, DateTimeKind.Utc);

            //only import until 'now', good idea?? This is only done once...
            dbContext.AddRange(answers.Where(x => x.SubmitDateTime <= today));
            var imported = dbContext.SaveChanges();

            stopwatch.Stop();
            logger.LogInformation($"Imported {imported} answers, took {stopwatch.ElapsedMilliseconds} milliseconds.");
        }
    }
}

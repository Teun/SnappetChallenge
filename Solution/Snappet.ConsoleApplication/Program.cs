using System;
using System.Collections.Generic;
using System.Linq;
using Snappet.Data.DataObjects;
using Snappet.Data.DataServices;
using Snappet.Data.Mappers;
using Snappet.Data.QueryRepositories;

namespace Snappet.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.SetWindowSize(Math.Min(150, Console.LargestWindowWidth),
                Math.Min(60, Console.LargestWindowHeight));

                RunApplication();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured running the application.");
                Console.WriteLine(e);
            }


            // Leave console open:
            Console.ReadLine();
        }

        private static void RunApplication()
        {
            var dataService = CreateDataService();

            // Simulate current datetime.
            DateTime now = new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);

            var resultToday = dataService.GetClassResult(now);
            var resultLastWeek = dataService.GetClassResult(now.AddDays(-14));

            Console.WriteLine("resultaten van vandaag");
            Console.WriteLine(PrintToStringTable(resultToday));

            Console.WriteLine("resultaten van vorige week");
            Console.WriteLine(PrintToStringTable(resultLastWeek));
        }

        private static string PrintToStringTable(IEnumerable<ClassResultRow> data)
        {
            return data
                .OrderBy(_ => _.Subject)
                .ThenByDescending(_ => _.Count)
                .ToStringTable(
                    new[] {"Onderwerp", "Leerdoel", "Aantal opgaves", "Goed", "Fout", "%Goed"},
                    _ => _.Subject,
                    _ => _.LearningObjective,
                    _ => _.Count,
                    _ => _.Correct,
                    _ => _.Incorrect,
                    _ => _.PercentCorrect);
        }

        private static IClassResultDataService CreateDataService()
        {
            return null;
            //IQueryRepository dataRepo = new FilterQueryRepository(new JsonDataRepository());
            //return new ClassResultDataService(dataRepo, new ReportRowMapper());
        }
    }
}

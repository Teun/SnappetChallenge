using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RReporter.Application.ReportWorkSummary;
using RReporter.Application.ReportWorkSummary.Dto;
using RReporter.Application.StoreWorkEvent;
using RReporter.Framework;

namespace RReporter.Run.Console
{
    class Program
    {
        static void Main (string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync() 
        {
            // storage (in memory for now)
            var pupilsStorage = new MemoryPupilsStorage ();
            var workEventStorage = new MemoryWorkEventStorage ();

            // application components
            var workEventHandler = new WorkEventHandler (workEventStorage);
            var workSummaryQueries = new WorkSummaryQueries (workEventStorage, pupilsStorage);

            // time provider with a time offset
            var timeProvider = new OffsetTimeProvider();
            

            // create event emitter
            var workEventEmitter = new WorkEventEmitter (workEventHandler);

            // emit events until a certain time
            var now = timeProvider.CurrentUtcTime;
            await workEventEmitter.EmitEventsUntilAsync (now);

            WorkSummaryDto[] workSummaries = await Task.WhenAll (
                workSummaryQueries.GetDaySummaryAtTimeAsync (1, now),
                workSummaryQueries.GetDaySummaryAtTimeAsync (2, now)
            );

            var workSummaryReports = workSummaries.Select(FormatWorkSummaryReport).ToArray();
            
            System.Console.WriteLine("Klas 1:");
            System.Console.WriteLine(workSummaryReports[0]);
            System.Console.WriteLine();

            System.Console.WriteLine(new string('=', 101));
            System.Console.WriteLine("Klas 2:");
            System.Console.WriteLine(workSummaryReports[1]);
            System.Console.WriteLine();

        }

        static string FormatWorkSummaryReport(WorkSummaryDto workSummary) 
        {
            var pupilSummaryReports = workSummary.PupilSummaries.Select(FormatPupilSummaryReport);
            return $"Werk vandaag tot {workSummary.Timestamp}:\n\n{string.Join("\n\n", pupilSummaryReports)}";
        }

        static string FormatPupilSummaryReport(PupilSummaryDto pupilSummary) 
        {
            var losummaryHeader = FormatLearningObjectiveSummaryHeader() ;
            var losummaryRuler = new string('-', 101);
            var loSummaryReports = pupilSummary.LearningObjectiveSummaries.Select(FormatLearningObjectiveSummaryReport);
            return $"Leerling: {pupilSummary.UserId}\n{losummaryRuler}\n{losummaryHeader}\n{losummaryRuler}\n{string.Join("\n", loSummaryReports)}\n{losummaryRuler}";
        }
 
        static string FormatLearningObjectiveSummaryReport(LearningObjectiveSummaryDto loSummary) 
        {
            return $"{loSummary.Subject + "; " + loSummary.LearningObjective,-64} {loSummary.NumberOfAnswers,12} {loSummary.CorrectPercentage,12:P0} {loSummary.TotalProgress,10}";
        }

        static string FormatLearningObjectiveSummaryHeader() 
        {
            return $"{"Leerdoel",-64} {"Antwoorden",12} {"Correct %",12} {"Voortgang",10}";
        }
    }
}
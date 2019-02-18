using System;
using System.Diagnostics;
using System.IO;
using Dashboard.CsvImport;
using Dashboard.Dashboard;

namespace Dashboard
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Supply input file, datetime, and output file");
                Environment.Exit(1);
                return;
            }

            string inputFileName = args[0];
            string inputDate = args[1];
            string outputFileName = args[2];

            var csvImporter = new AnswersCsvImporter();
            var dashboardBuilder = new DashboardBuilder();
            var dashboardExcelExporter = new DashboardExcelExporter();

            var answers = csvImporter.Import(inputFileName);

            DateTimeOffset end = DateTimeOffset.Parse(inputDate);
            DateTimeOffset start = new DateTimeOffset(end.Date, TimeSpan.Zero);

            var dashboard = dashboardBuilder.Build(answers, start, end);

            using (var excelPackage = dashboardExcelExporter.Export(dashboard))
            {
                excelPackage.SaveAs(new FileInfo(outputFileName));
            }

            var excel = new Process();
            excel.StartInfo = new ProcessStartInfo(outputFileName)
            {
                UseShellExecute = true
            };
            excel.Start();
        }
    }
}

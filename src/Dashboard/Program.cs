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

            Console.WriteLine($"Starting CSV import from {inputFileName}...");
            var answers = csvImporter.Import(inputFileName);

            DateTimeOffset end = DateTimeOffset.Parse(inputDate);
            DateTimeOffset start = new DateTimeOffset(end.Date, TimeSpan.Zero);

            Console.WriteLine("Building dashboard...");
            var dashboard = dashboardBuilder.Build(answers, start, end);

            Console.WriteLine("Building Excel file...");
            using (var excelPackage = dashboardExcelExporter.Export(dashboard))
            {
                Console.WriteLine($"Saving Excel file to {outputFileName}...");
                excelPackage.SaveAs(new FileInfo(outputFileName));
            }

            Console.WriteLine("Opening Excel file...");
            var excel = new Process();
            excel.StartInfo = new ProcessStartInfo(outputFileName)
            {
                UseShellExecute = true
            };
            excel.Start();

            Console.WriteLine("Done!");
        }
    }
}

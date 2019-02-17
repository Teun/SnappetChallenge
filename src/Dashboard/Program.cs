using System;
using Dashboard.CsvImport;
using Dashboard.Dashboard;

namespace Dashboard
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Supply file and datetime");
                Environment.Exit(1);
                return;
            }

            var csvImporter = new AnswersCsvImporter();
            var dashboardBuilder = new DashboardBuilder();
            var dashboardPresenter = new DashboardPresenter();

            var answers = csvImporter.Import(args[0]);

            DateTimeOffset end = DateTimeOffset.Parse(args[1]);
            DateTimeOffset start = new DateTimeOffset(end.Date, TimeSpan.Zero);

            var dashboard = dashboardBuilder.Build(answers, start, end);

            dashboardPresenter.Present(dashboard);

#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}

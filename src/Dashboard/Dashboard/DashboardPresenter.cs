using System;
using Dashboard.Dashboard.Models;

namespace Dashboard.Dashboard
{
    public class DashboardPresenter
    {
        public void Present(Models.Dashboard dashboard)
        {
            if (dashboard == null)
            {
                throw new ArgumentNullException(nameof(dashboard));
            }

            AddHeader("Class activity report");
            AddNewLine();

            OutputField("Start date", dashboard.Start);
            AddNewLine();
            OutputField("End date", dashboard.End);
            AddNewLine();
            AddNewLine();

            OutputField("Students present", dashboard.StudentsPresent);
            AddNewLine();

            Console.WriteLine("Subject Exercises Correct answers, %");
            AddNewLine();

            ShowSliceStatisticsRecursive(dashboard.SlicedStatistics);
        }

        private void ShowSliceStatisticsRecursive(AnswersSlice slice)
        {
            var stats = slice.GetStatistics();

            Console.WriteLine($"{slice.Name, -50} {stats.ExerciseCount, 10} {stats.CorrectPercentage,10:N0}");
            AddNewLine();

            foreach (AnswersSlice subslice in slice.Subslices)
            {
                ShowSliceStatisticsRecursive(subslice);
            }
        }

        private void OutputField(string label, object value, int padding = 3)
        {
            string paddingString = new string('\t', padding);
            Console.Write($"{label}:{paddingString}{value}");
        }

        private void AddHeader(string label)
        {
            Console.WriteLine(label);
        }

        private void AddNewLine()
        {
            Console.WriteLine();
        }
    }
}

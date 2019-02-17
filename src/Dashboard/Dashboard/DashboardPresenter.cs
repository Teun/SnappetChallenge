using System;
using System.Collections.Generic;
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
            AddSpacing();

            OutputField("Start date", dashboard.Start);
            OutputField("End date", dashboard.End);
            AddSpacing();

            OutputField("Students present", dashboard.StudentsPresent);
            AddSpacing();

            PresentLearningResults(dashboard.OverallLearningResults);
        }

        private void PresentLearningResults(LearningResults results)
        {
            OutputField("Exercises", results.ExerciseCount);
            OutputField("Correct percentage", results.CorrectPercentage.ToString("N0"), 2);
            AddSpacing();

            if (results.Detalization != null)
            {
                foreach (KeyValuePair<string, LearningResults> details in results.Detalization)
                {
                    Console.WriteLine(details.Key);
                    PresentLearningResults(details.Value);
                }
            }
        }

        private void OutputField(string label, object value, int padding = 3)
        {
            string paddingString = new string('\t', padding);
            Console.WriteLine($"{label}:{paddingString}{value}");
        }

        private void AddHeader(string label)
        {
            Console.WriteLine(label);
        }

        private void AddSpacing()
        {
            Console.WriteLine();
        }
    }
}

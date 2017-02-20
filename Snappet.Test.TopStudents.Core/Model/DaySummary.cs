using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Snappet.Test.Kernel;

namespace Snappet.Test.TopStudents.Core.Model
{
    public class DaySummary : Entity
    {
        public static DaySummary Create(string subject, DateTime date)
        {
            return new DaySummary
            {
                Subject = subject,
                RecordDate = date.Date
            };
        }

        public bool UpdateSummary(int studentId, decimal difficulty, int progress)
        {
            if (progress == 0)
                return false;
            
            if (!StudentIdsStore.Contains(studentId))
            {
                NumberOfStudents++;
                StudentIdsStore.Add(studentId);
            }

            AverageProgress = (AverageProgress + NumberOfAnswers + progress) / (NumberOfAnswers + 1);
            NumberOfAnswers++;

            if (progress > MaxProgress)
            {
                MaxProgress = progress;
            }
            if (progress < MinProgress)
            {
                MinProgress = progress;
            }

            return true;
        }

        public string StudentIdsCsv
        {
            get { return string.Join(";", StudentIdsStore); }
            private set { StudentIdsStore = value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
            }
        }

        protected List<int> StudentIdsStore { get; set; } = new List<int>();

        public byte[] RowVersion { get; set; }
        public DateTime RecordDate { get; private set; }
        public string Subject { get; private set; }

        public int NumberOfStudents { get; private set; }
        public int NumberOfAnswers { get; private set; }
        public decimal MaxProgress { get; private set; }
        public decimal MinProgress { get; private set; }
        public decimal AverageProgress { get; private set; }
    }
}
namespace Snappet.Borisov.Test.Domain.Reporting
{
    public class OverviewReport
    {
        public StudentModel[] Students { get; set; }

        public class StudentModel
        {
            public string Name { get; set; }
            public TodayModel Today { get; set; }
            public HistoryModel History { get; set; }

            public class TodayModel
            {
                public int NumberOfObjectives { get; set; }
                public int NumberOfAnswers { get; set; }
                public int NumberOfCorrectAnswers { get; set; }
                public ObjectiveProgressModel ObjectiveWithMaxProgress { get; set; }
                public ObjectiveProgressModel ObjectiveWithMinProgress { get; set; }
            }

            public class HistoryModel
            {
            }

            public class ObjectiveProgressModel
            {
                public string LearningObjective { get; set; }
                public int Progress { get; set; }
            }
        }
    }
}
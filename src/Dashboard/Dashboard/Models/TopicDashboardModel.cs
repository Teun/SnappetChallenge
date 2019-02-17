namespace Dashboard.Dashboard.Models
{
    public class TopicDashboardModel
    {
        public string TopicName { get; }

        public int Level { get; }

        public int ExerciseCount { get; }

        public float CorrectAnswersRate { get; }

        public float StudentsShare { get; }

        public TopicDashboardModel(string topicName, int level, int exerciseCount, float correctAnswersRate, float studentsShare)
        {
            TopicName = topicName;
            Level = level;
            ExerciseCount = exerciseCount;
            CorrectAnswersRate = correctAnswersRate;
            StudentsShare = studentsShare;
        }
    }
}

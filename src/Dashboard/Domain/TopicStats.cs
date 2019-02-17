namespace Dashboard.Domain
{
    public class TopicStats
    {
        private readonly int _answersCount;

        private readonly int _correctAnswersCount;

        public int ExerciseCount { get; }

        public int StudentsCount { get; }

        public float CorrectAnswersRate => (float)_correctAnswersCount / _answersCount;

        public TopicStats(int exerciseCount, int answersCount, int correctAnswersCount, int studentsCount)
        {
            _answersCount = answersCount;
            _correctAnswersCount = correctAnswersCount;
            ExerciseCount = exerciseCount;
            StudentsCount = studentsCount;
        }
    }
}

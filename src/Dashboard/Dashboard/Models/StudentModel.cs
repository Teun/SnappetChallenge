namespace Dashboard.Dashboard.Models
{
    public class StudentModel
    {
        public string Name { get; }

        public int ExerciseCount { get; }

        public float CorrectAnswersRatio { get; }

        public float FinishedExerciseShare { get; }

        public StudentModel(string name, int exerciseCount, float correctAnswersRatio)
        {
            Name = name;
            ExerciseCount = exerciseCount;
            CorrectAnswersRatio = correctAnswersRatio;
        }
    }
}

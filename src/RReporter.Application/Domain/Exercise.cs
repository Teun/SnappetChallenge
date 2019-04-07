namespace RReporter.Application.Domain
{
    public class Exercise
    {
        public Exercise (int id, ExerciseClassification classification, double? difficulty)
        {
            Id = id;
            Classification = classification;
            Difficulty = difficulty;
        }

        public int Id { get; private set; }

        public ExerciseClassification Classification { get; private set; }

        public double? Difficulty { get; private set; }
    }
}
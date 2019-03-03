namespace SnappetTrueskill.Domain
{
    public class TrueskillEvent
    {
        public ExerciseInteraction ExerciseInteraction { get; set; }
        public double MeanDelta { get; set; }
        public double StdDelta { get; set; }
        public double Quality { get; set; }
        public double CorrectProbability { get; set; }
        public double ExerciseRating { get; set; }
    }
}

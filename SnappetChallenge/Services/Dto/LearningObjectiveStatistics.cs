namespace Services.Dto
{
    public class LearningObjectiveStatistics
    {
        public string Name { get; set; }

        public int TotalCount { get; set; }
        public int CorrectCount { get; set; }
        public int IncorrectCount { get; set; }

        public int AverageProgress { get; set; }
        public decimal AverageDifficulty { get; set; }
    }
}
namespace SnappetChallenge.Models
{
    public record SubjectOverviewDto
    {
        public string Subject { get; init; }
        public int UniqueExercises { get; init; }
        public int TotalAnswers { get; init; }
        public decimal AssessedSkillLevelChange { get; init; }
        public int TotalReanswered { get; init; }
        public decimal? TotalReansweredPercentage { get; init; }
    }
}

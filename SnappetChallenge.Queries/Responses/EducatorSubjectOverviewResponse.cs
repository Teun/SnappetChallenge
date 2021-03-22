namespace SnappetChallenge.Queries.Responses
{
    public record EducatorSubjectOverviewResponse
    {
        public string Domain { get; init; }
        public string LearningObjective { get; init; }
        public long UserId { get; init; }
        public decimal AssessedSkillLevelChange { get; init; }
    }
}

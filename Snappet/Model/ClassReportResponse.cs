namespace Snappet.Model
{
    public class ClassReportResponse
    {
        public NamedBinaryReport[] SubjectReport { get; set; }
        public NamedBinaryReport[] DomainReport { get; set; }
        public NamedBinaryReport[] LearningObjectiveReport { get; set; }
        public NamedBinaryReport[] DifficultyRangeReport { get; set; }
    }
}
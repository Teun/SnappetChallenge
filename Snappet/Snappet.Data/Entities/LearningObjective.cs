namespace Snappet.Data.Entities
{
    public class LearningObjective : NamedIdentifyable<int>
    {
        public LearningSubject LearningSubject { get; set; }
    }
}

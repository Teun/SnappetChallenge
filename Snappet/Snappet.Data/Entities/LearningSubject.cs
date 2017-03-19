namespace Snappet.Data.Entities
{
    public class LearningSubject : NamedIdentifyable<int>
    {
        public LearningDomain LearningDomain { get; set; }
    }
}

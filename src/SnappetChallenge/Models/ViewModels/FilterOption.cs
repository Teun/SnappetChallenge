using System.Collections.Generic;

namespace SnappetChallenge.Models.ViewModels
{
    public class FilterOption
    {
        public IEnumerable<SubjectFilter> Subjects { get; set; }
    }

    public class SubjectFilter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DomainFilter> Domains { get; set; } 
    }

    public class DomainFilter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<LearningObjectiveFilter> LearningObjectives { get; set; }
    }

    public class LearningObjectiveFilter
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

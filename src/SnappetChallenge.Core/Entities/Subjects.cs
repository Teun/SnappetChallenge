using System.Collections.Generic;

namespace SnappetChallenge.Core.Entities
{
    public class Subjects
    {
        private readonly IEnumerable<Exercise> _exercises;
        public Subjects(IEnumerable<Exercise> exercises)
        {
            All = new List<Subject>();
            _exercises = exercises;

            var subjectGrouped = _exercises.GroupByMany(x => x.Subject, x => x.Domain, x => x.LearningObjective);
            foreach (var subjectKey in subjectGrouped)
            {
                var subject = new Subject(subjectKey.Key.ToString());

                foreach (var domainKey in subjectKey.SubGroups)
                {
                    var domain = new Domain(domainKey.Key.ToString());
                    subject.AddDomain(domain);

                    foreach (var learningObjectiveKey in domainKey.SubGroups)
                    {
                        var learningObjective = new LearningObjective(learningObjectiveKey.Key.ToString());
                        domain.AddLearningObjective(learningObjective);
                    }
                }

                All.Add(subject);
            }
        }

        public IList<Subject> All { get; private set; }
    }

    public class Subject
    {
        public Subject(string name)
        {
            Name = name;
            Domains = new List<Domain>();
        }

        public string Name { get; private set; }
        public IList<Domain> Domains { get; private set; }

        public void AddDomain(Domain domain) => Domains.Add(domain);
    }
}

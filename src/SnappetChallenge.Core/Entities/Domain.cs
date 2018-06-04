using System.Collections.Generic;

namespace SnappetChallenge.Core.Entities
{
    public class Domain
    {
        public Domain(string name)
        {
            Name = name;
            LearningObjectives = new List<LearningObjective>();
        }

        public string Name { get; private set; }
        public IList<LearningObjective> LearningObjectives { get; private set; }

        public void AddLearningObjective(LearningObjective learningObjective) => LearningObjectives.Add(learningObjective);
    }
}

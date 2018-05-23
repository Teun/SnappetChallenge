namespace SnappetChallenge.Core.Entities
{
    public class LearningObjective
    {
        public LearningObjective(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}

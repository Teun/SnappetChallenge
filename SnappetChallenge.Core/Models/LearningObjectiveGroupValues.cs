namespace SnappetChallenge.Core.Models
{
    public class LearningObjectiveGroupValues
    {
        public LearningObjectiveGroupValues(string name, string domain, string subject)
        {
            Name = name;
            Domain = domain;
            Subject = subject;
        }

        public string Name { get; }
        public string Domain { get; }
        public string Subject { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is LearningObjectiveGroupValues other))
                return false;
            return Equals(other);
        }

        protected bool Equals(LearningObjectiveGroupValues other)
        {
            return string.Equals((string) Name, (string) other.Name) && string.Equals((string) Domain, (string) other.Domain) && string.Equals((string) Subject, (string) other.Subject);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Domain != null ? Domain.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Subject != null ? Subject.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
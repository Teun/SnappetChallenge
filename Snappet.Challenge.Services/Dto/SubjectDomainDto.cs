namespace Snappet.Challenge.Services.Dto
{
    public class SubjectDomainDto
    {
        public string Subject { get; set; }
        public string Domain { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SubjectDomainDto);
        }

        public bool Equals(SubjectDomainDto obj)
        {
            return Subject.Equals(obj.Subject) 
                && Domain.Equals(obj.Domain);
        }

        public override int GetHashCode()
        {
            return (string.IsNullOrEmpty(Subject) ? 0 : Subject.GetHashCode())
                ^ (string.IsNullOrEmpty(Domain)? 0 : Domain.GetHashCode());
        }
    }
}

namespace SnappetChallenge.Domain.Entities
{
    public class User : IEntity
    {
        public long Id { get; set; }
        public long ExternalId { get; set; }
        public string Name { get; set; }
    }
}

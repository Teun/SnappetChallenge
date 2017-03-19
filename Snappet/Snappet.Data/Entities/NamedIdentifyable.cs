namespace Snappet.Data.Entities
{
    public abstract class NamedIdentifyable<TIdentityType> : Identifyable<TIdentityType>
    {
        public virtual string Name { get; set; }
    }
}

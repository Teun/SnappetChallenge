namespace SnappetChallenge.DAL.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    
    internal sealed class ObjectiveConfiguration : EntityTypeConfiguration<Objective>
    {
        public ObjectiveConfiguration()
        {
            ToTable("Objective");
            HasKey<long>(s => s.Id);
        }
    }
}

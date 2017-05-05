namespace SnappetChallenge.DAL.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    
    internal sealed class DomainConfiguration : EntityTypeConfiguration<Domain>
    {
        public DomainConfiguration()
        {
            ToTable("Domain");
            HasKey<long>(s => s.Id);
            //HasMany(d => d.Exercises).WithRequired(e => e.Domain).HasForeignKey(e => e.DomainId);
        }
    }
}

using System;

namespace SnappetChallenge.DAL.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    
    internal sealed class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration()
        {
            this.ToTable("Subject");
            this.HasKey<Guid>(s => s.Id);
            //this.HasRequired(s => s.Exercise);
        }
    }
}

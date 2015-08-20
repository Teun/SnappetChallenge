using System;

namespace SnappetChallenge.DAL.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;
    
    internal sealed class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            this.ToTable("Student");
            this.HasKey<Guid>(s => s.Id);
        }
    }
}

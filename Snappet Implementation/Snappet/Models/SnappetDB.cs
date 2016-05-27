using System.Data.Entity;

namespace Snappet.Models
{
    public partial class SnappetDB : DbContext
    {
        public SnappetDB()
            : base("name=SnappetDB")
        {
        }

        public virtual DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.SubmittedAnswers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}

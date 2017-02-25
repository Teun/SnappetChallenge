namespace Persistence
{
	using Domain;
	using Microsoft.EntityFrameworkCore;
	using Persistence.Users;

	public class SchoolContext : DbContext, IUnitOfWork
	{
		public SchoolContext(DbContextOptions<SchoolContext> options)
			: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<LearningObjective>().HasIndex(x => x.Name);
			modelBuilder.Entity<Subject>().HasIndex(x => x.Name);
			modelBuilder.Entity<KnowledgeDomain>().HasIndex(x => x.Name);
			modelBuilder.Entity<User>().HasIndex(x => x.Name);

			modelBuilder.Entity<SubmittedAnswer>()
				.HasOne(x => x.User).WithMany().IsRequired();
			modelBuilder.Entity<SubmittedAnswer>()
				.HasOne(x => x.Exercise).WithMany().IsRequired();
			modelBuilder.Entity<Exercise>()
				.HasOne(x => x.LearningObjective).WithMany().IsRequired();
			modelBuilder.Entity<LearningObjective>()
				.HasOne(x => x.Domain).WithMany().IsRequired();
			modelBuilder.Entity<LearningObjective>()
				.HasOne(x => x.Subject).WithMany().IsRequired();

			modelBuilder.Entity<UserStats>()
				.Ignore(x => x.LatestProgress);
		}

		public DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<LearningObjective> LearningObjectives { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<KnowledgeDomain> KnowledgeDomains { get; set; }

		// The following mapping is not needed.
		// This is a workaround for EF Core lacking possibility to
		// execute raw SQL queries for non-mapped types.
		// See https://github.com/aspnet/EntityFramework/issues/1862
		public DbSet<UserStats> UserStats { get; set; }

		public IUserStatsRepository UserStatsRepository =>
			new UserStatsRepository(this);
	}
}

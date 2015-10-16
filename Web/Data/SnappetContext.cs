using System.Data.Entity;
using Web.Models;

namespace Web.Data
{
	public class SnappetContext : DbContext
	{

		public DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }

	}
}
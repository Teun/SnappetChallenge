using Microsoft.EntityFrameworkCore;
using Snappet.ClassInsights.Model.Domain;

namespace Snappet.ClassInsights.Orm
{
    public class InsightsContext : DbContext
    {
        public DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }
        public InsightsContext(DbContextOptions<InsightsContext> options) : base(options)
        {
        }
    }
}


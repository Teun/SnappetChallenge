using System.Threading.Tasks;

namespace Snappet.ClassInsights.Orm
{
    public interface IDataSeeder
    {
        Task SeedSubmittedAnswersAsync(string connectionString);
    }
}
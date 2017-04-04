using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.SnappetChallenge.Data.Repositories
{
    public interface IDashboardRepository
    {
        List<AggregatedProgressData> GetSubjectData(string subject, DateTime dateFilter);
        List<AggregatedProgressData> GetUserData(int userId, string subject, DateTime dateFilter);
        List<string> GetSubjects(DateTime dateFilter);
    }
}

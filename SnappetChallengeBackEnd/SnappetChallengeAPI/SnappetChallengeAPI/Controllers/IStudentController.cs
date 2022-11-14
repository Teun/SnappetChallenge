using SnappetChallengAPI.Helper;
using SnappetChallengAPI.Model;

namespace SnappetChallengAPI.Controllers
{
    public interface IStudentController
    {
        JsonWrapper GetTodayStatisticalReport();
        JsonWrapper GetFilteredStudents(FilterReport filter);
        JsonWrapper GetSubjects();
        JsonWrapper GetDomains();
    }
}
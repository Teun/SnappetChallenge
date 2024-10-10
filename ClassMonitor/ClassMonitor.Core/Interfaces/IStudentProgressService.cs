using ClassMonitor.Core.Models;

namespace ClassMonitor.Core.Interfaces
{
    public interface IStudentProgressService
    {
        Task<ProgressByStudent[]> GetDailyProgressByStudent(int year, int month, int day);

        Task<ProgressByStudent[]> GetMonthlyProgressByStudent(int year, int month);
    }
}

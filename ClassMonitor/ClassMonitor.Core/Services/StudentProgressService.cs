using ClassMonitor.Core.Interfaces;
using ClassMonitor.Core.Models;
using ClassMonitor.Core.WorkAggregate;
using Microsoft.EntityFrameworkCore;

namespace ClassMonitor.Core.Services
{
    public class StudentProgressService(DbContext context) : IStudentProgressService
    {
        public async Task<ProgressByStudent[]> GetDailyProgressByStudent(int year, int month, int day)
        {
            return await context.Set<Work>()
                .Where(x => x.SubmitDateTime.Day == day && x.SubmitDateTime.Month == month && x.SubmitDateTime.Year == year)
                .OrderBy(x => x.UserId)
                .ThenBy(x => x.SubmitDateTime)
                .Select(x => new ProgressByStudent
                {
                    DateTime = x.SubmitDateTime,
                    Progress = x.Progress,
                    StudentName = "Student " + x.UserId
                })
                .ToArrayAsync();
        }

        public async Task<ProgressByStudent[]> GetMonthlyProgressByStudent(int year, int month)
        {
            return await context.Set<Work>()
                .Where(x => x.SubmitDateTime.Month == month && x.SubmitDateTime.Year == year)
                .OrderBy(x => x.UserId)
                .ThenBy(x => x.SubmitDateTime)
                .Select(x => new ProgressByStudent
                {
                    DateTime = x.SubmitDateTime,
                    Progress = x.Progress,
                    StudentName = "Student " + x.UserId
                })
                .ToArrayAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorBoard.Dal.Repositories;
using TutorBoard.Report.Dtos;

namespace TutorBoard.Report.Services
{
    public class DailyReportService : IDailyReportService
    {
        private readonly IWorkResultRepository _workResultRepo;
        private readonly ISubjectRepository _subjectRepo;
        private readonly IUserRepository _userRepo;

        public DailyReportService(IWorkResultRepository workResultRepo, ISubjectRepository subjectRepo, IUserRepository userRepo)
        {
            _workResultRepo = workResultRepo;
            _subjectRepo = subjectRepo;
            _userRepo = userRepo;
        }

        /// <inheritdoc />
        public async Task<DailyReportDto> CreateDailyReportAsync(DateTime date)
        {
            return new DailyReportDto
            {
                EditedTasks = await CreateEditedTasksReportAsync(date),
                UserProgress = await CreateUserProgressReportsAsync(date)
            };
        }

        /// <inheritdoc />
        public async Task<EditedTasksReportDto> CreateEditedTasksReportAsync(DateTime date)
        {
            var subjectCounts = new List<SubjectEditedTasksCountDto>();

            foreach (var subject in await _subjectRepo.GetAsync())
            {
                subjectCounts.Add(new SubjectEditedTasksCountDto
                {
                    Subject = subject.Label,
                    Count = await _workResultRepo.CountExercisesForSubjectAsync(date, subject.Label)
                });
            }

            return new EditedTasksReportDto {
                Summary = await _workResultRepo.CountExercisesAsync(date),
                SubjectCounts = subjectCounts
            };
        }

        /// <inheritdoc />
        public async Task<IEnumerable<UserProgressReportDto>> CreateUserProgressReportsAsync(DateTime date)
        {
            var users = await _userRepo.GetAsync();
            var userProgresses = await _workResultRepo.GetUserProgressAsync(date);

            return users.AsParallel().Select(u => new UserProgressReportDto
            {
                UserId = u.UserId,
                UserName = u.Name,
                Progress = userProgresses.SingleOrDefault(up => up.UserId == u.UserId)?.Progress ?? 0
            });
        }
    }
}

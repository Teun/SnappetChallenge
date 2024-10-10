using ClassMonitor.Core.DomainAggregate;
using ClassMonitor.Core.WorkAggregate;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassMonitor.Infrastructure.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(AppDbContext dbContext)
        {
            if (await dbContext.Work.AnyAsync())
            {
                return;
            }

            await PopulateTestDataAsync(dbContext);
        }

        private static readonly JsonSerializerOptions jsonSerializerOptions = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

        public static async Task PopulateTestDataAsync(AppDbContext dbContext)
        {
            var domainNames = dbContext.Domains.ToDictionary(x => x.Name, x => x.Id);
            var learningObjectives = dbContext.LearningObjectives.ToDictionary(x => x.Name, x => x.Id);
            var subjects = dbContext.Subjects.ToDictionary(x => x.Name, x => x.Id);
            var userIds = dbContext.Users.Select(x => x.Id).ToHashSet();

            using var fileStream = File.OpenRead("../../Data/work.json");
            var workModels = JsonSerializer.Deserialize<WorkModel[]>(fileStream, jsonSerializerOptions) ?? Enumerable.Empty<WorkModel>();
            foreach (var workModel in workModels)
            {
                if (workModel.SubmitDateTime > new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc))
                {
                    continue;
                }

                var work = new Work
                {
                    Correct = workModel.Correct,
                    Difficulty = double.TryParse(workModel.Difficulty, out var difficulty) ? difficulty : null,
                    DomainId = domainNames.TryGetValue(workModel.Domain, out var domainId) ? domainId : 0,
                    Domain = domainId != 0 ? null : new Domain { Id = 0, Name = workModel.Domain },
                    ExerciseId = workModel.ExerciseId,
                    LearningObjectiveId = learningObjectives.TryGetValue(workModel.LearningObjective, out var learningObjectiveId) ? learningObjectiveId : 0,
                    LearningObjective = learningObjectiveId != 0 ? null : new Core.LearningObjectiveAggregate.LearningObjective { Id = 0, Name = workModel.LearningObjective },
                    Progress = workModel.Progress,
                    SubjectId = subjects.TryGetValue(workModel.Subject, out var subjectId) ? subjectId : 0,
                    Subject = subjectId != 0 ? null : new Core.SubjectAggregate.Subject { Id = 0, Name = workModel.Subject },
                    SubmitDateTime = workModel.SubmitDateTime,
                    SubmittedAnswerId = workModel.SubmittedAnswerId,
                    UserId = userIds.TryGetValue(workModel.UserId, out var userId) ? userId : 0,
                    User = userId != 0 ? null : new Core.UserAggregate.User { Id = workModel.UserId }
                };
                dbContext.Work.Add(work);
                if (domainId == 0 || learningObjectiveId == 0 || subjectId == 0 || userId == 0)
                {
                    await dbContext.SaveChangesAsync();
                }

                if (domainId == 0)
                {
                    domainNames.Add(work.Domain!.Name, work.Domain.Id);
                }

                if (learningObjectiveId == 0)
                {
                    learningObjectives.Add(work.LearningObjective!.Name, work.LearningObjective.Id);
                }

                if (subjectId == 0)
                {
                    subjects.Add(work.Subject!.Name, work.Subject.Id);
                }

                if (userId == 0)
                {
                    userIds.Add(work.UserId);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        private class WorkModel
        {
            public int SubmittedAnswerId { get; set; }
            public DateTime SubmitDateTime { get; set; }
            public int Correct { get; set; }
            public int Progress { get; set; }
            public int UserId { get; set; }
            public int ExerciseId { get; set; }
            public string? Difficulty { get; set; }
            public string Subject { get; set; } = string.Empty;
            public string Domain { get; set; } = string.Empty;
            public string LearningObjective { get; set; } = string.Empty;
        }
    }
}

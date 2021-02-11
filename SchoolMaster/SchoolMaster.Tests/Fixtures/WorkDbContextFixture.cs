using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolMaster.Database;
using SchoolMaster.Models;

namespace SchoolMaster.Tests.Fixtures
{
    public class WorkDbContextFixture
    {
        public WorkDbContextFixture()
        {
            Setup();
        }

        public WorkDbContext DbContext { get; private set; }

        private void Setup()
        {
            var start = DateTime.SpecifyKind(DateTime.Parse("2015-03-24 11:30:00"), DateTimeKind.Utc);

            var options = new DbContextOptionsBuilder<WorkDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            DbContext = new WorkDbContext(options);
            DbContext.Users.Add(new User
            {
                Firstname = "Robin ",
                LastName = "van Persie",
                UserId = 40272
            });

            DbContext.UserWorks.AddRange(GenerateData(start.AddHours(-4), start, 40272));

            DbContext.SaveChanges();
        }

        private ICollection<Work> GenerateData(DateTime from, DateTime end, int userId)
        {
            var result = new List<Work>();

            var submissionId = 0;

            while (from < end)
            {
                result.Add(new Work
                {
                    SubmittedAnswerId = ++submissionId,
                    UserId = userId,
                    Difficulty = 0.5,
                    Correct = 1,
                    Progress = submissionId % 2 == 0 ? 1 : 2,
                    SubmitDateTime = from,
                    Domain = "Math",
                    Subject = "-",
                    LearningObjective = "2*4",
                    ExerciseId = submissionId
                });

                from = from.AddHours(1);
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Moq;
using SchoolMaster.Database;
using SchoolMaster.Models;
using Xunit;

namespace SchoolMaster.Tests.Fixtures
{
    public class WorkDbContextFixture
    {
        public WorkDbContext DbContext { get; private set; }

        public WorkDbContextFixture()
        {
            Setup();
        }

        private void Setup()
        {
            var start = DateTime.SpecifyKind(DateTime.Parse("2015-03-24 11:30:00"), DateTimeKind.Utc);

            var options = new DbContextOptionsBuilder<WorkDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            DbContext = new WorkDbContext(options);
            DbContext.Users.Add(new User
            {
                Firstname = "Robin ",
                LastName = "van Persie",
                UserId = 40272
            });

            DbContext.UserWorks.AddRange(GenerateData(start.AddHours(-4), start, userId: 40272));

            DbContext.SaveChanges();
        }

        private ICollection<Work> GenerateData(DateTime from, DateTime end, int userId)
        {
            var result = new List<Work>();

            int submissionId = 0;

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

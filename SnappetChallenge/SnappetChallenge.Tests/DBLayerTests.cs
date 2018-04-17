namespace SnappetChallenge.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EFGetStarted.AspNetCore.NewDb.Models;
    using Microsoft.EntityFrameworkCore;
    using SnappetChallenge.Core;
    using Xunit;

    public class DBLayerTests
    {
        List<ReportItem> testItems = new List<ReportItem>()
        {
            new ReportItem { SubmittedAnswerId = 1, SubmitDateTime = DateTime.Now, Correct = 5 },
            new ReportItem { SubmittedAnswerId = 2, SubmitDateTime = DateTime.Now, Correct = 5 }
        };

        DbContextOptions<ClassReportContext> options;

        public DBLayerTests()
        {
            options = new DbContextOptionsBuilder<ClassReportContext>()
                .UseInMemoryDatabase(databaseName: "TestDbLayer")
                .Options;
        }

        [Fact]
        public async Task TestGetReportItemAsync()
        {
            using (var context = new ClassReportContext(options))
            {
                context.ReportItems.AddRange(testItems);
                context.SaveChanges();
            }

            using (var dbLayer = new ReportDatabaseLayer(new ClassReportContext(options)))
            {
                var result = await dbLayer.GetReportItemAsync(DateTime.Now);

                Assert.NotNull(result);
                Assert.Single(result);
                Assert.Equal(10, result[0].CorrectAnswers);
            }
        }

        [Fact]
        public async Task TestAddClassReportItem()
        {
            var testItems2 = new List<ReportItem>()
            {
                new ReportItem { SubmittedAnswerId = 3, SubmitDateTime = DateTime.Now, Correct = 0 }
            };

            using (var dbLayer = new ReportDatabaseLayer(new ClassReportContext(options)))
            {
                await dbLayer.AddClassReportItem(testItems2);
            }
        }
    }
}

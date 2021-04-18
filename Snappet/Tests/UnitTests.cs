using System;
using BlCore.BlServicesProviders;
using Database.DataProviders.Json;
using Xunit;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void UsersReportTest()
        {
            string testFilePath = "testwork.json";
            var jsonDataProvider = new JsonDataProvider(testFilePath);
            var bl = new BlServicesProvider();
            bl.SetDataProvider(jsonDataProvider);
            var reportService = bl.GetReportService();
            var begin = new DateTime(2021, 04, 18);
            var end = new DateTime(2021, 04, 18);
            var usersReport = reportService.GetUsersReport(begin, end);
            Assert.Equal(2, usersReport.Items.Length);
            Assert.Equal(2, usersReport.Total.UsersCount);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Snappet.Common.BusinessLogic;
using Snappet.DataProvider.Component;
using Snappet.Model.DataProvider;
using Snappet.Model.Domain;

namespace Snappet.DataProvider.Test
{
    [TestFixture]
    public class WorkReportJSONDataProviderTest
    {
        Mock<IDataProvider> DataProviderMock;
        WorkReportJSONDataProvider workReportJSONDataProvider;
        public WorkReportJSONDataProviderTest()
        {
            workReportJSONDataProvider = new WorkReportJSONDataProvider(UnityContainerInstance.Container);
            DataProviderMock = new Mock<IDataProvider>();
        }

        
        void setupMockData()
        {
            DataProviderMock.Setup(x => x.GetWorkDetails()).Returns(getMockWorkData());
            workReportJSONDataProvider.DataProvider = DataProviderMock.Object;
            workReportJSONDataProvider.DataType = "JSON";

        }       

        [Test]
        public void GetWorkReport_WhenSpecificData_ReturnsSpecificReport()
        {
            setupMockData();
            var workResult = workReportJSONDataProvider.GetWorkReport(DateTime.Now.Date, "", "");
            Assert.AreEqual(workResult.Count(), 3);
        }

        [Test]
        public void GetWorkReport_WhenSpecificData2_ReturnsSpecificReport()
        {
            setupMockData();
            var workResult = workReportJSONDataProvider.GetWorkReport(DateTime.Now.Date, "", "a");
            Assert.AreEqual(workResult.Count(), 3);
        }

        [Test]
        public void GetWorkReport_WhenSpecificData3_ReturnsSpecificReport()
        {
            setupMockData();
            var workResult = workReportJSONDataProvider.GetWorkReport(DateTime.Now.Date, "sa", "b");
            Assert.AreEqual(workResult.Count(), 1);
        }

        [Test]
        public void GetWorkReport_WhenSpecificWrongData_ReturnsSpecificEmptyReport()
        {
            setupMockData();
            var workResult = workReportJSONDataProvider.GetWorkReport(DateTime.Now, "sa", "b");
            Assert.AreEqual(workResult.Count(), 0);
        }

        List<Work> getMockWorkData()
        {
            return new List<Work>
            {
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = false,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 5,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = false,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 6,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = false,
                    Domain = "b",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "lb"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "lb"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 9,
                    Subject = "sa",
                    LearningObjective = "lb"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = false,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "lc"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "b",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "lb"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = false,
                    Domain = "a",
                    Progress = -10,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = false,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "lb"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "c",
                    Progress = -4,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = false,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "lc"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "f",
                    Progress = -6,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = false,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "lb"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "e",
                    Progress = 7,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "la"
                },
                new Work()
                {
                    SubmitDateTime = DateTime.Now.ToString(),
                    UserId = 1,
                    ExerciseId = 1,
                    Correct = true,
                    Domain = "a",
                    Progress = 1,
                    Subject = "sa",
                    LearningObjective = "lc"
                }
            };
        }
    }
}

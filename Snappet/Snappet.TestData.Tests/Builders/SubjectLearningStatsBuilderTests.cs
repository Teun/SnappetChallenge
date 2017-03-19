using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snappet.TestData.Builders;
using Snappet.TestData.Entities;
using System.Linq;
using Snappet.Data.Entities;

namespace Snappet.TestData.Tests.Builders
{
    [TestClass]
    public class SubjectLearningStatsBuilderTests
    {
        private SubjectLearningStatsBuilder _testBuilder;

        [TestInitialize]
        public void Init()
        {
            _testBuilder = new SubjectLearningStatsBuilder();
        }

        [TestMethod]
        public void LearningObjective_MultipleObjectives_AreGroupedCorrectly()
        {
            var testRecords = new[] {
                new ExerciseRecord
                {
                    Domain = "Domain",
                    LearningObjective = "LearningObjective1",
                    Subject = "Subject"
                },
                new ExerciseRecord
                {
                    Domain = "Domain2",
                    LearningObjective = "LearningObjective2",
                    Subject = "Subject"
                },
                new ExerciseRecord
                {
                    Domain = "Domain2",
                    LearningObjective = "LearningObjective2",
                    Subject = "Subject"
                }
            };
            var resultList = _testBuilder.BuildEntities(testRecords);
            Assert.AreEqual(2, resultList.Count);

            var firstDomain = resultList.First();
            ValidateLearningSubject(firstDomain.Aggregate, "Domain", "Subject");

            var secondDomain = resultList.Last();
            ValidateLearningSubject(secondDomain.Aggregate, "Domain2", "Subject");
        }

        [TestMethod]
        public void AverageExerciseStats_MultipleExercises_HaveCorrectAverage()
        {
            var testRecords = new[] {
                new ExerciseRecord
                {
                    Domain = "Domain",
                    LearningObjective = "LearningObjective1",
                    Subject = "Subject",
                    Correct = 1,
                    Difficulty = "209",
                    ExerciseId = 23,
                    Progress = -4,
                    SubmitDateTime = new DateTime(2010, 8, 2),
                    SubmittedAnswerId = 234324,
                    UserId = 3434
                },
                new ExerciseRecord
                {
                    Domain = "Domain2",
                    LearningObjective = "LearningObjective2",
                    Subject = "Subject",
                    Correct = 1,
                    Difficulty = "209",
                    ExerciseId = 23,
                    Progress = 4,
                    SubmitDateTime = new DateTime(2010, 8, 2),
                    SubmittedAnswerId = 234324,
                    UserId = 3434
                },
                new ExerciseRecord
                {
                    Domain = "Domain2",
                    LearningObjective = "LearningObjective2",
                    Subject = "Subject",
                    Correct = 0,
                    Difficulty = "209",
                    ExerciseId = 23,
                    Progress = -4,
                    SubmitDateTime = new DateTime(2010, 8, 2),
                    SubmittedAnswerId = 234325,
                    UserId = 3434
                }
            };
            var resultList = _testBuilder.BuildEntities(testRecords);

            var firstStats = resultList.First();
            Assert.AreEqual(1, firstStats.AverageExerciseCount);
            Assert.AreEqual(0, firstStats.AverageExerciseInCorrect);

            var secondStats = resultList.Last();
            Assert.AreEqual(2, secondStats.AverageExerciseCount);
            Assert.AreEqual(1, secondStats.AverageExerciseInCorrect);
        }

        [TestMethod]
        public void NegativeProgressUserStats_MultipleExercises_OnlyNegativeProgressUserStatsAreIncluded()
        {
            var testRecords = new[] {
                new ExerciseRecord{ Correct = 0, ExerciseId = 23, Progress = -4, UserId = 3434 },
                new ExerciseRecord{ Correct = 1, ExerciseId = 23, Progress =  4, UserId = 3435 },
                new ExerciseRecord{ Correct = 0, ExerciseId = 23, Progress = -4, UserId = 3434 },
                new ExerciseRecord{ Correct = 1, ExerciseId = 23, Progress = 2, UserId = 3434 }
            };
            var resultList = _testBuilder.BuildEntities(testRecords);

            var firstStats = resultList.First();
            Assert.AreEqual(1, firstStats.NegativeProgressUserStats.Count);
            var userStats = firstStats.NegativeProgressUserStats.First();
            Assert.AreEqual(3434, userStats.User.Id);
            Assert.AreEqual(-6, userStats.ProgressSum);
            Assert.AreEqual(3, userStats.ExerciseCount);
            Assert.AreEqual(2, userStats.ExerciseInCorrectCount);
        }

        [TestMethod]
        public void TopInCorrectExercises_MultipleExercises_OnlyNegativeProgressUserStatsAreIncluded()
        {
            var testRecords = new[] {
                new ExerciseRecord{ Correct = 0, ExerciseId = 0 },
                new ExerciseRecord{ Correct = 0, ExerciseId = 0 },
                new ExerciseRecord{ Correct = 0, ExerciseId = 0 },
                new ExerciseRecord{ Correct = 0, ExerciseId = 1 },
                new ExerciseRecord{ Correct = 0, ExerciseId = 1 },
                new ExerciseRecord{ Correct = 1, ExerciseId = 1 },
                new ExerciseRecord{ Correct = 0, ExerciseId = 2 },
                new ExerciseRecord{ Correct = 0, ExerciseId = 2 },
                new ExerciseRecord{ Correct = 1, ExerciseId = 2 },
                new ExerciseRecord{ Correct = 0, ExerciseId = 3 },
                new ExerciseRecord{ Correct = 1, ExerciseId = 3 },
                new ExerciseRecord{ Correct = 1, ExerciseId = 3 },
                new ExerciseRecord{ Correct = 0, ExerciseId = 4 },
                new ExerciseRecord{ Correct = 1, ExerciseId = 4 },
                new ExerciseRecord{ Correct = 1, ExerciseId = 4 },
                new ExerciseRecord{ Correct = 1, ExerciseId = 5 },
                new ExerciseRecord{ Correct = 1, ExerciseId = 5 },
                new ExerciseRecord{ Correct = 1, ExerciseId = 5 },
            };
            var resultList = _testBuilder.BuildEntities(testRecords);

            var firstStats = resultList.First();
            Assert.AreEqual(5, firstStats.TopInCorrectExercises.Count);
            for(int i = 0; i < 5; i++)
            {
                Assert.AreEqual(i, firstStats.TopInCorrectExercises[i].Exercise.Id);
                Assert.AreEqual(3, firstStats.TopInCorrectExercises[i].ExerciseCount);
            }
            var exerciseStats = firstStats.TopInCorrectExercises.First();
            Assert.AreEqual(3, firstStats.TopInCorrectExercises[0].ExerciseInCorrectCount);
            Assert.AreEqual(1, firstStats.TopInCorrectExercises[4].ExerciseInCorrectCount);
        }

        private void ValidateLearningSubject(LearningSubject learningSubject, string domain, string subject)
        {
            Assert.AreEqual(domain, learningSubject.LearningDomain.Name);
            Assert.AreEqual(subject, learningSubject.Name);
        }
    }
}

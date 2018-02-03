using System.Linq;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnappetChallenge.Core;
using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Tests
{
    [TestClass]
    public class UserStatisticsCalculatorTests
    {
        private IUserStatisticsCalculator userStatisticsCalculator;
        private Fixture fixture;

        [TestInitialize]
        public void Initialize()
        {
            userStatisticsCalculator = new UserStatisticsCalculator();
            fixture = new Fixture();
        }

        [TestMethod]
        public void Should_ReturnStatisticsForEmptyUser()
        {
            var user = fixture.Build<User>()
                .With(u => u.LearningObjectives, new LearningObjectiveForUser[0])
                .Create();
            var statistics = userStatisticsCalculator.GetStatistics(user);
            statistics.AverageProgress.Should().Be(0);
        }

        [TestMethod]
        public void OverallLearningObjectiveProgressInUser_ShouldBe_SumFromAllAnswers()
        {
            SubmittedAnswer CreateAnswerWithProgress(double progress)
            {
                return fixture.Build<SubmittedAnswer>()
                    .With(a => a.Progress, progress)
                    .Create();
            }

            var subset1 = new[]
            {
                CreateAnswerWithProgress(2),
                CreateAnswerWithProgress(4),
                CreateAnswerWithProgress(-6),
                CreateAnswerWithProgress(9)
            };

            var subset2 = new[]
            {
                CreateAnswerWithProgress(5),
                CreateAnswerWithProgress(-6),
                CreateAnswerWithProgress(9),
                CreateAnswerWithProgress(-2)
            };

            var learningObjective1 = fixture.Build<LearningObjectiveForUser>()
                .With(lo => lo.Answers, subset1)
                .Create();

            var learningObjective2 = fixture.Build<LearningObjectiveForUser>()
                .With(lo => lo.Answers, subset2)
                .Create();

            var user = fixture.Build<User>()
                .With(u => u.LearningObjectives, new[] { learningObjective1, learningObjective2 })
                .Create();

            var statistics = userStatisticsCalculator.GetStatistics(user);
            statistics.GetLearningObjectiveProgress(learningObjective1.Name, learningObjective1.Domain,
                    learningObjective1.Subject)
                .Should().Be(9);
            statistics.GetLearningObjectiveProgress(learningObjective2.Name, learningObjective2.Domain,
                    learningObjective2.Subject)
                .Should().Be(6);
        }

        [TestMethod]
        public void UserProgress_ShouldBe_AverageValueFromAllLearningObjectives()
        {
            var subset1 = fixture.CreateMany<SubmittedAnswer>(3).ToArray();
            var subset2 = fixture.CreateMany<SubmittedAnswer>(4).ToArray();
            var subset3 = fixture.CreateMany<SubmittedAnswer>(2).ToArray();
            var learningObjective1 = fixture.Build<LearningObjectiveForUser>()
                .With(lo => lo.Answers, subset1)
                .Create();
            var learningObjective2 = fixture.Build<LearningObjectiveForUser>()
                .With(lo => lo.Answers, subset2)
                .Create();
            var learningObjective3 = fixture.Build<LearningObjectiveForUser>()
                .With(lo => lo.Answers, subset3)
                .Create();

            var user = fixture.Build<User>()
                .With(u => u.LearningObjectives, new[] { learningObjective1, learningObjective2, learningObjective3 })
                .Create();

            var statistics = userStatisticsCalculator.GetStatistics(user);

            var expectedProgress = new[]
            {
                statistics.GetLearningObjectiveProgress(learningObjective1.Name, learningObjective1.Domain,
                    learningObjective1.Subject),
                statistics.GetLearningObjectiveProgress(learningObjective2.Name, learningObjective2.Domain,
                    learningObjective2.Subject),
                statistics.GetLearningObjectiveProgress(learningObjective3.Name, learningObjective3.Domain,
                    learningObjective3.Subject),
            }.Average();

            statistics.AverageProgress.Should().Be(expectedProgress);
        }
    }
}
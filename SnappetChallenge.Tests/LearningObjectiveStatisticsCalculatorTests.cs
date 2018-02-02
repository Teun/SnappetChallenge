using System.Linq;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnappetChallenge.Core;
using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Tests
{
    [TestClass]
    public class LearningObjectiveStatisticsCalculatorTests
    {
        private ILearningObjectiveStatisticsCalculator learningObjectiveStatisticsCalculator;
        private Fixture fixture;

        [TestInitialize]
        public void Initialize()
        {
            learningObjectiveStatisticsCalculator = new LearningObjectiveStatisticsCalculator();
            fixture = new Fixture();
        }

        [TestMethod]
        public void Should_ReturnEmptyStatistics()
        {
            var learningObjective = fixture.Build<LearningObjective>()
                .With(lo => lo.Users, new UserForLearningObjective[0])
                .Create();

            var statistics = learningObjectiveStatisticsCalculator.GetStatistics(learningObjective);
            statistics.AverageProgress.Should().Be(0);
        }

        [TestMethod]
        public void OverallUserProgressInLearningObjective_ShouldBe_SumOfProgressesFromAllAnswers()
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

            var user1 = fixture.Build<UserForLearningObjective>()
                .With(lo => lo.UserAnswers, subset1)
                .Create();

            var user2 = fixture.Build<UserForLearningObjective>()
                .With(lo => lo.UserAnswers, subset2)
                .Create();

            var learningObjective = fixture.Build<LearningObjective>()
                .With(lo => lo.Users, new[] { user1, user2 })
                .Create();

            var statistics = learningObjectiveStatisticsCalculator.GetStatistics(learningObjective);
            statistics.GetUserProgress(user1.UserId)
                .Should().Be(9);
            statistics.GetUserProgress(user2.UserId)
                .Should().Be(6);
        }

        [TestMethod]
        public void LearningObjectiveProgress_ShouldBe_AverageValueFromAllUsers()
        {
            var subset1 = fixture.CreateMany<SubmittedAnswer>(3).ToArray();
            var subset2 = fixture.CreateMany<SubmittedAnswer>(4).ToArray();
            var subset3 = fixture.CreateMany<SubmittedAnswer>(2).ToArray();
            var user1 = fixture.Build<UserForLearningObjective>()
                .With(u => u.UserAnswers, subset1)
                .Create();
            var user2 = fixture.Build<UserForLearningObjective>()
                .With(u => u.UserAnswers, subset2)
                .Create();
            var user3 = fixture.Build<UserForLearningObjective>()
                .With(u => u.UserAnswers, subset3)
                .Create();

            var learningObjective = fixture.Build<LearningObjective>()
                .With(lo => lo.Users, new[] { user1, user2, user3 })
                .Create();

            var statistics = learningObjectiveStatisticsCalculator.GetStatistics(learningObjective);

            var expectedProgress = new[]
            {
                statistics.GetUserProgress(user1.UserId),
                statistics.GetUserProgress(user2.UserId),
                statistics.GetUserProgress(user3.UserId)
            }.Average();

            statistics.AverageProgress.Should().Be(expectedProgress);
        }
    }
}
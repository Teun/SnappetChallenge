using System.Linq;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        public void Should_ReturnStatistics()
        {
            var subset1 = fixture.CreateMany<SubmittedAnswer>(3).ToArray();
            var subset2 = fixture.CreateMany<SubmittedAnswer>(4).ToArray();
            var subset3 = fixture.CreateMany<SubmittedAnswer>(10).ToArray();

            var user1 = fixture.Build<UserForLearningObjective>()
                .With(lo => lo.UserAnswers, subset1)
                .Create();

            var user2 = fixture.Build<UserForLearningObjective>()
                .With(lo => lo.UserAnswers, subset2)
                .Create();

            var user3 = fixture.Build<UserForLearningObjective>()
                .With(lo => lo.UserAnswers, subset3)
                .Create();
            
            var learningObjective = fixture.Build<LearningObjective>()
                .With(lo => lo.Users, new [] { user1, user2, user3 })
                .Create();

            var statistics = learningObjectiveStatisticsCalculator.GetStatistics(learningObjective);
            var expectedUser1Progress = user1.UserAnswers.Sum(a => a.Progress);
            statistics.GetUserProgress(user1.UserId)
                .Should().Be(expectedUser1Progress);
            var expectedUser2Progress = user2.UserAnswers.Sum(a => a.Progress);
            statistics.GetUserProgress(user2.UserId)
                .Should().Be(expectedUser2Progress);
            var expectedUser3Progress = user3.UserAnswers.Sum(a => a.Progress);
            statistics.GetUserProgress(user3.UserId)
                .Should().Be(expectedUser3Progress);

            statistics.AverageProgress
                .Should().Be(new[] {expectedUser1Progress, expectedUser2Progress, expectedUser3Progress}.Average());
        }
    }
}
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnappetChallenge.Core;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Data;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Tests
{
    [TestClass]
    public class UsersProviderTests
    {
        private IUsersProvider usersProvider;
        private Mock<ISubmittedAnswersProvider> submittedAnswersProviderSetup;
        private Mock<IUsersRepository> usersRepositorySetup;
        private Fixture fixture;

        [TestInitialize]
        public void Initialize()
        {
            var mockRepository = new MockRepository(MockBehavior.Loose);
            submittedAnswersProviderSetup = mockRepository.Create<ISubmittedAnswersProvider>();
            usersRepositorySetup = mockRepository.Create<IUsersRepository>();
            usersProvider = new UsersProvider(submittedAnswersProviderSetup.Object, usersRepositorySetup.Object);
            fixture = new Fixture();
        }

        [TestMethod]
        public void Should_ReturnEmpty_WhenNoUsers()
        {
            usersRepositorySetup.Setup(r => r.Query())
                .Returns(new UserDb[0].AsQueryable());

            var filter = new SubmittedAnswersFilter();

            submittedAnswersProviderSetup.Setup(p => p.GetAnswers(filter))
                .Returns(new SubmittedAnswer[0]);

            usersProvider.GetUsers(filter)
                .Should().BeEmpty();
        }

        [TestMethod]
        public void Should_ReturnUsers_WithoutAnswers()
        {
            var users = fixture.CreateMany<UserDb>(5).ToArray();
            usersRepositorySetup.Setup(r => r.Query())
                .Returns(users.AsQueryable());

            var filter = new SubmittedAnswersFilter();
            submittedAnswersProviderSetup.Setup(p => p.GetAnswers(filter))
                .Returns(new SubmittedAnswer[0]);

            usersProvider.GetUsers(filter)
                .Select(u => u.UserId)
                .ShouldBeEquivalentTo(users.Select(u => u.UserId));
        }

        [TestMethod]
        public void Should_GroupByUser()
        {
            var users = fixture.CreateMany<UserForSubmittedAnswer>(2).ToArray();
            var answersSetup = fixture.Build<SubmittedAnswer>()
                .With(a => a.LearningObjective, "learning objective")
                .With(a => a.Domain, "domain")
                .With(a => a.Subject, "subject");

            var subset1 = answersSetup.With(a => a.User, users[0])
                .CreateMany()
                .ToArray();

            var subset2 = answersSetup.With(a => a.User, users[1])
                .CreateMany()
                .ToArray();

            var dbUsers = users.Select(u => new UserDb {UserId = u.UserId, Name = u.Name, ImageId = u.ImageId});
            usersRepositorySetup.Setup(r => r.Query())
                .Returns(dbUsers.AsQueryable());
            
            var filter = new SubmittedAnswersFilter();
            submittedAnswersProviderSetup.Setup(p => p.GetAnswers(filter))
                .Returns(subset1.Union(subset2).ToArray());

            var resultUsers = usersProvider.GetUsers(filter);
            resultUsers.Length.Should().Be(2);
            var resultUser1 = resultUsers.First(u => u.UserId == users[0].UserId);
            resultUser1.LearningObjectives.Length.Should().Be(1);
            resultUser1.LearningObjectives[0].Answers.ShouldBeEquivalentTo(subset1);

            var resultUser2 = resultUsers.First(u => u.UserId == users[1].UserId);
            resultUser2.LearningObjectives.Length.Should().Be(1);
            resultUser2.LearningObjectives[0].Answers.ShouldBeEquivalentTo(subset2);
        }

        [TestMethod]
        public void Should_FilterByUser()
        {
            var users = fixture.CreateMany<UserDb>(4).ToArray();

            usersRepositorySetup.Setup(r => r.Query())
                .Returns(users.AsQueryable());

            var filter = new SubmittedAnswersFilter
            {
                UserId = users[1].UserId
            };

            submittedAnswersProviderSetup.Setup(p => p.GetAnswers(filter))
                .Returns(new SubmittedAnswer[0]);

            var resultUsers = usersProvider.GetUsers(filter);
            resultUsers.Length.Should().Be(1);
            resultUsers[0].UserId.Should().Be(users[1].UserId);
        }
    }
}
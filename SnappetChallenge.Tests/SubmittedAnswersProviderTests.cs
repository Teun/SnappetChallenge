using System;
using System.Linq;
using AutoFixture;
using FlashMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnappetChallenge.Core;
using SnappetChallenge.Core.Builders;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Core.SubmittedAnswersQueryFilters;
using SnappetChallenge.Data;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Tests
{
    [TestClass]
    public class SubmittedAnswersProviderTests
    {
        private ISubmittedAnswersProvider submittedAnswersProvider;
        private Mock<ISubmittedAnswersRepository> submittedAnswersRepositorySetup;
        private Mock<IUsersRepository> usersRepositorySetup;
        private Fixture fixture;

        [TestInitialize]
        public void Initialize()
        {
            fixture = new Fixture();
            var mockRepository = new MockRepository(MockBehavior.Loose);
            var mappingConfiguration = new MappingConfiguration();
            var userForSubmittedAnswerBuilder = new UserForSubmittedAnswerBuilder(mappingConfiguration);
            userForSubmittedAnswerBuilder.RegisterMapping();
            var submittedAnswersBuilder = new SubmittedAnswerBuilder(mappingConfiguration, userForSubmittedAnswerBuilder);
            submittedAnswersBuilder.RegisterMapping();
            submittedAnswersRepositorySetup = mockRepository.Create<ISubmittedAnswersRepository>();
            usersRepositorySetup = mockRepository.Create<IUsersRepository>();
            submittedAnswersProvider = new SubmittedAnswersProvider(submittedAnswersRepositorySetup.Object, 
                usersRepositorySetup.Object, new ISubmittedAnswersQueryFilterHandler[]
                {
                    new FromSubmittedAnswersQueryFilterHandler(),
                    new ToSubmittedAnswersQueryFilterHandler(),
                    new UserIdSubmittedAnswersQueryFilterHandler()
                }, submittedAnswersBuilder);
        }

        [TestMethod]
        public void Should_ReturnEmpty_WhenNoData()
        {
            submittedAnswersRepositorySetup.Setup(r => r.Query())
                .Returns(new SubmittedAnswerDb[0].AsQueryable());

            var users = fixture.CreateMany<UserDb>(10).ToArray();
            usersRepositorySetup.Setup(r => r.Query())
                .Returns(users.AsQueryable());
            var filter = fixture.Create<SubmittedAnswersFilter>();
            var answers = submittedAnswersProvider.GetAnswers(filter);
            answers.Should().NotBeNull();
            answers.Should().BeEmpty();
        }

        [TestMethod]
        public void Should_ReturnData()
        {
            var user1 = fixture.Build<UserDb>()
                .With(u => u.UserId, 1)
                .Create();

            usersRepositorySetup.Setup(r => r.Query())
                .Returns(new[] { user1 }.AsQueryable());

            var repositoryData = fixture.Build<SubmittedAnswerDb>()
                .With(a => a.UserId, user1.UserId)
                .CreateMany(20)
                .ToArray();

            submittedAnswersRepositorySetup.Setup(r => r.Query())
                .Returns(repositoryData.AsQueryable());

            var answers = submittedAnswersProvider.GetAnswers(new SubmittedAnswersFilter());

            answers.Select(a => a.SubmittedAnswerId)
                .ShouldBeEquivalentTo(repositoryData.Select(a => a.SubmittedAnswerId));
        }

        [TestMethod]
        public void Should_FilterByUser()
        {
            var user1 = fixture.Build<UserDb>()
                .With(u => u.UserId, 1)
                .Create();

            var user2 = fixture.Build<UserDb>()
                .With(u => u.UserId, 2)
                .Create();

            usersRepositorySetup.Setup(r => r.Query())
                .Returns(new[] {user1, user2}.AsQueryable());

            var subset1 = fixture.Build<SubmittedAnswerDb>()
                .With(a => a.UserId, user1.UserId)
                .CreateMany(10)
                .ToArray();

            var subset2 = fixture.Build<SubmittedAnswerDb>()
                .With(a => a.UserId, user2.UserId)
                .CreateMany(8)
                .ToArray();

            submittedAnswersRepositorySetup.Setup(r => r.Query())
                .Returns(subset1.Union(subset2).AsQueryable());

            var answers = submittedAnswersProvider.GetAnswers(
                new SubmittedAnswersFilter
                {
                    UserId = user1.UserId
                });

            answers.Select(a => a.SubmittedAnswerId)
                .ShouldBeEquivalentTo(subset1.Select(a => a.SubmittedAnswerId));
        }

        [TestMethod]
        public void Should_FilterByDates()
        {
            var user1 = fixture.Build<UserDb>()
                .With(u => u.UserId, 1)
                .Create();

            usersRepositorySetup.Setup(r => r.Query())
                .Returns(new[] { user1 }.AsQueryable());

            var subset1 = fixture.Build<SubmittedAnswerDb>()
                .With(a => a.SubmitDateTime, DateTime.Parse("2015-03-03T03:05:44Z"))
                .With(a => a.UserId, user1.UserId)
                .CreateMany(7)
                .ToArray();

            var subset2 = fixture.Build<SubmittedAnswerDb>()
                .With(a => a.SubmitDateTime, DateTime.Parse("2015-03-15T13:25:41Z"))
                .With(a => a.UserId, user1.UserId)
                .CreateMany(8)
                .ToArray();

            var subset3 = fixture.Build<SubmittedAnswerDb>()
                .With(a => a.SubmitDateTime, DateTime.Parse("2015-03-24T13:25:41Z"))
                .With(a => a.UserId, user1.UserId)
                .CreateMany(10)
                .ToArray();
            
            submittedAnswersRepositorySetup.Setup(r => r.Query())
                .Returns(subset1.Union(subset2).Union(subset3).AsQueryable());

            var from = DateTime.Parse("2015-03-10T00:00:00Z");
            var to = DateTime.Parse("2015-03-20T00:00:00Z");

            var filteredByFrom = submittedAnswersProvider.GetAnswers(
                new SubmittedAnswersFilter
                {
                    From = from
                });

            filteredByFrom.Select(sa => sa.SubmittedAnswerId)
                .ShouldBeEquivalentTo(subset2.Union(subset3).Select(sa => sa.SubmittedAnswerId));

            var filteredByTo = submittedAnswersProvider.GetAnswers(
                new SubmittedAnswersFilter
                {
                    To = to
                });

            filteredByTo.Select(sa => sa.SubmittedAnswerId)
                .ShouldBeEquivalentTo(subset1.Union(subset2).Select(sa => sa.SubmittedAnswerId));

            var filteredByRange = submittedAnswersProvider.GetAnswers(
                new SubmittedAnswersFilter
                {
                    From = from,
                    To = to
                });

            filteredByRange.Select(sa => sa.SubmittedAnswerId)
                .ShouldBeEquivalentTo(subset2.Select(sa => sa.SubmittedAnswerId));
        }
    }
}
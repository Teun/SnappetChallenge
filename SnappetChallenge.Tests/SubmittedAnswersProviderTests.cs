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
    }
}
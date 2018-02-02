using System.Collections.Generic;
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
    public class LearningObjectivesProviderTests
    {
        private ILearningObjectivesProvider learningObjectivesProvider;
        private Mock<ISubmittedAnswersProvider> submittedAnswersProviderSetup;
        private Fixture fixture;

        [TestInitialize]
        public void Initialize()
        {
            var mockRepository = new MockRepository(MockBehavior.Loose);
            submittedAnswersProviderSetup = mockRepository.Create<ISubmittedAnswersProvider>();
            learningObjectivesProvider = new LearningObjectivesProvider(submittedAnswersProviderSetup.Object);
            fixture = new Fixture();
        }

        [TestMethod]
        public void Should_ReturnEmpty_WhenNoAnswersFound()
        {
            var filter = fixture.Create<SubmittedAnswersFilter>();
            submittedAnswersProviderSetup.Setup(p => p.GetAnswers(filter))
                .Returns(new SubmittedAnswer[0]);

            var learningObjectives = learningObjectivesProvider.GetLearningObjectives(filter);
            learningObjectives.Should().NotBeNull();
            learningObjectives.Should().BeEmpty();
        }

        [TestMethod]
        public void Should_ReturnLearningObjectives()
        {
            var filter = fixture.Create<SubmittedAnswersFilter>();
            var user1 = fixture.Create<UserForSubmittedAnswer>();
            var user2 = fixture.Create<UserForSubmittedAnswer>();
            const string learningObjective1Name = "learning objective 1";
            const string learningObjective2Name = "learning objective 2";
            const string domainName = "domain";
            const string subjectName = "subject";
            var learningObjective1Setup = fixture.Build<SubmittedAnswer>()
                .With(a => a.LearningObjective, learningObjective1Name)
                .With(a => a.Domain, domainName)
                .With(a => a.Subject, subjectName);

            var subset1 = learningObjective1Setup
                .With(a => a.User, user1)
                .CreateMany(3)
                .ToArray();

            var subset2 = learningObjective1Setup
                .With(a => a.User, user2)
                .CreateMany(2)
                .ToArray();
            
            var learningObjective2Setup = fixture.Build<SubmittedAnswer>()
                .With(a => a.LearningObjective, learningObjective2Name)
                .With(a => a.Domain, domainName)
                .With(a => a.Subject, subjectName);

            var subset3 = learningObjective2Setup
                .With(a => a.User, user2)
                .CreateMany(5)
                .ToArray();
            
            submittedAnswersProviderSetup.Setup(p => p.GetAnswers(filter))
                .Returns(subset1.Union(subset2).Union(subset3).ToArray());

            var learningObjectives = learningObjectivesProvider.GetLearningObjectives(filter);
            learningObjectives.Length.Should().Be(2);

            void CheckLearningObjective(string learningObjectiveName, int usersTotal, UserForSubmittedAnswer user, IEnumerable<SubmittedAnswer> answers)
            {
                var learningObjective = learningObjectives.First(lo => lo.Name == learningObjectiveName);
                learningObjective.Domain.Should().Be(domainName);
                learningObjective.Subject.Should().Be(subjectName);
                learningObjective.Users.Length.Should().Be(usersTotal);
                var learningObjectiveUser = learningObjective.Users.First(u => u.UserId == user.UserId);
                learningObjectiveUser.ImageId.Should().Be(user.ImageId);
                learningObjectiveUser.Name.Should().Be(user.Name);
                learningObjectiveUser.UserAnswers.Should().BeEquivalentTo(answers);
            }
            CheckLearningObjective(learningObjective1Name, 2, user1, subset1);
            CheckLearningObjective(learningObjective1Name, 2, user2, subset2);
            CheckLearningObjective(learningObjective2Name, 1, user2, subset3);
        }

        [TestMethod]
        public void Should_GroupByDomainAndSubject()
        {
            const string learningObjectiveName = "learning objective";
            const string domain1Name = "domain 1";
            const string domain2Name = "domain 2";
            const string subject1Name = "subject 1";
            const string subject2Name = "subject 2";
            var user = fixture.Create<UserForSubmittedAnswer>();
            var learningObjectiveForSubject1Setup = fixture.Build<SubmittedAnswer>()
                .With(a => a.LearningObjective, learningObjectiveName)
                .With(a => a.Subject, subject1Name)
                .With(a => a.User, user);

            var subset1 = learningObjectiveForSubject1Setup
                .With(a => a.Domain, domain1Name)
                .CreateMany(3)
                .ToArray();

            var subset2 = learningObjectiveForSubject1Setup
                .With(a => a.Domain, domain2Name)
                .CreateMany(2)
                .ToArray();

            var learningObjectiveForSubject2Setup = fixture.Build<SubmittedAnswer>()
                .With(a => a.LearningObjective, learningObjectiveName)
                .With(a => a.Subject, subject2Name)
                .With(a => a.User, user);

            var subset3 = learningObjectiveForSubject2Setup
                .With(a => a.Domain, domain1Name)
                .CreateMany(5)
                .ToArray();

            var filter = fixture.Create<SubmittedAnswersFilter>();
            submittedAnswersProviderSetup.Setup(p => p.GetAnswers(filter))
                .Returns(subset1.Union(subset2).Union(subset3).ToArray());

            var learningObjectives = learningObjectivesProvider.GetLearningObjectives(filter);
            learningObjectives.Length.Should().Be(3);

            void CheckLearningObjective(string domain, string subject, IEnumerable<SubmittedAnswer> answers)
            {
                var learningObjective = learningObjectives.First(lo => lo.Name == learningObjectiveName && lo.Domain == domain && lo.Subject == subject);
                learningObjective.Users.Length.Should().Be(1);
                var learningObjectiveUser = learningObjective.Users.First();
                learningObjectiveUser.ImageId.Should().Be(user.ImageId);
                learningObjectiveUser.Name.Should().Be(user.Name);
                learningObjectiveUser.UserAnswers.Should().BeEquivalentTo(answers);
            }

            CheckLearningObjective(domain1Name, subject1Name, subset1);
            CheckLearningObjective(domain2Name, subject1Name, subset2);
            CheckLearningObjective(domain1Name, subject2Name, subset3);
        }
    }
}
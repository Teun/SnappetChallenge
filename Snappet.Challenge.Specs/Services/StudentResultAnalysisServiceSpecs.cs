using FakeItEasy;
using FluentAssertions;
using Snappet.Challenge.Domain;
using Snappet.Challenge.Domain.Entities;
using Snappet.Challenge.Services;
using Snappet.Challenge.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Snappet.Challenge.Specs.Services
{
    public class StudentResultAnalysisServiceSpecs
    {
        [Fact]
        public void When_searching_by_subject__it_should_return()
        {
            var repository = A.Fake<IRepository<StudentResult>>();
            A.CallTo(() => repository.GetAll()).Returns(
                new List<StudentResult> {
                    new StudentResult { Subject = "Subject1", Domain = "Domain1" },
                    new StudentResult { Subject = "Subject1", Domain = "Domain1" },
                    new StudentResult { Subject = "Subject2", Domain = "Domain1" },
                    new StudentResult { Subject = "Subject2", Domain = "Domain2" }
                });

            var result = new StudentResultAnalysisService(repository).SearchForSubectDomains("Subject1");

            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(
                new SubjectDomainDto
                {
                    Subject = "Subject1",
                    Domain = string.Empty
                },
                new SubjectDomainDto
                {
                    Subject = "Subject1",
                    Domain = "Domain1"
                });
        }

        [Fact]
        public void When_searching_by_domain_it_should_return()
        {
            var repository = A.Fake<IRepository<StudentResult>>();
            A.CallTo(() => repository.GetAll()).Returns(
                new List<StudentResult> {
                    new StudentResult { Subject = "Subject1", Domain = "Domain1" },
                    new StudentResult { Subject = "Subject1", Domain = "Domain1" },
                    new StudentResult { Subject = "Subject2", Domain = "Domain1" },
                    new StudentResult { Subject = "Subject2", Domain = "Domain2" }
                });

            var result = new StudentResultAnalysisService(repository).SearchForSubectDomains("Domain1");

            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(
                new SubjectDomainDto
                {
                    Subject = "Subject1",
                    Domain = "Domain1"
                },
                new SubjectDomainDto
                {
                    Subject = "Subject2",
                    Domain = "Domain1"
                });
        }

        [Fact]
        public void When_getting_daily_statistics_for_time_span_it_should_return()
        {
            const string subject = "Subject";
            var repository = A.Fake<IRepository<StudentResult>>();
            A.CallTo(() => repository.GetAll()).Returns(
                new List<StudentResult> {
                    new StudentResult { SubmitDateTime = new DateTime(2000, 1, 2), Subject = subject },
                    new StudentResult { SubmitDateTime = new DateTime(2000, 1, 3), Subject = subject },
                    new StudentResult { SubmitDateTime = new DateTime(2000, 1, 4), Subject = subject },
                    new StudentResult { SubmitDateTime = new DateTime(2000, 1, 5), Subject = subject }
                });

            var result = new StudentResultAnalysisService(repository).GetClassLearningObjectiveStatisticsFor(subject, null, 
                new DateTime(2000, 1,3), new DateTime(2000, 1, 4));

            result.Should().HaveCount(1);
            result.Single().DailyStatistics.Should().HaveCount(2);
        }

        [Fact]
        public void When_getting_daily_statistics_for_subject_and_domain_it_should_return()
        {
            const string subject1 = "Subject1";
            const string subject2 = "Subject2";
            const string domain1 = "Domain1";
            const string domain2 = "Domain2";

            var repository = A.Fake<IRepository<StudentResult>>();
            A.CallTo(() => repository.GetAll()).Returns(
                new List<StudentResult> {
                    new StudentResult { SubmitDateTime = new DateTime(2000, 1, 2), Subject = subject1, Domain = domain1 },
                    new StudentResult { SubmitDateTime = new DateTime(2000, 1, 2), Subject = subject1, Domain = domain1 },
                    new StudentResult { SubmitDateTime = new DateTime(2000, 1, 2), Subject = subject1, Domain = domain2 },
                    new StudentResult { SubmitDateTime = new DateTime(2000, 1, 2), Subject = subject2, Domain = domain1 },
                });

            var result = new StudentResultAnalysisService(repository).GetClassLearningObjectiveStatisticsFor(subject1, domain1,
                new DateTime(2000, 1, 1), new DateTime(2000, 1, 4));

            result.Should().HaveCount(1);
            result.Single().DailyStatistics.Should().HaveCount(1);
        }

        [Fact]
        public void When_getting_daily_statistics_for_subject_and_domain_it_should_return_correct_calulations()
        {
            const string subject = "Subject";
            const string learningObjective = "LearningObjective";

            var repository = A.Fake<IRepository<StudentResult>>();
            A.CallTo(() => repository.GetAll()).Returns(
                new List<StudentResult> {
                    new StudentResult {
                        SubmitDateTime = new DateTime(2000, 1, 2),
                        Subject = subject,
                        LearningObjective = learningObjective,
                        Correct = true,
                        Difficulty = 2.5F,
                        Progress = -1,
                        UserId = 1
                    },
                    new StudentResult {
                        SubmitDateTime = new DateTime(2000, 1, 2),
                        Subject = subject,
                        LearningObjective = learningObjective,
                        Correct = true,
                        Difficulty = 2.5F,
                        Progress = 10,
                        UserId = 2
                    },
                    new StudentResult {
                        SubmitDateTime = new DateTime(2000, 1, 2),
                        Subject = subject,
                        LearningObjective = learningObjective,
                        Correct = false,
                        Difficulty = 10,
                        Progress = 6,
                        UserId = 3
                    },
                });

            var result = new StudentResultAnalysisService(repository).GetClassLearningObjectiveStatisticsFor(subject, null,
                new DateTime(2000, 1, 1), new DateTime(2000, 1, 4));

            result.Should().HaveCount(1);
            result.Single().DailyStatistics.Should().HaveCount(1);
            result.Single().DailyStatistics.Single().Should().Be(new DailyClassStatisticsDto
            {
                AmountOfProgressedStudents = 2,
                AvgDifficulty = 5,
                AvgProgress = 5,
                Correct = 2,
                Incorrect = 1,
                SubmitDateTime = new DateTime(2000, 1, 2)
            });
        }
    }
}

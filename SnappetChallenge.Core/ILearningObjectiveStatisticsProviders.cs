using System.Collections.Generic;
using System.Linq;
using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public interface ILearningObjectiveStatisticsProviders
    {
        LearningObjective[] GetLearningObjectivesStatistics(SubmittedAnswersFilter filter);
    }

    public class LearningObjectiveGroupValues
    {
        public LearningObjectiveGroupValues(string name, string domain, string subject)
        {
            Name = name;
            Domain = domain;
            Subject = subject;
        }

        public string Name { get; }
        public string Domain { get; }
        public string Subject { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is LearningObjectiveGroupValues other))
                return false;
            return Equals(other);
        }

        protected bool Equals(LearningObjectiveGroupValues other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Domain, other.Domain) && string.Equals(Subject, other.Subject);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Domain != null ? Domain.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Subject != null ? Subject.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

    public interface IUserForLearningObjectiveBuilder : IBuilder<UserForSubmittedAnswer, IEnumerable<SubmittedAnswer>, UserForLearningObjective>
    {
    }

    public class UserForLearningObjectiveBuilder : FlashMapperBuilder<UserForSubmittedAnswer, IEnumerable<SubmittedAnswer>, UserForLearningObjective, UserForLearningObjectiveBuilder>, IUserForLearningObjectiveBuilder
    {
        private readonly IStatisticsService statisticsService;

        public UserForLearningObjectiveBuilder(IMappingConfiguration mappingConfiguration,
            IStatisticsService statisticsService) : base(mappingConfiguration)
        {
            this.statisticsService = statisticsService;
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<UserForSubmittedAnswer, IEnumerable<SubmittedAnswer>, UserForLearningObjective> configurator)
        {
            configurator
                .ResolveExtraParameter((user, submittedAnswers) => submittedAnswers.ToArray())
                .CreateMapping((user, submittedAnswers, submittedAnswersArray) => new UserForLearningObjective
                {
                    OverallProgress = statisticsService.GetOverallProgress(submittedAnswersArray),
                    UserAnswers = submittedAnswersArray
                });
        }
    }

    public interface ILearningObjectiveBuilder : IBuilder<LearningObjectiveGroupValues, IEnumerable<SubmittedAnswer>, LearningObjective>
    {
    }

    public class LearningObjectiveBuilder : FlashMapperBuilder<LearningObjectiveGroupValues, IEnumerable<SubmittedAnswer>, LearningObjective, LearningObjectiveBuilder>, ILearningObjectiveBuilder
    {
        private readonly IUserForLearningObjectiveBuilder userForLearningObjectiveBuilder;
        private readonly IStatisticsService statisticsService;

        public LearningObjectiveBuilder(IMappingConfiguration mappingConfiguration,
            IUserForLearningObjectiveBuilder userForLearningObjectiveBuilder,
            IStatisticsService statisticsService) : base(mappingConfiguration)
        {
            this.userForLearningObjectiveBuilder = userForLearningObjectiveBuilder;
            this.statisticsService = statisticsService;
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<LearningObjectiveGroupValues, IEnumerable<SubmittedAnswer>, LearningObjective> configurator)
        {
            configurator.ResolveExtraParameter((group, submittedAnswers) => GetUsersData(group, submittedAnswers))
                .CreateMapping((group, submittedAnswers, users) => new LearningObjective
                {
                    AverageProgress = statisticsService.GetAverageProgress(users.Select(u => u.OverallProgress)),
                    Users = users
                });
        }

        private UserForLearningObjective[] GetUsersData(LearningObjectiveGroupValues group, IEnumerable<SubmittedAnswer> submittedAnswers)
        {
            return submittedAnswers.GroupBy(sa => sa.User.UserId)
                .Select(sg => userForLearningObjectiveBuilder.Build(sg.First().User, sg))
                .ToArray();
        }
    }

    public class LearningObjectiveStatisticsProviders : ILearningObjectiveStatisticsProviders
    {
        private readonly ISubmittedAnswersProvider submittedAnswersProvider;

        public LearningObjectiveStatisticsProviders(ISubmittedAnswersProvider submittedAnswersProvider)
        {
            this.submittedAnswersProvider = submittedAnswersProvider;
        }

        public LearningObjective[] GetLearningObjectivesStatistics(SubmittedAnswersFilter filter)
        {
            var answers = submittedAnswersProvider.GetAnswers(filter);
            var answersGrouppedByLearningObjective = answers.GroupBy(a => new LearningObjectiveGroupValues(a.LearningObjective, a.Domain, a.Subject));
            foreach (var learningObjectivesGroup in answersGrouppedByLearningObjective)
            {
                
            }
            throw new System.NotImplementedException();
        }
    }
}
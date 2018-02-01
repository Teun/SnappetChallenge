using System.Linq;
using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Models;

namespace SnappetChallenge.Builders
{
    public class UserDetailsDtoBuilder : FlashMapperBuilder<User, UserDetailsDto, UserDetailsDtoBuilder>, IUserDetailsDtoBuilder
    {
        private readonly IUserStatisticsCalculator userStatisticsCalculator;
        private readonly ILearningObjectiveForUserDtoBuilder learningObjectiveForUserDtoBuilder;

        public UserDetailsDtoBuilder(IMappingConfiguration mappingConfiguration,
            IUserStatisticsCalculator userStatisticsCalculator,
            ILearningObjectiveForUserDtoBuilder learningObjectiveForUserDtoBuilder) : base(mappingConfiguration)
        {
            this.userStatisticsCalculator = userStatisticsCalculator;
            this.learningObjectiveForUserDtoBuilder = learningObjectiveForUserDtoBuilder;
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<User, UserDetailsDto> configurator)
        {
            configurator.ResolveExtraParameter(user => userStatisticsCalculator.GetStatistics(user))
                .CreateMapping((user, statistics) => new UserDetailsDto
                {
                    LearningObjectives = user.LearningObjectives
                        .Select(lo => learningObjectiveForUserDtoBuilder.Build(lo, statistics))
                        .ToArray()
                });
        }
    }
}
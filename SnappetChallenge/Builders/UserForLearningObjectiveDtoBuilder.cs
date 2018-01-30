using System.Collections.Generic;
using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Models;

namespace SnappetChallenge.Builders
{
    public class UserForLearningObjectiveDtoBuilder : FlashMapperBuilder<UserForLearningObjective, LearningObectiveStatistics, UserForLearningObjectiveDto, UserForLearningObjectiveDtoBuilder>, IUserForLearningObjectiveDtoBuilder
    {
        public UserForLearningObjectiveDtoBuilder(IMappingConfiguration mappingConfiguration) : base(mappingConfiguration)
        {
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<UserForLearningObjective, LearningObectiveStatistics, UserForLearningObjectiveDto> configurator)
        {
            configurator.CreateMapping((u, s) => new UserForLearningObjectiveDto
            {
                OverallProgress = s.GetUserProgress(u.UserId)
            });
        }
    }
}

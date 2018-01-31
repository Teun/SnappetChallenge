using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Models;

namespace SnappetChallenge.Builders
{
    public class UserForLearningObjectiveDtoBuilder : 
        FlashMapperBuilder<
            UserForLearningObjective, //Source1: User from domain model
            LearningObectiveStatistics, //Source2: Statistics for current LearningObjective instance and it's children
            UserForLearningObjectiveDto, //Result: Dto model
            UserForLearningObjectiveDtoBuilder>,
        IUserForLearningObjectiveDtoBuilder
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

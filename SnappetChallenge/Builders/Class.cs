using System.Collections.Generic;
using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Models;

namespace SnappetChallenge.Builders
{
    public interface IUserForLearningObjectiveDtoBuilder : IBuilder<UserForSubmittedAnswer, IEnumerable<SubmittedAnswer>, UserForLearningObjectiveDto>
    {
    }

    public class UserForLearningObjectiveDtoBuilder : FlashMapperBuilder<UserForSubmittedAnswer, IEnumerable<SubmittedAnswer>, UserForLearningObjectiveDto, UserForLearningObjectiveDtoBuilder>, 
        IUserForLearningObjectiveDtoBuilder
    {
        private readonly IStatisticsService statisticsService;

        public UserForLearningObjectiveDtoBuilder(IMappingConfiguration mappingConfiguration,
            IStatisticsService statisticsService) : base(mappingConfiguration)
        {
            this.statisticsService = statisticsService;
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<UserForSubmittedAnswer, IEnumerable<SubmittedAnswer>, UserForLearningObjectiveDto> configurator)
        {
            configurator.CreateMapping((user, answers) => new UserForLearningObjectiveDto
            {
                OverallProgress = statisticsService.GetOverallProgress(answers),
            });
        }
    }
}

using System.Linq;
using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Models;

namespace SnappetChallenge.Builders
{
    public class LearningObjectiveDtoBuilder : FlashMapperBuilder<LearningObjective, LearningObjectiveDto, LearningObjectiveDtoBuilder>,
        ILearningObjectiveDtoBuilder
    {
        private readonly ILearningObjectiveStatisticsCalculator learningObjectiveStatisticsCalculator;
        private readonly IUserForLearningObjectiveDtoBuilder userForLearningObjectiveDtoBuilder;

        public LearningObjectiveDtoBuilder(IMappingConfiguration mappingConfiguration,
            ILearningObjectiveStatisticsCalculator learningObjectiveStatisticsCalculator,
            IUserForLearningObjectiveDtoBuilder userForLearningObjectiveDtoBuilder) : base(mappingConfiguration)
        {
            this.learningObjectiveStatisticsCalculator = learningObjectiveStatisticsCalculator;
            this.userForLearningObjectiveDtoBuilder = userForLearningObjectiveDtoBuilder;
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<LearningObjective, LearningObjectiveDto> configurator)
        {
            configurator.ResolveExtraParameter(o => learningObjectiveStatisticsCalculator.GetStatistics(o))
                .CreateMapping((o, s) => new LearningObjectiveDto
                {
                    Users = o.Users
                        .Select(u => userForLearningObjectiveDtoBuilder.Build(u, s))
                        .OrderBy(u => u.Name)
                        .ToArray()
                });
        }
    }
}
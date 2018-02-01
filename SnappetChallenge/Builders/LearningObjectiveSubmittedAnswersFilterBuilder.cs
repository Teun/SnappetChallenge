using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Models;

namespace SnappetChallenge.Builders
{
    public class LearningObjectiveSubmittedAnswersFilterBuilder : FlashMapperBuilder<DateRangeFilterDto, SubmittedAnswersFilter, LearningObjectiveSubmittedAnswersFilterBuilder>, ILearningObjectiveSubmittedAnswersFilterBuilder
    {
        public LearningObjectiveSubmittedAnswersFilterBuilder(IMappingConfiguration mappingConfiguration) : base(mappingConfiguration)
        {
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<DateRangeFilterDto, SubmittedAnswersFilter> configurator)
        {
            configurator.CreateMapping(f => new SubmittedAnswersFilter
            {
                UserId = null,
            });
        }
    }
}
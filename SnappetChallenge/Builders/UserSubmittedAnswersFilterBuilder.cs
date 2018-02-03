using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Models;

namespace SnappetChallenge.Builders
{
    public class UserSubmittedAnswersFilterBuilder : FlashMapperBuilder<DateRangeFilterDto, int, SubmittedAnswersFilter, UserSubmittedAnswersFilterBuilder>, IUserSubmittedAnswersFilterBuilder
    {
        public UserSubmittedAnswersFilterBuilder(IMappingConfiguration mappingConfiguration) : base(mappingConfiguration)
        {
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<DateRangeFilterDto, int, SubmittedAnswersFilter> configurator)
        {
            configurator.CreateMapping((filter, userId) => new SubmittedAnswersFilter
            {
                UserId = userId,
            });
        }
    }
}
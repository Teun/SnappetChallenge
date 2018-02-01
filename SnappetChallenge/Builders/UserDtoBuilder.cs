using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Models;

namespace SnappetChallenge.Builders
{
    public class UserDtoBuilder : FlashMapperBuilder<User, UserDto, UserDtoBuilder>, IUserDtoBuilder
    {
        private readonly IUserStatisticsCalculator userStatisticsCalculator;

        public UserDtoBuilder(IMappingConfiguration mappingConfiguration,
            IUserStatisticsCalculator userStatisticsCalculator) : base(mappingConfiguration)
        {
            this.userStatisticsCalculator = userStatisticsCalculator;
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<User, UserDto> configurator)
        {
            configurator.ResolveExtraParameter(user => userStatisticsCalculator.GetStatistics(user))
                .CreateMapping((user, statistics) => new UserDto());
        }
    }
}
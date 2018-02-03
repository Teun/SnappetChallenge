using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Core.Builders
{
    public class UserForSubmittedAnswerBuilder : FlashMapperBuilder<UserDb, UserForSubmittedAnswer, UserForSubmittedAnswerBuilder>, IUserForSubmittedAnswerBuilder
    {
        public UserForSubmittedAnswerBuilder(IMappingConfiguration mappingConfiguration) : base(mappingConfiguration)
        {
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<UserDb, UserForSubmittedAnswer> configurator)
        {
            configurator.CreateMapping(user => new UserForSubmittedAnswer());
        }
    }
}
using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Core.Builders
{
    public class SubmittedAnswerBuilder : FlashMapperBuilder<SubmittedAnswerDb, UserDb, SubmittedAnswer, SubmittedAnswerBuilder>, ISubmittedAnswerBuilder
    {
        private readonly IUserForSubmittedAnswerBuilder userForSubmittedAnswerBuilder;

        public SubmittedAnswerBuilder(IMappingConfiguration mappingConfiguration,
            IUserForSubmittedAnswerBuilder userForSubmittedAnswerBuilder) : base(mappingConfiguration)
        {
            this.userForSubmittedAnswerBuilder = userForSubmittedAnswerBuilder;
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<SubmittedAnswerDb, UserDb, SubmittedAnswer> configurator)
        {
            configurator.CreateMapping((answer, user) => new SubmittedAnswer
            {
                User = userForSubmittedAnswerBuilder.Build(user),
            });
        }
    }
}
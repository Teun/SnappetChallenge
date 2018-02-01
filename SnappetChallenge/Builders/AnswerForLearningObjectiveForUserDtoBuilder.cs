using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Models;

namespace SnappetChallenge.Builders
{
    public class AnswerForLearningObjectiveForUserDtoBuilder 
        : FlashMapperBuilder<
            SubmittedAnswer, 
            AnswerForLearningObjectiveForUserDto, 
            AnswerForLearningObjectiveForUserDtoBuilder>, IAnswerForLearningObjectiveForUserDtoBuilder
    {
        public AnswerForLearningObjectiveForUserDtoBuilder(IMappingConfiguration mappingConfiguration) : base(mappingConfiguration)
        {
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<SubmittedAnswer, AnswerForLearningObjectiveForUserDto> configurator)
        {
            configurator.CreateMapping(sa => new AnswerForLearningObjectiveForUserDto
            {
                AnswerId = sa.SubmittedAnswerId,
                Correct = sa.Correct == 1,
            });
        }
    }
}
using System.Linq;
using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Models;

namespace SnappetChallenge.Builders
{
    public class LearningObjectiveForUserDtoBuilder 
        : FlashMapperBuilder<
            LearningObjectiveForUser, 
            UserStatistics, 
            LearningObjectiveForUserDto, 
            LearningObjectiveForUserDtoBuilder>, ILearningObjectiveForUserDtoBuilder
    {
        private readonly IAnswerForLearningObjectiveForUserDtoBuilder answerForLearningObjectiveForUserDtoBuilder;

        public LearningObjectiveForUserDtoBuilder(IMappingConfiguration mappingConfiguration, 
            IAnswerForLearningObjectiveForUserDtoBuilder answerForLearningObjectiveForUserDtoBuilder) : base(mappingConfiguration)
        {
            this.answerForLearningObjectiveForUserDtoBuilder = answerForLearningObjectiveForUserDtoBuilder;
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<LearningObjectiveForUser, UserStatistics, LearningObjectiveForUserDto> configurator)
        {
            configurator.CreateMapping((lo, s) => new LearningObjectiveForUserDto
            {
                OverallProgress = s.GetLearningObjectiveProgress(lo.Name, lo.Domain, lo.Subject),
                Answers = lo.Answers.Select(answerForLearningObjectiveForUserDtoBuilder.Build)
                    .ToArray()
            });
        }
    }
}
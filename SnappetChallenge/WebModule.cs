using FlashMapper;
using LightInject;
using SnappetChallenge.Builders;
using SnappetChallenge.Data;
using SnappetChallenge.Infrastructure;

namespace SnappetChallenge
{
    public class WebModule: ILightInjectModule
    {
        public void RegisterServices(IServiceRegistry container)
        {
            container.Register<ILearningObjectiveDtoBuilder, LearningObjectiveDtoBuilder>();
            container.Register<IFlashMapperBuilder, LearningObjectiveDtoBuilder>(nameof(LearningObjectiveDtoBuilder));
            container.Register<ILearningObjectiveSubmittedAnswersFilterBuilder, LearningObjectiveSubmittedAnswersFilterBuilder>();
            container.Register<IFlashMapperBuilder, LearningObjectiveSubmittedAnswersFilterBuilder>(nameof(LearningObjectiveSubmittedAnswersFilterBuilder));
            container.Register<IUserForLearningObjectiveDtoBuilder, UserForLearningObjectiveDtoBuilder>();
            container.Register<IFlashMapperBuilder, UserForLearningObjectiveDtoBuilder>(nameof(UserForLearningObjectiveDtoBuilder));
        }
    }
}
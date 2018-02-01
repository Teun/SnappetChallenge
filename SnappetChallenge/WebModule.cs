using FlashMapper;
using LightInject;
using SnappetChallenge.Builders;
using SnappetChallenge.Core.Models;
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
            container.Register<IAnswerForLearningObjectiveForUserDtoBuilder, AnswerForLearningObjectiveForUserDtoBuilder>();
            container.Register<IFlashMapperBuilder, AnswerForLearningObjectiveForUserDtoBuilder>(nameof(AnswerForLearningObjectiveForUserDtoBuilder));
            container.Register<ILearningObjectiveForUserDtoBuilder, LearningObjectiveForUserDtoBuilder>();
            container.Register<IFlashMapperBuilder, LearningObjectiveForUserDtoBuilder>(nameof(LearningObjectiveForUserDtoBuilder));
            container.Register<IUserDetailsDtoBuilder, UserDetailsDtoBuilder>();
            container.Register<IFlashMapperBuilder, UserDetailsDtoBuilder>(nameof(UserDetailsDtoBuilder));
            container.Register<IUserDtoBuilder, UserDtoBuilder>();
            container.Register<IFlashMapperBuilder, UserDtoBuilder>(nameof(UserDtoBuilder));
            container.Register<IUserSubmittedAnswersFilterBuilder, UserSubmittedAnswersFilterBuilder>();
            container.Register<IFlashMapperBuilder, UserSubmittedAnswersFilterBuilder>(nameof(UserSubmittedAnswersFilterBuilder));
        }
    }
}
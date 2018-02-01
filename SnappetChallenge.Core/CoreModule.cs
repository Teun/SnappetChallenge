using FlashMapper;
using LightInject;
using SnappetChallenge.Core.Builders;
using SnappetChallenge.Core.SubmittedAnswersQueryFilters;
using SnappetChallenge.Infrastructure;

namespace SnappetChallenge.Core
{
    public class CoreModule: ILightInjectModule
    {
        public void RegisterServices(IServiceRegistry container)
        {
            container.Register<ILearningObjectivesProvider, LearningObjectivesProvider>();
            container.Register<ILearningObjectiveStatisticsCalculator, LearningObjectiveStatisticsCalculator>();
            container.Register<ISubmittedAnswersProvider, SubmittedAnswersProvider>();
            container.Register<ISubmittedAnswerBuilder, SubmittedAnswerBuilder>();
            container.Register<IFlashMapperBuilder, SubmittedAnswerBuilder>(nameof(SubmittedAnswerBuilder));
            container.Register<IUserForSubmittedAnswerBuilder, UserForSubmittedAnswerBuilder>();
            container.Register<IFlashMapperBuilder, UserForSubmittedAnswerBuilder>(nameof(UserForSubmittedAnswerBuilder));
            container.Register<IImageBuilder, ImageBuilder>();
            container.Register<IFlashMapperBuilder, ImageBuilder>(nameof(ImageBuilder));
            container.Register<ISubmittedAnswersQueryFilterHandler, FromSubmittedAnswersQueryFilterHandler>(nameof(FromSubmittedAnswersQueryFilterHandler));
            container.Register<ISubmittedAnswersQueryFilterHandler, ToSubmittedAnswersQueryFilterHandler>(nameof(ToSubmittedAnswersQueryFilterHandler));
            container.Register<ISubmittedAnswersQueryFilterHandler, UserIdSubmittedAnswersQueryFilterHandler>(nameof(UserIdSubmittedAnswersQueryFilterHandler));
            container.Register<IImageProvider, ImageProvider>();
            container.Register<IUsersProvider, UsersProvider>();
            container.Register<IUserStatisticsCalculator, UserStatisticsCalculator>();
        }
    }
}
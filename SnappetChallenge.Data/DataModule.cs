using LightInject;
using SnappetChallenge.Infrastructure;

namespace SnappetChallenge.Data
{
    public class DataModule : ILightInjectModule
    {
        public void RegisterServices(IServiceRegistry container)
        {
            container.Register<ISubmittedAnswersRepository, SubmittedAnswersRepository>();
            container.Register<IImagesRepository, ImagesRepository>();
            container.Register<IUsersRepository, UsersRepository>();
        }
    }
}
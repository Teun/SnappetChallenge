using FlashMapper;
using FlashMapper.DependencyInjection;
using LightInject;

namespace SnappetChallenge.Infrastructure
{
    public class InfrastructureModule : ILightInjectModule
    {
        public void RegisterServices(IServiceRegistry container)
        {
            container.Register<IMappingConfiguration, MappingConfiguration>(new PerContainerLifetime());
            container.Register<IInitializer, FlashMapperInitializer>();
            container.Register<IAppInitializer, AppInitializer>();
            container.Register<IFlashMapperBuildersRegistrationService, FlashMapperBuildersRegistrationService>();
        }
    }
}
using LightInject;

namespace SnappetChallenge.Infrastructure
{
    public static class LightInjectModuleExtensions
    {
        public static IServiceRegistry RegisterModule(this IServiceRegistry serviceRegistry, ILightInjectModule module)
        {
            module.RegisterServices(serviceRegistry);
            return serviceRegistry;
        }
    }
}
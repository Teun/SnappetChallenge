using LightInject;

namespace SnappetChallenge.Infrastructure
{
    public interface ILightInjectModule
    {
        void RegisterServices(IServiceRegistry container);
    }
}
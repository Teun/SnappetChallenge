namespace BlCore.IoC
{
    internal interface ISnappetDependencyResolver
    {
        T Resolve<T>();

        void RegisterInstance<T>(T instance);
    }
}

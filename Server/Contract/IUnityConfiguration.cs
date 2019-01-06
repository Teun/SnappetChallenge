using System;
using Unity;

namespace Contract
{
    public interface IUnityConfiguration
    {
        void RegisterType(IUnityContainer container);
    }
}

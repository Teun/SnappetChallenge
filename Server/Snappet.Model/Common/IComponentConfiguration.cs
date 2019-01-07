using System;
using Unity;

namespace Snappet.Model
{
    public interface IComponentConfiguration
    {
        void RegisterType(IUnityContainer container);
    }
}

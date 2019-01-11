using System;
using Unity;

namespace Snappet.Model.Common
{
    public interface IComponentConfiguration
    {
        void RegisterType(IUnityContainer container);
    }
}

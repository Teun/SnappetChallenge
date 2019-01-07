
using System;
using Unity;

namespace Snappet.Common.BusinessLogic
{
    public static class UnityContainerInstance
    {
        private static IUnityContainer container;
        public static IUnityContainer Container
        {
            get
            {
                return container;
            }
            set
            {
                if(container==null)
                    container = value;
            }
        }
    }
}

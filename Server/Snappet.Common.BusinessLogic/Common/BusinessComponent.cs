using Snappet.Model.Common;
using Unity;

namespace Snappet.Common.BusinessLogic
{
    public class BusinessComponent : IBusinessComponent
    {
        private IUnityContainer _container; 
        public BusinessComponent(IUnityContainer container)
        {
            _container = container;
        }
        public T GetBusinessComponent<T>()
        {
            return _container.Resolve<T>();
        }
        public T GetBusinessComponent<T>(string aliasName)
        {
            return _container.Resolve<T>(aliasName);
        }
        public T GetRepository<T>()
        {
            return _container.Resolve<T>();
        }
        public T GetRepository<T>(string aliasName)
        {
            return _container.Resolve<T>(aliasName);
        }
    }
}

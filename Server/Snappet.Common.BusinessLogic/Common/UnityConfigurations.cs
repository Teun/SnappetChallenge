using Snappet.Model.Common;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Unity;

namespace Snappet.WebAPI.Unity
{
    public class UnityConfigurations
    {        
        [ImportMany(typeof(IComponentConfiguration))]
        public IEnumerable<IComponentConfiguration> ComponentConfigurations;

        public UnityConfigurations()
        {
            var catalog = new AggregateCatalog();
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
            catalog.Catalogs.Add(new DirectoryCatalog(appPath));
            CompositionContainer compositionContainer = new CompositionContainer(catalog);
            compositionContainer.ComposeParts(this);
        }

        public IUnityContainer UnityResolver()
        {
            IUnityContainer _container = new UnityContainer();
            ComponentConfigurations.ToList().ForEach((Configuration) =>
            {
                Configuration.RegisterType(_container);
            });
            return _container;
        }
    }
}
using Snappet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Unity;
//using System.Composition.Hosting;

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

       // [Import(typeof(IComponentConfiguration))]
       // public IComponentConfiguration UnityConfiguration;

        //public UnityConfigurations()
        //{
        //    var catalog = new AggregateCatalog();
        //    string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
        //    catalog.Catalogs.Add(new DirectoryCatalog(appPath));
        //    compositionContainer = new CompositionContainer(catalog);
        //    compositionContainer.ComposeParts(this);            
        //}

        //public IUnityContainer UnityResolver()
        //{
        //    IUnityContainer _container = new UnityContainer();
        //    UnityConfigurations unityConfig = new UnityConfigurations();            
        //    unityConfig.UnityConfiguration.RegisterType(_container);
        //    return _container;
        //}
    }
}
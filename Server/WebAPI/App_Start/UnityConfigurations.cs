using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using Unity;

namespace WebAPI.Unity
{
    public class UnityConfigurations
    {
        public CompositionContainer compositionContainer;
        public static IUnityContainer _container = new UnityContainer();
        [Import(typeof(IUnityConfiguration))]
        public IUnityConfiguration UnityConfiguration;

        public UnityConfigurations()
        {
            var catalog = new AggregateCatalog();
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
            catalog.Catalogs.Add(new DirectoryCatalog(appPath));
            compositionContainer = new CompositionContainer(catalog);

            try
            {
                compositionContainer.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                //Console.WriteLine(compositionException.ToString());
            }
        }

        public IUnityContainer UnityResolver()
        {
            
            UnityConfigurations unityConfig = new UnityConfigurations();
            unityConfig.UnityConfiguration.RegisterType(_container);            
            return _container;
        }
    }
}
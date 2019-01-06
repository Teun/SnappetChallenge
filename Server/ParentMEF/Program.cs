using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using Contract;
using Unity;

namespace ParentMEF
{
    class Program
    {
        private CompositionContainer _container;
        [Import(typeof(IUnityConfiguration))]
        public IUnityConfiguration UnityConfiguration;
        private Program()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog("C:\\myCode\\study\\Snappet\\MEF\\ParentMEF\\ParentMEF\\bin\\Debug"));
            _container = new CompositionContainer(catalog);

            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
        static void Main(string[] args)
        {
            IUnityContainer _container = new UnityContainer();
           Program p = new Program();
           p.UnityConfiguration.RegisterType(_container);
           _container.Resolve<IStudentFacade>().GetStudent("print");
        }      

       
    }
}
    

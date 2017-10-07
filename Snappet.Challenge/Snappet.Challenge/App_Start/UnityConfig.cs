using Microsoft.Practices.Unity;
using Snappet.Challenge.Facade;
using Snappet.Data;
using Snappet.DataAnalytics;
using Snappet.Repository;
using System.Web.Http;
using Unity.WebApi;

namespace Snappet.Challenge
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = BuildContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
        private static IUnityContainer BuildContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IStudentSkillRepository, StudentSkillRepository>();
            container.RegisterType<IDataFactory, DataFactory>();
            container.RegisterType<IReportDataFacade, ReportDataFacade>();
            container.RegisterType<IStatisticsDataFacade, StatisticsDataFacade>();
            container.RegisterType<IDataAnalyticsFacade, DataAnalyticsFacade>();
            container.RegisterType<IScatterPlotDataFacade, ScatterPlotDataFacade>();
            return container;
        }
    }
}
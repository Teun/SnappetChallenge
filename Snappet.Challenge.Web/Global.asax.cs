using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Snappet.Challenge.Domain;
using System.Configuration;
using Snappet.Challenge.Services;
using Snappet.Challenge.Services.Dto;
using Snappet.Challenge.Web.Models;
using AutoMapper;

namespace Snappet.Challenge.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacConfig();
            AutomapperConfig();
        }

        private void AutofacConfig()
        {
            var jsonFilePath = Server.MapPath(ConfigurationManager.AppSettings["JsonDataFilePath"]);
            var builder = new ContainerBuilder();

            builder.RegisterGeneric(typeof(JsonRepository<>))
                .As(typeof(IRepository<>))
                .WithParameter("filePath", jsonFilePath)
                .SingleInstance();

            builder.RegisterType<StudentResultAnalysisService>()
                .As<IStudentResultAnalysisService>();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void AutomapperConfig()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DailyClassStatisticsDto, DailyStatisticsChartModel>()
                .ForMember(
                    dest => dest.X,
                    opt => opt.MapFrom(x => (long)(x.SubmitDateTime - new DateTime(1970, 1, 1)).TotalMilliseconds))
                .ForMember(
                    dest => dest.Y,
                    opt => opt.MapFrom(x => x.AvgProgress));

                cfg.CreateMap<LearningObjectiveStatisticsDto, LearningObjectiveStatisticsChartModel>()
                .ForMember(
                    dest => dest.DailyStatistics,
                    opt => opt.MapFrom(x => Mapper.Map<DailyClassStatisticsDto[], DailyStatisticsChartModel[]>(x.DailyStatistics.ToArray())));
             }); 
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using SnappetChallenge.BusinessLogicLayer;
using SnappetChallenge.BusinessLogicLayer.BusinessObjects;
using SnappetChallenge.Controllers;
using SnappetChallenge.Interfaces;
using SnappetChallenge.Models;
using SnappetChallenge.Services;
using SubmittedAnswerBO = SnappetChallenge.BusinessLogicLayer.BusinessObjects.SubmittedAnswer;
using SnappetChallenge.BusinessLogicLayer.Services;

namespace SnappetChallenge
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitAutomapper();
            InitAutofac();
        }

        private void InitAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new SnappetChallenge.BusinessLogicLayer.AutoFacInit());

            builder.Register(x => Mapper.Instance).As<IMapper>();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ChartService>().As<IChartService>().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void InitAutomapper()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<SubmittedAnswerViewModel, SubmittedAnswerBO>();
                cfg.CreateMap<SubmittedAnswerBO, SubmittedAnswerViewModel>();
                cfg.CreateMap<TopStudentsViewModel, TopStudentStatistic>();
                cfg.CreateMap<TopStudentStatistic, TopStudentsViewModel>();
            });
            Mapper.Configuration.CompileMappings();
        }
    }
}

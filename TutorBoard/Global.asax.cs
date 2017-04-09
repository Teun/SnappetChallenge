using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using LightInject;
using TutorBoard.Dal.Data;
using TutorBoard.Dal.Repositories;
using TutorBoard.Report.Services;
using System.IO;
using TutorBoard.Dal.Providers;

namespace TutorBoard
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            var container = new ServiceContainer();
            container.RegisterControllers();
            container.RegisterApiControllers();

            // register dal
            var jsonFile = Path.Combine(Server.MapPath("~/App_Data"), "work.json");
            var fakeDate = new DateTime(2015, 3, 24, 11, 30, 00, DateTimeKind.Utc);
            container.Register<IDateTimeProvider>((f) => new FakeDateTimeProvider(fakeDate));
            container.Register<IDataContext>((f) => new JsonDataContext(jsonFile, f.GetInstance<IDateTimeProvider>()), new PerContainerLifetime());
            container.Register<ISubjectRepository, SubjectRepository>();
            container.Register<IWorkResultRepository, WorkResultRepository>();
            container.Register<IUserRepository, UserRepository>();

            //register report services
            container.Register<IDailyReportService, DailyReportService>();

            container.EnableMvc();
            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);
        }
    }
}
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Snappet.Core.Utils;
using Snappet.Repository.Dao;
using Snappet.Repository.Interfaces;
using Snappet.Services.Services;

namespace Snappet
{
    public class MvcApplication : HttpApplication
    {
        private readonly IAppSettingsRepository _appSettingsRepository = AppSettingsRepository.GetInstance();
        private readonly IAppLogRepository _appLogRepository = AppLogRepository.GetInstance();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //CheckBulkUploadStatus(); // I dont have sufficient time to proof this auto upload implementation

        }

        private void CheckBulkUploadStatus()
        {
            #region -- Check if Bulk Upload has been done else do it--
            try
            {
                bool isBulkUploadCompleted;
                var bulkUploadSettings = _appSettingsRepository.GetByName(ApplicationConstants.HasFileBeenUploaded);
                if (string.IsNullOrEmpty(bulkUploadSettings.Value) ||
                    bool.TryParse(bulkUploadSettings.Value, out isBulkUploadCompleted)) return;
                var bulkData = new WorkService().LoadAndDataFile();
                new WorkRepository().BulkInsert(bulkData);
            }
            catch (Exception exception)
            {
                _appLogRepository.Log(exception);
            }

            #endregion
        }
    }
}

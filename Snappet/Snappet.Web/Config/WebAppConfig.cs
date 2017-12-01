using Snappet.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snappet.Web.Config
{
    public class WebAppConfig : IAppConfig
    {
        public string DataFilePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["csvFilePath"]);
            }
        }
    }
}
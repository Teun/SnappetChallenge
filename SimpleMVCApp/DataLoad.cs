using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVCApp
{
    public static class DataLoader
    {
        public static object GetData()
        {
            return System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/") + "work.json");
        }
    }
}
using Snappet.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Web.Tests.Config
{
    public class TestConfig : IAppConfig
    {
        public string DataFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["csvDataPath"];
            }
        }
    }
}

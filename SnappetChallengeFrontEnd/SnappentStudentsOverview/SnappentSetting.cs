using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetChallenge.Client
{
    public class SnappentSetting 
    {
        private static SnappentSetting _snappentSetting ;
        public string CurrentEnvironment { get; set; } = Constants.ProductionEnvironmentBaseUrl;
        public static SnappentSetting  snappentSetting
        {
            get { return _snappentSetting ??= new SnappentSetting(); }
        }
    }
}

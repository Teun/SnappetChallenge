using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Contracts.ConfigrationSettings
{
    public class ConfigurationSettings
    {
        public string PathToDbFile { get; set; }
        public DateTimeOffset DateTimeNow { get; set; }
    }
}

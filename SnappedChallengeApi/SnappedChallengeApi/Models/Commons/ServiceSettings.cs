using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappedChallengeApi.Models.Commons
{
    public class ServiceSettings
    {
        //TODO move to appsettings json
        public string DataPath { get; set; } = "Data\\work.json";
    }
}

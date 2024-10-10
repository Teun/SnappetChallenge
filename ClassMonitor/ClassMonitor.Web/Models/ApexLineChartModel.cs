using System.Text.Json.Serialization;

namespace ClassMonitor.Web.Models
{
    public class ApexLineChartModel
    {
        public ChartModel Chart { get; } = new();
        public required SeriesModel[] Series {  get; set; }
        public required XAxisModel Xaxis { get; set; }


        public class ChartModel
        {
            public string Type { get; } = "line";
        }

        public class SeriesModel
        {
            public required string Name { get; set; }
            public required float?[] Data { get; set; }
        }

        [JsonDerivedType(typeof(XAxisStringModel), typeDiscriminator: "string")]
        [JsonDerivedType(typeof(XAxisDoubleModel), typeDiscriminator: "double")]
        public abstract class XAxisModel
        {
            //public string[] Categories { get; set; }
        }

        public class XAxisStringModel : XAxisModel
        {
            public string Type { get; } = "category";
            public required string[] Categories { get; set; }
        }

        public class XAxisDoubleModel : XAxisModel
        {
            public string Type { get; } = "datetime";
            public required double[] Categories { get; set; }
        }
    }
}

using System;

namespace Snappet.ClassInsights.Model.Configurations
{
    public class DataSeederOptions
    {
        public string JsonFilePath { get; set; }

        /// <summary>
        /// If true, seeder will silently continue in case of seeding failure, otherwise it will throw
        /// </summary>
        public bool ContinueOnDataSeedingFailure { get; set; }

        public DateTime? MaximumValidSubmitDateTime { get; set; }
    }
}

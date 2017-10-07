using Newtonsoft.Json;
using Snappet.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Snappet.Data
{
    public class DataFactory: IDataFactory
    {
        private string _dataFileName =ConfigurationManager.AppSettings[Constants.DataFileName];

        static List<StudentSkill> skills;
        public IList<StudentSkill> FetchData()
        {
            if (skills != null) return skills;

            var studentSkills = new List<StudentSkill>();
            var applicationBasePath = AppDomain.CurrentDomain.BaseDirectory;
            var dataFilePath = $"{applicationBasePath}\\App_data\\{_dataFileName}";

            if (!File.Exists(dataFilePath))
            {
                throw new FileNotFoundException($"The given {dataFilePath} is doenot exist");
            }
            var jsonStream = File.ReadAllText(dataFilePath);

            try
            {
                studentSkills = JsonConvert.DeserializeObject<List<StudentSkill>>(jsonStream);
            }
            catch(JsonException exception)
            {
                //Log exception
            }
            skills = studentSkills;
            return studentSkills;
        }
    }
}

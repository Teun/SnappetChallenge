using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Report.Data
{
    internal class InMemoryJsonDataContext : IDataContext
    {
        private readonly string _filePath;

        private List<UserActivity> _data;

        private object _locker = new object();

        public InMemoryJsonDataContext(IConfiguration configuration)
        {
            _filePath = configuration.GetValue<string>("Data:FilePath");
        }

        public Task<IEnumerable<UserActivity>> Get()
        {
            lock (_locker)
            {
                LoadDataLazy();
                return Task.Run<IEnumerable<UserActivity>>(() => _data);
            }
        }

        private void LoadDataLazy()
        {
            if (_data == null)
            {
                JArray items = JArray.Parse(File.ReadAllText(_filePath));

                _data = new List<UserActivity>(items.Count);

                foreach (var t in items.Children())
                {
                    _data.Add(new UserActivity(
                        t["SubmittedAnswerId"].Value<int>(),
                        DateTime.SpecifyKind(t["SubmitDateTime"].Value<DateTime>(), DateTimeKind.Utc),
                        t["Correct"].Value<int>() == 1,
                        t["Progress"].Value<int>(),
                        t["UserId"].Value<int>(),
                        t["ExerciseId"].Value<int>(),
                        GetDifficulty(t["Difficulty"].Value<string>()),
                        t["Subject"].Value<string>(),
                        t["Domain"].Value<string>(),
                        t["LearningObjective"].Value<string>()));
                }
            }

            static float GetDifficulty(string difficulty)
            {
                if(float.TryParse(difficulty, NumberStyles.Float, CultureInfo.InvariantCulture, out var f))
                {
                    return f;
                }

                return default;
            }
        }
    }
}

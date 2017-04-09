using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TutorBoard.Dal.Dtos;
using TutorBoard.Dal.Providers;

namespace TutorBoard.Dal.Data
{
    public class JsonDataContext : IDataContext
    {
        private readonly string _fileName;
        private readonly IDateTimeProvider _dateTime;

        private IEnumerable<WorkDto> _workData;

        private object _dataLock;

        public JsonDataContext(string fileName, IDateTimeProvider dateTimeProvider)
        {
            _fileName = fileName;
            _dateTime = dateTimeProvider;
            _dataLock = new object();
        }

        public IEnumerable<WorkDto> GetWorkData()
        {
            lock (_dataLock)
            {
                if (_workData == null)
                {
                    using (StreamReader sr = new StreamReader(_fileName))
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        var data = serializer.Deserialize<IEnumerable<WorkDto>>(reader);

                        // Filter, we have no submits in future
                        _workData = data
                            .Where(w => w.SubmitDateTime <= _dateTime.UtcNow)
                            .ToList();

                        // Set timezone explicit to UTC
                        _workData.AsParallel()
                            .ForAll(w => w.SubmitDateTime = TimeZoneInfo.ConvertTimeToUtc(w.SubmitDateTime, TimeZoneInfo.Utc));
                    }

                }
            }
            return _workData;
        }
    }
}

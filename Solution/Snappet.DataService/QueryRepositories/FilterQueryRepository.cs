using System;
using System.Collections.Generic;
using System.Linq;
using Snappet.Data.DataObjects;

namespace Snappet.Data.QueryRepositories
{
    public class FilterQueryRepository : IQueryRepository
    {
        private readonly IDataRepository _dataRepository;
        private readonly string _jsonFile;

        public FilterQueryRepository(IDataRepository dataRepository, string jsonFile)
        {
            _dataRepository = dataRepository;
            _jsonFile = jsonFile;
        }

        public IEnumerable<JsonData> GetDayResults(DateTime utcNow)
        {
            var data = _dataRepository.GetDataFromJson(_jsonFile)
                // Midnight utc... may this should be midnight local time? 
                // Leave it for now since dataset does not contain any data that may cause invalid results.
                .Where(row => row.SubmitDateTime >= utcNow.Date) 
                .Where(row => row.SubmitDateTime <= utcNow)
                .ToList();

            return data;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Snappet.Data.DataObjects;
using Snappet.Data.Mappers;
using Snappet.Data.QueryRepositories;

namespace Snappet.Data.DataServices
{
    public class ClassResultDataService : IClassResultDataService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly IReportRowMapper _resultMapper;

        public ClassResultDataService(IQueryRepository queryRepository, IReportRowMapper resultMapper)
        {
            _queryRepository = queryRepository;
            _resultMapper = resultMapper;
        }
        public IList<ClassResultRow> GetClassResult(DateTime utcNow)
        {
            IEnumerable<JsonData> dayResults = _queryRepository.GetDayResults(utcNow);
            return _resultMapper.MapDataToReportRow(dayResults).ToList();
        }

    }
}
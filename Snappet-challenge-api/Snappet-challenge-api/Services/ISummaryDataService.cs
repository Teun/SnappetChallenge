using System;
using System.Collections.Generic;
using Snappet_challenge_api.Models;

namespace Snappet_challenge_api.Services
{
    public interface ISummaryDataService
    {
        public List<UserSummary> GetSummaryData(string summaryDate);
        public List<string> GetSubjects(string summaryDate);
    }
}
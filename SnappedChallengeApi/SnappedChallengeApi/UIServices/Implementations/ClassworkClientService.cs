using Newtonsoft.Json;
using SnappedChallengeApi._Corelib.RestClient;
using SnappedChallengeApi._Corelib.RestClient.Request;
using SnappedChallengeApi._Corelib.RestClient.Response;
using SnappedChallengeApi.Models.Bussiness;
using SnappedChallengeApi.Models.Commons;
using SnappedChallengeApi.Models.Commons.ApiCommons;
using SnappedChallengeApi.UIServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi.RestClients;

namespace SnappedChallengeApi.UIServices.Implementations
{
    public class ClassworkClientService : IClassworkClientService
    {
        public async Task<List<ClassworkSummary>> GetClassworkSummaryRecords(DateTime startDate, DateTime endDate)
        {
            List<ClassworkSummary> records = null;
            try
            {
                records = await ClassworkRestClient.Instance().GetClassworkSummary(startDate, endDate);
            }
            catch (Exception ex)
            {
                throw;
            }

            return records;
        }
    }
}

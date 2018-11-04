using SnappedChallengeApi.Models.Bussiness;
using SnappedChallengeApi.UIServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi.RestClients;
using System.Linq;

namespace SnappedChallengeApi.UIServices.Implementations
{
    /// <summary>
    /// Classworks Client Service for the UI 
    /// In real world examples usally single page or pure javascript frameworks are being choosed so, this kind of client codes exist
    /// in the typescript and service scripts of the javascript UI frameworks.
    /// I wanted to keep it simple so there is only one application with UI combined, but i tried to make calls from UI backend controllers
    /// with rest clients for simualation of real world samples
    /// </summary>
    public class ClassworkClientService : IClassworkClientService
    {
        /// <summary>
        /// Classworks Summary Fetch Method
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<ClassworkSummary>> GetClassworkSummaryRecords(DateTime startDate, DateTime endDate)
        {
            List<ClassworkSummary> records = null;
            try
            {
                records = await ClassworkRestClient.Instance().GetClassworkSummary(startDate, endDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return records;
        }

        /// <summary>
        /// Summary data preparation method thats why i did not start with http method prefix
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public List<ClassworkSummary> SummarizeClassworkRecordsByDate(List<ClassworkSummary> records)
        {
            List<ClassworkSummary> result = new List<ClassworkSummary>();

            if (records.IsNotNullAndEmpty())
            {
                result = (from record in records
                          group record by new
                          {
                              record.Date,
                          } into gcs
                          select new ClassworkSummary()
                          {
                              Date = gcs.Key.Date,
                              ExerciseCount = gcs.Count(),
                              WrongAnswerCount = gcs.Sum(f => f.WrongAnswerCount),
                              CorrectAnswerCount = gcs.Sum(f => f.CorrectAnswerCount),
                              StudentCount = gcs.Sum(f => f.StudentCount),
                              TotalProgress = gcs.Sum(f => f.TotalProgress)
                          }).ToList();
            }

            return result;
        }
    }
}

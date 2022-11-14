using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using SnappetChallenge.Client.Model;
using Newtonsoft.Json;
using System.Linq;

namespace SnappetChallenge.Client.Service
{
    public class StudentApiService
    {
        #region Fields 
        HttpService httpService;
        #endregion


        #region Constructor
        public StudentApiService()
        {
            httpService = new HttpService();
        }

        #endregion

        #region Methods
        public async Task<IEnumerable<StatisticalReport>> LoadTodayStatisticalReport()
        {
            try
            {
                var remote = await httpService.GetRequest<IEnumerable<StatisticalReport>>(Constants.StudentTodayStatisticalReportApiUrl);
                return remote;

            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<IEnumerable<Student>> GetStudentByFilter(FilterReport filterReport)
        {
           
            if (filterReport == null) throw new ArgumentNullException(nameof(filterReport));
            var remote = await httpService.PostRequest<IEnumerable<Student>>(Constants.StudentFilterApiUrl, filterReport);
            if (remote.Count() != 0)
            return remote;
            return null;
        }

        public async Task<IEnumerable<string>> GetSubjects()
        {

            var remote = await httpService.GetRequest<IEnumerable<string>>(Constants.GetSubjects);
            if (remote.Count() != 0)
                return remote;
            return null;
        }

        public async Task<IEnumerable<string>> GetDomains()
        {

            var remote = await httpService.GetRequest<IEnumerable<string>>(Constants.GetDomains);
            if (remote.Count() != 0)
                return remote;
            return null;
        }
        #endregion
    }

   
}


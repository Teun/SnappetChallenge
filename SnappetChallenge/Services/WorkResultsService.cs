using SnappetChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SnappetChallenge.Models;
using Newtonsoft.Json;
using System.IO;

namespace SnappetChallenge.Services
{
    public class WorkResultsService : IWorkResultsService
    {
        public List<WorkResultModel> GetAllResults()
        {
            if (HttpContext.Current.Cache["main_results"] != null)
            {
                return (List<WorkResultModel>)HttpContext.Current.Cache["main_results"];
            }

            List<WorkResultModel> lstAllResults = JsonConvert.DeserializeObject<List<WorkResultModel>>(
                File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/work.json")));

            HttpContext.Current.Cache["main_results"] = lstAllResults;

            return lstAllResults;
        }

        public List<WorkResultModel> GetResultsByDay(DateTime date)
        {
            List<WorkResultModel> allResults = GetAllResults();
            List<WorkResultModel> filtered = allResults.Where(itm => itm.SubmitDateTime.Date == date.Date).ToList();
            return filtered;
        }
    }
}
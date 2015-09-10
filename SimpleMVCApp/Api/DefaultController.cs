using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace SimpleMVCApp.Api
{
    public class DefaultController : ApiController
    {

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public dynamic GetUsers()
        {
            return GetFilteredData();
        }

        private List<dynamic> GetFilteredData()
        {
            List<dynamic> validData = new List<dynamic>();
            

            /* check if the cache is populated - this is to speed up loading */
            if (HttpContext.Current.Cache["filteredData"] == null)
            {
                JArray v = JArray.Parse(DataLoader.GetData().ToString());
                DateTime cutOffTime = new DateTime(2015, 3, 24, 11, 30, 0);

                foreach (var row in v)
                {
                    DateTime dt = new DateTime();
                    if (DateTime.TryParse(row["SubmitDateTime"].ToString(), out dt) 
                        && dt.Date == cutOffTime.Date 
                        && dt < cutOffTime)
                    {
                        dynamic obj = JsonConvert.DeserializeObject(row.ToString());
                        validData.Add(obj);
                    }
                    else
                    {
                        var t = row.ToString();
                    }
                }
                // dispose the object
                v=null;
                /* set the cache of the filtered data for the next calls*/
                HttpContext.Current.Cache["filteredData"] = validData;
                return validData;
            }
            else
                return (List<dynamic>)HttpContext.Current.Cache["filteredData"];
        }


        [System.Web.Http.AcceptVerbs("GET", "POST")]       
        public dynamic GetUserSummary()
        {

            var query = from p in GetFilteredData()
                        group p by p.UserId into g
                        select new
                        {
                            UserId = g.Key,
                            TotalExercises = (int)g.Count(x => x.SubmittedAnswerId),
                            CorrectExercises = (int)g.Count(x => x.Correct == 1)
                        };

            return query;
        }

        public dynamic GetSubjectSummary()
        {
            var query = from p in GetFilteredData()
                        group p by p.Subject into g
                        select new
                        {
                            Subject = g.Key,
                            TotalExercises = (int)g.Count(x => x.SubmittedAnswerId),
                            CorrectExercises = (int)g.Count(x => x.Correct == 1)
                        };

            return query;
        }

        public dynamic GetExcerciseSummary()
        {
            var query = from p in GetFilteredData()
                        group p by p.ExerciseId into g
                        select new
                        {
                            ExerciseId = g.Key,
                            Subject = g.Select(x => x.Subject).FirstOrDefault(),
                            Domain = g.Select(x => x.Domain).FirstOrDefault(),
                            LearningObjective = g.Select(x => x.LearningObjective).FirstOrDefault(),
                            TotalExercises = (int)g.Count(x => x.SubmittedAnswerId),
                            CorrectExercises = (int)g.Count(x => x.Correct == 1)
                        };

            return query;
        }

    }
}
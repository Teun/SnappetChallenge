using System.Collections.Generic;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web;
using SnappetAPI.Models;
using System.Linq;
using System;

namespace SnappetAPI.Controllers
{
    public class ClassRoomController : ApiController
    {

        private List<Work> getAllData()
        {
            string file = HttpContext.Current.Server.MapPath("~/App_Data/work.json");
            string Json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            var result = serializer.Deserialize<List<Work>>(Json);
            return result;
        }

        [HttpGet]
        [Route("GetReport")]
        public IEnumerable<Report> GetReport(string date,string subject, string domain,string viewtype)
        {
            var workData = this.getAllData();
            var dateToSearch = DateTime.Parse(date);
            var reports = new List<Report>();

            if (workData != null)
            {
                var workByDate = workData.FindAll(a => a.SubmitDate == dateToSearch);

                if (!string.IsNullOrWhiteSpace(subject))
                {
                   workByDate = workByDate.FindAll(a => a.Subject == subject);
                }
                if (!string.IsNullOrWhiteSpace(domain))
                {
                    workByDate = workByDate.FindAll(a => a.Domain == domain);
                }

                IEnumerable<IGrouping<string,Work>> groupByList;

                if (viewtype == "subject")
                {
                    groupByList = workByDate.ToList().GroupBy(a => a.Subject);
                }
                else if (viewtype== "domain")
                {
                    groupByList = workByDate.ToList().GroupBy(a => a.Domain);
                }
                else if (viewtype== "learningObjective")
                {
                    groupByList = workByDate.ToList().GroupBy(a => a.LearningObjective);
                }else
                {
                    groupByList = workByDate.ToList().GroupBy(a => a.Subject);
                }
                
                foreach(var item in groupByList)
                {
                    var report = new Report();
                    report.Key = item.Key;
                    report.NoOfExercises = item.GroupBy(a => a.ExerciseId).Count();
                    report.NoOfStudents = item.GroupBy(a => a.UserId).Count();
                    report.CorrectAttempts = item.ToList().FindAll(a => a.Correct == 1).Count();
                    report.IncorrectAttempts = item.ToList().FindAll(a => a.Correct == 0).Count();
                    reports.Add(report);
                }

            }

            return reports;
        }


        [HttpGet]
        [Route("GetStudentDetails")]
        public IEnumerable<Student> GetStudentDetails(string date, string subject, string domain,string objective)
        {
            var workData = this.getAllData();
            var dateToSearch = DateTime.Parse(date);
            var reports = new List<Student>();

            if (workData != null)
            {
                var workByDate = workData.FindAll(a => a.SubmitDate == dateToSearch 
                && a.Subject == subject && a.Domain == domain && a.LearningObjective==objective);

                var workGroupedByUser = workByDate.ToList().GroupBy(a => a.UserId);

                        foreach (var user in workGroupedByUser)
                        {
                            var student = new Student();
                            student.Id = user.Key;
                            student.NoOfAttempts = user.Count();
                            student.NoOfExercise = user.GroupBy(a => a.ExerciseId).Count();
                            student.RightAttemptCount = user.Count(a => a.Correct == 1);
                            student.WrongAttemptCount = student.NoOfAttempts - student.RightAttemptCount;
                    double progress = (double)student.RightAttemptCount / (double)student.NoOfAttempts*100;
                    var progressInInteger= Math.Round(progress, 0);
                            student.Progress = Int32.Parse(progressInInteger.ToString());

                    reports.Add(student);
                        }
            }

            return reports;
        }
       
    }
}
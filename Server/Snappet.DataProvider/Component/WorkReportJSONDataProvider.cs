using Snappet.Common.BusinessLogic;
using Snappet.Model.DataProvider;
using Snappet.Model.Domain;
using Snappet.Model.Filters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Unity;

namespace Snappet.DataProvider.Component
{
    public class WorkReportJSONDataProvider : BusinessComponent, IWorkReportJSONDataProvider
    {
        
        public WorkReportJSONDataProvider(IUnityContainer container) : base(container)
        {
        }
        string dataType = null;
        public string DataType { 
            get
            {
                return dataType = dataType  ?? ConfigurationManager.AppSettings["dataType"].ToString();
            }
        }

        private IDataProvider dataProvider;
        public IDataProvider DataProvider
        {
            get { return dataProvider = dataProvider ?? GetRepository<IDataProvider>(DataType); }
        }
        #region Public function
        public IEnumerable<FilterDateSubject> GetFilterDetails()
        {
            var works = GetAllWorks();
            List<FilterDateSubject> dateSubjectDomains = new List<FilterDateSubject>();
            if (works != null && works.Any())
            {
                var dates = works.GroupBy(p => p.SubmitDate);

                GetFilter(dates, dateSubjectDomains);
            }

            return dateSubjectDomains;
        }

        public IEnumerable<Work> GetAllWorks()
        {
            return DataProvider.GetWorkDetails();
        }
        public IEnumerable<FilterDateSubject> GetFilterDetailsByDate(string dateTime)
        {
            var works = GetAllWorks();
            List<FilterDateSubject> dateSubjectDomains = new List<FilterDateSubject>();
            if (works != null && works.Any())
            {
                var dates = works.Where(p => p.SubmitDate == DateTime.Parse(dateTime)).GroupBy(p => p.SubmitDate);

                GetFilter(dates, dateSubjectDomains);
            }

            return dateSubjectDomains;
        }
       

        public IEnumerable<WorkReport> GetWorkReport(DateTime date, string subject, string domain)
        {
            IEnumerable<Work> workDetails = DataProvider.GetWorkDetails();
            List<WorkReport> workReport = new List<WorkReport>();

            if (workDetails != null && workDetails.Any())
            {
                var getSpecificDate = workDetails.Where(p => p.SubmitDate == date);

                if (!string.IsNullOrWhiteSpace(subject))
                {
                    getSpecificDate = getSpecificDate.Where(p => p.Subject == subject);
                }

                if (!string.IsNullOrWhiteSpace(domain))
                {
                    getSpecificDate = getSpecificDate.Where(p => p.Domain == domain);
                }

                var workReports = getSpecificDate.GroupBy(p => p.LearningObjective);


                foreach (var item in workReports)
                {
                    var users = item.GroupBy(p => p.UserId);
                    WorkReport report = new WorkReport
                    {
                        LearningObjective = item.Key,
                        TotalExerices = item.GroupBy(p => p.ExerciseId).Count(),
                        TotalStudents = users.Count(),
                    };

                    if (users != null && users.Any())
                    {
                        report.StudentDetails = new List<StudentDetail>();
                        foreach (var exercise in users)
                        {
                            StudentDetail studentDetail = GetStudentDetails(exercise);
                            report.StudentDetails.Add(studentDetail);
                        }
                    }
                    report.Progress = (report.StudentDetails.Sum(p => p.Progress) / users.Count());

                    var domainFirstOrDefault = item.FirstOrDefault();
                    if (domainFirstOrDefault != null) report.Domain = domainFirstOrDefault.Domain;
                    var subjectFirstOrDefault = item.FirstOrDefault();
                    if (subjectFirstOrDefault != null) report.Subject = subjectFirstOrDefault.Subject;

                    workReport.Add(report);
                }
            }
            return workReport;
        }

        #endregion

        #region Private function
        private static void GetFilter(IEnumerable<IGrouping<DateTime, Work>> dates, List<FilterDateSubject> dateSubjectDomains)
        {
            foreach (var date in dates)
            {
                var filterDateSubject = new FilterDateSubject();
                filterDateSubject.DateTime = date.Key;
                var subjects = date.GroupBy(p => p.Subject);
                filterDateSubject.SubjectsList = new List<FilterSubjectDomain>();
                foreach (var subject in subjects)
                {
                    var filterSubjectDomain = new FilterSubjectDomain();
                    filterSubjectDomain.Name = subject.Key;
                    filterSubjectDomain.DomainList = subject.GroupBy(p => p.Domain).Select(p => p.Key).ToList();
                    filterDateSubject.SubjectsList.Add(filterSubjectDomain);
                }
                dateSubjectDomains.Add(filterDateSubject);
            }
        }
        private StudentDetail GetStudentDetails(IGrouping<int, Work> exercise)
        {
            var exerciseDetails = new StudentDetail
            {
                UserId = exercise.Key,
                TotalAttempts = exercise.Count(),
                TotalAttemptsRight = exercise.Count(p => p.Correct),
                TotalExercise = exercise.GroupBy(p => p.ExerciseId).Count(),
            };
            exerciseDetails.Progress = exercise.Sum(p => p.Progress);
            exerciseDetails.TotalAttemptsWrong = exerciseDetails.TotalAttempts - exerciseDetails.TotalAttemptsRight;
            return exerciseDetails;
        }
        #endregion
    }
}
